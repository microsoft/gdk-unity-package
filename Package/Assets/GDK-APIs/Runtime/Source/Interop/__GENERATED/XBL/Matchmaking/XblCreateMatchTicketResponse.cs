namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblCreateMatchTicketResponse
    {
        [NativeTypeName("char [40]")]
        public fixed sbyte matchTicketId[40];

        [NativeTypeName("int64_t")]
        public long estimatedWaitTime;
    }
}
