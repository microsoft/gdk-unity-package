using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblTournamentTeamResult
    //{
    //    const char* Team;
    //    XblTournamentGameResultWithRank GameResult;
    //} XblTournamentTeamResult;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblTournamentTeamResult
    {
        internal readonly UTF8StringPtr Team;
        internal readonly XblTournamentGameResultWithRank GameResult;

        internal XblTournamentTeamResult(XGamingRuntime.XblTournamentTeamResult publicObject, DisposableCollection disposableCollection)
        {
            this.Team = new UTF8StringPtr(publicObject.Team, disposableCollection);
            this.GameResult = new XblTournamentGameResultWithRank(publicObject.GameResult);
        }
    }
}