using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XGamingRuntime.Interop
{
    internal static partial class XblInterop
    {
        /// <summary>
        /// Get a list of XblAchievement objects.
        /// This memory of the list is freed when the XblAchievementsResultHandle is closed 
        /// with XblAchievementsResultCloseHandle
        /// </summary>
        /// <param name="resultHandle">Achievement result handle.</param>
        /// <param name="achievements">Pointer to an array of XblAchievement objects.</param>
        /// <param name="achievementsCount">The count of objects in the returned array.</param>
        /// <returns>HRESULT return code for this API operation.</returns>
        //STDAPI XblAchievementsResultGetAchievements(
        //    _In_ XblAchievementsResultHandle resultHandle,
        //    _Out_ const XblAchievement** achievements,
        //    _Out_ size_t* achievementsCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblAchievementsResultGetAchievements(
            XblAchievementsResultHandle resultHandle,
            out IntPtr achievements,
            out SizeT achievementsCount);

        /// <summary>
        /// Checks if there are more pages of achievements to retrieve from the service.
        /// </summary>
        /// <param name="resultHandle">Achievement result handle.</param>
        /// <param name="hasNext">Return value. True if there are more results to retrieve, false otherwise.</param>
        /// <returns>HRESULT return code for this API operation.</returns>
        //STDAPI XblAchievementsResultHasNext(
        //    _In_ XblAchievementsResultHandle resultHandle,
        //    _Out_ bool* hasNext
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblAchievementsResultHasNext(
            XblAchievementsResultHandle resultHandle,
            [MarshalAs(UnmanagedType.U1)] out bool hasNext);

        /// <summary>
        /// Gets the result of next page of achievements for a player of the specified title.
        /// To get the result, call XblAchievementsResultGetNextResult inside the AsyncBlock callback
        /// or after the AsyncBlock is complete.
        /// </summary>
        /// <param name="resultHandle">Handle to the achievement result.</param>
        /// <param name="maxItems">The maximum number of items that the result can contain. Pass 0 to attempt
        /// to retrieve all items.</param>
        /// <param name="async">Caller allocated AsyncBlock.</param>
        /// <remarks>
        /// This method calls V2 GET /users/xuid({xuid})/achievements.
        /// </remarks>
        /// <returns>HRESULT return code for this API operation.</returns>
        //STDAPI XblAchievementsResultGetNextAsync(
        //    _In_ XblAchievementsResultHandle resultHandle,
        //    _In_ uint32_t maxItems,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblAchievementsResultGetNextAsync(
            XblAchievementsResultHandle resultHandle,
            UInt32 maxItems,
            XAsyncBlockPtr asyncBlock);

        /// <summary>
        /// Get XblAchievementsResultHandle from an XblAchievementsResultGetNextAsync call.
        /// </summary>
        /// <param name="async">The same AsyncBlock that passed to XblAchievementsResultGetNextAsync.</param>
        /// <param name="result">
        /// Returns the next achievement result handle. Note that this is a separate handle than the one passed to the
        /// XblAchievementsResultGetNextAsync API. Each result handle must be closed separately.
        /// </param>
        /// <returns>HRESULT return code for this API operation.</returns>
        //STDAPI XblAchievementsResultGetNextResult(
        //    _In_ XAsyncBlock* async,
        //    _Out_ XblAchievementsResultHandle* result
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblAchievementsResultGetNextResult(
            XAsyncBlockPtr asyncBlock,
            out XblAchievementsResultHandle resultHandle);

        /// <summary>
        /// Gets the first page of achievements for a player of the specified title.
        /// To get the result, call XblAchievementsGetAchievementsForTitleIdResult inside the AsyncBlock callback
        /// or after the AsyncBlock is complete.
        /// </summary>
        /// <param name="xboxLiveContext">An xbox live context handle created with XblContextCreateHandle.</param>
        /// <param name="xboxUserId">The Xbox User ID of the player.</param>
        /// <param name="titleId">The title ID.</param>
        /// <param name="type">The achievement type to retrieve.</param>
        /// <param name="unlockedOnly">Indicates whether to return unlocked achievements only.</param>
        /// <param name="orderBy">Controls how the list of achievements is ordered.</param>
        /// <param name="skipItems">The number of achievements to skip.</param>
        /// <param name="maxItems">The maximum number of achievements the result can contain.  Pass 0 to attempt
        /// <param name="async">Caller allocated AsyncBlock.</param>
        /// to retrieve all items.</param>
        /// <returns>HRESULT return code for this API operation.</returns>
        /// <remarks>
        /// This method calls V2 GET /users/xuid({xuid})/achievements
        /// </remarks>
        //STDAPI XblAchievementsGetAchievementsForTitleIdAsync(
        //    _In_ XblContextHandle xboxLiveContext,
        //    _In_ uint64_t xboxUserId,
        //    _In_ uint32_t titleId,
        //    _In_ XblAchievementType type,
        //    _In_ bool unlockedOnly,
        //    _In_ XblAchievementOrderBy orderBy,
        //    _In_ uint32_t skipItems,
        //    _In_ uint32_t maxItems,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblAchievementsGetAchievementsForTitleIdAsync(
            XblContextHandle xboxLiveContext,
            UInt64 xboxUserId,
            UInt32 titleId,
            XblAchievementType type,
            [MarshalAs(UnmanagedType.U1)] bool unlockedOnly,
            XblAchievementOrderBy orderBy,
            UInt32 skipItems,
            UInt32 maxItems,
            XAsyncBlockPtr asyncBlock);

        /// <summary>
        /// Get XblAchievementsResultHandle from an XblAchievementsGetAchievementsForTitleIdAsync call.
        /// Use XblAchievementsResultGetAchievements to get the list.
        /// </summary>
        /// <param name="async">The same AsyncBlock that passed to XblAchievementsGetAchievementsForTitleIdAsync.</param>
        /// <param name="result">Achievement result handle.</param>
        /// <returns>HRESULT return code for this API operation.</returns>
        //STDAPI XblAchievementsGetAchievementsForTitleIdResult(
        //    _In_ XAsyncBlock* async,
        //    _Out_ XblAchievementsResultHandle* result
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblAchievementsGetAchievementsForTitleIdResult(
            XAsyncBlockPtr asyncBlock,
            out XblAchievementsResultHandle result);

        /// <summary>
        /// Allow achievement progress to be updated and achievements to be unlocked.
        /// This API will work even when offline on PC and Xbox One. Offline updates will be 
        /// posted by the system when connection is re-established even if the title isn't running.
        /// The result of the asynchronous operation can be obtained by calling XAsyncGetStatus
        /// inside the AsyncBlock callback or after the AsyncBlock is complete
        /// </summary>
        /// <param name="xboxLiveContext">An xbox live context handle created with XblContextCreateHandle.</param>
        /// <param name="xboxUserId">The Xbox User ID of the player.</param>
        /// <param name="achievementId">The UTF-8 encoded achievement ID as defined by XDP or Dev Center.</param>
        /// <param name="percentComplete">The completion percentage of the achievement to indicate progress.
        /// Valid values are from 1 to 100. Set to 100 to unlock the achievement.
        /// Progress will be set by the server to the highest value sent</param>
        /// <param name="async">Caller allocated AsyncBlock.</param>
        /// <returns>HRESULT return code for this API operation.</returns>
        /// <remarks>
        /// This method calls V2 POST /users/xuid({xuid})/achievements/{scid}/update
        /// </remarks>
        //STDAPI XblAchievementsUpdateAchievementAsync(
        //    _In_ XblContextHandle xboxLiveContext,
        //    _In_ uint64_t xboxUserId,
        //    _In_z_ const char* achievementId,
        //    _In_ uint32_t percentComplete,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblAchievementsUpdateAchievementAsync(
            XblContextHandle xboxLiveContext,
            UInt64 xboxUserId,
            Byte[] achievementId,
            UInt32 percentComplete,
            XAsyncBlockPtr asyncBlock);

        /// <summary>
        /// Allow achievement progress to be updated and achievements to be unlocked.
        /// This API will work even when offline on PC and Xbox One. Offline updates will be 
        /// posted by the system when connection is re-established even if the title isn't running.
        /// The result of the asynchronous operation can be obtained by calling XAsyncGetStatus
        /// inside the AsyncBlock callback or after the AsyncBlock is complete
        /// </summary>
        /// <param name="xboxLiveContext">An xbox live context handle created with XblContextCreateHandle.</param>
        /// <param name="xboxUserId">The Xbox User ID of the player.</param>
        /// <param name="titleId">The title ID.</param>
        /// <param name="serviceConfigurationId">The UTF-8 encoded service configuration ID (SCID) for the title.</param>
        /// <param name="achievementId">The UTF-8 encoded achievement ID as defined by XDP or Dev Center.</param>
        /// <param name="percentComplete">The completion percentage of the achievement to indicate progress.
        /// Valid values are from 1 to 100. Set to 100 to unlock the achievement.
        /// Progress will be set by the server to the highest value sent</param>
        /// <param name="async">Caller allocated AsyncBlock.</param>
        /// <returns>HRESULT return code for this API operation.</returns>
        /// <remarks>
        /// This method calls V2 POST /users/xuid({xuid})/achievements/{scid}/update
        /// </remarks>
        //STDAPI XblAchievementsUpdateAchievementForTitleIdAsync(
        //    _In_ XblContextHandle xboxLiveContext,
        //    _In_ uint64_t xboxUserId,
        //    _In_ const uint32_t titleId,
        //    _In_z_ const char* serviceConfigurationId,
        //    _In_z_ const char* achievementId,
        //    _In_ uint32_t percentComplete,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblAchievementsUpdateAchievementForTitleIdAsync(
            XblContextHandle xboxLiveContext,
            UInt64 xboxUserId,
            UInt32 titleId,
            Byte[] serviceConfigurationId,
            Byte[] achievementId,
            UInt32 percentComplete,
            XAsyncBlockPtr asyncBlock);

        /// <summary>
        /// Gets an achievement for a player with a specific achievement ID.
        /// To get the result, call XblAchievementsGetAchievementResult inside the AsyncBlock callback
        /// or after the AsyncBlock is complete.
        /// </summary>
        /// <param name="xboxLiveContext">An xbox live context handle created with XblContextCreateHandle.</param>
        /// <param name="xboxUserId">The Xbox User ID of the player.</param>
        /// <param name="serviceConfigurationId">The UTF-8 encoded service configuration ID (SCID) for the title.</param>
        /// <param name="achievementId">The UTF-8 encoded unique identifier of the Achievement as defined by XDP or Dev Center.</param>
        /// <param name="async">Caller allocated AsyncBlock.</param>
        /// <returns>HRESULT return code for this API operation.</returns>
        /// <remarks>
        /// This method calls V2 GET /users/xuid({xuid})/achievements/{scid}/{achievementId}.
        /// </remarks>
        //STDAPI XblAchievementsGetAchievementAsync(
        //    _In_ XblContextHandle xboxLiveContext,
        //    _In_ uint64_t xboxUserId,
        //    _In_z_ const char* serviceConfigurationId,
        //    _In_z_ const char* achievementId,
        //    _In_ XAsyncBlock* async
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblAchievementsGetAchievementAsync(
            XblContextHandle xboxLiveContext,
            UInt64 xboxUserId,
            Byte[] serviceConfigurationId,
            Byte[] achievementId,
            XAsyncBlockPtr asyncBlock);

        /// <summary>
        /// Get the result handle from an XblAchievementsGetAchievementAsync call.
        /// </summary>
        /// <param name="async">The same AsyncBlock that passed to XblAchievementsGetAchievementAsync.</param>
        /// <param name="result">
        /// The achievement result handle. This handle is used by other APIs to get the achievement objects
        /// and to get the next page of achievements from the service if there is is one. The handle must be closed
        /// using XblAchievementsResultCloseHandle when the result is no longer needed.
        /// </param>
        /// <returns>HRESULT return code for this API operation.</returns>
        //STDAPI XblAchievementsGetAchievementResult(
        //    _In_ XAsyncBlock* async,
        //    _Out_ XblAchievementsResultHandle* result
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblAchievementsGetAchievementResult(
            XAsyncBlockPtr asyncBlock,
            [Out] out XblAchievementsResultHandle result);

        /// <summary>
        /// Duplicates a XblAchievementsResultHandle
        /// </summary>
        /// <param name="handle">The XblAchievementsResultHandle to duplicate.</param>
        /// <param name="duplicatedHandle">The duplicated handle.</param>
        //STDAPI XblAchievementsResultDuplicateHandle(
        //    _In_ XblAchievementsResultHandle handle,
        //    _Out_ XblAchievementsResultHandle* duplicatedHandle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblAchievementsResultDuplicateHandle(
            XblAchievementsResultHandle handle,
            out XblAchievementsResultHandle duplicatedHandle);

        /// <summary>
        /// Closes the XblAchievementsResultHandle.
        /// When all outstanding handles have been closed, the memory associated with the achievement result will be freed.
        /// </summary>
        /// <param name="handle">The XblAchievementsResultHandle to close.</param>
        //STDAPI_(void) XblAchievementsResultCloseHandle(
        //    _In_ XblAchievementsResultHandle handle
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XblAchievementsResultCloseHandle(
            XblAchievementsResultHandle handle);
    }
}
