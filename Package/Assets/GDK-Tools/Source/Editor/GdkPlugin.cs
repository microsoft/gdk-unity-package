// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.IO;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

namespace Microsoft.GameCore.Tools
{
    [InitializeOnLoad]
    public static class GdkPlugin
    {
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
            string configEditorPath = Path.Combine(GdkEditorHelpers.GdkToolsPath, "GameConfigEditor.exe");
            if (!File.Exists(configEditorPath))
            {
                EditorUtility.DisplayDialog("GDK tools not found", "Ensure the GDK is installed on this PC.", "Close");
                return;
            }

            string manifestFilePath = GdkEditorHelpers.GetGameConfigPath();
            if (!File.Exists(manifestFilePath))
            {
                EditorUtility.DisplayDialog("MicrosoftGame.config not found", "No MicrosoftGame.config file was found. Please re-import this plugin.", "Close");
                return;
            }

            try
            {
                Process.Start(configEditorPath, string.Format("\"{0}\" GameEngine", manifestFilePath));
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogError(e.Message);
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

        [MenuItem("GDK/PC/Build and Run")]
        private static void CreatePackage()
        {
            GdkBuildEditorWindow window = EditorWindow.GetWindow<GdkBuildEditorWindow>();
            window.minSize = new Vector2(400, 600);
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