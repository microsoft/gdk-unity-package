using System;

namespace XGamingRuntime.Interop
{
    internal class HR
    {
        internal const Int32 S_OK = 0x00000000;
        internal const Int32 E_INVALIDARG = unchecked((Int32)0x80070057);

        internal static bool SUCCEEDED(Int32 hr)
        {
            return hr >= 0;
        }

        internal static bool FAILED(Int32 hr)
        {
            return hr < 0;
        }
    }
}
