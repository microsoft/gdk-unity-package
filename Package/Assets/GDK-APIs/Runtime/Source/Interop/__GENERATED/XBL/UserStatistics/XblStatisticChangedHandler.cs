using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public unsafe delegate void XblStatisticChangedHandler(XblStatisticChangeEventArgs statisticChangeEventArgs, void* context);
}
