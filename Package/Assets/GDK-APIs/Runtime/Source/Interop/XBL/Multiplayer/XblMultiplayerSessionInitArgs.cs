using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionInitArgs
    //{
    //    uint32_t MaxMembersInSession;
    //    XblMultiplayerSessionVisibility Visibility;
    //    const uint64_t* InitiatorXuids;
    //    size_t InitiatorXuidsCount;
    //    _Null_terminated_ const char* CustomJson;
    //} XblMultiplayerSessionInitArgs;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerSessionInitArgs
    {
        internal readonly UInt32 MaxMembersInSession;
        internal readonly XblMultiplayerSessionVisibility Visibility;
        private readonly unsafe UInt64* InitiatorXuids;
        internal readonly SizeT InitiatorXuidsCount;
        internal readonly UTF8StringPtr CustomJson;

        internal T[] GetInitiatorXuids<T>(Func<UInt64,T> ctor) { unsafe { return Converters.PtrToClassArray<T, UInt64>((IntPtr)this.InitiatorXuids, this.InitiatorXuidsCount, ctor); } }

        internal XblMultiplayerSessionInitArgs(XGamingRuntime.XblMultiplayerSessionInitArgs publicObject, DisposableCollection disposableCollection)
        {
            this.MaxMembersInSession = publicObject.MaxMembersInSession;
            this.Visibility = publicObject.Visibility;
            unsafe
            {
                this.InitiatorXuids = (UInt64*)Converters.ClassArrayToPtr(
                    publicObject.InitiatorXuids, 
                    (UInt64 x, DisposableCollection _) =>x, 
                    disposableCollection,
                    out this.InitiatorXuidsCount);
            }
            this.CustomJson = new UTF8StringPtr(publicObject.CustomJson, disposableCollection);
        }
    }
}