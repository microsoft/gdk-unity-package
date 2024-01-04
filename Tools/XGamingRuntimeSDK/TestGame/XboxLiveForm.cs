using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using XGamingRuntime;

namespace TestGame
{
    public partial class XboxLiveForm : Form
    {
        private StringBuilder logText = new StringBuilder();
        private bool hasLogText = false;
        private const string SCID = "00000000-0000-0000-0000-000076029b4d";
        private const UInt32 TitleId = 0x000076029B4D;
        private const Int32 HTTP_E_STATUS_NOT_MODIFIED = -2145844944;

        private XblContextHandle xblContextHandle = null;
        private XUserHandle userHandle = null;
        private UInt64 userId = 0;
        private XblAchievement[] achievements = null;
        private XblAchievement currentlySelectedAchievement = null;
        private XblSocialManagerUserGroupHandle socialUserGroup = null;
        private XblSocialManagerUserGroupHandle listUserGroup = null;
        private XblHttpCallHandle httpCall = null;

        public XboxLiveForm()
        {
            InitializeComponent();
            Int32 hresult = SDK.XBL.XblInitialize(SCID);
            LOG("XblInitialize", hresult);

            SDK.XUserAddAsync(XUserAddOptions.AddDefaultUserAllowingUI, (hr, userHandle) =>
            {
                LOG("XUserAddAsync", hr);
                if (hr >= 0)
                {
                    this.userHandle = userHandle;
                    hr = SDK.XBL.XblContextCreateHandle(userHandle, out xblContextHandle);
                    LOG("XblContextCreateHandle", hr);

                    hr = SDK.XUserGetId(userHandle, out userId);
                    LOG("XUserGetId", hr);
                }
                fetchAchievementsButton.Enabled = true;
            });

            InitializeListView();
        }

        private void AddAchievementToListView(XblAchievement achievement)
        {
            string[] row = { achievement.Id, achievement.Name, achievement.ProgressState.ToString() };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            //Add column header
            listView1.Columns.Add("Id", 100);
            listView1.Columns.Add("Name", 200);
            listView1.Columns.Add("ProgressState", 150);

        }

        private void ListView1_ItemSelectionChanged(Object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.ItemIndex >= achievements.Length)
            {
                throw new InvalidOperationException("App error: Selected invalid item");

            }
            earnAchievementButton.Enabled = true;
            currentlySelectedAchievement = achievements[e.ItemIndex];
            earnAchievementButton.Text = "Earn achievement #" + currentlySelectedAchievement.Id;

        }

        private void LogAchievement(XblAchievement achievement)
        {
            LOG("Achievement #" + achievement.Id + ": (" + achievement.Name + ") Progression state: " + achievement.ProgressState);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (this.hasLogText)
            {
                this.hasLogText = false;
                this.logTextBox.Text = this.logText.ToString();
                this.logTextBox.AppendText(" ");
            }

            // pump runtime callbacks on UI thread
            SDK.XTaskQueueDispatch();
            if (this.xblContextHandle != null)
            {
                int hr = SDK.XBL.XblSocialManagerDoWork(out XblSocialManagerEvent[] socialEvents);
                if (hr < 0)
                {
                    LOG("XblSocialManagerDoWork", hr);
                    return;
                }

                if (socialEvents != null && socialEvents.Length > 0)
                {
                    foreach (var se in socialEvents)
                    {
                        LOG($"{se.EventType} usersAffected:{string.Join(",", Array.ConvertAll(se.UsersAffected, u => u.UniqueModernGamertag))}");
                    }
                }
            }
        }

        private void LOG(string s)
        {
            this.hasLogText = true;
            logText.Append(s + "\r\n");
        }

        private void LOG(string s, Int32 hr)
        {
            this.hasLogText = true;
            logText.AppendFormat("{0} -- hresult = 0x{1}\r\n", s, hr.ToString("X8"));
        }

        private void fetchAchievementsButton_Click(object sender, EventArgs e)
        {
            if (achievements != null)
            {
                listView1.Items.Clear();
                Array.Clear(achievements, 0, achievements.Length);
            }
            LOG("Start fetching achievements");
            SDK.XBL.XblAchievementsGetAchievementsForTitleIdAsync(
                xblContextHandle,
                userId,
                TitleId,
                XblAchievementType.All,
                unlockedOnly: false,
                orderBy: XblAchievementOrderBy.DefaultOrder,
                skipItems: 0,
                maxItems: 10000,
                completionRoutine: (achievementsHresult, resultHandle) =>
                {
                    LOG("XblAchievementsGetAchievementsForTitleIdAsync", achievementsHresult);
                    Int32 getAchievementsHresult = SDK.XBL.XblAchievementsResultGetAchievements(resultHandle, out achievements);
                    

                    LOG("XblAchievementsResultGetAchievements", getAchievementsHresult);

                    XblAchievement achievement = null;
                    foreach (var ach in achievements)
                    {
                        LogAchievement(ach);
                        achievement = ach;
                        AddAchievementToListView(ach);
                    }
                });
        }

