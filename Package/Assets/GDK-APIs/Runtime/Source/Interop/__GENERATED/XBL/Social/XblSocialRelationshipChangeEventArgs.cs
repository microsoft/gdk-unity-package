using System;

namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblSocialRelationshipChangeEventArgs
    {
        [NativeTypeName("uint64_t")]
        public ulong callerXboxUserId;

        public XblSocialNotificationType socialNotification;

        [NativeTypeName("uint64_t *")]
        public ulong* xboxUserIds;

        [NativeTypeName("size_t")]
        public SizeT xboxUserIdsCount;
    }
}
