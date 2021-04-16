using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XGameSaveProvider* XGameSaveProviderHandle;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XGameSaveProviderHandle
    {
        internal readonly IntPtr Ptr;
    }
}
