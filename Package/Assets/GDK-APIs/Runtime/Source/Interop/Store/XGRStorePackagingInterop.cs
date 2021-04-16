using System;
using System.Runtime.InteropServices;
using System.Text;

namespace XGamingRuntime.Interop
{
    partial class XGRInterop
    {
        internal const Int32 XPACKAGE_IDENTIFIER_MAX_LENGTH = 33;

        //STDAPI XStoreQueryGameAndDlcPackageUpdatesAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryGameAndDlcPackageUpdatesAsync(
            XStoreContextHandle storeContextHandle,
            XAsyncBlockPtr async);

        //STDAPI XStoreQueryGameAndDlcPackageUpdatesResultCount(
        //    _In_ XAsyncBlock* async,
        //    _Out_ uint32_t* count
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryGameAndDlcPackageUpdatesResultCount(
            XAsyncBlockPtr async,
            out UInt32 count);

        //STDAPI XStoreQueryGameAndDlcPackageUpdatesResult(
        //    _Inout_ XAsyncBlock* async,
        //    _In_ uint32_t count,
        //    _Out_writes_(count) XStorePackageUpdate* packageUpdates
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryGameAndDlcPackageUpdatesResult(
            XAsyncBlockPtr async,
            UInt32 count,
            [Out] XStorePackageUpdate[] packageUpdates);

        //STDAPI XStoreDownloadAndInstallPackagesAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_count_(storeIdsCount) const char** storeIds,
        //    _In_ size_t storeIdsCount,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreDownloadAndInstallPackagesAsync(
            XStoreContextHandle storeContextHandle,
            [In] UTF8StringPtr[] storeIds,
            SizeT storeIdsCount,
            XAsyncBlockPtr async);

        //STDAPI XStoreDownloadAndInstallPackagesResultCount(
        //    _In_ XAsyncBlock* async,
        //    _Out_ uint32_t* count
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreDownloadAndInstallPackagesResultCount(
            XAsyncBlockPtr async,
            out UInt32 count);

        //STDAPI XStoreDownloadAndInstallPackagesResult(
        //    _Inout_ XAsyncBlock* async,
        //    _In_ uint32_t count,
        //    _Out_writes_z_(count) char packageIdentifiers[][XPACKAGE_IDENTIFIER_MAX_LENGTH]
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreDownloadAndInstallPackagesResult(
            XAsyncBlockPtr async,
            UInt32 count,
            [In] byte[] packageIdentifiers);

        //STDAPI XStoreDownloadAndInstallPackageUpdatesAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_count_(packageIdentifiersCount) const char** packageIdentifiers,
        //    _In_ size_t packageIdentifiersCount,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreDownloadAndInstallPackageUpdatesAsync(
            XStoreContextHandle storeContextHandle,
            [In] UTF8StringPtr[] packageIdentifiers,
            SizeT packageIdentifiersCount,
            XAsyncBlockPtr async);

        //STDAPI XStoreDownloadAndInstallPackageUpdatesResult(
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreDownloadAndInstallPackageUpdatesResult(
            XAsyncBlockPtr async);

        //STDAPI XStoreDownloadPackageUpdatesAsync(
        //    _In_ const XStoreContextHandle storeContextHandle,
        //    _In_z_count_(packageIdentifiersCount) const char** packageIdentifiers,
        //    _In_ size_t packageIdentifiersCount,
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreDownloadPackageUpdatesAsync(
            XStoreContextHandle storeContextHandle,
            [In] UTF8StringPtr[] packageIdentifiers,
            SizeT packageIdentifiersCount,
            XAsyncBlockPtr async);

        //STDAPI XStoreDownloadPackageUpdatesResult(
        //    _Inout_ XAsyncBlock* async
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreDownloadPackageUpdatesResult(
            XAsyncBlockPtr async);

        //STDAPI XStoreQueryPackageIdentifier(
        //    _In_z_ const char* storeId,
        //    _In_ size_t size,
        //    _Out_writes_z_(size) char* packageIdentifier
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XStoreQueryPackageIdentifier(
            Byte[] storeId,
            SizeT size,
            Byte[] packageIdentifier);
    }
}
