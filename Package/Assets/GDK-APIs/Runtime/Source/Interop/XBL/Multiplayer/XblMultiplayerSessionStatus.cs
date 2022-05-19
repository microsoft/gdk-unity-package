
namespace XGamingRuntime
{
    public enum XblMultiplayerSessionStatus : uint
    {
        Unknown = Interop.XblMultiplayerSessionStatus.Unknown,
        Active = Interop.XblMultiplayerSessionStatus.Active,
        Inactive = Interop.XblMultiplayerSessionStatus.Inactive,
        Reserved = Interop.XblMultiplayerSessionStatus.Reserved
    }
}
