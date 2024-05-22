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
            /* E_GS_USER_CANCELED is return when user selects to play offline which generated a valid
             * to use in other XGameSave apis */
            if (Interop.HR.SUCCEEDED(hresult) || hresult == HR.E_GS_USER_CANCELED)
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
