using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XColor
    //{
    //    union
    //    {
    //        struct
    //        {
    //            uint8_t A;
    //            uint8_t R;
    //            uint8_t G;
    //            uint8_t B;
    //        };
    //        uint32_t Value;
    //    };
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XColor
    {
        internal readonly byte A;
        internal readonly byte R;
        internal readonly byte G;
        internal readonly byte B;
    }
}
