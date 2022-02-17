// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Xbox;
using UnityEditor;
using UnityEngine;

using Debug = UnityEngine.Debug;

namespace Microsoft.GameCore.Tools
{
    public class GdkEditorHelpers : ScriptableObject
    {
        internal static string GdkToolsPath 
        { 
            get 
            { 
                if (!File.Exists(_gdkToolsPath))
                {
                    _gdkToolsPath = Path.Combine(RegUtil.GetRegKey(RegUtil.HKEY_LOCAL_MACHINE, @"SOFTWARE\WOW6432Node\Microsoft\GDK", "InstallPath"), "bin");
                }

                return _gdkToolsPath;
            }
        }

        internal static string RootPluginPath
        {
            get
            {
                if (!File.Exists(_rootPluginPath))
                {
                    _rootPluginPath = Application.dataPath.Replace("/", @"\");
                }

                return _rootPluginPath;
            }
        }

        internal static string GameConfigPath
        {
            get
            {
                if (!File.Exists(_gameConfigPath))
                {
                    string gameConfigPath = string.Empty;
                    try
                    {
                        // First look in the place where the MicrosoftGame.Config should be.
                        string path = Path.Combine(RootPluginPath, @"GDK-Tools\ProjectMetadata");
                        string[] files = Directory.GetFiles(path, "MicrosoftGame.Config", SearchOption.TopDirectoryOnly);

                        // If not found, do a more expensive operation to search the entire project directory.
                        if (files.Length == 0)
                        {
                            Debug.Log("Searching for MicrosoftGame.Config in all asset folders.");
                            files = Directory.GetFiles(Application.dataPath, "MicrosoftGame.Config", SearchOption.AllDirectories);
                        }

                        if (files.Length > 0)
                        {
                            gameConfigPath = files[0];
                        }

                        _gameConfigPath = gameConfigPath.Replace("/", "\\");
                    }
                    catch
                    {
                        Debug.LogError("No MicrosoftGame.Config found. Please re-import this plugin.");
                    }
                }

                return _gameConfigPath;
            }
        }

        private static string _gdkToolsPath;
        private static string _rootPluginPath;
        private static string _gameConfigPath;

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
                workingDirectory = GdkToolsPath;
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
                workingDirectory = GdkToolsPath;
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

        internal static void SyncScidToGameConfig()
        {
            string configScid = string.Empty;
            XDocument gameConfigDoc = XDocument.Load(GameConfigPath);
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

        #region RegHelper
        private static class RegUtil
        {
            public const uint HKEY_LOCAL_MACHINE = 0x80000002u;

            [Flags]
            private enum RegSAM : uint
            {
                QUERY_VALUE = 0x0001,
                WOW64_64KEY = 0x0100,

                QUERY64 = QUERY_VALUE | WOW64_64KEY
            }

            private const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

            public static string GetRegKey(uint inHive, string inKeyName, string inPropertyName)
            {
                uint hkey = 0;
                uint lResult;

                try
                {
                    uint dis;
                    lResult = RegCreateKeyEx(inHive, inKeyName, 0, null, 0, (uint)RegSAM.QUERY64, 0, out hkey, out dis);

                    if (0 != lResult)
                    {
                        Debug.LogError("Create/OpenKey (Query) failed " + lResult + ": " + FormatMessage(lResult));
                        return string.Empty;
                    }

                    uint lpType = 0;
                    uint lpcbData = 1024;
                    StringBuilder valueBuffer = new StringBuilder(1024);
                    lResult = RegQueryValueEx(
                        hkey,
                        inPropertyName,
                        0, // reserved (must be 0)
                        ref lpType,
                        valueBuffer,
                        ref lpcbData);

                    if (0 != lResult)
                    {
                        // 2 here means the key exists but there's just no value set. No need for an error message
                        if (2 != lResult)
                        {
                            Debug.LogError("QueryKey failed " + lResult + ": " + FormatMessage(lResult));
                        }

                        return string.Empty;
                    }

                    return valueBuffer.ToString();
                }
                catch (Exception e)
                {
                    Debug.LogError("Failed to get key: " + e.Message);
                    return string.Empty;
                }
                finally
                {
                    if (0 != hkey)
                    {
                        lResult = RegCloseKey(hkey);

                        if (0 != lResult)
                        {
                            Debug.LogError("CloseKey (Query) failed " + lResult + ": " + FormatMessage(lResult));
                        }
                    }
                }
            }

            [DllImport("Advapi32.dll")]
            private static extern uint RegCreateKeyEx(uint hKey, string lpSubKey, uint reserved, string lpClass, uint dwOptions, uint samDesired, uint lpSecurityAttributes, out uint phkResult, out uint lpdwDisposition);

            [DllImport("Advapi32.dll")]
            private static extern uint RegCloseKey(uint hKey);

            [DllImport("Advapi32.dll")]
            private static extern uint RegQueryValueEx(uint hKey, string lpValueName, uint lpReserved, ref uint lpType, StringBuilder lpData, ref uint lpcbData);

            [DllImport("Kernel32.dll")]
            private static extern uint FormatMessage(uint dwFlags, uint lpSource, uint dwMessageId, uint dwLanguageId, StringBuilder lpBuffer, uint nSize, uint arguments);

            private static string FormatMessage(uint dwMessageId)
            {
                StringBuilder errorBuffer = new StringBuilder(1024);
                FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, 0, dwMessageId, 0, errorBuffer, 1024, 0);
                return errorBuffer.ToString();
            }
        }
        #endregion
    }
}
