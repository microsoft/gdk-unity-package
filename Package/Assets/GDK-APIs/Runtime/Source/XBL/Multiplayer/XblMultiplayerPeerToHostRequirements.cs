using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerPeerToHostRequirements
    {
        internal XblMultiplayerPeerToHostRequirements(Interop.XblMultiplayerPeerToHostRequirements interopStruct)
        {
            this.LatencyMaximum = interopStruct.LatencyMaximum;
            this.BandwidthDownMinimumInKbps = interopStruct.BandwidthDownMinimumInKbps;
            this.BandwidthUpMinimumInKbps = interopStruct.BandwidthUpMinimumInKbps;
            this.HostSelectionMetric = interopStruct.HostSelectionMetric;
        }

        public UInt64 LatencyMaximum { get; private set; }
        public UInt64 BandwidthDownMinimumInKbps { get; private set; }
        public UInt64 BandwidthUpMinimumInKbps { get; private set; }
        public XblMultiplayerMetrics HostSelectionMetric { get; private set; }
    }
}