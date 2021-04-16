using System;
using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerEvent
    {
        internal XblMultiplayerEvent(Interop.XblMultiplayerEvent interopStruct)
        {
            this.Result = interopStruct.Result;
            this.ErrorMessage = interopStruct.ErrorMessage.GetString();
            this.EventType = interopStruct.EventType;
            this.EventArgsHandle = new XblMultiplayerEventArgsHandle(interopStruct.EventArgsHandle);
            this.SessionType = interopStruct.SessionType;

            // Unwrap and unpin wrapped context pointer
            this.Context = null;
            if (interopStruct.Context != IntPtr.Zero)
            {
                var handle = GCHandle.FromIntPtr(interopStruct.Context);
                this.Context = handle.Target;
                handle.Free();
            }
        }

        public Int32 Result { get; private set; }
        public string ErrorMessage { get; private set; }
        public object Context { get; private set; }
        public XblMultiplayerEventType EventType { get; private set; }
        public XblMultiplayerEventArgsHandle EventArgsHandle { get; private set; }
        public XblMultiplayerSessionType SessionType { get; private set; }
    }
}