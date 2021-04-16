using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerManagerMember
    //{
    //    uint32_t MemberId;
    //    _Field_z_ const char* TeamId;
    //    _Field_z_ const char* InitialTeam;
    //    uint64_t Xuid;
    //    _Field_z_ const char* DebugGamertag;
    //    bool IsLocal;
    //    bool IsInLobby;
    //    bool IsInGame;
    //    XblMultiplayerSessionMemberStatus Status;
    //    _Field_z_ const char* ConnectionAddress;
    //    _Field_z_ const char* PropertiesJson;
    //    _Field_z_ const char* DeviceToken;
    //} XblMultiplayerManagerMember;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerManagerMember
    {
        internal readonly UInt32 MemberId;
        internal readonly UTF8StringPtr TeamId;
        internal readonly UTF8StringPtr InitialTeam;
        internal readonly UInt64 Xuid;
        internal readonly UTF8StringPtr DebugGamertag;
        internal readonly NativeBool IsLocal;
        internal readonly NativeBool IsInLobby;
        internal readonly NativeBool IsInGame;
        internal readonly XblMultiplayerSessionMemberStatus Status;
        internal readonly UTF8StringPtr ConnectionAddress;
        internal readonly UTF8StringPtr PropertiesJson;
        internal readonly UTF8StringPtr DeviceToken;

        internal XblMultiplayerManagerMember(XGamingRuntime.XblMultiplayerManagerMember publicObject, DisposableCollection disposableCollection)
        {
            this.MemberId = publicObject.MemberId;
            this.TeamId = new UTF8StringPtr(publicObject.TeamId, disposableCollection);
            this.InitialTeam = new UTF8StringPtr(publicObject.InitialTeam, disposableCollection);
            this.Xuid = publicObject.Xuid;
            this.DebugGamertag = new UTF8StringPtr(publicObject.DebugGamertag, disposableCollection);
            this.IsLocal = new NativeBool(publicObject.IsLocal);
            this.IsInLobby = new NativeBool(publicObject.IsInLobby);
            this.IsInGame = new NativeBool(publicObject.IsInGame);
            this.Status = publicObject.Status;
            this.ConnectionAddress = new UTF8StringPtr(publicObject.ConnectionAddress, disposableCollection);
            this.PropertiesJson = new UTF8StringPtr(publicObject.PropertiesJson, disposableCollection);
            this.DeviceToken = new UTF8StringPtr(publicObject.DeviceToken, disposableCollection);
        }
    }
}