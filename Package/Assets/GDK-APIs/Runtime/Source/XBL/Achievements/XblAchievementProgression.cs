using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblAchievementProgression
    {
        internal unsafe XblAchievementProgression(Interop.XblAchievementProgression interopProgression)
        {
            this.Requirements = Converters.PtrToClassArray
                                    <XblAchievementRequirement, Interop.XblAchievementRequirement>(
                                        (IntPtr)interopProgression.requirements, 
                                        interopProgression.requirementsCount, 
                                        (r) => new XblAchievementRequirement(r)
                                    );
            this.TimeUnlocked = new DateTime(interopProgression.timeUnlocked);
        }

        public XblAchievementRequirement[] Requirements { get; private set; }
        public DateTime TimeUnlocked { get; private set; }
    }
}
