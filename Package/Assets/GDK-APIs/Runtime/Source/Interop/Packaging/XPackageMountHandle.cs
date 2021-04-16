using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct XPackageMountHandle
    {
        internal IntPtr handle;
    }
}
