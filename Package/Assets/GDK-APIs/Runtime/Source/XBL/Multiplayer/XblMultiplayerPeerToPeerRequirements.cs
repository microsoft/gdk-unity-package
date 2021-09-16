using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerPeerToPeerRequirements
    {
        public XblMultiplayerPeerToPeerRequirements() { }

        internal XblMultiplayerPeerToPeerRequirements(Interop.XblMultiplayerPeerToPeerRequirements interopStruct)
        {
            this.LatencyMaximum = interopStruct.LatencyMaximum;
            this.BandwidthMinimumInKbps = interopStruct.BandwidthMinimumInKbps;
        }

        public UInt64 LatencyMaximum { get; set; }
        public UInt64 BandwidthMinimumInKbps { get; set; }
    }
}