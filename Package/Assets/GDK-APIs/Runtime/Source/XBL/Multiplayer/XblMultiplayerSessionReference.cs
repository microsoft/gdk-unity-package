using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionReference
    {
        internal XblMultiplayerSessionReference(Interop.XblMultiplayerSessionReference interopStruct)
        {
            this.Scid = interopStruct.GetScid();
            this.SessionTemplateName = interopStruct.GetSessionTemplateName();
            this.SessionName = interopStruct.GetSessionName();
        }

        public string Scid { get; private set; }
        public string SessionTemplateName { get; private set; }
        public string SessionName { get; private set; }
    }
}