using System;

namespace XGamingRuntime
{
    public class XblAchievementTimeWindow
    {
        internal XblAchievementTimeWindow(Interop.XblAchievementTimeWindow interopTimeWindow)
        {
            this.StartDate = interopTimeWindow.startDate.DateTime;
            this.EndDate = interopTimeWindow.endDate.DateTime;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}
