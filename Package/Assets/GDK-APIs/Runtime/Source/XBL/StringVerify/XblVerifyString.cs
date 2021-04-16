using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XblStringVerifyStringCompleted(Int32 hresult, XblVerifyStringResult result);
    public delegate void XblStringVerifyStringsCompleted(Int32 hresult, XblVerifyStringResult[] result);

    public partial class SDK
    {
        public partial class XBL
        {
            static public void XblStringVerifyStringAsync(
                XblContextHandle xblContextHandle,
                string stringToVerify,
                XblStringVerifyStringCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblVerifyStringResult));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblStringVerifyStringResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblVerifyStringResult));
                        return;
                    }

                    using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                    {
                        IntPtr result;
                        SizeT bufferUsed;
                        hr = XblInterop.XblStringVerifyStringResult(
                            block,
                            resultSizeInBytes,
                            buffer.IntPtr,
                            out result,
                            out bufferUsed);

                        if (HR.FAILED(hr))
                        {
                            completionRoutine(hr, default(XblVerifyStringResult));
                            return;
                        }

                        completionRoutine(hr, Converters.PtrToClass<XblVerifyStringResult, Interop.XblVerifyStringResult>(result, r =>new XblVerifyStringResult(r)));
                    }
                });

                Int32 hresult = XblInterop.XblStringVerifyStringAsync(
                    xblContextHandle.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(stringToVerify),
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    completionRoutine(hresult, default(XblVerifyStringResult));
                    return;
                }
            }

            static public void XblStringVerifyStringsAsync(
                XblContextHandle xblContextHandle,
                string[] stringsToVerify,
                XblStringVerifyStringsCompleted completionRoutine)
            {
                if (xblContextHandle == null || stringsToVerify == null || stringsToVerify.Length == 0)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblVerifyStringResult[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblStringVerifyStringsResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblVerifyStringResult[]));
                        return;
                    }

                    using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                    {
                        IntPtr ptrToBuffer;
                        SizeT resultsCount, bufferUsed;
                        hr = XblInterop.XblStringVerifyStringsResult(
                            block,
                            resultSizeInBytes,
                            buffer.IntPtr,
                            out ptrToBuffer,
                            out resultsCount,
                            out bufferUsed);

                        if (HR.FAILED(hr))
                        {
                            completionRoutine(hr, default(XblVerifyStringResult[]));
                            return;
                        }

                        completionRoutine(hr, Converters.PtrToClassArray<XblVerifyStringResult, Interop.XblVerifyStringResult>(ptrToBuffer, resultsCount, r =>new XblVerifyStringResult(r)));
                    }
                });

                using (DisposableBuffer stringsToVerifyBuffer = Converters.StringArrayToUTF8StringArray(stringsToVerify))
                {
                    Int32 hresult = XblInterop.XblStringVerifyStringsAsync(
                        xblContextHandle.InteropHandle,
                        stringsToVerifyBuffer.IntPtr,
                        Convert.ToUInt64(stringsToVerify.Length),
                        asyncBlock);

                    if (HR.FAILED(hresult))
                    {
                        completionRoutine(hresult, default(XblVerifyStringResult[]));
                        return;
                    }
                }
            }
        }
    }
}
