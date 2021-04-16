using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    partial class XGRInterop
    {
        const string ThunkDllName = "XGamingRuntimeThunks";

        //STDAPI XGameRuntimeInitialize();
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XGameRuntimeInitialize();

        //STDAPI_(void) XGameRuntimeUninitialize();
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XGameRuntimeUninitialize();

        //STDAPI XTaskQueueCreate(
        //    _In_ XTaskQueueDispatchMode workDispatchMode,
        //    _In_ XTaskQueueDispatchMode completionDispatchMode,
        //    _Out_ XTaskQueueHandle* queue
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XTaskQueueCreate(
            XTaskQueueDispatchMode workDispatchMode,
            XTaskQueueDispatchMode completionDispatchMode,
            out XTaskQueueHandle queue
        );

        //STDAPI_(void) XTaskQueueCloseHandle(
        //    _In_ XTaskQueueHandle queue
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XTaskQueueCloseHandle(XTaskQueueHandle queue);

        //STDAPI_(bool) XTaskQueueDispatch(
        //    _In_ XTaskQueueHandle queue,
        //    _In_ XTaskQueuePort port,
        //    _In_ uint32_t timeoutInMs
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XTaskQueueDispatch(XTaskQueueHandle queue, XTaskQueuePort port, UInt32 timeoutInMs);

        //STDAPI XAsyncGetStatus(
        //    _Inout_ XAsyncBlock* asyncBlock,
        //    _In_ bool wait
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XAsyncGetStatus(XAsyncBlockPtr asyncBlock, [MarshalAs(UnmanagedType.U1)] bool wait);

        //STDAPI XAsyncGetResultSize(
        //    _Inout_ XAsyncBlock* asyncBlock,
        //    _Out_ size_t* bufferSize
        //    ) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 XAsyncGetResultSize(XAsyncBlockPtr asyncBlock, out SizeT bufferSize);
    }
}
