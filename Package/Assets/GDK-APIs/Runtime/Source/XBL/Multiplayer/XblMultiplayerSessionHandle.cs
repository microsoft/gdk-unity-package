using System;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionHandle : EquatableHandle
    {
        public XblMultiplayerSessionHandle(Interop.XblMultiplayerSessionHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.handle;
        }

        public Interop.XblMultiplayerSessionHandle InteropHandle { get; set; }
    }
}
