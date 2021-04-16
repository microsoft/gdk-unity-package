using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XGameSaveContainer* XGameSaveContainerHandle;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XGameSaveContainerHandle
    {
        internal readonly IntPtr Ptr;
    }
}
