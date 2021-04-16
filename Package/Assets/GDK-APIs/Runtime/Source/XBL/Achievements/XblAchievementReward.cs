namespace XGamingRuntime
{
    public class XblAchievementReward
    {
        internal XblAchievementReward(Interop.XblAchievementReward interopReward)
        {
            this.Name = interopReward.name.GetString();
            this.Description = interopReward.description.GetString();
            this.Value = interopReward.value.GetString();
            this.RewardType = interopReward.rewardType;
            this.ValueType = interopReward.valueType.GetString();
            this.MediaAsset = interopReward.GetMediaAsset(ma =>new XblAchievementMediaAsset(ma));
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Value { get; private set; }
        public XblAchievementRewardType RewardType { get; private set; }
        public string ValueType { get; private set; }
        public XblAchievementMediaAsset MediaAsset { get; private set; }
    }
}
