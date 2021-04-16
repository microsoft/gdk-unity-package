// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using UnityEditor;
#if UNITY_2018_4_OR_NEWER
using UnityEditor.Build.Reporting;
#endif
using UnityEngine;

namespace Microsoft.GameCore.Tools
{
    public class GdkBuildEditorWindow : EditorWindow
    {
        private static bool initialized;
        private Vector2 scenesScrollPos;
        private string aumid;
        private string buildOutputFolderPath;
        private string buildWin32OutputFolderPath;
        private string buildMsixvcOutputFolderPath;
        private string contentIdOverride;
        private string originalSquare150x150LogoPath;
        private string originalSquare44x44LogoPath;
        private string originalSplashScreenImagePath;
        private string originalStoreLogoPath;
        private bool previousForceSingleInstanceValue;
        private static bool isGameCorePlatformDefined;
        private static bool createPackageForStoreUpload;
        private static bool isBuilding;
        private static BuildTarget previousStandaloneBuildTarget;

        private const string ContentIdOverrideNodeXPath = "/Game/DevelopmentOnly/ContentIdOverride";
        private const string MsixvcOutputDirectory = "MSIXVC";
        private const string Win32OutputDirectory = "Win32";
        private const string GameCorePlatformDefine = "MICROSOFT_GAME_CORE";

        // Start is called before the first frame update
        void Start()
        {
        }

        private void Initialize()
        {
            scenesScrollPos = Vector2.zero;
            aumid = string.Empty;

            isGameCorePlatformDefined = IsGameCoreScriptingDefineEnabled();

            EditorStyles.textArea.wordWrap = true;

            initialized = true;
        }

        void OnGUI()
        {
            if (!initialized)
            {
                Initialize();
            }

            EditorGUI.indentLevel = 1;

            EditorGUILayout.Separator();

            // Header
            EditorGUILayout.LabelField("Create a package that you can upload to the Microsoft Store (.msixvc).", EditorStyles.wordWrappedLabel);
            GdkEditorHelpers.SectionSeperator();

            // Scenes
            EditorGUILayout.LabelField("Scenes in Build", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("The following scenes will be included in your build. You can change these scenes in the Unity build menu. To access the build settings go to File > Build Settings...", EditorStyles.wordWrappedLabel);

            EditorGUILayout.Separator();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            scenesScrollPos = EditorGUILayout.BeginScrollView(scenesScrollPos);

            EditorGUILayout.Separator();

            EditorBuildSettingsScene[] buildScenes = EditorBuildSettings.scenes;
            foreach (EditorBuildSettingsScene buildScene in buildScenes)
            {
                if (buildScene.enabled)
                {
                    EditorGUILayout.LabelField(buildScene.path, EditorStyles.wordWrappedLabel);
                }
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

            GdkEditorHelpers.SectionSeperator();

            // Action buttons
            EditorGUILayout.LabelField("The PC, Mac, Linux & Standalone build settings will be used. You can edit these build settings in the Unity build menu. To access the build menu go to File > Build Settings...", EditorStyles.wordWrappedLabel);

            EditorGUILayout.Separator();

            isGameCorePlatformDefined = EditorGUILayout.ToggleLeft("Define " + GameCorePlatformDefine, isGameCorePlatformDefined);
            string scriptDefineMicrosoftGamecoreHelpText = "Checking this box means that any code you have conditionally defined using " +
                "'#if MICROSOFT_GAME_CORE' will be defined in the editor, providing an easy way to catch compilation errors without having " +
                "to do a full build.Note that MICROSOFT_GAME_CORE will always be defined when you click the 'Build' or 'Build and Run' buttons below";
            EditorGUILayout.LabelField(scriptDefineMicrosoftGamecoreHelpText, EditorStyles.helpBox);
            if (!isBuilding)
            {
                if (isGameCorePlatformDefined)
                {
                    EnableGameCoreScriptingDefine();
                    previousStandaloneBuildTarget = EditorUserBuildSettings.activeBuildTarget;
                    EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);
                }
                else
                {
                    DisableGameCoreScriptingDefine();
                    EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, previousStandaloneBuildTarget);
                }
            }

            GdkEditorHelpers.SectionSeperator();

            createPackageForStoreUpload = EditorGUILayout.ToggleLeft("Create package to upload to the store", createPackageForStoreUpload);
            string createPackageForStoreUploadHelpText = "Checking this box means that the package will be encypted, which is required for " +
                "uploading to the store. Clicking the Build button will generate the files to upload to the store.";
            EditorGUILayout.LabelField(createPackageForStoreUploadHelpText, EditorStyles.helpBox);

            GdkEditorHelpers.SectionSeperator();

            if (!isGameCorePlatformDefined)
            {
                EditorGUILayout.HelpBox("You need to check \"Define MICROSOFT_GAME_CORE\" above to Build.", MessageType.Warning);
            }

            EditorGUILayout.BeginHorizontal(EditorStyles.inspectorDefaultMargins);
            EditorGUI.BeginDisabledGroup(!isGameCorePlatformDefined);
            if (GUILayout.Button("Build"))
            {
                Build(true);
            }
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(!isGameCorePlatformDefined || createPackageForStoreUpload);
            if (GUILayout.Button("Build and Run"))
            {
                bool succeeded = false;
                succeeded = Build(false);
                succeeded = InstallAndRun(succeeded);
            }
            else
            {
                // We put this in the else statement because otherwise Unity will print an error to the screen
                // because EndHorizontal gets called without a BeginHorizontal. This is because of the call 
                // preceeding it which takes longer than one frame.
                EditorGUILayout.EndHorizontal();
            }
            EditorGUI.EndDisabledGroup();

            GdkEditorHelpers.SectionSeperator();
        }

