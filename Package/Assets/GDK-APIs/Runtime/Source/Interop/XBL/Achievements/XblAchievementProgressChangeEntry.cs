namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblAchievementProgressChangeEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* achievementId;

        public XblAchievementProgressState progressState;

        public XblAchievementProgression progression;
    }
}
