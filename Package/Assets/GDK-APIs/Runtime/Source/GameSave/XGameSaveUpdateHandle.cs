using System;

namespace XGamingRuntime
{
    public class XGameSaveUpdateHandle : EquatableHandle
    {
        internal XGameSaveUpdateHandle(Interop.XGameSaveUpdateHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal static Int32 WrapInteropHandleAndReturnHResult(Int32 hresult, Interop.XGameSaveUpdateHandle interopHandle, out XGameSaveUpdateHandle userHandle)
        {
            if (Interop.HR.SUCCEEDED(hresult))
            {
                userHandle = new XGameSaveUpdateHandle(interopHandle);
            }
            else
            {
                userHandle = default(XGameSaveUpdateHandle);
            }
            return hresult;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.Ptr;
        }

        internal Interop.XGameSaveUpdateHandle InteropHandle { get; private set; }
    }
}
