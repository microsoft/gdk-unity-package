using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblAchievementReward
    {
        internal unsafe XblAchievementReward(Interop.XblAchievementReward interopReward)
        {
            this.Name = Converters.PtrToStringUTF8(interopReward.name);
            this.Description = Converters.PtrToStringUTF8(interopReward.description);
            this.Value = Converters.PtrToStringUTF8(interopReward.value);
            this.RewardType = interopReward.rewardType;
            this.ValueType = Converters.PtrToStringUTF8(interopReward.valueType);
            this.MediaAsset = new XblAchievementMediaAsset(*interopReward.mediaAsset);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Value { get; private set; }
        public XblAchievementRewardType RewardType { get; private set; }
        public string ValueType { get; private set; }
        public XblAchievementMediaAsset MediaAsset { get; private set; }
    }
}
