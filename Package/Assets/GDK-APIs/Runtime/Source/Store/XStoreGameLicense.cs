using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreGameLicense
    {
        internal XStoreGameLicense(Interop.XStoreGameLicense interopStruct)
        {
            this.SkuStoreId = interopStruct.GetSkuStoreId();
            this.IsActive = interopStruct.isActive.Value;
            this.IsTrialOwnedByThisUser = interopStruct.isTrialOwnedByThisUser.Value;
            this.IsDiscLicense = interopStruct.isDiscLicense.Value;
            this.IsTrial = interopStruct.isTrial.Value;
            this.TrialTimeRemainingInSeconds = interopStruct.trialTimeRemainingInSeconds;
            this.TrialUniqueId = interopStruct.GetTrialUniqueId();
            this.ExpirationDate = interopStruct.expirationDate.DateTime;
        }

        public string SkuStoreId { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsTrialOwnedByThisUser { get; private set; }
        public bool IsDiscLicense { get; private set; }
        public bool IsTrial { get; private set; }
        public UInt32 TrialTimeRemainingInSeconds { get; private set; }
        public string TrialUniqueId { get; private set; }
        public DateTime ExpirationDate { get; private set; }
    }
}