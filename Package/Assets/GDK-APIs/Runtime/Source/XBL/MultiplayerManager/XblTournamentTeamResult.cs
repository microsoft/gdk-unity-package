using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    /// <summary>
    /// Deprecated
    /// </summary>
    public class XblTournamentTeamResult
    {
        internal XblTournamentTeamResult(Interop.XblTournamentTeamResult interopStruct)
        {
            this.Team = interopStruct.Team.GetString();
            this.GameResult = new XblTournamentGameResultWithRank(interopStruct.GameResult);
        }

        public string Team { get; private set; }
        public XblTournamentGameResultWithRank GameResult { get; private set; }
    }
}