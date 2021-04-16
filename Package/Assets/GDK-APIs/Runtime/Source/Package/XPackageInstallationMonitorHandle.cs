using System;

namespace XGamingRuntime
{
    public class XPackageInstallationMonitorHandle : EquatableHandle
    {
        internal XPackageInstallationMonitorHandle(Interop.XPackageInstallationMonitorHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal static Int32 WrapInteropHandleAndReturnHResult(
            Int32 hresult,
            Interop.XPackageInstallationMonitorHandle interopHandle,
            out XPackageInstallationMonitorHandle handle)
        {
            if (Interop.HR.SUCCEEDED(hresult))
            {
                handle = new XPackageInstallationMonitorHandle(interopHandle);
            }
            else
            {
                handle = default(XPackageInstallationMonitorHandle);
            }

            return hresult;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.handle;
        }

        internal Interop.XPackageInstallationMonitorHandle InteropHandle { get; set; }
    }
}
