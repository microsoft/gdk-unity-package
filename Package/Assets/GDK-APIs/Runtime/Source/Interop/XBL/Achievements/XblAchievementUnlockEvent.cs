namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblAchievementUnlockEvent
    {
        [NativeTypeName("const char *")]
        public sbyte* achievementName;

        [NativeTypeName("const char *")]
        public sbyte* achievementDescription;

        [NativeTypeName("const char *")]
        public sbyte* achievementIcon;

        [NativeTypeName("const char *")]
        public sbyte* achievementId;

        [NativeTypeName("uint64_t")]
        public ulong gamerscore;

        [NativeTypeName("uint32_t")]
        public uint titleId;

        [NativeTypeName("uint64_t")]
        public ulong xboxUserId;

        [NativeTypeName("const char *")]
        public sbyte* deepLink;

        public float rarityPercentage;

        public XblAchievementRarityCategory rarityCategory;

        [NativeTypeName("time_t")]
        public long timeUnlocked;
    }
}
