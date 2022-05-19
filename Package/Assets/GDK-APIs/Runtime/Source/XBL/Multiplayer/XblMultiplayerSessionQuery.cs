using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionQuery
    {
        public string Scid;

        public uint MaxItems;

        public bool IncludePrivateSessions;

        public bool IncludeReservations;

        public bool IncludeInactiveSessions;

        public ulong[] XuidFilters;

        public uint XuidFiltersCount;

        public string KeywordFilter;

        public string SessionTemplateNameFilter;

        public XblMultiplayerSessionVisibility VisibilityFilter;

        public uint ContractVersionFilter;
    }
}
