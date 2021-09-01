namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblHopperStatisticsResponse
    {
        [NativeTypeName("char *")]
        public sbyte* hopperName;

        [NativeTypeName("int64_t")]
        public long estimatedWaitTime;

        [NativeTypeName("uint32_t")]
        public uint playersWaitingToMatch;
    }
}
