using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerActivityRecentPlayerUpdate
    {
        public XblMultiplayerActivityRecentPlayerUpdate()
        {
        }

        internal XblMultiplayerActivityRecentPlayerUpdate(Interop.XblMultiplayerActivityRecentPlayerUpdate interopStruct)
        {
            this.Xuid = interopStruct.xuid;
            this.EncounterType = interopStruct.encounterType;
        }

        public UInt64 Xuid { get; set; }
        public XblMultiplayerActivityEncounterType EncounterType { get; set; }
    }
}