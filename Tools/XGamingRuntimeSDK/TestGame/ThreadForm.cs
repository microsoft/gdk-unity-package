using System;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class ThreadForm : Form
    {
        public ThreadForm()
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

        private void setTimeSensitive_Click(object sender, EventArgs e)
        {
            LOG("Setting time sensitive to true");
            int hr = SDK.XThreadSetTimeSensitive(true);
            LOG("Set time sensitive", hr);
        }

        private void setNotTimeSensitive_Click(object sender, EventArgs e)
        {
            LOG("Setting time sensitive to false");
            int hr = SDK.XThreadSetTimeSensitive(false);
            LOG("Set time sensitive", hr);
        }

        private void getIsTimeSensitive_Click(object sender, EventArgs e)
        {
            LOG("Getting is time sensitive");
            bool b = SDK.XThreadIsTimeSensitive();
            LOG(string.Format("Is time sensitive: {0}", b.ToString()));
        }

        private void assertNotTimeSensitive_Click(object sender, EventArgs e)
        {
            LOG("Asserting not time sensitive...");
            SDK.XThreadAssertNotTimeSensitive();
        }
    }
}
