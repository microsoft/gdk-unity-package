using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblLeaderboardColumn
    // {
    //     _Field_z_ const char* statName;
    //     XblLeaderboardStatType statType;
    // } XblLeaderboardColumn;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblLeaderboardColumn
    {
        internal readonly UTF8StringPtr statName;
        internal readonly XblLeaderboardStatType statType;

        internal XblLeaderboardColumn(XGamingRuntime.XblLeaderboardColumn column, DisposableCollection disposableCollection)
        {
            this.statName = new UTF8StringPtr(column.StatName, disposableCollection);
            this.statType = column.StatType;
        }
    }
}
