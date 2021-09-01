namespace XGamingRuntime.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum XblTicketStatus : uint
    {
        Unknown,
        Expired,
        Searching,
        Found,
        Canceled,
    }
}
