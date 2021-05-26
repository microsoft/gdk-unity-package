using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblAchievement
    {
        internal unsafe XblAchievement(Interop.XblAchievement* interopAchievement)
        {
            this.Id = Converters.PtrToStringUTF8(interopAchievement->id);
            this.ServiceConfigurationId = Converters.PtrToStringUTF8(interopAchievement->serviceConfigurationId);
            this.Name = Converters.PtrToStringUTF8(interopAchievement->name);
            this.TitleAssociations = Converters.PtrToClassArray
                                        <XblAchievementTitleAssociation, Interop.XblAchievementTitleAssociation>(
                                            (IntPtr)interopAchievement->titleAssociations,
                                            interopAchievement->titleAssociationsCount,
                                            ta => new XblAchievementTitleAssociation(ta)
                                        );
            this.ProgressState = (XblAchievementProgressState)interopAchievement->progressState;
            this.Progression = new XblAchievementProgression(interopAchievement->progression);
            this.MediaAssets = Converters.PtrToClassArray
                                    <XblAchievementMediaAsset, Interop.XblAchievementMediaAsset>(
                                        (IntPtr)interopAchievement->mediaAssets,
                                        interopAchievement->mediaAssetsCount,
                                        ma => new XblAchievementMediaAsset(ma)
                                    );
            this.PlatformsAvailableOn = Converters.StringPtrToArray(
                                                interopAchievement->platformsAvailableOn,
                                                interopAchievement->platformsAvailableOnCount
                                            );
            this.IsSecret = interopAchievement->isSecret;
            this.UnlockedDescription = Converters.PtrToStringUTF8(interopAchievement->unlockedDescription);
            this.LockedDescription = Converters.PtrToStringUTF8(interopAchievement->lockedDescription);
            this.ProductId = Converters.PtrToStringUTF8(interopAchievement->productId);
            this.Type = (XblAchievementType)interopAchievement->type;
            this.ParticipationType = (XblAchievementParticipationType)interopAchievement->participationType;
            this.Available = new XblAchievementTimeWindow(interopAchievement->available);
            this.Rewards = Converters.PtrToClassArray
                                <XblAchievementReward, Interop.XblAchievementReward>(
                                    (IntPtr)interopAchievement->rewards,
                                    interopAchievement->rewardsCount,
                                    r => new XblAchievementReward(r)
                                );
            this.EstimatedUnlockTime = interopAchievement->estimatedUnlockTime;
            this.DeepLink = Converters.PtrToStringUTF8(interopAchievement->deepLink);
            this.IsRevoked = interopAchievement->isRevoked;
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
