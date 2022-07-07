// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xbox;
using Microsoft.GameCore.Utilities;
using UnityEditor;
using UnityEngine;

using Debug = UnityEngine.Debug;

namespace Microsoft.GameCore.Tools
{
    public class GdkEditorHelpers : ScriptableObject
    {
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
                workingDirectory = GdkUtilities.GdkToolsPath;
            }
            if (!Directory.Exists(workingDirectory))
            {
                Debug.LogError("Could not find the GDK tools. Make sure you have the Microsoft GDK installed.");
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
                    Debug.Log(standardOutputMessage);
                }
                if (!string.IsNullOrEmpty(standardErrorMessage))
                {
                    Debug.LogError(standardErrorMessage);
                    succeeded = false;
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
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
                workingDirectory = GdkUtilities.GdkToolsPath;
            }
            if (!Directory.Exists(workingDirectory))
            {
                Debug.LogError("Could not find the GDK tools. Make sure you have the Microsoft GDK installed.");
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
                    Debug.Log(standardOutputMessage);
                }
                if (!string.IsNullOrEmpty(standardErrorMessage))
                {
                    Debug.LogError(standardErrorMessage);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }

            return succeeded;
        }

        internal static bool StartCmdProcessAsAdmin(string arguments)
        {
            var processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.Arguments = arguments;
            processStartInfo.UseShellExecute = true;
            processStartInfo.RedirectStandardOutput = false;
            processStartInfo.RedirectStandardError = false;
            processStartInfo.Verb = "runas";

            try
            {
                var process = Process.Start(processStartInfo);
                process.WaitForExit();
                process.Close();
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }

            return true;
        }

        internal static void SyncScidToGameConfig()
        {
            string configScid = string.Empty;
            XDocument gameConfigDoc = XDocument.Load(GdkUtilities.GameConfigPath);
            try
            {
                XElement scidNode = (from node in gameConfigDoc.Descendants("ExtendedAttribute")
                                     where node.Attribute("Name").Value == "Scid"
                                     select node).First();

                configScid = scidNode.Attribute("Value").Value;
            }
            catch
            {
                Debug.LogError("Malformed MicrosoftGame.Config. Please re-import this plugin.");
                return;
            }

            string gdkPrefabId = AssetDatabase.FindAssets("GdkHelper", new string[] { "Assets/GDK-Tools/Prefabs" })[0];
            var gdkPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(gdkPrefabId));
            var gdkScript = gdkPrefab.GetComponent<Gdk>();
            gdkScript.scid = configScid;

            EditorUtility.SetDirty(gdkPrefab);
            AssetDatabase.SaveAssets();
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
    }
}
