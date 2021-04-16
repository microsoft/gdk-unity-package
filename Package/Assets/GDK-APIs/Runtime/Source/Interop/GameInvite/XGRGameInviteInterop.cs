using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef void CALLBACK XGameInviteEventCallback(
    //     _In_opt_ void* context,
    //     _In_ const char* inviteUri
    // );
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate void XGameInviteEventCallback(IntPtr context, UTF8StringPtr inviteUri);

    partial class XGRInterop
    {
        // STDAPI XGameInviteRegisterForEvent(
        //     _In_opt_ XTaskQueueHandle queue,
        //     _In_opt_ void* context,
        //     _In_ XGameInviteEventCallback* callback,
        //     _Out_ XTaskQueueRegistrationToken* token
        //     );
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern Int32 XGameInviteRegisterForEvent(XTaskQueueHandle queue, IntPtr context, XGameInviteEventCallback callback, out XTaskQueueRegistrationToken token);

        // STDAPI_(bool) XGameInviteUnregisterForEvent(
        //     _In_ XTaskQueueRegistrationToken token,
        //     _In_ bool wait
        //     );
        [DllImport(ThunkDllName, CallingConvention = CallingConvention.StdCall)]
        internal static extern NativeBool XGameInviteUnregisterForEvent(XTaskQueueRegistrationToken token, NativeBool wait);
    }
}