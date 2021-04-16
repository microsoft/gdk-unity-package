using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerActivityInfo
    {
        public XblMultiplayerActivityInfo()
        {
        }

        internal XblMultiplayerActivityInfo(Interop.XblMultiplayerActivityInfo interopStruct)
        {
            this.Xuid = interopStruct.xuid;
            this.ConnectionString = interopStruct.connectionString.GetString();
            this.JoinRestriction = interopStruct.joinRestriction;
            this.MaxPlayers = interopStruct.maxPlayers.ToInt32();
            this.CurrentPlayers = interopStruct.currentPlayers.ToInt32();
            this.GroupId = interopStruct.groupId.GetString();
            this.Platform = interopStruct.platform;
        }

        public UInt64 Xuid { get; set; }
        public string ConnectionString { get; set; }
        public XblMultiplayerActivityJoinRestriction JoinRestriction { get; set; }
        public Int32 MaxPlayers { get; set; }
        public Int32 CurrentPlayers { get; set; }
        public string GroupId { get; set; }
        public XblMultiplayerActivityPlatform Platform { get; set; }
    }
}