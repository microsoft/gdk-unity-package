using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerActivityInfo
    //{
    //    uint64_t xuid;
    //    const char* connectionString;
    //    XblMultiplayerActivityJoinRestriction joinRestriction;
    //    size_t maxPlayers;
    //    size_t currentPlayers;
    //    const char* groupId;
    //    XblMultiplayerActivityPlatform platform;
    //} XblMultiplayerActivityInfo;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerActivityInfo
    {
        internal readonly UInt64 xuid;
        internal readonly UTF8StringPtr connectionString;
        internal readonly XblMultiplayerActivityJoinRestriction joinRestriction;
        internal readonly SizeT maxPlayers;
        internal readonly SizeT currentPlayers;
        internal readonly UTF8StringPtr groupId;
        internal readonly XblMultiplayerActivityPlatform platform;

        internal XblMultiplayerActivityInfo(XGamingRuntime.XblMultiplayerActivityInfo publicObject, DisposableCollection disposableCollection)
        {
            this.xuid = publicObject.Xuid;
            this.connectionString = new UTF8StringPtr(publicObject.ConnectionString, disposableCollection);
            this.joinRestriction = publicObject.JoinRestriction;
            this.maxPlayers = new SizeT(publicObject.MaxPlayers);
            this.currentPlayers = new SizeT(publicObject.CurrentPlayers);
            this.groupId = new UTF8StringPtr(publicObject.GroupId, disposableCollection);
            this.platform = publicObject.Platform;
        }
    }
}