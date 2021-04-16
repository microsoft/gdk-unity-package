using System;

namespace XGamingRuntime
{
    public class XblRequestedStatistics
    {
        private XblRequestedStatistics(string serviceConfigurationId, string[] statistics)
        {
            this.ServiceConfigurationId = serviceConfigurationId;
            this.Statistics = statistics;
        }

        public static Int32 Create(string serviceConfigurationId, string[] statistics, out XblRequestedStatistics requestedStatistics)
        {
            if (!Interop.XblRequestedStatistics.ValidateFields(serviceConfigurationId))
            {
                requestedStatistics = default(XblRequestedStatistics);
                return Interop.HR.E_INVALIDARG;
            }

            requestedStatistics = new XblRequestedStatistics(serviceConfigurationId, statistics);
            return Interop.HR.S_OK;
        }

        public string ServiceConfigurationId { get; private set; }
        public string[] Statistics { get; private set; }
    }
}
