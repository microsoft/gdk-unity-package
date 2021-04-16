using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblTitleHistory
    // {
    //     bool hasUserPlayed;
    //     time_t lastTimeUserPlayed;
    // } XblTitleHistory;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblTitleHistory
    {
        [MarshalAs(UnmanagedType.U1)]
        internal readonly bool hasUserPlayed;
        internal readonly TimeT lastTimeUserPlayed;
    }
}
