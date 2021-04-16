using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XPackageInstallationProgress
    {
        internal XPackageInstallationProgress(Interop.XPackageInstallationProgress interopStruct)
        {
            this.TotalBytes = interopStruct.totalBytes;
            this.InstalledBytes = interopStruct.installedBytes;
            this.LaunchBytes = interopStruct.launchBytes;
            this.Launchable = interopStruct.launchable.Value;
            this.Completed = interopStruct.completed.Value;
        }

        public UInt64 TotalBytes { get; private set; }
        public UInt64 InstalledBytes { get; private set; }
        public UInt64 LaunchBytes { get; private set; }
        public bool Launchable { get; private set; }
        public bool Completed { get; private set; }
    }
}