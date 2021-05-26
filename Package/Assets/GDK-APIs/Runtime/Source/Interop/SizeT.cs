﻿using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SizeT 
    {
        public bool IsZero { get { return value == UIntPtr.Zero; } }

        public SizeT(Int32 length)
        {
            this.value = new UIntPtr(Convert.ToUInt64(length));
        }

        public SizeT(UInt32 length)
        {
            this.value = new UIntPtr(Convert.ToUInt64(length));
        }

        public SizeT(UIntPtr length)
        {
            this.value = length;
        }

        public UInt32 ToUInt32()
        {
            return Convert.ToUInt32(value.ToUInt64());
        }

        public Int32 ToInt32()
        {
            return Convert.ToInt32(value.ToUInt64());
        }

        private readonly UIntPtr value;
    }
}
