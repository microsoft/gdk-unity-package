using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerMemberInitialization
    {
        internal XblMultiplayerMemberInitialization(Interop.XblMultiplayerMemberInitialization interopStruct)
        {
            this.JoinTimeout = interopStruct.JoinTimeout;
            this.MeasurementTimeout = interopStruct.MeasurementTimeout;
            this.EvaluationTimeout = interopStruct.EvaluationTimeout;
            this.ExternalEvaluation = interopStruct.ExternalEvaluation.Value;
            this.MembersNeededToStart = interopStruct.MembersNeededToStart;
        }

        public UInt64 JoinTimeout { get; private set; }
        public UInt64 MeasurementTimeout { get; private set; }
        public UInt64 EvaluationTimeout { get; private set; }
        public bool ExternalEvaluation { get; private set; }
        public UInt32 MembersNeededToStart { get; private set; }
    }
}