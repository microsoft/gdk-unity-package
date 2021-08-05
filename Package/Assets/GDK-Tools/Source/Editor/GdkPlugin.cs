// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.IO;
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
            Application.OpenURL("http://aka.ms/gdk_unity");
        }

        [MenuItem("GDK/Associate with the Microsoft Store")]
        internal static void EditManifest()
        {
            string manifestFilePath = GdkEditorHelpers.GetGameConfigPath();
            if (!File.Exists(manifestFilePath))
            {
                EditorUtility.DisplayDialog("MicrosoftGame.config not found", "No MicrosoftGame.config file was found. Please re-import this plugin.", "Close", string.Empty);
                return;
            }

            string arguments = "/c start GDK-Tools\\Source\\Tools\\ManifestEditor\\ManifestEditor.exe " +
                "GDK-Tools\\ProjectMetadata\\MicrosoftGame.Config /e:Unity /i:GDK-PC\\ProjectMetadata\\Square480x480Logo.png";
            string workingDirectory = GdkEditorHelpers.GetRootPluginPath().Replace("GDK-Tools", string.Empty);
            GdkEditorHelpers.StartCmdProcess(arguments, workingDirectory);
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