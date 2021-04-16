using System;

namespace XGamingRuntime
{
    [Flags]
    public enum XblSocialManagerExtraDetailLevel : UInt32
    {
        /// <summary>Only get default PeopleHub information (presence, profile)</summary>
        NoExtraDetail,

        /// <summary>Add extra detail for the title history for the users</summary>
        TitleHistoryLevel = 0x1,

        /// <summary>Add extra detail for the preferred color for the users</summary>
        PreferredColorLevel = 0x2,

        /// <summary>Add all extra detail</summary>
        All = 0x3,
    }
}
