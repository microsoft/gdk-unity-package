using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal partial class XblInterop
    {
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerGetSessionByHandleAsync(
            XblContextHandle xblContext,  
            byte[] handleId,  
            XAsyncBlockPtr async  
        );
        
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XblMultiplayerGetSessionByHandleResult(
            XAsyncBlockPtr async,
            out XblMultiplayerSessionHandle handle
        );
    }
}