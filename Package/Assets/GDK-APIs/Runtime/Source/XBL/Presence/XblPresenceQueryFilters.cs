using System;

namespace XGamingRuntime
{
    public class XblPresenceQueryFilters
    {
        private XblPresenceQueryFilters(
            XblPresenceDeviceType[] deviceTypes,
            UInt32[] titleIds,
            XblPresenceDetailLevel detailLevel,
            bool onlineOnly,
            bool broadcastingOnly)
        {
            this.DeviceTypes = deviceTypes;
            this.TitleIds = titleIds;
            this.DetailLevel = detailLevel;
            this.OnlineOnly = onlineOnly;
            this.BroadcastingOnly = broadcastingOnly;
        }

        public static Int32 Create(
            XblPresenceDeviceType[] deviceTypes,
            UInt32[] titleIds,
            XblPresenceDetailLevel detailLevel,
            bool onlineOnly,
            bool broadcastingOnly,
            out XblPresenceQueryFilters queryFilters)
        {
            queryFilters = new XblPresenceQueryFilters(
                deviceTypes,
                titleIds,
                detailLevel,
                onlineOnly,
                broadcastingOnly);

            return Interop.HR.S_OK;
        }

        public XblPresenceDeviceType[] DeviceTypes { get; private set; }
        public UInt32[] TitleIds { get; private set; }
        public XblPresenceDetailLevel DetailLevel { get; private set; }
        public bool OnlineOnly { get; private set; }
        public bool BroadcastingOnly { get; private set; }
    }
}
