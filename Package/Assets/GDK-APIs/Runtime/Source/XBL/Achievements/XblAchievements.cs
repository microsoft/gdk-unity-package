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

                IntPtr interopAchievements;
                SizeT achievementsCount;
                Int32 hresult = XblInterop.XblAchievementsResultGetAchievements(resultHandle.InteropHandle, out interopAchievements, out achievementsCount);

                if (HR.FAILED(hresult))
                {
                    achievements = null;
                    return hresult;
                }

                achievements = Converters.PtrToClassArray<XblAchievement, Interop.XblAchievement>(interopAchievements, achievementsCount, a =>new XblAchievement(a));
                return hresult;
            }

            public static Int32 XblAchievementsResultHasNext(XblAchievementsResultHandle resultHandle, out bool hasNext)
            {
                if (resultHandle == null)
                {
                    hasNext = default(bool);
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblAchievementsResultHasNext(resultHandle.InteropHandle, out hasNext);
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
                    Interop.XblAchievementsResultHandle interopHandle;
                    Int32 hresult = XblInterop.XblAchievementsResultGetNextResult(block, out interopHandle);

                    if (HR.SUCCEEDED(hresult))
                    {
                        completionRoutine(hresult, new XblAchievementsResultHandle(interopHandle));
                    }
                    else
                    {
                        completionRoutine(hresult, default(XblAchievementsResultHandle));
                    }
                });

                Int32 hr = XblInterop.XblAchievementsResultGetNextAsync(resultHandle.InteropHandle, maxItems, asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr, default(XblAchievementsResultHandle));
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
                    Interop.XblAchievementsResultHandle interopHandle;
                    Int32 hresult = XblInterop.XblAchievementsGetAchievementsForTitleIdResult(block, out interopHandle);

                    if (HR.SUCCEEDED(hresult))
                    {
                        completionRoutine(hresult, new XblAchievementsResultHandle(interopHandle));
                    }
                    else
                    {
                        completionRoutine(hresult, default(XblAchievementsResultHandle));
                    }
                });

                Int32 hr = XblInterop.XblAchievementsGetAchievementsForTitleIdAsync(
                    xboxLiveContext.InteropHandle,
                    xboxUserId,
                    titleId,
                    type,
                    unlockedOnly,
                    orderBy,
                    skipItems,
                    maxItems,
                    asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr, default(XblAchievementsResultHandle));
                }
            }

            public static void XblAchievementsUpdateAchievementAsync(
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

                Int32 hr = XblInterop.XblAchievementsUpdateAchievementAsync(
                    xboxLiveContext.InteropHandle,
                    xboxUserId,
                    Converters.StringToNullTerminatedUTF8ByteArray(achievementId),
                    percentComplete,
                    asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr);
                }
            }

            public static void XblAchievementsUpdateAchievementAsync(
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

                Int32 hr = XblInterop.XblAchievementsUpdateAchievementForTitleIdAsync(
                    xboxLiveContext.InteropHandle,
                    xboxUserId,
                    titleId,
                    Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId),
                    Converters.StringToNullTerminatedUTF8ByteArray(achievementId),
                    percentComplete,
                    asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr);
                }
            }

            public static void XblAchievementsGetAchievementAsync(
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
                    Interop.XblAchievementsResultHandle interopHandle;
                    Int32 hresult = XblInterop.XblAchievementsGetAchievementResult(block, out interopHandle);
                    if (HR.SUCCEEDED(hresult))
                    {
                        completionRoutine(hresult, new XblAchievementsResultHandle(interopHandle));
                    }
                    else
                    {
                        completionRoutine(hresult, default(XblAchievementsResultHandle));
                    }
                });

                Int32 hr = XblInterop.XblAchievementsGetAchievementAsync(
                    xboxLiveContext.InteropHandle,
                    xboxUserId,
                    Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId),
                    Converters.StringToNullTerminatedUTF8ByteArray(achievementId),
                    asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr, default(XblAchievementsResultHandle));
                }
            }

            public static Int32 XblAchievementsResultDuplicateHandle(XblAchievementsResultHandle handle, out XblAchievementsResultHandle duplicatedHandle)
            {
                if (handle == null)
                {
                    duplicatedHandle = default(XblAchievementsResultHandle);
                    return HR.E_INVALIDARG;
                }

                Interop.XblAchievementsResultHandle duplicatedInteropHandle;
                Int32 hresult = XblInterop.XblAchievementsResultDuplicateHandle(handle.InteropHandle, out duplicatedInteropHandle);
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

            public static void XblAchievementsResultCloseHandle(XblAchievementsResultHandle handle)
            {
                if (handle == null)
                {
                    return;
                }

                XblInterop.XblAchievementsResultCloseHandle(handle.InteropHandle);
                handle.InteropHandle = new Interop.XblAchievementsResultHandle();
            }
        }
    }
}
