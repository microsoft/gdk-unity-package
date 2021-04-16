using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XUserGetTokenAndSignatureUtf16HttpHeader
    //{
    //    _Field_z_ const wchar_t* name;
    //    _Field_z_ const wchar_t* value;
    //};
    [StructLayout(LayoutKind.Sequential)]
    struct XUserGetTokenAndSignatureUtf16HttpHeader
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Name;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Value;
    }
}
