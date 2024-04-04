using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal partial class XblInterop
    {
        //STDAPI XblMultiplayerManagerLobbySessionHost(
        //    _Out_ XblMultiplayerManagerMember* hostMember
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionHost(
            out XblMultiplayerManagerMember hostMember);

        //STDAPI XblMultiplayerEventArgsTournamentRegistrationStateChanged(
        //    _In_ XblMultiplayerEventArgsHandle argsHandle,
        //    _Out_opt_ XblTournamentRegistrationState* registrationState,
        //    _Out_opt_ XblTournamentRegistrationReason* registrationReason
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerEventArgsTournamentRegistrationStateChanged(
            XblMultiplayerEventArgsHandle argsHandle,
            out XblTournamentRegistrationState registrationState,
            out XblTournamentRegistrationReason registrationReason);

        //STDAPI XblMultiplayerEventArgsFindMatchCompleted(
        //    _In_ XblMultiplayerEventArgsHandle argsHandle,
        //    _Out_opt_ XblMultiplayerMatchStatus* matchStatus,
        //    _Out_opt_ XblMultiplayerMeasurementFailure* initializationFailureCause
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerEventArgsFindMatchCompleted(
            XblMultiplayerEventArgsHandle argsHandle,
            out XblMultiplayerMatchStatus matchStatus,
            out XblMultiplayerMeasurementFailure initializationFailureCause);

        //STDAPI XblMultiplayerManagerLobbySessionInviteUsers(
        //    _In_ XblUserHandle user,
        //    _In_ const uint64_t* xuids,
        //    _In_ size_t xuidsCount,
        //    _In_opt_z_ const char* contextStringId,
        //    _In_opt_z_ const char* customActivationContext
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionInviteUsers(
            XUserHandle user,
            [In] UInt64[] xuids,
            SizeT xuidsCount,
            Byte[] contextStringId,
            Byte[] customActivationContext);

        //STDAPI XblMultiplayerManagerLobbySessionInviteUsers(
        //    _In_ XblUserHandle user,
        //    _In_ const uint64_t* xuids,
        //    _In_ size_t xuidsCount,
        //    _In_opt_z_ const char* contextStringId,
        //    _In_opt_z_ const char* customActivationContext
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionInviteUsers(
            IntPtr user,
            [In] UInt64[] xuids,
            SizeT xuidsCount,
            Byte[] contextStringId,
            Byte[] customActivationContext);

        //STDAPI XblMultiplayerManagerJoinLobby(
        //    _In_z_ const char* handleId,
        //    _In_ XblUserHandle user
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerJoinLobby(
            Byte[] handleId,
            XUserHandle user);

        //STDAPI XblMultiplayerManagerJoinLobby(
        //    _In_z_ const char* handleId,
        //    _In_ XblUserHandle user
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerJoinLobby(
            Byte[] handleId,
            IntPtr user);

        //STDAPI XblMultiplayerManagerLobbySessionInviteFriends(
        //    _In_ XblUserHandle requestingUser,
        //    _In_opt_z_ const char* contextStringId,
        //    _In_opt_z_ const char* customActivationContext
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionInviteFriends(
            XUserHandle requestingUser,
            Byte[] contextStringId,
            Byte[] customActivationContext);

        //STDAPI XblMultiplayerManagerLobbySessionInviteFriends(
        //    _In_ XblUserHandle requestingUser,
        //    _In_opt_z_ const char* contextStringId,
        //    _In_opt_z_ const char* customActivationContext
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionInviteFriends(
            IntPtr requestingUser,
            Byte[] contextStringId,
            Byte[] customActivationContext);

        //STDAPI XblMultiplayerManagerSetQosMeasurements(
        //    _In_z_ const char* measurementsJson
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerSetQosMeasurements(
            Byte[] measurementsJson);

        //STDAPI XblMultiplayerManagerSetJoinability(
        //    _In_ XblMultiplayerJoinability joinability,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerSetJoinability(
            XblMultiplayerJoinability joinability,
            IntPtr context);

        //STDAPI XblMultiplayerManagerLobbySessionAddLocalUser(
        //    _In_ XblUserHandle user
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionAddLocalUser(
            XUserHandle user);

        //STDAPI XblMultiplayerManagerLobbySessionAddLocalUser(
        //    _In_ XblUserHandle user
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionAddLocalUser(
            IntPtr user);

        //STDAPI XblMultiplayerEventArgsMembersCount(
        //    _In_ XblMultiplayerEventArgsHandle argsHandle,
        //    _Out_ size_t* memberCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerEventArgsMembersCount(
            XblMultiplayerEventArgsHandle argsHandle,
            out SizeT memberCount);

        //STDAPI XblMultiplayerManagerJoinGameFromLobby(
        //    _In_z_ const char* sessionTemplateName
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerJoinGameFromLobby(
            Byte[] sessionTemplateName);

        //STDAPI_(bool) XblMultiplayerManagerGameSessionIsHost(
        //    _In_ uint64_t xuid
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XblMultiplayerManagerGameSessionIsHost(
            UInt64 xuid);

        //STDAPI XblMultiplayerEventArgsPropertiesJson(
        //    _In_ XblMultiplayerEventArgsHandle argsHandle,
        //    _Out_ const char** properties
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerEventArgsPropertiesJson(
            XblMultiplayerEventArgsHandle argsHandle,
            out UTF8StringPtr properties);

        //STDAPI XblMultiplayerManagerGameSessionHost(
        //    _Out_ XblMultiplayerManagerMember* hostMember
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerGameSessionHost(
            out XblMultiplayerManagerMember hostMember);

        //STDAPI XblMultiplayerManagerLobbySessionSessionReference(
        //    _Out_ XblMultiplayerSessionReference* sessionReference
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionSessionReference(
            out XblMultiplayerSessionReference sessionReference);

        //STDAPI XblMultiplayerManagerLobbySessionSetProperties(
        //    _In_z_ const char* name,
        //    _In_z_ const char* valueJson,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionSetProperties(
            Byte[] name,
            Byte[] valueJson,
            IntPtr context);

        //STDAPI_(void) XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(
        //    _In_ bool autoFillMembers
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(
            NativeBool autoFillMembers);

        //STDAPI XblMultiplayerManagerLobbySessionSetLocalMemberProperties(
        //    _In_ XblUserHandle user,
        //    _In_z_ const char* name,
        //    _In_z_ const char* valueJson,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionSetLocalMemberProperties(
            XUserHandle user,
            Byte[] name,
            Byte[] valueJson,
            IntPtr context);

        //STDAPI XblMultiplayerManagerLobbySessionSetLocalMemberProperties(
        //    _In_ XblUserHandle user,
        //    _In_z_ const char* name,
        //    _In_z_ const char* valueJson,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionSetLocalMemberProperties(
            IntPtr user,
            Byte[] name,
            Byte[] valueJson,
            IntPtr context);

        //STDAPI XblMultiplayerManagerLobbySessionSetSynchronizedProperties(
        //    _In_z_ const char* name,
        //    _In_z_ const char* valueJson,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionSetSynchronizedProperties(
            Byte[] name,
            Byte[] valueJson,
            IntPtr context);

        //STDAPI_(const XblMultiplayerSessionReference*) XblMultiplayerManagerGameSessionSessionReference() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern XblMultiplayerSessionReference* XblMultiplayerManagerGameSessionSessionReference();

        //STDAPI XblMultiplayerEventArgsXuid(
        //    _In_ XblMultiplayerEventArgsHandle argsHandle,
        //    _Out_ uint64_t* xuid
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerEventArgsXuid(
            XblMultiplayerEventArgsHandle argsHandle,
            out UInt64 xuid);

        //STDAPI XblMultiplayerManagerGameSessionSetProperties(
        //    _In_z_ const char* name,
        //    _In_z_ const char* valueJson,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerGameSessionSetProperties(
            Byte[] name,
            Byte[] valueJson,
            IntPtr context);

        //STDAPI XblMultiplayerManagerLobbySessionMembers(
        //    _In_ size_t membersCount,
        //    _Out_writes_(membersCount) XblMultiplayerManagerMember* members
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionMembers(
            SizeT membersCount,
            [Out] XblMultiplayerManagerMember[] members);

        //STDAPI_(XblMultiplayerJoinability) XblMultiplayerManagerJoinability() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern XblMultiplayerJoinability XblMultiplayerManagerJoinability();

        //STDAPI_(const char*) XblMultiplayerManagerLobbySessionPropertiesJson() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern UTF8StringPtr XblMultiplayerManagerLobbySessionPropertiesJson();

        //STDAPI_(void) XblMultiplayerManagerCancelMatch() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern void XblMultiplayerManagerCancelMatch();

        //STDAPI_(uint32_t) XblMultiplayerManagerEstimatedMatchWaitTime() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern UInt32 XblMultiplayerManagerEstimatedMatchWaitTime();
        
        //STDAPI_(const XblMultiplayerSessionConstants*) XblMultiplayerManagerLobbySessionConstants() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern XblMultiplayerSessionConstants* XblMultiplayerManagerLobbySessionConstants();

        //STDAPI XblMultiplayerEventArgsTournamentGameSessionReady(
        //    _In_ XblMultiplayerEventArgsHandle argsHandle,
        //    _Out_ time_t* startTime
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerEventArgsTournamentGameSessionReady(
            XblMultiplayerEventArgsHandle argsHandle,
            out TimeT startTime);

        //STDAPI_(size_t) XblMultiplayerManagerLobbySessionLocalMembersCount() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern SizeT XblMultiplayerManagerLobbySessionLocalMembersCount();

        //STDAPI_(bool) XblMultiplayerManagerGameSessionActive() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XblMultiplayerManagerGameSessionActive();

        //STDAPI XblMultiplayerManagerInitialize(
        //    _In_z_ const char* lobbySessionTemplateName,
        //    _In_opt_ XTaskQueueHandle asyncQueue
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerInitialize(
            Byte[] lobbySessionTemplateName,
            XTaskQueueHandle asyncQueue);

        //STDAPI XblMultiplayerManagerLobbySessionRemoveLocalUser(
        //    _In_ XblUserHandle user
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionRemoveLocalUser(
            XUserHandle user);

        //STDAPI XblMultiplayerManagerLobbySessionRemoveLocalUser(
        //    _In_ XblUserHandle user
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionRemoveLocalUser(
            IntPtr user);

        //STDAPI XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(
        //    _In_ XblUserHandle user,
        //    _In_z_ const char* name,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(
            XUserHandle user,
            Byte[] name,
            IntPtr context);

        //STDAPI XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(
        //    _In_ XblUserHandle user,
        //    _In_z_ const char* name,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(
            IntPtr user,
            Byte[] name,
            IntPtr context);

        //STDAPI XblMultiplayerEventArgsMember(
        //    _In_ XblMultiplayerEventArgsHandle argsHandle,
        //    _Out_ XblMultiplayerManagerMember* member
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerEventArgsMember(
            XblMultiplayerEventArgsHandle argsHandle,
            out XblMultiplayerManagerMember member);

        //STDAPI_(bool) XblMultiplayerManagerMemberAreMembersOnSameDevice(
        //    _In_ const XblMultiplayerManagerMember* first,
        //    _In_ const XblMultiplayerManagerMember* second
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern NativeBool XblMultiplayerManagerMemberAreMembersOnSameDevice(
            [In] ref XblMultiplayerManagerMember first,
            [In] ref XblMultiplayerManagerMember second);

        //STDAPI XblMultiplayerManagerGameSessionSetSynchronizedHost(
        //    _In_ const char* deviceToken,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerGameSessionSetSynchronizedHost(
            Byte[] deviceToken,
            IntPtr context);

        //STDAPI_(const XblTournamentTeamResult*) XblMultiplayerManagerLobbySessionLastTournamentTeamResult() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern XblTournamentTeamResult* XblMultiplayerManagerLobbySessionLastTournamentTeamResult();
        
        //STDAPI XblMultiplayerManagerLeaveGame() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLeaveGame();

        //STDAPI XblMultiplayerEventArgsMembers(
        //    _In_ XblMultiplayerEventArgsHandle argsHandle,
        //    _In_ size_t membersCount,
        //    _Out_writes_(membersCount) XblMultiplayerManagerMember* members
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerEventArgsMembers(
            XblMultiplayerEventArgsHandle argsHandle,
            SizeT membersCount,
            [Out] XblMultiplayerManagerMember[] members);

        //STDAPI_(bool) XblMultiplayerManagerLobbySessionIsHost(
        //    _In_ uint64_t xuid
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XblMultiplayerManagerLobbySessionIsHost(
            UInt64 xuid);

        //STDAPI XblMultiplayerManagerGameSessionSetSynchronizedProperties(
        //    _In_z_ const char* name,
        //    _In_z_ const char* valueJson,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerGameSessionSetSynchronizedProperties(
            Byte[] name,
            Byte[] valueJson,
            IntPtr context);

        //STDAPI_(const char*) XblMultiplayerManagerGameSessionCorrelationId() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern UTF8StringPtr XblMultiplayerManagerGameSessionCorrelationId();

        //STDAPI_(const XblMultiplayerSessionConstants*) XblMultiplayerManagerGameSessionConstants() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern XblMultiplayerSessionConstants* XblMultiplayerManagerGameSessionConstants();

        //STDAPI XblMultiplayerManagerLobbySessionLocalMembers(
        //    _In_ size_t localMembersCount,
        //    _Out_writes_(localMembersCount) XblMultiplayerManagerMember* localMembers
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionLocalMembers(
            SizeT localMembersCount,
            [Out] XblMultiplayerManagerMember[] localMembers);

        //STDAPI_(XblMultiplayerMatchStatus) XblMultiplayerManagerMatchStatus() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern XblMultiplayerMatchStatus XblMultiplayerManagerMatchStatus();

        //STDAPI XblMultiplayerManagerLobbySessionSetSynchronizedHost(
        //    _In_ const char* deviceToken,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionSetSynchronizedHost(
            Byte[] deviceToken,
            IntPtr context);

        //STDAPI_(bool) XblMultiplayerManagerAutoFillMembersDuringMatchmaking() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XblMultiplayerManagerAutoFillMembersDuringMatchmaking();

        //STDAPI XblMultiplayerManagerLobbySessionCorrelationId(
        //    _Out_ XblGuid* correlationId
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionCorrelationId(
            out XblGuid correlationId);

        //STDAPI_(size_t) XblMultiplayerManagerLobbySessionMembersCount() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern SizeT XblMultiplayerManagerLobbySessionMembersCount();

        //STDAPI XblMultiplayerManagerFindMatch(
        //    _In_z_ const char* hopperName,
        //    _In_opt_z_ const char* attributesJson,
        //    _In_ uint32_t timeoutInSeconds
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerFindMatch(
            Byte[] hopperName,
            Byte[] attributesJson,
            UInt32 timeoutInSeconds);

        //STDAPI XblMultiplayerManagerDoWork(
        //    _Deref_out_opt_ const XblMultiplayerEvent** multiplayerEvents,
        //    _Out_ size_t* multiplayerEventsCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern Int32 XblMultiplayerManagerDoWork(
            out IntPtr multiplayerEvents,
            out SizeT multiplayerEventsCount);

        //STDAPI_(bool) XblMultiplayerSessionReferenceIsValid(
        //    _In_ const XblMultiplayerSessionReference* sessionReference
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal unsafe static extern NativeBool XblMultiplayerSessionReferenceIsValid(
            [In] ref XblMultiplayerSessionReference sessionReference);

        //STDAPI XblMultiplayerManagerGameSessionMembers(
        //    _In_ size_t membersCount,
        //    _Out_writes_(membersCount) XblMultiplayerManagerMember* members
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerGameSessionMembers(
            SizeT membersCount,
            [Out] XblMultiplayerManagerMember[] members);

        //STDAPI XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(
        //    _In_ XblUserHandle user,
        //    _In_z_ const char* connectionAddress,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(
            XUserHandle user,
            Byte[] connectionAddress,
            IntPtr context);

        //STDAPI XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(
        //    _In_ XblUserHandle user,
        //    _In_z_ const char* connectionAddress,
        //    _In_opt_ void* context
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(
            IntPtr user,
            Byte[] connectionAddress,
            IntPtr context);

        //STDAPI XblMultiplayerManagerJoinGame(
        //    _In_z_ const char* sessionName,
        //    _In_z_ const char* sessionTemplateName,
        //    _In_opt_ const uint64_t* xuids,
        //    _In_ size_t xuidsCount
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerManagerJoinGame(
            Byte[] sessionName,
            Byte[] sessionTemplateName,
            [In] UInt64[] xuids,
            SizeT xuidsCount);

        //STDAPI_(size_t) XblMultiplayerManagerGameSessionMembersCount() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern SizeT XblMultiplayerManagerGameSessionMembersCount();

        //STDAPI_(const char*) XblMultiplayerManagerGameSessionPropertiesJson() XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern UTF8StringPtr XblMultiplayerManagerGameSessionPropertiesJson();

        //STDAPI XblMultiplayerEventArgsPerformQoSMeasurements(
        //    _In_ XblMultiplayerEventArgsHandle argsHandle,
        //    _Out_ XblMultiplayerPerformQoSMeasurementsArgs* performQoSMeasurementsArgs
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblMultiplayerEventArgsPerformQoSMeasurements(
            XblMultiplayerEventArgsHandle argsHandle,
            out XblMultiplayerPerformQoSMeasurementsArgs performQoSMeasurementsArgs);
    }
}