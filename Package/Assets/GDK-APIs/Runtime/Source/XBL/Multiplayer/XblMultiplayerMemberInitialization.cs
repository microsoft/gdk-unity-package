using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerMemberInitialization
    {
        public XblMultiplayerMemberInitialization() { }

        internal XblMultiplayerMemberInitialization(Interop.XblMultiplayerMemberInitialization interopStruct)
        {
            this.JoinTimeout = interopStruct.JoinTimeout;
            this.MeasurementTimeout = interopStruct.MeasurementTimeout;
            this.EvaluationTimeout = interopStruct.EvaluationTimeout;
            this.ExternalEvaluation = interopStruct.ExternalEvaluation.Value;
            this.MembersNeededToStart = interopStruct.MembersNeededToStart;
        }

        public UInt64 JoinTimeout { get; set; }
        public UInt64 MeasurementTimeout { get; set; }
        public UInt64 EvaluationTimeout { get; set; }
        public bool ExternalEvaluation { get; set; }
        public UInt32 MembersNeededToStart { get; set; }
    }
}