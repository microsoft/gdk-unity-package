using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public delegate void XblCleanupResult(Int32 hresult);

            public static Int32 XblInitialize(string scid)
            {
                return XblInterop.XblWrapper_XblInitialize(
                    Converters.StringToNullTerminatedUTF8ByteArray(scid),
                    defaultQueue.handle);
            }

            public static void XblCleanup(XblCleanupResult completionRoutine)
            {
                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    Int32 hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
                    completionRoutine(hresult);
                });

                Int32 hr = XblInterop.XblCleanupAsync(asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr);
                }
            }

            public static Int32 XblContextCreateHandle(XUserHandle user, out XblContextHandle context)
            {
                if (user == null)
                {
                    context = default(XblContextHandle);
                    return HR.E_INVALIDARG;
                }

                Interop.XblContextHandle interopContext;
                Int32 hresult = XblInterop.XblContextCreateHandle(user.InteropHandle, out interopContext);
                if (HR.SUCCEEDED(hresult))
                {
                    context = new XblContextHandle(interopContext);
                }
                else
                {
                    context = default(XblContextHandle);
                }
                return hresult;
            }

            public static void XblContextCloseHandle(XblContextHandle xboxLiveContextHandle)
            {
                if (xboxLiveContextHandle == null)
                {
                    return;
                }

                XblInterop.XblContextCloseHandle(xboxLiveContextHandle.InteropHandle);
                xboxLiveContextHandle.InteropHandle = new Interop.XblContextHandle();
            }
        }
    }
}
