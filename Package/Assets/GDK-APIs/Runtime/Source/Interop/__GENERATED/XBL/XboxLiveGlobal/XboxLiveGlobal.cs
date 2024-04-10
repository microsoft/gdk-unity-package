using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    public static unsafe partial class XboxLiveGlobal
    {
        [DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int XblGetScid([NativeTypeName("const char **")] sbyte** scid);
    }
}
