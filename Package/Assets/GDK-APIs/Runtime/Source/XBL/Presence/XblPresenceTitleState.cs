using System;

namespace XGamingRuntime
{
    public enum XblPresenceTitleState : UInt32
    {
        /// <summary>
        /// Indicates this is a Unknown state.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates the user started playing the title.
        /// </summary>
        Started,

        /// <summary>
        /// Indicates the user ended playing the title.
        /// </summary>
        Ended
    }
}
