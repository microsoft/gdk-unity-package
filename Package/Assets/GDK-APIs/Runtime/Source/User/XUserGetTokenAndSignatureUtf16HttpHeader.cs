﻿namespace XGamingRuntime
{
    public class XUserGetTokenAndSignatureUtf16HttpHeader
    {
        public XUserGetTokenAndSignatureUtf16HttpHeader(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; private set; }
        public string Value { get; private set; }
    }
}
