using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal partial class XblInterop
    {
        //STDAPI XblStringVerifyStringAsync(
        //    _In_ XblContextHandle xboxLiveContext,
        //    _In_ const char* stringToVerify,
        //    _In_ XAsyncBlock* asyncBlock
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblStringVerifyStringAsync(
            XblContextHandle xblContextHandle,
            Byte[] stringToVerify,
            XAsyncBlockPtr async);

        //STDAPI XblStringVerifyStringResultSize(
        //    _In_ XAsyncBlock* asyncBlock,
        //    _Out_ size_t* resultSizeInBytes
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblStringVerifyStringResultSize(
            XAsyncBlockPtr async,
            out SizeT resultSizeInBytes);


        //STDAPI XblStringVerifyStringResult(
        //    _In_ XAsyncBlock* asyncBlock,
        //    _In_ size_t bufferSize,
        //    _Out_writes_bytes_to_(bufferSize, * bufferUsed) void* buffer,
        //    _Outptr_ XblVerifyStringResult** ptrToBuffer,
        //    _Out_opt_ size_t* bufferUsed
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblStringVerifyStringResult(
            XAsyncBlockPtr async,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr ptrToBuffer,
            out SizeT bufferUsed);


        //STDAPI XblStringVerifyStringsAsync(
        //    _In_ XblContextHandle xboxLiveContext,
        //    _In_ const char** stringsToVerify,
        //    _In_ const uint64_t stringsCount,
        //    _In_ XAsyncBlock* asyncBlock
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblStringVerifyStringsAsync(
            XblContextHandle xblContextHandle,
            IntPtr stringsToVerify,
            UInt64 stringsCount,
            XAsyncBlockPtr async);

        //STDAPI XblStringVerifyStringsResultSize(
        //    _In_ XAsyncBlock* asyncBlock,
        //    _Out_ size_t* resultSizeInBytes
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblStringVerifyStringsResultSize(
            XAsyncBlockPtr async,
            out SizeT resultSizeInBytes);

        //STDAPI XblStringVerifyStringsResult(
        //    _In_ XAsyncBlock* asyncBlock,
        //    _In_ size_t bufferSize,
        //    _Out_writes_bytes_to_(bufferSize, * bufferUsed) void* buffer,
        //    _Outptr_ XblVerifyStringResult** ptrToBufferStrings,
        //    _Out_ size_t* stringsCount,
        //    _Out_opt_ size_t* bufferUsed
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblStringVerifyStringsResult(
            XAsyncBlockPtr async,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr ptrToBufferStrings,
            out SizeT stringsCount,
            out SizeT bufferUsed); //XblPrivacyCheckPermissionResult
    }
}
