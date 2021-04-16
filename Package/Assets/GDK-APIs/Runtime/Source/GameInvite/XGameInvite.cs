using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XGameInviteEventCallback(string inviteUri);

    partial class SDK
    {
        #region Callbacks
        [MonoPInvokeCallback]
        private static void XGameInviteEventCallback(IntPtr context, UTF8StringPtr inviteUri)
        {
            GCHandle callbackHandle = GCHandle.FromIntPtr(context);
            var callbacks = callbackHandle.Target as UnmanagedCallback<Interop.XGameInviteEventCallback, XGameInviteEventCallback>;
            if (callbacks.userCallback != null)
            {
                callbacks.userCallback.Invoke(inviteUri.GetString());
            }
        }
        #endregion

        public static Int32 XGameInviteRegisterForEvent(XGameInviteEventCallback callback, out XRegistrationToken token)
        {
            var callbacks = new UnmanagedCallback<Interop.XGameInviteEventCallback, XGameInviteEventCallback>
            {
                directCallback = XGameInviteEventCallback,
                userCallback = callback
            };

            GCHandle callbackHandle = GCHandle.Alloc(callbacks);

            XTaskQueueRegistrationToken taskQueueToken;
            Int32 hr = XGRInterop.XGameInviteRegisterForEvent(
                defaultQueue.handle,
                GCHandle.ToIntPtr(callbackHandle),
                callbacks.directCallback,
                out taskQueueToken);

            if (HR.SUCCEEDED(hr))
            {
                token = new XRegistrationToken(callbackHandle, taskQueueToken);
            }
            else
            {
                token = default(XRegistrationToken);
                callbackHandle.Free();
            }

            return hr;
        }

        public static void XGameInviteUnregisterForEvent(XRegistrationToken token)
        {
            if (token == null)
            {
                return;
            }

            XGRInterop.XGameInviteUnregisterForEvent(token.Token, new NativeBool(true));
            token.CallbackHandle.Free();
        }
    }
}
