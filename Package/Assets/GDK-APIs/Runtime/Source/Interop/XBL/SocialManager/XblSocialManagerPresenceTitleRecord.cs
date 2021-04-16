using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblSocialManagerPresenceTitleRecord
    // {
    //     uint32_t titleId;
    //     bool isTitleActive;
    //     char presenceText[XBL_RICH_PRESENCE_CHAR_SIZE];
    //     bool isBroadcasting;
    //     XblPresenceDeviceType deviceType;
    //     bool isPrimary;
    // } XblSocialManagerPresenceTitleRecord;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblSocialManagerPresenceTitleRecord
    {
        internal readonly UInt32 titleId;
        [MarshalAs(UnmanagedType.U1)]
        internal readonly bool isTitleActive;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_RICH_PRESENCE_CHAR_SIZE)]
        internal readonly byte[] presenceText;
        [MarshalAs(UnmanagedType.U1)]
        internal readonly bool isBroadcasting;
        internal readonly XblPresenceDeviceType deviceType;
        [MarshalAs(UnmanagedType.U1)]
        internal readonly bool isPrimary;

        internal XblSocialManagerPresenceTitleRecord(XGamingRuntime.XblSocialManagerPresenceTitleRecord titleRecord)
        {
            this.titleId = titleRecord.TitleId;
            this.isTitleActive = titleRecord.IsTitleActive;
            this.presenceText = Converters.StringToNullTerminatedUTF8ByteArray(titleRecord.PresenceText, XblInterop.XBL_RICH_PRESENCE_CHAR_SIZE);
            this.isBroadcasting = titleRecord.IsBroadcasting;
            this.deviceType = titleRecord.DeviceType;
            this.isPrimary = titleRecord.IsPrimary;
        }
    }
}
