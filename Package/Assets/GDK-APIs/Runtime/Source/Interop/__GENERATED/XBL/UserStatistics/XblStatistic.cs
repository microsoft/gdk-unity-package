namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblStatistic
    {
        [NativeTypeName("const char *")]
        public sbyte* statisticName;

        [NativeTypeName("const char *")]
        public sbyte* statisticType;

        [NativeTypeName("const char *")]
        public sbyte* value;
    }
}
