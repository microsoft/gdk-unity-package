using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblStatisticChangeEventArgs
    // {
    //     uint64_t xboxUserId;
    //     _Null_terminated_ char serviceConfigurationId[XBL_SCID_LENGTH];
    //     XblStatistic latestStatistic;
    // } XblStatisticChangeEventArgs;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblStatisticChangeEventArgs
    {
        internal readonly UInt64 xboxUserId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_SCID_LENGTH)]
        internal readonly byte[] serviceConfigurationId;
        internal readonly XblStatistic latestStatistic;
    }
}
