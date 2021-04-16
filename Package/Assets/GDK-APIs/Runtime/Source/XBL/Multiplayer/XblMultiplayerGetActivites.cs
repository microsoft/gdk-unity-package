using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public delegate void XblMultiplayerGetActivitiesWithPropertiesResult(Int32 hresult, XblMultiplayerActivityDetails[] result);

            public static void XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(
                XblContextHandle xboxLiveContext,
                string scid,
                UInt64[] xuids,
                XblMultiplayerGetActivitiesWithPropertiesResult completionRoutine
                )
            {

                if (xboxLiveContext == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblMultiplayerActivityDetails[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblMultiplayerActivityDetails[]));
                        return;
                    }

                    // As of 2102, there is a bug in XblMultiplayerActivityGetActivityResult that will crash when 
                    // there are no items. Added this workaround since we support some versions of the GDK with 
                    // this bug. Remove this workaround when we stop supporting 2102 and lower.
                    if (resultSizeInBytes.IsZero)
                    {
                        completionRoutine(HR.S_OK, new XblMultiplayerActivityDetails[0]);
                        return;
                    }

                    unsafe
                    {
                        using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                        {
                            Interop.XblMultiplayerActivityDetails* ptrToBufferResults;
                            SizeT resultCount, bufferUsed;
                            hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersResult(
                                block,
                                resultSizeInBytes,
                                buffer.IntPtr,
                                out ptrToBufferResults,
                                out resultCount,
                                out bufferUsed);

                            if (HR.FAILED(hr))
                            {
                                completionRoutine(hr, default(XblMultiplayerActivityDetails[]));
                                return;
                            }

                            System.Collections.Generic.List<XblMultiplayerActivityDetails> activityDetails = new System.Collections.Generic.List<XblMultiplayerActivityDetails>();
                            for (int i = 0; i < resultCount.ToInt32(); i++)
                            {
                                activityDetails.Add(new XblMultiplayerActivityDetails(ptrToBufferResults[i]));
                            }


                            completionRoutine(hr, activityDetails.ToArray());
                        }
                    }
                });

                SizeT xuidsCount = new SizeT(0);
                if (xuids != null && xuids.Length > 0)
                {
                    xuidsCount = new SizeT(xuids.Length);
                }
                Int32 hresult = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(
                    xboxLiveContext.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(scid),
                    xuids,
                    xuidsCount,
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hresult, default(XblMultiplayerActivityDetails[]));
                }
            }

            public static void XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(
                XblContextHandle xboxLiveContext,
                string scid,
                UInt64 socialGroupOwnerXuid,
                string socialGroup,
                XblMultiplayerGetActivitiesWithPropertiesResult completionRoutine
                )
            {

                if (xboxLiveContext == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblMultiplayerActivityDetails[]));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    SizeT resultSizeInBytes;
                    Int32 hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResultSize(block, out resultSizeInBytes);
                    if (HR.FAILED(hr))
                    {
                        completionRoutine(hr, default(XblMultiplayerActivityDetails[]));
                        return;
                    }

                    // As of 2102, there is a bug in XblMultiplayerActivityGetActivityResult that will crash when 
                    // there are no items. Added this workaround since we support some versions of the GDK with 
                    // this bug. Remove this workaround when we stop supporting 2102 and lower.
                    if (resultSizeInBytes.IsZero)
                    {
                        completionRoutine(HR.S_OK, new XblMultiplayerActivityDetails[0]);
                        return;
                    }

                    unsafe
                    {
                        using (DisposableBuffer buffer = new DisposableBuffer(resultSizeInBytes.ToInt32()))
                        {
                            Interop.XblMultiplayerActivityDetails* ptrToBufferResults;
                            SizeT resultsCount, bufferUsed;
                            hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResult(
                                block,
                                resultSizeInBytes,
                                buffer.IntPtr,
                                out ptrToBufferResults,
                                out resultsCount,
                                out bufferUsed);

                            if (HR.FAILED(hr))
                            {
                                completionRoutine(hr, default(XblMultiplayerActivityDetails[]));
                                return;
                            }

                            System.Collections.Generic.List<XblMultiplayerActivityDetails> activityDetails = new System.Collections.Generic.List<XblMultiplayerActivityDetails>();
                            for (int i = 0; i < resultsCount.ToInt32(); i++)
                            {
                                activityDetails.Add(new XblMultiplayerActivityDetails(ptrToBufferResults[i]));
                            }


                            completionRoutine(hr, activityDetails.ToArray());
                        }
                    }
                });

                Int32 hresult = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(
                    xboxLiveContext.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(scid),
                    socialGroupOwnerXuid,
                    Converters.StringToNullTerminatedUTF8ByteArray(socialGroup),
                    asyncBlock);

                if (HR.FAILED(hresult))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hresult, default(XblMultiplayerActivityDetails[]));
                }
            }
        }
    }
}