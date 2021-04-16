using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal partial class XblInterop
    {
        // STDAPI XblLeaderboardGetLeaderboardAsync(
        //     _In_ XblContextHandle xboxLiveContext,
        //     _In_ XblLeaderboardQuery leaderboardQuery,
        //     _In_ XAsyncBlock* async
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblLeaderboardGetLeaderboardAsync(
            XblContextHandle xboxLiveContext,
            XblLeaderboardQuery leaderboardQuery,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XblLeaderboardGetLeaderboardResultSize(
        //     _In_ XAsyncBlock* async,
        //     _Out_ size_t* resultSizeInBytes
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblLeaderboardGetLeaderboardResultSize(
            XAsyncBlockPtr asyncBlockPtr,
            out SizeT resultSizeInBytes);

        // STDAPI XblLeaderboardGetLeaderboardResult(
        //     _In_ XAsyncBlock* async,
        //     _In_ size_t bufferSize,
        //     _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //     _Outptr_ XblLeaderboardResult** ptrToBuffer,
        //     _Out_opt_ size_t* bufferUsed
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblLeaderboardGetLeaderboardResult(
            XAsyncBlockPtr asyncBlock,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr ptrToBuffer,
            out SizeT bufferUsed);

        // STDAPI XblLeaderboardResultGetNextAsync(
        //     _In_ XblContextHandle xboxLiveContext,
        //     _In_ XblLeaderboardResult* leaderboardResult,
        //     _In_ uint32_t maxItems,
        //     _In_ XAsyncBlock* async
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblLeaderboardResultGetNextAsync(
            XblContextHandle xboxLiveContext,
            [In] ref XblLeaderboardResult leaderboardResult,
            UInt32 maxItems,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XblLeaderboardResultGetNextResultSize(
        //     _In_ XAsyncBlock* async,
        //     _Out_ size_t* resultSizeInBytes
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblLeaderboardResultGetNextResultSize(
            XAsyncBlockPtr asyncBlock,
            out SizeT resultSizeInBytes);

        // STDAPI XblLeaderboardResultGetNextResult(
        //     _In_ XAsyncBlock* async,
        //     _In_ size_t bufferSize,
        //     _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //     _Outptr_ XblLeaderboardResult** ptrToBuffer,
        //     _Out_opt_ size_t* bufferUsed
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblLeaderboardResultGetNextResult(
            XAsyncBlockPtr asyncBlock,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr ptrToBuffer,
            out SizeT bufferUsed);
    }
}
