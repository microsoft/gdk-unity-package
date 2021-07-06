using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal partial class XblInterop
    {
        //STDAPI XblMultiplayerGetSessionByHandleAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_ const char* handleId,
        //    _Inout_ XAsyncBlock* async  
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerGetSessionByHandleAsync(
            XblContextHandle xblContext,  
            byte[] handleId,  
            XAsyncBlockPtr async  
        );

        //STDAPI XblMultiplayerGetSessionByHandleResult(
        //    _Inout_ XAsyncBlock* async,
        //    _Out_ XblMultiplayerSessionHandle* handle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerGetSessionByHandleResult(
            XAsyncBlockPtr async,
            out XblMultiplayerSessionHandle handle
        );
    }
}