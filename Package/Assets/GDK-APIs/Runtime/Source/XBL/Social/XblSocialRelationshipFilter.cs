using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XGamingRuntime
{
    public enum XblSocialRelationshipFilter : uint 
    {
        All = Interop.XblSocialRelationshipFilter.All,
        Favorite = Interop.XblSocialRelationshipFilter.Favorite,
        LegacyXboxLiveFriends = Interop.XblSocialRelationshipFilter.LegacyXboxLiveFriends,
    }
}
