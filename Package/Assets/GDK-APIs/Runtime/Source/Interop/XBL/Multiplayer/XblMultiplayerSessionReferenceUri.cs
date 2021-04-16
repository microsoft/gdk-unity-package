using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionReferenceUri
    //{
    //    _Null_terminated_ char value[XBL_MULTIPLAYER_SESSION_REFERENCE_URI_MAX_LENGTH];
    //} XblMultiplayerSessionReferenceUri;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerSessionReferenceUri
    {
        private unsafe fixed Byte value[284]; // char value[284]

        internal string GetValue() { unsafe { fixed (Byte* ptr = this.value) { return Converters.BytePointerToString(ptr, 284); } } }

        internal XblMultiplayerSessionReferenceUri(XGamingRuntime.XblMultiplayerSessionReferenceUri publicObject)
        {
            unsafe
            {
                fixed (Byte* ptr = this.value)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, ptr, 284);
                }
            }
        }
    }
}