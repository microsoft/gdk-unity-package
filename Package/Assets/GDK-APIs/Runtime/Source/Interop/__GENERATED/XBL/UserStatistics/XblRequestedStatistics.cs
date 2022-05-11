namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblRequestedStatistics
    {
        [NativeTypeName("char [40]")]
        public fixed sbyte serviceConfigurationId[40];

        [NativeTypeName("const char **")]
        public sbyte** statistics;

        [NativeTypeName("uint32_t")]
        public uint statisticsCount;
    }
}
