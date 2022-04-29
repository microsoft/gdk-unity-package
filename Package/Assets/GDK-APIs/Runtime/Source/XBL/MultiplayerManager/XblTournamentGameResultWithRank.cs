using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    /// <summary>
    /// Deprecated
    /// </summary>
    public class XblTournamentGameResultWithRank
    {
        internal XblTournamentGameResultWithRank(Interop.XblTournamentGameResultWithRank interopStruct)
        {
            this.Result = interopStruct.Result;
            this.Ranking = interopStruct.Ranking;
        }

        public XblTournamentGameResult Result { get; private set; }
        public UInt64 Ranking { get; private set; }
    }
}