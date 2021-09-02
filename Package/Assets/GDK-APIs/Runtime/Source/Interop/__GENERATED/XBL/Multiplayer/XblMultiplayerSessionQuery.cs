namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblMultiplayerSessionQuery
    {
        [NativeTypeName("char [40]")]
        public fixed sbyte Scid[40];

        [NativeTypeName("uint32_t")]
        public uint MaxItems;

        public bool IncludePrivateSessions;

        public bool IncludeReservations;

        public bool IncludeInactiveSessions;

        [NativeTypeName("uint64_t *")]
        public ulong* XuidFilters;

        [NativeTypeName("size_t")]
        public SizeT XuidFiltersCount;

        [NativeTypeName("const char *")]
        public sbyte* KeywordFilter;

        [NativeTypeName("char [100]")]
        public fixed sbyte SessionTemplateNameFilter[100];

        public XblMultiplayerSessionVisibility VisibilityFilter;

        [NativeTypeName("uint32_t")]
        public uint ContractVersionFilter;
    }
}
