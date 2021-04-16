using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblSocialManagerUserGroupHandle
    {
        internal readonly IntPtr Handle;
    }
}
