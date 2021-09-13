using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public const int StandardScidLength = 36;

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

            /// <summary>
            /// Wraps the underlying native XblContextDuplicateHandle API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/xbox_live_context_c/functions/xblcontextduplicatehandle
            /// </summary>
            /// <param name="srcXboxLiveContextHandle"></param>
            /// <param name="dstXboxLiveContextHandle"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblContextDuplicateHandle(
                XblContextHandle srcXboxLiveContextHandle, 
                out XblContextHandle dstXboxLiveContextHandle)
            {
                var duplicatedHandle = new Interop.XblContextHandle();
                int result = HR.S_OK;
                
                unsafe
                {
                    result = XboxLiveContext.XblContextDuplicateHandle(
                        srcXboxLiveContextHandle.InteropHandle.handle,
                        &duplicatedHandle.handle);
                }

                if (HR.SUCCEEDED(result))
                {
                    dstXboxLiveContextHandle = new XblContextHandle(duplicatedHandle);
                }
                else
                {
                    dstXboxLiveContextHandle = null;
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblContextGetUser API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/xbox_live_context_c/functions/xblcontextgetuser
            /// </summary>
            /// <param name="xboxLiveContextHandle"></param>
            /// <param name="dstUserHandle"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblContextGetUser(
                XblContextHandle xboxLiveContextHandle,
                out XUserHandle dstUserHandle)
            {
                var resultUserHandle = new Interop.XUserHandle();
                int result = HR.S_OK;

                unsafe
                {
                    result = XboxLiveContext.XblContextGetUser(
                        xboxLiveContextHandle.InteropHandle.handle,
                        &resultUserHandle.Ptr);
                }

                if (HR.SUCCEEDED(result))
                {
                    dstUserHandle = new XUserHandle(resultUserHandle);
                }
                else
                {
                    dstUserHandle = null;
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblContextGetXboxUserId API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/xbox_live_context_c/functions/xblcontextgetxboxuserid
            /// </summary>
            /// <param name="xboxLiveContextHandle"></param>
            /// <param name="dstXboxUserId"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblContextGetXboxUserId(
                XblContextHandle xboxLiveContextHandle, 
                ref ulong dstXboxUserId)
            {
                ulong resultUserId = 0;
                int result = HR.S_OK;

                unsafe
                {
                    result = XboxLiveContext.XblContextGetXboxUserId(
                        xboxLiveContextHandle.InteropHandle.handle,
                        &resultUserId);
                }

                if (HR.SUCCEEDED(result))
                {
                    dstXboxUserId = resultUserId;
                }
                else
                {
                    dstXboxUserId = 0;
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblGetScid API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/xbox_live_global_c/functions/xblgetscid
            /// </summary>
            /// <param name="resultScid"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblGetScid(ref string resultScid)
            {
                resultScid = string.Empty;
                int result = HR.S_OK;

                unsafe
                {
                    sbyte* scidPointer;
                    result = XboxLiveGlobal.XblGetScid(&scidPointer);
                    if (HR.SUCCEEDED(result))
                    {
                        resultScid = Converters.BytePointerToString(
                            (byte*)scidPointer,
                            StandardScidLength);
                    }
                }

                return result;
            }
        }
    }
}
