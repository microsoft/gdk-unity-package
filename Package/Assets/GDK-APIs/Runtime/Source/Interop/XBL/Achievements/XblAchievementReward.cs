using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblAchievementReward
    //{
    //    _Field_z_ const char* name;
    //    _Field_z_ const char* description;
    //    _Field_z_ const char* value;
    //    XblAchievementRewardType rewardType;
    //    _Field_z_ const char* valueType;
    //    XblAchievementMediaAsset* mediaAsset;
    //}
    //XblAchievementReward;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblAchievementReward
    {
        #region IntPtr wrappers
        internal T GetMediaAsset<T>(Func<Interop.XblAchievementMediaAsset, T> ctor) where T : class { return Converters.PtrToClass<T, XblAchievementMediaAsset>(this.mediaAsset, ctor); }
        #endregion

        internal readonly UTF8StringPtr name;
        internal readonly UTF8StringPtr description;
        internal readonly UTF8StringPtr value;
        internal readonly XblAchievementRewardType rewardType;
        internal readonly UTF8StringPtr valueType;
        private readonly IntPtr mediaAsset;
    }
}
