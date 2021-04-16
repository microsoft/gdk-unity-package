using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblPresenceRichPresenceIds
    // {
    //     char scid[XBL_SCID_LENGTH];
    //     _Field_z_ const char* presenceId;
    //     const char** presenceTokenIds;
    //     size_t presenceTokenIdsCount;
    // } XblPresenceRichPresenceIds;

    // Note: class, not struct since it is exclusively passed by reference.
    [StructLayout(LayoutKind.Sequential)]
    internal class XblPresenceRichPresenceIdsRef
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_SCID_LENGTH)]
        internal readonly byte[] scid;
        internal readonly UTF8StringPtr presenceId;
        private readonly IntPtr presenceTokenIds;
        private readonly SizeT presenceTokenIdsCount;

        internal XblPresenceRichPresenceIdsRef(XGamingRuntime.XblPresenceRichPresenceIds richPresenceIds, DisposableCollection disposableCollection)
        {
            this.scid = Converters.StringToNullTerminatedUTF8ByteArray(richPresenceIds.ServiceConfigurationId, XblInterop.XBL_SCID_LENGTH);
            this.presenceId = new UTF8StringPtr(richPresenceIds.PresenceId, disposableCollection);
            this.presenceTokenIds = Converters.StringArrayToUTF8StringArray(richPresenceIds.PresenceTokenIds, disposableCollection,
                out this.presenceTokenIdsCount);
        }

        internal static bool ValidateFields(string scid)
        {
            return (
                scid != null &&
                Converters.StringToNullTerminatedUTF8ByteArray(scid).Length <= XblInterop.XBL_SCID_LENGTH
            );
        }
    }
}
