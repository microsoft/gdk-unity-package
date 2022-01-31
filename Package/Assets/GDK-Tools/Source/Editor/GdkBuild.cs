using Microsoft.GameCore.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEditor;
#if UNITY_2018_4_OR_NEWER
using UnityEditor.Build.Reporting;
#endif
using UnityEngine;

public static class GdkBuild
{

    internal static string aumid;
    private static string buildOutputFolderPath;
    private static string buildWin32OutputFolderPath;
    private static string buildMsixvcOutputFolderPath;
    private static string contentIdOverride;
    private static string originalSquare150x150LogoPath;
    private static string originalSquare44x44LogoPath;
    private static string originalSplashScreenImagePath;
    private static string originalStoreLogoPath;
    private static bool previousForceSingleInstanceValue;

    private const string MsixvcOutputDirectory = "MSIXVC";
    private const string Win32OutputDirectory = "Win32";
    private const string GameCorePlatformDefine = "MICROSOFT_GAME_CORE";

    internal static bool Build(bool buildOnly, bool createPackageForStoreUpload)
    {
        bool succeeded = false;

        succeeded = ChooseOutputFolder();
        if (succeeded)
        {
            succeeded = PreBuild(buildWin32OutputFolderPath);
        }
        if (succeeded)
        {
            succeeded = BuildWin32();
        }
        if (succeeded)
        {
            succeeded = PostBuild(buildWin32OutputFolderPath, buildMsixvcOutputFolderPath, createPackageForStoreUpload);
        }
        if (succeeded && buildOnly)
        {
            succeeded = OpenBuildOutputFolder();
        }

        return succeeded;
    }

    /// <summary>
    /// Runs pre build tasks to create a GDK package. Note: You need to define MICROSOFT_GAME_CORE in the custom scripting defines for
    /// the standalone build target.
    /// </summary>
    /// <param name="pcStandaloneBuildPath"></param>
    /// <returns></returns>
    public static bool PreBuild(string pcStandaloneBuildPath)
    {
        bool succeeded = false;

        buildWin32OutputFolderPath = pcStandaloneBuildPath;

        succeeded = CopyManifestFiles();

        return succeeded;
    }

    /// <summary>
    /// Runs the post build tasks to create a GDK package.
    /// </summary>
    /// <param name="pcStandaloneBuildPath">The path to your PC Standalone build output folder.</param>
    /// <param name="gdkBuildOutputFolderPath">The path to the folder where you would like the GDK build to go.</param>
    /// <param name="createPackageForStoreUpload">
    /// True if you want to create a package for uploading to the store. False to create a package to run on your local machine. 
    /// </param>
    /// <returns>True if the tasks succeeded. False if one or more tasks failed.</returns>
    public static bool PostBuild(string pcStandaloneBuildPath, string gdkBuildOutputFolderPath, bool createPackageForStoreUpload)
    {
        bool succeeded = false;

        try
        {
            if (!Directory.Exists(gdkBuildOutputFolderPath))
            {
                Directory.CreateDirectory(gdkBuildOutputFolderPath);
            }
        }
        catch (Exception)
        {
            GdkEditorHelpers.LogError("Error: Could not find or create GDK Build output directory: " + gdkBuildOutputFolderPath);
        }

        buildWin32OutputFolderPath = pcStandaloneBuildPath;
        buildMsixvcOutputFolderPath = gdkBuildOutputFolderPath;

        succeeded = PostWin32BuildCleanup();
        if (succeeded)
        {
            succeeded = CreateLayoutFile();
        }
        if (succeeded)
        {
            succeeded = MakePackage(createPackageForStoreUpload);
        }

        return succeeded;
    }

    internal static bool InstallAndRun(bool buildSucceeded)
    {
        if (buildSucceeded)
        {
            buildSucceeded = InstallPackage();
        }
        if (buildSucceeded)
        {
            buildSucceeded = LaunchPackage();
        }

        return buildSucceeded;
    }

