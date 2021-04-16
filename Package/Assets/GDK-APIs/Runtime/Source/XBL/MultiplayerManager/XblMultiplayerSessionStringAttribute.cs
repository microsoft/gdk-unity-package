using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionStringAttribute
    {
        public XblMultiplayerSessionStringAttribute(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        internal XblMultiplayerSessionStringAttribute(Interop.XblMultiplayerSessionStringAttribute interopStruct)
        {
            this.Name = interopStruct.GetName();
            this.Value = interopStruct.GetValue();
        }

        public string Name { get; private set; }
        public string Value { get; private set; }
    }
}