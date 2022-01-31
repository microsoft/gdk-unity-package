using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public struct XblMultiplayerHandlerCallbackToken
    {
        public const int InvalidHandlerId = 0;

        public Interop.XblFunctionContext FunctionContext;

        public void Reset() { FunctionContext = default(Interop.XblFunctionContext); }
        public bool IsValid() { return IsValid(FunctionContext.context); }

        public static bool IsValid(int interopHandlerId) { return interopHandlerId > InvalidHandlerId; }
    }

    public delegate void XblSubscriptionLostCallback();

    public delegate void XblConnectionIdChangedCallback();

    public delegate void XblSessionChangedCallback(XblMultiplayerSessionChangeEventArgs eventArgs);

    public partial class SDK
    {
        public partial class XBL
        {
            public static XblMultiplayerHandlerCallbackToken XblMultiplayerAddSubscriptionLostHandler(
                XblContextHandle xboxLiveContext,
                XblSubscriptionLostCallback callback)
            {
                var interopFunction = new Interop.XblFunctionContext();

                if (callback != null)
                {
                    var context = _subscriptionLostCallbackManager.GetUniqueContext();
                    interopFunction = XblInterop.XblMultiplayerAddSubscriptionLostHandler(
                        xboxLiveContext.InteropHandle,
                        SubscriptionLostCallbackManager.InteropPInvokeCallback,
                        context);

                    if (XblMultiplayerHandlerCallbackToken.IsValid(interopFunction.context))
                    {
                        _subscriptionLostCallbackManager.AddCallbackForId(
                            interopFunction.context, context, callback);
                    }
                }

                return new XblMultiplayerHandlerCallbackToken() { FunctionContext = interopFunction };
            }

            public static int XblMultiplayerRemoveSubscriptionLostHandler(
                XblContextHandle xboxLiveContext,
                ref XblMultiplayerHandlerCallbackToken subscriptionLostCallbackToken)
            {
                var result = XblInterop.XblMultiplayerRemoveSubscriptionLostHandler(
                    xboxLiveContext.InteropHandle,
                    subscriptionLostCallbackToken.FunctionContext);

                if (HR.SUCCEEDED(result))
                {
                    _subscriptionLostCallbackManager.RemoveCallbackForId(
                        subscriptionLostCallbackToken.FunctionContext.context);
                    subscriptionLostCallbackToken.Reset();
                }

                return result;
            }

            public static XblMultiplayerHandlerCallbackToken XblMultiplayerAddConnectionIdChangedHandler(
                XblContextHandle xboxLiveContext,
                XblConnectionIdChangedCallback callback)
            {
                var interopFunction = new Interop.XblFunctionContext();

                if (callback != null)
                {
                    var context = _connectionIdChangedCallbackManager.GetUniqueContext();
                    interopFunction = XblInterop.XblMultiplayerAddConnectionIdChangedHandler(
                        xboxLiveContext.InteropHandle,
                        ConnectionIdChangedCallbackManager.InteropPInvokeCallback,
                        context);

                    if (XblMultiplayerHandlerCallbackToken.IsValid(interopFunction.context))
                    {
                        _connectionIdChangedCallbackManager.AddCallbackForId(
                            interopFunction.context, context, callback);
                    }
                }

                return new XblMultiplayerHandlerCallbackToken() { FunctionContext = interopFunction };
            }

            public static int XblMultiplayerRemoveConnectionIdChangedHandler(
                XblContextHandle xboxLiveContext,
                ref XblMultiplayerHandlerCallbackToken connectionIdChangedCallbackToken)
            {
                var result = XblInterop.XblMultiplayerRemoveConnectionIdChangedHandler(
                    xboxLiveContext.InteropHandle,
                    connectionIdChangedCallbackToken.FunctionContext);

                if (HR.SUCCEEDED(result))
                {
                    _connectionIdChangedCallbackManager.RemoveCallbackForId(
                        connectionIdChangedCallbackToken.FunctionContext.context);
                    connectionIdChangedCallbackToken.Reset();
                }

                return result;
            }

            public static XblMultiplayerHandlerCallbackToken XblMultiplayerAddSessionChangedHandler(
                XblContextHandle xboxLiveContext,
                XblSessionChangedCallback callback)
            {
                var interopFunction = new Interop.XblFunctionContext();

                if (callback != null)
                {
                    var context = _sessionChangedCallbackManager.GetUniqueContext();
                    interopFunction = XblInterop.XblMultiplayerAddSessionChangedHandler(
                        xboxLiveContext.InteropHandle,
                        SessionChangedCallbackManager.InteropPInvokeCallback,
                        context);

                    if (XblMultiplayerHandlerCallbackToken.IsValid(interopFunction.context))
                    {
                        _sessionChangedCallbackManager.AddCallbackForId(
                            interopFunction.context, context, callback);
                    }
                }

                return new XblMultiplayerHandlerCallbackToken() { FunctionContext = interopFunction };
            }

            public static int XblMultiplayerRemoveSessionChangedHandler(
                XblContextHandle xboxLiveContext,
                ref XblMultiplayerHandlerCallbackToken sessionChangedCallbackToken)
            {
                var result = XblInterop.XblMultiplayerRemoveSessionChangedHandler(
                    xboxLiveContext.InteropHandle,
                    sessionChangedCallbackToken.FunctionContext);

                if (HR.SUCCEEDED(result))
                {
                    _sessionChangedCallbackManager.RemoveCallbackForId(
                        sessionChangedCallbackToken.FunctionContext.context);
                    sessionChangedCallbackToken.Reset();
                }

                return result;
            }

            private static SubscriptionLostCallbackManager _subscriptionLostCallbackManager =
                new SubscriptionLostCallbackManager();

            private class SubscriptionLostCallbackManager :
                InteropCallbackManager<XblSubscriptionLostCallback>
            {
                [MonoPInvokeCallback]
                internal static unsafe void InteropPInvokeCallback(IntPtr context)
                {
                    if (!_subscriptionLostCallbackManager._contextToFunctionId.ContainsKey(context))
                    {
                        return;
                    }

                    var functionId = _subscriptionLostCallbackManager._contextToFunctionId[context];
                    _subscriptionLostCallbackManager.IssueEventCallback(functionId);
                }

                private unsafe void IssueEventCallback(int functionId)
                {
                    if (!_functionIdToHandler.ContainsKey(functionId))
                    {
                        return;
                    }

                    var eventHandler = _functionIdToHandler[functionId];
                    if (eventHandler.Callback != null)
                    {
                        eventHandler.Callback.Invoke();
                    }
                }
            }

            private static ConnectionIdChangedCallbackManager _connectionIdChangedCallbackManager =
                new ConnectionIdChangedCallbackManager();

            private class ConnectionIdChangedCallbackManager :
                InteropCallbackManager<XblConnectionIdChangedCallback>
            {
                [MonoPInvokeCallback]
                internal static unsafe void InteropPInvokeCallback(IntPtr context)
                {
                    if (!_connectionIdChangedCallbackManager._contextToFunctionId.ContainsKey(context))
                    {
                        return;
                    }

                    var functionId = _connectionIdChangedCallbackManager._contextToFunctionId[context];
                    _connectionIdChangedCallbackManager.IssueEventCallback(functionId);
                }

                private unsafe void IssueEventCallback(int functionId)
                {
                    if (!_functionIdToHandler.ContainsKey(functionId))
                    {
                        return;
                    }

                    var eventHandler = _functionIdToHandler[functionId];
                    if (eventHandler.Callback != null)
                    {
                        eventHandler.Callback.Invoke();
                    }
                }
            }

            private static SessionChangedCallbackManager _sessionChangedCallbackManager =
                new SessionChangedCallbackManager();

            private class SessionChangedCallbackManager :
                InteropCallbackManager<XblSessionChangedCallback>
            {
                [MonoPInvokeCallback]
                internal static unsafe void InteropPInvokeCallback(
                    IntPtr context,
                    Interop.XblMultiplayerSessionChangeEventArgs args)
                {
                    if (!_sessionChangedCallbackManager._contextToFunctionId.ContainsKey(context))
                    {
                        return;
                    }

                    var functionId = _sessionChangedCallbackManager._contextToFunctionId[context];
                    _sessionChangedCallbackManager.IssueEventCallback(functionId, new XblMultiplayerSessionChangeEventArgs(args));
                }

                private unsafe void IssueEventCallback(
                    int functionId,
                    XblMultiplayerSessionChangeEventArgs eventArgs)
                {
                    if (!_functionIdToHandler.ContainsKey(functionId))
                    {
                        return;
                    }

                    var eventHandler = _functionIdToHandler[functionId];
                    if (eventHandler.Callback != null)
                    {
                        eventHandler.Callback.Invoke(eventArgs);
                    }
                }
            }
        }
    }
}
