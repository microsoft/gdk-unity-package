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
