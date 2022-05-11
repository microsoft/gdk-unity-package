namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblUserStatisticsResult
    {
        [NativeTypeName("uint64_t")]
        public ulong xboxUserId;

        public XblServiceConfigurationStatistic* serviceConfigStatistics;

        [NativeTypeName("uint32_t")]
        public uint serviceConfigStatisticsCount;
    }
}
