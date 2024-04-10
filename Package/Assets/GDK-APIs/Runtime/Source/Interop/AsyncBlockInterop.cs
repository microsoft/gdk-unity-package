using System;
using System.Runtime.InteropServices;
using System.Text;

namespace XGamingRuntime.Interop
{
    //typedef void CALLBACK XAsyncCompletionRoutine(_Inout_ struct XAsyncBlock* asyncBlock);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate void XAsyncCompletionRoutineInterop(IntPtr asyncBlock);

    // typedef HRESULT CALLBACK XAsyncWork(_Inout_ struct XAsyncBlock* asyncBlock);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate Int32 XAsyncWorkInterop(IntPtr asyncBlock);

    partial class XGRInterop
    {
        // STDAPI XAsyncGetStatus(
        //     _Inout_ XAsyncBlock* asyncBlock,
        //     _In_ bool wait) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XAsyncGetStatus(IntPtr asyncBlock, [MarshalAs(UnmanagedType.I1)] bool wait);

        // STDAPI XAsyncGetResultSize(
        //     _Inout_ XAsyncBlock* asyncBlock,
        //     _Out_ size_t* bufferSize) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XAsyncGetResultSize(IntPtr asyncBlock, out UInt64 bufferSize);


        // STDAPI_(void) XAsyncCancel(_Inout_ XAsyncBlock* asyncBlock) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XAsyncCancel(IntPtr asyncBlock);


        // STDAPI XAsyncRun(
        //     _Inout_ XAsyncBlock* asyncBlock,
        //     _In_ XAsyncWork* work) noexcept;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XAsyncRun(IntPtr asyncBlock, XAsyncWorkInterop work);

    }
}
