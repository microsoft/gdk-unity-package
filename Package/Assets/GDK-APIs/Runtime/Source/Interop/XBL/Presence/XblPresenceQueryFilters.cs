using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblPresenceQueryFilters
    // {
    //     const XblPresenceDeviceType* deviceTypes;
    //     size_t deviceTypesCount;
    //     const uint32_t* titleIds;
    //     size_t titleIdsCount;
    //     XblPresenceDetailLevel detailLevel;
    //     bool onlineOnly;
    //     bool broadcastingOnly;
    // } XblPresenceQueryFilters;

    // Note: class, not struct since it is exclusively passed by reference.
    [StructLayout(LayoutKind.Sequential)]
    internal class XblPresenceQueryFiltersRef
    {
        private readonly IntPtr deviceTypes;
        private readonly SizeT deviceTypesCount;
        private readonly IntPtr titleIds;
        private readonly SizeT titleIdsCount;
        internal readonly XblPresenceDetailLevel detailLevel;
        [MarshalAs(UnmanagedType.U1)]
        internal bool onlineOnly;
        [MarshalAs(UnmanagedType.U1)]
        internal bool broadcastingOnly;

        internal XblPresenceQueryFiltersRef(XGamingRuntime.XblPresenceQueryFilters filters, DisposableCollection disposableCollection)
        {
            this.deviceTypes = Converters.ClassArrayToPtr(filters.DeviceTypes, (XblPresenceDeviceType dt, DisposableCollection _) =>dt, disposableCollection,
                out this.deviceTypesCount);
            this.titleIds = Converters.ClassArrayToPtr(filters.TitleIds, (UInt32 titleId, DisposableCollection _) =>titleId, disposableCollection,
                out this.titleIdsCount);
            this.detailLevel = filters.DetailLevel;
            this.onlineOnly = filters.OnlineOnly;
            this.broadcastingOnly = filters.BroadcastingOnly;
        }
    }
}
