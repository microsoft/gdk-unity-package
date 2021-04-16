using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblStatistic
    // {
    //     _Field_z_ const char* statisticName;
    //     _Field_z_ const char* statisticType;
    //     _Field_z_ const char* value;
    // } XblStatistic;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblStatistic
    {
        internal readonly UTF8StringPtr statisticName;
        internal readonly UTF8StringPtr statisticType;
        internal readonly UTF8StringPtr value;
    }
}
