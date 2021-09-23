using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef int32_t XblFunctionContext;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblFunctionContext
    {
        public readonly Int32 context;
    }
}
