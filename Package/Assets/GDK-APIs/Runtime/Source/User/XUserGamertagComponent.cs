using System;

namespace XGamingRuntime
{
    // enum class XUserGamertagComponent : uint32_t
    // {
    //     Classic         = 0, // Clasic Gamertag
    //     Modern          = 1, // Modern Gamertag without Suffix
    //     ModernSuffix    = 2, // Modern Gamertag Suffix if present (otherwise empty)
    //     UniqueModern    = 3, // Combined Modern Gamertag with Suffix
    // };

    public enum XUserGamertagComponent : UInt32
    {
        Classic = 0,
        Modern = 1,
        ModernSuffix = 2,
        UniqueModern = 3
    }
}
