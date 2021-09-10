using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public struct XblSocialHandle
            {
                public IntPtr interopHandle;
            }

            public struct XblSocialRelationship
            {
                public ulong xboxUserId;
                public bool isFavorite;
                public bool isFollowingCaller;
                public string[] socialNetworks;
            }

            public struct XblSocialRelationshipChangeEventArgs
            {
                public ulong callerXboxUserId;
                public XblSocialNotificationType socialNotification;
                public ulong[] xboxUserIds;
            }

            public delegate void XblSocialRelationshipCallback(
                int hresult,
                XblSocialHandle socialHandle);

            public delegate void XblSocialRelationshipChangedCallback(
                XblSocialRelationshipChangeEventArgs eventArgs);

            /// <summary>
            /// Wraps the underlying native XblSocialGetSocialRelationshipsAsync API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/social_c/functions/xblsocialgetsocialrelationshipsasync
            /// </summary>
            /// <param name="xboxLiveContext"></param>
            /// <param name="xboxUserId"></param>
            /// <param name="socialRelationshipFilter"></param>
            /// <param name="startIndex"></param>
            /// <param name="maxItems"></param>
            /// <param name="completionCallback"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblSocialGetSocialRelationshipsAsync(
                XblContextHandle xboxLiveContext, 
                ulong xboxUserId, 
                XblSocialRelationshipFilter socialRelationshipFilter, 
                uint startIndex, 
                uint maxItems,
                XblSocialRelationshipCallback completionCallback)
            {
                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(
                    SDK.defaultQueue.handle,
                    (XAsyncBlockPtr block) =>
                    {
                        unsafe 
                        {
                            IntPtr handle = default(IntPtr);
                            var result = Social.XblSocialGetSocialRelationshipsResult(block, &handle);

                            var socialHandle = new XblSocialHandle { interopHandle = handle };
                            completionCallback?.Invoke(result, socialHandle);
                        }
                    });

                var result = Social.XblSocialGetSocialRelationshipsAsync(
                    xboxLiveContext.InteropHandle.handle,
                    xboxUserId,
                    socialRelationshipFilter,
                    new SizeT(startIndex),
                    new SizeT(maxItems),
                    asyncBlock);

                if (HR.FAILED(result))
                {
                    completionCallback?.Invoke(result, default(XblSocialHandle));
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblSocialRelationshipResultGetRelationships API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/social_c/functions/xblsocialrelationshipresultgetrelationships
            /// </summary>
            /// <param name="socialHandle"></param>
            /// <param name="relationships"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblSocialRelationshipResultGetRelationships(
                XblSocialHandle socialHandle, 
                out XblSocialRelationship[] relationships)
            {
                int result;

                unsafe
                {
                    SizeT count = new SizeT();
                    Interop.XblSocialRelationship* relationshipsPtr = default;
                    result = Social.XblSocialRelationshipResultGetRelationships(
                        socialHandle.interopHandle,
                        &relationshipsPtr,
                        &count);

                    if (HR.SUCCEEDED(result))
                    {
                        relationships = new XblSocialRelationship[count.ToInt32()];
                        var interopPtr = relationshipsPtr;

                        for (var i = 0; i < count.ToInt32(); i++)
                        {
                            relationships[i] = new XblSocialRelationship();
                            relationships[i].xboxUserId = interopPtr->xboxUserId;
                            relationships[i].isFavorite = interopPtr->isFavorite;
                            relationships[i].isFollowingCaller = interopPtr->isFollowingCaller;
                            relationships[i].socialNetworks = new string[interopPtr->socialNetworksCount.ToInt32()];

                            var socialNetworksPtr = interopPtr->socialNetworks;

                            for (var j = 0; j < interopPtr->socialNetworksCount.ToInt32(); j++)
                            {
                                relationships[i].socialNetworks[j] =
                                    Converters.NullTerminatedBytePointerToString((byte*)*socialNetworksPtr);
                                socialNetworksPtr++;
                            }
                        }
                    }
                    else
                    {
                        relationships = null;
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblSocialRelationshipResultHasNext API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/social_c/functions/xblsocialrelationshipresulthasnext
            /// </summary>
            /// <param name="socialHandle"></param>
            /// <param name="hasNext"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblSocialRelationshipResultHasNext(
                XblSocialHandle socialHandle,
                ref bool hasNext)
            {
                int result;

                unsafe
                {
                    bool interopHasNext;
                    result = Social.XblSocialRelationshipResultHasNext(
                        socialHandle.interopHandle,
                        &interopHasNext);

                    if (HR.SUCCEEDED(result))
                    {
                        hasNext = interopHasNext;
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblSocialRelationshipResultGetTotalCount API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/social_c/functions/xblsocialrelationshipresultgettotalcount
            /// </summary>
            /// <param name="socialHandle"></param>
            /// <param name="totalCount"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblSocialRelationshipResultGetTotalCount(
                XblSocialHandle socialHandle,
                ref uint totalCount)
            {
                int result;

                unsafe
                {
                    SizeT interopTotalCount;
                    result = Social.XblSocialRelationshipResultGetTotalCount(
                        socialHandle.interopHandle,
                        &interopTotalCount);

                    if (HR.SUCCEEDED(result))
                    {
                        totalCount = interopTotalCount.ToUInt32();
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblSocialRelationshipResultGetNextAsync API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/social_c/functions/xblsocialrelationshipresultgetnextasync
            /// </summary>
            /// <param name="xboxLiveContext"></param>
            /// <param name="socialHandle"></param>
            /// <param name="maxItems"></param>
            /// <param name="completionCallback"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblSocialRelationshipResultGetNextAsync(
                XblContextHandle xboxLiveContext,
                XblSocialHandle socialHandle,
                uint maxItems,
                XblSocialRelationshipCallback completionCallback)
            {
                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(
                    SDK.defaultQueue.handle,
                    (XAsyncBlockPtr block) =>
                    {
                        unsafe
                        {
                            IntPtr handle = default(IntPtr);
                            var result = Social.XblSocialRelationshipResultGetNextResult(block, &handle);

                            var socialHandle = new XblSocialHandle { interopHandle = handle };
                            completionCallback?.Invoke(result, socialHandle);
                        }
                    });

                var result = Social.XblSocialRelationshipResultGetNextAsync(
                    xboxLiveContext.InteropHandle.handle,
                    socialHandle.interopHandle,
                    new SizeT(maxItems),
                    asyncBlock);

                if (HR.FAILED(result))
                {
                    completionCallback?.Invoke(result, default(XblSocialHandle));
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblSocialRelationshipResultDuplicateHandle API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/social_c/functions/xblsocialrelationshipresultduplicatehandle
            /// </summary>
            /// <param name="socialHandle"></param>
            /// <param name="duplicatedHandle"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblSocialRelationshipResultDuplicateHandle(
                XblSocialHandle socialHandle,
                out XblSocialHandle duplicatedHandle)
            {
                duplicatedHandle = new XblSocialHandle();
                int result;

                unsafe
                {
                    fixed(IntPtr* ptrToDupeHandle = &duplicatedHandle.interopHandle)
                    {
                        result = Social.XblSocialRelationshipResultDuplicateHandle(
                            socialHandle.interopHandle,
                            ptrToDupeHandle);
                    }
                }

                if (HR.FAILED(result))
                {
                    duplicatedHandle = default;
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblSocialRelationshipResultCloseHandle API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/social_c/functions/xblsocialrelationshipresultclosehandle
            /// </summary>
            /// <param name="socialHandle"></param>
            public static void XblSocialRelationshipResultCloseHandle(
                XblSocialHandle socialHandle)
            {
                Social.XblSocialRelationshipResultCloseHandle(socialHandle.interopHandle);
            }

            /// <summary>
            /// Wraps the underlying native XblSocialAddSocialRelationshipChangedHandler API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/social_c/functions/xblsocialaddsocialrelationshipchangedhandler
            /// </summary>
            /// <param name="xboxLiveContext"></param>
            /// <param name="eventCallback"></param>
            /// <returns>an integer representing a callback function ID, or 0 on failure</returns>
            public static int XblSocialAddSocialRelationshipChangedHandler(
                XblContextHandle xboxLiveContext,
                XblSocialRelationshipChangedCallback eventCallback)
            {
                int callbackFunctionId;

                unsafe
                {
                    callbackFunctionId = Social.XblSocialAddSocialRelationshipChangedHandler(
                        xboxLiveContext.InteropHandle.handle,
                        (Interop.XblSocialRelationshipChangeEventArgs* eventArgs, IntPtr context) =>
                        {
                            var callbackEventArgs = new XblSocialRelationshipChangeEventArgs();

                            callbackEventArgs.callerXboxUserId = eventArgs->callerXboxUserId;
                            callbackEventArgs.socialNotification = eventArgs->socialNotification;
                            callbackEventArgs.xboxUserIds = new ulong[eventArgs->xboxUserIdsCount.ToInt32()];
                            var idsPtr = eventArgs->xboxUserIds;
                            for (var i = 0; i < eventArgs->xboxUserIdsCount.ToInt32(); i++)
                            {
                                callbackEventArgs.xboxUserIds[i] = *idsPtr;
                                idsPtr++;
                            }

                            eventCallback?.Invoke(callbackEventArgs);
                        },
                        default);
                }

                return callbackFunctionId;
            }

            /// <summary>
            /// Wraps the underlying native XblSocialRemoveSocialRelationshipChangedHandler API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/social_c/functions/xblsocialremovesocialrelationshipchangedhandler
            /// </summary>
            /// <param name="xboxLiveContext"></param>
            /// <param name="callbackFunctionId"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblSocialRemoveSocialRelationshipChangedHandler(
                XblContextHandle xboxLiveContext, 
                int callbackFunctionId)
            {
                int result;

                unsafe
                {
                    result = Social.XblSocialRemoveSocialRelationshipChangedHandler(
                        xboxLiveContext.InteropHandle.handle,
                        callbackFunctionId);
                }

                return result;
            }
        }
    }
}
