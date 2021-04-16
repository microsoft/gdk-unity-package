using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //struct XStorePrice
    //{
    //    float basePrice;
    //    float price;
    //    float recurrencePrice;
    //    _Field_z_ const char* currencyCode;
    //    _Field_z_ char formattedBasePrice[PRICE_MAX_SIZE];
    //    _Field_z_ char formattedPrice[PRICE_MAX_SIZE];
    //    _Field_z_ char formattedRecurrencePrice[PRICE_MAX_SIZE];
    //    bool isOnSale;
    //    time_t saleEndDate;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct XStorePrice
    {
        internal readonly float basePrice;
        internal readonly float price;
        internal readonly float recurrencePrice;
        internal readonly UTF8StringPtr currencyCode;
        private unsafe fixed Byte formattedBasePrice[16]; // char formattedBasePrice[16]
        private unsafe fixed Byte formattedPrice[16]; // char formattedPrice[16]
        private unsafe fixed Byte formattedRecurrencePrice[16]; // char formattedRecurrencePrice[16]
        internal readonly NativeBool isOnSale;
        internal readonly TimeT saleEndDate;

        internal string GetFormattedBasePrice() { unsafe { fixed (Byte* ptr = this.formattedBasePrice) { return Converters.BytePointerToString(ptr, 16); } } }
        internal string GetFormattedPrice() { unsafe { fixed (Byte* ptr = this.formattedPrice) { return Converters.BytePointerToString(ptr, 16); } } }
        internal string GetFormattedRecurrencePrice() { unsafe { fixed (Byte* ptr = this.formattedRecurrencePrice) { return Converters.BytePointerToString(ptr, 16); } } }

        internal XStorePrice(XGamingRuntime.XStorePrice publicObject, DisposableCollection disposableCollection)
        {
            this.basePrice = publicObject.BasePrice;
            this.price = publicObject.Price;
            this.recurrencePrice = publicObject.RecurrencePrice;
            this.currencyCode = new UTF8StringPtr(publicObject.CurrencyCode, disposableCollection);
            unsafe
            {
                fixed (Byte* ptr = this.formattedBasePrice)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.FormattedBasePrice, ptr, 16);
                }
            }
            unsafe
            {
                fixed (Byte* ptr = this.formattedPrice)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.FormattedPrice, ptr, 16);
                }
            }
            unsafe
            {
                fixed (Byte* ptr = this.formattedRecurrencePrice)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.FormattedRecurrencePrice, ptr, 16);
                }
            }
            this.isOnSale = new NativeBool(publicObject.IsOnSale);
            this.saleEndDate = new TimeT(publicObject.SaleEndDate);
        }
    }
}