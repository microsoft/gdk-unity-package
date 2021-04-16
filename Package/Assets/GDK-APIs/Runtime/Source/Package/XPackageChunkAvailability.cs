using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XPackageChunkAvailability : uint32_t
    //{
    //    Ready,
    //    Pending,
    //    Installable,
    //    Unavailable
    //};
    public enum XPackageChunkAvailability : UInt32
    {
        Ready = 0,
        Pending = 1,
        Installable = 2,
        Unavailable = 3,
    }
}