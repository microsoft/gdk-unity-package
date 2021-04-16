using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreAddonLicense
    //{
    //    _Field_z_ char skuStoreId[STORE_SKU_ID_SIZE];
    //    _Field_z_ char inAppOfferToken[IN_APP_OFFER_TOKEN_MAX_SIZE];
    //    bool isActive;
    //    time_t expirationDate;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreAddonLicense
    {
        private unsafe fixed Byte skuStoreId[18]; // char skuStoreId[18]
        private unsafe fixed Byte inAppOfferToken[64]; // char inAppOfferToken[64]
        internal readonly NativeBool isActive;
        internal readonly TimeT expirationDate;

        internal string GetSkuStoreId() { unsafe { fixed (Byte* ptr = this.skuStoreId) { return Converters.BytePointerToString(ptr, 18); } } }
        internal string GetInAppOfferToken() { unsafe { fixed (Byte* ptr = this.inAppOfferToken) { return Converters.BytePointerToString(ptr, 64); } } }

        internal XStoreAddonLicense(XGamingRuntime.XStoreAddonLicense publicObject)
        {
            unsafe
            {
                fixed (Byte* ptr = this.skuStoreId)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SkuStoreId, ptr, 18);
                }
            }
            unsafe
            {
                fixed (Byte* ptr = this.inAppOfferToken)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.InAppOfferToken, ptr, 64);
                }
            }
            this.isActive = new NativeBool(publicObject.IsActive);
            this.expirationDate = new TimeT(publicObject.ExpirationDate);
        }
    }
}