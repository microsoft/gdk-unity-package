using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreSku
    //{
    //    _Field_z_ const char* skuId;
    //    _Field_z_ const char* title;
    //    _Field_z_ const char* description;
    //    _Field_z_ const char* language;
    //    XStorePrice price;
    //    bool isTrial;
    //    bool isInUserCollection;
    //    XStoreCollectionData collectionData;
    //    bool isSubscription;
    //    XStoreSubscriptionInfo subscriptionInfo;
    //    uint32_t bundledSkusCount;
    //    _Field_z_ const char** bundledSkus;
    //    uint32_t imagesCount;
    //    XStoreImage* images;
    //    uint32_t videosCount;
    //    XStoreVideo* videos;
    //    uint32_t availabilitiesCount;
    //    XStoreAvailability* availabilities;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreSku
    {
        internal readonly UTF8StringPtr skuId;
        internal readonly UTF8StringPtr title;
        internal readonly UTF8StringPtr description;
        internal readonly UTF8StringPtr language;
        internal readonly XStorePrice price;
        internal readonly NativeBool isTrial;
        internal readonly NativeBool isInUserCollection;
        internal readonly XStoreCollectionData collectionData;
        internal readonly NativeBool isSubscription;
        internal readonly XStoreSubscriptionInfo subscriptionInfo;
        internal readonly UInt32 bundledSkusCount;
        private readonly unsafe UTF8StringPtr* bundledSkus;
        internal readonly UInt32 imagesCount;
        private readonly unsafe XStoreImage* images;
        internal readonly UInt32 videosCount;
        private readonly unsafe XStoreVideo* videos;
        internal readonly UInt32 availabilitiesCount;
        private readonly unsafe XStoreAvailability* availabilities;

        internal T[] GetBundledSkus<T>(Func<UTF8StringPtr,T> ctor) { unsafe { return Converters.PtrToClassArray<T, UTF8StringPtr>((IntPtr)this.bundledSkus, this.bundledSkusCount, ctor); } }
        internal T[] GetImages<T>(Func<XStoreImage,T> ctor) { unsafe { return Converters.PtrToClassArray<T, XStoreImage>((IntPtr)this.images, this.imagesCount, ctor); } }
        internal T[] GetVideos<T>(Func<XStoreVideo,T> ctor) { unsafe { return Converters.PtrToClassArray<T, XStoreVideo>((IntPtr)this.videos, this.videosCount, ctor); } }
        internal T[] GetAvailabilities<T>(Func<XStoreAvailability,T> ctor) { unsafe { return Converters.PtrToClassArray<T, XStoreAvailability>((IntPtr)this.availabilities, this.availabilitiesCount, ctor); } }

        internal XStoreSku(XGamingRuntime.XStoreSku publicObject, DisposableCollection disposableCollection)
        {
            this.skuId = new UTF8StringPtr(publicObject.SkuId, disposableCollection);
            this.title = new UTF8StringPtr(publicObject.Title, disposableCollection);
            this.description = new UTF8StringPtr(publicObject.Description, disposableCollection);
            this.language = new UTF8StringPtr(publicObject.Language, disposableCollection);
            this.price = new XStorePrice(publicObject.Price, disposableCollection);
            this.isTrial = new NativeBool(publicObject.IsTrial);
            this.isInUserCollection = new NativeBool(publicObject.IsInUserCollection);
            this.collectionData = new XStoreCollectionData(publicObject.CollectionData, disposableCollection);
            this.isSubscription = new NativeBool(publicObject.IsSubscription);
            this.subscriptionInfo = new XStoreSubscriptionInfo(publicObject.SubscriptionInfo);
            unsafe
            {
                this.bundledSkus = (UTF8StringPtr*)Converters.ClassArrayToPtr(
                    publicObject.BundledSkus, 
                    (string x, DisposableCollection _) =>new UTF8StringPtr(x, disposableCollection), 
                    disposableCollection,
                    out this.bundledSkusCount).ToPointer();
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
                    out this.videosCount).ToPointer();
            }
            unsafe
            {
                this.availabilities = (XStoreAvailability*)Converters.ClassArrayToPtr(
                    publicObject.Availabilities, 
                    (XGamingRuntime.XStoreAvailability x, DisposableCollection _) =>new XStoreAvailability(x, disposableCollection), 
                    disposableCollection,
                    out this.availabilitiesCount).ToPointer();
            }
        }
    }
}