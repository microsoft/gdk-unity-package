using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreSubscriptionInfo
    //{
    //    bool hasTrialPeriod;
    //    XStoreDurationUnit trialPeriodUnit;
    //    uint32_t trialPeriod;
    //    XStoreDurationUnit billingPeriodUnit;
    //    uint32_t billingPeriod;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreSubscriptionInfo
    {
        internal readonly NativeBool hasTrialPeriod;
        internal readonly XStoreDurationUnit trialPeriodUnit;
        internal readonly UInt32 trialPeriod;
        internal readonly XStoreDurationUnit billingPeriodUnit;
        internal readonly UInt32 billingPeriod;

        internal XStoreSubscriptionInfo(XGamingRuntime.XStoreSubscriptionInfo publicObject)
        {
            this.hasTrialPeriod = new NativeBool(publicObject.HasTrialPeriod);
            this.trialPeriodUnit = publicObject.TrialPeriodUnit;
            this.trialPeriod = publicObject.TrialPeriod;
            this.billingPeriodUnit = publicObject.BillingPeriodUnit;
            this.billingPeriod = publicObject.BillingPeriod;
        }
    }
}