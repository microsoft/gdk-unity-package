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

        //STDAPI XStoreShowProductPageUIAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* storeId,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XStoreShowProductPageUIAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] storeId,
            XAsyncBlockPtr asyncBlock
            );

        //STDAPI XStoreShowProductPageUIResult(
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XStoreShowProductPageUIResult(
            XAsyncBlockPtr asyncBlock
            );

        //STDAPI XStoreShowAssociatedProductsUIAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* storeId,
        //    _In_ XStoreProductKind productKinds,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XStoreShowAssociatedProductsUIAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] storeId,
            XStoreProductKind productKinds,
            XAsyncBlockPtr asyncBlock
            );

        //STDAPI XStoreShowAssociatedProductsUIResult(
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XStoreShowAssociatedProductsUIResult(
            XAsyncBlockPtr asyncBlock
            );

        //STDAPI_(bool) XStoreIsAvailabilityPurchasable(
        //    _In_ const XStoreAvailability availability
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XStoreIsAvailabilityPurchasable(
            XStoreAvailability availability);
    }
}
