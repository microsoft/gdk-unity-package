using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerRole
    //{
    //    XblMultiplayerRoleType* RoleType;
    //    const char* Name;
    //    uint64_t* MemberXuids;
    //    uint32_t MemberCount;
    //    uint32_t TargetCount;
    //    uint32_t MaxMemberCount;
    //} XblMultiplayerRole;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerRole
    {
        private readonly unsafe XblMultiplayerRoleType* RoleType;
        internal readonly UTF8StringPtr Name;
        private readonly unsafe UInt64* MemberXuids;
        internal readonly UInt32 MemberCount;
        internal readonly UInt32 TargetCount;
        internal readonly UInt32 MaxMemberCount;

        internal T GetRoleType<T>(Func<XblMultiplayerRoleType, T> ctor) where T : class { unsafe { return Converters.PtrToClass((IntPtr)RoleType, ctor); } }
        internal T[] GetMemberXuids<T>(Func<UInt64, T> ctor) { unsafe { return Converters.PtrToClassArray<T, UInt64>((IntPtr)this.MemberXuids, this.MemberCount, ctor); } }
    }
}