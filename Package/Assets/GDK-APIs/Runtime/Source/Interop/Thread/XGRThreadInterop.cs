using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    partial class XGRInterop
    {
        //STDAPI_(bool) XThreadIsTimeSensitive() noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XThreadIsTimeSensitive();

        //STDAPI XThreadSetTimeSensitive(
        //    _In_ bool isTimeSensitiveThread
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XThreadSetTimeSensitive(
            NativeBool isTimeSensitiveThread);

        //STDAPI_(void) XThreadAssertNotTimeSensitive() noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XThreadAssertNotTimeSensitive();
    }
}
