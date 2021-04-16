using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreLicense : EquatableHandle
    {
        internal XStoreLicense(XStoreLicenseHandle interopHandle)
        {
            Handle = interopHandle;
        }

        internal override IntPtr GetInternalPtr()
        {
            return Handle.intPtr;
        }

        internal XStoreLicenseHandle Handle { get; set; }
    }
}
