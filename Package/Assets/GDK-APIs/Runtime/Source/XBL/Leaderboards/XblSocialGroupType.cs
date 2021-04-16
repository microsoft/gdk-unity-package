using System;

namespace XGamingRuntime
{
    public enum XblSocialGroupType : UInt32
    {
        /// <summary> 
        /// No social group.
        /// </summary>
        None,

        /// <summary> 
        /// Social group for the people followed.
        /// </summary>
        People,

        /// <summary> 
        /// Social group for the people tagged as favorites.
        /// </summary>
        Favorites
    }
}
