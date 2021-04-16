using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XUserGetTokenAndSignatureUtf16Data
    //{
    //    size_t tokenCount;
    //    size_t signatureCount;
    //    _Field_size_opt_(tokenCount) _Null_terminated_ const wchar_t* token;
    //    _Field_size_opt_(signatureCount) _Null_terminated_ const wchar_t* signature;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XUserGetTokenAndSignatureUtf16Data
    {
        public SizeT TokenCount;
        public SizeT SignatureCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Token;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Signature;
    }
}
