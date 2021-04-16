using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionReferenceUri
    {
        internal XblMultiplayerSessionReferenceUri(Interop.XblMultiplayerSessionReferenceUri interopStruct)
        {
            this.Value = interopStruct.GetValue();
        }

        public string Value { get; private set; }
    }
}