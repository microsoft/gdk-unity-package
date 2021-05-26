using System;

namespace XGamingRuntime
{
    public class XblAchievementTimeWindow
    {
        internal XblAchievementTimeWindow(Interop.XblAchievementTimeWindow interopTimeWindow)
        {
            this.StartDate = new DateTime(interopTimeWindow.startDate);
            this.EndDate = new DateTime(interopTimeWindow.endDate);
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}
