using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerSearchHandle
    {
        internal readonly IntPtr handle;
    }
}
