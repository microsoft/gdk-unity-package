using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class UserForm : Form
    {
        private List<XUserHandle> userHandles = new List<XUserHandle>();
        private XRegistrationToken registrationToken = null;
        private XUserSignOutDeferralHandle signoutDeferralHandle = null;
        private StringBuilder logText = new StringBuilder();
        private bool hasLogText = false;

        public UserForm()
        {
            InitializeComponent();
            this.statusTimer.Start();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (this.hasLogText)
            {
                this.hasLogText = false;
                this.log.Text = this.logText.ToString();
                this.log.AppendText(" ");
            }

            // pump runtime callbacks on UI thread
            SDK.XTaskQueueDispatch();
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

        private void UpdateCurrentUser(Int32 index)
        {
            SDK.XUserGetMaxUsers(out UInt32 maxUsers);
            this.maxUsers.Text = maxUsers.ToString();

            XUserHandle user = this.userHandles[index];
            Int32 hr = SDK.XUserGetGamertag(user, XUserGamertagComponent.UniqueModern, out string gamertag);
            LOG("XUserGetGamerTag", hr);
            this.gamertag.Text = gamertag;

            hr = SDK.XUserGetId(user, out UInt64 userId);
            LOG("XUserGetId", hr);
            this.id.Text = userId.ToString();

            hr = SDK.XUserGetLocalId(user, out XUserLocalId userLocalId);
            LOG("XUserGetLocalId", hr);
            this.localId.Text = userLocalId.value.ToString();

            hr = SDK.XUserGetAgeGroup(user, out XUserAgeGroup userAgeGroup);
            LOG("XUserGetAgeGroup", hr);
            this.ageGroup.Text = userAgeGroup.ToString();
            
            hr = SDK.XUserGetIsGuest(user, out bool isGuest);
            LOG("XUserGetIsGuest", hr);
            this.isGuest.Text = isGuest.ToString();

            this.privileges.Items.Clear();
            this.disallowedPrivileges.Items.Clear();
            foreach (var enumValue in Enum.GetValues(typeof(XUserPrivilege)))
            {
                XUserPrivilege xUserPrivilege = (XUserPrivilege)enumValue;
                hr = SDK.XUserCheckPrivilege(user, XUserPrivilegeOptions.None, xUserPrivilege, out bool hasPrivilege, out XUserPrivilegeDenyReason reason);
                LOG(string.Format("XUserCheckPrivilege({0})", Enum.GetName(typeof(XUserPrivilege), enumValue)), hr);
                if (hasPrivilege)
                {
                    this.privileges.Items.Add(Enum.GetName(typeof(XUserPrivilege), enumValue));
                }
                else
                {
                    this.disallowedPrivileges.Items.Add(Enum.GetName(typeof(XUserPrivilege), enumValue));
                }
            }

            SDK.XUserGetGamerPictureAsync(user, XUserGamerPictureSize.Small, (hresult, pngBuffer) =>
            {
                LOG("XUserGetGamerPictureAsync Completed...", hresult);
                if (hresult >= 0 && pngBuffer != null)
                {
                    this.gamerpic.Image = Image.FromStream(new MemoryStream(pngBuffer));
                }
                else
                {
                    this.gamerpic.Image = SystemIcons.Error.ToBitmap();
                }
            });
            LOG("XUserGetGamerPictureAsync Started...");
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            XUserAddOptions options = XUserAddOptions.None;
            foreach (var index in this.addUserOptions.SelectedIndices)
            {
                options |= (XUserAddOptions)Enum.Parse(typeof(XUserAddOptions), this.addUserOptions.Items[(Int32)index].ToString());
            }
            LOG(String.Format("Starting AddUser({0})...", Enum.GetName(typeof(XUserAddOptions), options)));
            SDK.XUserAddAsync(options, (Int32 hresult, XUserHandle userHandle) =>
            {
                LOG("AddUser complete", hresult);
                if (hresult == 0)
                {
                    this.userHandles.Add(userHandle);
                    this.signedInUsers.Items.Add(this.userHandles.Count.ToString());
                }
            });
        }

        private void signedInUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (signedInUsers.SelectedIndex >= 0)
            {
                this.UpdateCurrentUser(signedInUsers.SelectedIndex);
            }
        }

        private void closeUserHandle_Click(object sender, EventArgs e)
        {
            if (this.signedInUsers.SelectedIndex >= 0)
            {
                Int32 selectedIndex = signedInUsers.SelectedIndex;
                SDK.XUserCloseHandle(this.userHandles[selectedIndex]);
                LOG("XUserCloseHandle");
                this.signedInUsers.Items.RemoveAt(selectedIndex);
                this.userHandles.RemoveAt(selectedIndex);
            }
        }

        private void resolveIssue_Click(object sender, EventArgs e)
        {
            if (this.signedInUsers.SelectedIndex >= 0)
            {
                Int32 selectedIndex = signedInUsers.SelectedIndex;
                 SDK.XUserResolveIssueWithUiUtf16Async(this.userHandles[selectedIndex], null, (hr) =>
                {
                    LOG("XUserResolveIssueWithUi Completed", hr);
                });
                LOG("Starting XUserResolveIssueWithUi...");
            }
        }

        private void resolveButton_Click(object sender, EventArgs e)
        {
            if (this.disallowedPrivileges.SelectedIndex >= 0 && this.signedInUsers.SelectedIndex >= 0)
            {
                Int32 selectedIndex = this.signedInUsers.SelectedIndex;
                string selectedPrivilege = this.disallowedPrivileges.SelectedItem as string;
                XUserPrivilege privilege = (XUserPrivilege)Enum.Parse(typeof(XUserPrivilege), selectedPrivilege);
                SDK.XUserResolvePrivilegeWithUiAsync(this.userHandles[this.signedInUsers.SelectedIndex], XUserPrivilegeOptions.None, privilege, (Int32 hresult) =>
                {
                    LOG(string.Format("XUserResolvePrivilegeWithUiAsync({0}) completed.", privilege), hresult);
                    if (this.signedInUsers.SelectedIndex == selectedIndex)
                    {
                        this.UpdateCurrentUser(selectedIndex);
                    }
                });
                LOG(string.Format("Starting XUserResolvePrivilegeWithUiAsync({0})...", privilege));
            }
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            if (this.signedInUsers.SelectedIndex >= 0)
            {
                Int32 hr = SDK.XUserGetState(this.userHandles[this.signedInUsers.SelectedIndex], out XUserState state);
                if (hr < 0)
                {
                    LOG("XUserGetState failed", hr);
                }
                else
                {
                    this.status.Text = state.ToString();
                }
            }
        }

        private void registerForEvent_Click(object sender, EventArgs e)
        {
            Int32 hr = SDK.XUserRegisterForChangeEvent((localId, eventType) =>
            {
                LOG(string.Format("ChangeEvent: {0}, {1}", eventType, localId.value));

                if (eventType == XUserChangeEvent.SigningOut && this.deferSignOut.Checked)
                {
                    // Try to get a deferral
                    Int32 hresult = SDK.XUserGetSignOutDeferral(out this.signoutDeferralHandle);
                    LOG("XUserGetSignOutDeferral", hresult);
                }
            }, out this.registrationToken);
            LOG("XUserRegisterForChangeEvent", hr);
        }

        private void unregisterForEvent_Click(object sender, EventArgs e)
        {
            SDK.XUserUnregisterForChangeEvent(this.registrationToken);
            this.registrationToken = null;
        }

        private void deferSignOut_CheckedChanged(object sender, EventArgs e)
        {
            if (this.signoutDeferralHandle != null)
            {
                Int32 hresult = SDK.XUserCloseSignOutDeferralHandle(this.signoutDeferralHandle);
                LOG("XUserCloseSignOutDeferralHandle", hresult);
                this.signoutDeferralHandle = null;
            }
        }

        private void findLocal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.findId.Text) && UInt64.TryParse(this.findId.Text, out UInt64 localId))
            {
                Int32 hresult = SDK.XUserFindUserByLocalId(new XUserLocalId(localId), out XUserHandle handle);
                LOG("XUserFindUserByLocalId", hresult);
                if (hresult >= 0)
                {
                    this.userHandles.Add(handle);
                    this.signedInUsers.Items.Add(this.userHandles.Count.ToString());
                    this.signedInUsers.SelectedIndex = this.userHandles.Count - 1;
                }
            }
        }

        private void findXuid_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.findId.Text) && UInt64.TryParse(this.findId.Text, out UInt64 xuid))
            {
                Int32 hresult = SDK.XUserFindUserById(xuid, out XUserHandle handle);
                LOG("XUserFindUserById", hresult);
                if (hresult >= 0)
                {
                    this.userHandles.Add(handle);
                    this.signedInUsers.Items.Add(this.userHandles.Count.ToString());
                    this.signedInUsers.SelectedIndex = this.userHandles.Count - 1;
                }
            }
        }

        private void duplicateUserHandle_Click(object sender, EventArgs e)
        {
            if (this.signedInUsers.SelectedIndex >= 0)
            {
                Int32 hresult = SDK.XUserDuplicateHandle(this.userHandles[this.signedInUsers.SelectedIndex], out XUserHandle duplicatedHandle);
                LOG("XUserDuplicateHandle", hresult);
                this.userHandles.Add(duplicatedHandle);
                this.signedInUsers.Items.Add(this.userHandles.Count.ToString());
                this.signedInUsers.SelectedIndex = this.userHandles.Count - 1;
            }
        }

        private void compareHandle_Click(object sender, EventArgs e)
        {
            if (this.signedInUsers.SelectedIndex >= 1)
            {
                Int32 hresult = SDK.XUserCompare(this.userHandles[this.signedInUsers.SelectedIndex - 1], this.userHandles[this.signedInUsers.SelectedIndex], out Int32 comparisonResult);
                LOG(String.Format("XUserCompare => {0}", comparisonResult), hresult);
            }
        }

        private void getTokenAndSignatureButton_Click(object sender, EventArgs e)
        {
            if (this.signedInUsers.SelectedIndex >= 0)
            {
                XUserGetTokenAndSignatureUtf16HttpHeader[] headers = new XUserGetTokenAndSignatureUtf16HttpHeader[2];
                headers[0] = new XUserGetTokenAndSignatureUtf16HttpHeader("X-Header1", "Value1");
                headers[1] = new XUserGetTokenAndSignatureUtf16HttpHeader("X-Header2", "Value2");

                Byte[] body = null;
                if (!string.IsNullOrEmpty(getTokenAndSignatureBody.Text))
                {
                    body = System.Text.Encoding.UTF8.GetBytes(getTokenAndSignatureBody.Text);
                }

                SDK.XUserGetTokenAndSignatureUtf16Async(this.userHandles[this.signedInUsers.SelectedIndex], XUserGetTokenAndSignatureOptions.None, getTokenAndSignatureMethod.Text, getTokenAndSignatureUrl.Text, headers, body, (hr, data) =>
                {
                    LOG("XUserGetTokenAndSignatureUtf16Async completed", hr);
                    if (data != null)
                    {
                        LOG($"Token: {data.Token}\r\nSignature: {data.Signature}");
                    }
                });
                LOG("XUserGetTokenAndSignatureUtf16Async started...");
            }
        }
    }
}
