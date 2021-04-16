using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class AccessibilityForm : Form
    {
        private bool enabled = true;
        private XSpeechToTextType type = XSpeechToTextType.Text;
        private XSpeechToTextPositionHint hint = XSpeechToTextPositionHint.BottomCenter;
        private uint hypothesisId;

        public AccessibilityForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            SDK.XTaskQueueDispatch();
        }

        private void LOG(string s)
        {
            textBox1.AppendText(s + "\r\n");
        }

        private void LOG(string s, Int32 hr)
        {
            textBox1.AppendText(string.Format("{0} -- hresult = 0x{1}\r\n", s, hr.ToString("X8")));
        }

        private T GetNextEnumValue<T>(T value)
        {
            List<T> values = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            int index = values.FindIndex(x => x.Equals(value));
            return values[(index + 1) % values.Count];
        }

        private void setEnabled_Click(object sender, EventArgs e)
        {
            LOG("Starting set enabled");
            LOG($"Enabled: {enabled}");
            Int32 hr = SDK.XClosedCaptionSetEnabled(enabled);
            enabled = !enabled;
            LOG("Set enabled complete", hr);
        }

        private void getProperties_Click(object sender, EventArgs e)
        {
            LOG("Starting get properties");
            Int32 hr = SDK.XClosedCaptionGetProperties(out XClosedCaptionProperties properties);
            LOG($"BackgroundColor: {properties.BackgroundColor.Value} FontColor: {properties.FontColor.Value} WindowColor: {properties.WindowColor.Value} FontEdgeAttribute: {properties.FontEdgeAttribute} FontStyle: {properties.FontStyle} FontScale: {properties.FontScale} Enabled: {properties.Enabled}");
            LOG("Get properties complete", hr);
        }

        private void highContrastGetMode_Click(object sender, EventArgs e)
        {
            LOG("Starting high contrast get mode");
            Int32 hr = SDK.XHighContrastGetMode(out XHighContrastMode mode);
            LOG($"Mode: {mode}");
            LOG("High contrast get mode complete", hr);
        }

        private void speechToTextSendString_Click(object sender, EventArgs e)
        {
            LOG("Starting speech to text send string");
            LOG($"XSpeechToTextType: {type}");
            Int32 hr = SDK.XSpeechToTextSendString("Test Speaker", "Test content", type);
            type = GetNextEnumValue(type);
            LOG("Speech to text send string complete", hr);
        }

        private void speechToTextSetPositionHint_Click(object sender, EventArgs e)
        {
            LOG("Starting speech to text set position hint");
            LOG($"XSpeechToTextPositionHint: {hint}");
            Int32 hr = SDK.XSpeechToTextSetPositionHint(hint);
            hint = GetNextEnumValue(hint);
            LOG("Speech to text set position hint complete", hr);
        }
        private void XSpeechToTextBeginHypothesisString_Click(object sender, EventArgs e)
        {
            Int32 hr = SDK.XSpeechToTextBeginHypothesisString("speakerName", "content", XSpeechToTextType.Text, out hypothesisId);
            LOG($"XSpeechToTextBeginHypothesisString", hr);
        }

        private void XSpeechToTextUpdateHypothesisString_Click(object sender, EventArgs e)
        {
            Int32 hr = SDK.XSpeechToTextUpdateHypothesisString(hypothesisId, "content");
            LOG($"XSpeechToTextUpdateHypothesisString", hr);
        }
                private void XSpeechToTextFinalizeHypothesisString_Click(object sender, EventArgs e)
        {
            Int32 hr = SDK.XSpeechToTextFinalizeHypothesisString(hypothesisId, "content");
            LOG($"XSpeechToTextFinalizeHypothesisString", hr);
        }

        private void XSpeechToTextCancelHypothesisString_Click(object sender, EventArgs e)
        {
            Int32 hr = SDK.XSpeechToTextCancelHypothesisString(hypothesisId);
            LOG($"XSpeechToTextCancelHypothesisString", hr);
        }
    }
}
