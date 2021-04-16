using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    partial class SDK
    {
        public static Int32 XGameGetXboxTitleId(out UInt32 titleId)
        {
            return XGRInterop.XGameGetXboxTitleId(out titleId);
        }
    }
}
