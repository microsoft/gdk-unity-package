using System;

namespace XGamingRuntime
{
    public class XGameSaveProviderHandle : EquatableHandle
    {
        internal XGameSaveProviderHandle(Interop.XGameSaveProviderHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal static Int32 WrapInteropHandleAndReturnHResult(Int32 hresult, Interop.XGameSaveProviderHandle interopHandle, out XGameSaveProviderHandle userHandle)
        {
            if (Interop.HR.SUCCEEDED(hresult))
            {
                userHandle = new XGameSaveProviderHandle(interopHandle);
            }
            else
            {
                userHandle = default(XGameSaveProviderHandle);
            }
            return hresult;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.Ptr;
        }

        internal Interop.XGameSaveProviderHandle InteropHandle { get; private set; }
    }
}
