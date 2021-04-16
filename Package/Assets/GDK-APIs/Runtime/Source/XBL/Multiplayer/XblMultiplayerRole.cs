using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerRole
    {
        internal XblMultiplayerRole(Interop.XblMultiplayerRole interopStruct)
        {
            this.RoleType = interopStruct.GetRoleType(x =>new XblMultiplayerRoleType(x));
            this.Name = interopStruct.Name.GetString();
            this.MemberXuids = interopStruct.GetMemberXuids(x =>x);
            this.TargetCount = interopStruct.TargetCount;
            this.MaxMemberCount = interopStruct.MaxMemberCount;
        }

        public XblMultiplayerRoleType RoleType { get; private set; }
        public string Name { get; private set; }
        public UInt64[] MemberXuids { get; private set; }
        public UInt32 TargetCount { get; private set; }
        public UInt32 MaxMemberCount { get; private set; }
    }
}