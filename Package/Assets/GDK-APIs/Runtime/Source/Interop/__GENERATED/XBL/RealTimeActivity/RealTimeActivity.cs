using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    public static unsafe partial class RealTimeActivity
    {
        //typedef void CALLBACK XblRealTimeActivityConnectionStateChangeHandler(
        //    _In_opt_ void* context,
        //    _In_ XblRealTimeActivityConnectionState connectionState
        //);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void XblRealTimeActivityConnectionStateChangeHandler(
            IntPtr context,
            XblRealTimeActivityConnectionState connectionState);

        //typedef void CALLBACK XblRealTimeActivityResyncHandler(
        //    _In_opt_ void* context
        //);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void XblRealTimeActivityResyncHandler(
            IntPtr context);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("XblFunctionContext")]
        public static extern int XblRealTimeActivityAddConnectionStateChangeHandler([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("XblRealTimeActivityConnectionStateChangeHandler *")] XblRealTimeActivityConnectionStateChangeHandler handler, IntPtr context);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblRealTimeActivityRemoveConnectionStateChangeHandler([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("XblFunctionContext")] int token);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("XblFunctionContext")]
        public static extern int XblRealTimeActivityAddResyncHandler([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("XblRealTimeActivityResyncHandler *")] XblRealTimeActivityResyncHandler handler, IntPtr context);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblRealTimeActivityRemoveResyncHandler([NativeTypeName("XblContextHandle")] IntPtr xboxLiveContext, [NativeTypeName("XblFunctionContext")] int token);
    }
}
