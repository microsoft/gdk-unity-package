using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class Form1 : Form
    {
        //private XTaskQueue queue;
        private XStoreContext context;

        public Form1()
        {
            InitializeComponent();
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

        private void initialize_Click(object sender, EventArgs e)
        {
            LOG("Initializing XGameRuntime...");
            Int32 hr = SDK.XGameRuntimeInitialize();
            LOG("XGameRuntime initialized!", hr);

            if (hr == 0)
            {
                initialize.Enabled = false;

                createStoreContext.Enabled = true;
                userAPIs.Enabled = true;
                gamesaveButton.Enabled = true;
                xboxLiveApis.Enabled = true;
                gameUiButton.Enabled = true;
                xblPresenceApis.Enabled = true;
                getTitleId.Enabled = true;
                threadApis.Enabled = true;
                accessibilityApis.Enabled = true;
                xblPrivacyAPIs.Enabled = true;
                xblProfileBtn.Enabled = true;
                xblMpmApis.Enabled = true;
                xblMpaApis.Enabled = true;
                xblMpApis.Enabled = true;
            }
        }

        private void createStoreContext_Click(object sender, EventArgs e)
        {
            LOG("Creating store context...");
            Int32 hr = SDK.XStoreCreateContext(out this.context);
            LOG("Context created!", hr);

            if (hr == 0)
            {
                createStoreContext.Enabled = false;

                purchaseAPIs.Enabled = true;
                queryButton.Enabled = true;
                packageAPIs.Enabled = true;
                licenseAPIs.Enabled = true;
            }
        }

        private void purchaseAPIs_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm(this.context);
            purchaseForm.ShowDialog();
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            QueriesForm f = new QueriesForm(this.context);
            f.ShowDialog();
        }

        private void packageAPIs_Click(object sender, EventArgs e)
        {
            PackageForm f = new PackageForm(this.context);
            f.ShowDialog();
        }

        private void userAPIs_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }

        private void gamesaveButton_Click(object sender, EventArgs e)
        {
            GameSaveForm f = new GameSaveForm();
            f.ShowDialog();
        }

        private void licenseAPIs_Click(object sender, EventArgs e)
        {
            LicenseForm f = new LicenseForm(this.context);
            f.ShowDialog();
        }

        private void xboxLiveApis_Click(object sender, EventArgs e)
        {
            XboxLiveForm xblForm = new XboxLiveForm();
            xblForm.ShowDialog();
        }

        private void gameUiButton_Click(object sender, EventArgs e)
        {
            GameUIForm gameUIForm = new GameUIForm();
            gameUIForm.ShowDialog();
        }

        private void xblPresenceApis_Click(object sender, EventArgs e)
        {
            PresenceForm f = new PresenceForm();
            f.ShowDialog();
        }

        private void getTitleId_Click(object sender, EventArgs e)
        {
            int hr = SDK.XGameGetXboxTitleId(out uint titleId);
            LOG(string.Format("XGameGetXboxTitleId completed: {0}", titleId), hr);
        }

        private void threadApis_Click(object sender, EventArgs e)
        {
            ThreadForm f = new ThreadForm();
            f.ShowDialog();
        }

        private void accessibilityApis_Click(object sender, EventArgs e)
        {
            AccessibilityForm f = new AccessibilityForm();
            f.ShowDialog();
        }

        private void xblPrivacyAPIs_Click(object sender, EventArgs e)
        {
            PrivacyForm f = new PrivacyForm();
            f.ShowDialog();
        }

        private void xblMpmApis_Click(object sender, EventArgs e)
        {
            MultiplayerManagerForm f = new MultiplayerManagerForm();
            f.ShowDialog();
        }

        private void xblMpaApis_Click(object sender, EventArgs e)
        {
            MultiplayerActivityForm f = new MultiplayerActivityForm();
            f.ShowDialog();
        }

        private void xblMpApis_Click(object sender, EventArgs e)
        {
            XblMultiplayerForm f = new XblMultiplayerForm();
            f.ShowDialog();
        }

        private void xblProfileBtn_Click(object sender, EventArgs e)
        {
            XblProfileForm f = new XblProfileForm();
            f.ShowDialog();
        }
    }
}
