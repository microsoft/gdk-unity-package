using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XStoreProductQuery* XStoreProductQueryHandle;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreProductQueryHandle
    {
        private readonly IntPtr intPtr;
    }
}
