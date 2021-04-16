using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblDeviceToken
    {
        internal XblDeviceToken(Interop.XblDeviceToken interopStruct)
        {
            this.Value = interopStruct.GetValue();
        }

        public string Value { get; private set; }
    }
}