using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XPackageChunkSelectorType : uint32_t
    //{
    //    Language,
    //    Tag,
    //    Chunk,
    //    Feature
    //};
    public enum XPackageChunkSelectorType : UInt32
    {
        Language = 0,
        Tag = 1,
        Chunk = 2,
        Feature = 3,
    }
}