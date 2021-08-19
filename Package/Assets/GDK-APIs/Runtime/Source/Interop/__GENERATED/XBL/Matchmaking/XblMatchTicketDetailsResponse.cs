namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblMatchTicketDetailsResponse
    {
        public XblTicketStatus matchStatus;

        [NativeTypeName("int64_t")]
        public long estimatedWaitTime;

        public XblPreserveSessionMode preserveSession;

        public XblMultiplayerSessionReference ticketSession;

        public XblMultiplayerSessionReference targetSession;

        [NativeTypeName("char *")]
        public sbyte* ticketAttributes;
    }
}
