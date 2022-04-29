using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblTournamentArbitrationStatus : uint32_t
    //{
    //    Waiting,
    //    InProgress,
    //    Complete,
    //    Playing,
    //    Incomplete,
    //    Joining
    //};
    /// <summary>
    /// Deprecated
    /// </summary>
    public enum XblTournamentArbitrationStatus : UInt32
    {
        Waiting = 0,
        InProgress = 1,
        Complete = 2,
        Playing = 3,
        Incomplete = 4,
        Joining = 5,
    }
}