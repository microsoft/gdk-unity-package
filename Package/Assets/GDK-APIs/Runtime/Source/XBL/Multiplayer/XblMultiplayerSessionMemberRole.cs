using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionMemberRole
    {
        internal XblMultiplayerSessionMemberRole(Interop.XblMultiplayerSessionMemberRole interopStruct)
        {
            this.RoleTypeName = interopStruct.roleTypeName.GetString();
            this.RoleName = interopStruct.roleName.GetString();
        }

        public string RoleTypeName { get; private set; }
        public string RoleName { get; private set; }
    }
}