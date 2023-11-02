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
    public partial class PackageForm : Form
    {
        private XStoreContext context;
        private XRegistrationToken eventToken;
        private XPackageInstallationMonitorHandle installMonitor;
        private XRegistrationToken progressToken;

        public PackageForm(XStoreContext context)
        {
            this.context = context;
            InitializeComponent();
            packageKindCombo.Items.Clear();

            foreach (XPackageKind kind in Enum.GetValues(typeof(XPackageKind)))
            {
                packageKindCombo.Items.Add(kind);
            }

            packageKindCombo.SelectedIndex = 0;
            copyToClipboardBtn.Enabled = false;
            mountBtn.Enabled = false;
            unmountBtn.Enabled = false;
            getPathBtn.Enabled = false;
            installUnregBtn.Enabled = false;
            registerForInstallProgressButton.Enabled = false;
            updateInstallMonitorButton.Enabled = false;
            closeInstallMonitorButton.Enabled = false;
            unregisterForInstallProgressButton.Enabled = false;
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

        private void queryUpdates_Click(object sender, EventArgs e)
        {
            LOG("Starting query updates...");
            SDK.XStoreQueryGameAndDlcPackageUpdatesAsync(this.context, QueryUpdatesComplete);
        }

        private void QueryUpdatesComplete(Int32 hresult, XStorePackageUpdate[] packageUpdates)
        {
            LOG("Query updates complete", hresult);
            if (hresult == 0)
            {
                LOG(String.Format("Updates returned: {0}", packageUpdates.Length));
                foreach (var packageUpdate in packageUpdates)
                {
                    LOG(String.Format("Package Identifier: {0}   Mandatory: {1}", packageUpdate.PackageIdentifier, packageUpdate.IsMandatory));
                }
            }
        }

        private void downloadStoreId_Click(object sender, EventArgs e)
        {
            string storeId = storeIdTextBox.Text;
            LOG(string.Format("Starting download and install by storeId of {0}", storeId));
            SDK.XStoreDownloadAndInstallPackagesAsync(this.context, new string[] { storeId }, DownloadStoreIdComplete);
        }

        private void DownloadStoreIdComplete(Int32 hresult, string[] packageIdentifiers)
        {
            LOG("Download StoreId complete", hresult);
            if (hresult == 0)
            {
                LOG(String.Format("Downloads started: {0}", packageIdentifiers.Length));
                foreach (string packageIdentifier in packageIdentifiers)
                {
                    LOG(String.Format("Package Identifier: {0}", packageIdentifier));
                    packageIdTextBox.Text = packageIdentifier;
                }
            }
        }

        private void downloadUpdates_Click(object sender, EventArgs e)
        {
            LOG("Starting download update...");
            SDK.XStoreDownloadPackageUpdatesAsync(this.context, new string[] { "SOMEPACKAGEIDHERE" }, DownloadUpdateComplete);
        }

        private void DownloadUpdateComplete(Int32 hresult)
        {
            LOG("Download update complete", hresult);
        }

        private void installUpdates_Click(object sender, EventArgs e)
        {
            LOG("Starting download and install update...");
            SDK.XStoreDownloadAndInstallPackageUpdatesAsync(this.context, new string[] { "SOMEPACKAGEIDHERE" }, DownloadAndInstallComplete);
        }

        private void DownloadAndInstallComplete(Int32 hresult)
        {
            LOG("Download and install update complete", hresult);
        }

        private void queryPackageIdentifier_Click(object sender, EventArgs e)
        {
            string storeId = storeIdTextBox.Text;
            LOG(string.Format("Starting query package identifier for storeId {0}...", storeId));

            string packageIdentifier;
            Int32 hresult = SDK.XStoreQueryPackageIdentifier(storeId, out packageIdentifier);

            LOG("Query package identifier complete", hresult);
            if (hresult == 0)
            {
                LOG(String.Format("Package Identifier: {0}", packageIdentifier));
                packageIdTextBox.Text = packageIdentifier;
            }
        }

        private void getProcessPkgId_click(object sender, EventArgs e)
        {
            LOG("Starting get process package ID request...");

            string packageIdentifier;
            Int32 hresult = SDK.XPackageGetCurrentProcessPackageIdentifier(out packageIdentifier);
            LOG("Get package ID request complete", hresult);
            if (hresult >= 0)
            {
                LOG(string.Format("Package Identifier: {0}", packageIdentifier));
            }
        }

        private void getLocaleBtn_Click(object sender, EventArgs e)
        {
            LOG("Getting user locale...");
            string userLocale;
            Int32 hresult = SDK.XPackageGetUserLocale(out userLocale);
            LOG("Get userlocale complete", hresult);
            if (hresult >= 0)
            {
                LOG(string.Format("User locale: {0}", userLocale));
            }
        }

        private void getIsPackagedBtn_Click(object sender, EventArgs e)
        {
            LOG("Getting is packaged process...");
            bool ispkg = SDK.XPackageIsPackagedProcess();
            LOG(string.Format("Is packaged: {0}", ispkg));
        }

        private void enumPackagesBtn_Click(object sender, EventArgs e)
        {
            packageEnumList.Items.Clear();
            copyToClipboardBtn.Enabled = false;
            mountBtn.Enabled = false;

            XPackageKind pkgKind = (XPackageKind)packageKindCombo.SelectedItem;
            LOG(string.Format("Enumerating packages of kind {0}", pkgKind.ToString()));
            Int32 hresult = SDK.XPackageEnumeratePackages(pkgKind, XPackageEnumerationScope.ThisAndRelated, out XPackageDetails [] details);
            LOG("Enumerate complete", hresult);
            if (hresult >= 0)
            {
                foreach(XPackageDetails detail in details)
                {
                    packageEnumList.Items.Add(string.Format("{0}:{1}", detail.StoreId, detail.PackageIdentifier));
                }
            }
        }

        private void packageEnumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (packageEnumList.SelectedIndex >= 0)
            {
                copyToClipboardBtn.Enabled = true;
                mountBtn.Enabled = true;
            }
        }

        private void copyToClipboardBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(packageEnumList.SelectedItem.ToString());
        }

        private void mountBtn_Click(object sender, EventArgs e)
        {
            string item = packageEnumList.SelectedItem.ToString();
            string packageId = item.Split(':')[1];
            LOG(string.Format("Mounting package {0}", packageId));
            Int32 hresult = SDK.XPackageMountWithUiAsync(
                packageId, 
                (int hr, XPackageMountHandle mountHandle) =>
            { 
                LOG("Mount complete", hr);
                mountedPackagesList.Items.Add(new MountItem { packageId = packageId, mountHandle = mountHandle });
            });
        }

        private void mountedPackagesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mountedPackagesList.SelectedIndex >= 0)
            {
                unmountBtn.Enabled = true;
                getPathBtn.Enabled = true;
            }
        }

        private void unmountBtn_Click(object sender, EventArgs e)
        {
            MountItem mi = mountedPackagesList.SelectedItem as MountItem;
            LOG(string.Format("Unmounting package {0}", mi.packageId));
            SDK.XPackageCloseMountHandle(mi.mountHandle);
            mountedPackagesList.Items.Remove(mi);
            LOG(string.Format("Package unmounted"));

            unmountBtn.Enabled = false;
            getPathBtn.Enabled = false;
        }

        private void getPathBtn_Click(object sender, EventArgs e)
        {
            MountItem mi = mountedPackagesList.SelectedItem as MountItem;
            LOG(string.Format("Getting path for packageid {0}", mi.packageId));
            Int32 hresult = SDK.XPackageGetMountPath(mi.mountHandle, out string path);
            LOG("Get path complete", hresult);
            if (hresult >= 0)
            {
                LOG(string.Format("Package mount path: {0}", path));
            }
        }

        private void installRegBtn_Click(object sender, EventArgs e)
        {
            installRegBtn.Enabled = false;
            installUnregBtn.Enabled = true;
            LOG("Registering for install events");
            int hresult = SDK.XPackageRegisterPackageInstalled(packageInstalled, out eventToken);
            LOG("Registration complete", hresult);
        }

        private void packageInstalled(XPackageDetails details)
        {
            LOG(string.Format("Received package install notice for: {0} ({1})", details.DisplayName, details.PackageIdentifier));
        }

        private void installUnregBtn_Click(object sender, EventArgs e)
        {
            installRegBtn.Enabled = true;
            installUnregBtn.Enabled = false;
            LOG("Unregistering for install events");
            SDK.XPackageUnregisterPackageInstalled(eventToken);
            LOG("Unregistration complete");
        }

        private void estimateDownloadSizeButton_Click(object sender, EventArgs e)
        {
            string pkgId = packageIdTextBox.Text;
            LOG(string.Format("Estimating download size for package {0}", pkgId));
            int hr = SDK.XPackageEstimateDownloadSize(pkgId, out ulong downloadSize, out bool shouldPresentUserConfirmation);
            LOG("Estimating download size complete", hr);
            if (hr >= 0)
            {
                LOG(string.Format("size: {0}, shouldpresentconfirm: {1}", downloadSize, shouldPresentUserConfirmation));
            }
        }

        private void createInstallMonitorButton_Click(object sender, EventArgs e)
        {
            string pkgId = packageIdTextBox.Text;
            LOG(string.Format("Creating install monitor for package {0}", pkgId));
            int hr = SDK.XPackageCreateInstallationMonitor(pkgId, 1000, out installMonitor);
            LOG("Create install monitor complete", hr);
            if (hr >= 0)
            {
                registerForInstallProgressButton.Enabled = true;
                updateInstallMonitorButton.Enabled = true;
                closeInstallMonitorButton.Enabled = true;

                SDK.XPackageGetInstallationProgress(installMonitor, out XPackageInstallationProgress progress);
                LogProgress(progress);
            }
        }

        private void updateInstallMonitorButton_Click(object sender, EventArgs e)
        {
            LOG("Updating install monitor");
            bool updated = SDK.XPackageUpdateInstallationMonitor(installMonitor);
            LOG(string.Format("Updated: {0}", updated.ToString()));
            if (updated)
            {
                SDK.XPackageGetInstallationProgress(installMonitor, out XPackageInstallationProgress progress);
                LogProgress(progress);
            }
        }

        private void LogProgress(XPackageInstallationProgress progress)
        {
            LOG(string.Format("Completed: {0}, Launchable: {1}", progress.Completed, progress.Launchable));
            LOG(string.Format(" installBytes: {0}", progress.InstalledBytes));
            LOG(string.Format(" launchBytes: {0}", progress.LaunchBytes));
            LOG(string.Format(" totalBytes: {0}", progress.TotalBytes));
        }

        private void closeInstallMonitorButton_Click(object sender, EventArgs e)
        {
            LOG("Closing install monitor");

            if (progressToken != null)
            {
                SDK.XPackageUnregisterInstallationProgressChanged(installMonitor, progressToken);
            }

            SDK.XPackageCloseInstallationMonitorHandle(installMonitor);
            installMonitor = null;

            registerForInstallProgressButton.Enabled = false;
            updateInstallMonitorButton.Enabled = false;
            closeInstallMonitorButton.Enabled = false;
            unregisterForInstallProgressButton.Enabled = false;
        }

        private void registerForInstallProgressButton_Click(object sender, EventArgs e)
        {
            LOG("Registering for install progress");
            int hr = SDK.XPackageRegisterInstallationProgressChanged(installMonitor, InstallationProgressChanged, out progressToken);
            LOG("Registration complete", hr);
            if (hr >= 0)
            {
                unregisterForInstallProgressButton.Enabled = true;
                registerForInstallProgressButton.Enabled = false;
            }
        }

        private void InstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitor)
        {
            LOG("Received progress update!");
            SDK.XPackageGetInstallationProgress(installationMonitor, out XPackageInstallationProgress progress);
            LogProgress(progress);
        }

        private void unregisterForInstallProgressButton_Click(object sender, EventArgs e)
        {
            LOG("Unregistering for install progress");
            SDK.XPackageUnregisterInstallationProgressChanged(installMonitor, progressToken);
            registerForInstallProgressButton.Enabled = true;
            unregisterForInstallProgressButton.Enabled = false;
        }

        private void XPackageGetWriteStats_Click(object sender, EventArgs e)
        {
            int hr = SDK.XPackageGetWriteStats(out XPackageWriteStats writeStats);
            LOG("XPackageGetWriteStats", hr);
            LOG($"Write stats:\n\tBudget: {writeStats.Budget}\n\tBytesWritten: {writeStats.BytesWritten}\n\tElapsed: {writeStats.Elapsed}\n\tInterval: {writeStats.Interval}");
        }

        private void XPackageUninstallUWPInstance_Click(object sender, EventArgs e)
        {
            string packageName = "testPackageName";
            int hr = SDK.XPackageUninstallUWPInstance(packageName);
            LOG("XPackageUninstallUWPInstance", hr);
        }

        private void XPackageEnumerateFeatures_Click(object sender, EventArgs e)
        {
            string packageName = "testPackageName";
            int hr = SDK.XPackageEnumerateFeatures(packageName, out XPackageFeature[] features);
            LOG("XPackageEnumerateFeatures", hr);
            foreach (var feature in features)
            {
                LOG($"\tFeature\n\tDisplayName: {feature.DisplayName}\n\tHidden: {feature.Hidden}\n\tId: {feature.Id}\n\tTags: {feature.Tags}");
            }
        }
    }

    class MountItem
    {
        public string packageId;
        public XPackageMountHandle mountHandle;

        public override string ToString()
        {
            return packageId;
        }
    }
}
