using System;

namespace XGamingRuntime.Interop
{
    public unsafe partial struct XblSocialRelationship
    {
        [NativeTypeName("uint64_t")]
        public ulong xboxUserId;

        public bool isFavorite;

        public bool isFollowingCaller;

        [NativeTypeName("const char **")]
        public sbyte** socialNetworks;

        [NativeTypeName("size_t")]
        public SizeT socialNetworksCount;
    }
}
