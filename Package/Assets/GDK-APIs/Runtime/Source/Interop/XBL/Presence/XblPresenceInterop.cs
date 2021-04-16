using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef void CALLBACK XblPresenceDevicePresenceChangedHandler(
    //     _In_opt_ void* context,
    //     _In_ uint64_t xuid,
    //     _In_ XblPresenceDeviceType deviceType,
    //     _In_ bool isUserLoggedOnDevice
    // );
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate void XblPresenceDevicePresenceChangedHandler(
        IntPtr context,
        UInt64 xuid,
        XblPresenceDeviceType deviceType,
        [MarshalAs(UnmanagedType.U1)] bool isUserLoggedOnDevice);

    // typedef void CALLBACK XblPresenceTitlePresenceChangedHandler(
    //     _In_opt_ void* context,
    //     _In_ uint64_t xuid,
    //     _In_ uint32_t titleId,
    //     _In_ XblPresenceTitleState titleState
    // );
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate void XblPresenceTitlePresenceChangedHandler(
        IntPtr context,
        UInt64 xuid,
        UInt32 titleId,
        XblPresenceTitleState titleState);

    internal partial class XblInterop
    {
        // STDAPI XblPresenceRecordGetXuid(
        //     _In_ XblPresenceRecordHandle handle,
        //     _Out_ uint64_t* xuid
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceRecordGetXuid(
            XblPresenceRecordHandle handle,
            out UInt64 xuid);

        // STDAPI XblPresenceRecordGetUserState(
        //     _In_ XblPresenceRecordHandle handle,
        //     _Out_ XblPresenceUserState* userState
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceRecordGetUserState(
            XblPresenceRecordHandle handle,
            out XblPresenceUserState userState);

        // STDAPI XblPresenceRecordGetDeviceRecords(
        //     _In_ XblPresenceRecordHandle handle,
        //     _Out_ const XblPresenceDeviceRecord** deviceRecords,
        //     _Out_ size_t* deviceRecordsCount
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceRecordGetDeviceRecords(
            XblPresenceRecordHandle handle,
            out IntPtr deviceRecords,
            out SizeT deviceRecordsCount);

        // STDAPI XblPresenceRecordDuplicateHandle(
        //     _In_ XblPresenceRecordHandle handle,
        //     _Out_ XblPresenceRecordHandle* duplicatedHandle
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceRecordDuplicateHandle(
            XblPresenceRecordHandle handle,
            out XblPresenceRecordHandle duplicatedHandle);

        // STDAPI_(void) XblPresenceRecordCloseHandle(
        //     _In_ XblPresenceRecordHandle handle
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XblPresenceRecordCloseHandle(XblPresenceRecordHandle handle);

        // STDAPI XblPresenceSetPresenceAsync(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ bool isUserActiveInTitle,
        //     _In_opt_ XblPresenceRichPresenceIds* richPresenceIds,
        //     _In_ XAsyncBlock* async
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceSetPresenceAsync(
            XblContextHandle xblContextHandle,
            [MarshalAs(UnmanagedType.U1)] bool isUserActiveInTitle,
            [Optional] XblPresenceRichPresenceIdsRef richPresenceIds,
            XAsyncBlockPtr asyncBlockPtr);

        // STDAPI XblPresenceGetPresenceAsync(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ uint64_t xuid,
        //     _In_ XAsyncBlock* async
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceGetPresenceAsync(
            XblContextHandle xblContextHandle,
            UInt64 xuid,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XblPresenceGetPresenceResult(
        //     _In_ XAsyncBlock* async,
        //     _Out_ XblPresenceRecordHandle* presenceRecordHandle
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceGetPresenceResult(
            XAsyncBlockPtr asyncBlock,
            out XblPresenceRecordHandle presenceRecordHandle);

        // STDAPI XblPresenceGetPresenceForMultipleUsersAsync(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ uint64_t* xuids,
        //     _In_ size_t xuidsCount,
        //     _In_opt_ XblPresenceQueryFilters* filters,
        //     _In_ XAsyncBlock* async
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceGetPresenceForMultipleUsersAsync(
            XblContextHandle xblContextHandle,
            UInt64[] xuids,
            SizeT xuidsCount,
            [Optional] XblPresenceQueryFiltersRef filters,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XblPresenceGetPresenceForMultipleUsersResultCount(
        //     _In_ XAsyncBlock* async,
        //     _Out_ size_t* resultCount
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceGetPresenceForMultipleUsersResultCount(
            XAsyncBlockPtr asyncBlock,
            out SizeT resultCount);

        // STDAPI XblPresenceGetPresenceForMultipleUsersResult(
        //     _In_ XAsyncBlock* async,
        //     _Out_ XblPresenceRecordHandle* presenceRecordHandles,
        //     _In_ size_t presenceRecordHandlesCount
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceGetPresenceForMultipleUsersResult(
            XAsyncBlockPtr asyncBlock,
            [Out] XblPresenceRecordHandle[] presenceRecordHandles,
            SizeT presenceRecordHandlesCount);

        // STDAPI XblPresenceGetPresenceForSocialGroupAsync(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_z_ const char* socialGroupName,
        //     _In_opt_ uint64_t* socialGroupOwnerXuid,
        //     _In_opt_ XblPresenceQueryFilters* filters,
        //     _In_ XAsyncBlock* async
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceGetPresenceForSocialGroupAsync(
            XblContextHandle xblContextHandle,
            byte[] socialGroupName,
            [Optional] UInt64Ref socialGroupOwnerXuid,
            [Optional] XblPresenceQueryFiltersRef filters,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XblPresenceGetPresenceForSocialGroupResultCount(
        //     _In_ XAsyncBlock* async,
        //     _Out_ size_t* resultCount
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceGetPresenceForSocialGroupResultCount(
            XAsyncBlockPtr asyncBlock,
            out SizeT resultCount);

        // STDAPI XblPresenceGetPresenceForSocialGroupResult(
        //     _In_ XAsyncBlock* async,
        //     _Out_ XblPresenceRecordHandle* presenceRecordHandles,
        //     _In_ size_t presenceRecordHandlesCount
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceGetPresenceForSocialGroupResult(
            XAsyncBlockPtr asyncBlock,
            [Out] XblPresenceRecordHandle[] presenceRecordHandles,
            SizeT presenceRecordHandlesCount);

        // STDAPI XblPresenceSubscribeToDevicePresenceChange(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ uint64_t xuid,
        //     _Out_ XblRealTimeActivitySubscriptionHandle* subscriptionHandle
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceSubscribeToDevicePresenceChange(
            XblContextHandle xblContextHandle,
            UInt64 xuid,
            out XblRealTimeActivitySubscriptionHandle subscriptionHandle);

        // STDAPI XblPresenceUnsubscribeFromDevicePresenceChange(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ XblRealTimeActivitySubscriptionHandle subscriptionHandle
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceUnsubscribeFromDevicePresenceChange(
            XblContextHandle xblContextHandle,
            XblRealTimeActivitySubscriptionHandle subscriptionHandle);

        // STDAPI XblPresenceSubscribeToTitlePresenceChange(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ uint64_t xuid,
        //     _In_ uint32_t titleId,
        //     _Out_ XblRealTimeActivitySubscriptionHandle* subscriptionHandle
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceSubscribeToTitlePresenceChange(
            XblContextHandle xblContextHandle,
            UInt64 xuid,
            UInt32 titleId,
            out XblRealTimeActivitySubscriptionHandle subscriptionHandle);

        // STDAPI XblPresenceUnsubscribeFromTitlePresenceChange(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ XblRealTimeActivitySubscriptionHandle subscriptionHandle
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceUnsubscribeFromTitlePresenceChange(
            XblContextHandle xblContext,
            XblRealTimeActivitySubscriptionHandle subscriptionHandle);

        // STDAPI_(XblFunctionContext) XblPresenceAddDevicePresenceChangedHandler(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ XblPresenceDevicePresenceChangedHandler* handler,
        //     _In_opt_ void* context
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern XblFunctionContext XblPresenceAddDevicePresenceChangedHandler(
            XblContextHandle xblContextHandle,
            XblPresenceDevicePresenceChangedHandler handler,
            IntPtr context);

        // STDAPI XblPresenceRemoveDevicePresenceChangedHandler(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ XblFunctionContext token
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceRemoveDevicePresenceChangedHandler(
            XblContextHandle xblContextHandle,
            XblFunctionContext token);

        // STDAPI_(XblFunctionContext) XblPresenceAddTitlePresenceChangedHandler(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ XblPresenceTitlePresenceChangedHandler* handler,
        //     _In_opt_ void* context
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern XblFunctionContext XblPresenceAddTitlePresenceChangedHandler(
            XblContextHandle xblContextHandle,
            XblPresenceTitlePresenceChangedHandler handler,
            IntPtr context);

        // STDAPI XblPresenceRemoveTitlePresenceChangedHandler(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ XblFunctionContext token
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblPresenceRemoveTitlePresenceChangedHandler(
            XblContextHandle xblContextHandle,
            XblFunctionContext token);
    }
}
