using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    //typedef struct XblAchievementRequirement
    //{
    //    _Field_z_ const char* id;
    //    _Field_z_ const char* currentProgressValue;
    //    _Field_z_ const char* targetProgressValue;
    //}
    //XblAchievementRequirement;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblAchievementRequirement
    {
        internal readonly UTF8StringPtr id;
        internal readonly UTF8StringPtr currentProgressValue;
        internal readonly UTF8StringPtr targetProgressValue;
    }
}
