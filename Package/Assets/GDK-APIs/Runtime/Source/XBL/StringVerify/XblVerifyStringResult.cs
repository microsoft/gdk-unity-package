using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblVerifyStringResult
    {
        internal XblVerifyStringResult(Interop.XblVerifyStringResult interopStruct)
        {
            this.ResultCode = interopStruct.resultCode;
            this.FirstOffendingSubstring = interopStruct.firstOffendingSubstring.GetString();
        }

        public XblVerifyStringResultCode ResultCode { get; private set; }
        public string FirstOffendingSubstring { get; private set; }
    }
}
