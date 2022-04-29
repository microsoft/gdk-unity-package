using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblTournamentGameResult : uint32_t
    //{
    //    NoContest,
    //    Win,
    //    Loss,
    //    Draw,
    //    Rank,
    //    NoShow,
    //};
    /// <summary>
    /// Deprecated
    /// </summary>
    public enum XblTournamentGameResult : UInt32
    {
        NoContest = 0,
        Win = 1,
        Loss = 2,
        Draw = 3,
        Rank = 4,
        NoShow = 5,
    }
}