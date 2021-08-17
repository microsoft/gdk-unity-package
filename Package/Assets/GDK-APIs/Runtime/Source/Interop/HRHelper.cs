using System;

namespace XGamingRuntime.Interop
{
    public class HR
    {
        public const Int32 S_OK = 0x00000000;
        public const Int32 E_INVALIDARG = unchecked((Int32)0x80070057);

        public static bool SUCCEEDED(Int32 hr)
        {
            return hr >= 0;
        }

        public static bool FAILED(Int32 hr)
        {
            return hr < 0;
        }
    }
}
