using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal partial class XblInterop
    {
        //STDAPI XblMultiplayerGetActivitiesForSocialGroupResultCount(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* activityCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerGetActivitiesForSocialGroupResultCount(
            XAsyncBlockPtr async,
            out SizeT activityCount);

        //STDAPI XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_ const char* scid,
        //    _In_reads_(xuidsCount) const uint64_t* xuids,
        //    _In_ size_t xuidsCount,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(
            XblContextHandle xblContext,
            Byte[] scid,
            [In] UInt64[] xuids,
            SizeT xuidsCount,
            XAsyncBlockPtr async);

        //STDAPI XblMultiplayerGetActivitiesForSocialGroupResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ size_t activityCount,
        //    _Out_writes_(activityCount) XblMultiplayerActivityDetails* activities
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerGetActivitiesForSocialGroupResult(
            XAsyncBlockPtr async,
            SizeT activityCount,
            [Out] XblMultiplayerActivityDetails[] activities);

        //STDAPI XblMultiplayerGetActivitiesForUsersAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_ const char* scid,
        //    _In_reads_(xuidsCount) const uint64_t* xuids,
        //    _In_ size_t xuidsCount,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        /// <summary>
        /// Deprecated
        /// </summary>
        /// <param name="xblContext"></param>
        /// <param name="scid"></param>
        /// <param name="xuids"></param>
        /// <param name="xuidsCount"></param>
        /// <param name="async"></param>
        /// <returns></returns>
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerGetActivitiesForUsersAsync(
            XblContextHandle xblContext,
            Byte[] scid,
            [In] UInt64[] xuids,
            SizeT xuidsCount,
            XAsyncBlockPtr async);

        //STDAPI XblMultiplayerGetActivitiesForUsersResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ size_t activityCount,
        //    _Out_writes_(activityCount) XblMultiplayerActivityDetails* activities
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerGetActivitiesForUsersResult(
            XAsyncBlockPtr async,
            SizeT activityCount,
            [Out] XblMultiplayerActivityDetails[] activities);

        //STDAPI XblMultiplayerGetActivitiesWithPropertiesForUsersResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ size_t bufferSize,
        //    _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //    _Outptr_ XblMultiplayerActivityDetails** ptrToBuffer,
        //    _Out_ size_t* ptrToBufferCount,
        //    _Out_opt_ size_t* bufferUsed
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern Int32 XblMultiplayerGetActivitiesWithPropertiesForUsersResult(
            XAsyncBlockPtr async,
            SizeT bufferSize,
            IntPtr buffer,
            out XblMultiplayerActivityDetails* ptrToBuffer,
            out SizeT ptrToBufferCount,
            out SizeT bufferUsed);

        //STDAPI XblMultiplayerGetActivitiesForSocialGroupAsync(
        //    _In_ XblContextHandle xboxLiveContext,
        //    _In_ const char* scid,
        //    _In_ uint64_t socialGroupOwnerXuid,
        //    _In_ const char* socialGroup,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        /// <summary>
        /// Deprecated
        /// </summary>
        /// <param name="xboxLiveContext"></param>
        /// <param name="scid"></param>
        /// <param name="socialGroupOwnerXuid"></param>
        /// <param name="socialGroup"></param>
        /// <param name="async"></param>
        /// <returns></returns>
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerGetActivitiesForSocialGroupAsync(
            XblContextHandle xboxLiveContext,
            Byte[] scid,
            UInt64 socialGroupOwnerXuid,
            Byte[] socialGroup,
            XAsyncBlockPtr async);

        //STDAPI XblMultiplayerGetActivitiesWithPropertiesForUsersResultSize(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* resultSizeInBytes
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerGetActivitiesWithPropertiesForUsersResultSize(
            XAsyncBlockPtr async,
            out SizeT resultSizeInBytes);

        //STDAPI XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResult(
        //    _In_ XAsyncBlock* async,
        //    _In_ size_t bufferSize,
        //    _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //    _Outptr_ XblMultiplayerActivityDetails** ptrToBuffer,
        //    _Out_ size_t* ptrToBufferCount,
        //    _Out_opt_ size_t* bufferUsed
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern Int32 XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResult(
            XAsyncBlockPtr async,
            SizeT bufferSize,
            IntPtr buffer,
            out XblMultiplayerActivityDetails* ptrToBuffer,
            out SizeT ptrToBufferCount,
            out SizeT bufferUsed);

        //STDAPI XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResultSize(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* resultSizeInBytes
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResultSize(
            XAsyncBlockPtr async,
            out SizeT resultSizeInBytes);

        //STDAPI XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(
        //    _In_ XblContextHandle xblContext,
        //    _In_ const char* scid,
        //    _In_ uint64_t socialGroupOwnerXuid,
        //    _In_ const char* socialGroup,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(
            XblContextHandle xblContext,
            Byte[] scid,
            UInt64 socialGroupOwnerXuid,
            Byte[] socialGroup,
            XAsyncBlockPtr async);

        //STDAPI XblMultiplayerGetActivitiesForUsersResultCount(
        //    _In_ XAsyncBlock* async,
        //    _Out_ size_t* activityCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerGetActivitiesForUsersResultCount(
            XAsyncBlockPtr async,
            out SizeT activityCount);
    }
}