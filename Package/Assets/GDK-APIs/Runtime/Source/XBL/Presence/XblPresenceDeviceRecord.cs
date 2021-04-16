using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XGamingRuntime
{
    public class XblPresenceDeviceRecord
    {
        internal XblPresenceDeviceRecord(Interop.XblPresenceDeviceRecord interopRecord)
        {
            this.DeviceType = interopRecord.deviceType;
            this.TitleRecords = interopRecord.GetTitleRecords(tr =>new XblPresenceTitleRecord(tr));
        }

        public XblPresenceDeviceType DeviceType { get; private set; }
        public XblPresenceTitleRecord[] TitleRecords { get; private set; }
    }
}
