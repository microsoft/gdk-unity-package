using System;

namespace XGamingRuntime
{
    public class XblAchievementsResultHandle : EquatableHandle
    {
        internal unsafe XblAchievementsResultHandle(Interop.XblAchievementsResult* interopHandle)
        {
            this.InteropHandle = interopHandle;
        }

        internal override IntPtr GetInternalPtr()
        {
            IntPtr ptr = default(IntPtr);
            unsafe
            {
                ptr = (IntPtr)InteropHandle;
            }
            return ptr;
        }

        internal unsafe Interop.XblAchievementsResult* InteropHandle { get; set; }
    }
}
