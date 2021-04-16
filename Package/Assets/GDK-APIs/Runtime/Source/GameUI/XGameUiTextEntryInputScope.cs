using System;

namespace XGamingRuntime
{
    public enum XGameUiTextEntryInputScope : UInt32
    {
        Default = 0,
        Url = 1,
        EmailSmtpAddress = 5,
        Number = 29,
        Password = 31,
        TelephoneNumber = 32,
        Alphanumeric = 40,
        Search = 50
    }
}