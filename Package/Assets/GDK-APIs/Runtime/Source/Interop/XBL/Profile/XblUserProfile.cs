using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblUserProfile
    //{
    //    uint64_t xboxUserId;
    //    char appDisplayName[XBL_DISPLAY_NAME_CHAR_SIZE];
    //    char appDisplayPictureResizeUri[XBL_DISPLAY_PIC_URL_RAW_CHAR_SIZE];
    //    char gameDisplayName[XBL_DISPLAY_NAME_CHAR_SIZE];
    //    char gameDisplayPictureResizeUri[XBL_DISPLAY_PIC_URL_RAW_CHAR_SIZE];
    //    char gamerscore[XBL_GAMERSCORE_CHAR_SIZE];
    //    char gamertag[XBL_GAMERTAG_CHAR_SIZE];
    //    char modernGamertag[XBL_MODERN_GAMERTAG_CHAR_SIZE];
    //    char modernGamertagSuffix[XBL_MODERN_GAMERTAG_SUFFIX_CHAR_SIZE];
    //    char uniqueModernGamertag[XBL_UNIQUE_MODERN_GAMERTAG_CHAR_SIZE];
    //}
    //XblUserProfile;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblUserProfile
    {
        internal readonly UInt64 xboxUserId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 90)]
        internal Byte[] appDisplayName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 675)]
        internal Byte[] appDisplayPictureResizeUri;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 90)]
        internal Byte[] gameDisplayName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 675)]
        internal Byte[] gameDisplayPictureResizeUri;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        internal Byte[] gamerscore;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        internal Byte[] gamertag;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 97)]
        internal Byte[] modernGamertag;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        internal Byte[] modernGamertagSuffix;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 101)]
        internal Byte[] uniqueModernGamertag;
    }
}
