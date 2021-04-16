using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreRateAndReviewResult
    //{
    //    bool wasUpdated;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreRateAndReviewResult
    {
        internal readonly NativeBool wasUpdated;

        internal XStoreRateAndReviewResult(XGamingRuntime.XStoreRateAndReviewResult publicObject)
        {
            this.wasUpdated = new NativeBool(publicObject.WasUpdated);
        }
    }
}