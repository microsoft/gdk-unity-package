using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class MultiplayerActivityForm : Form
    {
        private const string SCID = "00000000-0000-0000-0000-000076029b4d";
        private const UInt32 TitleId = 1979882317;
        private XUserHandle userHandle = null;
        private UInt64 userId = 0;
        private XblContextHandle xblContextHandle = null;

        private List<XblMultiplayerActivityRecentPlayerUpdate> pendingRecentPlayers;

        public MultiplayerActivityForm()
        {
            InitializeComponent();

            pendingRecentPlayers = new List<XblMultiplayerActivityRecentPlayerUpdate>();

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

                    if (hr >= 0)
                    {
                        UpdateRecentPlayers.Enabled = true;
                        FlushRecentPlayers.Enabled = true;
                        AddRecentPlayerXuid.Enabled = true;

                        SetActivity.Enabled = true;
                        GetActivities.Enabled = true;
                        DeleteActivity.Enabled = true;

                        SendInvite.Enabled = true;
                    }
                }
            });
        }
        private void LOG(string s)
        {
            textBox1.AppendText(s + "\r\n");
        }

        private void LOG(string s, Int32 hr)
        {
            textBox1.AppendText(String.Format("{0} -- hresult = 0x{1}\r\n", s, hr.ToString("X8")));
        }

        private void UpdateRecentPlayers_Click(object sender, EventArgs e)
        {
            PendingRecentPlayersListBox.Items.Clear();
            int hr = SDK.XBL.XblMultiplayerActivityUpdateRecentPlayers(xblContextHandle, pendingRecentPlayers.ToArray());
            pendingRecentPlayers.Clear();
            LOG("XblMultiplayerActivityUpdateRecentPlayers", hr);
        }

        private void FlushRecentPlayers_Click(object sender, EventArgs e)
        {
            SDK.XBL.XblMultiplayerActivityFlushRecentPlayersAsync(xblContextHandle, (hr) =>
            {
                LOG("XblMultiplayerActivityFlushRecentPlayersAsync", hr);
            });
        }

        private void AddRecentPlayerXuid_Click(object sender, EventArgs e)
        {
            if (UInt64.TryParse(RecentPlayerXuidTextBox.Text, out UInt64 xuid))
            {
                XblMultiplayerActivityRecentPlayerUpdate recentplayer = new XblMultiplayerActivityRecentPlayerUpdate()
                {
                    Xuid = xuid,
                    EncounterType = (XblMultiplayerActivityEncounterType)Enum.Parse(typeof(XblMultiplayerActivityEncounterType), EncounterTypeListBox.SelectedItem.ToString())
                };
                pendingRecentPlayers.Add(recentplayer);
                PendingRecentPlayersListBox.Items.Add(string.Format("{0} {1}", recentplayer.Xuid, recentplayer.EncounterType.ToString()));
                LOG(string.Format("Added {0} {1} - Press 'Update Recent Players' to update the MPA service.", recentplayer.Xuid, recentplayer.EncounterType.ToString()));
            }
            else
            {
                LOG(string.Format("Could not add {0}", RecentPlayerXuidTextBox.Text));
            }
        }

        private void SetActivity_Click(object sender, EventArgs e)
        {
            var activity = new XblMultiplayerActivityInfo()
            {
                ConnectionString = "dummyConnectionAddress",
                JoinRestriction = XblMultiplayerActivityJoinRestriction.Followed,
                MaxPlayers = 10,
                CurrentPlayers = 1,
                GroupId = "dummyGroupId"
            };

            SDK.XBL.XblMultiplayerActivitySetActivityAsync(xblContextHandle, activity, true, (hr) =>
            {
                LOG("XblMultiplayerActivitySetActivityAsync", hr);
            });
        }

        private void GetActivities_Click(object sender, EventArgs e)
        {
            List<UInt64> xuids = new List<UInt64>();
            xuids.Add(userId);
            SDK.XBL.XblMultiplayerActivityGetActivityAsync(xblContextHandle, xuids.ToArray(), (hr, activityInfos) =>
            {
                LOG("XblMultiplayerActivityGetActivityAsync", hr);

                if (hr < 0)
                {
                    return;
                }

                foreach (var info in activityInfos)
                {
                    LOG(string.Format("Info for {0}\n\tConnectionString: {1}\n\tCurrentPlayers: {2}\n\tGroupId: {3}\n\tJoinRestriction: {4}\n\tMaxPlayers: {5}\n\tPlatform: {6}",
                        info.Xuid,
                        info.ConnectionString,
                        info.CurrentPlayers,
                        info.GroupId,
                        info.JoinRestriction,
                        info.MaxPlayers,
                        info.Platform.ToString()));
                }
            });
        }

        private void DeleteActivity_Click(object sender, EventArgs e)
        {
            SDK.XBL.XblMultiplayerActivityDeleteActivityAsync(xblContextHandle, (hr) =>
            {
                LOG("XblMultiplayerActivityDeleteActivityAsync", hr);
            });
        }

        private void SendInvite_Click(object sender, EventArgs e)
        {
            if (UInt64.TryParse(XuidToInviteTextBox.Text, out UInt64 xuid))
            {
                List<UInt64> xuids = new List<UInt64>();
                xuids.Add(xuid);
                SDK.XBL.XblMultiplayerActivitySendInvitesAsync(xblContextHandle, xuids.ToArray(), true, (hr) =>
                {
                    LOG("XblMultiplayerActivitySendInvitesAsync", hr);
                });
            }
            else
            {
                LOG(string.Format("Could not parse {0} as a xuid", XuidToInviteTextBox.Text));
            }
        }
    }
}
