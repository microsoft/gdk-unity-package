using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionMember
    //{
    //    uint32_t MemberId;
    //    XBL_DEPRECATED const char* TeamId;
    //    const char* InitialTeam;
    //    XBL_DEPRECATED XblTournamentArbitrationStatus ArbitrationStatus;
    //    uint64_t Xuid;
    //    const char* CustomConstantsJson;
    //    const char* SecureDeviceBaseAddress64;
    //    const XblMultiplayerSessionMemberRole* Roles;
    //    size_t RolesCount;
    //    const char* CustomPropertiesJson;
    //    char Gamertag[XBL_GAMERTAG_CHAR_SIZE];
    //    XblMultiplayerSessionMemberStatus Status;
    //    bool IsTurnAvailable;
    //    bool IsCurrentUser;
    //    bool InitializeRequested;
    //    const char* MatchmakingResultServerMeasurementsJson;
    //    const char* ServerMeasurementsJson;
    //    const uint32_t* MembersInGroupIds;
    //    size_t MembersInGroupCount;
    //    const char* QosMeasurementsJson;
    //    XblDeviceToken DeviceToken;
    //    XblNetworkAddressTranslationSetting Nat;
    //    uint32_t ActiveTitleId;
    //    uint32_t InitializationEpisode;
    //    time_t JoinTime;
    //    XblMultiplayerMeasurementFailure InitializationFailureCause;
    //    const char** Groups;
    //    size_t GroupsCount;
    //    const char** Encounters;
    //    size_t EncountersCount;
    //    XBL_DEPRECATED XblMultiplayerSessionReference TournamentTeamSessionReference;
    //    void* Internal;
    //} XblMultiplayerSessionMember;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerSessionMember
    {
        internal readonly UInt32 MemberId;
        internal readonly UTF8StringPtr TeamId;
        internal readonly UTF8StringPtr InitialTeam;
        internal readonly XblTournamentArbitrationStatus ArbitrationStatus;
        internal readonly UInt64 Xuid;
        internal readonly UTF8StringPtr CustomConstantsJson;
        internal readonly UTF8StringPtr SecureDeviceBaseAddress64;
        private readonly unsafe XblMultiplayerSessionMemberRole* Roles;
        internal readonly SizeT RolesCount;
        internal readonly UTF8StringPtr CustomPropertiesJson;
        private unsafe fixed Byte Gamertag[48]; // char Gamertag[48]
        internal readonly XblMultiplayerSessionMemberStatus Status;
        internal readonly NativeBool IsTurnAvailable;
        internal readonly NativeBool IsCurrentUser;
        internal readonly NativeBool InitializeRequested;
        internal readonly UTF8StringPtr MatchmakingResultServerMeasurementsJson;
        internal readonly UTF8StringPtr ServerMeasurementsJson;
        private readonly unsafe UInt32* MembersInGroupIds;
        internal readonly SizeT MembersInGroupCount;
        internal readonly UTF8StringPtr QosMeasurementsJson;
        internal readonly XblDeviceToken DeviceToken;
        internal readonly XblNetworkAddressTranslationSetting Nat;
        internal readonly UInt32 ActiveTitleId;
        internal readonly UInt32 InitializationEpisode;
        internal readonly TimeT JoinTime;
        internal readonly XblMultiplayerMeasurementFailure InitializationFailureCause;
        private readonly unsafe UTF8StringPtr* Groups;
        internal readonly SizeT GroupsCount;
        private readonly unsafe UTF8StringPtr* Encounters;
        internal readonly SizeT EncountersCount;
        internal readonly XblMultiplayerSessionReference TournamentTeamSessionReference;
        internal readonly IntPtr Internal;

        internal T[] GetRoles<T>(Func<XblMultiplayerSessionMemberRole,T> ctor) { unsafe { return Converters.PtrToClassArray<T, XblMultiplayerSessionMemberRole>((IntPtr)this.Roles, this.RolesCount, ctor); } }
        internal string GetGamertag() { unsafe { fixed (Byte* ptr = this.Gamertag) { return Converters.BytePointerToString(ptr, 48); } } }
        internal T[] GetMembersInGroupIds<T>(Func<UInt32, T> ctor) { unsafe { return Converters.PtrToClassArray<T, UInt32>((IntPtr)this.MembersInGroupIds, this.MembersInGroupCount, ctor); } }
        internal T[] GetGroups<T>(Func<UTF8StringPtr,T> ctor) { unsafe { return Converters.PtrToClassArray<T, UTF8StringPtr>((IntPtr)this.Groups, this.GroupsCount, ctor); } }
        internal T[] GetEncounters<T>(Func<UTF8StringPtr,T> ctor) { unsafe { return Converters.PtrToClassArray<T, UTF8StringPtr>((IntPtr)this.Encounters, this.EncountersCount, ctor); } }

        internal XblMultiplayerSessionMember(XGamingRuntime.XblMultiplayerSessionMember publicObject, DisposableCollection disposableCollection)
        {
            this.MemberId = publicObject.MemberId;
            this.TeamId = new UTF8StringPtr(publicObject.TeamId, disposableCollection);
            this.InitialTeam = new UTF8StringPtr(publicObject.InitialTeam, disposableCollection);
            this.ArbitrationStatus = publicObject.ArbitrationStatus;
            this.Xuid = publicObject.Xuid;
            this.CustomConstantsJson = new UTF8StringPtr(publicObject.CustomConstantsJson, disposableCollection);
            this.SecureDeviceBaseAddress64 = new UTF8StringPtr(publicObject.SecureDeviceBaseAddress64, disposableCollection);
            unsafe
            {
                this.Roles = (XblMultiplayerSessionMemberRole*)Converters.ClassArrayToPtr(
                    publicObject.Roles, 
                    (XGamingRuntime.XblMultiplayerSessionMemberRole x, DisposableCollection _) =>new XblMultiplayerSessionMemberRole(x, disposableCollection), 
                    disposableCollection,
                    out this.RolesCount);
            }
            this.CustomPropertiesJson = new UTF8StringPtr(publicObject.CustomPropertiesJson, disposableCollection);
            unsafe
            {
                fixed (Byte* ptr = this.Gamertag)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Gamertag, ptr, 48);
                }
            }
            this.Status = publicObject.Status;
            this.IsTurnAvailable = new NativeBool(publicObject.IsTurnAvailable);
            this.IsCurrentUser = new NativeBool(publicObject.IsCurrentUser);
            this.InitializeRequested = new NativeBool(publicObject.InitializeRequested);
            this.MatchmakingResultServerMeasurementsJson = new UTF8StringPtr(publicObject.MatchmakingResultServerMeasurementsJson, disposableCollection);
            this.ServerMeasurementsJson = new UTF8StringPtr(publicObject.ServerMeasurementsJson, disposableCollection);
            unsafe
            {
                this.MembersInGroupIds = (UInt32*)Converters.ClassArrayToPtr<UInt32, UInt32>(
                    publicObject.MembersInGroupIds,
                    (x, _) =>x,
                    disposableCollection,
                    out this.MembersInGroupCount);
            }
            this.MembersInGroupCount = new SizeT(publicObject.MembersInGroupIds.Length);
            this.QosMeasurementsJson = new UTF8StringPtr(publicObject.QosMeasurementsJson, disposableCollection);
            this.DeviceToken = new XblDeviceToken(publicObject.DeviceToken);
            this.Nat = publicObject.Nat;
            this.ActiveTitleId = publicObject.ActiveTitleId;
            this.InitializationEpisode = publicObject.InitializationEpisode;
            this.JoinTime = new TimeT(publicObject.JoinTime);
            this.InitializationFailureCause = publicObject.InitializationFailureCause;
            unsafe
            {
                this.Groups = (UTF8StringPtr*)Converters.ClassArrayToPtr(
                    publicObject.Groups, 
                    (string x, DisposableCollection _) =>new UTF8StringPtr(x, disposableCollection), 
                    disposableCollection,
                    out this.GroupsCount);
            }
            unsafe
            {
                this.Encounters = (UTF8StringPtr*)Converters.ClassArrayToPtr(
                    publicObject.Encounters,
                    (string x, DisposableCollection _) =>new UTF8StringPtr(x, disposableCollection), 
                    disposableCollection,
                    out this.EncountersCount);
            }
            this.TournamentTeamSessionReference = new XblMultiplayerSessionReference(publicObject.TournamentTeamSessionReference);
            this.Internal = publicObject.Internal;
        }
    }
}