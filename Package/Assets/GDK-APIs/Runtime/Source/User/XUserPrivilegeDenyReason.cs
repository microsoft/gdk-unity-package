using System;

namespace XGamingRuntime
{
    public enum XUserPrivilegeDenyReason : UInt32
    {
        None = 0,
        PurchaseRequired = 1,
        Restricted = 2,
        Banned = 3,

        Unknown = 0xFFFFFFFF,
    }
}
