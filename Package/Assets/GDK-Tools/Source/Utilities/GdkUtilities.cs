using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Microsoft.GameCore.Utilities
{
    public class GdkUtilities
    {
        public static string XsapiLibName { get { return "Microsoft.Xbox.Services.GDK.C.Thunks.dll"; } }
        public static string XCurlLibName { get { return "XCurl.dll"; } }
        public static string HttpClientName { get { return "libHttpClient.GDK.dll"; } } 
        public static string GdkToolsPath
        {
            get
            {
                if (!File.Exists(_gdkToolsPath))
                {
                    _gdkToolsPath = Path.Combine(RegUtil.GetRegKey(RegUtil.HKEY_LOCAL_MACHINE, @"SOFTWARE\WOW6432Node\Microsoft\GDK", "GRDKInstallPath"), "bin");
                }

                return _gdkToolsPath;
            }
        }

        public static string GdkVersion
        {
            get
            {
                if (string.IsNullOrEmpty(_gdkVersion))
                {
                    // Reset paths to get new versions
                    _xsapiLibPath = "";
                    _xCurlLibPath = "";
                    _httpClientPath = "";
                    _gdkVersion = RegUtil.GetRegKey(RegUtil.HKEY_LOCAL_MACHINE, @"SOFTWARE\WOW6432Node\Microsoft\GDK", "GRDKLatest");
                }

                return _gdkVersion;
            }
        }

        public static string XsapiLibPath
        {
            get
            {
                if (!File.Exists(_xsapiLibPath))
                {
                    _xsapiLibPath = Path.Combine(Path.Combine(RegUtil.GetRegKey(RegUtil.HKEY_LOCAL_MACHINE, @"SOFTWARE\WOW6432Node\Microsoft\GDK", "GRDKInstallPath"), 
                                                 GdkVersion), 
                                                 Path.Combine(@"GRDK\ExtensionLibraries\Xbox.Services.API.C\DesignTime\CommonConfiguration\Neutral\Lib\Release", 
                                                 XsapiLibName));
                }

                return _xsapiLibPath;
            }
        }

        public static string XCurlLibPath
        {
            get
            {
                if (!File.Exists(_xCurlLibPath))
                {
                    _xCurlLibPath = Path.Combine(Path.Combine(RegUtil.GetRegKey(RegUtil.HKEY_LOCAL_MACHINE, @"SOFTWARE\WOW6432Node\Microsoft\GDK", "GRDKInstallPath"), 
                                                 GdkVersion), 
                                                 Path.Combine(@"GRDK\ExtensionLibraries\Xbox.XCurl.API\Redist\CommonConfiguration\neutral", 
                                                 XCurlLibName));
                }

                return _xCurlLibPath;
            }
        }

        public static string HttpClientPath
        {
            get
            {
                if (!File.Exists(_httpClientPath))
                {
                    _httpClientPath = Path.Combine(Path.Combine(RegUtil.GetRegKey(RegUtil.HKEY_LOCAL_MACHINE, @"SOFTWARE\WOW6432Node\Microsoft\GDK", "GRDKInstallPath"), 
                                                 GdkVersion), 
                                                 Path.Combine(@"GRDK\ExtensionLibraries\Xbox.LibHttpClient\Redist\CommonConfiguration\neutral", 
                                                 HttpClientName));
                }

                return _httpClientPath;
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

        public static string PluginDllPath
        {
            get
            {
                if (!File.Exists(_pluginDllPath))
                {
                    _pluginDllPath = Path.Combine(RootPluginPath, @"GDK-APIs\Runtime\DLLs");
                }

                return _pluginDllPath;
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

        private static string _gdkVersion;
        private static string _xsapiLibPath;
        private static string _xCurlLibPath;
        private static string _httpClientPath;
        private static string _gdkToolsPath;
        private static string _pluginDllPath;
        private static string _rootPluginPath;
        private static string _gameConfigPath;

        /// <summary>
        /// Copy DLLs from GDK if not currently in the plugin or if a different GDK version is detected
        /// </summary>
        public static void PullGdkDlls()
        {
            string oldGdkVersion = GdkVersion;
            _gdkVersion = "";

            string xsapiPath = Path.Combine(PluginDllPath, XsapiLibName);
            string xCurlPath = Path.Combine(PluginDllPath, XCurlLibName);
            string httpClientPath = Path.Combine(PluginDllPath, HttpClientName);
            
            int gdkMajorVersion = int.Parse(GdkVersion.Substring(0, 4)); 
            bool requiresXCurl = gdkMajorVersion >= 2110;
            bool requiresHttpClient = gdkMajorVersion >= 2406;

            if (!oldGdkVersion.Equals(GdkVersion) ||
                !File.Exists(xsapiPath) || 
                (requiresXCurl && !File.Exists(xCurlPath)) ||
                (requiresHttpClient && !File.Exists(httpClientPath)))
            {
                if (!File.Exists(XsapiLibPath))
                {
                    Debug.LogError("Could not find the GDK DLLs. Make sure you have the Microsoft GDK installed.");
                    return;
                }

                File.Copy(XsapiLibPath, Path.Combine(PluginDllPath, XsapiLibName), true);

                if (File.Exists(XCurlLibPath))
                {
                    File.Copy(XCurlLibPath, Path.Combine(PluginDllPath, XCurlLibName), true);
                }

                if (File.Exists(HttpClientPath))
                {
                    File.Copy(HttpClientPath, httpClientPath, true);
                }
            }
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