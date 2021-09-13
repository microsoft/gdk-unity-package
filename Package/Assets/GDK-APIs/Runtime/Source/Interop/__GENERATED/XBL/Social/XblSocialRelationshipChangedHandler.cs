using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void XblSocialRelationshipChangedHandler([NativeTypeName("const XblSocialRelationshipChangeEventArgs *")] XblSocialRelationshipChangeEventArgs* eventArgs, IntPtr context);
}
