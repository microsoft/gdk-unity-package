using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    /// <summary>
    /// A handle to an achievement result. This handle is used by other APIs to get the achievement objects
    /// and to get the next page of achievements from the service if there is is one. The handle must be closed
    /// using XblAchievementsResultCloseHandle when the result is no longer needed.
    /// </summary>
    /// typedef struct XblAchievementsResult* XblAchievementsResultHandle;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblAchievementsResultHandle
    {
        internal readonly IntPtr handle;
    }
}
