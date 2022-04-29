using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerManagerMember
    {
        internal XblMultiplayerManagerMember(Interop.XblMultiplayerManagerMember interopStruct)
        {
            this.MemberId = interopStruct.MemberId;
            this.TeamId = interopStruct.TeamId.GetString();
            this.InitialTeam = interopStruct.InitialTeam.GetString();
            this.Xuid = interopStruct.Xuid;
            this.DebugGamertag = interopStruct.DebugGamertag.GetString();
            this.IsLocal = interopStruct.IsLocal.Value;
            this.IsInLobby = interopStruct.IsInLobby.Value;
            this.IsInGame = interopStruct.IsInGame.Value;
            this.Status = interopStruct.Status;
            this.ConnectionAddress = interopStruct.ConnectionAddress.GetString();
            this.PropertiesJson = interopStruct.PropertiesJson.GetString();
            this.DeviceToken = interopStruct.DeviceToken.GetString();
        }

        public UInt32 MemberId { get; private set; }
        /// <summary>
        /// Deprecated
        /// </summary>
        public string TeamId { get; private set; }
        public string InitialTeam { get; private set; }
        public UInt64 Xuid { get; private set; }
        public string DebugGamertag { get; private set; }
        public bool IsLocal { get; private set; }
        public bool IsInLobby { get; private set; }
        public bool IsInGame { get; private set; }
        public XblMultiplayerSessionMemberStatus Status { get; private set; }
        public string ConnectionAddress { get; private set; }
        public string PropertiesJson { get; private set; }
        public string DeviceToken { get; private set; }
    }
}