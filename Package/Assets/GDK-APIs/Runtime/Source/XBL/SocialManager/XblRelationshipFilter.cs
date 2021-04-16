using System;

namespace XGamingRuntime
{
    public enum XblRelationshipFilter : UInt32
    {
        /// <summary>Unknown</summary>
        Unknown,

        /// <summary>Friends of the user (user is following)</summary>
        Friends,

        /// <summary>Favorites of the user</summary>
        Favorite
    }
}
