using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerPeerToHostRequirements
    //{
    //    uint64_t LatencyMaximum;
    //    uint64_t BandwidthDownMinimumInKbps;
    //    uint64_t BandwidthUpMinimumInKbps;
    //    XblMultiplayerMetrics HostSelectionMetric;
    //} XblMultiplayerPeerToHostRequirements;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerPeerToHostRequirements
    {
        internal readonly UInt64 LatencyMaximum;
        internal readonly UInt64 BandwidthDownMinimumInKbps;
        internal readonly UInt64 BandwidthUpMinimumInKbps;
        internal readonly XblMultiplayerMetrics HostSelectionMetric;

        internal XblMultiplayerPeerToHostRequirements(XGamingRuntime.XblMultiplayerPeerToHostRequirements publicObject)
        {
            this.LatencyMaximum = publicObject.LatencyMaximum;
            this.BandwidthDownMinimumInKbps = publicObject.BandwidthDownMinimumInKbps;
            this.BandwidthUpMinimumInKbps = publicObject.BandwidthUpMinimumInKbps;
            this.HostSelectionMetric = publicObject.HostSelectionMetric;
        }
    }
}