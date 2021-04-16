using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerActivityDetails
    //{
    //    XblMultiplayerSessionReference SessionReference;
    //    char HandleId[XBL_GUID_LENGTH];
    //    uint32_t TitleId;
    //    XblMultiplayerSessionVisibility Visibility;
    //    XblMultiplayerSessionRestriction JoinRestriction;
    //    bool Closed;
    //    uint64_t OwnerXuid;
    //    uint32_t MaxMembersCount;
    //    uint32_t MembersCount;
    //    const char* CustomSessionPropertiesJson;
    //} XblMultiplayerActivityDetails;
    [StructLayout(LayoutKind.Sequential)]
    internal struct XblMultiplayerActivityDetails
    {
        internal readonly XblMultiplayerSessionReference SessionReference;
        private unsafe fixed Byte HandleId[40]; // char HandleId[40]
        internal readonly UInt32 TitleId;
        internal readonly XblMultiplayerSessionVisibility Visibility;
        internal readonly XblMultiplayerSessionRestriction JoinRestriction;
        internal readonly NativeBool Closed;
        internal readonly UInt64 OwnerXuid;
        internal readonly UInt32 MaxMembersCount;
        internal readonly UInt32 MembersCount;
        internal readonly UTF8StringPtr CustomSessionPropertiesJson;

        internal string GetHandleId() { unsafe { fixed (Byte* ptr = this.HandleId) { return Converters.BytePointerToString(ptr, 40); } } }

        internal XblMultiplayerActivityDetails(XGamingRuntime.XblMultiplayerActivityDetails publicObject, DisposableCollection disposableCollection)
        {
            this.SessionReference = new XblMultiplayerSessionReference(publicObject.SessionReference);
            unsafe
            {
                fixed (Byte* ptr = this.HandleId)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.HandleId, ptr, 40);
                }
            }
            this.TitleId = publicObject.TitleId;
            this.Visibility = publicObject.Visibility;
            this.JoinRestriction = publicObject.JoinRestriction;
            this.Closed = new NativeBool(publicObject.Closed);
            this.OwnerXuid = publicObject.OwnerXuid;
            this.MaxMembersCount = publicObject.MaxMembersCount;
            this.MembersCount = publicObject.MembersCount;
            this.CustomSessionPropertiesJson = new UTF8StringPtr(publicObject.CustomSessionPropertiesJson, disposableCollection);
        }
    }
}