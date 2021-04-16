using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblMutableRoleSettings : uint32_t
    //{
    //    None = 0x0,
    //    Max = 0x1,
    //    Target = 0x2
    //};
    [Flags]
    public enum XblMutableRoleSettings : UInt32
    {
        None = 0,
        Max = 1,
        Target = 2,
    }
}