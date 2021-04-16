using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblLeaderboardQuery
    // {
    //     uint64_t xboxUserId;
    //     _Field_z_ char scid[XBL_SCID_LENGTH];
    //     _Field_z_ const char* leaderboardName;
    //     _Field_z_ const char* statName;
    //     XblSocialGroupType socialGroup;
    //     _Field_z_ const char** additionalColumnleaderboardNames;
    //     size_t additionalColumnleaderboardNamesCount;
    //     XblLeaderboardSortOrder order;
    //     uint32_t maxItems;
    //     uint64_t skipToXboxUserId;
    //     uint32_t skipResultToRank;
    //     _Field_z_ const char* continuationToken;
    //     XblLeaderboardQueryType queryType;
    // } XblLeaderboardQuery;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblLeaderboardQuery
    {
        internal string[] GetAdditionalColumnleaderboardNames()
        {
            return Converters.PtrToClassArray<string, UTF8StringPtr>(this.additionalColumnleaderboardNames, this.additionalColumnleaderboardNamesCount, s => s.GetString());
        }

        internal string GetScid()
        {
            unsafe
            {
                fixed (Byte* scidPointer = this.scid)
                {
                    return Converters.BytePointerToString(scidPointer, XblInterop.XBL_SCID_LENGTH);
                }
            }
        }

        internal readonly UInt64 xboxUserId;
        private unsafe fixed Byte scid[XblInterop.XBL_SCID_LENGTH];
        internal readonly UTF8StringPtr leaderboardName;
        internal readonly UTF8StringPtr statName;
        internal readonly XblSocialGroupType socialGroup;
        private readonly IntPtr additionalColumnleaderboardNames;
        private readonly SizeT additionalColumnleaderboardNamesCount;
        internal readonly XblLeaderboardSortOrder order;
        internal readonly UInt32 maxItems;
        internal readonly UInt64 skipToXboxUserId;
        internal readonly UInt32 skipResultToRank;
        internal readonly UTF8StringPtr continuationToken;
        internal readonly XblLeaderboardQueryType queryType;

        internal XblLeaderboardQuery(XGamingRuntime.XblLeaderboardQuery query, DisposableCollection disposableCollection)
        {
            this.xboxUserId = query.XboxUserId;
            unsafe
            {
                fixed (Byte* scidPointer = this.scid)
                {
                    Converters.StringToNullTerminatedUTF8FixedPointer(query.ServiceConfigurationId, scidPointer, XblInterop.XBL_SCID_LENGTH);
                }
            }
            this.leaderboardName = new UTF8StringPtr(query.LeaderboardName, disposableCollection);
            this.statName = new UTF8StringPtr(query.StatName, disposableCollection);
            this.socialGroup = query.SocialGroup;
            this.additionalColumnleaderboardNames = Converters.StringArrayToUTF8StringArray(query.AdditionalColumnleaderboardNames, disposableCollection,
                out this.additionalColumnleaderboardNamesCount);
            this.order = query.Order;
            this.maxItems = query.MaxItems;
            this.skipToXboxUserId = query.SkipToXboxUserId;
            this.skipResultToRank = query.SkipResultToRank;
            this.continuationToken = new UTF8StringPtr(query.ContinuationToken, disposableCollection);
            this.queryType = query.QueryType;
        }

        internal static bool ValidateFields(string scid)
        {
            return (
                scid != null &&
                Converters.StringToNullTerminatedUTF8ByteArray(scid).Length <= XblInterop.XBL_SCID_LENGTH
            );
        }
    }
}
