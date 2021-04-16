using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreProduct
    {
        internal XStoreProduct(Interop.XStoreProduct interopStruct)
        {
            this.StoreId = interopStruct.storeId.GetString();
            this.Title = interopStruct.title.GetString();
            this.Description = interopStruct.description.GetString();
            this.Language = interopStruct.language.GetString();
            this.InAppOfferToken = interopStruct.inAppOfferToken.GetString();
            this.LinkUri = interopStruct.linkUri.GetString();
            this.ProductKind = interopStruct.productKind;
            this.Price = new XStorePrice(interopStruct.price);
            this.HasDigitalDownload = interopStruct.hasDigitalDownload.Value;
            this.IsInUserCollection = interopStruct.isInUserCollection.Value;
            this.Keywords = interopStruct.GetKeywords(x =>x.GetString());
            this.Skus = interopStruct.GetSkus(x =>new XStoreSku(x));
            this.Images = interopStruct.GetImages(x =>new XStoreImage(x));
            this.Videos = interopStruct.GetVideos(x =>new XStoreVideo(x));
        }

        public string StoreId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Language { get; private set; }
        public string InAppOfferToken { get; private set; }
        public string LinkUri { get; private set; }
        public XStoreProductKind ProductKind { get; private set; }
        public XStorePrice Price { get; private set; }
        public bool HasDigitalDownload { get; private set; }
        public bool IsInUserCollection { get; private set; }
        public string[] Keywords { get; private set; }
        public XStoreSku[] Skus { get; private set; }
        public XStoreImage[] Images { get; private set; }
        public XStoreVideo[] Videos { get; private set; }
    }
}