        /// <summary>
        /// HRESULT 0x80190130 if achievement is unmodified (progress set to same value)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void earnAchievementButton_Click(object sender, EventArgs e)
        {
            if (achievements == null)
            {
                LOG("Error: Can't update achievements if they have not been fetched yet");
            } else if (achievements.Length > 0)
            {

                LOG("Attempting to award 100% progress for achievement id## " + currentlySelectedAchievement.Id + " \"" + currentlySelectedAchievement.Name + "\"");
                SDK.XBL.XblAchievementsUpdateAchievementAsync(xblContextHandle, userId, currentlySelectedAchievement.Id, 100, (achievementUpdateResult) => {
                    LOG("XblAchievementsUpdateAchievementAsync result", achievementUpdateResult);
                    if (achievementUpdateResult == HTTP_E_STATUS_NOT_MODIFIED) //  0x80190130
                    {
                        LOG("Achievement #" + currentlySelectedAchievement.Id + " already earned");
                    }
                });
            } else
            {
                LOG("Error: This title has no achievements");
            }
        }

        private void solvePuzzleButton_Click(object sender, EventArgs e)
        {
            int hr = SDK.XBL.XblEventsWriteInGameEvent(
                this.xblContextHandle,
                "PuzzleSolved",
                "{ \"DifficultyLevelId\":100, \"GameplayModeId\": 1, \"MultiplayerCorrelationId\":\"multiplayer correlation id\", \"SectionId\":1 }",
                "{}");
            LOG("XblEventsWriteInGameEvent", hr);
        }

        private void getStatsButton_Click(object sender, EventArgs e)
        {
            LOG("XblUserStatisticsGetSingleUserStatisticAsync starting...");
            SDK.XBL.XblUserStatisticsGetSingleUserStatisticAsync(
                this.xblContextHandle,
                this.userId,
                SCID,
                "TotalPuzzlesSolved",
                (hr, statsResult) =>
                {
                    LOG("XblUserStatisticsGetSingleUserStatisticAsync completed", hr);
                    if (hr < 0)
                    {
                        return;
                    }
                    ValidateStatsResult(statsResult);

                    hr = XblRequestedStatistics.Create(SCID, new string[] { "TotalPuzzlesSolved" }, out XblRequestedStatistics requestedStatistics);
                    LOG("XblRequestedStatistics.Create", hr);
                    if (hr < 0)
                    {
                        return;
                    }

                    SDK.XBL.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(
                        this.xblContextHandle,
                        new ulong[] { this.userId },
                        new XblRequestedStatistics[] { requestedStatistics },
                        (multipleHr, multipleStatsResult) =>
                        {
                            LOG("XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync", hr);
                            if (hr < 0)
                            {
                                return;
                            }

                            Debug.Assert(multipleStatsResult.Length == 1);
                            foreach (var statResult in multipleStatsResult)
                            {
                                ValidateStatsResult(statResult);
                            }
                        });
                });
        }

        private void ValidateStatsResult(XblUserStatisticsResult statsResult)
        {
            Debug.Assert(statsResult.XboxUserId == this.userId, "User ID should match.");
            Debug.Assert(statsResult.ServiceConfigStatistics.Length == 1, "Length should be 1.");
            foreach (var scidStat in statsResult.ServiceConfigStatistics)
            {
                Debug.Assert(scidStat.ServiceConfigurationId == SCID, "SCID should match.");
                Debug.Assert(scidStat.Statistics.Length == 1, "Statistics length should be 1.");
                foreach (var stat in scidStat.Statistics)
                {
                    Debug.Assert(stat.StatisticName == "TotalPuzzlesSolved");
                    LOG(String.Format("{0} {1} {2}", stat.StatisticName, stat.StatisticType, stat.Value));
                }
            }
        }

