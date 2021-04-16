using System;
using System.Linq;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class PresenceForm : Form
    {
        private const string SCID = "00000000-0000-0000-0000-000076029b4d";
        private const UInt32 TitleId = 750323071;
        private const string SocialGroupPeople = "People";

        private XblContextHandle xblContextHandle = null;
        private XblPresenceRecordHandle xblPresenceRecordHandle = null;

        private XblPresenceRecordHandle XblPresenceRecordHandle
        {
            get
            {
                return xblPresenceRecordHandle;
            }

            set
            {
                xblPresenceRecordHandle = value;
                getPresence.Enabled = value == null;
                getPresenceForMultipleUsers.Enabled = value == null;
                getPresenceForSocialGroup.Enabled = value == null;
                duplicateHandle.Enabled = value != null;
                closeHandle.Enabled = value != null;
                getXuid.Enabled = value != null;
                getUserState.Enabled = value != null;
                getDeviceRecords.Enabled = value != null;
            }
        }

        public PresenceForm()
        {
            InitializeComponent();

            Int32 hr = SDK.XBL.XblInitialize(SCID);
            LOG("XblInitialize", hr);

            SDK.XUserAddAsync(XUserAddOptions.AddDefaultUserAllowingUI, (hresult, user) =>
            {
                LOG("XUserAddAsync", hresult);

                hresult = SDK.XBL.XblContextCreateHandle(user, out xblContextHandle);
                LOG("XblContextCreateHandle", hresult);

                hresult = SDK.XUserGetId(user, out UInt64 xuid);
                LOG("XUserGetId", hresult);

                xuids.Text = xuid.ToString();
                titleIds.Text = TitleId.ToString();
            });
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            SDK.XTaskQueueDispatch();
        }

        private UInt64 GetXuid()
        {
            return GetXuids().FirstOrDefault();
        }

        private UInt64[] GetXuids()
        {
            if (!string.IsNullOrEmpty(xuids.Text))
            {
                string[] split = xuids.Text.Split(',');
                if (split?.Length > 0)
                {
                    return Array.ConvertAll(split, x => Convert.ToUInt64(x));
                }
            }
            return new UInt64[0];
        }

        private UInt32[] GetTitleIds()
        {
            if (!string.IsNullOrEmpty(titleIds.Text))
            {
                string[] split = titleIds.Text.Split(',');
                if (split?.Length > 0)
                {
                    return Array.ConvertAll(split, x => Convert.ToUInt32(x));
                }
            }
            return new UInt32[0];
        }

        private void LOG(string s)
        {
            textBox1.AppendText(s + "\r\n");
        }

        private void LOG(string s, Int32 hr)
        {
            textBox1.AppendText(String.Format("{0} -- hresult = 0x{1}\r\n", s, hr.ToString("X8")));
        }

        private void getPresence_Click(object sender, EventArgs e)
        {
            LOG("Start get presence");
            SDK.XBL.XblPresenceGetPresenceAsync(xblContextHandle, GetXuid(), (hresult, record) =>
            {
                XblPresenceRecordHandle = record;
                LOG("Get presence complete", hresult);
            });
        }

        private void getPresenceForMultipleUsers_Click(object sender, EventArgs e)
        {
            LOG("Start get presence for multiple users");
            Int32 hr = XblPresenceQueryFilters.Create(
                new XblPresenceDeviceType[] { XblPresenceDeviceType.XboxOne },
                GetTitleIds(),
                XblPresenceDetailLevel.All,
                false,
                false,
                out XblPresenceQueryFilters filters);
            LOG("Create XblPresenceQueryFilters completed", hr);
            if (hr >= 0)
            {
                SDK.XBL.XblPresenceGetPresenceForMultipleUsersAsync(xblContextHandle, GetXuids(), filters, (hresult, records) =>
                {
                    XblPresenceRecordHandle = records.FirstOrDefault();
                    LOG("Get presence for multiple users complete", hresult);
                });
            }
        }

        private void getPresenceForSocialGroup_Click(object sender, EventArgs e)
        {
            LOG("Start get presence for social group");
            Int32 hr = XblPresenceQueryFilters.Create(
                new XblPresenceDeviceType[] { XblPresenceDeviceType.XboxOne },
                new UInt32[] { TitleId },
                XblPresenceDetailLevel.All,
                false,
                false,
                out XblPresenceQueryFilters filters);
            LOG("Create XblPresenceQueryFilters completed", hr);
            if (hr >= 0)
            {
                SDK.XBL.XblPresenceGetPresenceForSocialGroupAsync(xblContextHandle, SocialGroupPeople, GetXuid(), filters, (hresult, records) =>
                {
                    XblPresenceRecordHandle = records.FirstOrDefault();
                    LOG("Get presence for multiple users complete", hresult);
                });
            }
        }

        private void setPresence_Click(object sender, EventArgs e)
        {
            LOG("Start set presence");
            Int32 hr = XblPresenceRichPresenceIds.Create(SCID, string.Empty, new string[] { }, out XblPresenceRichPresenceIds richPresenceIds);
            LOG("Create XblPresenceRichPresenceIds completed", hr);
            if (hr >= 0)
            {
                SDK.XBL.XblPresenceSetPresenceAsync(xblContextHandle, false, richPresenceIds, (hresult) =>
                {
                    LOG("Set presence completed", hresult);
                });
            }
        }

        private void duplicateHandle_Click(object sender, EventArgs e)
        {
            LOG("Start duplicate handle");
            Int32 hr = SDK.XBL.XblPresenceRecordDuplicateHandle(XblPresenceRecordHandle, out XblPresenceRecordHandle duplicatedHandle);
            SDK.XBL.XblPresenceRecordCloseHandle(duplicatedHandle);
            LOG("Duplicate handle complete", hr);
        }

        private void closeHandle_Click(object sender, EventArgs e)
        {
            LOG("Start close handle");
            SDK.XBL.XblPresenceRecordCloseHandle(XblPresenceRecordHandle);
            XblPresenceRecordHandle = null;
            LOG("Close handle complete");
        }

        private void getXuid_Click(object sender, EventArgs e)
        {
            LOG("Start get XUID");
            Int32 hr = SDK.XBL.XblPresenceRecordGetXuid(XblPresenceRecordHandle, out ulong xuid);
            LOG($"XUID: {xuid}");
            LOG("Get XUID complete", hr);
        }

        private void getUserState_Click(object sender, EventArgs e)
        {
            LOG("Start get user state");
            Int32 hr = SDK.XBL.XblPresenceRecordGetUserState(XblPresenceRecordHandle, out XblPresenceUserState userState);
            LOG($"Value: {userState}");
            LOG("Get user state complete", hr);
        }

        private void getDeviceRecords_Click(object sender, EventArgs e)
        {
            LOG("Start get device records");
            Int32 hr = SDK.XBL.XblPresenceRecordGetDeviceRecords(XblPresenceRecordHandle, out XblPresenceDeviceRecord[] deviceRecords);
            if (deviceRecords != null)
            {
                foreach (XblPresenceDeviceRecord deviceRecord in deviceRecords)
                {
                    LOG($"DeviceType: {deviceRecord.DeviceType}");
                    if (deviceRecord.TitleRecords != null)
                    {
                        foreach (XblPresenceTitleRecord titleRecord in deviceRecord.TitleRecords)
                        {
                            LOG($"TitleId: {titleRecord.TitleId} TitleName: {titleRecord.TitleName} LastModified: {titleRecord.LastModified} TitleActive: {titleRecord.TitleActive} RichPresenceString: {titleRecord.RichPresenceString} ViewState: {titleRecord.ViewState}");
                            if (titleRecord.BroadcastRecord != null)
                            {
                                LOG($"BroadcastId: {titleRecord.BroadcastRecord.BroadcastId} Session: {titleRecord.BroadcastRecord.Session} Provider: {titleRecord.BroadcastRecord.Provider} ViewerCount: {titleRecord.BroadcastRecord.ViewerCount} StartTime: {titleRecord.BroadcastRecord.StartTime}");
                            }
                        }
                    }
                }
            }
            LOG("Get device records complete", hr);
        }
    }
}
