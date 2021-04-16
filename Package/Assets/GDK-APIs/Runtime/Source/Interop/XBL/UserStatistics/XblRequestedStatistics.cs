using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblRequestedStatistics
    // {
    //     _Null_terminated_ char serviceConfigurationId[XBL_SCID_LENGTH];
    //     _Field_z_ const char** statistics;
    //     uint32_t statisticsCount;
    // } XblRequestedStatistics;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblRequestedStatistics
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_SCID_LENGTH)]
        internal readonly byte[] serviceConfigurationId;
        private readonly IntPtr statistics;
        private readonly UInt32 statisticsCount;

        internal XblRequestedStatistics(XGamingRuntime.XblRequestedStatistics requestedStatistics, DisposableCollection disposableCollection)
        {
            this.serviceConfigurationId = Converters.StringToNullTerminatedUTF8ByteArray(requestedStatistics.ServiceConfigurationId, XblInterop.XBL_SCID_LENGTH);
            SizeT statisticsCount;
            this.statistics = Converters.StringArrayToUTF8StringArray(requestedStatistics.Statistics, disposableCollection,
                out statisticsCount);
            this.statisticsCount = statisticsCount.ToUInt32();
        }

        internal static bool ValidateFields(string scid)
        {
            return (
                scid != null &&
                Converters.StringToNullTerminatedUTF8ByteArray(scid).Length <= XblInterop.XBL_SCID_LENGTH
            );
        }
    }
}
