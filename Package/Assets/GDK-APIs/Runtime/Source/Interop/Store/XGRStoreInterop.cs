using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    partial class XGRInterop
    {
        //STDAPI XStoreCreateContext(
        //    _In_opt_ const XUserHandle user,
        //    _Out_ XStoreContextHandle* storeContextHandle
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreCreateContext(
            XUserHandle user,
            out XStoreContextHandle storeContextHandle);

        //STDAPI_(void) XStoreCloseContextHandle(
        //    _In_ XStoreContextHandle storeContextHandle
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XStoreCloseContextHandle(
            XStoreContextHandle storeContextHandle);

        //STDAPI_(bool) XStoreIsAvailabilityPurchasable(
        //    _In_ const XStoreAvailability availability
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XStoreIsAvailabilityPurchasable(
            XStoreAvailability availability);
    }
}
