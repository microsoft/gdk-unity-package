namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblAchievementTitleAssociation
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("uint32_t")]
        public uint titleId;
    }
}
