using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XGamingRuntime
{
    public class XblUserStatisticsResult
    {
        internal XblUserStatisticsResult(Interop.XblUserStatisticsResult interopResult)
        {
            this.XboxUserId = interopResult.xboxUserId;
            this.ServiceConfigStatistics = interopResult.GetServiceConfigStatistics(scs =>new XblServiceConfigurationStatistic(scs));
        }

        public UInt64 XboxUserId { get; private set; }
        public XblServiceConfigurationStatistic[] ServiceConfigStatistics { get; private set; }
    }
}
