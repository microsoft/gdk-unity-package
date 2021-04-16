using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class PrivacyForm : Form
    {
        private const string SCID = "00000000-0000-0000-0000-000076029b4d";
        private const UInt32 TitleId = 750323071;
        private const string SocialGroupPeople = "People";
        private XUserHandle userHandle = null;
        private UInt64 userId = 0;

        private XblContextHandle xblContextHandle = null;

        public PrivacyForm()
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
            });

            // populate permissions list
            foreach (XblPermission perm in Enum.GetValues(typeof(XblPermission)))
            {
                permissionsList.Items.Add(perm);
            }
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
            textBox1.AppendText(String.Format("{0} -- hresult = 0x{1}\r\n", s, hr.ToString("X8")));
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

        private void checkPermissionsButton_Click(object sender, EventArgs e)
        {
            var xuids = GetXuids();
            var perms = permissionsList.SelectedItems;

            if (xuids.Length == 1 && perms.Count == 1)
            {
                checkSinglePermission(xuids[0], (XblPermission)perms[0]);
            }
            else
            {
                bulkCheckPermissions(xuids, perms.Cast<XblPermission>().ToArray());
            }
        }

        private void checkSinglePermission(ulong xuid, XblPermission permission)
        {
            SDK.XBL.XblPrivacyCheckPermissionAsync(xblContextHandle, permission, xuid, checkSinglePermissionCompleted);
        }

        private void checkSinglePermissionCompleted(int hresult, XblPermissionCheckResult result)
        {
            LOG("CheckSinglePermissionCompleted", hresult);
            if (hresult >= 0)
            {
                PrintPermissionCheck(result);
            }
        }

        private void bulkCheckPermissions(ulong[] xuids, XblPermission[] perms)
        {
            var userTypes = new XblAnonymousUserType[]
            {
                XblAnonymousUserType.CrossNetworkFriend,
                XblAnonymousUserType.CrossNetworkUser
            };

            SDK.XBL.XblPrivacyBatchCheckPermissionAsync(xblContextHandle, perms, xuids, userTypes, bulkCheckPermissionsCompleted);
        }

        private void bulkCheckPermissionsCompleted(int hresult, XblPermissionCheckResult[] results)
        {
            LOG("BulkCheckPermissionsCompleted", hresult);
            if (hresult >= 0)
            {
                foreach(var result in results)
                {
                    PrintPermissionCheck(result);
                }
            }
        }

        private void PrintPermissionCheck(XblPermissionCheckResult result)
        {
            LOG(string.Format("Permission {0} for xuid {1}, anonymousUserType {2}", result.PermissionRequested, result.TargetXuid, result.TargetUserType.ToString()));
            LOG(string.Format("  Allowed: {0}", result.IsAllowed));
            if (result.Reasons.Length >= 0)
            {
                foreach(var reason in result.Reasons)
                {
                    LOG(string.Format("  DenyReason: {0}", reason.Reason));
                }
            }
        }

        private void getMuteListButton_Click(object sender, EventArgs e)
        {
            SDK.XBL.XblPrivacyGetMuteListAsync(xblContextHandle, GetMuteListCompleted);
        }

        private void GetMuteListCompleted(int hresult, ulong[] xuids)
        {
            LOG("GetMuteListCompleted", hresult);
            if (hresult >= 0)
            {
                string xuidsStr = GetXuidString(xuids);
                LOG(string.Format("Mute list: {0}", xuidsStr));
            }
        }

        private void getAvoidListButton_Click(object sender, EventArgs e)
        {
            SDK.XBL.XblPrivacyGetAvoidListAsync(xblContextHandle, GetAvoidListCompleted);
        }

        private void GetAvoidListCompleted(int hresult, ulong[] xuids)
        {
            LOG("GetAvoidListCompleted", hresult);
            if (hresult >= 0)
            {
                string xuidsStr = GetXuidString(xuids);
                LOG(string.Format("Avoid list: {0}", xuidsStr));
            }
        }

        private static string GetXuidString(ulong[] xuids)
        {
            string xuidsStr = "";
            foreach (ulong xuid in xuids)
            {
                xuidsStr += xuid.ToString() + ", ";
            }

            return xuidsStr;
        }
    }
}
