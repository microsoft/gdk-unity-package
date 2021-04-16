using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeBool
    {
        internal NativeBool(bool value)
        {
            this.value = (byte)(value ? 1 : 0);
        }

        internal bool Value { get { return value != 0; } }

        private Byte value;
    }
}
