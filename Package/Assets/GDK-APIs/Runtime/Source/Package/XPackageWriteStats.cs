using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XPackageWriteStats
    {
        internal XPackageWriteStats(Interop.XPackageWriteStats interopStruct)
        {
            this.Interval = interopStruct.interval;
            this.Budget = interopStruct.budget;
            this.Elapsed = interopStruct.elapsed;
            this.BytesWritten = interopStruct.bytesWritten;
        }

        public UInt64 Interval { get; private set; }
        public UInt64 Budget { get; private set; }
        public UInt64 Elapsed { get; private set; }
        public UInt64 BytesWritten { get; private set; }
    }
}