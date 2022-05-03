// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using UnityEditor;
using UnityEngine;

namespace Microsoft.GameCore.Tools
{
    public class GdkBuildEditorWindow : EditorWindow
    {
        private enum CompressionMethod
        {
            Default = BuildOptions.None,
            LZ4 = BuildOptions.CompressWithLz4,
            LZ4HC = BuildOptions.CompressWithLz4HC
        }

        private const string GameCorePlatformDefine = "MICROSOFT_GAME_CORE";

        private static bool _initialized;
        private static bool _isGameCorePlatformDefined;
        private static bool _isGameCorePlatformDefinedPrev;
        private static bool _createPackageForStoreUpload;
        private static bool _isBuilding;
        private static BuildTarget _previousStandaloneBuildTarget;
        private static CompressionMethod _compressionMethod;
        
        private Vector2 _scenesScrollPos;

        private void Initialize()
        {
            _scenesScrollPos = Vector2.zero;
            GdkBuild.aumid = string.Empty;

            _isGameCorePlatformDefined = IsGameCoreScriptingDefineEnabled();
            _isGameCorePlatformDefinedPrev = _isGameCorePlatformDefined;

            GetCompressionMethod();

            EditorStyles.textArea.wordWrap = true;

            _initialized = true;
        }

        void OnGUI()
        {
            if (!_initialized)
            {
                Initialize();
            }

            GUIStyle margins = new GUIStyle
            {
                padding = new RectOffset(10, 10, 0, 0)
            };

            using (new EditorGUILayout.VerticalScope(margins))
            {
                EditorGUILayout.Separator();

                GUIStyle header = new GUIStyle(EditorStyles.largeLabel);
                header.wordWrap = true;

                // Header
                EditorGUILayout.LabelField("Create a package targetting the PC, Mac & Linux Standalone platform that you can upload to the Microsoft Store (.msixvc).", header);
                EditorGUILayout.Separator();

                // Scenes
                EditorGUILayout.LabelField("Scenes in Build", EditorStyles.boldLabel, GUILayout.MaxWidth(100));

                using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
                {
                    using (new EditorGUILayout.ScrollViewScope(_scenesScrollPos, GUILayout.MinHeight(150)))
                    {
                        EditorBuildSettingsScene[] buildScenes = EditorBuildSettings.scenes;
                        foreach (EditorBuildSettingsScene buildScene in buildScenes)
                        {
                            if (buildScene.enabled)
                            {
                                EditorGUILayout.LabelField(buildScene.path, EditorStyles.wordWrappedLabel);
                            }
                        }
                    }
                }

                EditorGUILayout.Separator();

                //EditorGUILayout.LabelField("Using PC, Mac & Linux Standalone platform and build settings.", EditorStyles.largeLabel);

                // Action buttons
                if (GUILayout.Button("Select scenes and edit Build Settings", GUILayout.MaxWidth(240)))
                {
                    GetWindow<BuildPlayerWindow>().Show();
                }

                GdkEditorHelpers.SectionSeperator();

                using (new EditorGUI.DisabledGroupScope(_isBuilding))
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        using (new EditorGUILayout.VerticalScope(GUILayout.MaxWidth(230)))
                        {
                            GUIContent defineToggle = new GUIContent
                            {
                                text = "Define " + GameCorePlatformDefine,
                                tooltip = "Checking this box means that any code you have conditionally defined using '#if MICROSOFT_GAME_CORE' will be defined " +
                                    "in the editor providing an easy way to catch compilation errors without having to do a full build. Note that " +
                                    "MICROSOFT_GAME_CORE must be defined when you click either of the Build buttons below."
                            };

                            GUIContent packageToggle = new GUIContent
                            {
                                text = "Create package to upload to the store",
                                tooltip = "Checking this box means that the package will be encypted, which is required for uploading to the store. " +
                                    "Clicking the Build button will generate the files to upload to the store."
                            };

                            GUIContent compressionDropdown = new GUIContent
                            {
                                text = "Compression Method",
                                tooltip = "Compression Method set in main Build Settings has no effect on this build."
                            };

                            EditorGUILayout.LabelField(defineToggle);
                            EditorGUILayout.LabelField(packageToggle);
                            EditorGUILayout.Separator();
                            EditorGUILayout.LabelField(compressionDropdown);
                        }

                        using (new EditorGUILayout.VerticalScope(GUILayout.MaxWidth(170)))
                        {
                            _isGameCorePlatformDefined = EditorGUILayout.Toggle(_isGameCorePlatformDefined);
                            _createPackageForStoreUpload = EditorGUILayout.Toggle(_createPackageForStoreUpload);
                            EditorGUILayout.Separator();
                            SetCompressionMethod((CompressionMethod)EditorGUILayout.EnumPopup(_compressionMethod));
                        }
                    }

                    GdkEditorHelpers.SectionSeperator();

                    if (!_isBuilding && _isGameCorePlatformDefined != _isGameCorePlatformDefinedPrev)
                    {
                        if (_isGameCorePlatformDefined)
                        {
                            EnableGameCoreScriptingDefine();
                            _previousStandaloneBuildTarget = EditorUserBuildSettings.activeBuildTarget;
                            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);
                        }
                        else
                        {
                            DisableGameCoreScriptingDefine();
                            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, _previousStandaloneBuildTarget);
                        }

