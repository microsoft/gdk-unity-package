using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    // TODO: place structs and delegate definitions here

    public partial class SDK
    {
        public partial class XBL
        {
            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionDuplicateHandle API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionduplicatehandle
            /// </summary>
            /// <param name="srcHandle"></param>
            /// <param name="dstHandle"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionDuplicateHandle(
                XblMultiplayerSessionHandle srcHandle,
                out XblMultiplayerSessionHandle dstHandle)
            {
                var interopDstHandle = new Interop.XblMultiplayerSessionHandle();
                int result;

                unsafe
                {
                    result = Multiplayer.XblMultiplayerSessionDuplicateHandle(
                        srcHandle.InteropHandle.handle,
                        &interopDstHandle.handle);

                    if (HR.SUCCEEDED(result))
                    {
                        dstHandle = new XblMultiplayerSessionHandle(interopDstHandle);
                    }
                    else
                    {
                        dstHandle = null;
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionTimeOfSession API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessiontimeofsession
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <returns>a DateTime representing when the session was created.</returns>
            public static DateTime XblMultiplayerSessionTimeOfSession(
                XblMultiplayerSessionHandle sessionHandle)
            {
                var result = Multiplayer.XblMultiplayerSessionTimeOfSession(
                    sessionHandle.InteropHandle.handle);
                var time = new TimeT(result);
                return time.DateTime;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionGetInitializationInfo API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessiongetinitializationinfo
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <returns>null if info does not exist for the handle, non-null otherwise.</returns>
            public static XblMultiplayerSessionInitializationInfo XblMultiplayerSessionGetInitializationInfo(
                XblMultiplayerSessionHandle sessionHandle)
            {
                XblMultiplayerSessionInitializationInfo info = null;

                unsafe
                {
                    var result = Multiplayer.XblMultiplayerSessionGetInitializationInfo(
                        sessionHandle.InteropHandle.handle);
                    if (result != default(Interop.XblMultiplayerSessionInitializationInfo*))
                    {
                        info = new XblMultiplayerSessionInitializationInfo(*result);
                    }
                }

                return info;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionSubscribedChangeTypes API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionsubscribedchangetypes
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <returns>Combined bit flags that contain supported change types by the session.</returns>
            public static XblMultiplayerSessionChangeTypes XblMultiplayerSessionSubscribedChangeTypes(
                XblMultiplayerSessionHandle sessionHandle)
            {
                return Multiplayer.XblMultiplayerSessionSubscribedChangeTypes(
                    sessionHandle.InteropHandle.handle);
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionHostCandidates API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionhostcandidates
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="deviceTokens"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionHostCandidates(
                XblMultiplayerSessionHandle sessionHandle,
                out XblDeviceToken[] deviceTokens)
            {
                int result;

                unsafe
                {
                    var tokenCount = new SizeT();
                    var tokenPtr = default(Interop.XblDeviceToken*);

                    result = Multiplayer.XblMultiplayerSessionHostCandidates(
                        sessionHandle.InteropHandle.handle,
                        &tokenPtr,
                        &tokenCount);

                    if (HR.SUCCEEDED(result))
                    {
                        deviceTokens = new XblDeviceToken[tokenCount.ToInt32()];
                        for (var i = 0; i < tokenCount.ToInt32(); i++)
                        {
                            deviceTokens[i] = new XblDeviceToken(*tokenPtr);
                            tokenPtr++;
                        }
                    }
                    else
                    {
                        deviceTokens = null;
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionSessionReference API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionsessionreference
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <returns>null if the session handle is invalid, non-null otherwise.</returns>
            public static XblMultiplayerSessionReference XblMultiplayerSessionSessionReference(
                XblMultiplayerSessionHandle sessionHandle)
            {
                XblMultiplayerSessionReference sessionReference = null;

                unsafe
                {
                    var sessionRefPtr = Multiplayer.XblMultiplayerSessionSessionReference(
                        sessionHandle.InteropHandle.handle);

                    if (sessionRefPtr != default(Interop.XblMultiplayerSessionReference*))
                    {
                        sessionReference = new XblMultiplayerSessionReference(*sessionRefPtr);
                    }
                }

                return sessionReference;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionSessionConstants API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionsessionconstants
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <returns>null if the session handle is invalid, non-null otherwise.</returns>
            public static XblMultiplayerSessionConstants XblMultiplayerSessionSessionConstants(
                XblMultiplayerSessionHandle sessionHandle)
            {
                XblMultiplayerSessionConstants sessionConstants = null;

                unsafe
                {
                    var result = Multiplayer.XblMultiplayerSessionSessionConstants(
                        sessionHandle.InteropHandle.handle);

                    if (result != default(Interop.XblMultiplayerSessionConstants*))
                    {
                        sessionConstants = new XblMultiplayerSessionConstants(*result);
                    }
                }

                return sessionConstants;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionConstantsSetMaxMembersInSession API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionconstantssetmaxmembersinsession
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="maxMembersInSession"></param>
            public static void XblMultiplayerSessionConstantsSetMaxMembersInSession(
                XblMultiplayerSessionHandle sessionHandle,
                uint maxMembersInSession)
            {
                Multiplayer.XblMultiplayerSessionConstantsSetMaxMembersInSession(
                    sessionHandle.InteropHandle.handle, maxMembersInSession);
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionConstantsSetVisibility API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionconstantssetvisibility
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="visibility"></param>
            public static void XblMultiplayerSessionConstantsSetVisibility(
                XblMultiplayerSessionHandle sessionHandle,
                XblMultiplayerSessionVisibility visibility)
            {
                Multiplayer.XblMultiplayerSessionConstantsSetVisibility(
                    sessionHandle.InteropHandle.handle, visibility);
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionConstantsSetTimeouts API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionconstantssettimeouts
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="memberReservedTimeout"></param>
            /// <param name="memberInactiveTimeout"></param>
            /// <param name="memberReadyTimeout"></param>
            /// <param name="sessionEmptyTimeout"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionConstantsSetTimeouts(
                XblMultiplayerSessionHandle sessionHandle,
                TimeSpan memberReservedTimeout,
                TimeSpan memberInactiveTimeout,
                TimeSpan memberReadyTimeout,
                TimeSpan sessionEmptyTimeout)
            {
                return Multiplayer.XblMultiplayerSessionConstantsSetTimeouts(
                    sessionHandle.InteropHandle.handle,
                    Convert.ToUInt64(memberReservedTimeout.TotalMilliseconds),
                    Convert.ToUInt64(memberInactiveTimeout.TotalMilliseconds),
                    Convert.ToUInt64(memberReadyTimeout.TotalMilliseconds),
                    Convert.ToUInt64(sessionEmptyTimeout.TotalMilliseconds));
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionConstantsSetArbitrationTimeouts API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionconstantssetarbitrationtimeouts
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="arbitrationTimeout"></param>
            /// <param name="forfeitTimeout"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionConstantsSetArbitrationTimeouts(
                XblMultiplayerSessionHandle sessionHandle,
                TimeSpan arbitrationTimeout,
                TimeSpan forfeitTimeout)
            {
                return Multiplayer.XblMultiplayerSessionConstantsSetArbitrationTimeouts(
                    sessionHandle.InteropHandle.handle,
                    Convert.ToUInt64(arbitrationTimeout.TotalMilliseconds),
                    Convert.ToUInt64(forfeitTimeout.TotalMilliseconds));
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionConstantsSetQosConnectivityMetrics API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionconstantssetqosconnectivitymetrics
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="enableLatencyMetric"></param>
            /// <param name="enableBandwidthDownMetric"></param>
            /// <param name="enableBandwidthUpMetric"></param>
            /// <param name="enableCustomMetric"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionConstantsSetQosConnectivityMetrics(
                XblMultiplayerSessionHandle sessionHandle,
                bool enableLatencyMetric,
                bool enableBandwidthDownMetric,
                bool enableBandwidthUpMetric,
                bool enableCustomMetric)
            {
                return Multiplayer.XblMultiplayerSessionConstantsSetQosConnectivityMetrics(
                    sessionHandle.InteropHandle.handle,
                    Convert.ToByte(enableLatencyMetric),
                    Convert.ToByte(enableBandwidthDownMetric),
                    Convert.ToByte(enableBandwidthUpMetric),
                    Convert.ToByte(enableCustomMetric));
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionConstantsSetMemberInitialization API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionconstantssetmemberinitialization
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="memberInitialization"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionConstantsSetMemberInitialization(
                XblMultiplayerSessionHandle sessionHandle,
                XblMultiplayerMemberInitialization memberInitialization)
            {
                return Multiplayer.XblMultiplayerSessionConstantsSetMemberInitialization(
                    sessionHandle.InteropHandle.handle,
                    new Interop.XblMultiplayerMemberInitialization(memberInitialization));
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionConstantsSetPeerToPeerRequirements API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionconstantssetpeertopeerrequirements
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="requirements"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionConstantsSetPeerToPeerRequirements(
                XblMultiplayerSessionHandle sessionHandle,
                XblMultiplayerPeerToPeerRequirements requirements)
            {
                return Multiplayer.XblMultiplayerSessionConstantsSetPeerToPeerRequirements(
                    sessionHandle.InteropHandle.handle,
                    new Interop.XblMultiplayerPeerToPeerRequirements(requirements));
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionConstantsSetPeerToHostRequirements API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionconstantssetpeertohostrequirements
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="requirements"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionConstantsSetPeerToHostRequirements(
                XblMultiplayerSessionHandle sessionHandle,
                XblMultiplayerPeerToHostRequirements requirements)
            {
                return Multiplayer.XblMultiplayerSessionConstantsSetPeerToHostRequirements(
                    sessionHandle.InteropHandle.handle,
                    new Interop.XblMultiplayerPeerToHostRequirements(requirements));
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionconstantssetmeasurementserveraddressesjson
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="measurementServerAddressesJson"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson(
                XblMultiplayerSessionHandle sessionHandle,
                string measurementServerAddressesJson)
            {
                int result;

                unsafe
                {
                    var requiredInteropLen = Converters.GetSizeRequiredToEncodeStringToUTF8(
                        measurementServerAddressesJson);
                    sbyte[] interopJson = new sbyte[requiredInteropLen];

                    fixed(sbyte* interopJsonPtr = &interopJson[0])
                    {
                        Converters.StringToNullTerminatedUTF8FixedPointer(
                            measurementServerAddressesJson, (byte*)interopJsonPtr, requiredInteropLen);
                        result = Multiplayer.XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson(
                            sessionHandle.InteropHandle.handle,
                            interopJsonPtr);
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionConstantsSetCapabilities API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionconstantssetcapabilities
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="capabilities"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionConstantsSetCapabilities(
                XblMultiplayerSessionHandle sessionHandle,
                XblMultiplayerSessionCapabilities capabilities)
            {
                return Multiplayer.XblMultiplayerSessionConstantsSetCapabilities(
                    sessionHandle.InteropHandle.handle,
                    new Interop.XblMultiplayerSessionCapabilities(capabilities));
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionConstantsSetCloudComputePackageJson API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionconstantssetcloudcomputepackagejson
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="sessionCloudComputePackageConstantsJson"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionConstantsSetCloudComputePackageJson(
                XblMultiplayerSessionHandle sessionHandle,
                string sessionCloudComputePackageConstantsJson)
            {
                int result;

                unsafe
                {
                    var requiredInteropLen = Converters.GetSizeRequiredToEncodeStringToUTF8(
                        sessionCloudComputePackageConstantsJson);
                    sbyte[] interopJson = new sbyte[requiredInteropLen];

                    fixed (sbyte* interopJsonPtr = &interopJson[0])
                    {
                        Converters.StringToNullTerminatedUTF8FixedPointer(
                            sessionCloudComputePackageConstantsJson, (byte*)interopJsonPtr, requiredInteropLen);
                        result = Multiplayer.XblMultiplayerSessionConstantsSetCloudComputePackageJson(
                            sessionHandle.InteropHandle.handle,
                            interopJsonPtr);
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionPropertiesSetJoinRestriction API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionpropertiessetjoinrestriction
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="joinRestriction"></param>
            public static void XblMultiplayerSessionPropertiesSetJoinRestriction(
                XblMultiplayerSessionHandle sessionHandle,
                XblMultiplayerSessionRestriction joinRestriction)
            {
                Multiplayer.XblMultiplayerSessionPropertiesSetJoinRestriction(
                    sessionHandle.InteropHandle.handle,
                    joinRestriction);
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionPropertiesSetReadRestriction API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionpropertiessetreadrestriction
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="readRestriction"></param>
            public static void XblMultiplayerSessionPropertiesSetReadRestriction(
                XblMultiplayerSessionHandle sessionHandle,
                XblMultiplayerSessionRestriction readRestriction)
            {
                Multiplayer.XblMultiplayerSessionPropertiesSetReadRestriction(
                    sessionHandle.InteropHandle.handle,
                    readRestriction);
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionSetMutableRoleSettings API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionsetmutablerolesettings
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="roleTypeName"></param>
            /// <param name="roleName"></param>
            /// <param name="maxMemberCount"></param>
            /// <param name="targetMemberCount"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionSetMutableRoleSettings(
                XblMultiplayerSessionHandle sessionHandle,
                string roleTypeName,
                string roleName,
                uint? maxMemberCount,
                uint? targetMemberCount)
            {
                int result;

                unsafe
                {
                    var interopRoleTypeNameLen = Converters.GetSizeRequiredToEncodeStringToUTF8(
                        roleTypeName);
                    var interopRoleNameLen = Converters.GetSizeRequiredToEncodeStringToUTF8(
                        roleName);

                    var interopRoleTypeName = new sbyte[interopRoleTypeNameLen];
                    var interopRoleName = new sbyte[interopRoleNameLen];

                    var maxMemberCountValue = maxMemberCount.HasValue ? maxMemberCount.Value : default(uint);
                    var targetMemberCountValue = targetMemberCount.HasValue ? targetMemberCount.Value : default(uint);

                    var maxMemberCountPtr = maxMemberCount.HasValue ? &maxMemberCountValue : default(uint*);
                    var targetMemberCountPtr = targetMemberCount.HasValue ? &targetMemberCountValue : default(uint*);

                    fixed (sbyte* interopRoleTypePtr = &interopRoleTypeName[0],
                        interopRolePtr = &interopRoleName[0])
                    {
                        result = Multiplayer.XblMultiplayerSessionSetMutableRoleSettings(
                            sessionHandle.InteropHandle.handle,
                            interopRoleTypePtr,
                            interopRolePtr,
                            maxMemberCountPtr,
                            targetMemberCountPtr);
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionGetMember API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessiongetmember
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="memberId"></param>
            /// <returns>null if the session handle or memberId is invalid, non-null otherwise.</returns>
            public static XblMultiplayerSessionMember XblMultiplayerSessionGetMember(
                XblMultiplayerSessionHandle sessionHandle,
                uint memberId)
            {
                XblMultiplayerSessionMember sessionMember = null;

                unsafe
                {
                    var result = Multiplayer.XblMultiplayerSessionGetMember(
                        sessionHandle.InteropHandle.handle,
                        memberId);

                    if (result != default(Interop.XblMultiplayerSessionMember*))
                    {
                        sessionMember = new XblMultiplayerSessionMember(*result);
                    }
                }

                return sessionMember;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionMembersAccepted API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionmembersaccepted
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <returns>0 if no members accepted or invalid handle, >0 otherwise.</returns>
            public static uint XblMultiplayerSessionMembersAccepted(
                XblMultiplayerSessionHandle sessionHandle)
            {
                return Multiplayer.XblMultiplayerSessionMembersAccepted(
                    sessionHandle.InteropHandle.handle);
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionRawServersJson API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionrawserversjson
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <returns>null if invalid session handle, non-null otherwise.</returns>
            public static string XblMultiplayerSessionRawServersJson(
                XblMultiplayerSessionHandle sessionHandle)
            {
                string serverJson = null;

                unsafe
                {
                    var interopServerJson = Multiplayer.XblMultiplayerSessionRawServersJson(
                        sessionHandle.InteropHandle.handle);
                    if (interopServerJson != default(sbyte*))
                    {
                        serverJson = Converters.NullTerminatedBytePointerToString((byte*)interopServerJson);
                    }
                }

                return serverJson;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionSetRawServersJson API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionsetrawserversjson
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="rawServersJson"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionSetRawServersJson(
                XblMultiplayerSessionHandle sessionHandle,
                string rawServersJson)
            {
                int result;

                unsafe
                {
                    var interopServerJsonLen = 
                        string.IsNullOrEmpty(rawServersJson) ? 1 :
                        Converters.GetSizeRequiredToEncodeStringToUTF8(
                            rawServersJson);
                    var interopServerJson = new sbyte[interopServerJsonLen];
                    interopServerJson[0] = 0;

                    fixed (sbyte* interopServerJsonPtr = &interopServerJson[0])
                    {
                        if (!string.IsNullOrEmpty(rawServersJson))
                        {
                            Converters.StringToNullTerminatedUTF8FixedPointer(
                                rawServersJson, (byte*)interopServerJsonPtr, interopServerJsonLen);
                        }
                        result = Multiplayer.XblMultiplayerSessionSetRawServersJson(
                            sessionHandle.InteropHandle.handle,
                            interopServerJsonPtr);
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionEtag API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionetag
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <returns>null if the session handle is invalid, non-null otherwise.</returns>
            public static string XblMultiplayerSessionEtag(
                XblMultiplayerSessionHandle sessionHandle)
            {
                string etag = null;

                unsafe
                {
                    var interopEtag = Multiplayer.XblMultiplayerSessionEtag(
                        sessionHandle.InteropHandle.handle);
                    if (interopEtag != default(sbyte*))
                    {
                        etag = Converters.NullTerminatedBytePointerToString((byte*)interopEtag);
                    }
                }

                return etag;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionGetInfo API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessiongetinfo
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <returns>null is session handle is invalid, non-null otherwise.</returns>
            public static XblMultiplayerSessionInfo XblMultiplayerSessionGetInfo(
                XblMultiplayerSessionHandle sessionHandle)
            {
                XblMultiplayerSessionInfo sessionInfo = null;

                unsafe
                {
                    var interopInfo = Multiplayer.XblMultiplayerSessionGetInfo(
                        sessionHandle.InteropHandle.handle);
                    if (interopInfo != default(Interop.XblMultiplayerSessionInfo*))
                    {
                        sessionInfo = new XblMultiplayerSessionInfo(*interopInfo);
                    }
                }

                return sessionInfo;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionAddMemberReservation API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionaddmemberreservation
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="xuid"></param>
            /// <param name="memberCustomConstantsJson"></param>
            /// <param name="initializeRequested"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionAddMemberReservation(
                XblMultiplayerSessionHandle sessionHandle,
                ulong xuid,
                string memberCustomConstantsJson,
                bool initializeRequested)
            {
                int result;

                unsafe
                {
                    var interopConstantsJsonLen =
                        string.IsNullOrEmpty(memberCustomConstantsJson) ? 1 :
                        Converters.GetSizeRequiredToEncodeStringToUTF8(memberCustomConstantsJson);

                    var interopConstantsJson = new sbyte[interopConstantsJsonLen];
                    interopConstantsJson[0] = 0;

                    fixed (sbyte* interopConstantsJsonPtr = &interopConstantsJson[0])
                    {
                        if (!string.IsNullOrEmpty(memberCustomConstantsJson))
                        {
                            Converters.StringToNullTerminatedUTF8FixedPointer(
                                memberCustomConstantsJson,
                                (byte*)interopConstantsJsonPtr,
                                interopConstantsJsonLen);
                        }

                        result = Multiplayer.XblMultiplayerSessionAddMemberReservation(
                            sessionHandle.InteropHandle.handle,
                            xuid,
                            interopConstantsJsonPtr,
                            Convert.ToByte(initializeRequested));
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionSetInitializationSucceeded API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionsetinitializationsucceeded
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="initializationSucceeded"></param>
            public static void XblMultiplayerSessionSetInitializationSucceeded(
                XblMultiplayerSessionHandle sessionHandle,
                bool initializationSucceeded)
            {
                Multiplayer.XblMultiplayerSessionSetInitializationSucceeded(
                    sessionHandle.InteropHandle.handle,
                    Convert.ToByte(initializationSucceeded));
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionSetMatchmakingServerConnectionPath API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionsetmatchmakingserverconnectionpath
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="serverConnectionPath"></param>
            public static void XblMultiplayerSessionSetMatchmakingServerConnectionPath(
                XblMultiplayerSessionHandle sessionHandle,
                string serverConnectionPath)
            {
                unsafe
                {
                    var connectionPathLen =
                        string.IsNullOrEmpty(serverConnectionPath) ? 1 :
                        Converters.GetSizeRequiredToEncodeStringToUTF8(serverConnectionPath);
                    var connectionPath = new sbyte[connectionPathLen];
                    connectionPath[0] = 0;

                    fixed(sbyte* connectionPathPtr = &connectionPath[0])
                    {
                        if (!string.IsNullOrEmpty(serverConnectionPath))
                        {
                            Converters.StringToNullTerminatedUTF8FixedPointer(
                                serverConnectionPath, (byte*)connectionPathPtr, connectionPathLen);
                        }

                        Multiplayer.XblMultiplayerSessionSetMatchmakingServerConnectionPath(
                            sessionHandle.InteropHandle.handle,
                            connectionPathPtr);
                    }
                }
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionSetLocked API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionsetlocked
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="isLocked"></param>
            public static void XblMultiplayerSessionSetLocked(
                XblMultiplayerSessionHandle sessionHandle,
                bool isLocked)
            {
                Multiplayer.XblMultiplayerSessionSetLocked(
                    sessionHandle.InteropHandle.handle,
                    Convert.ToByte(isLocked));
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionSetAllocateCloudCompute API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionsetallocatecloudcompute
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="allocateCloudCompute"></param>
            public static void XblMultiplayerSessionSetAllocateCloudCompute(
                XblMultiplayerSessionHandle sessionHandle,
                bool allocateCloudCompute)
            {
                Multiplayer.XblMultiplayerSessionSetAllocateCloudCompute(
                    sessionHandle.InteropHandle.handle,
                    Convert.ToByte(allocateCloudCompute));
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionSetMatchmakingResubmit API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessionsetmatchmakingresubmit
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="matchResubmit"></param>
            public static void XblMultiplayerSessionSetMatchmakingResubmit(
                XblMultiplayerSessionHandle sessionHandle,
                bool matchResubmit)
            {
                Multiplayer.XblMultiplayerSessionSetMatchmakingResubmit(
                    sessionHandle.InteropHandle.handle,
                    Convert.ToByte(matchResubmit));
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionCurrentUserSetRoles API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessioncurrentusersetroles
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="memberRoles"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionCurrentUserSetRoles(
                XblMultiplayerSessionHandle sessionHandle,
                XblMultiplayerSessionMemberRole[] memberRoles)
            {
                int result;

                unsafe
                {
                    using (DisposableCollection disposableCollection = new DisposableCollection())
                    {
                        var interopRoles = new Interop.XblMultiplayerSessionMemberRole[memberRoles.Length];

                        for (var i = 0; i < memberRoles.Length; i++)
                        {
                            interopRoles[i] = new Interop.XblMultiplayerSessionMemberRole(memberRoles[i], disposableCollection);
                        }

                        fixed (Interop.XblMultiplayerSessionMemberRole* interopRolesPtr = &interopRoles[0])
                        {
                            result = Multiplayer.XblMultiplayerSessionCurrentUserSetRoles(
                                sessionHandle.InteropHandle.handle,
                                interopRolesPtr,
                                new SizeT(memberRoles.Length));
                        }
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionCurrentUserSetQosMeasurements API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessioncurrentusersetqosmeasurements
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="measurements"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionCurrentUserSetQosMeasurements(
                XblMultiplayerSessionHandle sessionHandle,
                string measurements)
            {
                int result;

                unsafe
                {
                    var interopMeasurementsLen =
                        string.IsNullOrEmpty(measurements) ? 1 :
                        Converters.GetSizeRequiredToEncodeStringToUTF8(measurements);

                    var interopMeasurements = new sbyte[interopMeasurementsLen];
                    interopMeasurements[0] = 0;

                    fixed (sbyte* interopMeasurementsPtr = &interopMeasurements[0])
                    {
                        if (!string.IsNullOrEmpty(measurements))
                        {
                            Converters.StringToNullTerminatedUTF8FixedPointer(
                                measurements, 
                                (byte*)interopMeasurementsPtr, 
                                interopMeasurementsLen);
                        }

                        result = Multiplayer.XblMultiplayerSessionCurrentUserSetQosMeasurements(
                            sessionHandle.InteropHandle.handle,
                            interopMeasurementsPtr);
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionCurrentUserSetCustomPropertyJson API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessioncurrentusersetcustompropertyjson
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="propertyName"></param>
            /// <param name="propertyValueJson"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionCurrentUserSetCustomPropertyJson(
                XblMultiplayerSessionHandle sessionHandle,
                string propertyName,
                string propertyValueJson)
            {
                int result;

                unsafe
                {
                    var interopNameLen =
                        string.IsNullOrEmpty(propertyName) ? 1 :
                        Converters.GetSizeRequiredToEncodeStringToUTF8(propertyName);

                    var interopValueLen =
                        string.IsNullOrEmpty(propertyValueJson) ? 1 :
                        Converters.GetSizeRequiredToEncodeStringToUTF8(propertyValueJson);

                    var interopName = new sbyte[interopNameLen];
                    interopName[0] = 0;

                    var interopValue = new sbyte[interopValueLen];
                    interopValue[0] = 0;

                    fixed (sbyte* interopNamePtr = &interopName[0], interopValuePtr = &interopValue[0])
                    {
                        if (!string.IsNullOrEmpty(propertyName))
                        {
                            Converters.StringToNullTerminatedUTF8FixedPointer(
                                propertyName, (byte*)interopNamePtr, interopNameLen);
                        }

                        if (!string.IsNullOrEmpty(propertyValueJson))
                        {
                            Converters.StringToNullTerminatedUTF8FixedPointer(
                                propertyValueJson, (byte*)interopValuePtr, interopValueLen);
                        }

                        result = Multiplayer.XblMultiplayerSessionCurrentUserSetCustomPropertyJson(
                           sessionHandle.InteropHandle.handle,
                            interopNamePtr,
                            interopValuePtr);
                    }
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/multiplayer_c/functions/xblmultiplayersessioncurrentuserdeletecustompropertyjson
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="propertyName"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson(
                XblMultiplayerSessionHandle sessionHandle,
                string propertyName)
            {
                int result;

                unsafe
                {
                    var interopNameLen =
                        string.IsNullOrEmpty(propertyName) ? 1 :
                        Converters.GetSizeRequiredToEncodeStringToUTF8(propertyName);

                    var interopName = new sbyte[interopNameLen];
                    interopName[0] = 0;

                    fixed (sbyte* interopNamePtr = &interopName[0])
                    {
                        if (!string.IsNullOrEmpty(propertyName))
                        {
                            Converters.StringToNullTerminatedUTF8FixedPointer(
                                propertyName, (byte*)interopNamePtr, interopNameLen);
                        }

                        result = Multiplayer.XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson(
                            sessionHandle.InteropHandle.handle,
                            interopNamePtr);
                    }
                }

                return result;
            }

            // TODO: place API method impls here (20 in ~240 mins [1 per ~12 min])

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerSessionSetMatchmakingTargetSessionConstantsJson(
            //  [NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle,
            //  [NativeTypeName("const char *")] sbyte* matchmakingTargetSessionConstantsJson);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerSessionSetCustomPropertyJson(
            //  [NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle,
            //  [NativeTypeName("const char *")] sbyte* name,
            //  [NativeTypeName("const char *")] sbyte* valueJson);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerSessionDeleteCustomPropertyJson(
            //  [NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle,
            //  [NativeTypeName("const char *")] sbyte* name);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //public static extern XblMultiplayerSessionChangeTypes XblMultiplayerSessionCompare(
            //  [NativeTypeName("XblMultiplayerSessionHandle")] IntPtr currentSessionHandle,
            //  [NativeTypeName("XblMultiplayerSessionHandle")] IntPtr oldSessionHandle);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerWriteSessionByHandleAsync(
            //  [NativeTypeName("XblContextHandle")] IntPtr xblContext,
            //  [NativeTypeName("XblMultiplayerSessionHandle")] IntPtr multiplayerSession,
            //  XblMultiplayerSessionWriteMode writeMode,
            //  [NativeTypeName("const char *")] sbyte* handleId,
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerWriteSessionByHandleResult(
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async,
            //  [NativeTypeName("XblMultiplayerSessionHandle *")] IntPtr* handle);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerGetSessionAsync(
            //  [NativeTypeName("XblContextHandle")] IntPtr xblContext,
            //  [NativeTypeName("const XblMultiplayerSessionReference *")] XblMultiplayerSessionReference* sessionReference,
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerGetSessionResult(
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async,
            //  [NativeTypeName("XblMultiplayerSessionHandle *")] IntPtr* handle);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerGetSessionByHandleAsync(
            //  [NativeTypeName("XblContextHandle")] IntPtr xblContext,
            //  [NativeTypeName("const char *")] sbyte* handleId,
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerGetSessionByHandleResult(
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async,
            //  [NativeTypeName("XblMultiplayerSessionHandle *")] IntPtr* handle);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerQuerySessionsAsync(
            //  [NativeTypeName("XblContextHandle")] IntPtr xblContext,
            //  [NativeTypeName("const XblMultiplayerSessionQuery *")] XblMultiplayerSessionQuery* sessionQuery,
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerQuerySessionsResultCount(
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async,
            //  [NativeTypeName("size_t *")] SizeT* sessionCount);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerQuerySessionsResult(
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async,
            //  [NativeTypeName("size_t")] SizeT sessionCount,
            //  XblMultiplayerSessionQueryResult* sessions);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerSetActivityAsync(
            //  [NativeTypeName("XblContextHandle")] IntPtr xblContext,
            //  [NativeTypeName("const XblMultiplayerSessionReference *")] XblMultiplayerSessionReference* sessionReference,
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerClearActivityAsync(
            //  [NativeTypeName("XblContextHandle")] IntPtr xblContext,
            //  [NativeTypeName("const char *")] sbyte* scid,
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerSendInvitesAsync(
            //  [NativeTypeName("XblContextHandle")] IntPtr xblContext,
            //  [NativeTypeName("const XblMultiplayerSessionReference *")] XblMultiplayerSessionReference* sessionReference,
            //  [NativeTypeName("const uint64_t *")] ulong* xuids,
            //  [NativeTypeName("size_t")] SizeT xuidsCount,
            //  [NativeTypeName("uint32_t")] uint titleId,
            //  [NativeTypeName("const char *")] sbyte* contextStringId,
            //  [NativeTypeName("const char *")] sbyte* customActivationContext,
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerSendInvitesResult(
            //  [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async,
            //  [NativeTypeName("size_t")] SizeT handlesCount,
            //  XblMultiplayerInviteHandle* handles);

            /// <summary>
            /// Wraps the underlying native XblMultiplayerSessionPropertiesSetKeywords API:
            /// </summary>
            /// <param name="sessionHandle"></param>
            /// <param name="keywords"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            //public static int XblMultiplayerSessionPropertiesSetKeywords(
            //    XblMultiplayerSessionHandle sessionHandle,
            //    string[] keywords)
            //{
            //}

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerSessionRoleTypes(
            //  [NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle,
            //  [NativeTypeName("const XblMultiplayerRoleType **")] XblMultiplayerRoleType** roleTypes,
            //  [NativeTypeName("size_t *")] SizeT* roleTypesCount);
            //public static int XblMultiplayerSessionRoleTypes(
            //    XblMultiplayerSessionHandle sessionHandle,
            //    out XblMultiplayerRoleType[] roleTypes)
            //{ }

            //[DllImport("Microsoft_Xbox_Services_141_GDK_C_Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            //[return: NativeTypeName("HRESULT")]
            //public static extern int XblMultiplayerSessionGetRoleByName(
            //  [NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle,
            //  [NativeTypeName("const char *")] sbyte* roleTypeName,
            //  [NativeTypeName("const char *")] sbyte* roleName,
            //  [NativeTypeName("const XblMultiplayerRole **")] XblMultiplayerRole** role);
            //public static int XblMultiplayerSessionGetRoleByName(
            //    XblMultiplayerSessionHandle sessionHandle,
            //    string roleTypeName,
            //    string roleName,
            //    out XblMultiplayerRole role)
            //{ }
        }
    }
}
