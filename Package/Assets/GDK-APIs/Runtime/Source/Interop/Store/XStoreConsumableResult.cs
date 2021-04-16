using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreConsumableResult
    //{
    //    uint32_t quantity;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreConsumableResult
    {
        internal readonly UInt32 quantity;

        internal XStoreConsumableResult(XGamingRuntime.XStoreConsumableResult publicObject)
        {
            this.quantity = publicObject.Quantity;
        }
    }
}