using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef void CALLBACK XStoreGameLicenseChangedCallback(_In_ void* context);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate void XStoreGameLicenseChangedCallback(IntPtr context);

    //typedef void CALLBACK XStorePackageLicenseLostCallback(_In_ void* context);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate void XStorePackageLicenseLostCallback(IntPtr context);

    partial class XGRInterop
    {
        //STDAPI XStoreAcquireLicenseForPackageAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* packageIdentifier,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreAcquireLicenseForPackageAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] packageIdentifier,
            XAsyncBlockPtr async);

        //STDAPI XStoreAcquireLicenseForPackageResult(
        //    _Inout_ XAsyncBlock* async,
        //    _Out_ XStoreLicenseHandle* storeLicenseHandle
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreAcquireLicenseForPackageResult(
            XAsyncBlockPtr async,
            out XStoreLicenseHandle storeLicenseHandle);

        //STDAPI XStoreCanAcquireLicenseForPackageAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* packageIdentifier,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreCanAcquireLicenseForPackageAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] packageIdentifier,
            XAsyncBlockPtr async);

        //STDAPI XStoreCanAcquireLicenseForPackageResult(
        //    _Inout_ XAsyncBlock* async,
        //    _Out_ XStoreCanAcquireLicenseResult* storeCanAcquireLicense
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreCanAcquireLicenseForPackageResult(
            XAsyncBlockPtr async,
            out XStoreCanAcquireLicenseResult storeCanAcquireLicense);

        //STDAPI XStoreCanAcquireLicenseForStoreIdAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* storeProductId,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreCanAcquireLicenseForStoreIdAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] storeProductId,
            XAsyncBlockPtr async);

        //STDAPI XStoreCanAcquireLicenseForStoreIdResult(
        //    _Inout_ XAsyncBlock* async,
        //    _Out_ XStoreCanAcquireLicenseResult* storeCanAcquireLicense
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreCanAcquireLicenseForStoreIdResult(
            XAsyncBlockPtr async,
            out XStoreCanAcquireLicenseResult storeCanAcquireLicense);

        //STDAPI_(void) XStoreCloseLicenseHandle(
        //    _In_ XStoreLicenseHandle storeLicenseHandle
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XStoreCloseLicenseHandle(
            XStoreLicenseHandle storeLicenseHandle);

        //STDAPI_(bool) XStoreIsLicenseValid(
        //    _In_ const XStoreLicenseHandle storeLicenseHandle
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XStoreIsLicenseValid(
            XStoreLicenseHandle storeLicenseHandle);

        //STDAPI XStoreQueryAddOnLicensesAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryAddOnLicensesAsync(
            XStoreContextHandle storeContextHandle,
            XAsyncBlockPtr async);

        //STDAPI XStoreQueryAddOnLicensesResult(
        //    _Inout_ XAsyncBlock* async,
        //    _In_ uint32_t count,
        //    _Out_writes_(count) XStoreAddonLicense* addOnLicenses
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryAddOnLicensesResult(
            XAsyncBlockPtr async,
            UInt32 count,
            [Out] XStoreAddonLicense[] addOnLicenses);

        //STDAPI XStoreQueryAddOnLicensesResultCount(
        //    _In_ XAsyncBlock* async,
        //    _Out_ uint32_t* count
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryAddOnLicensesResultCount(
            XAsyncBlockPtr async,
            out UInt32 count);

        //STDAPI XStoreQueryGameLicenseAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryGameLicenseAsync(
            XStoreContextHandle storeContextHandle,
            XAsyncBlockPtr async);

        //STDAPI XStoreQueryGameLicenseResult(
        //    _Inout_ XAsyncBlock* async,
        //    _Out_ XStoreGameLicense* license
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryGameLicenseResult(
            XAsyncBlockPtr async,
            out XStoreGameLicense license);

        //STDAPI XStoreQueryLicenseTokenAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_count_(productIdsCount) const char** productIds,
        //    _In_ size_t productIdsCount,
        //    _In_z_ const char* customDeveloperString,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryLicenseTokenAsync(
            XStoreContextHandle storeContextHandle,
            [In] UTF8StringPtr[] productIds,
            SizeT productIdsCount,
            Byte[] customDeveloperString,
            XAsyncBlockPtr async);

        //STDAPI XStoreQueryLicenseTokenResult(
        //    _Inout_ XAsyncBlock* async,
        //    _In_ size_t size,
        //    _Out_writes_z_(size) char* result
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryLicenseTokenResult(
            XAsyncBlockPtr async,
            SizeT size,
            Byte[] result);

        //STDAPI XStoreQueryLicenseTokenResultSize(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* size
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryLicenseTokenResultSize(
            XAsyncBlockPtr async,
            out SizeT size);

        //STDAPI XStoreRegisterGameLicenseChanged(
        //    _In_ XStoreContextHandle storeContextHandle,
        //    _In_ XTaskQueueHandle queue,
        //    _In_opt_ void* context,
        //    _In_ XStoreGameLicenseChangedCallback* callback,
        //    _Out_ XTaskQueueRegistrationToken* token
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreRegisterGameLicenseChanged(
            XStoreContextHandle storeContextHandle,
            XTaskQueueHandle queue,
            IntPtr context,
            XStoreGameLicenseChangedCallback callback,
            out XTaskQueueRegistrationToken token);

        //STDAPI XStoreRegisterPackageLicenseLost(
        //    _In_ XStoreLicenseHandle licenseHandle,
        //    _In_ XTaskQueueHandle queue,
        //    _In_opt_ void* context,
        //    _In_ XStorePackageLicenseLostCallback* callback,
        //    _Out_ XTaskQueueRegistrationToken* token
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreRegisterPackageLicenseLost(
            XStoreLicenseHandle licenseHandle,
            XTaskQueueHandle queue,
            IntPtr context,
            XStorePackageLicenseLostCallback callback,
            out XTaskQueueRegistrationToken token);

        //STDAPI_(bool) XStoreUnregisterGameLicenseChanged(
        //    _In_ XStoreContextHandle storeContextHandle,
        //    _In_ XTaskQueueRegistrationToken token,
        //    _In_ bool wait
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XStoreUnregisterGameLicenseChanged(
            XStoreContextHandle storeContextHandle,
            XTaskQueueRegistrationToken token,
            NativeBool wait);

        //STDAPI_(bool) XStoreUnregisterPackageLicenseLost(
        //    _In_ XStoreLicenseHandle licenseHandle,
        //    _In_ XTaskQueueRegistrationToken token,
        //    _In_ bool wait
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XStoreUnregisterPackageLicenseLost(
            XStoreLicenseHandle licenseHandle,
            XTaskQueueRegistrationToken token,
            NativeBool wait);

        //STDAPI XStoreAcquireLicenseForDurablesAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_ const char* storeId,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreAcquireLicenseForDurablesAsync(
            XStoreContextHandle storeContextHandle,
            Byte[] storeId,
            XAsyncBlockPtr async);

        //STDAPI XStoreAcquireLicenseForDurablesResult(
        //    _Inout_ XAsyncBlock* async,
        //    _Out_ XStoreLicenseHandle* storeLicenseHandle
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreAcquireLicenseForDurablesResult(
            XAsyncBlockPtr async,
            out XStoreLicenseHandle storeLicenseHandle);
    }
}
