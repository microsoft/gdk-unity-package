using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionInfo
    {
        internal XblMultiplayerSessionInfo(Interop.XblMultiplayerSessionInfo interopStruct)
        {
            this.ContractVersion = interopStruct.ContractVersion;
            this.Branch = interopStruct.GetBranch();
            this.ChangeNumber = interopStruct.ChangeNumber;
            this.CorrelationId = interopStruct.GetCorrelationId();
            this.StartTime = interopStruct.StartTime.DateTime;
            this.NextTimer = interopStruct.NextTimer.DateTime;
            this.SearchHandleId = interopStruct.GetSearchHandleId();
        }

        public UInt32 ContractVersion { get; private set; }
        public string Branch { get; private set; }
        public UInt64 ChangeNumber { get; private set; }
        public string CorrelationId { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime NextTimer { get; private set; }
        public string SearchHandleId { get; private set; }
    }
}