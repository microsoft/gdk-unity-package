using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblMultiplayerSessionVisibility : uint32_t
    //{
    //    Unknown,
    //    Any,
    //    PrivateSession,
    //    Visible,
    //    Full,
    //    Open
    //};
    public enum XblMultiplayerSessionVisibility : UInt32
    {
        Unknown = 0,
        Any = 1,
        PrivateSession = 2,
        Visible = 3,
        Full = 4,
        Open = 5,
    }
}