        private bool IsGameCoreScriptingDefineEnabled()
        {
            bool isGameCoreScriptingDefineEnabled = false;
            string existingScriptingDefineSymbolsForGroup = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
            if (existingScriptingDefineSymbolsForGroup.Contains(GameCorePlatformDefine))
            {
                isGameCoreScriptingDefineEnabled = true;
            }
            isGameCorePlatformDefined = isGameCoreScriptingDefineEnabled;
            return isGameCoreScriptingDefineEnabled;
        }

        private void EnableGameCoreScriptingDefine()
        {
            string existingScriptingDefineSymbolsForGroup = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
            if (!IsGameCoreScriptingDefineEnabled())
            {
                if (!string.IsNullOrEmpty(existingScriptingDefineSymbolsForGroup) &&
                    existingScriptingDefineSymbolsForGroup[existingScriptingDefineSymbolsForGroup.Length - 1] != ';')
                {
                    existingScriptingDefineSymbolsForGroup += ";";
                }
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, existingScriptingDefineSymbolsForGroup + GameCorePlatformDefine + ";");
                isGameCorePlatformDefined = true;
            }
        }

        private void DisableGameCoreScriptingDefine()
        {
            string existingScriptingDefineSymbolsForGroup = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
            if (existingScriptingDefineSymbolsForGroup.Contains(GameCorePlatformDefine))
            {
                string newScriptingDefineSymbolsForGroup = existingScriptingDefineSymbolsForGroup.Replace(GameCorePlatformDefine + ";", "");
                newScriptingDefineSymbolsForGroup = newScriptingDefineSymbolsForGroup.Replace(GameCorePlatformDefine, "");
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, newScriptingDefineSymbolsForGroup);
                isGameCorePlatformDefined = false;
            }
        }

        private bool Build(bool buildOnly = false)
        {
            bool succeeded = false;
            isBuilding = true;

            succeeded = ChooseOutputFolder();
            if (succeeded)
            {
                succeeded = CopyManifestFiles();
            }
            if (succeeded)
            {
                succeeded = BuildWin32();
            }
            if (succeeded)
            {
                succeeded = PostBuild();
            }
            if (succeeded)
            {
                succeeded = CreateLayoutFile();
            }
            if (succeeded)
            {
                succeeded = MakePackage();
            }
            if (succeeded && buildOnly)
            {
                succeeded = OpenBuildOutputFolder();
            }
            isBuilding = false;

            return succeeded;
        }

        private bool InstallAndRun(bool buildSucceeded)
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

        private bool ChooseOutputFolder()
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

        private bool CopyManifestFiles()
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

        private bool BuildWin32()
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

        private BuildOptions ImportWin32BuildSettings()
        {
            BuildOptions buildOptions = BuildOptions.None;
            // Switch the platform to Win32, x64. The GDK only supports x64.
            BuildTarget buildTarget = BuildTarget.StandaloneWindows64;
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, buildTarget);
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
            if (EditorUserBuildSettings.development)
            {
                buildOptions |= BuildOptions.Development;
            }
            if (EditorUserBuildSettings.enableHeadlessMode)
            {
                buildOptions |= BuildOptions.EnableHeadlessMode;
            }
#if UNITY_2019_1_OR_NEWER
            if (EditorUserBuildSettings.waitForPlayerConnection)
            {
                buildOptions |= BuildOptions.WaitForPlayerConnection;
            }
#endif

            return buildOptions;
        }

        private bool PostBuild()
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

        private bool CreateLayoutFile()
        {
            string arguments = string.Format("/c makepkg.exe genmap /f \"{0}\\layout.xml\" /d \"{0}\"", buildWin32OutputFolderPath);
            return GdkEditorHelpers.StartCmdProcess(arguments);
        }

        private bool MakePackage()
        {
            string makePkgExtraArgs = string.Empty;
            if (!string.IsNullOrEmpty(contentIdOverride))
            {
                makePkgExtraArgs = "/contentid " + contentIdOverride;
            }
            string arguments = string.Format("/c makepkg.exe pack /f \"{0}\\layout.xml\" /d \"{0}\" /pd \"{1}\" /pc /CorrelationId Unity " + makePkgExtraArgs, buildWin32OutputFolderPath, buildMsixvcOutputFolderPath);
            if (createPackageForStoreUpload)
            {
                arguments += " /l";
            }
            return GdkEditorHelpers.StartCmdProcess(arguments);
        }

        private bool OpenBuildOutputFolder()
        {
            bool succeeded = true;
            Process.Start("explorer.exe", buildMsixvcOutputFolderPath);
            return succeeded;
        }

        private bool InstallPackage()
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
        private bool LaunchPackage()
        {
            string arguments = "/c wdapp.exe launch " + aumid;
            return GdkEditorHelpers.StartCmdProcess(arguments);
        }
    }
}