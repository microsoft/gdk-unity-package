using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal class UInt64Ref
    {
        internal UInt64Ref(UInt64 value)
        {
            this.Value = value;
        }

        internal readonly UInt64 Value;
    }
}
