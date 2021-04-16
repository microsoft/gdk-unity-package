using System;

namespace XGamingRuntime
{
    public enum XblAchievementProgressState : UInt32
    {
        /// <summary>Achievement progress is unknown.</summary>
        Unknown,

        /// <summary>Achievement has been earned.</summary>
        Achieved,

        /// <summary>Achievement progress has not been started.</summary>
        NotStarted,

        /// <summary>Achievement progress has started.</summary>
        InProgress
    }
}
