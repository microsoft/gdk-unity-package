using System;
using System.Collections.Generic;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XUserHandle : SafeEquatableHandle
    {

        internal XUserHandle(IntPtr interopHandle) :
            base(IntPtr.Zero, true, interopHandle)
        {
        }

        internal XUserHandle(IntPtr interopHandle, bool ownsHandle) :
            base(IntPtr.Zero, ownsHandle, interopHandle)
        {
        }
        
        internal static Int32 WrapAndReturnHResult(Int32 hresult, IntPtr interopHandle, out XUserHandle handle)
        {
            if (Interop.HR.SUCCEEDED(hresult) && interopHandle != IntPtr.Zero)
            {
                handle = new XUserHandle(interopHandle);
            }
            else
            {
                handle = null;
            }
            return hresult;
        }

        protected override bool ReleaseHandle()
        {
            XGRInterop.XUserCloseHandle(this.handle);
            SetHandle(IntPtr.Zero);
            return true;
        }

        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }
    }
}
