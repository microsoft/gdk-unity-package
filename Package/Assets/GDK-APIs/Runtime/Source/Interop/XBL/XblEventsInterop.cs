using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal partial class XblInterop
    {
        //STDAPI XblEventsWriteInGameEvent(
        //    _In_ XblContextHandle xboxLiveContext,
        //    _In_z_ const char* eventName,
        //    _In_opt_z_ const char* dimensionsJson,
        //    _In_opt_z_ const char* measurementsJson
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XblEventsWriteInGameEvent(
            XblContextHandle xboxLiveContext,
            byte[] eventName,
            [Optional] byte[] dimensionsJson,
            [Optional] byte[] measurementsJson);
    }
}
