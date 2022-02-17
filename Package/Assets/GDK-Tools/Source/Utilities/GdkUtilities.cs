using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Microsoft.GameCore.Utilities
{
    public class GdkUtilities
    {
        public static string GdkToolsPath
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

        public static string RootPluginPath
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

        public static string GameConfigPath
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