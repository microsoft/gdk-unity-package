using System;

namespace XGamingRuntime
{
    [Flags]
    public enum XUserPrivilegeOptions : UInt32
    {
        None = 0x00,
        AllUsers = 0x01,
    }
}
