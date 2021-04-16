using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblPreferredColor
    // {
    //     char primaryColor[XBL_COLOR_CHAR_SIZE];
    //     char secondaryColor[XBL_COLOR_CHAR_SIZE];
    //     char tertiaryColor[XBL_COLOR_CHAR_SIZE];
    // } XblPreferredColor;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblPreferredColor
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_COLOR_CHAR_SIZE)]
        internal readonly byte[] primaryColor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_COLOR_CHAR_SIZE)]
        internal readonly byte[] secondaryColor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_COLOR_CHAR_SIZE)]
        internal readonly byte[] tertiaryColor;
    }
}
