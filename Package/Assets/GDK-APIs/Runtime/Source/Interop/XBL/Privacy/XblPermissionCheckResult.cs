using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblPermissionCheckResult
    //{
    //    bool isAllowed;
    //    uint64_t targetXuid;
    //    XblPermission permissionRequested;
    //    XblPermissionDenyReasonDetails* reasons;
    //    size_t reasonsCount;
    //} XblPermissionCheckResult;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblPermissionCheckResult
    {
        internal readonly NativeBool isAllowed;
        internal readonly UInt64 targetXuid;
        internal readonly XblAnonymousUserType targetUserType;
        internal readonly XblPermission permissionRequested;
        private readonly unsafe XblPermissionDenyReasonDetails* reasons;
        internal readonly SizeT reasonsCount;

        internal T[] GetReasons<T>(Func<XblPermissionDenyReasonDetails,T> ctor) { unsafe { return Converters.PtrToClassArray<T, XblPermissionDenyReasonDetails>((IntPtr)this.reasons, this.reasonsCount, ctor); } }
    }
}