using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblMultiplayerEventType : uint32_t
    //{
    //    UserAdded,
    //    UserRemoved,
    //    MemberJoined,
    //    MemberLeft,
    //    MemberPropertyChanged,
    //    LocalMemberPropertyWriteCompleted,
    //    LocalMemberConnectionAddressWriteCompleted,
    //    SessionPropertyChanged,
    //    SessionPropertyWriteCompleted,
    //    SessionSynchronizedPropertyWriteCompleted,
    //    HostChanged,
    //    SynchronizedHostWriteCompleted,
    //    JoinabilityStateChanged,
    //    PerformQosMeasurements,
    //    FindMatchCompleted,
    //    JoinGameCompleted,
    //    LeaveGameCompleted,
    //    JoinLobbyCompleted,
    //    ClientDisconnectedFromMultiplayerService,
    //    InviteSent,
    //    TournamentRegistrationStateChanged,
    //    TournamentGameSessionReady,
    //    ArbitrationComplete
    //};
    public enum XblMultiplayerEventType : UInt32
    {
        UserAdded = 0,
        UserRemoved = 1,
        MemberJoined = 2,
        MemberLeft = 3,
        MemberPropertyChanged = 4,
        LocalMemberPropertyWriteCompleted = 5,
        LocalMemberConnectionAddressWriteCompleted = 6,
        SessionPropertyChanged = 7,
        SessionPropertyWriteCompleted = 8,
        SessionSynchronizedPropertyWriteCompleted = 9,
        HostChanged = 10,
        SynchronizedHostWriteCompleted = 11,
        JoinabilityStateChanged = 12,
        PerformQosMeasurements = 13,
        FindMatchCompleted = 14,
        JoinGameCompleted = 15,
        LeaveGameCompleted = 16,
        JoinLobbyCompleted = 17,
        ClientDisconnectedFromMultiplayerService = 18,
        InviteSent = 19,
        /// <summary>
        /// Deprecated
        /// </summary>
        TournamentRegistrationStateChanged = 20,
        /// <summary>
        /// Deprecated
        /// </summary>
        TournamentGameSessionReady = 21,
        /// <summary>
        /// Deprecated
        /// </summary>
        ArbitrationComplete = 22,
    }
}