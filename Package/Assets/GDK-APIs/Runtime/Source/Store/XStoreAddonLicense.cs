using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreAddonLicense
    {
        internal XStoreAddonLicense(Interop.XStoreAddonLicense interopStruct)
        {
            this.SkuStoreId = interopStruct.GetSkuStoreId();
            this.InAppOfferToken = interopStruct.GetInAppOfferToken();
            this.IsActive = interopStruct.isActive.Value;
            this.ExpirationDate = interopStruct.expirationDate.DateTime;
        }

        public string SkuStoreId { get; private set; }
        public string InAppOfferToken { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime ExpirationDate { get; private set; }
    }
}