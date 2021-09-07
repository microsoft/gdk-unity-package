namespace XGamingRuntime.Interop
{
    public partial struct XblMultiplayerSessionQueryResult
    {
        [NativeTypeName("time_t")]
        public long StartTime;

        public XblMultiplayerSessionReference SessionReference;

        public XblMultiplayerSessionStatus Status;

        public XblMultiplayerSessionVisibility Visibility;

        public bool IsMyTurn;

        [NativeTypeName("uint64_t")]
        public ulong Xuid;

        [NativeTypeName("uint32_t")]
        public uint AcceptedMemberCount;

        public XblMultiplayerSessionRestriction JoinRestriction;
    }
}
