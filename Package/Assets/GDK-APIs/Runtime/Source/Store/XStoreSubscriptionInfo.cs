using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreSubscriptionInfo
    {
        internal XStoreSubscriptionInfo(Interop.XStoreSubscriptionInfo interopStruct)
        {
            this.HasTrialPeriod = interopStruct.hasTrialPeriod.Value;
            this.TrialPeriodUnit = interopStruct.trialPeriodUnit;
            this.TrialPeriod = interopStruct.trialPeriod;
            this.BillingPeriodUnit = interopStruct.billingPeriodUnit;
            this.BillingPeriod = interopStruct.billingPeriod;
        }

        public bool HasTrialPeriod { get; private set; }
        public XStoreDurationUnit TrialPeriodUnit { get; private set; }
        public UInt32 TrialPeriod { get; private set; }
        public XStoreDurationUnit BillingPeriodUnit { get; private set; }
        public UInt32 BillingPeriod { get; private set; }
    }
}