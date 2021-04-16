using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblMultiplayerMetrics : uint32_t
    //{
    //    Unknown,
    //    BandwidthUp,
    //    BandwidthDown,
    //    Bandwidth,
    //    Latency
    //};
    public enum XblMultiplayerMetrics : UInt32
    {
        Unknown = 0,
        BandwidthUp = 1,
        BandwidthDown = 2,
        Bandwidth = 3,
        Latency = 4,
    }
}