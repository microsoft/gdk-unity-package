namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblStatisticChangeEventArgs
    {
        [NativeTypeName("uint64_t")]
        public ulong xboxUserId;

        [NativeTypeName("char [40]")]
        public fixed sbyte serviceConfigurationId[40];

        public XblStatistic latestStatistic;
    }
}
