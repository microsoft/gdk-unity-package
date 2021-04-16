using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XStorePrice
    {
        internal XStorePrice(Interop.XStorePrice interopStruct)
        {
            this.BasePrice = interopStruct.basePrice;
            this.Price = interopStruct.price;
            this.RecurrencePrice = interopStruct.recurrencePrice;
            this.CurrencyCode = interopStruct.currencyCode.GetString();
            this.FormattedBasePrice = interopStruct.GetFormattedBasePrice();
            this.FormattedPrice = interopStruct.GetFormattedPrice();
            this.FormattedRecurrencePrice = interopStruct.GetFormattedRecurrencePrice();
            this.IsOnSale = interopStruct.isOnSale.Value;
            this.SaleEndDate = interopStruct.saleEndDate.DateTime;
        }

        public float BasePrice { get; private set; }
        public float Price { get; private set; }
        public float RecurrencePrice { get; private set; }
        public string CurrencyCode { get; private set; }
        public string FormattedBasePrice { get; private set; }
        public string FormattedPrice { get; private set; }
        public string FormattedRecurrencePrice { get; private set; }
        public bool IsOnSale { get; private set; }
        public DateTime SaleEndDate { get; private set; }
    }
}