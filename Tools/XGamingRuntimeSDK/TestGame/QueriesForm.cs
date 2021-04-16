using System;
using System.Windows.Forms;
using XGamingRuntime;

namespace TestGame
{
    public partial class QueriesForm : Form
    {
        XStoreContext context = null;

        public QueriesForm(XStoreContext storeContext)
        {
            InitializeComponent();
            this.context = storeContext;
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

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            UInt32 pageSize = (UInt32)numericUpDown1.Value;
            XStoreProductKind productKinds = XStoreProductKind.Game | XStoreProductKind.Durable | XStoreProductKind.Consumable | XStoreProductKind.UnmanagedConsumable;
            LOG("Calling QueryAssociatedProductsAsync");
            SDK.XStoreQueryAssociatedProductsAsync(context, productKinds, pageSize, XStoreQueryCompleted);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            UInt32 pageSize = (UInt32)numericUpDown1.Value;
            XStoreProductKind productKinds = XStoreProductKind.Game | XStoreProductKind.Durable | XStoreProductKind.Consumable | XStoreProductKind.UnmanagedConsumable;
            LOG("Calling QueryEntitledProductsAsync");
            SDK.XStoreQueryEntitledProductsAsync(context, productKinds, pageSize, XStoreQueryCompleted);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            LOG("Calling QueryProductForCurrentGameAsync");
            SDK.XStoreQueryProductForCurrentGameAsync(context, XStoreQueryCompleted);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XStoreProductKind productKinds = XStoreProductKind.Game | XStoreProductKind.Durable | XStoreProductKind.Consumable | XStoreProductKind.UnmanagedConsumable;
            string packageId = packageIdTextBox.Text;
            LOG(string.Format("Calling QueryProductForPackageAsync with packageId {0}", packageId));
            SDK.XStoreQueryProductForPackageAsync(context, productKinds, packageId, XStoreQueryCompleted);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XStoreProductKind productKinds = XStoreProductKind.Game | XStoreProductKind.Durable | XStoreProductKind.Consumable | XStoreProductKind.UnmanagedConsumable;
            string[] ids = idsTextBox.Text.Split(',');
            string[] filters = filtersTextBox.Text.Split(',');
            LOG(string.Format("Calling QueryProductsAsync with {0} ids and {1} filters", ids.Length, filters.Length));
            SDK.XStoreQueryProductsAsync(context, productKinds, ids, filters, XStoreQueryCompleted);
        }

        private void XStoreQueryCompleted(Int32 hr, XStoreQueryResult result)
        {
            LOG("Query completed", hr);
            if (hr >= 0)
            {
                LOG(string.Format("{0} results, hasMorePages: {1}", result.PageItems.Length, result.HasMorePages));

                foreach (XStoreProduct p in result.PageItems)
                {

                    listBox1.Items.Add(string.Format("{0}: {1}", p.StoreId, p.Title));
                }

                label3.Text = listBox1.Items.Count.ToString();

                if (result.HasMorePages)
                {
                    SDK.XStoreProductsQueryNextPageAsync(result, (nextHr, nextResult) =>
                    {
                        SDK.XStoreCloseProductsQueryHandle(result);
                        this.XStoreQueryCompleted(nextHr, nextResult);
                    });
                }
            }
        }

        private void copyToClipboardButton_Click(object sender, EventArgs e)
        {
            string accumulator = string.Empty;
            foreach(var item in listBox1.SelectedItems)
            {
                accumulator += item.ToString() + "\n";
            }

            Clipboard.SetText(accumulator);
        }
    }
}
