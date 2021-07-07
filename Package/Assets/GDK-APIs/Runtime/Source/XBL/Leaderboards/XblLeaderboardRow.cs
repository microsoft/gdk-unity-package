using System;

namespace XGamingRuntime
{
    public class XblLeaderboardRow
    {
        internal XblLeaderboardRow(Interop.XblLeaderboardRow interopRow)
        {
            this.Gamertag = Interop.Converters.ByteArrayToString(interopRow.gamertag);
            this.ModernGamertag = Interop.Converters.ByteArrayToString(interopRow.modernGamertag);
            this.ModernGamertagSuffix = Interop.Converters.ByteArrayToString(interopRow.modernGamertagSuffix);
            this.UniqueModernGamertag = Interop.Converters.ByteArrayToString(interopRow.uniqueModernGamertag);
            this.XboxUserId = interopRow.xboxUserId;
            this.Percentile = interopRow.percentile;
            this.Rank = interopRow.rank;
            this.GlobalRank = interopRow.globalRank;
            this.ColumnValues = interopRow.GetColumnValues();
        }

        public string Gamertag { get; private set; }
        public string ModernGamertag { get; private set; }
        public string ModernGamertagSuffix { get; private set; }
        public string UniqueModernGamertag { get; private set; }
        public UInt64 XboxUserId { get; private set; }
        public double Percentile { get; private set; }
        public UInt32 Rank { get; private set; }
        public UInt32 GlobalRank { get; private set; }
        public string[] ColumnValues { get; private set; }
    }
}
