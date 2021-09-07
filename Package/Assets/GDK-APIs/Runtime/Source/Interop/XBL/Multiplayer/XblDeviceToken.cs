using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblDeviceToken
    //{
    //    _Null_terminated_ char Value[XBL_MULTIPLAYER_DEVICE_TOKEN_MAX_LENGTH];
    //} XblDeviceToken;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblDeviceToken
    {
        private unsafe fixed Byte Value[40]; // char Value[40]

        internal string GetValue() { unsafe { fixed (Byte* ptr = this.Value) { return Converters.BytePointerToString(ptr, 40); } } }

        internal XblDeviceToken(XGamingRuntime.XblDeviceToken publicObject)
        {
            unsafe
            {
                fixed (Byte* ptr = this.Value)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, ptr, 40);
                }
            }
        }
    }
}