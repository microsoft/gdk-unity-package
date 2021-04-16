using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblServiceConfigurationStatistic
    // {
    //     _Null_terminated_ char serviceConfigurationId[XBL_SCID_LENGTH];
    //     XblStatistic* statistics;
    //     uint32_t statisticsCount;
    // } XblServiceConfigurationStatistic;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblServiceConfigurationStatistic
    {
        internal T[] GetStatistics<T>(Func<XblStatistic, T> ctor) { return Converters.PtrToClassArray(this.statistics, this.statisticsCount, ctor); }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_SCID_LENGTH)]
        internal readonly byte[] serviceConfigurationId;
        private readonly IntPtr statistics;
        private readonly UInt32 statisticsCount;
    }
}
