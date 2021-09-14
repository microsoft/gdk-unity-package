using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public struct XblRealTimeActivityCallbackToken
    {
        public const int InvalidHandlerId = 0;

        public int InteropHandlerId;

        public void Reset() { InteropHandlerId = InvalidHandlerId; }
        public bool IsValid() { return InteropHandlerId > InvalidHandlerId; }
    }

    public delegate void XblConnectionStateChangeCallback(XblRealTimeActivityConnectionState newConnectionState);

    public delegate void XblConnectionResyncCallback();

    public partial class SDK
    {
        public partial class XBL
        {
            public static XblRealTimeActivityCallbackToken XblRealTimeActivityAddConnectionStateChangeHandler(
                XblContextHandle xboxLiveContext,
                XblConnectionStateChangeCallback callback)
            {
                int interopHandlerId = XblRealTimeActivityCallbackToken.InvalidHandlerId;

                if (callback != null)
                {
                    interopHandlerId = RealTimeActivity.XblRealTimeActivityAddConnectionStateChangeHandler(
                        xboxLiveContext.InteropHandle.handle,
                        (IntPtr context, XblRealTimeActivityConnectionState connectionState) =>
                        {
                            callback?.Invoke(connectionState);
                        },
                        default(IntPtr));
                }

                return new XblRealTimeActivityCallbackToken() { InteropHandlerId = interopHandlerId };
            }

            public static int XblRealTimeActivityRemoveConnectionStateChangeHandler(
                XblContextHandle xboxLiveContext,
                ref XblRealTimeActivityCallbackToken connectionStateChangeCallbackToken)
            {
                var result = RealTimeActivity.XblRealTimeActivityRemoveConnectionStateChangeHandler(
                    xboxLiveContext.InteropHandle.handle,
                    connectionStateChangeCallbackToken.InteropHandlerId);

                if (HR.SUCCEEDED(result))
                {
                    connectionStateChangeCallbackToken.Reset();
                }

                return result;
            }

            public static XblRealTimeActivityCallbackToken XblRealTimeActivityAddResyncHandler(
                XblContextHandle xboxLiveContext,
                XblConnectionResyncCallback callback)
            {
                int interopHandlerId = XblRealTimeActivityCallbackToken.InvalidHandlerId;

                if (callback != null)
                {
                    interopHandlerId = RealTimeActivity.XblRealTimeActivityAddResyncHandler(
                        xboxLiveContext.InteropHandle.handle,
                        (IntPtr context) =>
                        {
                            callback?.Invoke();
                        },
                        default(IntPtr));
                }

                return new XblRealTimeActivityCallbackToken() { InteropHandlerId = interopHandlerId };
            }

            public static int XblRealTimeActivityRemoveResyncHandler(
                XblContextHandle xboxLiveContext,
                ref XblRealTimeActivityCallbackToken connectionResyncCallbackToken)
            {
                var result = RealTimeActivity.XblRealTimeActivityRemoveResyncHandler(
                    xboxLiveContext.InteropHandle.handle,
                    connectionResyncCallbackToken.InteropHandlerId);

                if (HR.SUCCEEDED(result))
                {
                    connectionResyncCallbackToken.Reset();
                }

                return result;
            }
        }
    }
}
