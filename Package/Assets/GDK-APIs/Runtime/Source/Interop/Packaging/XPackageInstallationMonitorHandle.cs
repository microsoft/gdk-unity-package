using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct XPackageInstallationMonitorHandle
    {
        internal IntPtr handle;
    }
}
