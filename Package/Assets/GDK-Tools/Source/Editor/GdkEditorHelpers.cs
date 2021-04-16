// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Microsoft.GameCore.Tools
{
    public class GdkEditorHelpers : ScriptableObject
    {
        private static GdkEditorHelpers _instance;

        public static GdkEditorHelpers Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = CreateInstance("GdkEditorHelpers") as GdkEditorHelpers;
                }

                return _instance;
            }
        }

        internal static bool StartCmdProcess(string arguments)
        {
            string unusedString = string.Empty;
            string workingDirectory = string.Empty;
            return StartCmdProcess(arguments, out unusedString, workingDirectory);
        }

        internal static bool StartCmdProcess(string arguments, string workingDirectory)
        {
            string unusedString = string.Empty;
            return StartCmdProcess(arguments, out unusedString, workingDirectory);
        }

        internal static bool StartCmdProcess(string arguments, out string aumid, string workingDirectory = "")
        {
            bool succeeded = true;
            aumid = string.Empty;

            if (string.IsNullOrEmpty(workingDirectory))
            {
                workingDirectory = @"C:\Program Files (x86)\Microsoft GDK\bin";
            }
            if (!Directory.Exists(workingDirectory))
            {
                LogError("Error: Could not find the GDK tools. Make sure you have the Microsoft GDK installed.");
                return false;
            }

            var processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.Arguments = arguments;
            processStartInfo.WorkingDirectory = workingDirectory;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            try
            {
                var process = Process.Start(processStartInfo);
                string standardOutputMessage = string.Empty;
                string standardErrorMessage = string.Empty;
                while (!process.StandardOutput.EndOfStream)
                {
                    string standardOutputLine = process.StandardOutput.ReadLine();
                    standardOutputMessage += standardOutputLine;
                    if (standardOutputLine.Contains("Install failed"))
                    {
                        succeeded = false;
                    }
                    if (standardOutputLine.Contains("!Game")) // TODO: This can't be hardcoded, needs to come from the gameconfig.
                    {
                        aumid = standardOutputLine;
                    }
                }
                while (!process.StandardError.EndOfStream)
                {
                    string standardErrorLine = process.StandardError.ReadLine();
                    standardErrorMessage += standardErrorLine;
                }
                process.WaitForExit();
                process.Close();
                if (!string.IsNullOrEmpty(standardOutputMessage))
                {
                    LogInfo(standardOutputMessage);
                }
                if (!string.IsNullOrEmpty(standardErrorMessage))
                {
                    LogInfo(standardErrorMessage);
                    succeeded = false;
                }
            }
            catch (Exception e)
            {
                LogError(e.Message);
                succeeded = false;
            }

            return succeeded;
        }

        internal static bool StartCmdProcessAndReturnOutput(string arguments, out string standardOutput, out string standartError, string workingDirectory = "")
        {
            bool succeeded = true;
            standardOutput = string.Empty;
            standartError = string.Empty;

            if (string.IsNullOrEmpty(workingDirectory))
            {
                workingDirectory = @"C:\Program Files (x86)\Microsoft GDK\bin";
            }
            if (!Directory.Exists(workingDirectory))
            {
                LogError("Error: Could not find the GDK tools. Make sure you have the Microsoft GDK installed.");
                return false;
            }

            var processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.Arguments = arguments;
            processStartInfo.WorkingDirectory = workingDirectory;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            try
            {
                var process = Process.Start(processStartInfo);
                string standardOutputMessage = string.Empty;
                string standardErrorMessage = string.Empty;
                while (!process.StandardOutput.EndOfStream)
                {
                    string standardOutputLine = process.StandardOutput.ReadLine();
                    standardOutput += standardOutputLine;
                }
                while (!process.StandardError.EndOfStream)
                {
                    string standardErrorLine = process.StandardError.ReadLine();
                    standartError += standardErrorLine;
                }
                process.WaitForExit();
                process.Close();
                if (!string.IsNullOrEmpty(standardOutputMessage))
                {
                    LogInfo(standardOutputMessage);
                }
                if (!string.IsNullOrEmpty(standardErrorMessage))
                {
                    LogInfo(standardErrorMessage);
                }
            }
            catch (Exception e)
            {
                LogError(e.Message);
            }

            return succeeded;
        }

        internal static void LogInfo(string message)
        {
            UnityEngine.Debug.Log(message);
        }

        internal static void LogError(string message)
        {
            UnityEngine.Debug.LogError(message);
        }

        internal static void SectionSeperator()
        {
            EditorGUILayout.Separator();
            EditorGUILayout.Separator();
            EditorGUILayout.Separator();
        }
        internal static string GetGameConfigPath()
        {
            string getGameConfigPath = string.Empty;
            try
            {
                // First look in the place where the MicrosoftGame.Config should be.
                string path = GetRootPluginPath() + "\\GDK-Tools\\ProjectMetadata";
                string[] files = Directory.GetFiles(path, "MicrosoftGame.Config", SearchOption.TopDirectoryOnly);
                // If not found, do a more expensive operation to search the entire project directory.
                if (files.Length == 0)
                {
                    files = Directory.GetFiles(Application.dataPath, "MicrosoftGame.Config", SearchOption.AllDirectories);
                }
                if (files.Length > 0)
                {
                    getGameConfigPath = files[0];
                }
                getGameConfigPath = getGameConfigPath.Replace("/", "\\");
            }
            catch
            {
                LogError("MicrosoftGame.config not found.");
            }

            return getGameConfigPath;
        }

        internal static string GetRootPluginPath()
        {
            string rootPluginPath = string.Empty;

            MonoScript monoScript = MonoScript.FromScriptableObject(GdkEditorHelpers.Instance);
            string assetPath = AssetDatabase.GetAssetPath(monoScript);
            rootPluginPath = assetPath.Replace("/GDK-Tools/Source/Editor/GdkEditorHelpers.cs", string.Empty);
            rootPluginPath = (Application.dataPath + rootPluginPath.Replace("Assets", string.Empty)).Replace("/", "\\");

            return rootPluginPath;
        }
    }
}
