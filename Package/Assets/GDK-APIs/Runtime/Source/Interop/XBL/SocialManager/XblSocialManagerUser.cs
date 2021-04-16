using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblSocialManagerUser
    // {
    //     uint64_t xboxUserId;
    //     bool isFavorite;
    //     bool isFollowingUser;
    //     bool isFollowedByCaller;
    //     char displayName[XBL_DISPLAY_NAME_CHAR_SIZE];
    //     char realName[XBL_REAL_NAME_CHAR_SIZE];
    //     char displayPicUrlRaw[XBL_DISPLAY_PIC_URL_RAW_CHAR_SIZE];
    //     bool useAvatar;
    //     char gamerscore[XBL_GAMERSCORE_CHAR_SIZE];
    //     char gamertag[XBL_GAMERTAG_CHAR_SIZE];
    //     char modernGamertag[XBL_MODERN_GAMERTAG_CHAR_SIZE];
    //     char modernGamertagSuffix[XBL_MODERN_GAMERTAG_SUFFIX_CHAR_SIZE];
    //     char uniqueModernGamertag[XBL_UNIQUE_MODERN_GAMERTAG_CHAR_SIZE];
    //     XblSocialManagerPresenceRecord presenceRecord;
    //     XblTitleHistory titleHistory;
    //     XblPreferredColor preferredColor;
    // } XblSocialManagerUser;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblSocialManagerUser
    {
        internal readonly UInt64 xboxUserId;
        [MarshalAs(UnmanagedType.U1)]
        internal readonly bool isFavorite;
        [MarshalAs(UnmanagedType.U1)]
        internal readonly bool isFollowingUser;
        [MarshalAs(UnmanagedType.U1)]
        internal readonly bool isFollowedByCaller;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_DISPLAY_NAME_CHAR_SIZE)]
        internal readonly byte[] displayName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_REAL_NAME_CHAR_SIZE)]
        internal readonly byte[] realName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_DISPLAY_PIC_URL_RAW_CHAR_SIZE)]
        internal readonly byte[] displayPicUrlRaw;
        [MarshalAs(UnmanagedType.U1)]
        internal readonly bool useAvatar;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_GAMERSCORE_CHAR_SIZE)]
        internal readonly byte[] gamerscore;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_GAMERTAG_CHAR_SIZE)]
        internal readonly byte[] gamertag;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_MODERN_GAMERTAG_CHAR_SIZE)]
        internal readonly byte[] modernGamertag;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_MODERN_GAMERTAG_SUFFIX_CHAR_SIZE)]
        internal readonly byte[] modernGamertagSuffix;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_UNIQUE_MODERN_GAMERTAG_CHAR_SIZE)]
        internal readonly byte[] uniqueModernGamertag;

        internal readonly XblSocialManagerPresenceRecord presenceRecord;
        internal readonly XblTitleHistory titleHistory;
        internal readonly XblPreferredColor preferredColor;
    }
}
