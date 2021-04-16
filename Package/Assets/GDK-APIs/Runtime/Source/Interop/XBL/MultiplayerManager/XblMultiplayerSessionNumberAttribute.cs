using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionNumberAttribute
    //{
    //    char name[XBL_MULTIPLAYER_SEARCH_HANDLE_MAX_FIELD_LENGTH];
    //    double value;
    //} XblMultiplayerSessionNumberAttribute;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerSessionNumberAttribute
    {
        private unsafe fixed Byte name[100]; // char name[100]
        internal readonly double value;

        internal string GetName() { unsafe { fixed (Byte* ptr = this.name) { return Converters.BytePointerToString(ptr, 100); } } }

        internal XblMultiplayerSessionNumberAttribute(XGamingRuntime.XblMultiplayerSessionNumberAttribute publicObject)
        {
            unsafe
            {
                fixed (Byte* ptr = this.name)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Name, ptr, 100);
                }
            }
            this.value = publicObject.Value;
        }
    }
}