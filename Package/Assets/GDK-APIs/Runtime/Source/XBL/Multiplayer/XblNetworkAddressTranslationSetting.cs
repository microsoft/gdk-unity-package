using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblNetworkAddressTranslationSetting : uint32_t
    //{
    //    Unknown,
    //    Open,
    //    Moderate,
    //    Strict
    //};
    public enum XblNetworkAddressTranslationSetting : UInt32
    {
        Unknown = 0,
        Open = 1,
        Moderate = 2,
        Strict = 3,
    }
}