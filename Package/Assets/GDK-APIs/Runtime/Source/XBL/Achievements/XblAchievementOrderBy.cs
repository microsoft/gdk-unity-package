using System;

namespace XGamingRuntime
{
    public enum XblAchievementOrderBy : UInt32
    {
        /// <summary>Default order does not guarantee sort order.</summary>
        DefaultOrder,

        /// <summary>Sort by title id.</summary>
        TitleId,

        /// <summary>Sort by achievement unlock time.</summary>
        UnlockTime
    }
}
