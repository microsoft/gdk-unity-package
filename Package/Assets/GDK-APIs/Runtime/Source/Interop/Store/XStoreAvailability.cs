using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStoreAvailability
    //{
    //    _Field_z_ const char* availabilityId;
    //    XStorePrice price;
    //    time_t endDate;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStoreAvailability
    {
        internal readonly UTF8StringPtr availabilityId;
        internal readonly XStorePrice price;
        internal readonly TimeT endDate;

        internal XStoreAvailability(XGamingRuntime.XStoreAvailability publicObject, DisposableCollection disposableCollection)
        {
            this.availabilityId = new UTF8StringPtr(publicObject.AvailabilityId, disposableCollection);
            this.price = new XStorePrice(publicObject.Price, disposableCollection);
            this.endDate = new TimeT(publicObject.EndDate);
        }
    }
}