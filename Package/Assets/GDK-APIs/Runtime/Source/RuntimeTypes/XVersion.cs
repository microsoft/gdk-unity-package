using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XVersion
    {
        internal XVersion(Interop.XVersion interopStruct)
        {
            this.Major = interopStruct.major;
            this.Minor = interopStruct.minor;
            this.Build = interopStruct.build;
            this.Revision = interopStruct.revision;
        }

        public UInt16 Major { get; private set; }
        public UInt16 Minor { get; private set; }
        public UInt16 Build { get; private set; }
        public UInt16 Revision { get; private set; }
    }
}