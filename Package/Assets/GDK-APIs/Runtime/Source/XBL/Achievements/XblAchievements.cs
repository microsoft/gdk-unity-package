using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public delegate void XblAchievementsResultGetNextResult(Int32 hresult, XblAchievementsResultHandle result);
            public delegate void XblAchievementsGetAchievementsForTitleIdResult(Int32 hresult, XblAchievementsResultHandle result);
            public delegate void XblAchievementsUpdateAchievementResult(Int32 hresult);
            public delegate void XblAchievementsUpdateAchievementForTitleIdResult(Int32 hresult);
            public delegate void XblAchievementsGetAchievementResult(Int32 hresult, XblAchievementsResultHandle result);

            public static Int32 XblAchievementsResultGetAchievements(XblAchievementsResultHandle resultHandle, out XblAchievement[] achievements)
            {
                if (resultHandle == null)
                {
                    achievements = null;
                    return HR.E_INVALIDARG;
                }
                unsafe
                {
                    Interop.XblAchievement* interopAchievements;
                    uint achievementsCount;
                    Int32 hresult = XblInterop.XblAchievementsResultGetAchievements(resultHandle.InteropHandle, &interopAchievements, &achievementsCount);

                    if (HR.FAILED(hresult))
                    {
                        achievements = null;
                        return hresult;
                    }

                    achievements = Converters.PtrToClassArray<XblAchievement, Interop.XblAchievement>((IntPtr)interopAchievements, achievementsCount, a => new XblAchievement(&a));
                    return hresult;
                }
            }

            public static Int32 XblAchievementsResultHasNext(XblAchievementsResultHandle resultHandle, out bool hasNext)
            {
                if (resultHandle == null)
                {
                    hasNext = default(bool);
                    return HR.E_INVALIDARG;
                }

                unsafe
                {
                    bool result = default(bool);
                    var hr = XblInterop.XblAchievementsResultHasNext(resultHandle.InteropHandle, &result);
                    hasNext = result;

                    return hr;
                }
            }

            public static void XblAchievementsResultGetNextAsync(XblAchievementsResultHandle resultHandle, UInt32 maxItems, XblAchievementsResultGetNextResult completionRoutine)
            {
                if (resultHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblAchievementsResultHandle));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) =>
                {
                    unsafe
                    {
                        Interop.XblAchievementsResult* interopHandle;
                        Int32 hresult = XblInterop.XblAchievementsResultGetNextResult(block.Ptr, &interopHandle);

                        if (HR.SUCCEEDED(hresult))
                        {
                            completionRoutine(hresult, new XblAchievementsResultHandle(interopHandle));
                        }
                        else
                        {
                            completionRoutine(hresult, default(XblAchievementsResultHandle));
                        }
                    }
                });

                unsafe
                {
                    Int32 hr = XblInterop.XblAchievementsResultGetNextAsync(resultHandle.InteropHandle, maxItems, asyncBlock.Ptr);

                    if (HR.FAILED(hr))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hr, default(XblAchievementsResultHandle));
                    }
                }
            }

            public static void XblAchievementsGetAchievementsForTitleIdAsync(
                XblContextHandle xboxLiveContext,
                UInt64 xboxUserId,
                UInt32 titleId,
                XblAchievementType type,
                bool unlockedOnly,
                XblAchievementOrderBy orderBy,
                UInt32 skipItems,
                UInt32 maxItems,
                XblAchievementsGetAchievementsForTitleIdResult completionRoutine)
            {
                if (xboxLiveContext == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblAchievementsResultHandle));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) =>
                {
                    unsafe
                    {
                        Interop.XblAchievementsResult* interopHandle;
                        Int32 hresult = XblInterop.XblAchievementsGetAchievementsForTitleIdResult(block.Ptr, &interopHandle);

                        if (HR.SUCCEEDED(hresult))
                        {
                            completionRoutine(hresult, new XblAchievementsResultHandle(interopHandle));
                        }
                        else
                        {
                            completionRoutine(hresult, default(XblAchievementsResultHandle));
                        }
                    }
                });

                unsafe
                {
                    Int32 hr = XblInterop.XblAchievementsGetAchievementsForTitleIdAsync(
                        (XblContext*)xboxLiveContext.InteropHandle.handle,
                        xboxUserId,
                        titleId,
                        type,
                        Convert.ToByte(unlockedOnly),
                        orderBy,
                        skipItems,
                        maxItems,
                        asyncBlock.Ptr);

                    if (HR.FAILED(hr))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hr, default(XblAchievementsResultHandle));
                    }
                }
            }

            public unsafe static void XblAchievementsUpdateAchievementAsync(
                XblContextHandle xboxLiveContext,
                UInt64 xboxUserId,
                string achievementId,
                UInt32 percentComplete,
                XblAchievementsUpdateAchievementResult completionRoutine)
            {
                if (xboxLiveContext == null)
                {
                    completionRoutine(HR.E_INVALIDARG);
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) =>
                {
                    Int32 hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
                    completionRoutine(hresult);
                });

                using (var disposableCollection = new DisposableCollection())
                {
                    var achPtr = new UTF8StringPtr(achievementId, disposableCollection);

                    Int32 hr = XblInterop.XblAchievementsUpdateAchievementAsync(
                        (XblContext*)xboxLiveContext.InteropHandle.handle,
                        xboxUserId,
                        achPtr.ptr,
                        percentComplete,
                        asyncBlock.Ptr);

                    if (HR.FAILED(hr))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hr);
                    }
                }
            }

            public unsafe static void XblAchievementsUpdateAchievementAsync(
                XblContextHandle xboxLiveContext,
                UInt64 xboxUserId,
                UInt32 titleId,
                string serviceConfigurationId,
                string achievementId,
                UInt32 percentComplete,
                XblAchievementsUpdateAchievementForTitleIdResult completionRoutine)
            {
                if (xboxLiveContext == null)
                {
                    completionRoutine(HR.E_INVALIDARG);
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) =>
                {
                    Int32 hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
                    completionRoutine(hresult);
                });

                using (var disposableCollection = new DisposableCollection())
                {
                    var scidPtr = new UTF8StringPtr(serviceConfigurationId, disposableCollection);
                    var achPtr = new UTF8StringPtr(achievementId, disposableCollection);

                    Int32 hr = XblInterop.XblAchievementsUpdateAchievementForTitleIdAsync(
                    (XblContext*)xboxLiveContext.InteropHandle.handle,
                    xboxUserId,
                    titleId,
                    scidPtr.ptr,
                    achPtr.ptr,
                    percentComplete,
                    asyncBlock.Ptr);

                    if (HR.FAILED(hr))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hr);
                    }
                }
            }

            public unsafe static void XblAchievementsGetAchievementAsync(
                XblContextHandle xboxLiveContext,
                UInt64 xboxUserId,
                string serviceConfigurationId,
                string achievementId,
                XblAchievementsGetAchievementResult completionRoutine)
            {
                if (xboxLiveContext == null)
                {
                    ;
                    completionRoutine(HR.E_INVALIDARG, default(XblAchievementsResultHandle));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) =>
                {
                    Interop.XblAchievementsResult* interopHandle;
                    Int32 hresult = XblInterop.XblAchievementsGetAchievementResult(block.Ptr, &interopHandle);
                    if (HR.SUCCEEDED(hresult))
                    {
                        completionRoutine(hresult, new XblAchievementsResultHandle(interopHandle));
                    }
                    else
                    {
                        completionRoutine(hresult, default(XblAchievementsResultHandle));
                    }
                });

                using (var disposableCollection = new DisposableCollection())
                {
                    var scidPtr = new UTF8StringPtr(serviceConfigurationId, disposableCollection);
                    var achPtr = new UTF8StringPtr(achievementId, disposableCollection);

                    Int32 hr = XblInterop.XblAchievementsGetAchievementAsync(
                    (XblContext*)xboxLiveContext.InteropHandle.handle,
                    xboxUserId,
                    scidPtr.ptr,
                    achPtr.ptr,
                    asyncBlock.Ptr);

                    if (HR.FAILED(hr))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hr, default(XblAchievementsResultHandle));
                    }
                }
            }

            public unsafe static Int32 XblAchievementsResultDuplicateHandle(XblAchievementsResultHandle handle, out XblAchievementsResultHandle duplicatedHandle)
            {
                if (handle == null)
                {
                    duplicatedHandle = default(XblAchievementsResultHandle);
                    return HR.E_INVALIDARG;
                }

                Interop.XblAchievementsResult* duplicatedInteropHandle;
                Int32 hresult = XblInterop.XblAchievementsResultDuplicateHandle(handle.InteropHandle, &duplicatedInteropHandle);
                if (HR.SUCCEEDED(hresult))
                {
                    duplicatedHandle = new XblAchievementsResultHandle(duplicatedInteropHandle);
                }
                else
                {
                    duplicatedHandle = default(XblAchievementsResultHandle);
                }
                return hresult;
            }

            public unsafe static void XblAchievementsResultCloseHandle(XblAchievementsResultHandle handle)
            {
                if (handle == null)
                {
                    return;
                }

                XblInterop.XblAchievementsResultCloseHandle(handle.InteropHandle);
                handle.InteropHandle = null;
            }
        }
    }
}
