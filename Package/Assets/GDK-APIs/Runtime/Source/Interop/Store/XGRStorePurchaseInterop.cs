using System;
using System.Runtime.InteropServices;
using System.Text;

namespace XGamingRuntime.Interop
{
    partial class XGRInterop
    {
        //STDAPI XStoreShowRedeemTokenUIAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* token,
        //    _In_z_count_(allowedStoreIdsCount) const char** allowedStoreIds,
        //    _In_ size_t allowedStoreIdsCount,
        //    _In_ bool disallowCsvRedemption,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreShowRedeemTokenUIAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] token,
            [In] UTF8StringPtr[] allowedStoreIds,
            SizeT allowedStoreIdsCount,
            NativeBool disallowCsvRedemption,
            XAsyncBlockPtr async);

        //STDAPI XStoreShowRedeemTokenUIResult(
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreShowRedeemTokenUIResult(
            XAsyncBlockPtr async);

        //STDAPI XStoreShowRateAndReviewUIAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreShowRateAndReviewUIAsync(
            XStoreContextHandle storeContextHandle,
            XAsyncBlockPtr async);

        //STDAPI XStoreShowRateAndReviewUIResult(
        //    _Inout_ XAsyncBlock* async,
        //    _Out_ XStoreRateAndReviewResult* result
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreShowRateAndReviewUIResult(
            XAsyncBlockPtr async,
            out XStoreRateAndReviewResult result);

        //STDAPI XStoreShowPurchaseUIAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* storeId,
        //    _In_opt_z_ const char* name,
        //    _In_opt_z_ const char* extendedJsonData,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreShowPurchaseUIAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] storeId,
            Byte[] name,
            Byte[] extendedJsonData,
            XAsyncBlockPtr async);

        //STDAPI XStoreShowPurchaseUIResult(
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreShowPurchaseUIResult(
            XAsyncBlockPtr async);

        //STDAPI XStoreQueryConsumableBalanceRemainingAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* storeProductId,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryConsumableBalanceRemainingAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] storeProductId,
            XAsyncBlockPtr async);

        //STDAPI XStoreQueryConsumableBalanceRemainingResult(
        //    _Inout_ XAsyncBlock* async,
        //    _Out_ XStoreConsumableResult* consumableResult
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryConsumableBalanceRemainingResult(
            XAsyncBlockPtr async,
            out XStoreConsumableResult consumableResult);

        //STDAPI XStoreReportConsumableFulfillmentAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* storeProductId,
        //    _In_ uint32_t quantity,
        //    _In_ GUID trackingId,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreReportConsumableFulfillmentAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] storeProductId,
            UInt32 quantity,
            Guid trackingId,
            XAsyncBlockPtr async);

        //STDAPI XStoreReportConsumableFulfillmentResult(
        //    _Inout_ XAsyncBlock* async,
        //    _Out_ XStoreConsumableResult* consumableResult
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreReportConsumableFulfillmentResult(
            XAsyncBlockPtr async,
            out XStoreConsumableResult consumableResult);

        //STDAPI XStoreGetUserCollectionsIdAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* serviceTicket,
        //    _In_z_ const char* publisherUserId,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreGetUserCollectionsIdAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] serviceTicket,
            Byte[] publisherUserId,
            XAsyncBlockPtr async);

        //STDAPI XStoreGetUserCollectionsIdResultSize(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* size
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreGetUserCollectionsIdResultSize(
            XAsyncBlockPtr async,
            out SizeT size);

        //STDAPI XStoreGetUserCollectionsIdResult(
        //    _Inout_ XAsyncBlock* async,
        //    _In_ size_t size,
        //    _Out_writes_z_(size) char* result
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreGetUserCollectionsIdResult(
            XAsyncBlockPtr async,
            SizeT size,
            Byte[] result);

        //STDAPI XStoreGetUserPurchaseIdAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* serviceTicket,
        //    _In_z_ const char* publisherUserId,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreGetUserPurchaseIdAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] serviceTicket,
            Byte[] publisherUserId,
            XAsyncBlockPtr async);

        //STDAPI XStoreGetUserPurchaseIdResultSize(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* size
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreGetUserPurchaseIdResultSize(
            XAsyncBlockPtr async,
            out SizeT size);

        //STDAPI XStoreGetUserPurchaseIdResult(
        //    _Inout_ XAsyncBlock* async,
        //    _In_ size_t size,
        //    _Out_writes_z_(size) char* result
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreGetUserPurchaseIdResult(
            XAsyncBlockPtr async,
            SizeT size,
            Byte[] result);
    }
}
