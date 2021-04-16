using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    internal partial class XblInterop
    {
        //STDAPI_(XblErrorCondition) XblGetErrorCondition(
        //    _In_ HRESULT hr
        //) XBL_NOEXCEPT;
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern XblErrorCondition XblGetErrorCondition(Int32 hr);
    }
}
