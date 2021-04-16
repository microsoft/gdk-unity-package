using System;

namespace XGamingRuntime
{
    public class XblPresenceRecordHandle : EquatableHandle
    {
        internal XblPresenceRecordHandle(Interop.XblPresenceRecordHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal static Int32 WrapInteropHandleAndReturnHResult(Int32 hresult, Interop.XblPresenceRecordHandle interopHandle, out XblPresenceRecordHandle handle)
        {
            if (Interop.HR.SUCCEEDED(hresult))
            {
                handle = new XblPresenceRecordHandle(interopHandle);
            }
            else
            {
                handle = default(XblPresenceRecordHandle);
            }
            return hresult;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.intPtr;
        }

        internal Interop.XblPresenceRecordHandle InteropHandle { get; private set; }
    }
}
