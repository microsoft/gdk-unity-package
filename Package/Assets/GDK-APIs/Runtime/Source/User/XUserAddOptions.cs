using System;

namespace XGamingRuntime
{
    [Flags]
    public enum XUserAddOptions : UInt32
    {
        None = 0x00,
        AddDefaultUserSilently = 0x01,
        AllowGuests = 0x02,
        AddDefaultUserAllowingUI = 0x04,
    }
}
