using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblAchievementTimeWindow
    //{
    //    time_t startDate;
    //    time_t endDate;
    //}
    //XblAchievementTimeWindow;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblAchievementTimeWindow
    {
        internal readonly TimeT startDate;
        internal readonly TimeT endDate;
    }
}
