using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblAchievementMediaAsset
    //{
    //    _Field_z_ const char* name;
    //    XblAchievementMediaAssetType mediaAssetType;
    //    _Field_z_ const char* url;
    //}
    //XblAchievementMediaAsset;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblAchievementMediaAsset
    {
        internal readonly UTF8StringPtr name;
        internal readonly XblAchievementMediaAssetType mediaAssetType;
        internal readonly UTF8StringPtr url;
    }
}
