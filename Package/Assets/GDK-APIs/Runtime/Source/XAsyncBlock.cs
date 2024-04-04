// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public delegate void XAsyncCompletionRoutine(XAsyncBlock block);
    public delegate Int32 XAsyncWork(XAsyncBlock asyncBlock);

    public class XAsyncBlock : IDisposable
    {
        public XTaskQueueHandle Queue;
        public IntPtr Context;
        public XAsyncCompletionRoutine Callback;
        public XAsyncBlockInterop Interop;

        private GCHandle callbackObjHandle;
        private GCHandle interopHandle;

        [AOT.MonoPInvokeCallback(typeof(XAsyncCompletionRoutineInterop))]
        private static void OnXAsyncBlockCompletion(IntPtr asyncBlock)
        {
            XAsyncBlockInterop tmp = (XAsyncBlockInterop)Marshal.PtrToStructure(asyncBlock, typeof(XAsyncBlockInterop));
            GCHandle contextHandle = GCHandle.FromIntPtr(tmp.context);
            XAsyncBlock blockRef = contextHandle.Target as XAsyncBlock;
            blockRef.DoCompletionCallback();
        }

        private static XAsyncCompletionRoutineInterop InteropCallback = OnXAsyncBlockCompletion;

        bool disposedValue;

        public XAsyncBlock(XTaskQueueHandle queue, XAsyncCompletionRoutine callback, IntPtr context)
        {
            this.Queue = queue;
            this.Context = context;

            this.Callback = callback;
            this.Interop = new XAsyncBlockInterop()
            {
                queue = queue != null ? queue.Handle : IntPtr.Zero,
            };

            if (callback != null)
            {
                this.callbackObjHandle = GCHandle.Alloc(this);
                this.Interop.context = GCHandle.ToIntPtr(this.callbackObjHandle);
                this.Interop.callback = Marshal.GetFunctionPointerForDelegate(InteropCallback);
            }

            this.interopHandle = GCHandle.Alloc(this.Interop, GCHandleType.Pinned);
        }

        public bool IsCompleted { get; private set; }
        public IntPtr InteropPtr { get { return this.interopHandle.AddrOfPinnedObject(); } }

        void DoCompletionCallback()
        {
            this.Callback(this);
            this.IsCompleted = true;

            // Once the callback has been called, this block is not expected to be used anymore.
            // Free interop resources now
            if (this.callbackObjHandle.IsAllocated)
            {
                this.callbackObjHandle.Free();
            }
            if (this.interopHandle.IsAllocated)
            {
                this.interopHandle.Free();
            }
        }

        //struct XAsyncBlock
        //{
        //    XTaskQueueHandle queue;
        //    void* context;
        //    XAsyncCompletionRoutine* callback;
        //    unsigned char internal[sizeof(void*) * 4];
        //};
        [StructLayout(LayoutKind.Sequential)]
        unsafe public struct XAsyncBlockInterop
        {
            /// <summary>
            /// The queue to queue the call on
            /// </summary>
            public IntPtr queue;

            /// <summary>
            /// Optional context pointer to pass to the callback
            /// </summary>
            public IntPtr context;

            /// <summary>
            /// Optional callback that will be invoked when the call completes
            /// </summary>
            public IntPtr callback;

            /// <summary>
            /// Internal use only
            /// </summary>
            public fixed byte reserved[32];
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (this.callbackObjHandle.IsAllocated)
                {
                    this.callbackObjHandle.Free();
                }

                if (this.interopHandle.IsAllocated)
                {
                    this.interopHandle.Free();
                }

                disposedValue = true;
            }
        }

        ~XAsyncBlock()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    partial class SDK
    {
        static private Dictionary<IntPtr, CallbackWrapper<XAsyncWorkInterop>> asyncWorkCallbackDictionary
            = new Dictionary<IntPtr, CallbackWrapper<XAsyncWorkInterop>>();

        [AOT.MonoPInvokeCallback(typeof(XAsyncWorkInterop))]
        private static Int32 OnAsyncWorkCallback(IntPtr asyncBlock)
        {
            CallbackWrapper<XAsyncWorkInterop> asyncWorkWrapper;
            if (!asyncWorkCallbackDictionary.TryGetValue(asyncBlock, out asyncWorkWrapper))
            {
                return HR.E_INVALIDARG;
            };

            GCHandle handle = GCHandle.FromIntPtr(asyncWorkWrapper.CallbackContext);
            var wrapper = handle.Target as CallbackWrapper<XAsyncWorkInterop>;
            return wrapper.Callback(asyncBlock);
        }

        public static Int32 XAsyncGetStatus(XAsyncBlock asyncBlock, bool wait)
        {
            return XGRInterop.XAsyncGetStatus(asyncBlock.InteropPtr, wait);
        }

        public static Int32 XAsyncGetResultSize(XAsyncBlock asyncBlock, out UInt64 bufferSize)
        {
            return XGRInterop.XAsyncGetResultSize(asyncBlock.InteropPtr, out bufferSize);
        }

        public static void XAsyncCancel(XAsyncBlock asyncBlock)
        {
            if (asyncBlock.IsCompleted)
            {
                // Block is already completed, do nothing
                return;
            }

            CallbackWrapper<XAsyncWorkInterop> asyncWorkCallback;
            if (asyncWorkCallbackDictionary.TryGetValue(asyncBlock.InteropPtr, out asyncWorkCallback))
            {
                asyncWorkCallback.Dispose();
                asyncWorkCallback = null;
                asyncWorkCallbackDictionary.Remove(asyncBlock.InteropPtr);
            }

            XGRInterop.XAsyncCancel(asyncBlock.InteropPtr);
        }

        public static Int32 XAsyncRun(XAsyncBlock asyncBlock, XAsyncWork work)
        {
            // Rewrite the callback for an spesific AsyncBlock
            CallbackWrapper<XAsyncWorkInterop> preAsyncWorkCallback;
            if (asyncWorkCallbackDictionary.TryGetValue(asyncBlock.InteropPtr, out preAsyncWorkCallback))
            {
                preAsyncWorkCallback.Dispose();
                preAsyncWorkCallback = null;
                asyncWorkCallbackDictionary.Remove(asyncBlock.InteropPtr);
            }

            XAsyncWorkInterop localCallback = (IntPtr _asyncBlockInterop) =>
            {
                return work(asyncBlock);
            };

            CallbackWrapper<XAsyncWorkInterop> wrapper = new CallbackWrapper<XAsyncWorkInterop>(localCallback, asyncBlock.Context, OnAsyncWorkCallback);

            asyncWorkCallbackDictionary.Add(asyncBlock.InteropPtr, wrapper);

            return XGRInterop.XAsyncRun(asyncBlock.InteropPtr, wrapper.StaticCallback);
        }
    }
}