        private void getLeaderboardButton_Click(object sender, EventArgs e)
        {
            int hresult = XblLeaderboardQuery.Create(
                    this.userId,
                    SCID,
                    "TotalPuzzlesSolvedLB",
                    "TotalPuzzesSolved",
                    XblSocialGroupType.None,
                    new string[] { "TotalPuzzlesSolved" },
                    XblLeaderboardSortOrder.Descending,
                    maxItems: 1,
                    skipToXboxUserId: 0,
                    skipResultToRank: 0,
                    continuationToken: null,
                    queryType: XblLeaderboardQueryType.UserStatBacked,
                    leaderboardQuery: out XblLeaderboardQuery query);

            LOG("XblLeaderboardQuery.Create", hresult);
            if (hresult < 0)
            {
                return;
            }

            LOG("XblLeaderboardGetLeaderboardAsync started...");
            SDK.XBL.XblLeaderboardGetLeaderboardAsync(this.xblContextHandle, query, DumpLeaderboardAndGetNext);
        }

        private void DumpLeaderboardAndGetNext(int hresult, XblLeaderboardResult leaderboardResult)
        {
            LOG("XblLeaderboardGetLeaderboardAsync/XblLeaderboardResultGetNextAsync completed.", hresult);
            if (hresult < 0)
            {
                return;
            }

            LOG($"Leaderboard result: {leaderboardResult.TotalRowCount} total rows, {leaderboardResult.Columns.Length} columns, {leaderboardResult.Rows.Length} rows, hasNext={leaderboardResult.HasNext}");
            LOG("Columns:");
            foreach (var column in leaderboardResult.Columns)
            {
                LOG($"{column.StatName}, {column.StatType}");
            }

            LOG("Rows:");
            foreach (var row in leaderboardResult.Rows)
            {
                LOG(string.Join("/", new string[]
                {
                            row.Rank.ToString(),
                            row.XboxUserId.ToString(),
                            row.Gamertag,
                            row.Percentile.ToString(),
                            string.Join(":", row.ColumnValues)
                }));
            }

            if (leaderboardResult.HasNext)
            {
                LOG("XblLeaderboardResultGetNextAsync started...");
                SDK.XBL.XblLeaderboardResultGetNextAsync(
                    this.xblContextHandle,
                    leaderboardResult,
                    maxItems: 1,
                    completionRoutine: DumpLeaderboardAndGetNext);
            }
        }

        private void testSocialManagerButton_Click(object sender, EventArgs e)
        {
            int hr = SDK.XBL.XblSocialManagerAddLocalUser(this.userHandle, XblSocialManagerExtraDetailLevel.All);
            LOG("XblSocialManagerAddLocalUser", hr);

            hr = SDK.XBL.XblSocialManagerRemoveLocalUser(this.userHandle, XblSocialManagerExtraDetailLevel.All);
            LOG("XblSocialManagerRemoveLocalUser", hr);

            hr = SDK.XBL.XblSocialManagerAddLocalUser(this.userHandle, XblSocialManagerExtraDetailLevel.All);
            LOG("XblSocialManagerAddLocalUser", hr);

            hr = SDK.XBL.XblSocialManagerSetRichPresencePollingStatus(this.userHandle, shouldEnablePolling: true);
            LOG("XblSocialManagerSetRichPresencePollingStatus", hr);

            hr = SDK.XBL.XblSocialManagerGetLocalUsers(out XUserHandle[] users);
            LOG("XblSocialManagerGetLocalUsers", hr);
            Debug.Assert(users.Length == 1);

            // Not sure this is true anymore
            // foreach (var user in users)
            // {
            //     Debug.Assert(user == this.userHandle, "XUserHandle should be equal");
            // }

            hr = SDK.XBL.XblSocialManagerCreateSocialUserGroupFromFilters(
                this.userHandle,
                XblPresenceFilter.All,
                XblRelationshipFilter.Friends,
                out this.socialUserGroup);
            LOG("XblSocialManagerCreateSocialUserGroupFromFilters", hr);

            hr = SDK.XBL.XblSocialManagerCreateSocialUserGroupFromList(
                this.userHandle,
                new ulong[] { 2814636030307118 },
                out this.listUserGroup);
            LOG("XblSocialManagerCreateSocialUserGroupFromList", hr);

            hr = SDK.XBL.XblSocialManagerUpdateSocialUserGroup(this.listUserGroup, new ulong[] { 2533274853217818 });
            LOG("XblSocialManagerUpdateSocialUserGroup", hr);
        }

        private void getSocialManagerUsersButton_Click(object sender, EventArgs e)
        {
            TestGetUsers(this.socialUserGroup);
            TestGetUsers(this.listUserGroup);
        }
        
