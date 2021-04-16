using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XGamingRuntime
{
    public class XblHttpCallHandle : EquatableHandle
    {
        internal XblHttpCallHandle(Interop.XblHttpCallHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal static Int32 WrapInteropHandleAndReturnHResult(Int32 hresult, Interop.XblHttpCallHandle interopHandle, out XblHttpCallHandle handle)
        {
            if (Interop.HR.SUCCEEDED(hresult))
            {
                handle = new XblHttpCallHandle(interopHandle);
            }
            else
            {
                handle = default(XblHttpCallHandle);
            }
            return hresult;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.handle;
        }

        internal Interop.XblHttpCallHandle InteropHandle { get; set; }
    }
}

