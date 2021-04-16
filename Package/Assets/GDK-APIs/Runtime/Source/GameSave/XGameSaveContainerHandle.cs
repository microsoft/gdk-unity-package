using System;

namespace XGamingRuntime
{
    public class XGameSaveContainerHandle : EquatableHandle
    {
        internal XGameSaveContainerHandle(Interop.XGameSaveContainerHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }        

        internal static Int32 WrapInteropHandleAndReturnHResult(Int32 hresult, Interop.XGameSaveContainerHandle interopHandle, out XGameSaveContainerHandle userHandle)
        {
            if (Interop.HR.SUCCEEDED(hresult))
            {
                userHandle = new XGameSaveContainerHandle(interopHandle);
            }
            else
            {
                userHandle = default(XGameSaveContainerHandle);
            }
            return hresult;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.Ptr;
        }

        internal Interop.XGameSaveContainerHandle InteropHandle { get; private set; }
    }
}
