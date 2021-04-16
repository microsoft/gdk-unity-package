using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class GameUIForm : Form
    {
        private const UInt32 TitleId = 0x000076029B4D;
        private XUserHandle userHandle;

        public GameUIForm()
        {
            InitializeComponent();

            launchUriButton.Enabled = false;
            showAchievementsButton.Enabled = false;

            defaultBtnCombo.Items.Clear();
            cancelBtnCombo.Items.Clear();
            foreach (XGameUiMessageDialogButton btn in Enum.GetValues(typeof(XGameUiMessageDialogButton)))
            {
                defaultBtnCombo.Items.Add(btn);
                cancelBtnCombo.Items.Add(btn);
            }

            defaultBtnCombo.SelectedIndex = 0;
            cancelBtnCombo.SelectedIndex = 1;

            notificationPosititionCombo.Items.Clear();
            foreach (XGameUiNotificationPositionHint hint in Enum.GetValues(typeof(XGameUiNotificationPositionHint)))
            {
                notificationPosititionCombo.Items.Add(hint);
            }

            notificationPosititionCombo.SelectedIndex = 0;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // pump runtime callbacks on UI thread
            SDK.XTaskQueueDispatch();
        }

        private void LOG(string s)
        {
            textBox1.AppendText(s + "\r\n");
        }

        private void LOG(string s, Int32 hr)
        {
            textBox1.AppendText(String.Format("{0} -- hresult = 0x{1}\r\n", s, hr.ToString("X8")));
        }

        private void GetUserHandleButton_Click(object sender, EventArgs e)
        {
            LOG("Trying to sign in silently.");
            SDK.XUserAddAsync(XUserAddOptions.AddDefaultUserAllowingUI, XUserAddCompleted);
        }

        private void XUserAddCompleted(Int32 hresult, XUserHandle userHandle)
        {
            LOG("Attempt to sign in silently complete", hresult);
            if (hresult == 0)
            {
                this.userHandle = userHandle;

                launchUriButton.Enabled = true;
                showAchievementsButton.Enabled = true;
            }
            else
            {
                LOG("Need to sign in explicitly to get a default user. Use the User API tests to do that.");
            }
        }

        private void launchUriButton_Click(object sender, EventArgs e)
        {
            string uri = uriTextBox.Text;
            LOG(string.Format("Launching uri {0}...", uri));
            int hr = SDK.XLaunchUri(this.userHandle, uri);
            LOG("Launch URI complete", hr);
        }

        private void showAchievementsButton_Click(object sender, EventArgs e)
        {
            LOG("Showing achivements...");
            SDK.XGameUiShowAchievementsAsync(this.userHandle, TitleId, ShowAchievementsCompleted);
        }

        private void ShowAchievementsCompleted(int hresult)
        {
            LOG("Show achievements completed", hresult);
        }

        private void showErrorDialogButton_Click(object sender, EventArgs e)
        {
            int hr = Convert.ToInt32(errorCodeTextBox.Text, 16);
            LOG(string.Format("Showing dialog for error {0}", hr.ToString("X8")));
            SDK.XGameUiShowErrorDialogAsync(hr, null, ShowErrorDialogCompleted);
        }

        private void ShowErrorDialogCompleted(int hresult)
        {
            LOG("Show error dialog completed", hresult);
        }

        private void showDialogButton_Click(object sender, EventArgs e)
        {
            LOG("Showing message dialog...");
            SDK.XGameUiShowMessageDialogAsync(
                titleTextBox.Text,
                contentTextBox.Text,
                firstBtnTextBox.Text,
                secondBtnTextBox.Text,
                thirdBtnTextBox.Text,
                (XGameUiMessageDialogButton)defaultBtnCombo.SelectedItem,
                (XGameUiMessageDialogButton)cancelBtnCombo.SelectedItem,
                ShowMessageDialogCompleted);
        }

        private void ShowMessageDialogCompleted(int hresult, XGameUiMessageDialogButton resultButton)
        {
            LOG(string.Format("Show message dialog completed with button {0}", resultButton.ToString()), hresult);
        }

        private void showTextEntryDialog_Click(object sender, EventArgs e)
        {
            LOG("Showing text entry dialog...");
            SDK.XGameUiShowTextEntryAsync(
                "title text",
                "description text",
                "default text",
                XGameUiTextEntryInputScope.Alphanumeric,
                20,
                ShowTextEntryDialogCompleted);
        }

        private void ShowTextEntryDialogCompleted(Int32 hresult, string resultText)
        {
            LOG(string.Format("Show text entry dialog completed, returned '{0}'", resultText), hresult);
        }

        private void showWebAuth_Click(object sender, EventArgs e)
        {
            LOG("Showing web auth...");
            SDK.XGameUIShowWebAuthenticationAsync(
                this.userHandle,
                startUriTextBox.Text,
                endUriTextBox.Text,
                ShowWebAuthCompleted);
        }

        public void ShowWebAuthCompleted(int result, XGameUiWebAuthenticationResultData data)
        {
            LOG("Web auth completed", result);
            LOG("responseStatus: " + data.responseStatus);
            LOG("responseCompletionUriSize: " + data.responseCompletionUriSize);
            LOG("responseCompletionUri: " + data.responseCompletionUri);
        }

        private void showPlayerCard_Click(object sender, EventArgs e)
        {
            int hr = SDK.XUserGetId(this.userHandle, out UInt64 userId);

            if (hr != 0)
            {
                LOG("XUserGetId failed", hr);
            }

            LOG("Showing player profile card...");
            SDK.XGameUiShowPlayerProfileCardAsync(
                this.userHandle,
                userId,
                ShowPlayerProfileCardCompleted);
        }

        public void ShowPlayerProfileCardCompleted(int result)
        {
            LOG("Player profile card completed", result);
        }

        private void showPlayerPickerButton_Click(object sender, EventArgs e)
        {
            LOG("Showing player picker...");

            if (!UInt32.TryParse(minCountTextBox.Text, out uint minCount) || !UInt32.TryParse(maxCountTextBox.Text, out uint maxCount))
            {
                LOG("Unable to parse max/min count");
                return;
            }

            var playersList = new List<UInt64>();

            TryAddXuid(xuid1TextBox, ref playersList);
            TryAddXuid(xuid2TextBox, ref playersList);
            TryAddXuid(xuid3TextBox, ref playersList);

            if (playersList.Count == 0)
            {
                LOG("No XUIDs found, exiting");
                return;
            }

            var preselectedPlayers = new ulong[] { playersList[0] };

            SDK.XGameUiShowPlayerPickerAsync(
                this.userHandle,
                "prompt text",
                playersList.ToArray(),
                preselectedPlayers,
                minCount,
                maxCount,
                ShowPlayerPickerCompleted);
        }

        private void TryAddXuid(TextBox xuidTextBox, ref List<UInt64> playersList)
        {
            UInt64 xuid;
            if (UInt64.TryParse(xuidTextBox.Text, out xuid))
            {
                playersList.Add(xuid);
            }
            else
            {
                LOG("Failed to parse XUID in " + xuidTextBox.Name);
            }
        }

        public void ShowPlayerPickerCompleted(int result, UInt64[] selected)
        {
            int count = selected.Length;

            string m = "Completed, returned: [";
            for (int i = 0; i < count; i++)
            {
                m += selected[i].ToString();
                if (i != count - 1)
                {
                    m += ", ";
                }
            }

            m += "]";

            LOG(m, result);
        }

        private void showNotificationPositionButton_Click(object sender, EventArgs e)
        {
            var pos = (XGameUiNotificationPositionHint)notificationPosititionCombo.SelectedItem;
            LOG("Setting notification position to " + pos);
            int hr = SDK.XGameUiSetNotificationPositionHint(pos);
            LOG("Completed", hr);
        }
    }
}
