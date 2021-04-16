using System;

namespace XGamingRuntime
{
    public enum XblPresenceTitleViewState : UInt32
    {
        /// <summary>Unknown view state.</summary>
        Unknown,

        /// <summary>The title's view is using the full screen.</summary>
        FullScreen,

        /// <summary>The title's view is using part of the screen with another application snapped.</summary>
        Filled,

        /// <summary>The title's view is snapped with another application using a part of the screen.</summary>
        Snapped,

        /// <summary>The title's running in the background and is not visible.</summary>
        Background
    }
}
