namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblAchievement
    {
        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const char *")]
        public sbyte* serviceConfigurationId;

        [NativeTypeName("const char *")]
        public sbyte* name;

        public XblAchievementTitleAssociation* titleAssociations;

        [NativeTypeName("size_t")]
        public uint titleAssociationsCount;

        public XblAchievementProgressState progressState;

        public XblAchievementProgression progression;

        public XblAchievementMediaAsset* mediaAssets;

        [NativeTypeName("size_t")]
        public uint mediaAssetsCount;

        [NativeTypeName("const char **")]
        public sbyte** platformsAvailableOn;

        [NativeTypeName("size_t")]
        public uint platformsAvailableOnCount;

        public bool isSecret;

        [NativeTypeName("const char *")]
        public sbyte* unlockedDescription;

        [NativeTypeName("const char *")]
        public sbyte* lockedDescription;

        [NativeTypeName("const char *")]
        public sbyte* productId;

        public XblAchievementType type;

        public XblAchievementParticipationType participationType;

        public XblAchievementTimeWindow available;

        public XblAchievementReward* rewards;

        [NativeTypeName("size_t")]
        public uint rewardsCount;

        [NativeTypeName("uint64_t")]
        public ulong estimatedUnlockTime;

        [NativeTypeName("const char *")]
        public sbyte* deepLink;

        public bool isRevoked;
    }
}
