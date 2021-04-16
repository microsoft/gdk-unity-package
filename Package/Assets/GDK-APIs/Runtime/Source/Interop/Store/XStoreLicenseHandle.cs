using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XStoreLicense* XStoreLicenseHandle;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreLicenseHandle
    {
        internal readonly IntPtr intPtr;
    }
}
