using System;

namespace XGamingRuntime
{
    public class XblContextHandle : EquatableHandle
    {
        public XblContextHandle(Interop.XblContextHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.handle;
        }

        public Interop.XblContextHandle InteropHandle { get; set; }
    }
}
