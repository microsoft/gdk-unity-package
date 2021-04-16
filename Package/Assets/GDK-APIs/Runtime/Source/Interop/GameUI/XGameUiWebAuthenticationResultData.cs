using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XGameUiWebAuthenticationResultData
    //{
    //    HRESULT responseStatus;
    //    size_t responseCompletionUriSize;
    //    _Field_size_opt_(responseCompletionUriSize) _Null_terminated_ const char* responseCompletionUri;
    //};

    [StructLayout(LayoutKind.Sequential)]
    internal struct XGameUiWebAuthenticationResultData
    {
        internal readonly Int32 responseStatus;
        internal readonly SizeT responseCompletionUriSize;
        internal readonly UTF8StringPtr responseCompletionUri;
    }
}
