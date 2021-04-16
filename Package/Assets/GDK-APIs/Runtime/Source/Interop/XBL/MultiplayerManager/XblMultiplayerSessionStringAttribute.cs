using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionStringAttribute
    //{
    //    char name[XBL_MULTIPLAYER_SEARCH_HANDLE_MAX_FIELD_LENGTH];
    //    char value[XBL_MULTIPLAYER_SEARCH_HANDLE_MAX_FIELD_LENGTH];
    //} XblMultiplayerSessionStringAttribute;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerSessionStringAttribute
    {
        private unsafe fixed Byte name[100]; // char name[100]
        private unsafe fixed Byte value[100]; // char value[100]

        internal string GetName() { unsafe { fixed (Byte* ptr = this.name) { return Converters.BytePointerToString(ptr, 100); } } }
        internal string GetValue() { unsafe { fixed (Byte* ptr = this.value) { return Converters.BytePointerToString(ptr, 100); } } }

        internal XblMultiplayerSessionStringAttribute(XGamingRuntime.XblMultiplayerSessionStringAttribute publicObject)
        {
            unsafe
            {
                fixed (Byte* ptr = this.name)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Name, ptr, 100);
                }
            }
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