        private void TestGetUsers(XblSocialManagerUserGroupHandle userGroup)
        {
            int hr = SDK.XBL.XblSocialManagerUserGroupGetUsersTrackedByGroup(userGroup, out ulong[] trackedUsers);
            LOG("XblSocialManagerUserGroupGetUsersTrackedByGroup", hr);

            if (hr >= 0)
            {
                foreach (var u in trackedUsers)
                {
                    LOG($"{u}");
                }
            }

            {
                hr = SDK.XBL.XblSocialManagerUserGroupGetUsers(this.socialUserGroup, out XblSocialManagerUser[] xboxSocialUsers);
                LOG("XblSocialManagerUserGroupGetUsers", hr);
                if (hr >= 0)
                {
                    foreach (var user in xboxSocialUsers)
                    {
                        LogUser(user);
                    }
                }
            }
        }

        private void LogUser(XblSocialManagerUser user)
        {
            LOG($"{user.Gamertag} : {user.DisplayName}, {(user.PresenceRecord.PresenceTitleRecords.Length > 0 ? user.PresenceRecord.PresenceTitleRecords[0].PresenceText : "")}, {user.TitleHistory.HasUserPlayed}, {user.PreferredColor.PrimaryColor} " +
                $"{SDK.XBL.XblSocialManagerPresenceRecordIsUserPlayingTitle(user.PresenceRecord, TitleId)}");
        }

        private void destroySocialButton_Click(object sender, EventArgs e)
        {
            int hr = SDK.XBL.XblSocialManagerDestroySocialUserGroup(this.socialUserGroup);
            LOG("XblSocialManagerDestroySocialUserGroup", hr);
            this.socialUserGroup = null;

            hr = SDK.XBL.XblSocialManagerDestroySocialUserGroup(this.listUserGroup);
            LOG("XblSocialManagerDestroySocialUserGroup", hr);
            this.listUserGroup = null;
        }

        private void lookupErrorButton_Click(object sender, EventArgs e)
        {
            string hrstr = errorCodeTextBox.Text;
            int hr = Convert.ToInt32(hrstr, 16);
            LOG("Calling GetErrorCondition with hr", hr);
            XblErrorCondition cond = SDK.XBL.XblGetErrorCondition(hr);
            LOG(string.Format("Got back error condition {0}", cond.ToString()));
        }

        private void makeHttpCallButton_Click(object sender, EventArgs e)
        {
            // create revision number
            long revision = 0;
            long dateTime = DateTime.UtcNow.ToFileTimeUtc();
            const long dateTimeFromJan1st2015 = 130645440000000000;
            if (dateTime < dateTimeFromJan1st2015)
            {
                revision = 1; // Clock is wrong and not yet synced, so just setting revision to 1
            }
            else
            {
                long dateTimeSince2015 = dateTime - dateTimeFromJan1st2015;
                revision = dateTimeSince2015 >> 16; // divide by 2^16 to get it to sub-second range
            }

            // build stats value document
            JObject svd = new JObject();
            svd["$schema"] = "http://stats.xboxlive.com/2017-1/schema#";
            svd["previousRevision"] = 0;
            svd["revision"] = revision;
            svd["timestamp"] = DateTime.UtcNow.ToString("s") + "Z"; // ISO 8601 UTC
            svd["stats"] = new JObject();
            svd["stats"]["title"] = new JObject();
            svd["stats"]["title"]["StatOne"] = new JObject();
            svd["stats"]["title"]["StatTwo"] = new JObject();
            svd["stats"]["title"]["StatOne"]["value"] = 100;
            svd["stats"]["title"]["StatTwo"]["value"] = 16353;

            // create HTTP call
            LOG("Creating http call...");
            string url = string.Format("https://statswrite.xboxlive.com/stats/users/{0}/scids/{1}", userId, SCID);
            int hr = SDK.XBL.XblHttpCallCreate(xblContextHandle, "POST", url, out httpCall);
            LOG("Created call", hr);
            SDK.XBL.XblHttpCallRequestSetHeader(httpCall, "Content-Type", "application/json; charset=utf-8", true);
            SDK.XBL.XblHttpCallRequestSetHeader(httpCall, "Accept-Language", "en-US,en", true);
            SDK.XBL.XblHttpCallRequestSetHeader(httpCall, "x-xbl-contract-version", "4", true);
            SDK.XBL.XblHttpCallRequestSetRequestBodyString(httpCall, svd.ToString());

            LOG("Performing http call...");
            SDK.XBL.XblHttpCallPerformAsync(httpCall, XblHttpCallResponseBodyType.String, httpCallCompleted);
        }

        private void httpCallCompleted(int hresult)
        {
            LOG("Call completed", hresult);
            if (hresult >= 0)
            {
                SDK.XBL.XblHttpCallGetStatusCode(httpCall, out uint statusCode);
                LOG(string.Format("Http call response code {0}", statusCode));
            }
            SDK.XBL.XblHttpCallCloseHandle(httpCall);
        }
    }
}
