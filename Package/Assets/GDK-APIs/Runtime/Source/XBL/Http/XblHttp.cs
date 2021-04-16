using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XblHttpCallPerformCompleted(Int32 hresult);

    public partial class SDK
    {
        public partial class XBL
        {
            public static Int32 XblHttpCallRequestSetRequestBodyBytes(XblHttpCallHandle call, Byte[] requestBodyBytes)
            {
                if (call == null || requestBodyBytes == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblHttpCallRequestSetRequestBodyBytes(call.InteropHandle, requestBodyBytes, (uint)requestBodyBytes.Length);
            }

            public static Int32 XblHttpCallGetNetworkErrorCode(XblHttpCallHandle call, out Int32 networkErrorCode, out UInt32 platformNetworkErrorCode)
            {
                if (call == null)
                {
                    networkErrorCode = 0;
                    platformNetworkErrorCode = 0;
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblHttpCallGetNetworkErrorCode(call.InteropHandle, out networkErrorCode, out platformNetworkErrorCode);
            }

            public static Int32 XblHttpCallRequestSetLongHttpCall(XblHttpCallHandle call, bool longHttpCall)
            {
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblHttpCallRequestSetLongHttpCall(call.InteropHandle, new NativeBool(longHttpCall));
            }

            public static void XblHttpCallPerformAsync(XblHttpCallHandle call, XblHttpCallResponseBodyType type, XblHttpCallPerformCompleted completionRoutine)
            {
                if (call == null)
                {
                    completionRoutine(HR.E_INVALIDARG);
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    completionRoutine(XGRInterop.XAsyncGetStatus(block, wait: false));
                });

                int hr = XblInterop.XblHttpCallPerformAsync(call.InteropHandle, type, asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr);
                }
            }

            public static Int32 XblHttpCallSetTracing(XblHttpCallHandle call, bool traceCall)
            {
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblHttpCallSetTracing(call.InteropHandle, new NativeBool(traceCall));
            }

            public static Int32 XblHttpCallCreate(XblContextHandle xblContext, string method, string url, out XblHttpCallHandle call)
            {
                if (xblContext == null)
                {
                    call = default(XblHttpCallHandle);
                    return HR.E_INVALIDARG;
                }

                Interop.XblHttpCallHandle callHandle;
                int hr = XblInterop.XblHttpCallCreate(
                    xblContext.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(method),
                    Converters.StringToNullTerminatedUTF8ByteArray(url),
                    out callHandle);

                return XblHttpCallHandle.WrapInteropHandleAndReturnHResult(hr, callHandle, out call);
            }

            public static void XblHttpCallCloseHandle(XblHttpCallHandle call)
            {
                if (call == null)
                {
                    return;
                }

                XblInterop.XblHttpCallCloseHandle(call.InteropHandle);
                call.InteropHandle = new Interop.XblHttpCallHandle();
            }

            public static Int32 XblHttpCallRequestSetRequestBodyString(XblHttpCallHandle call, string requestBodyString)
            {
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblHttpCallRequestSetRequestBodyString(
                    call.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(requestBodyString));
            }

            public static Int32 XblHttpCallGetResponseString(XblHttpCallHandle call, out string responseString)
            {
                responseString = default(string);
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                UTF8StringPtr responseStringPtr;
                int hr = XblInterop.XblHttpCallGetResponseString(call.InteropHandle, out responseStringPtr);
                if (HR.SUCCEEDED(hr))
                {
                    responseString = responseStringPtr.GetString();
                }

                return hr;
            }

            public static Int32 XblHttpCallGetHeaderAtIndex(XblHttpCallHandle call, UInt32 headerIndex, out string headerName, out string headerValue)
            {
                headerName = default(string);
                headerValue = default(string);
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                UTF8StringPtr headerNamePtr, headerValuePtr;
                int hr = XblInterop.XblHttpCallGetHeaderAtIndex(
                    call.InteropHandle,
                    headerIndex,
                    out headerNamePtr,
                    out headerValuePtr);
                if (HR.SUCCEEDED(hr))
                {
                    headerName = headerNamePtr.GetString();
                    headerValue = headerValuePtr.GetString();
                }

                return hr;
            }

            public static Int32 XblHttpCallGetPlatformNetworkErrorMessage(XblHttpCallHandle call, out string platformNetworkErrorMessage)
            {
                platformNetworkErrorMessage = default(string);
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                UTF8StringPtr platformNetworkErrorMessagePtr;
                int hr = XblInterop.XblHttpCallGetPlatformNetworkErrorMessage(call.InteropHandle, out platformNetworkErrorMessagePtr);
                if (HR.SUCCEEDED(hr))
                {
                    platformNetworkErrorMessage = platformNetworkErrorMessagePtr.GetString();
                }

                return hr;
            }

            public static Int32 XblHttpCallGetResponseBodyBytes(XblHttpCallHandle call, out Byte[] buffer)
            {
                buffer = default(Byte[]);
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                SizeT bufferSize, bufferUsed;
                int hr = XblInterop.XblHttpCallGetResponseBodyBytesSize(call.InteropHandle, out bufferSize);
                if (HR.SUCCEEDED(hr))
                {
                    buffer = new byte[bufferSize.ToInt32()];
                    return XblInterop.XblHttpCallGetResponseBodyBytes(call.InteropHandle, bufferSize, buffer, out bufferUsed);
                }
                else
                {
                    return hr;
                }
            }

            public static Int32 XblHttpCallRequestSetRetryAllowed(XblHttpCallHandle call, bool retryAllowed)
            {
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblHttpCallRequestSetRetryAllowed(call.InteropHandle, new NativeBool(retryAllowed));
            }

            public static Int32 XblHttpCallRequestSetHeader(XblHttpCallHandle call, string headerName, string headerValue, bool allowTracing)
            {
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblHttpCallRequestSetHeader(
                    call.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(headerName),
                    Converters.StringToNullTerminatedUTF8ByteArray(headerValue),
                    new NativeBool(allowTracing));
            }

            public static Int32 XblHttpCallDuplicateHandle(XblHttpCallHandle call, out XblHttpCallHandle duplicateHandle)
            {
                if (call == null)
                {
                    duplicateHandle = default(XblHttpCallHandle);
                    return HR.E_INVALIDARG;
                }

                Interop.XblHttpCallHandle duplicateHandleInterop;
                int hr = XblInterop.XblHttpCallDuplicateHandle(call.InteropHandle, out duplicateHandleInterop);
                return XblHttpCallHandle.WrapInteropHandleAndReturnHResult(hr, duplicateHandleInterop, out duplicateHandle);
            }

            public static Int32 XblHttpCallGetNumHeaders(XblHttpCallHandle call, out UInt32 numHeaders)
            {
                if (call == null)
                {
                    numHeaders = default(UInt32);
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblHttpCallGetNumHeaders(call.InteropHandle, out numHeaders);
            }

            public static Int32 XblHttpCallGetStatusCode(XblHttpCallHandle call, out UInt32 statusCode)
            {
                if (call == null)
                {
                    statusCode = default(UInt32);
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblHttpCallGetStatusCode(call.InteropHandle, out statusCode);
            }

            public static Int32 XblHttpCallGetHeader(XblHttpCallHandle call, string headerName, out string headerValue)
            {
                headerValue = default(string);
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                UTF8StringPtr headerValuePtr;
                int hr = XblInterop.XblHttpCallGetHeader(
                    call.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(headerName),
                    out headerValuePtr);
                if (HR.SUCCEEDED(hr))
                {
                    headerValue = headerValuePtr.GetString();
                }

                return hr;
            }

            public static Int32 XblHttpCallGetRequestUrl(XblHttpCallHandle call, out string url)
            {
                url = default(string);
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                UTF8StringPtr urlPtr;
                int hr = XblInterop.XblHttpCallGetRequestUrl(call.InteropHandle, out urlPtr);
                if (HR.SUCCEEDED(hr))
                {
                    url = urlPtr.GetString();
                }

                return hr;
            }

            public static Int32 XblHttpCallRequestSetRetryCacheId(XblHttpCallHandle call, UInt32 retryAfterCacheId)
            {
                if (call == null)
                {
                    return HR.E_INVALIDARG;
                }

                return XblInterop.XblHttpCallRequestSetRetryCacheId(call.InteropHandle, retryAfterCacheId);
            }
        }
    }
}
