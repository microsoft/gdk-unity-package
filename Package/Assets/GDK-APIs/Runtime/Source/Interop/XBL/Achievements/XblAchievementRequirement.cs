namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblAchievementRequirement
    {
        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const char *")]
        public sbyte* currentProgressValue;

        [NativeTypeName("const char *")]
        public sbyte* targetProgressValue;
    }
}
