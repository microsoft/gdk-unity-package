using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionReference
    //{
    //    _Null_terminated_ char Scid[XBL_SCID_LENGTH];
    //    _Null_terminated_ char SessionTemplateName[XBL_MULTIPLAYER_SESSION_TEMPLATE_NAME_MAX_LENGTH];
    //    _Null_terminated_ char SessionName[XBL_MULTIPLAYER_SESSION_NAME_MAX_LENGTH];
    //} XblMultiplayerSessionReference;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerSessionReference
    {
        private unsafe fixed Byte Scid[40]; // char Scid[40]
        private unsafe fixed Byte SessionTemplateName[100]; // char SessionTemplateName[100]
        private unsafe fixed Byte SessionName[100]; // char SessionName[100]

        public string GetScid() { unsafe { fixed (Byte* ptr = this.Scid) { return Converters.BytePointerToString(ptr, 40); } } }
        public string GetSessionTemplateName() { unsafe { fixed (Byte* ptr = this.SessionTemplateName) { return Converters.BytePointerToString(ptr, 100); } } }
        public string GetSessionName() { unsafe { fixed (Byte* ptr = this.SessionName) { return Converters.BytePointerToString(ptr, 100); } } }

        public XblMultiplayerSessionReference(XGamingRuntime.XblMultiplayerSessionReference publicObject)
        {
            unsafe
            {
                fixed (Byte* ptr = this.Scid)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Scid, ptr, 40);
                }
            }
            unsafe
            {
                fixed (Byte* ptr = this.SessionTemplateName)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SessionTemplateName, ptr, 100);
                }
            }
            unsafe
            {
                fixed (Byte* ptr = this.SessionName)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SessionName, ptr, 100);
                }
            }
        }
    }
}