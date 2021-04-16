using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XblPrivacyGetAvoidListCompleted(Int32 hresult, UInt64[] xuids);
    public delegate void XblPrivacyGetMuteListCompleted(Int32 hresult, UInt64[] xuids);
    public delegate void XblPrivacyCheckPermissionCompleted(Int32 hresult, XblPermissionCheckResult result);
    public delegate void XblPrivacyBatchCheckPermissionCompleted(Int32 hresult, XblPermissionCheckResult[] result);

    public partial class SDK
    {
        public partial class XBL
        {
            static public void XblPrivacyGetAvoidListAsync(XblContextHandle xblContextHandle, XblPrivacyGetAvoidListCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(UInt64[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultCount;
                    int hr = XblInterop.XblPrivacyGetAvoidListResultCount(block, out resultCount);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(UInt64[]));
                        return;
                    }

                    UInt64[] avoidList = new UInt64[resultCount.ToInt32()];
                    hr = XblInterop.XblPrivacyGetAvoidListResult(block, resultCount, avoidList);
                    completionRoutine(hr, avoidList);
                });

                int hresult = XblInterop.XblPrivacyGetAvoidListAsync(xblContextHandle.InteropHandle, asyncBlock);
                if (HR.FAILED(hresult))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hresult, default(UInt64[]));
                    return;
                }
            }

            static public void XblPrivacyGetMuteListAsync(XblContextHandle xblContextHandle, XblPrivacyGetMuteListCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(UInt64[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultCount;
                    int hr = XblInterop.XblPrivacyGetMuteListResultCount(block, out resultCount);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(UInt64[]));
                        return;
                    }

                    UInt64[] avoidList = new UInt64[resultCount.ToInt32()];
                    hr = XblInterop.XblPrivacyGetMuteListResult(block, resultCount, avoidList);
                    completionRoutine(hr, avoidList);
                });

                int hresult = XblInterop.XblPrivacyGetMuteListAsync(xblContextHandle.InteropHandle, asyncBlock);
                if (HR.FAILED(hresult))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hresult, default(UInt64[]));
                    return;
                }
            }

            static public void XblPrivacyCheckPermissionAsync(
                XblContextHandle xblContextHandle,
                XblPermission permissionToCheck,
                UInt64 targetXuid,
                XblPrivacyCheckPermissionCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblPermissionCheckResult));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblPrivacyCheckPermissionResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblPermissionCheckResult));
                        return;
                    }

                    using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                    {
                        IntPtr ptrToBuffer;
                        SizeT bufferUsed;
                        hr = XblInterop.XblPrivacyCheckPermissionResult(
                            block,
                            resultSizeInBytes,
                            buffer.IntPtr,
                            out ptrToBuffer,
                            out bufferUsed);

                        if (HR.FAILED(hr))
                        {
                            completionRoutine(hr, default(XblPermissionCheckResult));
                            return;
                        }

                        completionRoutine(hr, Converters.PtrToClass<XblPermissionCheckResult, Interop.XblPermissionCheckResult>(ptrToBuffer, r =>new XblPermissionCheckResult(r)));
                    }
                });

                Int32 hresult = XblInterop.XblPrivacyCheckPermissionAsync(
                    xblContextHandle.InteropHandle,
                    permissionToCheck,
                    targetXuid,
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    completionRoutine(hresult, default(XblPermissionCheckResult));
                    return;
                }
            }

            static public void XblPrivacyBatchCheckPermissionAsync(
                XblContextHandle xblContextHandle,
                XblPermission[] permissionsToCheck,
                UInt64[] targetXuids,
                XblAnonymousUserType[] targetAnonymousUserTypes,
                XblPrivacyBatchCheckPermissionCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblPermissionCheckResult[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblPrivacyBatchCheckPermissionResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblPermissionCheckResult[]));
                        return;
                    }

                    using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                    {
                        IntPtr ptrToBuffer;
                        SizeT resultsCount, bufferUsed;
                        hr = XblInterop.XblPrivacyBatchCheckPermissionResult(
                            block,
                            resultSizeInBytes,
                            buffer.IntPtr,
                            out ptrToBuffer,
                            out resultsCount,
                            out bufferUsed);

                        if (HR.FAILED(hr))
                        {
                            completionRoutine(hr, default(XblPermissionCheckResult[]));
                            return;
                        }

                        completionRoutine(hr, Converters.PtrToClassArray<XblPermissionCheckResult, Interop.XblPermissionCheckResult>(ptrToBuffer, resultsCount, r =>new XblPermissionCheckResult(r)));
                    }
                });

                Int32 hresult = XblInterop.XblPrivacyBatchCheckPermissionAsync(
                    xblContextHandle.InteropHandle,
                    permissionsToCheck,
                    new SizeT(permissionsToCheck == null ? 0 : permissionsToCheck.Length),
                    targetXuids,
                    new SizeT(targetXuids == null ? 0 : targetXuids.Length),
                    targetAnonymousUserTypes,
                    new SizeT(targetAnonymousUserTypes == null ? 0 : targetAnonymousUserTypes.Length),
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    completionRoutine(hresult, default(XblPermissionCheckResult[]));
                    return;
                }
            }
        }
    }
}
