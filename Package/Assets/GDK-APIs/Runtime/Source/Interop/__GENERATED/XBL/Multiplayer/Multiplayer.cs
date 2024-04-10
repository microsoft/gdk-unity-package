using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    public static unsafe partial class Multiplayer
    {
        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionReferenceToUriPath([NativeTypeName("const XblMultiplayerSessionReference *")] XblMultiplayerSessionReference* sessionReference, XblMultiplayerSessionReferenceUri* sessionReferenceUri);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionDuplicateHandle([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("XblMultiplayerSessionHandle *")] IntPtr* duplicatedHandle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("time_t")]
        public static extern long XblMultiplayerSessionTimeOfSession([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const XblMultiplayerSessionInitializationInfo *")]
        public static extern XblMultiplayerSessionInitializationInfo* XblMultiplayerSessionGetInitializationInfo([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XblMultiplayerSessionChangeTypes XblMultiplayerSessionSubscribedChangeTypes([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionHostCandidates([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const XblDeviceToken **")] XblDeviceToken** deviceTokens, [NativeTypeName("size_t *")] SizeT* deviceTokensCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const XblMultiplayerSessionReference *")]
        public static extern XblMultiplayerSessionReference* XblMultiplayerSessionSessionReference([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const XblMultiplayerSessionConstants *")]
        public static extern XblMultiplayerSessionConstants* XblMultiplayerSessionSessionConstants([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblMultiplayerSessionConstantsSetMaxMembersInSession([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("uint32_t")] uint maxMembersInSession);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblMultiplayerSessionConstantsSetVisibility([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, XblMultiplayerSessionVisibility visibility);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionConstantsSetTimeouts([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("uint64_t")] ulong memberReservedTimeout, [NativeTypeName("uint64_t")] ulong memberInactiveTimeout, [NativeTypeName("uint64_t")] ulong memberReadyTimeout, [NativeTypeName("uint64_t")] ulong sessionEmptyTimeout);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionConstantsSetArbitrationTimeouts([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("uint64_t")] ulong arbitrationTimeout, [NativeTypeName("uint64_t")] ulong forfeitTimeout);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionConstantsSetQosConnectivityMetrics([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("bool")] byte enableLatencyMetric, [NativeTypeName("bool")] byte enableBandwidthDownMetric, [NativeTypeName("bool")] byte enableBandwidthUpMetric, [NativeTypeName("bool")] byte enableCustomMetric);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionConstantsSetMemberInitialization([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, XblMultiplayerMemberInitialization memberInitialization);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionConstantsSetPeerToPeerRequirements([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, XblMultiplayerPeerToPeerRequirements requirements);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionConstantsSetPeerToHostRequirements([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, XblMultiplayerPeerToHostRequirements requirements);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* measurementServerAddressesJson);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionConstantsSetCapabilities([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, XblMultiplayerSessionCapabilities capabilities);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionConstantsSetCloudComputePackageJson([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* sessionCloudComputePackageConstantsJson);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionPropertiesSetKeywords([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char **")] sbyte** keywords, [NativeTypeName("size_t")] SizeT keywordsCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblMultiplayerSessionPropertiesSetJoinRestriction([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, XblMultiplayerSessionRestriction joinRestriction);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblMultiplayerSessionPropertiesSetReadRestriction([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, XblMultiplayerSessionRestriction readRestriction);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionPropertiesSetTurnCollection([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const uint32_t *")] uint* turnCollectionMemberIds, [NativeTypeName("size_t")] SizeT turnCollectionMemberIdsCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionRoleTypes([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const XblMultiplayerRoleType **")] XblMultiplayerRoleType** roleTypes, [NativeTypeName("size_t *")] SizeT* roleTypesCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionGetRoleByName([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* roleTypeName, [NativeTypeName("const char *")] sbyte* roleName, [NativeTypeName("const XblMultiplayerRole **")] XblMultiplayerRole** role);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionSetMutableRoleSettings([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* roleTypeName, [NativeTypeName("const char *")] sbyte* roleName, [NativeTypeName("uint32_t *")] uint* maxMemberCount, [NativeTypeName("uint32_t *")] uint* targetMemberCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const XblMultiplayerSessionMember *")]
        public static extern XblMultiplayerSessionMember* XblMultiplayerSessionGetMember([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("uint32_t")] uint memberId);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const XblMultiplayerMatchmakingServer *")]
        public static extern XblMultiplayerMatchmakingServer* XblMultiplayerSessionMatchmakingServer([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint XblMultiplayerSessionMembersAccepted([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* XblMultiplayerSessionRawServersJson([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionSetRawServersJson([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* rawServersJson);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* XblMultiplayerSessionEtag([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const XblMultiplayerSessionInfo *")]
        public static extern XblMultiplayerSessionInfo* XblMultiplayerSessionGetInfo([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionAddMemberReservation([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("uint64_t")] ulong xuid, [NativeTypeName("const char *")] sbyte* memberCustomConstantsJson, [NativeTypeName("bool")] byte initializeRequested);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblMultiplayerSessionSetInitializationSucceeded([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("bool")] byte initializationSucceeded);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblMultiplayerSessionSetMatchmakingServerConnectionPath([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* serverConnectionPath);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblMultiplayerSessionSetLocked([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("bool")] byte locked);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblMultiplayerSessionSetAllocateCloudCompute([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("bool")] byte allocateCloudCompute);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XblMultiplayerSessionSetMatchmakingResubmit([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("bool")] byte matchResubmit);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionSetServerConnectionStringCandidates([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char **")] sbyte** serverConnectionStringCandidates, [NativeTypeName("size_t")] SizeT serverConnectionStringCandidatesCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionCurrentUserSetRoles([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const XblMultiplayerSessionMemberRole *")] XblMultiplayerSessionMemberRole* roles, [NativeTypeName("size_t")] SizeT rolesCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionCurrentUserSetMembersInGroup([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr session, [NativeTypeName("uint32_t *")] uint* memberIds, [NativeTypeName("size_t")] SizeT memberIdsCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionCurrentUserSetGroups([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char **")] sbyte** groups, [NativeTypeName("size_t")] SizeT groupsCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionCurrentUserSetEncounters([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char **")] sbyte** encounters, [NativeTypeName("size_t")] SizeT encountersCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionCurrentUserSetQosMeasurements([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* measurements);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionCurrentUserSetCustomPropertyJson([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *")] sbyte* valueJson);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionSetMatchmakingTargetSessionConstantsJson([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* matchmakingTargetSessionConstantsJson);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionSetCustomPropertyJson([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *")] sbyte* valueJson);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSessionDeleteCustomPropertyJson([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr handle, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XblMultiplayerSessionChangeTypes XblMultiplayerSessionCompare([NativeTypeName("XblMultiplayerSessionHandle")] IntPtr currentSessionHandle, [NativeTypeName("XblMultiplayerSessionHandle")] IntPtr oldSessionHandle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerWriteSessionByHandleAsync([NativeTypeName("XblContextHandle")] IntPtr xblContext, [NativeTypeName("XblMultiplayerSessionHandle")] IntPtr multiplayerSession, XblMultiplayerSessionWriteMode writeMode, [NativeTypeName("const char *")] sbyte* handleId, [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerWriteSessionByHandleResult([NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async, [NativeTypeName("XblMultiplayerSessionHandle *")] IntPtr* handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerGetSessionAsync([NativeTypeName("XblContextHandle")] IntPtr xblContext, [NativeTypeName("const XblMultiplayerSessionReference *")] XblMultiplayerSessionReference* sessionReference, [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerGetSessionResult([NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async, [NativeTypeName("XblMultiplayerSessionHandle *")] IntPtr* handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerGetSessionByHandleAsync([NativeTypeName("XblContextHandle")] IntPtr xblContext, [NativeTypeName("const char *")] sbyte* handleId, [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerGetSessionByHandleResult([NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async, [NativeTypeName("XblMultiplayerSessionHandle *")] IntPtr* handle);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerQuerySessionsAsync([NativeTypeName("XblContextHandle")] IntPtr xblContext, [NativeTypeName("const XblMultiplayerSessionQuery *")] XblMultiplayerSessionQuery* sessionQuery, [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerQuerySessionsResultCount([NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async, [NativeTypeName("size_t *")] SizeT* sessionCount);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerQuerySessionsResult([NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async, [NativeTypeName("size_t")] SizeT sessionCount, XblMultiplayerSessionQueryResult* sessions);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSetActivityAsync([NativeTypeName("XblContextHandle")] IntPtr xblContext, [NativeTypeName("const XblMultiplayerSessionReference *")] XblMultiplayerSessionReference* sessionReference, [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerClearActivityAsync([NativeTypeName("XblContextHandle")] IntPtr xblContext, [NativeTypeName("const char *")] sbyte* scid, [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSendInvitesAsync([NativeTypeName("XblContextHandle")] IntPtr xblContext, [NativeTypeName("const XblMultiplayerSessionReference *")] XblMultiplayerSessionReference* sessionReference, [NativeTypeName("const uint64_t *")] ulong* xuids, [NativeTypeName("size_t")] SizeT xuidsCount, [NativeTypeName("uint32_t")] uint titleId, [NativeTypeName("const char *")] sbyte* contextStringId, [NativeTypeName("const char *")] sbyte* customActivationContext, [NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSendInvitesResult([NativeTypeName("XAsyncBlock *")] XAsyncBlockPtr async, [NativeTypeName("size_t")] SizeT handlesCount, XblMultiplayerInviteHandle* handles);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSetTransferHandleAsync([NativeTypeName("XblContextHandle")] IntPtr xblContext, XblMultiplayerSessionReference targetSessionReference, XblMultiplayerSessionReference originSessionReference, XAsyncBlockPtr async);

        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblMultiplayerSetTransferHandleResult(XAsyncBlockPtr async, XblMultiplayerSessionHandleId* handleId);
    }
}
