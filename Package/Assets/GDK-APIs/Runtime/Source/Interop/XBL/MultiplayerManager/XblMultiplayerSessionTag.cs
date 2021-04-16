using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionTag
    //{
    //    char value[XBL_MULTIPLAYER_SEARCH_HANDLE_MAX_FIELD_LENGTH];
    //} XblMultiplayerSessionTag;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerSessionTag
    {
        private unsafe fixed Byte value[100]; // char value[100]

        internal string GetValue() { unsafe { fixed (Byte* ptr = this.value) { return Converters.BytePointerToString(ptr, 100); } } }

        internal XblMultiplayerSessionTag(XGamingRuntime.XblMultiplayerSessionTag publicObject)
        {
            unsafe
            {
                fixed (Byte* ptr = this.value)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, ptr, 100);
                }
            }
        }
    }
}