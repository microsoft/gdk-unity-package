using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XblPresenceSetPresenceCompleted(Int32 hresult);
    public delegate void XblPresenceGetPresenceCompleted(Int32 hresult, XblPresenceRecordHandle presenceRecordHandle);
    public delegate void XblPresenceGetPresenceForMultipleUsersCompleted(Int32 hresult, XblPresenceRecordHandle[] presenceRecordHandles);
    public delegate void XblPresenceGetPresenceForSocialGroupCompleted(Int32 hresult, XblPresenceRecordHandle[] presenceRecordHandles);
    //public delegate void XblPresenceDevicePresenceChangedHandler(UInt64 xuid, XblPresenceDeviceType deviceType, bool isUserLoggedOnDevice);
    //public delegate void XblPresenceTitlePresenceChangedHandler(UInt64 xuid, UInt32 titleId, XblPresenceTitleState titleState);

    public partial class SDK
    {
        public partial class XBL
        {
            public static Int32 XblPresenceRecordGetXuid(XblPresenceRecordHandle handle, out UInt64 xuid)
            {
                if (handle == null)
                {
                    xuid = default(UInt64);
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblPresenceRecordGetXuid(handle.InteropHandle, out xuid);
            }

            public static Int32 XblPresenceRecordGetUserState(XblPresenceRecordHandle handle, out XblPresenceUserState userState)
            {
                if (handle == null)
                {
                    userState = default(XblPresenceUserState);
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblPresenceRecordGetUserState(handle.InteropHandle, out userState);
            }

            public static Int32 XblPresenceRecordGetDeviceRecords(XblPresenceRecordHandle handle, out XblPresenceDeviceRecord[] deviceRecords)
            {
                if (handle == null)
                {
                    deviceRecords = default(XblPresenceDeviceRecord[]);
                    return HR.E_INVALIDARG;
                }

                IntPtr deviceRecordsIntPtr;
                SizeT deviceRecordsCount;
                Int32 hresult = XblInterop.XblPresenceRecordGetDeviceRecords(
                    handle.InteropHandle,
                    out deviceRecordsIntPtr,
                    out deviceRecordsCount);

                if (HR.FAILED(hresult))
                {
                    deviceRecords = default(XblPresenceDeviceRecord[]);
                    return hresult;
                }

                deviceRecords = Converters.PtrToClassArray<XblPresenceDeviceRecord, Interop.XblPresenceDeviceRecord>(
                    deviceRecordsIntPtr,
                    deviceRecordsCount,
                    dr =>new XblPresenceDeviceRecord(dr));

                return hresult;
            }

            public static Int32 XblPresenceRecordDuplicateHandle(XblPresenceRecordHandle handle, out XblPresenceRecordHandle duplicatedHandle)
            {
                if (handle == null)
                {
                    duplicatedHandle = default(XblPresenceRecordHandle);
                    return HR.E_INVALIDARG;
                }

                Interop.XblPresenceRecordHandle duplicatedInteropHandle;
                Int32 hresult = XblInterop.XblPresenceRecordDuplicateHandle(handle.InteropHandle, out duplicatedInteropHandle);
                return XblPresenceRecordHandle.WrapInteropHandleAndReturnHResult(hresult, duplicatedInteropHandle, out duplicatedHandle);
            }

            public static void XblPresenceRecordCloseHandle(XblPresenceRecordHandle handle)
            {
                if (handle == null)
                {
                    return;
                }

                XblInterop.XblPresenceRecordCloseHandle(handle.InteropHandle);
            }

            public static void XblPresenceSetPresenceAsync(
                XblContextHandle xblContextHandle,
                bool isUserActiveInTitle,
                XblPresenceRichPresenceIds richPresenceIds,
                XblPresenceSetPresenceCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG);
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    completionRoutine(XGRInterop.XAsyncGetStatus(block, wait: false));
                });

                using (DisposableCollection disposableCollection = new DisposableCollection())
                {
                    Int32 hresult = XblInterop.XblPresenceSetPresenceAsync(
                        xblContextHandle.InteropHandle,
                        isUserActiveInTitle,
                        richPresenceIds == null ? null : new Interop.XblPresenceRichPresenceIdsRef(richPresenceIds, disposableCollection),
                        asyncBlock);

                    if (HR.FAILED(hresult))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hresult);
                    }
                }
            }

            public static void XblPresenceGetPresenceAsync(
                XblContextHandle xblContextHandle,
                UInt64 xuid,
                XblPresenceGetPresenceCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblPresenceRecordHandle));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    Interop.XblPresenceRecordHandle interopHandle;
                    Int32 hr = XblInterop.XblPresenceGetPresenceResult(block, out interopHandle);

                    XblPresenceRecordHandle handle;
                    XblPresenceRecordHandle.WrapInteropHandleAndReturnHResult(hr, interopHandle, out handle);
                    completionRoutine(hr, handle);
                });

                Int32 hresult = XblInterop.XblPresenceGetPresenceAsync(
                    xblContextHandle.InteropHandle,
                    xuid,
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hresult, default(XblPresenceRecordHandle));
                }
            }

            public static void XblPresenceGetPresenceForMultipleUsersAsync(
                XblContextHandle xblContextHandle,
                UInt64[] xuids,
                XblPresenceQueryFilters filters,
                XblPresenceGetPresenceForMultipleUsersCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblPresenceRecordHandle[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultCount;
                    Int32 hr = XblInterop.XblPresenceGetPresenceForMultipleUsersResultCount(block, out resultCount);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblPresenceRecordHandle[]));
                        return;
                    }

                    Interop.XblPresenceRecordHandle[] interopHandles = new Interop.XblPresenceRecordHandle[resultCount.ToInt32()];
                    hr = XblInterop.XblPresenceGetPresenceForMultipleUsersResult(block, interopHandles, resultCount);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblPresenceRecordHandle[]));
                        return;
                    }

                    completionRoutine(hr, Array.ConvertAll(interopHandles, h =>new XblPresenceRecordHandle(h)));
                });

                using (DisposableCollection disposableCollection = new DisposableCollection())
                {
                    SizeT xuidsCount = new SizeT(0);
                    if (xuids != null && xuids.Length > 0)
                    {
                        xuidsCount = new SizeT(xuids.Length);
                    }
                    Int32 hresult = XblInterop.XblPresenceGetPresenceForMultipleUsersAsync(
                        xblContextHandle.InteropHandle,
                        xuids,
                        xuidsCount,
                        filters == null ? null : new Interop.XblPresenceQueryFiltersRef(filters, disposableCollection),
                        asyncBlock);

                    if (HR.FAILED(hresult))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hresult, default(XblPresenceRecordHandle[]));
                    }
                }
            }

            public static void XblPresenceGetPresenceForSocialGroupAsync(
                XblContextHandle xblContextHandle,
                string socialGroupName,
                UInt64? socialGroupOwnerXuid,
                XblPresenceQueryFilters filters,
                XblPresenceGetPresenceForSocialGroupCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblPresenceRecordHandle[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultCount;
                    Int32 hr = XblInterop.XblPresenceGetPresenceForSocialGroupResultCount(block, out resultCount);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblPresenceRecordHandle[]));
                        return;
                    }

                    Interop.XblPresenceRecordHandle[] interopHandles = new Interop.XblPresenceRecordHandle[resultCount.ToInt32()];
                    hr = XblInterop.XblPresenceGetPresenceForSocialGroupResult(block, interopHandles, resultCount);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblPresenceRecordHandle[]));
                        return;
                    }

                    completionRoutine(hr, Array.ConvertAll(interopHandles, h =>new XblPresenceRecordHandle(h)));
                });

                using (DisposableCollection disposableCollection = new DisposableCollection())
                {
                    Int32 hresult = XblInterop.XblPresenceGetPresenceForSocialGroupAsync(
                        xblContextHandle.InteropHandle,
                        Converters.StringToNullTerminatedUTF8ByteArray(socialGroupName),
                        socialGroupOwnerXuid == null ? null : new UInt64Ref(socialGroupOwnerXuid.Value),
                        filters == null ? null : new Interop.XblPresenceQueryFiltersRef(filters, disposableCollection),
                        asyncBlock);

                    if (HR.FAILED(hresult))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hresult, default(XblPresenceRecordHandle[]));
                    }
                }
            }

            // STDAPI XblPresenceSubscribeToDevicePresenceChange(
            //     _In_ XblContextHandle xblContextHandle,
            //     _In_ uint64_t xuid,
            //     _Out_ XblRealTimeActivitySubscriptionHandle* subscriptionHandle
            // ) XBL_NOEXCEPT;

            // STDAPI XblPresenceUnsubscribeFromDevicePresenceChange(
            //     _In_ XblContextHandle xblContextHandle,
            //     _In_ XblRealTimeActivitySubscriptionHandle subscriptionHandle
            // ) XBL_NOEXCEPT;

            // STDAPI XblPresenceSubscribeToTitlePresenceChange(
            //     _In_ XblContextHandle xblContextHandle,
            //     _In_ uint64_t xuid,
            //     _In_ uint32_t titleId,
            //     _Out_ XblRealTimeActivitySubscriptionHandle* subscriptionHandle
            // ) XBL_NOEXCEPT;

            // STDAPI XblPresenceUnsubscribeFromTitlePresenceChange(
            //     _In_ XblContextHandle xblContextHandle,
            //     _In_ XblRealTimeActivitySubscriptionHandle subscriptionHandle
            // ) XBL_NOEXCEPT;

            // STDAPI_(XblFunctionContext) XblPresenceAddDevicePresenceChangedHandler(
            //     _In_ XblContextHandle xblContextHandle,
            //     _In_ XblPresenceDevicePresenceChangedHandler* handler,
            //     _In_opt_ void* context
            // ) XBL_NOEXCEPT;

            // STDAPI XblPresenceRemoveDevicePresenceChangedHandler(
            //     _In_ XblContextHandle xblContextHandle,
            //     _In_ XblFunctionContext token
            // ) XBL_NOEXCEPT;

            // STDAPI_(XblFunctionContext) XblPresenceAddTitlePresenceChangedHandler(
            //     _In_ XblContextHandle xblContextHandle,
            //     _In_ XblPresenceTitlePresenceChangedHandler* handler,
            //     _In_opt_ void* context
            // ) XBL_NOEXCEPT;

            // STDAPI XblPresenceRemoveTitlePresenceChangedHandler(
            //     _In_ XblContextHandle xblContextHandle,
            //     _In_ XblFunctionContext token
            // ) XBL_NOEXCEPT;

        }
    }
}
