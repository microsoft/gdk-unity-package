using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XGameUiWebAuthenticationResultData
    {
        internal XGameUiWebAuthenticationResultData(Interop.XGameUiWebAuthenticationResultData interopResult)
        {
            this.responseStatus = interopResult.responseStatus;
            this.responseCompletionUriSize = (UInt64)interopResult.responseCompletionUriSize.ToUInt32();
            this.responseCompletionUri = interopResult.responseCompletionUri.GetString();
        }

        public Int32 responseStatus;
        public UInt64 responseCompletionUriSize;
        public string responseCompletionUri;
    }
}