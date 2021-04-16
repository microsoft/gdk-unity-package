using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XblTitleManagedStatsOperationCompleted(Int32 hresult);

    public partial class SDK
    {
        public partial class XBL
        {
            public static void XblTitleManagedStatsUpdateStatsAsync(
                XblContextHandle xblContextHandle,
                XblTitleManagedStatistic[] statistics,
                XblTitleManagedStatsOperationCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG);
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    Int32 hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
                    completionRoutine(hresult);
                });

                using (var disposableCollection = new DisposableCollection())
                {
                    var interopStatistics = Array.ConvertAll(statistics, s =>new Interop.XblTitleManagedStatistic(s, disposableCollection));
                    Int32 hr = XblInterop.XblTitleManagedStatsUpdateStatsAsync(
                        xblContextHandle.InteropHandle,
                        interopStatistics,
                        new SizeT(interopStatistics.Length),
                        asyncBlock);

                    if (HR.FAILED(hr))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hr);
                    }
                }
            }

            public static void XblTitleManagedStatsDeleteStatsAsync(
                XblContextHandle xblContextHandle,
                string[] statisticNames,
                XblTitleManagedStatsOperationCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG);
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    Int32 hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
                    completionRoutine(hresult);
                });

                using (var disposableCollection = new DisposableCollection())
                {
                    SizeT interopStatisticsCount;
                    var interopStatistics = Interop.Converters.StringArrayToUTF8StringArray(statisticNames, disposableCollection, out interopStatisticsCount);
                    Int32 hr = XblInterop.XblTitleManagedStatsDeleteStatsAsync(
                        xblContextHandle.InteropHandle,
                        interopStatistics,
                        interopStatisticsCount,
                        asyncBlock);

                    if (HR.FAILED(hr))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hr);
                    }
                }
            }

            public static void XblTitleManagedStatsWriteAsync(
                XblContextHandle xblContextHandle,
                UInt64 xboxUserId,
                XblTitleManagedStatistic[] statistics,
                XblTitleManagedStatsOperationCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG);
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    Int32 hresult = XGRInterop.XAsyncGetStatus(block, wait: false);
                    completionRoutine(hresult);
                });

                using (var disposableCollection = new DisposableCollection())
                {
                    var interopStatistics = Array.ConvertAll(statistics, s =>new Interop.XblTitleManagedStatistic(s, disposableCollection));
                    Int32 hr = XblInterop.XblTitleManagedStatsWriteAsync(
                        xblContextHandle.InteropHandle,
                        xboxUserId,
                        interopStatistics,
                        new SizeT(interopStatistics.Length),
                        asyncBlock);

                    if (HR.FAILED(hr))
                    {
                        AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        completionRoutine(hr);
                    }
                }
            }
        }
    }
}