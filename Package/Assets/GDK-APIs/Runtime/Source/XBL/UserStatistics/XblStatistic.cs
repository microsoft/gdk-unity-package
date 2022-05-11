using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblStatistic
    {
        internal XblStatistic(Interop.XblStatisticInternal interopStatistic)
        {
            this.StatisticName = interopStatistic.statisticName.GetString();
            this.StatisticType = interopStatistic.statisticType.GetString();
            this.Value = interopStatistic.value.GetString();
        }

        internal unsafe XblStatistic(Interop.XblStatistic interopStatistic)
        {
            StatisticName = Converters.NullTerminatedBytePointerToString((byte*)interopStatistic.statisticName);
            StatisticType = Converters.NullTerminatedBytePointerToString((byte*)interopStatistic.statisticType);
            Value = Converters.NullTerminatedBytePointerToString((byte*)interopStatistic.value);
        }

        public string StatisticName { get; private set; }
        public string StatisticType { get; private set; }
        public string Value { get; private set; }
    }
}
