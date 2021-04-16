using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XPackageWriteStats
    //{
    //    uint64_t interval;
    //    uint64_t budget;
    //    uint64_t elapsed;
    //    uint64_t bytesWritten;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XPackageWriteStats
    {
        internal readonly UInt64 interval;
        internal readonly UInt64 budget;
        internal readonly UInt64 elapsed;
        internal readonly UInt64 bytesWritten;

        internal XPackageWriteStats(XGamingRuntime.XPackageWriteStats publicObject)
        {
            this.interval = publicObject.Interval;
            this.budget = publicObject.Budget;
            this.elapsed = publicObject.Elapsed;
            this.bytesWritten = publicObject.BytesWritten;
        }
    }
}