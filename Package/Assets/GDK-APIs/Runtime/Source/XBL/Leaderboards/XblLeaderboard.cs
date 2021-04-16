using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XblLeaderboardGetLeaderboardCompleted(Int32 hresult, XblLeaderboardResult xblLeaderboardResult);
    public delegate void XblLeaderboardGetNextCompleted(Int32 hresult, XblLeaderboardResult xblLeaderboardResult);

    public partial class SDK
    {
        public partial class XBL
        {
            public static void XblLeaderboardGetLeaderboardAsync(
                XblContextHandle xboxLiveContext,
                XblLeaderboardQuery leaderboardQuery,
                XblLeaderboardGetLeaderboardCompleted completionRoutine)
            {
                if (xboxLiveContext == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblLeaderboardResult));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblLeaderboardGetLeaderboardResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblLeaderboardResult));
                        return;
                    }

                    using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                    {
                        IntPtr ptrToBuffer;
                        SizeT bufferUsed;
                        hr = XblInterop.XblLeaderboardGetLeaderboardResult(
                            block,
                            resultSizeInBytes,
                            buffer.IntPtr,
                            out ptrToBuffer,
                            out bufferUsed);

                        if (HR.FAILED(hr))
                        {
                            completionRoutine(hr, default(XblLeaderboardResult));
                            return;
                        }

                        completionRoutine(hr, Converters.PtrToClass<XblLeaderboardResult, Interop.XblLeaderboardResult>(ptrToBuffer, r =>new XblLeaderboardResult(r)));
                    }
                });

                using (DisposableCollection disposableCollection = new DisposableCollection())
                {
                    Int32 hresult = XblInterop.XblLeaderboardGetLeaderboardAsync(
                        xboxLiveContext.InteropHandle,
                        new Interop.XblLeaderboardQuery(leaderboardQuery, disposableCollection),
                        asyncBlock);

                    if (HR.FAILED(hresult))
                    {
                        completionRoutine(hresult, default(XblLeaderboardResult));
                        return;
                    }
                }
            }

            public static void XblLeaderboardResultGetNextAsync(
                XblContextHandle xboxLiveContext,
                XblLeaderboardResult leaderboardResult,
                UInt32 maxItems,
                XblLeaderboardGetNextCompleted completionRoutine)
            {
                if (xboxLiveContext == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblLeaderboardResult));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblLeaderboardResultGetNextResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblLeaderboardResult));
                        return;
                    }

                    using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                    {
                        IntPtr ptrToBuffer;
                        SizeT bufferUsed;
                        hr = XblInterop.XblLeaderboardResultGetNextResult(
                            block,
                            resultSizeInBytes,
                            buffer.IntPtr,
                            out ptrToBuffer,
                            out bufferUsed);

                        if (HR.FAILED(hr))
                        {
                            completionRoutine(hr, default(XblLeaderboardResult));
                            return;
                        }

                        completionRoutine(hr, Converters.PtrToClass<XblLeaderboardResult, Interop.XblLeaderboardResult>(ptrToBuffer, r =>new XblLeaderboardResult(r)));
                    }
                });

                using (DisposableCollection disposableCollection = new DisposableCollection())
                {
                    Interop.XblLeaderboardResult interopResult = new Interop.XblLeaderboardResult(leaderboardResult, disposableCollection);
                    Int32 hresult = XblInterop.XblLeaderboardResultGetNextAsync(xboxLiveContext.InteropHandle, ref interopResult, maxItems, asyncBlock);

                    if (HR.FAILED(hresult))
                    {
                        completionRoutine(hresult, default(XblLeaderboardResult));
                        return;
                    }
                }
            }
        }
    }
}
