using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblLeaderboardRow
    // {
    //     _Field_z_ char gamertag[XBL_GAMERTAG_CHAR_SIZE];
    //     char modernGamertag[XBL_MODERN_GAMERTAG_CHAR_SIZE];
    //     char modernGamertagSuffix[XBL_MODERN_GAMERTAG_SUFFIX_CHAR_SIZE];
    //     char uniqueModernGamertag[XBL_UNIQUE_MODERN_GAMERTAG_CHAR_SIZE];
    //     uint64_t xboxUserId;
    //     double percentile;
    //     uint32_t rank;
    //     _Field_z_ const char** columnValues;
    //     size_t columnValuesCount;
    // } XblLeaderboardRow;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblLeaderboardRow
    {
        public string[] GetColumnValues() { return Converters.PtrToClassArray<string, UTF8StringPtr>(this.columnValues, this.columnValuesCount, s =>s.GetString()); }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_GAMERTAG_CHAR_SIZE)]
        internal readonly byte[] gamertag;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_MODERN_GAMERTAG_CHAR_SIZE)]
        internal readonly byte[] modernGamertag;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_MODERN_GAMERTAG_SUFFIX_CHAR_SIZE)]
        internal readonly byte[] modernGamertagSuffix;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = XblInterop.XBL_UNIQUE_MODERN_GAMERTAG_CHAR_SIZE)]
        internal readonly byte[] uniqueModernGamertag;

        internal readonly UInt64 xboxUserId;
        internal readonly double percentile;
        internal readonly UInt32 rank;
        internal readonly UInt32 globalRank;
        private readonly IntPtr columnValues;
        private readonly SizeT columnValuesCount;

        internal XblLeaderboardRow(XGamingRuntime.XblLeaderboardRow row, DisposableCollection disposableCollection)
        {
            this.gamertag = Converters.StringToNullTerminatedUTF8ByteArray(row.Gamertag, XblInterop.XBL_GAMERTAG_CHAR_SIZE);
            this.modernGamertag = Converters.StringToNullTerminatedUTF8ByteArray(row.ModernGamertag, XblInterop.XBL_MODERN_GAMERTAG_CHAR_SIZE);
            this.modernGamertagSuffix = Converters.StringToNullTerminatedUTF8ByteArray(row.ModernGamertagSuffix, XblInterop.XBL_MODERN_GAMERTAG_SUFFIX_CHAR_SIZE);
            this.uniqueModernGamertag = Converters.StringToNullTerminatedUTF8ByteArray(row.UniqueModernGamertag, XblInterop.XBL_UNIQUE_MODERN_GAMERTAG_CHAR_SIZE);
            this.xboxUserId = row.XboxUserId;
            this.percentile = row.Percentile;
            this.rank = row.Rank;
            this.globalRank = row.GlobalRank;
            this.columnValues = Converters.ClassArrayToPtr(row.ColumnValues, (s, dc) =>new UTF8StringPtr(s, dc), disposableCollection, out this.columnValuesCount);
        }
    }
}
