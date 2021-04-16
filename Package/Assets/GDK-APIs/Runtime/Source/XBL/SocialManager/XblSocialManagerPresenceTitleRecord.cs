using System;
using System.Linq;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblSocialManagerPresenceTitleRecord
    {
        internal XblSocialManagerPresenceTitleRecord(Interop.XblSocialManagerPresenceTitleRecord interopRecord)
        {
            this.TitleId = interopRecord.titleId;
            this.IsTitleActive = interopRecord.isTitleActive;
            this.PresenceText = Converters.ByteArrayToString(interopRecord.presenceText);
            this.IsBroadcasting = interopRecord.isBroadcasting;
            this.DeviceType = interopRecord.deviceType;
            this.IsPrimary = interopRecord.isPrimary;
        }

        public UInt32 TitleId { get; private set; }
        public bool IsTitleActive { get; private set; }
        public string PresenceText { get; private set; }
        public bool IsBroadcasting { get; private set; }
        public XblPresenceDeviceType DeviceType { get; private set; }
        public bool IsPrimary { get; private set; }
    }
}
