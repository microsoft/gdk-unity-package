using System;

namespace XGamingRuntime
{
    public class XblSocialManagerUserGroupHandle : EquatableHandle
    {
        internal XblSocialManagerUserGroupHandle(Interop.XblSocialManagerUserGroupHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal static Int32 WrapAndReturnHResult(Int32 hresult, Interop.XblSocialManagerUserGroupHandle interopHandle, out XblSocialManagerUserGroupHandle handle)
        {
            if (Interop.HR.SUCCEEDED(hresult))
            {
                handle = new XblSocialManagerUserGroupHandle(interopHandle);
            }
            else
            {
                handle = default(XblSocialManagerUserGroupHandle);
            }
            return hresult;
        }

        internal void ClearInteropHandle()
        {
            this.InteropHandle = new Interop.XblSocialManagerUserGroupHandle();
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.Handle;
        }

        internal Interop.XblSocialManagerUserGroupHandle InteropHandle { get; set; }
    }
}
