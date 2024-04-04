using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    partial class SDK
    {
        public static Int32 XLaunchUri(XUserHandle requestingUser, string uri)
        {
            if (requestingUser == null)
            {
                return HR.E_INVALIDARG;
            }

            return XGRInterop.XLaunchUri(requestingUser.Handle, Converters.StringToNullTerminatedUTF8ByteArray(uri));
        }
    }
}
