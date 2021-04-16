using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreConsumableResult
    {
        internal XStoreConsumableResult(Interop.XStoreConsumableResult interopStruct)
        {
            this.Quantity = interopStruct.quantity;
        }

        public UInt32 Quantity { get; private set; }
    }
}