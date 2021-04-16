using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerPeerToPeerRequirements
    {
        internal XblMultiplayerPeerToPeerRequirements(Interop.XblMultiplayerPeerToPeerRequirements interopStruct)
        {
            this.LatencyMaximum = interopStruct.LatencyMaximum;
            this.BandwidthMinimumInKbps = interopStruct.BandwidthMinimumInKbps;
        }

        public UInt64 LatencyMaximum { get; private set; }
        public UInt64 BandwidthMinimumInKbps { get; private set; }
    }
}