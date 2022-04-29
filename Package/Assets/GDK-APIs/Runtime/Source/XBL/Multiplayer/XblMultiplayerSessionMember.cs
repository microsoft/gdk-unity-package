using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionMember
    {
        internal XblMultiplayerSessionMember(Interop.XblMultiplayerSessionMember interopStruct)
        {
            this.MemberId = interopStruct.MemberId;
            this.TeamId = interopStruct.TeamId.GetString();
            this.InitialTeam = interopStruct.InitialTeam.GetString();
            this.ArbitrationStatus = interopStruct.ArbitrationStatus;
            this.Xuid = interopStruct.Xuid;
            this.CustomConstantsJson = interopStruct.CustomConstantsJson.GetString();
            this.SecureDeviceBaseAddress64 = interopStruct.SecureDeviceBaseAddress64.GetString();
            this.Roles = interopStruct.GetRoles(x =>new XblMultiplayerSessionMemberRole(x));
            this.CustomPropertiesJson = interopStruct.CustomPropertiesJson.GetString();
            this.Gamertag = interopStruct.GetGamertag();
            this.Status = interopStruct.Status;
            this.IsTurnAvailable = interopStruct.IsTurnAvailable.Value;
            this.IsCurrentUser = interopStruct.IsCurrentUser.Value;
            this.InitializeRequested = interopStruct.InitializeRequested.Value;
            this.MatchmakingResultServerMeasurementsJson = interopStruct.MatchmakingResultServerMeasurementsJson.GetString();
            this.ServerMeasurementsJson = interopStruct.ServerMeasurementsJson.GetString();
            this.MembersInGroupIds = interopStruct.GetMembersInGroupIds(x =>x);
            this.QosMeasurementsJson = interopStruct.QosMeasurementsJson.GetString();
            this.DeviceToken = new XblDeviceToken(interopStruct.DeviceToken);
            this.Nat = interopStruct.Nat;
            this.ActiveTitleId = interopStruct.ActiveTitleId;
            this.InitializationEpisode = interopStruct.InitializationEpisode;
            this.JoinTime = interopStruct.JoinTime.DateTime;
            this.InitializationFailureCause = interopStruct.InitializationFailureCause;
            this.Groups = interopStruct.GetGroups(x =>x.GetString());
            this.Encounters = interopStruct.GetEncounters(x =>x.GetString());
            this.TournamentTeamSessionReference = new XblMultiplayerSessionReference(interopStruct.TournamentTeamSessionReference);
            this.Internal = interopStruct.Internal;
        }

        public UInt32 MemberId { get; private set; }
        /// <summary>
        /// Deprecated
        /// </summary>
        public string TeamId { get; private set; }
        public string InitialTeam { get; private set; }
        /// <summary>
        /// Deprecated
        /// </summary>
        public XblTournamentArbitrationStatus ArbitrationStatus { get; private set; }
        public UInt64 Xuid { get; private set; }
        public string CustomConstantsJson { get; private set; }
        public string SecureDeviceBaseAddress64 { get; private set; }
        public XblMultiplayerSessionMemberRole[] Roles { get; private set; }
        public string CustomPropertiesJson { get; private set; }
        public string Gamertag { get; private set; }
        public XblMultiplayerSessionMemberStatus Status { get; private set; }
        public bool IsTurnAvailable { get; private set; }
        public bool IsCurrentUser { get; private set; }
        public bool InitializeRequested { get; private set; }
        public string MatchmakingResultServerMeasurementsJson { get; private set; }
        public string ServerMeasurementsJson { get; private set; }
        public UInt32[] MembersInGroupIds { get; private set; }
        public string QosMeasurementsJson { get; private set; }
        public XblDeviceToken DeviceToken { get; private set; }
        public XblNetworkAddressTranslationSetting Nat { get; private set; }
        public UInt32 ActiveTitleId { get; private set; }
        public UInt32 InitializationEpisode { get; private set; }
        public DateTime JoinTime { get; private set; }
        public XblMultiplayerMeasurementFailure InitializationFailureCause { get; private set; }
        public string[] Groups { get; private set; }
        public string[] Encounters { get; private set; }
        /// <summary>
        /// Deprecated
        /// </summary>
        public XblMultiplayerSessionReference TournamentTeamSessionReference { get; private set; }
        public IntPtr Internal { get; private set; }
    }
}