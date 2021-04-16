using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblLeaderboardQueryType : uint32_t
    //{
    //    UserStatBacked = 0,
    //    TitleManagedStatBackedGlobal = 1,
    //    TitleManagedStatBackedSocial = 2,
    //};
    public enum XblLeaderboardQueryType : UInt32
    {
        UserStatBacked = 0,
        TitleManagedStatBackedGlobal = 1,
        TitleManagedStatBackedSocial = 2,
    }
}