using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerSessionNumberAttribute
    {
        public XblMultiplayerSessionNumberAttribute(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }

        internal XblMultiplayerSessionNumberAttribute(Interop.XblMultiplayerSessionNumberAttribute interopStruct)
        {
            this.Name = interopStruct.GetName();
            this.Value = interopStruct.value;
        }

        public string Name { get; private set; }
        public double Value { get; private set; }
    }
}