using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XblMultiplayerActivityGetActivityCompleted(Int32 HRESULT, XblMultiplayerActivityInfo[] activityInfos);
    public delegate void XblMultiplayerActivityOperationCompleted(Int32 HRESULT);

    public partial class SDK
    {
        public partial class XBL
        {
            public static void XblMultiplayerActivityGetActivityAsync(
                XblContextHandle xblContextHandle,
                UInt64[] xuids,
                XblMultiplayerActivityGetActivityCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblMultiplayerActivityInfo[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblMultiplayerActivityGetActivityResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblMultiplayerActivityInfo[]));
                        return;
                    }
                    
                    unsafe
                    {
                        using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                        {
                            Interop.XblMultiplayerActivityInfo* ptrToBufferResults;
                            SizeT resultCount, bufferUsed;
                            hr = XblInterop.XblMultiplayerActivityGetActivityResult(
                                block,
                                resultSizeInBytes,
                                buffer.IntPtr,
                                out ptrToBufferResults,
                                out resultCount,
                                out bufferUsed);
                            
                            if (HR.FAILED(hr))
                            {
                                completionRoutine(hr, default(XblMultiplayerActivityInfo[]));
                                return;
                            }
                            
                            System.Collections.Generic.List<XblMultiplayerActivityInfo> activityInfos = new System.Collections.Generic.List<XblMultiplayerActivityInfo>();
                            for (int i = 0; i < resultCount.ToInt32(); i++)
                            {
                                activityInfos.Add(new XblMultiplayerActivityInfo(ptrToBufferResults[i]));
                            }

                            completionRoutine(hr, activityInfos.ToArray());
                        }
                    }
                });

                using (DisposableCollection disposableCollection = new DisposableCollection())
                {
                    SizeT xuidsCount = new SizeT(0);
                    if (xuids != null && xuids.Length > 0)
                    {
                        xuidsCount = new SizeT(xuids.Length);
                    }
                    Int32 hresult = XblInterop.XblMultiplayerActivityGetActivityAsync(
                        xblContextHandle.InteropHandle,
                        xuids,
                        xuidsCount,
                        asyncBlock);

                    if (HR.FAILED(hresult))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hresult, default(XblMultiplayerActivityInfo[]));
                    }
                }
            }


            public static void XblMultiplayerActivityFlushRecentPlayersAsync(
                XblContextHandle xblContextHandle,
                XblMultiplayerActivityOperationCompleted completionRoutine)
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

                Int32 hresult = XblInterop.XblMultiplayerActivityFlushRecentPlayersAsync(
                    xblContextHandle.InteropHandle,
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hresult);
                }
            }

            public static void XblMultiplayerActivitySendInvitesAsync(
                XblContextHandle xblContextHandle,
                UInt64[] xuids,
                bool allowCrossPlatformJoin,
                XblMultiplayerActivityOperationCompleted completionRoutine)
            {
                XblMultiplayerActivitySendInvitesAsync(
                    xblContextHandle,
                    xuids,
                    allowCrossPlatformJoin,
                    String.Empty,
                    completionRoutine);
            }

            public static void XblMultiplayerActivitySendInvitesAsync(
                XblContextHandle xblContextHandle,
                UInt64[] xuids,
                bool allowCrossPlatformJoin,
                string connectionString,
                XblMultiplayerActivityOperationCompleted completionRoutine)
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

                SizeT xuidsCount = new SizeT(0);
                if (xuids != null && xuids.Length > 0)
                {
                    xuidsCount = new SizeT(xuids.Length);
                }
                Int32 hresult = XblInterop.XblMultiplayerActivitySendInvitesAsync(
                    xblContextHandle.InteropHandle,
                    xuids,
                    xuidsCount,
                    new NativeBool(allowCrossPlatformJoin),
                    Converters.StringToNullTerminatedUTF8ByteArray(connectionString),
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hresult);
                }
            }

            public static void XblMultiplayerActivityDeleteActivityAsync(
                XblContextHandle xblContextHandle,
                XblMultiplayerActivityOperationCompleted completionRoutine)
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

                Int32 hresult = XblInterop.XblMultiplayerActivityDeleteActivityAsync(
                    xblContextHandle.InteropHandle,
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hresult);
                }
            }

            public static void XblMultiplayerActivitySetActivityAsync(
                XblContextHandle xblContextHandle,
                XblMultiplayerActivityInfo activityInfo,
                bool allowCrossPlatformJoin,
                XblMultiplayerActivityOperationCompleted completionRoutine)
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
                    Int32 hresult = XblInterop.XblMultiplayerActivitySetActivityAsync(
                    xblContextHandle.InteropHandle,
                    new Interop.XblMultiplayerActivityInfo(activityInfo, disposableCollection),
                    new NativeBool(allowCrossPlatformJoin),
                    asyncBlock);

                    if (HR.FAILED(hresult))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hresult);
                    }
                }
            }

            public static Int32 XblMultiplayerActivityUpdateRecentPlayers(
                XblContextHandle xblContextHandle,
                XblMultiplayerActivityRecentPlayerUpdate[] recentPlayerUpdates)
            {

                Interop.XblMultiplayerActivityRecentPlayerUpdate[] recentPlayerUpdatesInterop = Array.ConvertAll(recentPlayerUpdates, r => new Interop.XblMultiplayerActivityRecentPlayerUpdate(r));
                return XblInterop.XblMultiplayerActivityUpdateRecentPlayers(
                xblContextHandle.InteropHandle,
                recentPlayerUpdatesInterop,
                new SizeT(recentPlayerUpdatesInterop.Length ));
            }
        }
    }
}
