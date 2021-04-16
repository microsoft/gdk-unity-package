using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionProperties
    //{
    //    const char** Keywords;
    //    size_t KeywordCount;
    //    XblMultiplayerSessionRestriction JoinRestriction;
    //    XblMultiplayerSessionRestriction ReadRestriction;
    //    uint32_t* TurnCollection;
    //    size_t TurnCollectionCount;
    //    const char* MatchmakingTargetSessionConstantsJson;
    //    const char* SessionCustomPropertiesJson;
    //    const char* MatchmakingServerConnectionString;
    //    const char** ServerConnectionStringCandidates;
    //    size_t ServerConnectionStringCandidatesCount;
    //    uint32_t* SessionOwnerMemberIds;
    //    size_t SessionOwnerMemberIdsCount;
    //    XblDeviceToken HostDeviceToken;
    //    bool Closed;
    //    bool Locked;
    //    bool AllocateCloudCompute;
    //    bool MatchmakingResubmit;
    //} XblMultiplayerSessionProperties;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerSessionProperties
    {
        private readonly unsafe UTF8StringPtr* Keywords;
        internal readonly SizeT KeywordCount;
        internal readonly XblMultiplayerSessionRestriction JoinRestriction;
        internal readonly XblMultiplayerSessionRestriction ReadRestriction;
        private readonly unsafe UInt32* TurnCollection;
        internal readonly SizeT TurnCollectionCount;
        internal readonly UTF8StringPtr MatchmakingTargetSessionConstantsJson;
        internal readonly UTF8StringPtr SessionCustomPropertiesJson;
        internal readonly UTF8StringPtr MatchmakingServerConnectionString;
        private readonly unsafe UTF8StringPtr* ServerConnectionStringCandidates;
        internal readonly SizeT ServerConnectionStringCandidatesCount;
        private readonly unsafe UInt32* SessionOwnerMemberIds;
        internal readonly SizeT SessionOwnerMemberIdsCount;
        internal readonly XblDeviceToken HostDeviceToken;
        internal readonly NativeBool Closed;
        internal readonly NativeBool Locked;
        internal readonly NativeBool AllocateCloudCompute;
        internal readonly NativeBool MatchmakingResubmit;

        internal T[] GetKeywords<T>(Func<UTF8StringPtr,T> ctor) { unsafe { return Converters.PtrToClassArray<T, UTF8StringPtr>((IntPtr)this.Keywords, this.KeywordCount, ctor); } }
        internal T[] GetTurnCollection<T>(Func<UInt32,T> ctor) { unsafe { return Converters.PtrToClassArray<T, UInt32>((IntPtr)this.TurnCollection, this.TurnCollectionCount, ctor); } }
        internal T[] GetServerConnectionStringCandidates<T>(Func<UTF8StringPtr,T> ctor) { unsafe { return Converters.PtrToClassArray<T, UTF8StringPtr>((IntPtr)this.ServerConnectionStringCandidates, this.ServerConnectionStringCandidatesCount, ctor); } }
        internal T[] GetSessionOwnerMemberIds<T>(Func<UInt32,T> ctor) { unsafe { return Converters.PtrToClassArray<T, UInt32>((IntPtr)this.SessionOwnerMemberIds, this.SessionOwnerMemberIdsCount, ctor); } }

        internal XblMultiplayerSessionProperties(XGamingRuntime.XblMultiplayerSessionProperties publicObject, DisposableCollection disposableCollection)
        {
            unsafe
            {
                this.Keywords = (UTF8StringPtr*)Converters.ClassArrayToPtr(
                    publicObject.Keywords,
                    (string x, DisposableCollection _) =>new UTF8StringPtr(x, disposableCollection), 
                    disposableCollection,
                    out this.KeywordCount);
            }
            this.JoinRestriction = publicObject.JoinRestriction;
            this.ReadRestriction = publicObject.ReadRestriction;
            unsafe
            {
                this.TurnCollection = (UInt32*)Converters.ClassArrayToPtr(
                    publicObject.TurnCollection, 
                    (UInt32 x, DisposableCollection _) =>x, 
                    disposableCollection,
                    out this.TurnCollectionCount);
            }
            this.MatchmakingTargetSessionConstantsJson = new UTF8StringPtr(publicObject.MatchmakingTargetSessionConstantsJson, disposableCollection);
            this.SessionCustomPropertiesJson = new UTF8StringPtr(publicObject.SessionCustomPropertiesJson, disposableCollection);
            this.MatchmakingServerConnectionString = new UTF8StringPtr(publicObject.MatchmakingServerConnectionString, disposableCollection);
            unsafe
            {
                this.ServerConnectionStringCandidates = (UTF8StringPtr*)Converters.ClassArrayToPtr(
                    publicObject.ServerConnectionStringCandidates, 
                    (string x, DisposableCollection _) =>new UTF8StringPtr(x, disposableCollection), 
                    disposableCollection,
                    out this.ServerConnectionStringCandidatesCount);
            }
            unsafe
            {
                this.SessionOwnerMemberIds = (UInt32*)Converters.ClassArrayToPtr(
                    publicObject.SessionOwnerMemberIds, 
                    (UInt32 x, DisposableCollection _) =>x, 
                    disposableCollection,
                    out this.SessionOwnerMemberIdsCount);
            }
            this.HostDeviceToken = new XblDeviceToken(publicObject.HostDeviceToken);
            this.Closed = new NativeBool(publicObject.Closed);
            this.Locked = new NativeBool(publicObject.Locked);
            this.AllocateCloudCompute = new NativeBool(publicObject.AllocateCloudCompute);
            this.MatchmakingResubmit = new NativeBool(publicObject.MatchmakingResubmit);
        }
    }
}