                        _isGameCorePlatformDefinedPrev = _isGameCorePlatformDefined;
                    }

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        using (new EditorGUI.DisabledGroupScope(!_isGameCorePlatformDefined))
                        {
                            if (GUILayout.Button("Build"))
                            {
                                _isBuilding = true;
                                GdkBuild.Build(true, _createPackageForStoreUpload, (BuildOptions)_compressionMethod);
                                _isBuilding = false;
                                GUIUtility.ExitGUI();
                            }
                        }

                        using (new EditorGUI.DisabledGroupScope(!_isGameCorePlatformDefined || _createPackageForStoreUpload))
                        {
                            if (GUILayout.Button("Build and Run"))
                            {
                                _isBuilding = true;
                                bool succeeded = GdkBuild.Build(false, _createPackageForStoreUpload, (BuildOptions)_compressionMethod);
                                GdkBuild.InstallAndRun(succeeded);
                                _isBuilding = false;
                                GUIUtility.ExitGUI();
                            }
                        }
                    }
                }

                if (_isBuilding)
                {
                    EditorGUILayout.Separator();
                    EditorGUILayout.HelpBox("Building. Please wait...", MessageType.Warning);
                }

                if (!_isGameCorePlatformDefined)
                {
                    EditorGUILayout.Separator();
                    EditorGUILayout.HelpBox("You need to check \"Define MICROSOFT_GAME_CORE\" above to Build.", MessageType.Warning);
                }

                GdkEditorHelpers.SectionSeperator();
            }
        }

        private bool IsGameCoreScriptingDefineEnabled()
        {
            string existingScriptingDefineSymbolsForGroup = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);

            return existingScriptingDefineSymbolsForGroup.Contains(GameCorePlatformDefine);
        }

        private void EnableGameCoreScriptingDefine()
        {
            if (!IsGameCoreScriptingDefineEnabled())
            {
                string existingScriptingDefineSymbolsForGroup = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
                
                if (!string.IsNullOrEmpty(existingScriptingDefineSymbolsForGroup) &&
                    existingScriptingDefineSymbolsForGroup[existingScriptingDefineSymbolsForGroup.Length - 1] != ';')
                {
                    existingScriptingDefineSymbolsForGroup += ";";
                }

                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, existingScriptingDefineSymbolsForGroup + GameCorePlatformDefine + ";");
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
            }
        }

        private void GetCompressionMethod()
        {
            _compressionMethod = (CompressionMethod)EditorPrefs.GetInt("CompressionMethod");
        }

        private void SetCompressionMethod(CompressionMethod compressionMethod)
        {
            EditorPrefs.SetInt("CompressionMethod", (int)compressionMethod);
            _compressionMethod = compressionMethod;
        }
    }
}