using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerRoleType
    //{
    //    const char* Name;
    //    bool OwnerManaged;
    //    XblMutableRoleSettings MutableRoleSettings;
    //    struct XblMultiplayerRole* Roles;
    //    size_t RoleCount;
    //} XblMultiplayerRoleType;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerRoleType
    {
        internal readonly UTF8StringPtr Name;
        internal readonly NativeBool OwnerManaged;
        internal readonly XblMutableRoleSettings MutableRoleSettings;
        private readonly unsafe XblMultiplayerRole* Roles;
        internal readonly SizeT RoleCount;

        internal T[] GetRoles<T>(Func<XblMultiplayerRole,T> ctor) { unsafe { return Converters.PtrToClassArray<T, XblMultiplayerRole>((IntPtr)this.Roles, this.RoleCount, ctor); } }
    }
}