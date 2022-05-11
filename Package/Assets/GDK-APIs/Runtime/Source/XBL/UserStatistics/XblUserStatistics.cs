using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XblUserStatisticsGetSingleUserStatisticCompleted(Int32 hresult, XblUserStatisticsResult result);
    public delegate void XblUserStatisticsGetSingleUserStatisticsCompleted(Int32 hresult, XblUserStatisticsResult result);
    public delegate void XblUserStatisticsGetMultipleUserStatisticsCompleted(Int32 hresult, XblUserStatisticsResult[] results);
    public delegate void XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsCompleted(Int32 hresult, XblUserStatisticsResult[] results);
    
    public struct XblStatisticChangeEventArgs
    {
        public ulong xboxUserId;
        public string serviceConfigurationId;
        public XblStatistic latestStatistic;
    }
    public delegate void XblStatisticChangedCallback(XblStatisticChangeEventArgs statisticChangeEventArgs);

    public partial class SDK
    {
        public partial class XBL
        {
            public static void XblUserStatisticsGetSingleUserStatisticAsync(
                XblContextHandle xblContextHandle,
                UInt64 xboxUserId,
                string serviceConfigurationId,
                string statisticName,
                XblUserStatisticsGetSingleUserStatisticCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblUserStatisticsResult));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblUserStatisticsGetSingleUserStatisticResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblUserStatisticsResult));
                        return;
                    }

                    using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                    {
                        IntPtr ptrToBuffer;
                        SizeT bufferUsed;
                        hr = XblInterop.XblUserStatisticsGetSingleUserStatisticResult(
                            block,
                            resultSizeInBytes,
                            buffer.IntPtr,
                            out ptrToBuffer,
                            out bufferUsed);

                        if (HR.FAILED(hr))
                        {
                            completionRoutine(hr, default(XblUserStatisticsResult));
                            return;
                        }

                        XblUserStatisticsResult result = Converters.PtrToClass<XblUserStatisticsResult, Interop.XblUserStatisticsResultInternal>(ptrToBuffer, r =>new XblUserStatisticsResult(r));
                        completionRoutine(hr, result);
                    }
                });

                Int32 hresult = XblInterop.XblUserStatisticsGetSingleUserStatisticAsync(
                    xblContextHandle.InteropHandle,
                    xboxUserId,
                    Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId),
                    Converters.StringToNullTerminatedUTF8ByteArray(statisticName),
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    completionRoutine(hresult, default(XblUserStatisticsResult));
                }
            }

            public static void XblUserStatisticsGetSingleUserStatisticsAsync(
                XblContextHandle xblContextHandle,
                UInt64 xboxUserId,
                string serviceConfigurationId,
                string[] statisticNames,
                XblUserStatisticsGetSingleUserStatisticsCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblUserStatisticsResult));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblUserStatisticsGetSingleUserStatisticsResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblUserStatisticsResult));
                        return;
                    }

                    using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                    {
                        IntPtr ptrToBuffer;
                        SizeT bufferUsed;
                        hr = XblInterop.XblUserStatisticsGetSingleUserStatisticsResult(
                            block,
                            resultSizeInBytes,
                            buffer.IntPtr,
                            out ptrToBuffer,
                            out bufferUsed);

                        if (HR.FAILED(hr))
                        {
                            completionRoutine(hr, default(XblUserStatisticsResult));
                            return;
                        }

                        XblUserStatisticsResult result = Converters.PtrToClass<XblUserStatisticsResult, Interop.XblUserStatisticsResultInternal>(ptrToBuffer, r =>new XblUserStatisticsResult(r));
                        completionRoutine(hr, result);
                    }
                });

                using (DisposableBuffer statisticNamesBuffer = Converters.StringArrayToUTF8StringArray(statisticNames))
                {
                    Int32 hresult = XblInterop.XblUserStatisticsGetSingleUserStatisticsAsync(
                        xblContextHandle.InteropHandle,
                        xboxUserId,
                        Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId),
                        statisticNamesBuffer.IntPtr,
                        new SizeT(statisticNames.Length),
                        asyncBlock);

                    if (HR.FAILED(hresult))
                    {
                        completionRoutine(hresult, default(XblUserStatisticsResult));
                    }
                }
            }

            public static void XblUserStatisticsGetMultipleUserStatisticsAsync(
                XblContextHandle xblContextHandle,
                UInt64[] xboxUserIds,
                string serviceConfigurationId,
                string[] statisticNames,
                XblUserStatisticsGetMultipleUserStatisticsCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblUserStatisticsResult[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblUserStatisticsGetMultipleUserStatisticsResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblUserStatisticsResult[]));
                        return;
                    }

                    using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                    {
                        IntPtr ptrToBuffer;
                        SizeT resultsCount, bufferUsed;
                        hr = XblInterop.XblUserStatisticsGetMultipleUserStatisticsResult(
                            block,
                            resultSizeInBytes,
                            buffer.IntPtr,
                            out ptrToBuffer,
                            out resultsCount,
                            out bufferUsed);

                        if (HR.FAILED(hr))
                        {
                            completionRoutine(hr, default(XblUserStatisticsResult[]));
                            return;
                        }

                        XblUserStatisticsResult[] result = Converters.PtrToClassArray(ptrToBuffer, resultsCount, (Interop.XblUserStatisticsResultInternal r) =>new XblUserStatisticsResult(r));
                        completionRoutine(hr, result);
                    }
                });

                using (DisposableBuffer statisticNamesBuffer = Converters.StringArrayToUTF8StringArray(statisticNames))
                {
                    Int32 hresult = XblInterop.XblUserStatisticsGetMultipleUserStatisticsAsync(
                        xblContextHandle.InteropHandle,
                        xboxUserIds,
                        new SizeT(xboxUserIds.Length),
                        Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId),
                        statisticNamesBuffer.IntPtr,
                        new SizeT(statisticNames.Length),
                        asyncBlock);

                    if (HR.FAILED(hresult))
                    {
                        completionRoutine(hresult, default(XblUserStatisticsResult[]));
                    }
                }
            }

            public static void XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(
                XblContextHandle xblContextHandle,
                UInt64[] xboxUserIds,
                XblRequestedStatistics[] requestedServiceConfigurationStatisticsCollection,
                XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsCompleted completionRoutine)
            {
                if (xblContextHandle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblUserStatisticsResult[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblUserStatisticsResult[]));
                        return;
                    }

                    using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                    {
                        IntPtr results;
                        SizeT resultsCount, bufferUsed;
                        hr = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResult(
                            block,
                            resultSizeInBytes,
                            buffer.IntPtr,
                            out results,
                            out resultsCount,
                            out bufferUsed);

                        if (HR.FAILED(hr))
                        {
                            completionRoutine(hr, default(XblUserStatisticsResult[]));
                            return;
                        }

                        XblUserStatisticsResult[] result = Converters.PtrToClassArray(results, resultsCount, (Interop.XblUserStatisticsResultInternal r) =>new XblUserStatisticsResult(r));
                        completionRoutine(hr, result);
                    }
                });

                using (DisposableCollection disposableCollection = new DisposableCollection())
                {
                    SizeT requestedStatisticsCount;
                    IntPtr interopRequestedStatistics = Converters.ClassArrayToPtr(
                        requestedServiceConfigurationStatisticsCollection,
                        (request, disposables) =>new Interop.XblRequestedStatisticsInternal(request, disposables),
                        disposableCollection,
                        out requestedStatisticsCount);

                    Int32 hresult = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(
                        xblContextHandle.InteropHandle,
                        xboxUserIds,
                        Convert.ToUInt32(xboxUserIds.Length),
                        interopRequestedStatistics,
                        requestedStatisticsCount.ToUInt32(),
                        asyncBlock);

                    if (HR.FAILED(hresult))
                    {
                        completionRoutine(hresult, default(XblUserStatisticsResult[]));
                    }
                }
            }

            public static int XblUserStatisticsAddStatisticChangedHandler(
                XblContextHandle xblContextHandle,
                XblStatisticChangedCallback eventCallback)
            {
                int callbackFunctionId;

                unsafe
                {
                    var context = _userStatisticsChangeCallbackManager.GetUniqueContext();
                    callbackFunctionId = UserStatistics.XblUserStatisticsAddStatisticChangedHandler(
                        xblContextHandle.InteropHandle.handle,
                        UserStatisticsChangeCallbackManager.InteropPInvokeCallback,
                        context.ToPointer());

                    if (callbackFunctionId != 0)
                    {
                        _userStatisticsChangeCallbackManager.AddCallbackForId(
                            callbackFunctionId, context, eventCallback);
                    }
                }

                return callbackFunctionId;
            }

            public static void XblUserStatisticsRemoveStatisticChangedHandler(
                XblContextHandle xblContextHandle,
                int callbackFunctionId)
            {
                unsafe
                {
                    UserStatistics.XblUserStatisticsRemoveStatisticChangedHandler(
                        xblContextHandle.InteropHandle.handle,
                        callbackFunctionId);

                    _userStatisticsChangeCallbackManager.RemoveCallbackForId(
                        callbackFunctionId);
                }
            }

            public static void XblUserStatisticsTrackStatistics(
                XblContextHandle xblContextHandle,
                ulong[] xuids,
                string serviceConfigurationId,
                string[] statisticNames)
            {
                unsafe
                {
                    var scidLen = Converters.GetSizeRequiredToEncodeStringToUTF8(serviceConfigurationId);
                    sbyte[] scidAsBytes = new sbyte[scidLen];

                    fixed (ulong* xuidsPtr = &xuids[0])
                    fixed (sbyte* scidPtr = &scidAsBytes[0])
                    {
                        using (DisposableBuffer statisticNamesBuffer = Converters.StringArrayToUTF8StringArray(statisticNames))
                        {
                            Converters.StringToNullTerminatedUTF8FixedPointer(serviceConfigurationId, (byte*)scidPtr, serviceConfigurationId.Length);


                            UserStatistics.XblUserStatisticsTrackStatistics(xblContextHandle.InteropHandle.handle,
                                                                            xuidsPtr,
                                                                            new UIntPtr((uint)xuids.Length),
                                                                            scidPtr,
                                                                            (sbyte**)statisticNamesBuffer.IntPtr,
                                                                            new UIntPtr((uint)statisticNames.Length));
                        }
                    }
                }
            }

            public static void XblUserStatisticsStopTrackingStatistics(
                XblContextHandle xblContextHandle,
                ulong[] xuids,
                string serviceConfigurationId,
                string[] statisticNames)
            {
                unsafe
                {
                    var scidLen = Converters.GetSizeRequiredToEncodeStringToUTF8(serviceConfigurationId);
                    sbyte[] scidAsBytes = new sbyte[scidLen];

                    fixed (ulong* xuidsPtr = &xuids[0])
                    fixed (sbyte* scidPtr = &scidAsBytes[0])
                    {
                        using (DisposableBuffer statisticNamesBuffer = Converters.StringArrayToUTF8StringArray(statisticNames))
                        {
                            Converters.StringToNullTerminatedUTF8FixedPointer(serviceConfigurationId, (byte*)scidPtr, serviceConfigurationId.Length);

                            UserStatistics.XblUserStatisticsStopTrackingStatistics(xblContextHandle.InteropHandle.handle,
                                                                                   xuidsPtr,
                                                                                   new UIntPtr((uint)xuids.Length),
                                                                                   scidPtr,
                                                                                   (sbyte**)statisticNamesBuffer.IntPtr,
                                                                                   new UIntPtr((uint)statisticNames.Length));
                        }
                    }
                }
            }

            public static void XblUserStatisticsStopTrackingUsers(
                XblContextHandle xblContextHandle,
                ulong[] xuids)
            {
                unsafe
                {
                    fixed (ulong* xuidsPtr = &xuids[0])
                    {
                        UserStatistics.XblUserStatisticsStopTrackingUsers(xblContextHandle.InteropHandle.handle, xuidsPtr, new UIntPtr((uint)xuids.Length));
                    }
                }
            }

            private static UserStatisticsChangeCallbackManager _userStatisticsChangeCallbackManager =
                new UserStatisticsChangeCallbackManager();

            private class UserStatisticsChangeCallbackManager :
                InteropCallbackManager<XblStatisticChangedCallback>
            {
                [MonoPInvokeCallback]
                internal static unsafe void InteropPInvokeCallback(
                    Interop.XblStatisticChangeEventArgs eventArgs,
                    void* context)
                {
                    if (!_userStatisticsChangeCallbackManager._contextToFunctionId.ContainsKey(new IntPtr(context)))
                    {
                        return;
                    }

                    var functionId = _userStatisticsChangeCallbackManager._contextToFunctionId[new IntPtr(context)];
                    _userStatisticsChangeCallbackManager.IssueEventCallback(functionId, eventArgs);
                }

                private unsafe void IssueEventCallback(
                    int functionId,
                    Interop.XblStatisticChangeEventArgs eventArgs)
                {
                    if (!_functionIdToHandler.ContainsKey(functionId))
                    {
                        return;
                    }

                    var eventHandler = _functionIdToHandler[functionId];

                    var callbackEventArgs = new XblStatisticChangeEventArgs
                    {
                        latestStatistic = new XblStatistic(eventArgs.latestStatistic),
                        serviceConfigurationId = Converters.NullTerminatedBytePointerToString((byte*)eventArgs.serviceConfigurationId),
                        xboxUserId = eventArgs.xboxUserId
                    };

                    if (eventHandler.Callback != null)
                    {
                        eventHandler.Callback.Invoke(callbackEventArgs);
                    }
                }
            }
        }
    }
}
