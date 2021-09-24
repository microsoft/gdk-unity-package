namespace XGamingRuntime
{
    public enum XblRealTimeActivityConnectionState : uint
    {
        Connected = Interop.XblRealTimeActivityConnectionState.Connected,
        Connecting = Interop.XblRealTimeActivityConnectionState.Connecting,
        Disconnected = Interop.XblRealTimeActivityConnectionState.Disconnected,
    }
}
