using System;

namespace XGamingRuntime
{
    [Flags]
    public enum XUserGetTokenAndSignatureOptions : UInt32
    {
        None = 0x00,
        ForceRefresh = 0x01,
        AllUsers = 0x02,
    }
}
