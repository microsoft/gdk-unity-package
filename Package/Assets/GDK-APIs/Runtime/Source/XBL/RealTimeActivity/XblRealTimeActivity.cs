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

    public delegate void XblConnectionStateChangeCallback(
        XblRealTimeActivityConnectionState newConnectionState);

    public delegate void XblConnectionResyncCallback();

    public partial class SDK
    {
        public partial class XBL
        {
            /// <summary>
            /// Wraps the underlying native XblRealTimeActivityAddConnectionStateChangeHandler API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/real_time_activity_c/functions/xblrealtimeactivityaddconnectionstatechangehandler
            /// </summary>
            /// <param name="xboxLiveContext"></param>
            /// <param name="callback"></param>
            /// <returns>a XblRealTimeActivityCallbackToken with which to remove the callback</returns>
            public static XblRealTimeActivityCallbackToken XblRealTimeActivityAddConnectionStateChangeHandler(
                XblContextHandle xboxLiveContext,
                XblConnectionStateChangeCallback callback)
            {
                int interopHandlerId = XblRealTimeActivityCallbackToken.InvalidHandlerId;

                if (callback != null)
                {
                    var context = _connectionStateChangeCallbackManager.GetUniqueContext();
                    interopHandlerId = RealTimeActivity.XblRealTimeActivityAddConnectionStateChangeHandler(
                        xboxLiveContext.InteropHandle.handle,
                        _connectionStateChangeCallbackManager.InteropPInvokeCallback,
                        context);

                    if (interopHandlerId > 0)
                    {
                        _connectionStateChangeCallbackManager.AddCallbackForId(
                            interopHandlerId, context, callback);
                    }
                }

                return new XblRealTimeActivityCallbackToken() { InteropHandlerId = interopHandlerId };
            }

            /// <summary>
            /// Wraps the underlying native XblRealTimeActivityRemoveConnectionStateChangeHandler API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/real_time_activity_c/functions/xblrealtimeactivityremoveconnectionstatechangehandler
            /// </summary>
            /// <param name="xboxLiveContext"></param>
            /// <param name="connectionStateChangeCallbackToken"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblRealTimeActivityRemoveConnectionStateChangeHandler(
                XblContextHandle xboxLiveContext,
                ref XblRealTimeActivityCallbackToken connectionStateChangeCallbackToken)
            {
                var result = RealTimeActivity.XblRealTimeActivityRemoveConnectionStateChangeHandler(
                    xboxLiveContext.InteropHandle.handle,
                    connectionStateChangeCallbackToken.InteropHandlerId);

                if (HR.SUCCEEDED(result))
                {
                    _connectionStateChangeCallbackManager.RemoveCallbackForId(
                        connectionStateChangeCallbackToken.InteropHandlerId);
                    connectionStateChangeCallbackToken.Reset();
                }

                return result;
            }

            /// <summary>
            /// Wraps the underlying native XblRealTimeActivityAddResyncHandler API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/real_time_activity_c/functions/xblrealtimeactivityaddresynchandler
            /// </summary>
            /// <param name="xboxLiveContext"></param>
            /// <param name="callback"></param>
            /// <returns>a XblRealTimeActivityCallbackToken with which to remove the callback</returns>
            public static XblRealTimeActivityCallbackToken XblRealTimeActivityAddResyncHandler(
                XblContextHandle xboxLiveContext,
                XblConnectionResyncCallback callback)
            {
                int interopHandlerId = XblRealTimeActivityCallbackToken.InvalidHandlerId;

                if (callback != null)
                {
                    var context = _connectionResyncCallbackManager.GetUniqueContext();
                    interopHandlerId = RealTimeActivity.XblRealTimeActivityAddResyncHandler(
                        xboxLiveContext.InteropHandle.handle,
                        _connectionResyncCallbackManager.InteropPInvokeCallback,
                        default(IntPtr));

                    if (interopHandlerId > 0)
                    {
                        _connectionResyncCallbackManager.AddCallbackForId(
                            interopHandlerId, context, callback);
                    }
                }

                return new XblRealTimeActivityCallbackToken() { InteropHandlerId = interopHandlerId };
            }

            /// <summary>
            /// Wraps the underlying native XblRealTimeActivityRemoveResyncHandler API:
            /// https://docs.microsoft.com/en-us/gaming/gdk/_content/gc/reference/live/xsapi-c/real_time_activity_c/functions/xblrealtimeactivityremoveresynchandler
            /// </summary>
            /// <param name="xboxLiveContext"></param>
            /// <param name="connectionResyncCallbackToken"></param>
            /// <returns>HR.S_OK on success, otherwise HR.FAILED(...) is true</returns>
            public static int XblRealTimeActivityRemoveResyncHandler(
                XblContextHandle xboxLiveContext,
                ref XblRealTimeActivityCallbackToken connectionResyncCallbackToken)
            {
                var result = RealTimeActivity.XblRealTimeActivityRemoveResyncHandler(
                    xboxLiveContext.InteropHandle.handle,
                    connectionResyncCallbackToken.InteropHandlerId);

                if (HR.SUCCEEDED(result))
                {
                    _connectionResyncCallbackManager.RemoveCallbackForId(
                        connectionResyncCallbackToken.InteropHandlerId);
                    connectionResyncCallbackToken.Reset();
                }

                return result;
            }

            private static ConnectionStateChangeCallbackManager _connectionStateChangeCallbackManager =
                new ConnectionStateChangeCallbackManager();

            private class ConnectionStateChangeCallbackManager :
                InteropCallbackManager<XblConnectionStateChangeCallback>
            {
                [MonoPInvokeCallback]
                internal unsafe void InteropPInvokeCallback(
                    IntPtr context,
                    XblRealTimeActivityConnectionState newConnectionState)
                {
                    if (!_contextToFunctionId.ContainsKey(context))
                    {
                        return;
                    }

                    var functionId = _contextToFunctionId[context];
                    IssueEventCallback(functionId, newConnectionState);
                }

                private unsafe void IssueEventCallback(
                    int functionId,
                    XblRealTimeActivityConnectionState newConnectionState)
                {
                    if (!_functionIdToHandler.ContainsKey(functionId))
                    {
                        return;
                    }

                    var eventHandler = _functionIdToHandler[functionId];
                    eventHandler.Callback?.Invoke(newConnectionState);
                }
            }

            private static ConnectionResyncCallbackManager _connectionResyncCallbackManager =
                new ConnectionResyncCallbackManager();

            private class ConnectionResyncCallbackManager :
                InteropCallbackManager<XblConnectionResyncCallback>
            {
                [MonoPInvokeCallback]
                internal unsafe void InteropPInvokeCallback(IntPtr context)
                {
                    if (!_contextToFunctionId.ContainsKey(context))
                    {
                        return;
                    }

                    var functionId = _contextToFunctionId[context];
                    IssueEventCallback(functionId);
                }

                private unsafe void IssueEventCallback(int functionId)
                {
                    if (!_functionIdToHandler.ContainsKey(functionId))
                    {
                        return;
                    }

                    var eventHandler = _functionIdToHandler[functionId];
                    eventHandler.Callback?.Invoke();
                }
            }
        }
    }
}
