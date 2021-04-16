using System;

namespace XGamingRuntime
{
    public class XblAchievementProgression
    {
        internal XblAchievementProgression(Interop.XblAchievementProgression interopProgression)
        {
            this.Requirements = interopProgression.GetRequirements(r =>new XblAchievementRequirement(r));
            this.TimeUnlocked = interopProgression.timeUnlocked.DateTime;
        }

        public XblAchievementRequirement[] Requirements { get; private set; }
        public DateTime TimeUnlocked { get; private set; }
    }
}
