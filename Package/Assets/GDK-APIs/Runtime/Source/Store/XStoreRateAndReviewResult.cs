using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreRateAndReviewResult
    {
        internal XStoreRateAndReviewResult(Interop.XStoreRateAndReviewResult interopStruct)
        {
            this.WasUpdated = interopStruct.wasUpdated.Value;
        }

        public bool WasUpdated { get; private set; }
    }
}