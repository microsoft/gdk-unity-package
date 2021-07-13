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
using UnityEngine;

namespace Microsoft.GameCore.Tools
{
    public class GdkBuildEditorWindow : EditorWindow
    {
        private static bool initialized;
        private Vector2 scenesScrollPos;
        private static bool isGameCorePlatformDefined;
        private static bool createPackageForStoreUpload;
        private static bool isBuilding;
        private static BuildTarget previousStandaloneBuildTarget;

        private const string GameCorePlatformDefine = "MICROSOFT_GAME_CORE";

        // Start is called before the first frame update
        void Start()
        {
        }

        private void Initialize()
        {
            scenesScrollPos = Vector2.zero;
            GdkBuild.aumid = string.Empty;

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
                isBuilding = true;
                GdkBuild.Build(true, createPackageForStoreUpload);
                isBuilding = false;
            }
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(!isGameCorePlatformDefined || createPackageForStoreUpload);
            if (GUILayout.Button("Build and Run"))
            {
                isBuilding = true;
                bool succeeded = false;
                succeeded = GdkBuild.Build(false, createPackageForStoreUpload);
                succeeded = GdkBuild.InstallAndRun(succeeded);
                isBuilding = false;
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
    }
}