using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionConstants
    {
        internal XblMultiplayerSessionConstants(Interop.XblMultiplayerSessionConstants interopStruct)
        {
            this.MaxMembersInSession = interopStruct.MaxMembersInSession;
            this.Visibility = interopStruct.Visibility;
            this.InitiatorXuids = interopStruct.GetInitiatorXuids(x =>x);
            this.CustomJson = interopStruct.CustomJson.GetString();
            this.SessionCloudComputePackageConstantsJson = interopStruct.SessionCloudComputePackageConstantsJson.GetString();
            this.MemberReservedTimeout = interopStruct.MemberReservedTimeout;
            this.MemberInactiveTimeout = interopStruct.MemberInactiveTimeout;
            this.MemberReadyTimeout = interopStruct.MemberReadyTimeout;
            this.SessionEmptyTimeout = interopStruct.SessionEmptyTimeout;
            this.ArbitrationTimeout = interopStruct.ArbitrationTimeout;
            this.ForfeitTimeout = interopStruct.ForfeitTimeout;
            this.EnableMetricsLatency = interopStruct.EnableMetricsLatency.Value;
            this.EnableMetricsBandwidthDown = interopStruct.EnableMetricsBandwidthDown.Value;
            this.EnableMetricsBandwidthUp = interopStruct.EnableMetricsBandwidthUp.Value;
            this.EnableMetricsCustom = interopStruct.EnableMetricsCustom.Value;
            this.MemberInitialization = interopStruct.GetMemberInitialization(x =>new XblMultiplayerMemberInitialization(x));
            this.PeerToPeerRequirements = new XblMultiplayerPeerToPeerRequirements(interopStruct.PeerToPeerRequirements);
            this.PeerToHostRequirements = new XblMultiplayerPeerToHostRequirements(interopStruct.PeerToHostRequirements);
            this.MeasurementServerAddressesJson = interopStruct.MeasurementServerAddressesJson.GetString();
            this.ClientMatchmakingCapable = interopStruct.ClientMatchmakingCapable.Value;
            this.SessionCapabilities = new XblMultiplayerSessionCapabilities(interopStruct.SessionCapabilities);
        }

        public UInt32 MaxMembersInSession { get; private set; }
        public XblMultiplayerSessionVisibility Visibility { get; private set; }
        public UInt64[] InitiatorXuids { get; private set; }
        public string CustomJson { get; private set; }
        public string SessionCloudComputePackageConstantsJson { get; private set; }
        public UInt64 MemberReservedTimeout { get; private set; }
        public UInt64 MemberInactiveTimeout { get; private set; }
        public UInt64 MemberReadyTimeout { get; private set; }
        public UInt64 SessionEmptyTimeout { get; private set; }
        /// <summary>
        /// Deprecated
        /// </summary>
        public UInt64 ArbitrationTimeout { get; private set; }
        /// <summary>
        /// Deprecated
        /// </summary>
        public UInt64 ForfeitTimeout { get; private set; }
        public bool EnableMetricsLatency { get; private set; }
        public bool EnableMetricsBandwidthDown { get; private set; }
        public bool EnableMetricsBandwidthUp { get; private set; }
        public bool EnableMetricsCustom { get; private set; }
        public XblMultiplayerMemberInitialization MemberInitialization { get; private set; }
        public XblMultiplayerPeerToPeerRequirements PeerToPeerRequirements { get; private set; }
        public XblMultiplayerPeerToHostRequirements PeerToHostRequirements { get; private set; }
        public string MeasurementServerAddressesJson { get; private set; }
        public bool ClientMatchmakingCapable { get; private set; }
        public XblMultiplayerSessionCapabilities SessionCapabilities { get; private set; }
    }
}