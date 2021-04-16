using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XGamingRuntime
{
    public class XblPresenceTitleRecord
    {
        internal XblPresenceTitleRecord(Interop.XblPresenceTitleRecord interopRecord)
        {
            this.TitleId = interopRecord.titleId;
            this.TitleName = interopRecord.titleName.GetString();
            this.LastModified = interopRecord.lastModified.DateTime;
            this.TitleActive = interopRecord.titleActive;
            this.RichPresenceString = interopRecord.richPresenceString.GetString();
            this.ViewState = interopRecord.viewState;
            this.BroadcastRecord = interopRecord.GetBroadcastRecord(br =>new XblPresenceBroadcastRecord(br));
        }

        public UInt32 TitleId { get; private set; }
        public string TitleName { get; private set; }
        public DateTime LastModified { get; private set; }
        public bool TitleActive { get; private set; }
        public string RichPresenceString { get; private set; }
        public XblPresenceTitleViewState ViewState { get; private set; }
        public XblPresenceBroadcastRecord BroadcastRecord { get; private set; }
    }
}
