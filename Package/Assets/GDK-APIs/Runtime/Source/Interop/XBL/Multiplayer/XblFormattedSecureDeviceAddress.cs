using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblFormattedSecureDeviceAddress
    //{
    //    char value[4096];
    //}
    //XblFormattedSecureDeviceAddress;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblFormattedSecureDeviceAddress
    {
        private unsafe fixed Byte value[4096];
        internal string GetValue() { unsafe { fixed (Byte* ptr = this.value) { return Converters.BytePointerToString(ptr, 4096); } } }
    }
}
