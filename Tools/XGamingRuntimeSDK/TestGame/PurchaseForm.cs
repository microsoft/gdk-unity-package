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
    public partial class PurchaseForm : Form
    {
        private XStoreContext context;

        private const string ConsumableProductId = "9PBCF37456FZ";

        public PurchaseForm(XStoreContext context)
        {
            this.context = context;
            InitializeComponent();

            this.purchaseIdTextBox.Text = ConsumableProductId;
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

        private void redeemToken_Click(object sender, EventArgs e)
        {
            LOG("Starting token redemption...");
            SDK.XStoreShowRedeemTokenUIAsync(this.context, "00000-11111-22222-33333-44444", null, false, RedeemTokenComplete);
        }

        private void RedeemTokenComplete(Int32 hresult)
        {
            LOG("Redeem token complete", hresult);
        }

        private void rateAndReview_Click(object sender, EventArgs e)
        {
            LOG("Starting rate and review...");
            SDK.XStoreShowRateAndReviewUIAsync(this.context, RateAndReviewComplete);
        }

        private void RateAndReviewComplete(Int32 hresult, bool wasUpdated)
        {
            LOG("Rate and review complete", hresult);
            LOG(String.Format("Was Updated: {0}", wasUpdated));
        }

        private void purchase_Click(object sender, EventArgs e)
        {
            LOG("Starting purchase...");
            SDK.XStoreShowPurchaseUIAsync(this.context, this.purchaseIdTextBox.Text, null, null, PurchaseComplete);
        }

        private void PurchaseComplete(Int32 hresult)
        {
            LOG("Purchase complete", hresult);
        }

        private void queryConsumable_Click(object sender, EventArgs e)
        {
            LOG("Starting query consumable...");
            SDK.XStoreQueryConsumableBalanceRemainingAsync(this.context, this.purchaseIdTextBox.Text, QueryConsumableComplete);
        }

        private void QueryConsumableComplete(Int32 hresult, UInt32 quantity)
        {
            LOG("Query consumable complete", hresult);
            LOG(String.Format("Quantity: {0}", quantity));
        }

        private void consumeConsumable_Click(object sender, EventArgs e)
        {
            LOG("Starting consume consumable...");
            if (UInt32.TryParse(this.consumeQuantityTextBox.Text, out UInt32 quantity))
            {
                SDK.XStoreReportConsumableFulfillmentAsync(this.context, this.purchaseIdTextBox.Text, quantity, Guid.NewGuid(), ConsumeConsumableComplete);
            }
        }

        private void ConsumeConsumableComplete(Int32 hresult, UInt32 quantity)
        {
            LOG("Consume consumable complete", hresult);
            LOG(String.Format("Quantity: {0}", quantity));
        }

        private void userCollectionsId_Click(object sender, EventArgs e)
        {
            LOG("Starting get user collections id...");
            // TODO: Generate a valid AAD ticket
            string collectionsServiceTicket = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhCeGw5bUFlNmd4YXZDa2NvT1UyVEhzRE5hMCIsImtpZCI6IkhCeGw5bUFlNmd4YXZDa2NvT1UyVEhzRE5hMCJ9.eyJhdWQiOiJodHRwczovL29uZXN0b3JlLm1pY3Jvc29mdC5jb20vYjJiL2tleXMvY3JlYXRlL2NvbGxlY3Rpb25zIiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvMjc4NjZlYmQtOTA2NS00ZmI0LWI1ZmEtMGZiZTI3YTRlMDRiLyIsImlhdCI6MTU1NjU3MDgyMCwibmJmIjoxNTU2NTcwODIwLCJleHAiOjE1NTY1NzQ3MjAsImFpbyI6IjQyWmdZSERzbS9xNDh0ZXFMNmRmblBqWSsvV1NLZ0E9IiwiYXBwaWQiOiI1YWZkNTU0Ni05NzQ2LTRmMzktYTYwYy01NGMwZjNiYWU5ZjkiLCJhcHBpZGFjciI6IjEiLCJpZHAiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC8yNzg2NmViZC05MDY1LTRmYjQtYjVmYS0wZmJlMjdhNGUwNGIvIiwib2lkIjoiMDI0MjY4OWUtZWQ3Yy00NDdjLWE4ODEtYWFjNjU1ZDM5ZjAxIiwic3ViIjoiMDI0MjY4OWUtZWQ3Yy00NDdjLWE4ODEtYWFjNjU1ZDM5ZjAxIiwidGlkIjoiMjc4NjZlYmQtOTA2NS00ZmI0LWI1ZmEtMGZiZTI3YTRlMDRiIiwidXRpIjoiNlplY0RTbWRlMHVNeFR3TEtieGdBQSIsInZlciI6IjEuMCJ9.HLrnGARWM4qb0TyNLKLEZPm5sgZV0FVIEAExVwNUlsxOuI4SKMbZM43EdMvI6x37dXZr62a_K1K0L_-2sDUKqlQjAhX9fS_3GVW6PmLOJ4pnqPw5YOKSVi0Vt60nSRttlvaDEIP6T8x1gYVCqGUMFV1NYtqbLSDnxnSQhRNPmtUC4kNirDNhVb-80C1uprjg7RNRHaWCpcR1xYV_YaMpX6ktp8AcIGICP7nHYMjV9LTmhBSxvHmBOs7xyMydkdAR0jbChV1-rB5HaoAyXFA0b6lO3YOongBjdBxicBVC81BVmbZQNJbHNqnbUQVVvNkoVuehTUos-Qg6hQVSzZj6Xg";
            SDK.XStoreGetUserCollectionsIdAsync(this.context, collectionsServiceTicket, "example@contoso.com", UserCollectionsIdComplete);
        }

        private void UserCollectionsIdComplete(Int32 hresult, string token)
        {
            LOG("User collections id complete", hresult);
            LOG(String.Format("Token: {0}", token));
        }

        private void userPurchaseId_Click(object sender, EventArgs e)
        {
            LOG("Starting get user purchase id...");
            // TODO: Generate a valid AAD ticket
            string purchaseServiceTicket = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhCeGw5bUFlNmd4YXZDa2NvT1UyVEhzRE5hMCIsImtpZCI6IkhCeGw5bUFlNmd4YXZDa2NvT1UyVEhzRE5hMCJ9.eyJhdWQiOiJodHRwczovL29uZXN0b3JlLm1pY3Jvc29mdC5jb20vYjJiL2tleXMvY3JlYXRlL3B1cmNoYXNlIiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvMjc4NjZlYmQtOTA2NS00ZmI0LWI1ZmEtMGZiZTI3YTRlMDRiLyIsImlhdCI6MTU1NjU3MTIwNSwibmJmIjoxNTU2NTcxMjA1LCJleHAiOjE1NTY1NzUxMDUsImFpbyI6IjQyWmdZSGp2ZTFmSnovbjdzdEx6TTgwblgxbklEQUE9IiwiYXBwaWQiOiI1YWZkNTU0Ni05NzQ2LTRmMzktYTYwYy01NGMwZjNiYWU5ZjkiLCJhcHBpZGFjciI6IjEiLCJpZHAiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC8yNzg2NmViZC05MDY1LTRmYjQtYjVmYS0wZmJlMjdhNGUwNGIvIiwib2lkIjoiMDI0MjY4OWUtZWQ3Yy00NDdjLWE4ODEtYWFjNjU1ZDM5ZjAxIiwic3ViIjoiMDI0MjY4OWUtZWQ3Yy00NDdjLWE4ODEtYWFjNjU1ZDM5ZjAxIiwidGlkIjoiMjc4NjZlYmQtOTA2NS00ZmI0LWI1ZmEtMGZiZTI3YTRlMDRiIiwidXRpIjoid28yRnRrdHZlVWVrQ0l2WjBheGxBQSIsInZlciI6IjEuMCJ9.MHrQSuI3z6t6hzkMAe92Cz5rTUqHp4qTNODtnoL9aEBYTNDqdzX2SJEurWFjgw1S7aRJhI4hUdunQ9lIZtbO8i-0i_qGVhFNWF83TyyU3tpleA9bqzc-PBcEScCwUHh1sxB3U77ObPoK5Z72c8STuf7-MJVMn0oYkn08oyW-ILWVZuZ--UnCzujwQc4kIImtEKpCYWc2KToKoZnW0ZZrsv-9xHOEIyocBm-peeAjmmxXNHwbpjm-v4w7k8ZEIusi5p0pH35FeGm4wN9hHvmLpg4_BmwWFZ-mosUuwAPmlR0Qi8Z6lMgumxD3D5qfr7IhXvRt8TyDf9HWH7NrLUcNlw";
            SDK.XStoreGetUserPurchaseIdAsync(this.context, purchaseServiceTicket, "example@contoso.com", UserPurchaseIdComplete);
        }

        private void UserPurchaseIdComplete(Int32 hresult, string token)
        {
            LOG("User purchase id complete", hresult);
            LOG(String.Format("Token: {0}", token));
        }
    }
}
