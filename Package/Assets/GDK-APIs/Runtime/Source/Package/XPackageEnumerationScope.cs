using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XPackageEnumerationScope : uint32_t
    //{
    //    ThisOnly,
    //    ThisAndRelated
    //};
    public enum XPackageEnumerationScope : UInt32
    {
        ThisOnly = 0,
        ThisAndRelated = 1,
    }
}