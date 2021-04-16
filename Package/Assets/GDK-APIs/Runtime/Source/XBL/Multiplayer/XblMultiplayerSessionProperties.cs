using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionProperties
    {
        internal XblMultiplayerSessionProperties(Interop.XblMultiplayerSessionProperties interopStruct)
        {
            this.Keywords = interopStruct.GetKeywords(x =>x.GetString());
            this.JoinRestriction = interopStruct.JoinRestriction;
            this.ReadRestriction = interopStruct.ReadRestriction;
            this.TurnCollection = interopStruct.GetTurnCollection(x =>x);
            this.MatchmakingTargetSessionConstantsJson = interopStruct.MatchmakingTargetSessionConstantsJson.GetString();
            this.SessionCustomPropertiesJson = interopStruct.SessionCustomPropertiesJson.GetString();
            this.MatchmakingServerConnectionString = interopStruct.MatchmakingServerConnectionString.GetString();
            this.ServerConnectionStringCandidates = interopStruct.GetServerConnectionStringCandidates(x =>x.GetString());
            this.SessionOwnerMemberIds = interopStruct.GetSessionOwnerMemberIds(x =>x);
            this.HostDeviceToken = new XblDeviceToken(interopStruct.HostDeviceToken);
            this.Closed = interopStruct.Closed.Value;
            this.Locked = interopStruct.Locked.Value;
            this.AllocateCloudCompute = interopStruct.AllocateCloudCompute.Value;
            this.MatchmakingResubmit = interopStruct.MatchmakingResubmit.Value;
        }

        public string[] Keywords { get; private set; }
        public XblMultiplayerSessionRestriction JoinRestriction { get; private set; }
        public XblMultiplayerSessionRestriction ReadRestriction { get; private set; }
        public UInt32[] TurnCollection { get; private set; }
        public string MatchmakingTargetSessionConstantsJson { get; private set; }
        public string SessionCustomPropertiesJson { get; private set; }
        public string MatchmakingServerConnectionString { get; private set; }
        public string[] ServerConnectionStringCandidates { get; private set; }
        public UInt32[] SessionOwnerMemberIds { get; private set; }
        public XblDeviceToken HostDeviceToken { get; private set; }
        public bool Closed { get; private set; }
        public bool Locked { get; private set; }
        public bool AllocateCloudCompute { get; private set; }
        public bool MatchmakingResubmit { get; private set; }
    }
}