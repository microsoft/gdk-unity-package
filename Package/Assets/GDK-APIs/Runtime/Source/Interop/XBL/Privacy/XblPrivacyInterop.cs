using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    partial class XblInterop
    {
        //STDAPI XblPrivacyGetAvoidListAsync(
        //    _In_ XblContextHandle xblContextHandle,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyGetAvoidListAsync(
            XblContextHandle xblContextHandle,
            XAsyncBlockPtr async);

        //STDAPI XblPrivacyGetAvoidListResultCount(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* xuidCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyGetAvoidListResultCount(
            XAsyncBlockPtr async,
            out SizeT xuidCount);

        //STDAPI XblPrivacyGetAvoidListResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ size_t xuidCount,
        //    _Out_writes_(xuidCount) uint64_t* xuids
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyGetAvoidListResult(
            XAsyncBlockPtr async,
            SizeT xuidCount,
            [Out] UInt64[] xuids);

        //STDAPI XblPrivacyGetMuteListAsync(
        //    _In_ XblContextHandle xblContextHandle,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyGetMuteListAsync(
            XblContextHandle xblContextHandle,
            XAsyncBlockPtr async);

        //STDAPI XblPrivacyGetMuteListResultCount(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* xuidCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyGetMuteListResultCount(
            XAsyncBlockPtr async,
            out SizeT xuidCount);

        //STDAPI XblPrivacyGetMuteListResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ size_t xuidCount,
        //    _Out_writes_(xuidCount) uint64_t* xuids
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyGetMuteListResult(
            XAsyncBlockPtr async,
            SizeT xuidCount,
            [Out] UInt64[] xuids);

        //STDAPI XblPrivacyCheckPermissionAsync(
        //    _In_ XblContextHandle xblContextHandle,
        //    _In_ XblPermission permissionToCheck,
        //    _In_ uint64_t targetXuid,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyCheckPermissionAsync(
            XblContextHandle xblContextHandle,
            XblPermission permissionToCheck,
            UInt64 targetXuid,
            XAsyncBlockPtr async);

        //STDAPI XblPrivacyCheckPermissionResultSize(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* resultSizeInBytes
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyCheckPermissionResultSize(
            XAsyncBlockPtr async,
            out SizeT resultSizeInBytes);

        //STDAPI XblPrivacyCheckPermissionResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ size_t bufferSize,
        //    _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //    _Outptr_ XblPermissionCheckResult** result,
        //    _Out_opt_ size_t* bufferUsed
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyCheckPermissionResult(
            XAsyncBlockPtr async,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr result,
            out SizeT bufferUsed);

        //STDAPI XblPrivacyBatchCheckPermissionAsync(
        //    _In_ XblContextHandle xblContextHandle,
        //    _In_reads_(permissionsCount) XblPermission* permissionsToCheck,
        //    _In_ size_t permissionsCount,
        //    _In_reads_(xuidsCount) uint64_t* targetXuids,
        //    _In_ size_t xuidsCount,
        //    _In_reads_(targetAnonymousUserTypesCount) XblAnonymousUserType* targetAnonymousUserTypes,
        //    _In_ size_t targetAnonymousUserTypesCount,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyBatchCheckPermissionAsync(
            XblContextHandle xblContextHandle,
            [In] XblPermission[] permissionsToCheck,
            SizeT permissionsCount,
            [In] UInt64[] targetXuids,
            SizeT xuidsCount,
            [In] XblAnonymousUserType[] targetAnonymousUserTypes,
            SizeT targetAnonymousUserTypesCount,
            XAsyncBlockPtr async);

        //STDAPI XblPrivacyBatchCheckPermissionResultSize(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* resultSizeInBytes
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyBatchCheckPermissionResultSize(
            XAsyncBlockPtr async,
            out SizeT resultSizeInBytes);

        //STDAPI XblPrivacyBatchCheckPermissionResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ size_t bufferSize,
        //    _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //    _Outptr_ XblPermissionCheckResult** results,
        //    _Out_ size_t* resultsCount,
        //    _Out_opt_ size_t* bufferUsed
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPrivacyBatchCheckPermissionResult(
            XAsyncBlockPtr async,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr results,
            out SizeT resultsCount,
            out SizeT bufferUsed);
    }
}
