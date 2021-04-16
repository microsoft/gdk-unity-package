using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerMatchmakingServer
    {
        internal XblMultiplayerMatchmakingServer(Interop.XblMultiplayerMatchmakingServer interopStruct)
        {
            this.Status = interopStruct.Status;
            this.StatusDetails = interopStruct.StatusDetails.GetString();
            this.TypicalWaitInSeconds = interopStruct.TypicalWaitInSeconds;
            this.TargetSessionRef = new XblMultiplayerSessionReference(interopStruct.TargetSessionRef);
        }

        public XblMatchmakingStatus Status { get; private set; }
        public string StatusDetails { get; private set; }
        public UInt32 TypicalWaitInSeconds { get; private set; }
        public XblMultiplayerSessionReference TargetSessionRef { get; private set; }
    }
}