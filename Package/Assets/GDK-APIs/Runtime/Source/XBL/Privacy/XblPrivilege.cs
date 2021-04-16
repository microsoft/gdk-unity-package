using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblPrivilege : uint32_t
    //{
    //    Unknown = 0,
    //    AllowIngameVoiceCommunications = 205,
    //    AllowVideoCommunications = 235,
    //    AllowProfileViewing = 249,
    //    AllowCommunications = 252,
    //    AllowMultiplayer = 254,
    //    AllowAddFriend = 255
    //};
    public enum XblPrivilege : UInt32
    {
        Unknown = 0,
        AllowIngameVoiceCommunications = 205,
        AllowVideoCommunications = 235,
        AllowProfileViewing = 249,
        AllowCommunications = 252,
        AllowMultiplayer = 254,
        AllowAddFriend = 255,
    }
}