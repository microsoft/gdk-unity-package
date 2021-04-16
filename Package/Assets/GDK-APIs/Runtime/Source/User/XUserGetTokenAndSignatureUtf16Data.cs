namespace XGamingRuntime
{
    public class XUserGetTokenAndSignatureUtf16Data
    {
        internal XUserGetTokenAndSignatureUtf16Data(string token, string signature)
        {
            this.Token = token;
            this.Signature = signature;
        }

        public string Token { get; private set; }
        public string Signature { get; private set; }
    }
}
