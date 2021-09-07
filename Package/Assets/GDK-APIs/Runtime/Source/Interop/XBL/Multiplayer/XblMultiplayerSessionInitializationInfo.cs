using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionInitializationInfo
    //{
    //    XblMultiplayerInitializationStage Stage;
    //    time_t StageStartTime;
    //    uint32_t Episode;
    //} XblMultiplayerSessionInitializationInfo;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerSessionInitializationInfo
    {
        internal readonly XblMultiplayerInitializationStage Stage;
        internal readonly TimeT StageStartTime;
        internal readonly UInt32 Episode;

        internal XblMultiplayerSessionInitializationInfo(XGamingRuntime.XblMultiplayerSessionInitializationInfo publicObject)
        {
            this.Stage = publicObject.Stage;
            this.StageStartTime = new TimeT(publicObject.StageStartTime);
            this.Episode = publicObject.Episode;
        }
    }
}