using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XStoreCanLicenseStatus : uint32_t
    //{
    //    NotLicensableToUser = 0,
    //    Licensable          = 1,
    //};
    public enum XStoreCanLicenseStatus : UInt32
    {
        NotLicensableToUser = 0,
        Licensable = 1,
    }
}