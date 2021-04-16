using System;

namespace XGamingRuntime
{
    public class XUserSignOutDeferralHandle : EquatableHandle
    {
        internal XUserSignOutDeferralHandle(Interop.XUserSignOutDeferralHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.Ptr;
        }

        internal Interop.XUserSignOutDeferralHandle InteropHandle { get; private set; }
    }
}
