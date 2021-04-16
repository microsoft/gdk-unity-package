using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XPackageInstallationProgress
    //{
    //    uint64_t totalBytes;
    //    uint64_t installedBytes;
    //    uint64_t launchBytes;
    //    bool launchable;
    //    bool completed;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XPackageInstallationProgress
    {
        internal readonly UInt64 totalBytes;
        internal readonly UInt64 installedBytes;
        internal readonly UInt64 launchBytes;
        internal readonly NativeBool launchable;
        internal readonly NativeBool completed;

        internal XPackageInstallationProgress(XGamingRuntime.XPackageInstallationProgress publicObject)
        {
            this.totalBytes = publicObject.TotalBytes;
            this.installedBytes = publicObject.InstalledBytes;
            this.launchBytes = publicObject.LaunchBytes;
            this.launchable = new NativeBool(publicObject.Launchable);
            this.completed = new NativeBool(publicObject.Completed);
        }
    }
}