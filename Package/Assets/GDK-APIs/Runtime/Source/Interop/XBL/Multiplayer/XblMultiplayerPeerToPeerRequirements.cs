using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerPeerToPeerRequirements
    //{
    //    uint64_t LatencyMaximum;
    //    uint64_t BandwidthMinimumInKbps;
    //} XblMultiplayerPeerToPeerRequirements;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerPeerToPeerRequirements
    {
        internal readonly UInt64 LatencyMaximum;
        internal readonly UInt64 BandwidthMinimumInKbps;

        internal XblMultiplayerPeerToPeerRequirements(XGamingRuntime.XblMultiplayerPeerToPeerRequirements publicObject)
        {
            this.LatencyMaximum = publicObject.LatencyMaximum;
            this.BandwidthMinimumInKbps = publicObject.BandwidthMinimumInKbps;
        }
    }
}