using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblPermissionDenyReason : uint32_t
    //{
    //    Unknown = 0,
    //    NotAllowed = 2,
    //    MissingPrivilege = 3,
    //    PrivilegeRestrictsTarget = 4,
    //    BlockListRestrictsTarget = 5,
    //    MuteListRestrictsTarget = 7,
    //    PrivacySettingsRestrictsTarget = 9
    //};
    public enum XblPermissionDenyReason : UInt32
    {
        Unknown = 0,
        NotAllowed = 2,
        MissingPrivilege = 3,
        PrivilegeRestrictsTarget = 4,
        BlockListRestrictsTarget = 5,
        MuteListRestrictsTarget = 7,
        PrivacySettingsRestrictsTarget = 9,
    }
}