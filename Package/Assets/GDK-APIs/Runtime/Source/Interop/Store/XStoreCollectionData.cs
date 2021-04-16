using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreCollectionData
    //{
    //    time_t acquiredDate;
    //    time_t startDate;
    //    time_t endDate;
    //    bool isTrial;
    //    uint32_t trialTimeRemainingInSeconds;
    //    uint32_t quantity;
    //    _Field_z_ const char* campaignId;
    //    _Field_z_ const char* developerOfferId;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreCollectionData
    {
        internal readonly TimeT acquiredDate;
        internal readonly TimeT startDate;
        internal readonly TimeT endDate;
        internal readonly NativeBool isTrial;
        internal readonly UInt32 trialTimeRemainingInSeconds;
        internal readonly UInt32 quantity;
        internal readonly UTF8StringPtr campaignId;
        internal readonly UTF8StringPtr developerOfferId;

        internal XStoreCollectionData(XGamingRuntime.XStoreCollectionData publicObject, DisposableCollection disposableCollection)
        {
            this.acquiredDate = new TimeT(publicObject.AcquiredDate);
            this.startDate = new TimeT(publicObject.StartDate);
            this.endDate = new TimeT(publicObject.EndDate);
            this.isTrial = new NativeBool(publicObject.IsTrial);
            this.trialTimeRemainingInSeconds = publicObject.TrialTimeRemainingInSeconds;
            this.quantity = publicObject.Quantity;
            this.campaignId = new UTF8StringPtr(publicObject.CampaignId, disposableCollection);
            this.developerOfferId = new UTF8StringPtr(publicObject.DeveloperOfferId, disposableCollection);
        }
    }
}