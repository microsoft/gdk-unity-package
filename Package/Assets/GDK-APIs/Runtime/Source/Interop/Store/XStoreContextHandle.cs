using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XStoreContext* XStoreContextHandle;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreContextHandle
    {
        internal readonly IntPtr intPtr;
    }
}
