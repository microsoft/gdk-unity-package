using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblSocialManagerPresenceRecord
    // {
    //     XblPresenceUserState userState;
    //     XblSocialManagerPresenceTitleRecord presenceTitleRecords[XBL_NUM_PRESENCE_RECORDS];
    //     uint32_t presenceTitleRecordCount;
    // } XblSocialManagerPresenceRecord;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblSocialManagerPresenceRecord
    {
        internal readonly XblPresenceUserState userState;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_NUM_PRESENCE_RECORDS)]
        internal readonly XblSocialManagerPresenceTitleRecord[] presenceTitleRecords;
        internal readonly UInt32 presenceTitleCount;

        internal XblSocialManagerPresenceRecord(XGamingRuntime.XblSocialManagerPresenceRecord presenceRecord)
        {
            this.userState = presenceRecord.UserState;
            this.presenceTitleRecords = Converters.ConvertArrayToFixedLength(
                presenceRecord.PresenceTitleRecords,
                XblInterop.XBL_NUM_PRESENCE_RECORDS,
                r =>new Interop.XblSocialManagerPresenceTitleRecord(r));
            this.presenceTitleCount = Convert.ToUInt32(this.presenceTitleRecords.Length);
        }
    }
}
