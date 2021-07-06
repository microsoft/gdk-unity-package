using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public delegate void XblMultiplayerGetSessionByHandleCallback(
               Int32 hresult,
               XblMultiplayerSessionHandle handle);

            public static void XblMultiplayerGetSessionByHandleAsync(
                XblContextHandle xblContext,
                string handleId,
                XblMultiplayerGetSessionByHandleCallback completionRoutine)
            {
                if (xblContext == null || string.IsNullOrEmpty(handleId))
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblMultiplayerSessionHandle));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(
                    defaultQueue.handle,
                    (XAsyncBlockPtr asyncBlock) =>
                {
                    Interop.XblMultiplayerSessionHandle result;
                    Int32 hresult = XblInterop.XblMultiplayerGetSessionByHandleResult(asyncBlock, out result);
                    if (HR.FAILED(hresult))
                    {
                        completionRoutine?.Invoke(hresult, default(XblMultiplayerSessionHandle));
                    }
                    else
                    {
                        completionRoutine?.Invoke(hresult, new XblMultiplayerSessionHandle(result));
                    }

                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                });

                Int32 hr = XblInterop.XblMultiplayerGetSessionByHandleAsync(
                    xblContext.InteropHandle,
                   Converters.StringToNullTerminatedUTF8ByteArray(handleId),
                    asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine?.Invoke(hr, default(XblMultiplayerSessionHandle));
                }
            }
        }
    }
}
