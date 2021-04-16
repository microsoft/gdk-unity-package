using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreCanAcquireLicenseResult
    {
        internal XStoreCanAcquireLicenseResult(Interop.XStoreCanAcquireLicenseResult interopStruct)
        {
            this.LicensableSku = interopStruct.GetLicensableSku();
            this.Status = interopStruct.status;
        }

        public string LicensableSku { get; private set; }
        public XStoreCanLicenseStatus Status { get; private set; }
    }
}