using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XVersion
    //{
    //    uint16_t major;
    //    uint16_t minor;
    //    uint16_t build;
    //    uint16_t revision;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XVersion
    {
        internal readonly UInt16 major;
        internal readonly UInt16 minor;
        internal readonly UInt16 build;
        internal readonly UInt16 revision;

        internal XVersion(XGamingRuntime.XVersion publicObject)
        {
            this.major = publicObject.Major;
            this.minor = publicObject.Minor;
            this.build = publicObject.Build;
            this.revision = publicObject.Revision;
        }
    }
}