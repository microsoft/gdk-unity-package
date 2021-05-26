namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblAchievementReward
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* description;

        [NativeTypeName("const char *")]
        public sbyte* value;

        public XblAchievementRewardType rewardType;

        [NativeTypeName("const char *")]
        public sbyte* valueType;

        public XblAchievementMediaAsset* mediaAsset;
    }
}
