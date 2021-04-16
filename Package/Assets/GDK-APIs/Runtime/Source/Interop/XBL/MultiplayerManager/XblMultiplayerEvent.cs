using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerEvent
    //{
    //    HRESULT Result;
    //    _Field_z_ const char* ErrorMessage;
    //    void* Context;
    //    XblMultiplayerEventType EventType;
    //    XblMultiplayerEventArgsHandle EventArgsHandle;
    //    XblMultiplayerSessionType SessionType;
    //} XblMultiplayerEvent;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerEvent
    {
        internal readonly Int32 Result;
        internal readonly UTF8StringPtr ErrorMessage;
        internal readonly IntPtr Context;
        internal readonly XblMultiplayerEventType EventType;
        internal readonly XblMultiplayerEventArgsHandle EventArgsHandle;
        internal readonly XblMultiplayerSessionType SessionType;
    }
}