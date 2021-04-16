using System;

namespace XGamingRuntime
{
    public enum XblVerifyStringResultCode : UInt32
    {
        /// <summary>No issues were found with the string.</summary>
        Success,

        /// <summary>The string contains offensive content.</summary>
        Offensive,

        /// <summary>The string is too long to verify.</summary>
        TooLong,

        /// <summary>An unknown error was encountered during string verification.</summary>
        UnknownError
    }
}