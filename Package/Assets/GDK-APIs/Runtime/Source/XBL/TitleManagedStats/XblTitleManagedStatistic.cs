using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblTitleManagedStatistic
    {
        public string StatisticName { get; set;  }
        public XblTitleManagedStatType StatisticType { get; set; }
        public double NumberValue { get; set; }
        public string StringValue { get; set; }

        internal XblTitleManagedStatistic(Interop.XblTitleManagedStatistic interopStruct)
        {
            this.StatisticName = interopStruct.statisticName.GetString();
            this.StatisticType = interopStruct.statisticType;
            this.NumberValue = interopStruct.numberValue;
            this.StringValue = interopStruct.stringValue.GetString();
        }
        
        internal XblTitleManagedStatistic(string statisticName, XblTitleManagedStatType statType, string stringValue, double numberValue)
        {
            this.StatisticName = statisticName;
            this.StatisticType = statType;
            this.StringValue = stringValue;
            this.NumberValue = numberValue;
        }

        public XblTitleManagedStatistic()
        {
        }

        public XblTitleManagedStatistic(string statisticName, string statisticValue)
            : this(statisticName, XblTitleManagedStatType.String, statisticValue, default(double))
        {
        }

        public XblTitleManagedStatistic(string statisticName, double statisticValue)
            : this(statisticName, XblTitleManagedStatType.Number, default(string), statisticValue)
        {
        }
    }
}