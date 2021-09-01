using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionInitArgs
    {
        public XblMultiplayerSessionInitArgs(
            UInt32 maxMembers,
            XblMultiplayerSessionVisibility visibility,
            string customJson,
            params UInt64[] initiatorXuids)
        {
            this.MaxMembersInSession = maxMembers;
            this.Visibility = visibility;
            this.InitiatorXuids = new ulong[initiatorXuids.Length];
            Array.Copy(initiatorXuids, this.InitiatorXuids, initiatorXuids.Length);
            this.CustomJson = customJson;
        }

        internal XblMultiplayerSessionInitArgs(Interop.XblMultiplayerSessionInitArgs interopStruct)
        {
            this.MaxMembersInSession = interopStruct.MaxMembersInSession;
            this.Visibility = interopStruct.Visibility;
            this.InitiatorXuids = interopStruct.GetInitiatorXuids(x =>x);
            this.CustomJson = interopStruct.CustomJson.GetString();
        }

        public UInt32 MaxMembersInSession { get; private set; }
        public XblMultiplayerSessionVisibility Visibility { get; private set; }
        public UInt64[] InitiatorXuids { get; private set; }
        public string CustomJson { get; private set; }
    }
}