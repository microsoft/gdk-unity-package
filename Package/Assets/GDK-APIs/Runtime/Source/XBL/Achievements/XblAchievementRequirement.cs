using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblAchievementRequirement
    {
        internal unsafe XblAchievementRequirement(Interop.XblAchievementRequirement interopRequirement)
        {
            this.Id = Converters.PtrToStringUTF8(interopRequirement.id);
            this.CurrentProgressValue = Converters.PtrToStringUTF8(interopRequirement.currentProgressValue);
            this.TargetProgressValue = Converters.PtrToStringUTF8(interopRequirement.targetProgressValue);
        }

        public string Id { get; private set; }
        public string CurrentProgressValue { get; private set; }
        public string TargetProgressValue { get; private set; }
    }
}
