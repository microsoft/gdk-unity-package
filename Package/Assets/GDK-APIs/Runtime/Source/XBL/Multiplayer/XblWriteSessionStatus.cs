using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    //enum class XblWriteSessionStatus : uint32_t
    //{
    //    Unknown,
    //    AccessDenied,
    //    Created,
    //    Conflict,
    //    HandleNotFound,
    //    OutOfSync,
    //    SessionDeleted,
    //    Updated
    //};
    public enum XblWriteSessionStatus : UInt32
    {
        Unknown = 0,
        AccessDenied = 1,
        Created = 2,
        Conflict = 3,
        HandleNotFound = 4,
        OutOfSync = 5,
        SessionDeleted = 6,
        Updated = 7,
    }
}