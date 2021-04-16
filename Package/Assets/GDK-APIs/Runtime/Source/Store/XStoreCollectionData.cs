using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreCollectionData
    {
        internal XStoreCollectionData(Interop.XStoreCollectionData interopStruct)
        {
            this.AcquiredDate = interopStruct.acquiredDate.DateTime;
            this.StartDate = interopStruct.startDate.DateTime;
            this.EndDate = interopStruct.endDate.DateTime;
            this.IsTrial = interopStruct.isTrial.Value;
            this.TrialTimeRemainingInSeconds = interopStruct.trialTimeRemainingInSeconds;
            this.Quantity = interopStruct.quantity;
            this.CampaignId = interopStruct.campaignId.GetString();
            this.DeveloperOfferId = interopStruct.developerOfferId.GetString();
        }

        public DateTime AcquiredDate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsTrial { get; private set; }
        public UInt32 TrialTimeRemainingInSeconds { get; private set; }
        public UInt32 Quantity { get; private set; }
        public string CampaignId { get; private set; }
        public string DeveloperOfferId { get; private set; }
    }
}