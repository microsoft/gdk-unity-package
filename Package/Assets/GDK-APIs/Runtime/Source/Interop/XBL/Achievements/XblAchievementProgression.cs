namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblAchievementProgression
    {
        public XblAchievementRequirement* requirements;

        [NativeTypeName("size_t")]
        public uint requirementsCount;

        [NativeTypeName("time_t")]
        public long timeUnlocked;
    }
}
