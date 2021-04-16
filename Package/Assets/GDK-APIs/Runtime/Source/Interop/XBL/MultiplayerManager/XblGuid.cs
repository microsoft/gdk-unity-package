using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblGuid
    //{
    //    _Null_terminated_ char value[XBL_GUID_LENGTH];
    //} XblGuid;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblGuid
    {
        private unsafe fixed Byte value[40]; // char value[40]

        internal string GetValue() { unsafe { fixed (Byte* ptr = this.value) { return Converters.BytePointerToString(ptr, 40); } } }

        internal XblGuid(XGamingRuntime.XblGuid publicObject)
        {
            unsafe
            {
                fixed (Byte* ptr = this.value)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, ptr, 40);
                }
            }
        }
    }
}