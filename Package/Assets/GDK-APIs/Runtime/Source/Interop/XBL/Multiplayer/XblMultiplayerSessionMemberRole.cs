using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionMemberRole
    //{
    //    const char* roleTypeName;
    //    const char* roleName;
    //} XblMultiplayerSessionMemberRole;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerSessionMemberRole
    {
        internal readonly UTF8StringPtr roleTypeName;
        internal readonly UTF8StringPtr roleName;

        internal XblMultiplayerSessionMemberRole(XGamingRuntime.XblMultiplayerSessionMemberRole publicObject, DisposableCollection disposableCollection)
        {
            this.roleTypeName = new UTF8StringPtr(publicObject.RoleTypeName, disposableCollection);
            this.roleName = new UTF8StringPtr(publicObject.RoleName, disposableCollection);
        }
    }
}