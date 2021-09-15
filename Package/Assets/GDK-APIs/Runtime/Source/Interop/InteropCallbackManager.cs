using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // should be TDelegate : Delegate, but that is not available until C# 7
    public class InteropCallbackManager<TDelegate> where TDelegate : class
    {
        protected struct HandlerContext
        {
            public IntPtr Context;
            public TDelegate Callback;
        }

        protected readonly Dictionary<IntPtr, int> _contextToFunctionId =
            new Dictionary<IntPtr, int>();
        protected readonly Dictionary<int, HandlerContext> _functionIdToHandler =
            new Dictionary<int, HandlerContext>();

        private int _availableContextId = 1000;

        internal IntPtr GetUniqueContext()
        {
            return new IntPtr(_availableContextId++);
        }

        internal void AddCallbackForId(
            int functionId,
            IntPtr context,
            TDelegate callback)
        {
            _contextToFunctionId[context] = functionId;
            _functionIdToHandler[functionId] = new HandlerContext()
            {
                Context = context,
                Callback = callback
            };
        }

        internal void RemoveCallbackForId(int functionId)
        {
            if (!_functionIdToHandler.ContainsKey(functionId))
            {
                return;
            }

            var eventHandler = _functionIdToHandler[functionId];

            _contextToFunctionId.Remove(eventHandler.Context);
            _functionIdToHandler.Remove(functionId);
        }
    }
}
