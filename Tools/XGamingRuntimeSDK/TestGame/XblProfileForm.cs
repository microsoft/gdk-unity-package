using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class XblProfileForm : Form
    {
        private const string SCID = "00000000-0000-0000-0000-000076029b4d";
        private const UInt32 TitleId = 1979882317;
        private XUserHandle userHandle = null;
        private UInt64 userId = 0;
        private XblContextHandle xblContextHandle = null;

        private List<UInt64> xuids;

        public XblProfileForm()
        {
            InitializeComponent();

            xuids = new List<UInt64>();

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
                        GetUserProfiles.Enabled = true;
                        GetUserProfile.Enabled = true;
                        GetSocialUserProfiles.Enabled = true;
                        AddPlayerXuid.Enabled = true;
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

        private void AddPlayerXuid_Click(object sender, EventArgs e)
        {
            if (UInt64.TryParse(PlayerXuidTextBox.Text, out UInt64 xuid))
            {
                xuids.Add(xuid);
                XuidsListBox.Items.Add(xuid);
                LOG(string.Format("Added {0}", xuid));
            }
            else
            {
                LOG(string.Format("Could not add {0}", PlayerXuidTextBox.Text));
            }
        }

        private void GetUserProfiles_Click(object sender, EventArgs e)
        {
            SDK.XBL.XblProfileGetUserProfilesAsync(
                xblContextHandle,
                xuids.ToArray(),
                (hr, users) =>
                {
                    LOG("XblProfileGetUserProfilesAsync", hr);

                    if (hr < 0)
                    {
                        return;
                    }

                    for (int i = 0; i < users.Length; i++)
                    {
                        LOG(string.Format("\t{0}: gamerTag({1}) xuid({2})", i, users[i].Gamertag, users[i].XboxUserId));
                    }
                });
            LOG("Calling XblProfileGetUserProfilesAsync");
        }

        private void GetUserProfile_Click(object sender, EventArgs e)
        {
            if (UInt64.TryParse(XuidsListBox.SelectedItem.ToString(), out UInt64 xuid))
            {
                SDK.XBL.XblProfileGetUserProfileAsync(
                    xblContextHandle,
                    xuid,
                    (hr, profile) =>
                    {
                        LOG("XblProfileGetUserProfileAsync", hr);

                        if (hr < 0)
                        {
                            return;
                        }

                        LOG(string.Format("\tgamerTag({0}) xuid({1})", profile.Gamertag, profile.XboxUserId));
                    });
                LOG("Calling XblProfileGetUserProfileAsync for " + xuid);
            }
            else
            {
                LOG(string.Format("Could not add {0}", XuidsListBox.SelectedItem.ToString()));
            }

        }

        private void GetSocialUserProfiles_Click(object sender, EventArgs e)
        {
            SDK.XBL.XblProfileGetUserProfilesForSocialGroupAsync(
                xblContextHandle,
                SocialGroupListBox.SelectedItem.ToString(),
                (hr, users) =>
                {
                    LOG("XblProfileGetUserProfilesForSocialGroupAsync", hr);

                    if (hr < 0)
                    {
                        return;
                    }

                    for (int i = 0; i < users.Length; i++)
                    {
                        LOG(string.Format("\t{0}: gamerTag({1}) xuid({2})", i, users[i].Gamertag, users[i].XboxUserId));
                    }
                });
            LOG("Calling XblProfileGetUserProfilesForSocialGroupAsync for " + SocialGroupListBox.SelectedItem.ToString());
        }
    }
}
