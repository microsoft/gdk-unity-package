using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblTournamentGameResultWithRank
    //{
    //    XblTournamentGameResult Result;
    //    uint64_t Ranking;
    //} XblTournamentGameResultWithRank;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblTournamentGameResultWithRank
    {
        internal readonly XblTournamentGameResult Result;
        internal readonly UInt64 Ranking;

        internal XblTournamentGameResultWithRank(XGamingRuntime.XblTournamentGameResultWithRank publicObject)
        {
            this.Result = publicObject.Result;
            this.Ranking = publicObject.Ranking;
        }
    }
}