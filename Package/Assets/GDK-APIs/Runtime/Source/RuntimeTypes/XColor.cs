using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XColor
    {
        internal XColor(Interop.XColor interopStruct)
        {
            this.A = interopStruct.A;
            this.R = interopStruct.R;
            this.G = interopStruct.G;
            this.B = interopStruct.B;
            this.Value = BitConverter.ToUInt32(new byte[] { interopStruct.A, interopStruct.R, interopStruct.G, interopStruct.B }, 0);
        }

        public Byte A { get; private set; }
        public Byte R { get; private set; }
        public Byte G { get; private set; }
        public Byte B { get; private set; }
        public UInt32 Value { get; private set; }
    }
}
