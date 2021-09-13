using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XUser* XUserHandle;
    [StructLayout(LayoutKind.Sequential)]
    public struct XUserHandle
    {
        public IntPtr Ptr;
    }
}
