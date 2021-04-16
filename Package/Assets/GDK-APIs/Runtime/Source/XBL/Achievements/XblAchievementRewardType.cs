using System;

namespace XGamingRuntime
{
    public enum XblAchievementRewardType : UInt32
    {
        /// <summary>The reward type is unknown.</summary>
        Unknown,

        /// <summary>A Gamerscore reward.</summary>
        Gamerscore,

        /// <summary>An in-app reward, defined and delivered by the title.</summary>
        InApp,

        /// <summary>A digital art reward.</summary>
        Art
    }
}

