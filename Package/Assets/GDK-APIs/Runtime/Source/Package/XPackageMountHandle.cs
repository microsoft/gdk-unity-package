using System;

namespace XGamingRuntime
{
    public class XPackageMountHandle
    {
        internal XPackageMountHandle(Interop.XPackageMountHandle rawHandle)
        {
            this.Handle = rawHandle;
        }

        internal Interop.XPackageMountHandle Handle;
    }
}
