using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblMultiplayerActivityJoinRestriction : uint32_t
    //{
    //    Public = 0,
    //    InviteOnly = 1,
    //    Followed = 2
    //};
    public enum XblMultiplayerActivityJoinRestriction : UInt32
    {
        Public = 0,
        InviteOnly = 1,
        Followed = 2,
    }
}