using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XStoreProductKind : uint32_t
    //{
    //    None                = 0x00,
    //    Consumable          = 0x01,
    //    Durable             = 0x02,
    //    Game                = 0x04,
    //    Pass                = 0x08,
    //    UnmanagedConsumable = 0x10,
    //};
    [Flags]
    public enum XStoreProductKind : UInt32
    {
        None = 0,
        Consumable = 1,
        Durable = 2,
        Game = 4,
        Pass = 8,
        UnmanagedConsumable = 16,
    }
}