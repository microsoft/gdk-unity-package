using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerMatchmakingServer
    //{
    //    XblMatchmakingStatus Status;
    //    const char* StatusDetails;
    //    uint32_t TypicalWaitInSeconds;
    //    XblMultiplayerSessionReference TargetSessionRef;
    //} XblMultiplayerMatchmakingServer;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerMatchmakingServer
    {
        internal readonly XblMatchmakingStatus Status;
        internal readonly UTF8StringPtr StatusDetails;
        internal readonly UInt32 TypicalWaitInSeconds;
        internal readonly XblMultiplayerSessionReference TargetSessionRef;

        internal XblMultiplayerMatchmakingServer(XGamingRuntime.XblMultiplayerMatchmakingServer publicObject, DisposableCollection disposableCollection)
        {
            this.Status = publicObject.Status;
            this.StatusDetails = new UTF8StringPtr(publicObject.StatusDetails, disposableCollection);
            this.TypicalWaitInSeconds = publicObject.TypicalWaitInSeconds;
            this.TargetSessionRef = new XblMultiplayerSessionReference(publicObject.TargetSessionRef);
        }
    }
}