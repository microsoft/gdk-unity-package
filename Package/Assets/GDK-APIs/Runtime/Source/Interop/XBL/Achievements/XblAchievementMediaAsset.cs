namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblAchievementMediaAsset
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        public XblAchievementMediaAssetType mediaAssetType;

        [NativeTypeName("const char *")]
        public sbyte* url;
    }
}
