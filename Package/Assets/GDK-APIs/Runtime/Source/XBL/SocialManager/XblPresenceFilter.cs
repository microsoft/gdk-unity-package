using System;

namespace XGamingRuntime
{
    public enum XblPresenceFilter : UInt32
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// Is currently playing current title and is online.
        /// </summary>
        TitleOnline,

        /// <summary>
        /// Has played this title and is offline.
        /// </summary>
        TitleOffline,

        /// <summary>
        /// Has played this title, is online but not currently playing this title.
        /// </summary>
        TitleOnlineOutsideTitle,

        /// <summary>
        /// Everyone currently online.
        /// </summary>
        AllOnline,

        /// <summary>
        /// Everyone currently offline.
        /// </summary>
        AllOffline,

        /// <summary>
        /// Everyone who has played or is playing the title.
        /// </summary>
        AllTitle,

        /// <summary>
        /// Everyone.
        /// </summary>
        All
    }
}
