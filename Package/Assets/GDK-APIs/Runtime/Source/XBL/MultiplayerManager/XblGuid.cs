using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblGuid
    {
        internal XblGuid(Interop.XblGuid interopStruct)
        {
            this.Value = interopStruct.GetValue();
        }

        public string Value { get; private set; }
    }
}