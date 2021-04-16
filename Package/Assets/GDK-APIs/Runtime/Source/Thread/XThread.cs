using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    partial class SDK
    {
        public static bool XThreadIsTimeSensitive()
        {
            return XGRInterop.XThreadIsTimeSensitive().Value;
        }

        public static Int32 XThreadSetTimeSensitive(bool isTimeSensitiveThread)
        {
            return XGRInterop.XThreadSetTimeSensitive(new NativeBool(isTimeSensitiveThread));
        }

        public static void XThreadAssertNotTimeSensitive()
        {
            XGRInterop.XThreadAssertNotTimeSensitive();
        }
    }
}
