using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public partial class SDK
    {
        public partial class XBL
        {
            public delegate void XblMultiplayerQuerySessionsResult(int hresult, XblMultiplayerSessionQueryResult[] sessionsQueryResult);
            public delegate void XblMultiplayerWriteSessionHandleResult(Int32 hresult, XblMultiplayerSessionHandle handle);
            public delegate void XblMultiplayerCreateSearchHandleResult(Int32 hresult, XblMultiplayerSearchHandle handle);
            public delegate void XblMultiplayerDeleteSearchHandleResult(Int32 hresult);
            public delegate void XblMultiplayerGetSearchHandlesResult(Int32 hresult, XblMultiplayerSearchHandle[] searchHandles);

            public delegate void XblMultiplayerSessionChangedHandler(XblMultiplayerSessionChangeEventArgs args);
            public delegate void XblMultiplayerSessionSubscriptionLostHandler();
            public delegate void XblMultiplayerConnectionIdChangedHandler();

            public static XblMultiplayerSessionHandle XblMultiplayerSessionCreateHandle(
                ulong xboxUserId,
                XblMultiplayerSessionReference sessionRef,
                XblMultiplayerSessionInitArgs initArgs
                )
            {
                using (DisposableCollection disposableCollection = new DisposableCollection())
                {
                    var interopSessionRef = new Interop.XblMultiplayerSessionReference(sessionRef);
                    var interopInitArgs = new Interop.XblMultiplayerSessionInitArgs(initArgs, disposableCollection);
                    return new XblMultiplayerSessionHandle(XblInterop.XblMultiplayerSessionCreateHandle(xboxUserId, ref interopSessionRef, ref interopInitArgs));
                }
            }

            public static void XblMultiplayerSessionCloseHandle(
                XblMultiplayerSessionHandle handle
                )
            {
                if (handle != null)
                {
                    XblInterop.XblMultiplayerSessionCloseHandle(handle.InteropHandle);
                }
            }

            public static int XblMultiplayerQuerySessionsAsync(XblContextHandle xblContext, XblMultiplayerSessionQuery sessionQuery, XblMultiplayerQuerySessionsResult completionRoutine)
            {
                if (xblContext == null || sessionQuery == null) return HR.E_INVALIDARG;

                unsafe
                {
                    XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) =>
                    {
                        Interop.XblMultiplayerSessionQueryResult[] interopResult;
                        SizeT sessionCount = new SizeT(0);
                        int hresult = Multiplayer.XblMultiplayerQuerySessionsResultCount(block, &sessionCount);

                        if (HR.SUCCEEDED(hresult))
                        {
                            interopResult = new Interop.XblMultiplayerSessionQueryResult[sessionCount.ToInt32()];
                            fixed (Interop.XblMultiplayerSessionQueryResult* resultPtr = &interopResult[0])
                            {
                                hresult = Multiplayer.XblMultiplayerQuerySessionsResult(block, sessionCount, &resultPtr[0]);
                                
                                if (HR.SUCCEEDED(hresult))
                                {
                                    var result = Array.ConvertAll(interopResult, r => new XblMultiplayerSessionQueryResult(r));
                                    completionRoutine(hresult, result);
                                    return;
                                }
                            }
                        }

                        completionRoutine(hresult, new XblMultiplayerSessionQueryResult[0]);
                    });

                    int keywordLen = Converters.GetSizeRequiredToEncodeStringToUTF8(sessionQuery.KeywordFilter);
                    var keywordBuffer = new sbyte[keywordLen];

                    fixed (sbyte* keywordPtr = &keywordBuffer[0])
                    fixed (ulong* interopFilters = &sessionQuery.XuidFilters[0])
                    {
                        var interopQuery = new Interop.XblMultiplayerSessionQuery
                        {
                            MaxItems = sessionQuery.MaxItems,
                            IncludePrivateSessions = sessionQuery.IncludePrivateSessions,
                            IncludeReservations = sessionQuery.IncludeReservations,
                            IncludeInactiveSessions = sessionQuery.IncludeInactiveSessions,
                            XuidFilters = interopFilters,
                            XuidFiltersCount = new SizeT(sessionQuery.XuidFiltersCount),
                            KeywordFilter = keywordPtr,
                            VisibilityFilter = sessionQuery.VisibilityFilter,
                            ContractVersionFilter = sessionQuery.ContractVersionFilter
                        };

                        Converters.StringToNullTerminatedUTF8FixedPointer(sessionQuery.Scid, (byte*)interopQuery.Scid, 40);
                        Converters.StringToNullTerminatedUTF8FixedPointer(sessionQuery.KeywordFilter, (byte*)interopQuery.KeywordFilter, keywordLen);
                        Converters.StringToNullTerminatedUTF8FixedPointer(sessionQuery.SessionTemplateNameFilter, (byte*)interopQuery.SessionTemplateNameFilter, 100);

                        int hr = Multiplayer.XblMultiplayerQuerySessionsAsync(xblContext.InteropHandle.handle, &interopQuery, asyncBlock);

                        if (HR.FAILED(hr))
                        {
                            AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                        }

                        return hr;
                    }
                }
            }

            public static int XblMultiplayerSessionCurrentUserSetEncounters(XblMultiplayerSessionHandle handle, string[] encounters)
            {
                if (handle == null || encounters == null) return HR.E_INVALIDARG;

                unsafe
                {
                    using (var interopEncounters = Converters.StringArrayToUTF8StringArray(encounters))
                    {
                        return Multiplayer.XblMultiplayerSessionCurrentUserSetEncounters(handle.InteropHandle.handle, (sbyte**)interopEncounters.IntPtr, new SizeT(encounters.Length));
                    }
                }
            }

            public static int XblMultiplayerSessionCurrentUserSetGroups(XblMultiplayerSessionHandle handle, string[] groups)
            {
                if (handle == null || groups == null) return HR.E_INVALIDARG;

                unsafe
                {
                    using (var interopGroups = Converters.StringArrayToUTF8StringArray(groups))
                    {
                        return Multiplayer.XblMultiplayerSessionCurrentUserSetGroups(handle.InteropHandle.handle, (sbyte**)interopGroups.IntPtr, new SizeT(groups.Length));
                    }
                }
            }

            public static int XblMultiplayerSessionPropertiesSetTurnCollection(XblMultiplayerSessionHandle handle, uint[] turnCollectionMemberIds)
            {
                if (handle == null || turnCollectionMemberIds == null) return HR.E_INVALIDARG;

                unsafe
                {
                    fixed (uint* idsPtr = &turnCollectionMemberIds[0])
                    {
                        return Multiplayer.XblMultiplayerSessionPropertiesSetTurnCollection(handle.InteropHandle.handle, idsPtr, new SizeT(turnCollectionMemberIds.Length));
                    }
                }
            }

            public static int XblMultiplayerSessionReferenceToUriPath(XblMultiplayerSessionReference sessionReference, out string sessionReferenceUri)
            {
                sessionReferenceUri = null;
                if (sessionReference == null) return HR.E_INVALIDARG;

                unsafe
                {
                    var interopReference = new Interop.XblMultiplayerSessionReference(sessionReference);
                    var interopUri = default(Interop.XblMultiplayerSessionReferenceUri);

                    int hresult = Multiplayer.XblMultiplayerSessionReferenceToUriPath(&interopReference, &interopUri);

                    if (HR.SUCCEEDED(hresult))
                    {
                        sessionReferenceUri = Converters.BytePointerToString((byte*)interopUri.value, 284);
                    }

                    return hresult;
                }
            }

            public static int XblMultiplayerSessionSetServerConnectionStringCandidates(XblMultiplayerSessionHandle handle, string[] serverConnectionStringCandidates)
            {
                if (handle == null || serverConnectionStringCandidates == null) return HR.E_INVALIDARG;

                unsafe
                {
                    using (var interopCandidates = Converters.StringArrayToUTF8StringArray(serverConnectionStringCandidates))
                    {
                        return Multiplayer.XblMultiplayerSessionCurrentUserSetGroups(handle.InteropHandle.handle, (sbyte**)interopCandidates.IntPtr, new SizeT(serverConnectionStringCandidates.Length));
                    }
                }
            }

            public static XblMultiplayerSessionProperties XblMultiplayerSessionSessionProperties(
                XblMultiplayerSessionHandle handle
                )
            {
                if (handle == null)
                {
                    return null;
                }

                unsafe
                {
                    var interop = XblInterop.XblMultiplayerSessionSessionProperties(handle.InteropHandle);

                    if (interop == null)
                        return null;

                    return new XblMultiplayerSessionProperties(*interop);
                }
            }

            public static Int32 XblMultiplayerSessionMembers(
                XblMultiplayerSessionHandle handle,
                out XblMultiplayerSessionMember[] members
                )
            {
                IntPtr interopMembers;
                SizeT membersCount;

                int hr = XblInterop.XblMultiplayerSessionMembers(handle.InteropHandle, out interopMembers, out membersCount);

                if (HR.FAILED(hr) || membersCount.IsZero)
                {
                    members = null;
                    return hr;
                }

                members = Converters.PtrToClassArray<XblMultiplayerSessionMember, Interop.XblMultiplayerSessionMember>(interopMembers, membersCount, (x =>new XblMultiplayerSessionMember(x)));
                return hr;
            }

            public static XblMultiplayerSessionMember XblMultiplayerSessionCurrentUser(
                XblMultiplayerSessionHandle handle
                )
            {
                if (handle == null)
                {
                    return null;
                }

                unsafe
                {
                    var interop = XblInterop.XblMultiplayerSessionCurrentUser(handle.InteropHandle);

                    if (interop == null)
                        return null;

                    return new XblMultiplayerSessionMember(*interop);
                }
            }

            public static XblWriteSessionStatus XblMultiplayerSessionWriteStatus(
                XblMultiplayerSessionHandle handle
                )
            {
                return XblInterop.XblMultiplayerSessionWriteStatus(handle.InteropHandle);
            }

            public static Int32 XblMultiplayerSessionJoin(
                XblMultiplayerSessionHandle handle,
                string memberCustomConstantsJson,
                bool initializeRequested,
                bool joinWithActiveStatus
                )
            {
                return XblInterop.XblMultiplayerSessionJoin(handle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(memberCustomConstantsJson), initializeRequested, joinWithActiveStatus);
            }

            public static void XblMultiplayerSessionSetHostDeviceToken(
                XblMultiplayerSessionHandle handle,
                XblDeviceToken hostDeviceToken
                )
            {
                if (handle == null)
                    return;

                XblInterop.XblMultiplayerSessionSetHostDeviceToken(handle.InteropHandle, new Interop.XblDeviceToken(hostDeviceToken));
            }

            public static void XblMultiplayerSessionSetClosed(
                XblMultiplayerSessionHandle handle,
                bool closed
                )
            {
                if (handle != null)
                {
                    XblInterop.XblMultiplayerSessionSetClosed(handle.InteropHandle, closed);
                }
            }

            //public static extern Int32 XblMultiplayerSessionSetSessionChangeSubscription(
            //    XblMultiplayerSessionHandle handle,
            //    XblMultiplayerSessionChangeTypes changeTypes
            //    );
            public static Int32 XblMultiplayerSessionSetSessionChangeSubscription(
                XblMultiplayerSessionHandle handle,
                XblMultiplayerSessionChangeTypes changeTypes
                )
            {
                if (handle != null)
                {
                    return XblInterop.XblMultiplayerSessionSetSessionChangeSubscription(handle.InteropHandle, changeTypes);
                }

                return HR.E_INVALIDARG;
            }

            public static Int32 XblMultiplayerSessionLeave(
                XblMultiplayerSessionHandle handle
                )
            {
                if (handle != null)
                {
                    return XblInterop.XblMultiplayerSessionLeave(handle.InteropHandle);
                }

                return HR.E_INVALIDARG;
            }

            public static Int32 XblMultiplayerSessionCurrentUserSetStatus(
                XblMultiplayerSessionHandle handle,
                XblMultiplayerSessionMemberStatus status
                )
            {
                if (handle != null)
                {
                    return XblInterop.XblMultiplayerSessionCurrentUserSetStatus(handle.InteropHandle, status);
                }

                return HR.E_INVALIDARG;
            }

            public static Int32 XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(
                XblMultiplayerSessionHandle handle,
                string value
                )
            {
                if (handle != null)
                {
                    return XblInterop.XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(handle.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(value));
                }

                return HR.E_INVALIDARG;
            }

            public static Int32 XblFormatSecureDeviceAddress(
                string deviceId,
                out string address
                )
            {
                if (deviceId != null)
                {
                    Interop.XblFormattedSecureDeviceAddress result;
                    Int32 hr = XblInterop.XblFormatSecureDeviceAddress(Converters.StringToNullTerminatedUTF8ByteArray(deviceId), out result);
                    address = result.GetValue();
                    return hr;
                }

                address = null;
                return HR.E_INVALIDARG;
            }

            public static Int32 XblMultiplayerSearchHandleDuplicateHandle(
                XblMultiplayerSearchHandle handle,
                out XblMultiplayerSearchHandle duplicatedHandle)
            {
                duplicatedHandle = default(XblMultiplayerSearchHandle);

                if (handle == null)
                {
                    return HR.E_INVALIDARG;
                }

                Interop.XblMultiplayerSearchHandle interopDuplicateHandle;
                Int32 hresult = XblInterop.XblMultiplayerSearchHandleDuplicateHandle(
                    handle.InteropHandle,
                    out interopDuplicateHandle);

                if (!HR.FAILED(hresult))
                {
                    duplicatedHandle = new XblMultiplayerSearchHandle(interopDuplicateHandle);
                }

                return hresult;
            }

            public static void XblMultiplayerSearchHandleCloseHandle(XblMultiplayerSearchHandle handle)
            {
                if (handle != null)
                {
                    XblInterop.XblMultiplayerSearchHandleCloseHandle(handle.InteropHandle);
                }
            }

            public static Int32 XblMultiplayerSearchHandleGetSessionReference(
                XblMultiplayerSearchHandle handle,
                out XblMultiplayerSessionReference sessionRef
                )
            {
                Interop.XblMultiplayerSessionReference interopSessionRef;
                Int32 hr = XblInterop.XblMultiplayerSearchHandleGetSessionReference(handle.InteropHandle, out interopSessionRef);

                if (HR.FAILED(hr))
                {
                    sessionRef = null;
                }
                else
                {
                    sessionRef = new XblMultiplayerSessionReference(interopSessionRef);
                }

                return hr;
            }

            public static Int32 XblMultiplayerSearchHandleGetId(
                XblMultiplayerSearchHandle handle,
                out string id
                )
            {
                UTF8StringPtr interopId;
                int hr = XblInterop.XblMultiplayerSearchHandleGetId(handle.InteropHandle, out interopId);

                if (HR.FAILED(hr))
                {
                    id = null;
                }
                else
                {
                    id = interopId.GetString();
                }

                return hr;
            }

            public static Int32 XblMultiplayerSearchHandleGetSessionOwnerXuids(
                XblMultiplayerSearchHandle handle,
                out ulong[] xuids
                )
            {
                IntPtr interopXuids;
                SizeT xuidsCount;

                int hr = XblInterop.XblMultiplayerSearchHandleGetSessionOwnerXuids(handle.InteropHandle, out interopXuids, out xuidsCount);

                if (HR.FAILED(hr) || xuidsCount.IsZero)
                {
                    xuids = null;
                    return hr;
                }

                xuids = Converters.PtrToClassArray<ulong, ulong>(interopXuids, xuidsCount.ToUInt32(), (x =>x));
                return hr;
            }

            public static Int32 XblMultiplayerSearchHandleGetTags(
                XblMultiplayerSearchHandle handle,
                out XblMultiplayerSessionTag[] tags
                )
            {
                IntPtr interopTags;
                SizeT tagsCount;

                int hr = XblInterop.XblMultiplayerSearchHandleGetTags(handle.InteropHandle, out interopTags, out tagsCount);

                if (HR.FAILED(hr) || tagsCount.IsZero)
                {
                    tags = null;
                    return hr;
                }

                tags = Converters.PtrToClassArray<XblMultiplayerSessionTag, Interop.XblMultiplayerSessionTag>(interopTags, tagsCount, (x =>new XblMultiplayerSessionTag(x)));
                return hr;
            }

            public static Int32 XblMultiplayerSearchHandleGetStringAttributes(
                XblMultiplayerSearchHandle handle,
                out XblMultiplayerSessionStringAttribute[] attributes
                )
            {
                IntPtr interopAttributes;
                SizeT attributesCount;

                int hr = XblInterop.XblMultiplayerSearchHandleGetStringAttributes(handle.InteropHandle, out interopAttributes, out attributesCount);

                if (HR.FAILED(hr) || attributesCount.IsZero)
                {
                    attributes = null;
                    return hr;
                }

                attributes = Converters.PtrToClassArray<XblMultiplayerSessionStringAttribute, Interop.XblMultiplayerSessionStringAttribute>(interopAttributes, attributesCount, (x =>new XblMultiplayerSessionStringAttribute(x)));
                return hr;
            }

            public static Int32 XblMultiplayerSearchHandleGetNumberAttributes(
                XblMultiplayerSearchHandle handle,
                out XblMultiplayerSessionNumberAttribute[] attributes
                )
            {
                IntPtr interopAttributes;
                SizeT attributesCount;

                int hr = XblInterop.XblMultiplayerSearchHandleGetNumberAttributes(handle.InteropHandle, out interopAttributes, out attributesCount);

                if (HR.FAILED(hr) || attributesCount.IsZero)
                {
                    attributes = null;
                    return hr;
                }

                attributes = Converters.PtrToClassArray<XblMultiplayerSessionNumberAttribute, Interop.XblMultiplayerSessionNumberAttribute>(interopAttributes, attributesCount, (x =>new XblMultiplayerSessionNumberAttribute(x)));
                return hr;
            }

            public static Int32 XblMultiplayerSearchHandleGetVisibility(
                XblMultiplayerSearchHandle handle,
                out XblMultiplayerSessionVisibility visibility
                )
            {
                Int32 hr = XblInterop.XblMultiplayerSearchHandleGetVisibility(handle.InteropHandle, out visibility);

                return hr;
            }

            public static Int32 XblMultiplayerSearchHandleGetJoinRestriction(
                XblMultiplayerSearchHandle handle,
                out XblMultiplayerSessionRestriction joinRestriction
                )
            {
                Int32 hr = XblInterop.XblMultiplayerSearchHandleGetJoinRestriction(handle.InteropHandle, out joinRestriction);

                return hr;
            }

            public static Int32 XblMultiplayerSearchHandleGetSessionClosed(
                XblMultiplayerSearchHandle handle,
                out bool closed
                )
            {
                Int32 hr = XblInterop.XblMultiplayerSearchHandleGetSessionClosed(handle.InteropHandle, out closed);

                return hr;
            }

            public static Int32 XblMultiplayerSearchHandleGetMemberCounts(
                XblMultiplayerSearchHandle handle,
                out uint maxMembers,
                out uint currentMembers
                )
            {
                maxMembers = default(uint);
                currentMembers = default(uint);
                if (handle == null)
                {
                    return HR.E_INVALIDARG;
                }

                SizeT interopMaxMembers, interopCurrentMembers;
                int hr = XblInterop.XblMultiplayerSearchHandleGetMemberCounts(handle.InteropHandle, out interopMaxMembers, out interopCurrentMembers);
                if (HR.SUCCEEDED(hr))
                {
                    maxMembers = interopMaxMembers.ToUInt32();
                    currentMembers = interopCurrentMembers.ToUInt32();
                }

                return hr;
            }

            public static Int32 XblMultiplayerSearchHandleGetCreationTime(
                XblMultiplayerSearchHandle handle,
                out DateTime creationTime
                )
            {
                creationTime = default(DateTime);
                if (handle == null)
                {
                    return HR.E_INVALIDARG;
                }

                TimeT creationTimeT;
                int hr = XblInterop.XblMultiplayerSearchHandleGetCreationTime(handle.InteropHandle, out creationTimeT);
                if (HR.SUCCEEDED(hr))
                {
                    creationTime = creationTimeT.DateTime;
                }

                return hr;
            }

            public static Int32 XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(
                XblMultiplayerSearchHandle handle,
                out string customPropertiesJson
                )
            {
                customPropertiesJson = default(string);
                if (handle == null)
                {
                    return HR.E_INVALIDARG;
                }

                UTF8StringPtr interopCustomPropertiesJson;
                int hr = XblInterop.XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(handle.InteropHandle, out interopCustomPropertiesJson);
                if (HR.SUCCEEDED(hr))
                {
                    customPropertiesJson = interopCustomPropertiesJson.GetString();
                }

                return hr;
            }

            public static void XblMultiplayerWriteSessionAsync(
                XblContextHandle xblContext,
                XblMultiplayerSessionHandle handle,
                XblMultiplayerSessionWriteMode writeMode,
                XblMultiplayerWriteSessionHandleResult completionRoutine
                )
            {
                if (xblContext == null || handle == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblMultiplayerSessionHandle));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    Interop.XblMultiplayerSessionHandle result;
                    Int32 hresult = XblInterop.XblMultiplayerWriteSessionResult(block, out result);
                    if (HR.FAILED(hresult))
                    {
                        completionRoutine(hresult, default(XblMultiplayerSessionHandle));
                        return;
                    }

                    completionRoutine(hresult, new XblMultiplayerSessionHandle(result));
                });

                Int32 hr = XblInterop.XblMultiplayerWriteSessionAsync(
                    xblContext.InteropHandle,
                    handle.InteropHandle,
                    writeMode,
                    asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr, default(XblMultiplayerSessionHandle));
                }
            }

            public static void XblMultiplayerCreateSearchHandleAsync(
                XblContextHandle xblContext,
                XblMultiplayerSessionReference sessionRef,
                XblMultiplayerSessionTag[] tags,
                XblMultiplayerSessionNumberAttribute[] numberAttributes,
                XblMultiplayerSessionStringAttribute[] stringAttributes,
                XblMultiplayerCreateSearchHandleResult completionRoutine
                )
            {
                if (xblContext == null || sessionRef == null)
                {
                    completionRoutine(HR.E_INVALIDARG, default(XblMultiplayerSearchHandle));
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue.handle, (XAsyncBlockPtr block) => 
                {
                    Interop.XblMultiplayerSearchHandle result;
                    Int32 hresult = XblInterop.XblMultiplayerCreateSearchHandleResult(block, out result);
                    if (HR.FAILED(hresult))
                    {
                        completionRoutine(hresult, default(XblMultiplayerSearchHandle));
                        return;
                    }

                    completionRoutine(hresult, new XblMultiplayerSearchHandle(result));
                });

                var interopSessionRef = new Interop.XblMultiplayerSessionReference(sessionRef);
                var interopTags = Converters.ConvertArrayToFixedLength(tags, tags.Length, r =>new Interop.XblMultiplayerSessionTag(r));
                var interopNumberAttributes = Converters.ConvertArrayToFixedLength(numberAttributes, numberAttributes.Length, r =>new Interop.XblMultiplayerSessionNumberAttribute(r));
                var interopStringAttributes = Converters.ConvertArrayToFixedLength(stringAttributes, stringAttributes.Length, r =>new Interop.XblMultiplayerSessionStringAttribute(r));

                Int32 hr = XblInterop.XblMultiplayerCreateSearchHandleAsync(
                    xblContext.InteropHandle,
                    ref interopSessionRef,
                    interopTags,
                    new SizeT(interopTags.Length),
                    interopNumberAttributes,
                    new SizeT(interopNumberAttributes.Length),
                    interopStringAttributes,
                    new SizeT(interopStringAttributes.Length),
                    asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr, default(XblMultiplayerSearchHandle));
                }
            }

            public static void XblMultiplayerDeleteSearchHandleAsync(
                XblContextHandle xblContext,
                string handleId,
                XblMultiplayerDeleteSearchHandleResult completionRoutine
                )
            {
                if (xblContext == null || handleId == null)
                {
                    completionRoutine(HR.E_INVALIDARG);
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue.handle, (Interop.XAsyncCompletionRoutine)(block =>completionRoutine(XGRInterop.XAsyncGetStatus(block, false))));
                int hr = XblInterop.XblMultiplayerDeleteSearchHandleAsync(xblContext.InteropHandle, Converters.StringToNullTerminatedUTF8ByteArray(handleId), asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr);
                }
            }

            public static void XblMultiplayerGetSearchHandlesAsync(
                XblContextHandle xboxLiveContext,
                string scid,
                string sessionTemplateName,
                string orderByAttribute,
                bool orderAscending,
                string searchFilter,
                string socialGroup,
                XblMultiplayerGetSearchHandlesResult completionRoutine)
            {
                if (xboxLiveContext == null)
                {
                    completionRoutine(HR.E_INVALIDARG, new XblMultiplayerSearchHandle[0]);
                    return;
                }

                XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(SDK.defaultQueue.handle, (Interop.XAsyncCompletionRoutine)(block =>
                {
                    SizeT searchHandleCount;
                    int handlesResultCount = XblInterop.XblMultiplayerGetSearchHandlesResultCount(block, out searchHandleCount);
                    if (HR.FAILED(handlesResultCount) || searchHandleCount.IsZero)
                    {
                        completionRoutine(handlesResultCount, new XblMultiplayerSearchHandle[0]);
                    }
                    else
                    {
                        Interop.XblMultiplayerSearchHandle[] multiplayerSearchHandleArray = new Interop.XblMultiplayerSearchHandle[searchHandleCount.ToInt32()];
                        int hresult = XblInterop.XblMultiplayerGetSearchHandlesResult(block, multiplayerSearchHandleArray, searchHandleCount);
                        if (!HR.FAILED(hresult))
                            completionRoutine(hresult, Array.ConvertAll(multiplayerSearchHandleArray, h =>new XblMultiplayerSearchHandle(h)));
                        else
                            completionRoutine(hresult, new XblMultiplayerSearchHandle[0]);
                    }
                }));

                int hr = XblInterop.XblMultiplayerGetSearchHandlesAsync(
                    xboxLiveContext.InteropHandle,
                    Converters.StringToNullTerminatedUTF8ByteArray(scid),
                    Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName),
                    Converters.StringToNullTerminatedUTF8ByteArray(orderByAttribute),
                    orderAscending,
                    Converters.StringToNullTerminatedUTF8ByteArray(searchFilter),
                    Converters.StringToNullTerminatedUTF8ByteArray(socialGroup),
                    asyncBlock);

                if (HR.FAILED(hr))
                {
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                    completionRoutine(hr, new XblMultiplayerSearchHandle[0]);
                }
            }

            public static Int32 XblMultiplayerSetSubscriptionsEnabled(
                XblContextHandle xblContext,
                bool subscriptionsEnabled
                )
            {
                return XblInterop.XblMultiplayerSetSubscriptionsEnabled(xblContext.InteropHandle, subscriptionsEnabled);
            }

            public static bool XblMultiplayerSubscriptionsEnabled(
                XblContextHandle xblHandle
                )
            {
                return XblInterop.XblMultiplayerSubscriptionsEnabled(xblHandle.InteropHandle);
            }
        }
    }
}
