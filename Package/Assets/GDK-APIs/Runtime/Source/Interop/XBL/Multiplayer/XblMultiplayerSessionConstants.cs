using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionConstants
    //{
    //    uint32_t MaxMembersInSession;
    //    XblMultiplayerSessionVisibility Visibility;
    //    uint64_t* InitiatorXuids;
    //    size_t InitiatorXuidsCount;
    //    const char* CustomJson;
    //    const char* SessionCloudComputePackageConstantsJson;
    //    uint64_t MemberReservedTimeout;
    //    uint64_t MemberInactiveTimeout;
    //    uint64_t MemberReadyTimeout;
    //    uint64_t SessionEmptyTimeout;
    //    XBL_DEPRECATED uint64_t ArbitrationTimeout;
    //    XBL_DEPRECATED uint64_t ForfeitTimeout;
    //    bool EnableMetricsLatency;
    //    bool EnableMetricsBandwidthDown;
    //    bool EnableMetricsBandwidthUp;
    //    bool EnableMetricsCustom;
    //    XblMultiplayerMemberInitialization* MemberInitialization;
    //    XblMultiplayerPeerToPeerRequirements PeerToPeerRequirements;
    //    XblMultiplayerPeerToHostRequirements PeerToHostRequirements;
    //    const char* MeasurementServerAddressesJson;
    //    bool ClientMatchmakingCapable;
    //    XblMultiplayerSessionCapabilities SessionCapabilities;
    //} XblMultiplayerSessionConstants;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerSessionConstants
    {
        internal readonly UInt32 MaxMembersInSession;
        internal readonly XblMultiplayerSessionVisibility Visibility;
        private readonly unsafe UInt64* InitiatorXuids;
        internal readonly SizeT InitiatorXuidsCount;
        internal readonly UTF8StringPtr CustomJson;
        internal readonly UTF8StringPtr SessionCloudComputePackageConstantsJson;
        internal readonly UInt64 MemberReservedTimeout;
        internal readonly UInt64 MemberInactiveTimeout;
        internal readonly UInt64 MemberReadyTimeout;
        internal readonly UInt64 SessionEmptyTimeout;
        internal readonly UInt64 ArbitrationTimeout;
        internal readonly UInt64 ForfeitTimeout;
        internal readonly NativeBool EnableMetricsLatency;
        internal readonly NativeBool EnableMetricsBandwidthDown;
        internal readonly NativeBool EnableMetricsBandwidthUp;
        internal readonly NativeBool EnableMetricsCustom;
        private readonly unsafe XblMultiplayerMemberInitialization* MemberInitialization;
        internal readonly XblMultiplayerPeerToPeerRequirements PeerToPeerRequirements;
        internal readonly XblMultiplayerPeerToHostRequirements PeerToHostRequirements;
        internal readonly UTF8StringPtr MeasurementServerAddressesJson;
        internal readonly NativeBool ClientMatchmakingCapable;
        internal readonly XblMultiplayerSessionCapabilities SessionCapabilities;

        internal T[] GetInitiatorXuids<T>(Func<UInt64,T> ctor) { unsafe { return Converters.PtrToClassArray<T, UInt64>((IntPtr)this.InitiatorXuids, this.InitiatorXuidsCount, ctor); } }
        internal T GetMemberInitialization<T>(Func<XblMultiplayerMemberInitialization, T> ctor) where T : class { unsafe { return Converters.PtrToClass((IntPtr)MemberInitialization, ctor); } }
    }
}