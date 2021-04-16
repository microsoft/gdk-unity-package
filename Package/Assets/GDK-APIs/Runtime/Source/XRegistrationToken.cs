using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime
{
    public class XRegistrationToken
    {
        internal XRegistrationToken(GCHandle callbackHandle, Interop.XTaskQueueRegistrationToken token)
        {
            CallbackHandle = callbackHandle;
            Token = token;
        }

        internal GCHandle CallbackHandle { get; private set; }
        internal Interop.XTaskQueueRegistrationToken Token { get; private set; }
    }
}
