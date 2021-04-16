using System;
using System.Collections.Generic;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XUserHandle : EquatableHandle
    {
        internal XUserHandle(Interop.XUserHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal static Int32 WrapAndReturnHResult(Int32 hresult, Interop.XUserHandle interopHandle, out XUserHandle handle)
        {
            if (Interop.HR.SUCCEEDED(hresult))
            {
                handle = new XUserHandle(interopHandle);
            }
            else
            {
                handle = default(XUserHandle);
            }
            return hresult;
        }

        internal void ClearInteropHandle()
        {
            this.InteropHandle = new Interop.XUserHandle();
        }

        internal override IntPtr GetInternalPtr() { return InteropHandle.Ptr; }

        internal Interop.XUserHandle InteropHandle { get; private set; }
    }
}
