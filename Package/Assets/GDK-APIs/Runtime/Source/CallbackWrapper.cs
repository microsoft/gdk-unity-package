// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime
{
    public class CallbackWrapper<T> : IDisposable where T : Delegate
    {
        private GCHandle selfPtr;

        public CallbackWrapper(T callback, IntPtr context, T staticCallback)
        {
            if (staticCallback.Target != null)
            {
                throw new InvalidOperationException("staticCallback must point to a static method");
            }

            this.Callback = callback;
            this.Context = context;
            this.selfPtr = GCHandle.Alloc(this);
            this.StaticCallback = staticCallback;
        }

        ~CallbackWrapper()
        {
            Dispose(disposing: false);
        }

        public T StaticCallback { get; private set; }
        public T Callback { get; private set; }
        public IntPtr Context { get; private set; }

        public IntPtr CallbackContext
        {
            get { return GCHandle.ToIntPtr(this.selfPtr); }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.selfPtr.Free();
        }
    }
}
