using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XGamingRuntime
{
    public class XblLeaderboardColumn
    {
        internal XblLeaderboardColumn(Interop.XblLeaderboardColumn interopColumn)
        {
            this.StatName = interopColumn.statName.GetString();
            this.StatType = interopColumn.statType;
        }

        public string StatName { get; private set; }
        public XblLeaderboardStatType StatType { get; private set; }
    }
}
