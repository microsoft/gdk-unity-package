using System;

namespace XGamingRuntime
{
    public class XblTitleHistory
    {
        internal XblTitleHistory(Interop.XblTitleHistory interopTitleHistory)
        {
            this.HasUserPlayed = interopTitleHistory.hasUserPlayed;
            this.LastTimeUserPlayed = interopTitleHistory.lastTimeUserPlayed.DateTime;
        }

        public bool HasUserPlayed { get; private set; }
        public DateTime LastTimeUserPlayed { get; private set; }
    }
}
