using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XGamingRuntime
{
    public class XblStatistic
    {
        internal XblStatistic(Interop.XblStatistic interopStatistic)
        {
            this.StatisticName = interopStatistic.statisticName.GetString();
            this.StatisticType = interopStatistic.statisticType.GetString();
            this.Value = interopStatistic.value.GetString();
        }

        public string StatisticName { get; private set; }
        public string StatisticType { get; private set; }
        public string Value { get; private set; }
    }
}
