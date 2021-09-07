using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblMultiplayerSessionInfo
    //{
    //    uint32_t ContractVersion;
    //    char Branch[XBL_GUID_LENGTH];
    //    uint64_t ChangeNumber;
    //    char CorrelationId[XBL_GUID_LENGTH];
    //    time_t StartTime;
    //    time_t NextTimer;
    //    char SearchHandleId[XBL_GUID_LENGTH];
    //} XblMultiplayerSessionInfo;
    [StructLayout(LayoutKind.Sequential)]
    public struct XblMultiplayerSessionInfo
    {
        internal readonly UInt32 ContractVersion;
        private unsafe fixed Byte Branch[40]; // char Branch[40]
        internal readonly UInt64 ChangeNumber;
        private unsafe fixed Byte CorrelationId[40]; // char CorrelationId[40]
        internal readonly TimeT StartTime;
        internal readonly TimeT NextTimer;
        private unsafe fixed Byte SearchHandleId[40]; // char SearchHandleId[40]

        internal string GetBranch() { unsafe { fixed (Byte* ptr = this.Branch) { return Converters.BytePointerToString(ptr, 40); } } }
        internal string GetCorrelationId() { unsafe { fixed (Byte* ptr = this.CorrelationId) { return Converters.BytePointerToString(ptr, 40); } } }
        public string GetSearchHandleId() { unsafe { fixed (Byte* ptr = this.SearchHandleId) { return Converters.BytePointerToString(ptr, 40); } } }

        internal XblMultiplayerSessionInfo(XGamingRuntime.XblMultiplayerSessionInfo publicObject)
        {
            this.ContractVersion = publicObject.ContractVersion;
            unsafe
            {
                fixed (Byte* ptr = this.Branch)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Branch, ptr, 40);
                }
            }
            this.ChangeNumber = publicObject.ChangeNumber;
            unsafe
            {
                fixed (Byte* ptr = this.CorrelationId)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.CorrelationId, ptr, 40);
                }
            }
            this.StartTime = new TimeT(publicObject.StartTime);
            this.NextTimer = new TimeT(publicObject.NextTimer);
            unsafe
            {
                fixed (Byte* ptr = this.SearchHandleId)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SearchHandleId, ptr, 40);
                }
            }
        }
    }
}