using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionTag
    {
        public XblMultiplayerSessionTag(string value)
        {
            this.Value = value;
        }

        internal XblMultiplayerSessionTag(Interop.XblMultiplayerSessionTag interopStruct)
        {
            this.Value = interopStruct.GetValue();
        }

        public string Value { get; private set; }
    }
}