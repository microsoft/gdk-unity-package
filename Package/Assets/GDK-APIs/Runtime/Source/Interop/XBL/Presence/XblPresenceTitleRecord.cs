using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XGamingRuntime.Interop
{
    //typedef struct XblPresenceTitleRecord
    //{
    //     uint32_t titleId;
    //     _Field_z_ const char* titleName;
    //     time_t lastModified;
    //     bool titleActive;
    //     _Field_z_ const char* richPresenceString;
    //     XblPresenceTitleViewState viewState;
    //     struct XblPresenceBroadcastRecord* broadcastRecord;
    // } XblPresenceTitleRecord;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblPresenceTitleRecord
    {
        internal T GetBroadcastRecord<T>(Func<Interop.XblPresenceBroadcastRecord, T> ctor) where T : class { return Converters.PtrToClass(this.broadcastRecord, ctor); }

        internal readonly UInt32 titleId;
        internal readonly UTF8StringPtr titleName;
        internal readonly TimeT lastModified;
        [MarshalAs(UnmanagedType.U1)]
        internal readonly bool titleActive;
        internal readonly UTF8StringPtr richPresenceString;
        internal readonly XblPresenceTitleViewState viewState;
        private readonly IntPtr broadcastRecord;
    }
}
