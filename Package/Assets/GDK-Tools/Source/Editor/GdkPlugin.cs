// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.IO;
using System.Diagnostics;
using Microsoft.GameCore.Utilities;
using UnityEditor;
using UnityEngine;

using Debug = UnityEngine.Debug;
using XGamingRuntime;

namespace Microsoft.GameCore.Tools
{
    [InitializeOnLoad]
    public static class GdkPlugin
    {
        static GdkPlugin()
        {
            GdkUtilities.PullGdkDlls();
#if MICROSOFT_GAME_CORE
            EditorApplication.playModeStateChanged += OnPlayModeChange;
#endif
        }

#if MICROSOFT_GAME_CORE
        private static void OnPlayModeChange(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                GdkUtilities.PullGdkDlls();
            }
            else if (state == PlayModeStateChange.ExitingPlayMode)
            {
                SDK.XBL.XblCleanup((int hresult) => { });
            }
        }
#endif

        [MenuItem("GDK/Documentation/Developer Portal (GDK)")]
        private static void OpenDeveloperPortal()
        {
            Application.OpenURL("https://aka.ms/gamedevdocs");
        }

        [MenuItem("GDK/Documentation/Unity Integration Documentation (GDK)")]
        private static void OpenUnityDocs()
        {
            Application.OpenURL("https://aka.ms/gdk_unity");
        }

        [MenuItem("GDK/Associate with the Microsoft Store")]
        internal static void EditGameConfig()
        {
            string configEditorPath = Path.Combine(GdkUtilities.GdkToolsPath, "GameConfigEditor.exe");
            if (!File.Exists(configEditorPath))
            {
                EditorUtility.DisplayDialog("GDK tools not found", "Ensure the GDK is installed on this PC.", "Close");
                return;
            }

            if (!File.Exists(GdkUtilities.GameConfigPath))
            {
                EditorUtility.DisplayDialog("MicrosoftGame.config not found", "No MicrosoftGame.config file was found. Please re-import this plugin.", "Close");
                return;
            }

            using (Process configEditorProcess = new Process())
            {
                configEditorProcess.StartInfo.FileName = configEditorPath;
                configEditorProcess.StartInfo.Arguments = string.Format("\"{0}\" GameEngine", GdkUtilities.GameConfigPath);

                configEditorProcess.Start();
                configEditorProcess.WaitForExit();
                GdkEditorHelpers.SyncScidToGameConfig();
            }
        }

        [MenuItem("GDK/PC/Switch sandbox")]
        private static void SwitchToTestSandbox()
        {
            GdkSwitchSandboxEditorWindow window = EditorWindow.GetWindow<GdkSwitchSandboxEditorWindow>();
            window.minSize = new Vector2(400, 200);
            window.maxSize = new Vector2(600, 400);
            GUIContent titleContent = new GUIContent("GDK - Switch PC Sandbox");
            window.titleContent = titleContent;
            window.Show();
        }

        [MenuItem("GDK/PC/Update Editor Game Config")]
        private static void CopyConfigToEditorLocation()
        {
            GdkEditorHelpers.StartCmdProcessAsAdmin(string.Format("/C copy \"{0}\" \"{1}\"", GdkUtilities.GameConfigPath, Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)));
        }

        [MenuItem("GDK/PC/Build and Run")]
        private static void CreatePackage()
        {
            GdkBuildEditorWindow window = EditorWindow.GetWindow<GdkBuildEditorWindow>();
            window.minSize = new Vector2(600, 450);
            GUIContent titleContent = new GUIContent("GDK - PC Build and Run");
            window.titleContent = titleContent;
            window.Show();
        }

        [MenuItem("GDK/Send feedback")]
        private static void SendFeedback()
        {
            Application.OpenURL("https://github.com/microsoft/gdk-unity-package/issues/new");
        }
    }
}