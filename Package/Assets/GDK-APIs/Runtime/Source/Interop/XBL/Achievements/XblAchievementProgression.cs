using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblAchievementProgression
    //{
    //    XblAchievementRequirement* requirements;
    //    size_t requirementsCount;
    //    time_t timeUnlocked;
    //}
    //XblAchievementProgression;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblAchievementProgression
    {
        #region IntPtr wrappers
        internal T[] GetRequirements<T>(Func<XblAchievementRequirement, T> ctor) { return Converters.PtrToClassArray(this.requirements, this.requirementsCount, ctor); }
        #endregion

        private readonly IntPtr requirements;
        private readonly SizeT requirementsCount;
        internal readonly TimeT timeUnlocked;
    }
}
