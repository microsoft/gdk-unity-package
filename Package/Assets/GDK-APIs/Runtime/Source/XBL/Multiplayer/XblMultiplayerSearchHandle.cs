using System;

namespace XGamingRuntime
{
    public class XblMultiplayerSearchHandle : EquatableHandle
    {
        internal XblMultiplayerSearchHandle(Interop.XblMultiplayerSearchHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.handle;
        }

        internal Interop.XblMultiplayerSearchHandle InteropHandle { get; set; }
    }
}
