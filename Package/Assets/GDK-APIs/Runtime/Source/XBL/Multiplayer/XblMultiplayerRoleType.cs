using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerRoleType
    {
        internal XblMultiplayerRoleType(Interop.XblMultiplayerRoleType interopStruct)
        {
            this.Name = interopStruct.Name.GetString();
            this.OwnerManaged = interopStruct.OwnerManaged.Value;
            this.MutableRoleSettings = interopStruct.MutableRoleSettings;
            this.Roles = interopStruct.GetRoles(x =>new XblMultiplayerRole(x));
        }

        public string Name { get; private set; }
        public bool OwnerManaged { get; private set; }
        public XblMutableRoleSettings MutableRoleSettings { get; private set; }
        public XblMultiplayerRole[] Roles { get; private set; }
    }
}