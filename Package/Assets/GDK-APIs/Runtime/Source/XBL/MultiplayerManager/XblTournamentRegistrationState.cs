using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblTournamentRegistrationState : uint32_t
    //{
    //    Unknown,
    //    Pending,
    //    Withdrawn,
    //    Rejected,
    //    Registered,
    //    Completed
    //};
    /// <summary>
    /// Deprecated
    /// </summary>
    public enum XblTournamentRegistrationState : UInt32
    {
        Unknown = 0,
        Pending = 1,
        Withdrawn = 2,
        Rejected = 3,
        Registered = 4,
        Completed = 5,
    }
}