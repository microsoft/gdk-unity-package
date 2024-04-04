using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XTaskQueueHandle : SafeEquatableHandle
    {
        public XTaskQueueHandle(IntPtr handle) :
            base(IntPtr.Zero, true, handle)
        {
        }

        protected override bool ReleaseHandle()
        {
            XGRInterop.XTaskQueueCloseHandle(this.Handle);
            SetHandle(IntPtr.Zero);
            return true;
        }

        public override bool IsInvalid
        {
            get { return this.Handle == IntPtr.Zero; }
        }
    }
}
