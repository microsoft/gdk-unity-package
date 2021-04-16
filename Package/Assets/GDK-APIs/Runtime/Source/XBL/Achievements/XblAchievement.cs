using System;

namespace XGamingRuntime
{
    public class XblAchievement
    {
        internal XblAchievement(Interop.XblAchievement interopAchievement)
        {
            this.Id = interopAchievement.id.GetString();
            this.ServiceConfigurationId = interopAchievement.serviceConfigurationId.GetString();
            this.Name = interopAchievement.name.GetString();
            this.TitleAssociations = interopAchievement.GetTitleAssociations(ta =>new XblAchievementTitleAssociation(ta));
            this.ProgressState = interopAchievement.progressState;
            this.Progression = new XblAchievementProgression(interopAchievement.progression);
            this.MediaAssets = interopAchievement.GetMediaAssets(ma =>new XblAchievementMediaAsset(ma));
            this.PlatformsAvailableOn = interopAchievement.GetPlatformsAvailableOn();
            this.IsSecret = interopAchievement.isSecret;
            this.UnlockedDescription = interopAchievement.unlockedDescription.GetString();
            this.LockedDescription = interopAchievement.lockedDescription.GetString();
            this.ProductId = interopAchievement.productId.GetString();
            this.Type = interopAchievement.type;
            this.ParticipationType = interopAchievement.participationType;
            this.Available = new XblAchievementTimeWindow(interopAchievement.available);
            this.Rewards = interopAchievement.GetRewards(reward =>new XblAchievementReward(reward));
            this.EstimatedUnlockTime = interopAchievement.estimatedUnlockTime;
            this.DeepLink = interopAchievement.deepLink.GetString();
            this.IsRevoked = interopAchievement.isRevoked;
        }

        public string Id { get; private set; }
        public string ServiceConfigurationId { get; private set; }
        public string Name { get; private set; }
        public XblAchievementTitleAssociation[] TitleAssociations { get; private set; }
        public XblAchievementProgressState ProgressState { get; private set; }
        public XblAchievementProgression Progression { get; private set; }
        public XblAchievementMediaAsset[] MediaAssets { get; private set; }
        public string[] PlatformsAvailableOn { get; private set; }
        public bool IsSecret { get; private set; }
        public string UnlockedDescription { get; private set; }
        public string LockedDescription { get; private set; }
        public string ProductId { get; private set; }
        public XblAchievementType Type { get; private set; }
        public XblAchievementParticipationType ParticipationType { get; private set; }
        public XblAchievementTimeWindow Available { get; private set; }
        public XblAchievementReward[] Rewards { get; private set; }
        public UInt64 EstimatedUnlockTime { get; private set; }
        public string DeepLink { get; private set; }
        public bool IsRevoked { get; private set; }
    }
}
