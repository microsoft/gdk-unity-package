using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    /// <summary>
    /// Handle to an Xbox live context. Needed to interact with Xbox live services.
    /// </summary>
    //typedef struct XblContext* XblContextHandle;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblContextHandle
    {
        public IntPtr handle;
    }
}
