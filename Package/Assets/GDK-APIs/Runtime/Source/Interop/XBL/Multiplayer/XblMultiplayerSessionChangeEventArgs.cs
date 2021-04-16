using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionChangeEventArgs
    //{
    //    XblMultiplayerSessionReference SessionReference;
    //    char Branch[XBL_GUID_LENGTH];
    //    uint64_t ChangeNumber;
    //}
    //XblMultiplayerSessionChangeEventArgs;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerSessionChangeEventArgs
    {
        internal string GetBranch() { unsafe { fixed (Byte* ptr = this.Branch) { return Converters.BytePointerToString(ptr, XblInterop.XBL_GUID_LENGTH); } } }

        internal XblMultiplayerSessionReference SessionReference;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_GUID_LENGTH)]
        internal Byte[] Branch;
        internal readonly UInt64 ChangeNumber;
    }
}
