using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XGamingRuntime.Interop
{
    //typedef struct XblPresenceDeviceRecord
    //{
    //    XblPresenceDeviceType deviceType;
    //    const struct XblPresenceTitleRecord* titleRecords;
    //    size_t titleRecordsCount;
    //} XblPresenceDeviceRecord;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblPresenceDeviceRecord
    {
        internal T[] GetTitleRecords<T>(Func<XblPresenceTitleRecord, T> ctor) { return Converters.PtrToClassArray(this.titleRecords, this.titleRecordsCount, ctor); }

        internal readonly XblPresenceDeviceType deviceType;
        private readonly IntPtr titleRecords;
        private readonly SizeT titleRecordsCount;
    }
}
