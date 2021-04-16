using System;
using System.Linq;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class LicenseForm : Form
    {
        private XStoreContext context;
        private XStoreLicense license;
        private XRegistrationToken gameLicenseChanged;
        private XRegistrationToken packageLicenseLost;

        public LicenseForm(XStoreContext context)
        {
            this.context = context;
            InitializeComponent();
            SetLicense(null);
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
            textBox1.AppendText(string.Format("{0} -- hresult = 0x{1}\r\n", s, hr.ToString("X8")));
        }

        private void SetLicense(XStoreLicense license)
        {
            this.license = license;
            closeLicenseHandle.Enabled = isLicenseValid.Enabled = registerPackageLicenseLost.Enabled = (license != null);
            acquireLicenseForPackage.Enabled = (license == null);
        }

        private void acquireLicenseForPackage_Click(object sender, EventArgs e)
        {
            LOG("Starting acquire license for package...");
            SDK.XPackageGetCurrentProcessPackageIdentifier(out string gamePackageIdentifier);
            LOG(string.Format("gamePackageIdentifier: {0}", gamePackageIdentifier));
            SDK.XStoreAcquireLicenseForPackageAsync(this.context, gamePackageIdentifier, AcquireForPackageComplete);
        }

        private void AcquireForPackageComplete(Int32 hresult, XStoreLicense license)
        {
            LOG("Acquire license for package complete", hresult);
            SetLicense(license);
        }

        private void canAcquireLicenseForPackage_Click(object sender, EventArgs e)
        {
            LOG("Starting can acquire license for package...");
            SDK.XPackageGetCurrentProcessPackageIdentifier(out string gamePackageIdentifier);
            LOG(string.Format("gamePackageIdentifier: {0}", gamePackageIdentifier));
            SDK.XStoreCanAcquireLicenseForPackageAsync(this.context, gamePackageIdentifier, CanAcquireLicenseForPackageComplete);
        }

        private void CanAcquireLicenseForPackageComplete(Int32 hresult, XStoreCanAcquireLicenseResult result)
        {
            LOG("Can acquire license for package complete", hresult);
            LOG(string.Format("Result LicensableSku: {0}, Status: {1}", result?.LicensableSku, result?.Status));
        }

        private void canAcquireLicenseForStoreId_Click(object sender, EventArgs e)
        {
            LOG("Starting can acquire license for store ID...");
            SDK.XStoreQueryProductForCurrentGameAsync(this.context, CanAcquireLicenseStoreIdLookup);
        }

        private void CanAcquireLicenseStoreIdLookup(Int32 hresult, XStoreQueryResult result)
        {
            LOG("Getting store ID for current game...", hresult);

            if (hresult == 0 && result.PageItems.Length > 0)
            {
                string gameStoreId = result.PageItems[0].StoreId;
                LOG(string.Format("Got storeId: {0}", gameStoreId));
                SDK.XStoreCanAcquireLicenseForStoreIdAsync(this.context, gameStoreId, CanAcquireLicenseForStoreIdComplete);
            }
        }

        private void CanAcquireLicenseForStoreIdComplete(Int32 hresult, XStoreCanAcquireLicenseResult result)
        {
            LOG("Can acquire license for store ID complete", hresult);
            LOG(string.Format("Result LicensableSku: {0}, Status: {1}", result?.LicensableSku, result?.Status));
        }

        private void closeLicenseHandle_Click(object sender, EventArgs e)
        {
            LOG("Starting close license handle...");
            SDK.XStoreCloseLicenseHandle(this.license);
            SetLicense(null);
            LOG("Close license handle complete");
        }

        private void isLicenseValid_Click(object sender, EventArgs e)
        {
            LOG("Starting is license valid...");
            bool valid = SDK.XStoreIsLicenseValid(this.license);
            LOG("Is license valid complete");
            LOG(string.Format("Valid: {0}", valid));
        }

        private void queryAddonLicenses_Click(object sender, EventArgs e)
        {
            LOG("Starting query addon licenses...");
            SDK.XStoreQueryAddOnLicensesAsync(this.context, QueryAddonLicensesComplete);
        }

        private void QueryAddonLicensesComplete(Int32 hresult, XStoreAddonLicense[] licenses)
        {
            LOG("Query addon licenses complete", hresult);
            if (licenses?.Any() == true)
            {
                foreach (XStoreAddonLicense license in licenses)
                {
                    LOG(string.Format(
                        "Addon license SkuStoreId: {0}, InAppOfferToken: {1}, IsActive: {2}, ExpirationDate: {3}",
                        license.SkuStoreId,
                        license.InAppOfferToken,
                        license.IsActive,
                        license.ExpirationDate));
                }
            }
        }

        private void queryGameLicense_Click(object sender, EventArgs e)
        {
            LOG("Starting query game license...");
            SDK.XStoreQueryGameLicenseAsync(this.context, QueryGameLicenseComplete);
        }

        private void QueryGameLicenseComplete(Int32 hresult, XStoreGameLicense license)
        {
            LOG("Query game license complete", hresult);
            LOG(string.Format(
                "License SkuStoreId: {0}, IsActive: {1}, IsTrialOwnedByThisUser: {2}, IsDiscLicense: {3}, IsTrial: {4}, TrialTimeRemainingInSeconds: {5}, TrialUniqueId: {6}, ExpirationDate: {7}",
                license.SkuStoreId,
                license.IsActive,
                license.IsTrialOwnedByThisUser,
                license.IsDiscLicense,
                license.IsTrial,
                license.TrialTimeRemainingInSeconds,
                license.TrialUniqueId,
                license.ExpirationDate));
        }

        private void queryLicenseToken_Click(object sender, EventArgs e)
        {
            LOG("Starting query license token...");
            SDK.XStoreQueryProductForCurrentGameAsync(this.context, QueryLicenseTokenStoreIdLookup);
        }

        private void QueryLicenseTokenStoreIdLookup(Int32 hresult, XStoreQueryResult result)
        {
            LOG("Getting store ID for current game...", hresult);

            if (hresult == 0 && result.PageItems.Length > 0)
            {
                string gameStoreId = result.PageItems[0].StoreId;
                LOG(string.Format("Got storeId: {0}", gameStoreId));
                SDK.XStoreQueryLicenseTokenAsync(this.context, new string[] { gameStoreId }, "example@contoso.com", QueryLicenseTokenComplete);
            }
        }

        private void QueryLicenseTokenComplete(Int32 hresult, string token)
        {
            LOG("Query license token complete", hresult);
            LOG(string.Format("License token: {0}", token));
        }

        private void registerGameLicenseChanged_Click(object sender, EventArgs e)
        {
            LOG("Starting register game license changed...");
            SDK.XStoreRegisterGameLicenseChanged(this.context, GameLicenseChanged, out this.gameLicenseChanged);
            LOG("Register game license changed complete");

            registerGameLicenseChanged.Enabled = false;
            unregisterGameLicenseChanged.Enabled = true;
        }

        private void registerPackageLicenseLost_Click(object sender, EventArgs e)
        {
            LOG("Starting register package license lost...");
            SDK.XStoreRegisterPackageLicenseLost(this.license, PackageLicenseLost, out this.packageLicenseLost);
            LOG("Register package license lost complete");

            registerPackageLicenseLost.Enabled = false;
            unregisterPackageLicenseLost.Enabled = true;
        }

        private void unregisterGameLicenseChanged_Click(object sender, EventArgs e)
        {
            LOG("Starting unregister game license changed...");
            SDK.XStoreUnregisterGameLicenseChanged(this.context, this.gameLicenseChanged);
            LOG("Unregister game license changed complete");

            registerGameLicenseChanged.Enabled = true;
            unregisterGameLicenseChanged.Enabled = false;
        }

        private void unregisterPackageLicenseLost_Click(object sender, EventArgs e)
        {
            LOG("Starting unregister package license lost...");
            SDK.XStoreUnregisterPackageLicenseLost(this.license, this.packageLicenseLost);
            LOG("Unregister package license lost complete");

            registerPackageLicenseLost.Enabled = this.license != null;
            unregisterPackageLicenseLost.Enabled = false;
        }

        private void GameLicenseChanged()
        {
            LOG("Game license changed callback invoked");
        }

        private void PackageLicenseLost()
        {
            LOG("Package license lost callback invoked");
        }

        private void XStoreAcquireLicenseForDurablesAsync_Click(object sender, EventArgs e)
        {
            // TODO work with XStore to figure out the right storeId value
            string storeId = "";
            SDK.XStoreAcquireLicenseForDurablesAsync(context, storeId, (Int32 hresult, XStoreLicense license) =>
            {
                LOG("XStoreAcquireLicenseForDurablesAsync", hresult);
                SetLicense(license);
            });
        }
    }
}
