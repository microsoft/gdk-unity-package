using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    partial class XGRInterop
    {
        //STDAPI XGameGetXboxTitleId(_Out_ uint32_t* titleId) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameGetXboxTitleId(out UInt32 titleId);
    }
}
