using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreCanAcquireLicenseResult
    //{
    //    _Field_z_ char licensableSku[SKU_ID_SIZE];
    //    XStoreCanLicenseStatus status;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreCanAcquireLicenseResult
    {
        private unsafe fixed Byte licensableSku[5]; // char licensableSku[5]
        internal readonly XStoreCanLicenseStatus status;

        internal string GetLicensableSku() { unsafe { fixed (Byte* ptr = this.licensableSku) { return Converters.BytePointerToString(ptr, 5); } } }

        internal XStoreCanAcquireLicenseResult(XGamingRuntime.XStoreCanAcquireLicenseResult publicObject)
        {
            unsafe
            {
                fixed (Byte* ptr = this.licensableSku)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.LicensableSku, ptr, 5);
                }
            }
            this.status = publicObject.Status;
        }
    }
}