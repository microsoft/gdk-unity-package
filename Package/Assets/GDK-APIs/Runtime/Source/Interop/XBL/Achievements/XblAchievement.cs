using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblAchievement
    //{
    //    _Field_z_ const char* id;
    //    _Field_z_ const char* serviceConfigurationId;
    //    _Field_z_ const char* name;
    //    XblAchievementTitleAssociation* titleAssociations;
    //    size_t titleAssociationsCount;
    //    XblAchievementProgressState progressState;
    //    XblAchievementProgression progression;
    //    XblAchievementMediaAsset* mediaAssets;
    //    size_t mediaAssetsCount;
    //    _Field_z_ const char** platformsAvailableOn;
    //    size_t platformsAvailableOnCount;
    //    bool isSecret;
    //    _Field_z_ const char* unlockedDescription;
    //    _Field_z_ const char* lockedDescription;
    //    _Field_z_ const char* productId;
    //    XblAchievementType type;
    //    XblAchievementParticipationType participationType;
    //    XblAchievementTimeWindow available;
    //    XblAchievementReward* rewards;
    //    size_t rewardsCount;
    //    uint64_t estimatedUnlockTime;
    //    _Field_z_ const char* deepLink;
    //    bool isRevoked;
    //}
    //XblAchievement;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblAchievement
    {
        #region IntPtr wrappers
        internal T[] GetTitleAssociations<T>(Func<XblAchievementTitleAssociation, T> ctor) { return Converters.PtrToClassArray(this.titleAssociations, this.titleAssociationsCount, ctor); }
        internal T[] GetMediaAssets<T>(Func<XblAchievementMediaAsset, T> ctor) { return Converters.PtrToClassArray(this.mediaAssets, this.mediaAssetsCount, ctor); }
        internal string[] GetPlatformsAvailableOn() { return Converters.PtrToClassArray<string, UTF8StringPtr>(this.platformsAvailableOn, this.platformsAvailableOnCount, s =>s.GetString()); }
        internal T[] GetRewards<T>(Func<XblAchievementReward, T> ctor) { return Converters.PtrToClassArray(this.rewards, this.rewardsCount, ctor); }
        #endregion

        internal readonly UTF8StringPtr id;
        internal readonly UTF8StringPtr serviceConfigurationId;
        internal readonly UTF8StringPtr name;
        private readonly IntPtr titleAssociations;
        private readonly SizeT titleAssociationsCount;
        internal readonly XblAchievementProgressState progressState;
        internal readonly XblAchievementProgression progression;
        private readonly IntPtr mediaAssets;
        private readonly SizeT mediaAssetsCount;
        private readonly IntPtr platformsAvailableOn;
        private readonly SizeT platformsAvailableOnCount;
        [MarshalAs(UnmanagedType.U1)]
        internal readonly bool isSecret;
        internal readonly UTF8StringPtr unlockedDescription;
        internal readonly UTF8StringPtr lockedDescription;
        internal readonly UTF8StringPtr productId;
        internal readonly XblAchievementType type;
        internal readonly XblAchievementParticipationType participationType;
        internal readonly XblAchievementTimeWindow available;
        private readonly IntPtr rewards;
        private readonly SizeT rewardsCount;
        internal readonly UInt64 estimatedUnlockTime;
        internal readonly UTF8StringPtr deepLink;
        [MarshalAs(UnmanagedType.U1)]
        internal readonly bool isRevoked;
    }
}