    private static bool ChooseOutputFolder()
    {
        bool succeeded = true;
        string rawBuildOutputFolderPath = EditorUtility.OpenFolderPanel("Select an output folder for your MSIXVC package", string.Empty, string.Empty);
        if (rawBuildOutputFolderPath == string.Empty)
        {
            succeeded = false;
        }
        else
        {
            buildOutputFolderPath = rawBuildOutputFolderPath.Replace("/", "\\");

            // Create two subfolders underneath. One for the Win32 build and another for the MSIXVC package.
            buildWin32OutputFolderPath = buildOutputFolderPath + "\\" + Win32OutputDirectory;
            buildMsixvcOutputFolderPath = buildOutputFolderPath + "\\" + MsixvcOutputDirectory;

            Directory.CreateDirectory(buildWin32OutputFolderPath);
            Directory.CreateDirectory(buildMsixvcOutputFolderPath);
        }

        return succeeded;
    }

    private static bool CopyManifestFiles()
    {
        bool succeeded = true;

        string gameConfigFilePath = string.Empty;
        string square150x150LogoPath = string.Empty;
        string square44x44LogoPath = string.Empty;
        string splashScreenImagePath = string.Empty;
        string storeLogoPath = string.Empty;

        gameConfigFilePath = GdkEditorHelpers.GetGameConfigPath();

        // Use the first MicrosoftGame.Config
        if (!string.IsNullOrEmpty(gameConfigFilePath))
        {
            XDocument gameConfigXmlDoc = XDocument.Load(gameConfigFilePath);
            try
            {
                string imagesPath = GdkEditorHelpers.GetGameConfigPath().Replace("MicrosoftGame.Config", string.Empty);
                XElement executableEl = (from executable in gameConfigXmlDoc.Descendants("Executable")
                                         select executable).First();
                executableEl.SetAttributeValue("Name", PlayerSettings.productName + ".exe");

                // Find the images
                XElement shellVisualsEl = (from shellVisual in gameConfigXmlDoc.Descendants("ShellVisuals")
                                           select shellVisual).First();

                XAttribute square150x150LogoAttribute = shellVisualsEl.Attribute("Square150x150Logo");
                originalSquare150x150LogoPath = square150x150LogoAttribute.Value;
                square150x150LogoPath = (imagesPath + originalSquare150x150LogoPath).Replace("/", "\\");

                XAttribute square44x44LogoAttribute = shellVisualsEl.Attribute("Square44x44Logo");
                originalSquare44x44LogoPath = square44x44LogoAttribute.Value;
                square44x44LogoPath = (imagesPath + originalSquare44x44LogoPath).Replace("/", "\\");

                XAttribute splashScreenImageAttribute = shellVisualsEl.Attribute("SplashScreenImage");
                originalSplashScreenImagePath = splashScreenImageAttribute.Value;
                splashScreenImagePath = (imagesPath + originalSplashScreenImagePath).Replace("/", "\\");

                XAttribute storeLogoAttribute = shellVisualsEl.Attribute("StoreLogo");
                originalStoreLogoPath = storeLogoAttribute.Value;
                storeLogoPath = (imagesPath + originalStoreLogoPath).Replace("/", "\\");

                // Check for a Content ID override
                XElement contentIdOverrideEl = (from contentIdOverride in gameConfigXmlDoc.Descendants("ContentIdOverride")
                                                select contentIdOverride).First();
                contentIdOverride = contentIdOverrideEl.Value;

                gameConfigXmlDoc.Save(gameConfigFilePath);
            }
            catch (Exception)
            {
                GdkEditorHelpers.LogError("Error: Invalid or corrupt MicrosoftGame.Config.");
            }
        }
        else
        {
            GdkEditorHelpers.LogError("Error: No Microsoft.GameConfig found. You can create one under by selecting the GDK > Associate with the Store.");
        }

        List<string> storeAssetsToCopy = new List<string>();
        storeAssetsToCopy.Add(gameConfigFilePath);
        storeAssetsToCopy.Add(square150x150LogoPath);
        storeAssetsToCopy.Add(square44x44LogoPath);
        storeAssetsToCopy.Add(splashScreenImagePath);
        storeAssetsToCopy.Add(storeLogoPath);

        foreach (string storeAssetToCopy in storeAssetsToCopy)
        {
            string fileName = Path.GetFileName(storeAssetToCopy);
            string fullSourcePath = storeAssetToCopy;
            string destinationPath = buildWin32OutputFolderPath + "\\" + fileName;
            File.Copy(fullSourcePath, destinationPath, true);
        }

        return succeeded;
    }

