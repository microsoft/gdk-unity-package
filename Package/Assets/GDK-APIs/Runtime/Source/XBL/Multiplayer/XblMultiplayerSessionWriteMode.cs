using System;

namespace XGamingRuntime
{
    //enum class XblMultiplayerSessionWriteMode : uint32_t
    //{
    //    CreateNew,
    //    UpdateOrCreateNew,
    //    UpdateExisting,
    //    SynchronizedUpdate,
    //};
    public enum XblMultiplayerSessionWriteMode : UInt32
    {
        CreateNew = 0,
        UpdateOrCreateNew = 1,
        UpdateExisting = 2,
        SynchronizedUpdate = 3
    }
}
