namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblAchievementProgressChangeEventArgs
    {
        public XblAchievementProgressChangeEntry* updatedAchievementEntries;

        [NativeTypeName("size_t")]
        public uint entryCount;
    }
}
