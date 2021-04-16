using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionInitializationInfo
    {
        internal XblMultiplayerSessionInitializationInfo(Interop.XblMultiplayerSessionInitializationInfo interopStruct)
        {
            this.Stage = interopStruct.Stage;
            this.StageStartTime = interopStruct.StageStartTime.DateTime;
            this.Episode = interopStruct.Episode;
        }

        public XblMultiplayerInitializationStage Stage { get; private set; }
        public DateTime StageStartTime { get; private set; }
        public UInt32 Episode { get; private set; }
    }
}