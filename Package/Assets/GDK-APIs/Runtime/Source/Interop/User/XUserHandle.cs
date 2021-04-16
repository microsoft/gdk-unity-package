using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XUser* XUserHandle;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XUserHandle
    {
        internal readonly IntPtr Ptr;
    }
}
