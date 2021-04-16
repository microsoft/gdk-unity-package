using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal partial class XblInterop
    {
        // STDAPI XblUserStatisticsGetSingleUserStatisticAsync(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_z_ uint64_t xboxUserId,
        //     _In_z_ const char* serviceConfigurationId,
        //     _In_z_ const char* statisticName,
        //     _In_ XAsyncBlock* async
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetSingleUserStatisticAsync(
            XblContextHandle xblContextHandle,
            UInt64 xboxUserId,
            byte[] serviceConfigurationId,
            byte[] statisticName,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XblUserStatisticsGetSingleUserStatisticResultSize(
        //     _In_ XAsyncBlock* async,
        //     _Out_ size_t* resultSizeInBytes
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetSingleUserStatisticResultSize(
            XAsyncBlockPtr asyncBlock,
            out SizeT resultSizeInBytes);

        // STDAPI XblUserStatisticsGetSingleUserStatisticResult(
        //     _In_ XAsyncBlock* async,
        //     _In_ size_t bufferSize,
        //     _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //     _Outptr_ XblUserStatisticsResult** ptrToBuffer,
        //     _Out_opt_ size_t* bufferUsed
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetSingleUserStatisticResult(
            XAsyncBlockPtr asyncBlock,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr ptrToBuffer,
            out SizeT bufferUsed);

        // STDAPI XblUserStatisticsGetSingleUserStatisticsAsync(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ uint64_t xboxUserId,
        //     _In_z_ const char* serviceConfigurationId,
        //     _In_ const char** statisticNames,
        //     _In_ size_t statisticNamesCount,
        //     _In_ XAsyncBlock* async
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetSingleUserStatisticsAsync(
            XblContextHandle xblContextHandle,
            UInt64 xboxUserId,
            byte[] serviceConfigurationId,
            IntPtr statisticNames,
            SizeT statisticNamesCount,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XblUserStatisticsGetSingleUserStatisticsResultSize(
        //     _In_ XAsyncBlock* async,
        //     _Out_ size_t* resultSizeInBytes
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetSingleUserStatisticsResultSize(
            XAsyncBlockPtr asyncBlock,
            out SizeT resultSizeInBytes);

        // STDAPI XblUserStatisticsGetSingleUserStatisticsResult(
        //     _In_ XAsyncBlock* async,
        //     _In_ size_t bufferSize,
        //     _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //     _Outptr_ XblUserStatisticsResult** ptrToBuffer,
        //     _Out_opt_ size_t* bufferUsed
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetSingleUserStatisticsResult(
            XAsyncBlockPtr asyncBlock,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr ptrToBuffer,
            out SizeT bufferUsed);

        // STDAPI XblUserStatisticsGetMultipleUserStatisticsAsync(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ uint64_t* xboxUserIds,
        //     _In_ size_t xboxUserIdsCount,
        //     _In_z_ const char* serviceConfigurationId,
        //     _In_ const char** statisticNames,
        //     _In_ size_t statisticNamesCount,
        //     _In_ XAsyncBlock* async
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetMultipleUserStatisticsAsync(
            XblContextHandle xblContextHandle,
            UInt64[] xboxUserIds,
            SizeT xboxUserIdsCount,
            byte[] serviceConfigurationId,
            IntPtr statisticNames,
            SizeT statisticNamesCount,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XblUserStatisticsGetMultipleUserStatisticsResultSize(
        //     _In_ XAsyncBlock* async,
        //     _Out_ size_t* resultSizeInBytes
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetMultipleUserStatisticsResultSize(
            XAsyncBlockPtr asyncBlock,
            out SizeT resultSizeInBytes);

        // STDAPI XblUserStatisticsGetMultipleUserStatisticsResult(
        //     _In_ XAsyncBlock* async,
        //     _In_ size_t bufferSize,
        //     _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //     _Outptr_ XblUserStatisticsResult** ptrToBuffer,
        //     _Out_ size_t* resultsCount,
        //     _Out_opt_ size_t* bufferUsed
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetMultipleUserStatisticsResult(
            XAsyncBlockPtr asyncBlock,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr ptrToBuffer,
            out SizeT resultsCount,
            out SizeT bufferUsed);

        // STDAPI XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(
        //     _In_ XblContextHandle xblContextHandle,
        //     _In_ uint64_t* xboxUserIds,
        //     _In_ uint32_t xboxUserIdsCount,
        //     _In_ const XblRequestedStatistics* requestedServiceConfigurationStatisticsCollection,
        //     _In_ uint32_t requestedServiceConfigurationStatisticsCollectionCount,
        //     _In_ XAsyncBlock* async
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(
            XblContextHandle xblContextHandle,
            UInt64[] xboxUserIds,
            UInt32 xboxUserIdsCount,
            IntPtr requestedServiceConfigurationStatisticsCollection,
            UInt32 requestedServiceConfigurationStatisticsCollectionCount,
            XAsyncBlockPtr asyncBlock);

        // STDAPI XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResultSize(
        //     _In_ XAsyncBlock* async,
        //     _Out_ size_t* resultSizeInBytes
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResultSize(
            XAsyncBlockPtr asyncBlock,
            out SizeT resultSizeInBytes);

        // STDAPI XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResult(
        //     _In_ XAsyncBlock* async,
        //     _In_ size_t bufferSize,
        //     _Out_writes_bytes_to_(bufferSize, *bufferUsed) void* buffer,
        //     _Outptr_ XblUserStatisticsResult** results,
        //     _Out_ size_t* resultsCount,
        //     _Out_opt_ size_t* bufferUsed
        // ) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResult(
            XAsyncBlockPtr asyncBlock,
            SizeT bufferSize,
            IntPtr buffer,
            out IntPtr results,
            out SizeT resultsCount,
            out SizeT bufferUsed);
    }
}