    internal static bool BuildWin32()
    {
        bool buildSucceeded = true;

        EditorBuildSettingsScene[] buildScenes = EditorBuildSettings.scenes;
        if (buildScenes.Count() <= 0)
        {
            GdkEditorHelpers.LogError("Error: No scenes specified to build. Please select scenes in Unity's Build Settings dialog.");
            return false;
        }

        List<string> scenePaths = new List<string>();
        foreach (EditorBuildSettingsScene buildScene in buildScenes)
        {
            if (buildScene.enabled)
            {
                scenePaths.Add(buildScene.path);
            }
        }

        // We set forceSingleInstance to true, because if we do not, then multiple instance of the game can be launched, but
        // the gaming runtime APIs do not work with two instances.
        previousForceSingleInstanceValue = PlayerSettings.forceSingleInstance;
        PlayerSettings.forceSingleInstance = true;

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = scenePaths.ToArray();
        buildPlayerOptions.locationPathName = buildWin32OutputFolderPath + "/" + PlayerSettings.productName + ".exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows;

        if (EditorUserBuildSettings.selectedStandaloneTarget == BuildTarget.StandaloneWindows ||
            EditorUserBuildSettings.selectedStandaloneTarget == BuildTarget.StandaloneWindows64)
        {
            buildPlayerOptions.target = EditorUserBuildSettings.selectedStandaloneTarget;
        }
        else
        {
            buildPlayerOptions.target = BuildTarget.StandaloneWindows;
        }
        buildPlayerOptions.options = ImportWin32BuildSettings();

#if UNITY_2018_4_OR_NEWER
            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            BuildSummary summary = report.summary;

            if (summary.result == BuildResult.Succeeded)
            {
                GdkEditorHelpers.LogInfo("Build succeeded: " + summary.totalSize + " bytes");
                buildSucceeded = true;
            }
            else if (summary.result == BuildResult.Failed)
            {
                GdkEditorHelpers.LogInfo("Build failed. " + summary.totalErrors + " errors.");
                buildSucceeded = false;
            }
            else if (summary.result == BuildResult.Cancelled)
            {
                GdkEditorHelpers.LogInfo("Build cancelled.");
                buildSucceeded = false;
            }
            else
            {
                GdkEditorHelpers.LogInfo("Build failed.");
            }
#else
        string report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        GdkEditorHelpers.LogInfo(report);
#endif

        PlayerSettings.forceSingleInstance = previousForceSingleInstanceValue;

        return buildSucceeded;
    }

    private static BuildOptions ImportWin32BuildSettings()
    {
        BuildOptions buildOptions = BuildOptions.None;
        // Switch the platform to Win32, x64. The GDK only supports x64.
        BuildTarget buildTarget = BuildTarget.StandaloneWindows64;
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, buildTarget);
        if (EditorUserBuildSettings.development)
        {
            buildOptions |= BuildOptions.Development;

            if (EditorUserBuildSettings.allowDebugging)
            {
                buildOptions |= BuildOptions.AllowDebugging;
            }
            if (EditorUserBuildSettings.buildScriptsOnly)
            {
                buildOptions |= BuildOptions.BuildScriptsOnly;
            }
#if UNITY_2019_3_OR_NEWER
            if (EditorUserBuildSettings.buildWithDeepProfilingSupport)
            {
                buildOptions |= BuildOptions.EnableDeepProfilingSupport;
            }
#endif
            if (EditorUserBuildSettings.connectProfiler)
            {
                buildOptions |= BuildOptions.ConnectWithProfiler;
            }
#if UNITY_2019_1_OR_NEWER
            if (EditorUserBuildSettings.waitForPlayerConnection)
            {
                buildOptions |= BuildOptions.WaitForPlayerConnection;
            }
#endif
        }
        if (EditorUserBuildSettings.enableHeadlessMode)
        {
            buildOptions |= BuildOptions.EnableHeadlessMode;
        }

