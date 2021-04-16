using System;

namespace XGamingRuntime
{
    public enum XblLeaderboardStatType : UInt32
    {
        /// <summary>Unsigned 64 bit integer.</summary>
        Uint64,

        /// <summary>Boolean.</summary>
        Boolean,

        /// <summary>Double.</summary>
        Double,

        /// <summary>String.</summary>
        String,

        /// <summary>Unknown.</summary>
        Other
    }
}
