using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    partial class XGRInterop
    {
        //STDAPI XGameGetXboxTitleId(_Out_ uint32_t* titleId) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameGetXboxTitleId(out UInt32 titleId);

        //STDAPI_(void) XLaunchNewGame(_In_z_ const char* exePath, _In_opt_z_ const char* args, _In_opt_ XUserHandle defaultUser) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XLaunchNewGame([MarshalAs(UnmanagedType.LPStr)] string exePath, [MarshalAs(UnmanagedType.LPStr)] string args, IntPtr defaultUser);

        //STDAPI XLaunchRestartOnCrash(_In_opt_z_ const char* args, _In_ uint32_t reserved) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XLaunchRestartOnCrash([MarshalAs(UnmanagedType.LPStr)] string args, UInt32 reserved);
    }
}
