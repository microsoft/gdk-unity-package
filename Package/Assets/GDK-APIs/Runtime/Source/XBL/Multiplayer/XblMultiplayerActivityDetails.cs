using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerActivityDetails
    {
        internal XblMultiplayerActivityDetails(Interop.XblMultiplayerActivityDetails interopStruct)
        {
            this.SessionReference = new XblMultiplayerSessionReference(interopStruct.SessionReference);
            this.HandleId = interopStruct.GetHandleId();
            this.TitleId = interopStruct.TitleId;
            this.Visibility = interopStruct.Visibility;
            this.JoinRestriction = interopStruct.JoinRestriction;
            this.Closed = interopStruct.Closed.Value;
            this.OwnerXuid = interopStruct.OwnerXuid;
            this.MaxMembersCount = interopStruct.MaxMembersCount;
            this.MembersCount = interopStruct.MembersCount;
            this.CustomSessionPropertiesJson = interopStruct.CustomSessionPropertiesJson.GetString();
        }

        public XblMultiplayerSessionReference SessionReference { get; private set; }
        public string HandleId { get; private set; }
        public UInt32 TitleId { get; private set; }
        public XblMultiplayerSessionVisibility Visibility { get; private set; }
        public XblMultiplayerSessionRestriction JoinRestriction { get; private set; }
        public bool Closed { get; private set; }
        public UInt64 OwnerXuid { get; private set; }
        public UInt32 MaxMembersCount { get; private set; }
        public UInt32 MembersCount { get; private set; }
        public string CustomSessionPropertiesJson { get; private set; }
    }
}