        return buildOptions;
    }

    private static bool PostWin32BuildCleanup()
    {
        bool succeeded = true;

        string[] files = Directory.GetFiles(buildWin32OutputFolderPath, "MicrosoftGame.Config", SearchOption.TopDirectoryOnly);
        string gameConfigFilePath = files[0];
        string cleanedGameConfigFilePath = gameConfigFilePath.Replace("/", "\\");

        XDocument gameConfigXmlDoc = XDocument.Load(cleanedGameConfigFilePath);
        XElement shellVisualsEl = (from shellVisual in gameConfigXmlDoc.Descendants("ShellVisuals")
                                   select shellVisual).First();

        // We need to rewrite the manifest to point at where the images will be placed
        // in the build directory.
        shellVisualsEl.SetAttributeValue("Square150x150Logo", Path.GetFileName(originalSquare150x150LogoPath));
        shellVisualsEl.SetAttributeValue("Square44x44Logo", Path.GetFileName(originalSquare44x44LogoPath));
        shellVisualsEl.SetAttributeValue("SplashScreenImage", Path.GetFileName(originalSplashScreenImagePath));
        shellVisualsEl.SetAttributeValue("StoreLogo", Path.GetFileName(originalStoreLogoPath));

        gameConfigXmlDoc.Save(cleanedGameConfigFilePath);

        return succeeded;
    }

    private static bool CreateLayoutFile()
    {
        string arguments = string.Format("/c makepkg.exe genmap /f \"{0}\\layout.xml\" /d \"{0}\"", buildWin32OutputFolderPath);
        return GdkEditorHelpers.StartCmdProcess(arguments);
    }

    private static bool MakePackage(bool createForStoreUpload)
    {
        string makePkgExtraArgs = string.Empty;
        if (!string.IsNullOrEmpty(contentIdOverride))
        {
            makePkgExtraArgs = "/contentid " + contentIdOverride;
        }
        string arguments = string.Format("/c makepkg.exe pack /f \"{0}\\layout.xml\" /d \"{0}\" /pd \"{1}\" /pc /CorrelationId Unity " + makePkgExtraArgs, buildWin32OutputFolderPath, buildMsixvcOutputFolderPath);
        if (createForStoreUpload)
        {
            arguments += " /l";
        }
        return GdkEditorHelpers.StartCmdProcess(arguments);
    }

    private static bool OpenBuildOutputFolder()
    {
        bool succeeded = true;
        Process.Start("explorer.exe", buildMsixvcOutputFolderPath);
        return succeeded;
    }

    private static bool InstallPackage()
    {
        bool succeeded = true;

        string[] files = Directory.GetFiles(buildMsixvcOutputFolderPath, "*.msixvc");
        string msixvcFilePath = string.Empty;
        if (files.Length > 0)
        {
            msixvcFilePath = files[0];
            if (files.Length > 1)
            {
                GdkEditorHelpers.LogInfo("More than one .msixvc found. Installing this one: " + files[0]);
            }

            // We always try to uninstall an old package before installing a new one to avoid
            // cases where an old install is not fully cleaned up.
            string pFN = Path.GetFileNameWithoutExtension(msixvcFilePath);

            string listExistingGamesArguments = "/c wdapp.exe list";
            string standardOutput = string.Empty;
            string standardError = string.Empty;
            GdkEditorHelpers.StartCmdProcessAndReturnOutput(listExistingGamesArguments, out standardOutput, out standardError);
            if (standardOutput.Contains(pFN))
            {
                string uninstallArguments = "/c wdapp.exe uninstall " + pFN;
                succeeded = GdkEditorHelpers.StartCmdProcess(uninstallArguments);
            }

            string arguments = "/c wdapp.exe install \"" + msixvcFilePath + "\"";
            succeeded = GdkEditorHelpers.StartCmdProcess(arguments, out aumid);
        }
        else
        {
            GdkEditorHelpers.LogError("Error: No .msixvc found.");
        }

        return succeeded;
    }
    private static bool LaunchPackage()
    {
        string arguments = "/c wdapp.exe launch " + aumid;
        return GdkEditorHelpers.StartCmdProcess(arguments);
    }
}
