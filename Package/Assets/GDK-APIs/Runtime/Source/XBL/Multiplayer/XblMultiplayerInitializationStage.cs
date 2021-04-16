using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblMultiplayerInitializationStage : uint32_t
    //{
    //    Unknown,
    //    None,
    //    Joining,
    //    Measuring,
    //    Evaluating,
    //    Failed
    //};
    public enum XblMultiplayerInitializationStage : UInt32
    {
        Unknown = 0,
        None = 1,
        Joining = 2,
        Measuring = 3,
        Evaluating = 4,
        Failed = 5,
    }
}