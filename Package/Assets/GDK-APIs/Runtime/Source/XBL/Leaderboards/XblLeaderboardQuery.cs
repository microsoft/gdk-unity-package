using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
    public class XblLeaderboardQuery
    {
        private XblLeaderboardQuery(
            UInt64 xboxUserId,
            string serviceConfigurationId,
            string leaderboardName,
            string statName,
            XblSocialGroupType socialGroup,
            string[] additionalColumnleaderboardNames,
            XblLeaderboardSortOrder order,
            UInt32 maxItems,
            UInt64 skipToXboxUserId,
            UInt32 skipResultToRank,
            string continuationToken,
            XblLeaderboardQueryType queryType)
        {
            this.XboxUserId = xboxUserId;
            this.ServiceConfigurationId = serviceConfigurationId;
            this.LeaderboardName = leaderboardName;
            this.StatName = statName;
            this.SocialGroup = socialGroup;
            this.AdditionalColumnleaderboardNames = additionalColumnleaderboardNames;
            this.Order = order;
            this.MaxItems = maxItems;
            this.SkipToXboxUserId = skipToXboxUserId;
            this.SkipResultToRank = skipResultToRank;
            this.ContinuationToken = continuationToken;
            this.QueryType = queryType;
        }

        internal XblLeaderboardQuery(Interop.XblLeaderboardQuery interopLeaderboardQuery)
        {
            this.XboxUserId = interopLeaderboardQuery.xboxUserId;
            this.ServiceConfigurationId = interopLeaderboardQuery.GetScid();
            this.LeaderboardName = interopLeaderboardQuery.leaderboardName.GetString();
            this.StatName = interopLeaderboardQuery.statName.GetString();
            this.SocialGroup = interopLeaderboardQuery.socialGroup;
            this.AdditionalColumnleaderboardNames = interopLeaderboardQuery.GetAdditionalColumnleaderboardNames();
            this.Order = interopLeaderboardQuery.order;
            this.MaxItems = interopLeaderboardQuery.maxItems;
            this.SkipToXboxUserId = interopLeaderboardQuery.skipToXboxUserId;
            this.SkipResultToRank = interopLeaderboardQuery.skipResultToRank;
            this.ContinuationToken = interopLeaderboardQuery.continuationToken.GetString();
            this.QueryType = interopLeaderboardQuery.queryType;
        }

        public static Int32 Create(
            UInt64 xboxUserId,
            string serviceConfigurationId,
            string leaderboardName,
            string statName,
            XblSocialGroupType socialGroup,
            string[] additionalColumnleaderboardNames,
            XblLeaderboardSortOrder order,
            UInt32 maxItems,
            UInt64 skipToXboxUserId,
            UInt32 skipResultToRank,
            string continuationToken,
            XblLeaderboardQueryType queryType,
            out XblLeaderboardQuery leaderboardQuery)
        {
            if (!Interop.XblLeaderboardQuery.ValidateFields(scid: serviceConfigurationId))
            {
                leaderboardQuery = default(XblLeaderboardQuery);
                return HR.E_INVALIDARG;
            }

            leaderboardQuery = new XblLeaderboardQuery(
                xboxUserId,
                serviceConfigurationId,
                leaderboardName,
                statName,
                socialGroup,
                additionalColumnleaderboardNames,
                order,
                maxItems,
                skipToXboxUserId,
                skipResultToRank,
                continuationToken,
                queryType);

            return HR.S_OK;
        }

        public UInt64 XboxUserId { get; private set; }
        public string ServiceConfigurationId { get; private set; }
        public string LeaderboardName { get; private set; }
        public string StatName { get; private set; }
        public XblSocialGroupType SocialGroup { get; private set; }
        public string[] AdditionalColumnleaderboardNames { get; private set; }
        public XblLeaderboardSortOrder Order { get; private set; }
        public UInt32 MaxItems { get; private set; }
        public UInt64 SkipToXboxUserId { get; private set; }
        public UInt32 SkipResultToRank { get; private set; }
        public string ContinuationToken { get; private set; }
        public XblLeaderboardQueryType QueryType { get; private set; }
    }
}
