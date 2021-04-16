using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblMultiplayerJoinability : uint32_t
    //{
    //    None,
    //    JoinableByFriends,
    //    InviteOnly,
    //    DisableWhileGameInProgress,
    //    Closed
    //};
    public enum XblMultiplayerJoinability : UInt32
    {
        None = 0,
        JoinableByFriends = 1,
        InviteOnly = 2,
        DisableWhileGameInProgress = 3,
        Closed = 4,
    }
}