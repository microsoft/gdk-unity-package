using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XUserSignOutDeferral* XUserSignOutDeferralHandle;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XUserSignOutDeferralHandle
    {
        internal readonly IntPtr Ptr;
    }
}
