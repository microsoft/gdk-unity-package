using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef int32_t XblFunctionContext;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblFunctionContext
    {
        private readonly Int32 context;
    }
}
