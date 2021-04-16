using System;

namespace XGamingRuntime
{
    public enum XblPresenceDetailLevel : UInt32
    {
        /// <summary>Default detail level.</summary>
        Default,

        /// <summary>User detail level. User presence info only, no device, title or rich presence info.</summary>
        User,

        /// <summary>Device detail level. User and device presence info only, no title or rich presence info.</summary>
        Device,

        /// <summary>Title detail level. User, device and title presence info only, no rich presence info.</summary>
        Title,

        /// <summary>All detail possible. User, device, title and rich presence info will be provided.</summary>
        All
    }
}
