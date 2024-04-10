using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XPackageMountHandle : SafeEquatableHandle
    {
        public XPackageMountHandle(IntPtr handle) :
            base(IntPtr.Zero, true, handle)
        {
        }

        protected override bool ReleaseHandle()
        {
            XGRInterop.XPackageCloseMountHandle(this.Handle);
            SetHandle(IntPtr.Zero);
            return true;
        }

        public override bool IsInvalid
        {
            get { return this.Handle == IntPtr.Zero; }
        }
    }
}
