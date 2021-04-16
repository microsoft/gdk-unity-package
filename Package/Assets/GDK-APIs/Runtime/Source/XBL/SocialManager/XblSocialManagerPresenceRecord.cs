using System;
using System.Linq;

namespace XGamingRuntime
{
    public class XblSocialManagerPresenceRecord
    {
        internal XblSocialManagerPresenceRecord(Interop.XblSocialManagerPresenceRecord interopRecord)
        {
            this.UserState = interopRecord.userState;
            this.PresenceTitleRecords = interopRecord.presenceTitleRecords
                .Where((r, index) =>(UInt32)index < interopRecord.presenceTitleCount)
                .Select(r =>new XblSocialManagerPresenceTitleRecord(r))
                .ToArray();
        }

        public XblPresenceUserState UserState { get; private set; }
        public XblSocialManagerPresenceTitleRecord[] PresenceTitleRecords;
    }
}
