using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblMultiplayerConnectionAddressDeviceTokenPair
    {
        internal XblMultiplayerConnectionAddressDeviceTokenPair(Interop.XblMultiplayerConnectionAddressDeviceTokenPair interopStruct)
        {
            this.ConnectionAddress = interopStruct.connectionAddress.GetString();
            this.DeviceToken = new XblDeviceToken(interopStruct.deviceToken);
        }

        public string ConnectionAddress { get; private set; }
        public XblDeviceToken DeviceToken { get; private set; }
    }
}