using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerActivityRecentPlayerUpdate
    //{
    //    uint64_t xuid;
    //    XblMultiplayerActivityEncounterType encounterType;
    //} XblMultiplayerActivityRecentPlayerUpdate;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerActivityRecentPlayerUpdate
    {
        internal readonly UInt64 xuid;
        internal readonly XblMultiplayerActivityEncounterType encounterType;

        internal XblMultiplayerActivityRecentPlayerUpdate(XGamingRuntime.XblMultiplayerActivityRecentPlayerUpdate publicObject)
        {
            this.xuid = publicObject.Xuid;
            this.encounterType = publicObject.EncounterType;
        }
    }
}