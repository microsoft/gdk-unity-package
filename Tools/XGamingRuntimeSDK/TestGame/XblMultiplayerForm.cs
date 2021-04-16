using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class XblMultiplayerForm : Form
    {
        private const string SCID = "00000000-0000-0000-0000-000076029b4d";
        private const UInt32 TitleId = 1979882317;
        private XUserHandle userHandle = null;
        private UInt64 userId = 0;
        private XblContextHandle xblContextHandle = null;

        private List<UInt64> xuids;

        public XblMultiplayerForm()
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
                        GetActivitiesForUsers.Enabled = true;
                        GetActivitiesForSocialGroup.Enabled = true;
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
                LOG(string.Format("Added {0} - Press 'Get Activities For Players' to get the activities for these xuids.", xuid));
            }
            else
            {
                LOG(string.Format("Could not add {0}", PlayerXuidTextBox.Text));
            }
        }

        private void GetActivitiesForUser_Click(object sender, EventArgs e)
        {
            XuidsListBox.Items.Clear();
            SDK.XBL.XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(
                xblContextHandle,
                SCID, 
                xuids.ToArray(),
                (hr, details) =>
                {
                    LOG("XblMultiplayerGetActivitiesWithPropertiesForUsersAsync", hr);

                    if (hr < 0)
                    {
                        return;
                    }

                    for (int i = 0; i < details.Length; i++)
                    {
                        LOG(string.Format("\t{0}: handle({1}) ownerXuid({2})", i, details[i].HandleId, details[i].OwnerXuid));
                    }
                });
            LOG("Calling XblMultiplayerGetActivitiesWithPropertiesForUsersAsync");
        }

        private void GetActivitiesForSocialGroup_Click(object sender, EventArgs e)
        {
            if (UInt64.TryParse(OwnerXuidTextBox.Text, out UInt64 ownerXuid))
            {
                SDK.XBL.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(
                    xblContextHandle,
                    SCID,
                    ownerXuid,
                    SocialGroupListBox.SelectedItem.ToString(),
                    (hr, details) =>
                    {
                        LOG("XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync", hr);

                        if (hr < 0)
                        {
                            return;
                        }

                        for (int i = 0; i < details.Length; i++)
                        {
                            LOG(string.Format("\t{0}: handle({1}) ownerXuid({2})", i, details[i].HandleId, details[i].OwnerXuid));
                        }
                    });
                LOG("Calling XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync");
            }
            else
            {
                LOG(string.Format("Could not add {0}", OwnerXuidTextBox.Text));
            }

        }

    }
}
