using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreProduct
    //{
    //    _Field_z_ const char* storeId;
    //    _Field_z_ const char* title;
    //    _Field_z_ const char* description;
    //    _Field_z_ const char* language;
    //    _Field_z_ const char* inAppOfferToken;
    //    _Field_z_ char* linkUri;
    //    XStoreProductKind productKind;
    //    XStorePrice price;
    //    bool hasDigitalDownload;
    //    bool isInUserCollection;
    //    uint32_t keywordsCount;
    //    _Field_z_ const char** keywords;
    //    uint32_t skusCount;
    //    XStoreSku* skus;
    //    uint32_t imagesCount;
    //    XStoreImage* images;
    //    uint32_t videosCount;
    //    XStoreVideo* videos;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreProduct
    {
        internal readonly UTF8StringPtr storeId;
        internal readonly UTF8StringPtr title;
        internal readonly UTF8StringPtr description;
        internal readonly UTF8StringPtr language;
        internal readonly UTF8StringPtr inAppOfferToken;
        internal readonly UTF8StringPtr linkUri;
        internal readonly XStoreProductKind productKind;
        internal readonly XStorePrice price;
        internal readonly NativeBool hasDigitalDownload;
        internal readonly NativeBool isInUserCollection;
        internal readonly UInt32 keywordsCount;
        private readonly unsafe UTF8StringPtr* keywords;
        internal readonly UInt32 skusCount;
        private readonly unsafe XStoreSku* skus;
        internal readonly UInt32 imagesCount;
        private readonly unsafe XStoreImage* images;
        internal readonly UInt32 videosCount;
        private readonly unsafe XStoreVideo* videos;
        
        internal T[] GetKeywords<T>(Func<UTF8StringPtr,T> ctor) { unsafe { return Converters.PtrToClassArray<T, UTF8StringPtr>((IntPtr)this.keywords, this.keywordsCount, ctor); } }
        internal T[] GetSkus<T>(Func<XStoreSku,T> ctor) { unsafe { return Converters.PtrToClassArray<T, XStoreSku>((IntPtr)this.skus, this.skusCount, ctor); } }
        internal T[] GetImages<T>(Func<XStoreImage,T> ctor) { unsafe { return Converters.PtrToClassArray<T, XStoreImage>((IntPtr)this.images, this.imagesCount, ctor); } }
        internal T[] GetVideos<T>(Func<XStoreVideo,T> ctor) { unsafe { return Converters.PtrToClassArray<T, XStoreVideo>((IntPtr)this.videos, this.videosCount, ctor); } }

        internal XStoreProduct(XGamingRuntime.XStoreProduct publicObject, DisposableCollection disposableCollection)
        {
            this.storeId = new UTF8StringPtr(publicObject.StoreId, disposableCollection);
            this.title = new UTF8StringPtr(publicObject.Title, disposableCollection);
            this.description = new UTF8StringPtr(publicObject.Description, disposableCollection);
            this.language = new UTF8StringPtr(publicObject.Language, disposableCollection);
            this.inAppOfferToken = new UTF8StringPtr(publicObject.InAppOfferToken, disposableCollection);
            this.linkUri = new UTF8StringPtr(publicObject.LinkUri, disposableCollection);
            this.productKind = publicObject.ProductKind;
            this.price = new XStorePrice(publicObject.Price, disposableCollection);
            this.hasDigitalDownload = new NativeBool(publicObject.HasDigitalDownload);
            this.isInUserCollection = new NativeBool(publicObject.IsInUserCollection);
            unsafe
            {
                this.keywords = (UTF8StringPtr*)Converters.ClassArrayToPtr(
                    publicObject.Keywords, 
                    (string x, DisposableCollection _) =>new UTF8StringPtr(x, disposableCollection), 
                    disposableCollection,
                    out this.keywordsCount).ToPointer();
            }
            unsafe
            {
                this.skus = (XStoreSku*)Converters.ClassArrayToPtr(
                    publicObject.Skus, 
                    (XGamingRuntime.XStoreSku x, DisposableCollection _) =>new XStoreSku(x, disposableCollection), 
                    disposableCollection,
                    out this.skusCount).ToPointer();
            }
            unsafe
            {
                this.images = (XStoreImage*)Converters.ClassArrayToPtr(
                    publicObject.Images, 
                    (XGamingRuntime.XStoreImage x, DisposableCollection _) =>new XStoreImage(x, disposableCollection), 
                    disposableCollection,
                    out this.imagesCount).ToPointer();
            }
            unsafe
            {
                this.videos = (XStoreVideo*)Converters.ClassArrayToPtr(
                    publicObject.Videos, 
                    (XGamingRuntime.XStoreVideo x, DisposableCollection _) =>new XStoreVideo(x, disposableCollection), 
                    disposableCollection,
                    out this.videosCount);
            }
        }
    }
}