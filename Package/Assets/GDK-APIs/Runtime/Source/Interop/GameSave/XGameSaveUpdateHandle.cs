using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct XGameSaveUpdateHandle
    {
        internal readonly IntPtr Ptr;
    }
}
