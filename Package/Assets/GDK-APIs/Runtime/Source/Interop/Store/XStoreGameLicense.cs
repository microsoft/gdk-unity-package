using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreGameLicense
    //{
    //    _Field_z_ char skuStoreId[STORE_SKU_ID_SIZE];
    //    bool isActive;
    //    bool isTrialOwnedByThisUser;
    //    bool isDiscLicense;
    //    bool isTrial;
    //    uint32_t trialTimeRemainingInSeconds;
    //    _Field_z_ char trialUniqueId[TRIAL_UNIQUE_ID_MAX_SIZE];
    //    time_t expirationDate;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreGameLicense
    {
        private unsafe fixed Byte skuStoreId[18]; // char skuStoreId[18]
        internal readonly NativeBool isActive;
        internal readonly NativeBool isTrialOwnedByThisUser;
        internal readonly NativeBool isDiscLicense;
        internal readonly NativeBool isTrial;
        internal readonly UInt32 trialTimeRemainingInSeconds;
        private unsafe fixed Byte trialUniqueId[64]; // char trialUniqueId[64]
        internal readonly TimeT expirationDate;

        internal string GetSkuStoreId() { unsafe { fixed (Byte* ptr = this.skuStoreId) { return Converters.BytePointerToString(ptr, 18); } } }
        internal string GetTrialUniqueId() { unsafe { fixed (Byte* ptr = this.trialUniqueId) { return Converters.BytePointerToString(ptr, 64); } } }

        internal XStoreGameLicense(XGamingRuntime.XStoreGameLicense publicObject)
        {
            unsafe
            {
                fixed (Byte* ptr = this.skuStoreId)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SkuStoreId, ptr, 18);
                }
            }
            this.isActive = new NativeBool(publicObject.IsActive);
            this.isTrialOwnedByThisUser = new NativeBool(publicObject.IsTrialOwnedByThisUser);
            this.isDiscLicense = new NativeBool(publicObject.IsDiscLicense);
            this.isTrial = new NativeBool(publicObject.IsTrial);
            this.trialTimeRemainingInSeconds = publicObject.TrialTimeRemainingInSeconds;
            unsafe
            {
                fixed (Byte* ptr = this.trialUniqueId)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.TrialUniqueId, ptr, 64);
                }
            }
            this.expirationDate = new TimeT(publicObject.ExpirationDate);
        }
    }
}