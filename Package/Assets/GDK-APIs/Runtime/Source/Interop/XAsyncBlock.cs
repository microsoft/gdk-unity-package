using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void XAsyncCompletionRoutine(XAsyncBlockPtr asyncBlock);

    [StructLayout(LayoutKind.Sequential)]
    public struct XAsyncBlockPtr
    {
        internal XAsyncBlockPtr(IntPtr intPtr)
        {
            this.IntPtr = intPtr;
        }

        internal readonly IntPtr IntPtr;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct XAsyncBlock
    {
        internal XTaskQueueHandle queue;
        internal IntPtr context;
        internal IntPtr callback;

        // 34 bytes for internal data
        Byte i0;
        Byte i1;
        Byte i2;
        Byte i3;
        Byte i4;
        Byte i5;
        Byte i6;
        Byte i7;
        Byte i8;
        Byte i9;
        Byte i10;
        Byte i11;
        Byte i12;
        Byte i13;
        Byte i14;
        Byte i15;
        Byte i16;
        Byte i17;
        Byte i18;
        Byte i19;
        Byte i20;
        Byte i21;
        Byte i22;
        Byte i23;
        Byte i24;
        Byte i25;
        Byte i26;
        Byte i27;
        Byte i28;
        Byte i29;
        Byte i30;
        Byte i31;
        Byte i32;
        Byte i33;
    }
}
