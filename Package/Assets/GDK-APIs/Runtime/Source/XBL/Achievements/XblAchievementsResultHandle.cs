using System;

namespace XGamingRuntime
{
    public class XblAchievementsResultHandle : EquatableHandle
    {
        internal XblAchievementsResultHandle(Interop.XblAchievementsResultHandle interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal override IntPtr GetInternalPtr()
        {
            return InteropHandle.handle;
        }

        internal Interop.XblAchievementsResultHandle InteropHandle { get; set; }
    }
}
