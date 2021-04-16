using System;

namespace XGamingRuntime
{
    public class XblMultiplayerEventArgsHandle : EquatableHandle
    {
        internal XblMultiplayerEventArgsHandle(Interop.XblMultiplayerEventArgsHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal static Int32 WrapInteropHandleAndReturnHResult(Int32 hresult, Interop.XblMultiplayerEventArgsHandle interopHandle, out XblMultiplayerEventArgsHandle handle)
        {
            if (Interop.HR.SUCCEEDED(hresult))
            {
                handle = new XblMultiplayerEventArgsHandle(interopHandle);
            }
            else
            {
                handle = default(XblMultiplayerEventArgsHandle);
            }
            return hresult;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.handle;
        }

        internal Interop.XblMultiplayerEventArgsHandle InteropHandle { get; set; }
    }
}
