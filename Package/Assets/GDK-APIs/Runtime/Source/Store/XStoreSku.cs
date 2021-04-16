using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreSku
    {
        internal XStoreSku(Interop.XStoreSku interopStruct)
        {
            this.SkuId = interopStruct.skuId.GetString();
            this.Title = interopStruct.title.GetString();
            this.Description = interopStruct.description.GetString();
            this.Language = interopStruct.language.GetString();
            this.Price = new XStorePrice(interopStruct.price);
            this.IsTrial = interopStruct.isTrial.Value;
            this.IsInUserCollection = interopStruct.isInUserCollection.Value;
            this.CollectionData = new XStoreCollectionData(interopStruct.collectionData);
            this.IsSubscription = interopStruct.isSubscription.Value;
            this.SubscriptionInfo = new XStoreSubscriptionInfo(interopStruct.subscriptionInfo);
            this.BundledSkus = interopStruct.GetBundledSkus(x =>x.GetString());
            this.Images = interopStruct.GetImages(x =>new XStoreImage(x));
            this.Videos = interopStruct.GetVideos(x =>new XStoreVideo(x));
            this.Availabilities = interopStruct.GetAvailabilities(x =>new XStoreAvailability(x));
        }

        public string SkuId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Language { get; private set; }
        public XStorePrice Price { get; private set; }
        public bool IsTrial { get; private set; }
        public bool IsInUserCollection { get; private set; }
        public XStoreCollectionData CollectionData { get; private set; }
        public bool IsSubscription { get; private set; }
        public XStoreSubscriptionInfo SubscriptionInfo { get; private set; }
        public string[] BundledSkus { get; private set; }
        public XStoreImage[] Images { get; private set; }
        public XStoreVideo[] Videos { get; private set; }
        public XStoreAvailability[] Availabilities { get; private set; }
    }
}