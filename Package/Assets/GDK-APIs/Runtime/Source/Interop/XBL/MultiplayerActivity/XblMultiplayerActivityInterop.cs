using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{

    internal partial class XblInterop
    {
        //STDAPI XblMultiplayerActivityGetActivityAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_reads_(xuidsCount) const uint64_t* xuids,
        //    _In_ size_t xuidsCount,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerActivityGetActivityAsync(
            XblContextHandle xblContext,
            [In] UInt64[] xuids,
            SizeT xuidsCount,
            XAsyncBlockPtr async);

        //STDAPI XblMultiplayerActivityFlushRecentPlayersAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerActivityFlushRecentPlayersAsync(
            XblContextHandle xblContext,
            XAsyncBlockPtr async);

        //STDAPI XblMultiplayerActivitySendInvitesAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_ const uint64_t* xuids,
        //    _In_ size_t xuidsCount,
        //    _In_ bool allowCrossPlatformJoin,
        //    _In_opt_z_ const char* connectionString,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerActivitySendInvitesAsync(
            XblContextHandle xblContext,
            [In] UInt64[] xuids,
            SizeT xuidsCount,
            NativeBool allowCrossPlatformJoin,
            Byte[] connectionString,
            XAsyncBlockPtr async);

        //STDAPI XblMultiplayerActivityDeleteActivityAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerActivityDeleteActivityAsync(
            XblContextHandle xblContext,
            XAsyncBlockPtr async);

        //STDAPI XblMultiplayerActivitySetActivityAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_ const XblMultiplayerActivityInfo* activityInfo,
        //    _In_ bool allowCrossPlatformJoin,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerActivitySetActivityAsync(
            XblContextHandle xblContext,
            XblMultiplayerActivityInfo activityInfo,
            NativeBool allowCrossPlatformJoin,
            XAsyncBlockPtr async);

        //STDAPI XblMultiplayerActivityGetActivityResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ size_t bufferSize,
        //    _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //    _Outptr_ XblMultiplayerActivityInfo** ptrToBufferResults,
        //    _Out_ size_t* resultCount,
        //    _Out_opt_ size_t* bufferUsed
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern Int32 XblMultiplayerActivityGetActivityResult(
            XAsyncBlockPtr async,
            SizeT bufferSize,
            IntPtr buffer,
            out XblMultiplayerActivityInfo* ptrToBufferResults,
            out SizeT resultCount,
            out SizeT bufferUsed);

        //STDAPI XblMultiplayerActivityGetActivityResultSize(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* resultSizeInBytes
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerActivityGetActivityResultSize(
            XAsyncBlockPtr async,
            out SizeT resultSizeInBytes);

        //STDAPI XblMultiplayerActivityUpdateRecentPlayers(
        //    _In_ XblContextHandle xblContext,
        //    _In_reads_(updatesCount) const XblMultiplayerActivityRecentPlayerUpdate* updates,
        //    _In_ size_t updatesCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerActivityUpdateRecentPlayers(
            XblContextHandle xblContext,
            [In] XblMultiplayerActivityRecentPlayerUpdate[] recentPlayerUpdates,
            SizeT recentPlayerUpdatesCount);
    }
}