using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStoreAvailability
    {
        internal XStoreAvailability(Interop.XStoreAvailability interopStruct)
        {
            this.AvailabilityId = interopStruct.availabilityId.GetString();
            this.Price = new XStorePrice(interopStruct.price);
            this.EndDate = interopStruct.endDate.DateTime;
        }

        public string AvailabilityId { get; private set; }
        public XStorePrice Price { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}