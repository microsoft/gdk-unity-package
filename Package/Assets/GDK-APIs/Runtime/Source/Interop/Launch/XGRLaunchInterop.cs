using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    partial class XGRInterop
    {
        //STDAPI XLaunchUri(
        //    _In_opt_ XUserHandle requestingUser,
        //    _In_z_ const char* uri
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XLaunchUri(XUserHandle requestingUser, byte[] uri);

        //STDAPI XLaunchUri(
        //    _In_opt_ XUserHandle requestingUser,
        //    _In_z_ const char* uri
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XLaunchUri(IntPtr requestingUser, byte[] uri);
    }
}
