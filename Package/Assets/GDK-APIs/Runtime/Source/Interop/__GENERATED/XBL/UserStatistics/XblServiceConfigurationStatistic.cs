namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblServiceConfigurationStatistic
    {
        [NativeTypeName("char [40]")]
        public fixed sbyte serviceConfigurationId[40];

        public XblStatistic* statistics;

        [NativeTypeName("uint32_t")]
        public uint statisticsCount;
    }
}
