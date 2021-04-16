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
    public partial class GameSaveForm : Form
    {
        //const char GameSaveSample_SCID[] = "00000000-0000-0000-0000-0000788e8f9c"; 
        private const string ConfigurationId = "00000000-0000-0000-0000-000060f1e26a"; // ConfigId for matching TitleId: 60F1E26A
        private const string TestContainerName = "TestContainer1";
        private const string TestBlobName = "WorldState";
        private const string TestBlobData = "WorldState DATA DATA";
        private string[] TestBlobNames = { "WorldState", "PlayerState", "PlayerInventory" };

        private XUserHandle userHandle;
        private XGameSaveProviderHandle gameSaveProviderHandle;
        private XGameSaveContainerHandle gameSaveContainerHandle;
        private XGameSaveUpdateHandle gameSaveUpdateHandle;
        private XGameSaveBlobInfo currentBlobInfo;

        public GameSaveForm()
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

        private void UpdateButtonState()
        {
            bool hasUserHandle = this.userHandle != null;
            bool hasgameSaveProvider = this.gameSaveProviderHandle != null;
            bool hasgameSaveContainer = this.gameSaveContainerHandle != null;
            bool hasgameSaveUpdater = this.gameSaveUpdateHandle != null;

            GetUserHandleButton.Enabled = !hasUserHandle;
            CloseUserHandleButton.Enabled = hasUserHandle;

            InitProviderButton.Enabled = hasUserHandle && !hasgameSaveProvider;
            InitProviderAsyncButton.Enabled = hasUserHandle && !hasgameSaveProvider;
            CloseProviderButton.Enabled = hasgameSaveProvider;

            GetRemainingQuotaButton.Enabled = hasgameSaveProvider;
            GetRemainingAsyncButton.Enabled = hasgameSaveProvider;
            EnumContainerInfoButton.Enabled = hasgameSaveProvider;

            CreateContainerButton.Enabled = hasgameSaveProvider && !hasgameSaveContainer;
            DeleteContainerButton.Enabled = hasgameSaveContainer;
            DeleteContainerAsyncButton.Enabled = hasgameSaveContainer;
            CloseContainerButton.Enabled = hasgameSaveContainer;

            GetContainerInfoButton.Enabled = hasgameSaveProvider;

            EnumByNameButton.Enabled = hasgameSaveContainer;

            EnumBlobInfoButton.Enabled = hasgameSaveContainer;
            EnumBlobByNameButton.Enabled = hasgameSaveContainer;
            ReadBlobDataButton.Enabled = hasgameSaveContainer;
            ReadBlobDataAsyncButton.Enabled = hasgameSaveContainer;

            CreateUpdateHandleButton.Enabled = hasgameSaveContainer && !hasgameSaveUpdater;
            WriteBlobToHandleButton.Enabled = hasgameSaveUpdater;
            DeleteBlobFromHandleButton.Enabled = hasgameSaveUpdater;
            SubmitUpdateHandleButton.Enabled = hasgameSaveUpdater;
            SubmitUpdateHandleAsyncButton.Enabled = hasgameSaveUpdater;
            CloseUpdateHandleButton.Enabled = hasgameSaveUpdater;
        }

        #region Provider APIs
        private void InitProviderButton_Click(object sender, EventArgs e)
        { 
            LOG("Initializing a GameSave Provider...");
            bool syncOnDemand = false;
            Int32 hr = SDK.XGameSaveInitializeProvider(
                this.userHandle,
                ConfigurationId,
                syncOnDemand,
                out this.gameSaveProviderHandle);

            LOG("XGameSaveInitializeProvider returned: ", hr);

            UpdateButtonState();
        }

        private void InitProviderAsyncButton_Click(object sender, EventArgs e)
        {
            LOG("Initializing a GameSave Provider Asynchronously...");
            bool syncOnDemand = false;
            SDK.XGameSaveInitializeProviderAsync(
                this.userHandle,
                ConfigurationId,
                syncOnDemand,
                InitProviderAsyncCompleted);
        }

        private void InitProviderAsyncCompleted(Int32 hresult, XGameSaveProviderHandle gameSaveProvider)
        {
            LOG("Init Provider Async completed: ", hresult);
            this.gameSaveProviderHandle = gameSaveProvider;

            UpdateButtonState();
        }

        private void CloseProviderButton_Click(object sender, EventArgs e)
        {
            if (this.gameSaveProviderHandle == null)
            {
                LOG("No provider instance to close. Doing nothing.");
                return;
            }

            LOG("Closing GameSave Provider...");
            SDK.XGameSaveCloseProvider(this.gameSaveProviderHandle);
            this.gameSaveProviderHandle = null;

            LOG("GameSave Provider closed.");

            UpdateButtonState();
        }
        #endregion Provider APIs

        #region User Sign In
        private void signInButton_Click(object sender, EventArgs e)
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
            }
            else
            {
                LOG("Need to sign in explicitly to get a default user. Use the User API tests to do that.");
            }

            UpdateButtonState();
        }

        private void closeUserHandleButton_Click(object sender, EventArgs e)
        {
            if (this.userHandle != null)
            {
                SDK.XUserCloseHandle(this.userHandle);
            }

            this.userHandle = null;
            LOG("User Handle closed.");


            UpdateButtonState();
        }
        #endregion User Sign In

        #region GetRemainingQuota APIs
        private void GetRemainingQuotaButton_Click(object sender, EventArgs e)
        {
            LOG("GetRemainingQuota - start.");
            Int64 remainingQuota;
            Int32 hresult= SDK.XGameSaveGetRemainingQuota(this.gameSaveProviderHandle, out remainingQuota);
            LOG("GetRemainingQuota - completed: " + remainingQuota +  ".", hresult);
        }

        private void GetRemainingAsyncButton_Click(object sender, EventArgs e)
        {
            LOG("GetRemainingQuotaAsync - start.");
            SDK.XGameSaveGetRemainingQuotaAsync(this.gameSaveProviderHandle, GetRemainingQuotaAsyncCompleted);
        }

        private void GetRemainingQuotaAsyncCompleted(Int32 hresult, Int64 remainingQuota)
        {
            LOG("GetRemainingQuotaAsync - completed: " + remainingQuota + ".", hresult);
        }
        #endregion GetRemainingQuota APIs

        #region Container APIs
        private void createContainerButton_Click(object sender, EventArgs e)
        {
            LOG("CreateContainer - start.");
            Int32 hresult = SDK.XGameSaveCreateContainer(this.gameSaveProviderHandle, TestContainerName, out this.gameSaveContainerHandle);
            LOG("CreateContainer - completed.", hresult);

            UpdateButtonState();
        }

        private void deleteContainerButton_Click(object sender, EventArgs e)
        {
            LOG("DeleteContainer - start.");
            Int32 hresult = SDK.XGameSaveDeleteContainer(this.gameSaveProviderHandle, TestContainerName);
            LOG("DeleteContainer - completed.", hresult);

            this.gameSaveContainerHandle = null;
            UpdateButtonState();
        }

        private void deleteContainerAsyncButton_Click(object sender, EventArgs e)
        {
            LOG("DeleteContainerAsync - started.");
            SDK.XGameSaveDeleteContainerAsync(this.gameSaveProviderHandle, TestContainerName, DeleteContainerAsyncCompleted);
        }

        private void DeleteContainerAsyncCompleted(Int32 hresult)
        {
            LOG("DeleteContainerAsync - completed.", hresult);

            this.gameSaveContainerHandle = null;
            UpdateButtonState();
        }

        private void closeContainer_Click(object sender, EventArgs e)
        {
            LOG("CloseContainer - start.");
            SDK.XGameSaveCloseContainer(this.gameSaveContainerHandle);
            LOG("CloseContainer - completed.");

            this.gameSaveContainerHandle = null;
            UpdateButtonState();
        }

        private void GetContainerInfoButton_Click(object sender, EventArgs e)
        {
            LOG("GetContainerInfo - start.");
            XGameSaveContainerInfo info;
            Int32 hr = SDK.XGameSaveGetContainerInfo(this.gameSaveProviderHandle, TestContainerName, out info);
            LogContainerInfo(info);
            LOG("GetContainerInfo - completed.", hr);
        }

        private void EnumContainerInfoButton_Click(object sender, EventArgs e)
        {
            LOG("Enumerate ContainerInfo - start.");
            XGameSaveContainerInfo[] infos;
            Int32 hr = SDK.XGameSaveEnumerateContainerInfo(this.gameSaveProviderHandle, out infos);
            foreach (XGameSaveContainerInfo info in infos)
            {
                LogContainerInfo(info);
            }
            LOG("Enumerate ContainerInfo - completed.", hr);
        }

        private void EnumByNameButton_Click(object sender, EventArgs e)
        {
            LOG("Enumerate ContainerInfo By Name - start.");
            XGameSaveContainerInfo[] infos;
            Int32 hr = SDK.XGameSaveEnumerateContainerInfoByName(this.gameSaveProviderHandle, TestContainerName, out infos);
            foreach (XGameSaveContainerInfo info in infos)
            {
                LogContainerInfo(info);
            }
            LOG("Enumerate ContainerInfo By Name - completed.", hr);
        }

        private void LogContainerInfo(XGameSaveContainerInfo info)
        {
            if (info == null)
            {
                LOG("WARNING: ContainerInfo is null.");
            }
            else
            {
                LOG("ContainerInfo details:");
                LOG("  Name: " + info.Name);
                LOG("  DisplayName: " + info.DisplayName);
                LOG("  BlobCount: " + info.BlobCount);
                LOG("  TotalSize: " + info.TotalSize);
                LOG("  LastModifiedTime: " + info.LastModifiedTime);
            }
        }
        #endregion Container APIs

        #region Blob APIs
        private void EnumBlobInfoButton_Click(object sender, EventArgs e)
        {
            LOG("Enumerate Blob Infos - start.");
            XGameSaveBlobInfo[] blobInfos = null;
            Int32 hr = SDK.XGameSaveEnumerateBlobInfo(this.gameSaveContainerHandle, out blobInfos);
            LogBlobInfos(blobInfos);
            LOG("Enumerate Blob Infos - complete.", hr);
        }

        private void EnumBlobByNameButton_Click(object sender, EventArgs e)
        {
            LOG("Enumerate Blob Infos By Name - start.");
            XGameSaveBlobInfo[] blobInfos = null;
            Int32 hr = SDK.XGameSaveEnumerateBlobInfoByName(this.gameSaveContainerHandle, TestContainerName, out blobInfos);
            LogBlobInfos(blobInfos);
            LOG("Enumerate Blob Infos By Name - complete.", hr);
        }

        private void LogBlobInfos(XGameSaveBlobInfo[] infos)
        {
            if (infos != null)
            {
                foreach (XGameSaveBlobInfo info in infos)
                {
                    LogBlobInfo(info);
                }
            }
        }

        private void LogBlobInfo(XGameSaveBlobInfo info)
        {
            if (info == null)
            {
                LOG("WARNING:  XGameSaveBlobInfo info is null.");
            }
            else
            {
                LOG("BlobInfo details:");
                LOG("  Name: " + info.Name);
                this.currentBlobInfo = info;
            }
        }

        private void ReadBlobDataButton_Click(object sender, EventArgs e)
        {
            XGameSaveBlobInfo[] blobInfos = new XGameSaveBlobInfo[] { this.currentBlobInfo };
            XGameSaveBlob[] blobs = null;

            LOG("Read Blob Data - start.");
            Int32 hresult = SDK.XGameSaveReadBlobData(
                this.gameSaveContainerHandle,
                blobInfos,
                out blobs);
            LogBlobData(blobs);
            LOG("Read Blob Data - end.", hresult);
        }

        private void ReadBlobDataAsyncButton_Click(object sender, EventArgs e)
        {
            LOG("Read Blob Data Async - start.");
            SDK.XGameSaveReadBlobDataAsync(
                this.gameSaveContainerHandle,
                new string[] { TestBlobName },
                ReadBlobDataAsyncCompleted);
        }

        private void ReadBlobDataAsyncCompleted(Int32 hresult, XGameSaveBlob[] blobsData)
        {
            LogBlobData(blobsData);
            LOG("Read Blob Data Async - completed.", hresult);
        }

        private void LogBlobData(XGameSaveBlob[] blobs)
        {
            if (blobs != null)
            {
                foreach (XGameSaveBlob blob in blobs)
                {
                    LOG("Blob Data: ");
                    LogBlobInfo(blob.Info);
                    LOG("Blob Data has this count: " + blob.Data.Length);
                }
            }
        }

        #endregion Blob APIs

        #region Update APIs
        private void WriteBlobToHandleButton_Click(object sender, EventArgs e)
        {
            LOG("XGameSaveSubmitBlobWrite - start.");
            Byte[] testData = System.Text.Encoding.UTF8.GetBytes(TestBlobData);
            Int32 hr = SDK.XGameSaveSubmitBlobWrite(this.gameSaveUpdateHandle, TestBlobName, testData);
            LOG("XGameSaveSubmitBlobWrite - complete.", hr);
        }

        private void CreateUpdateHandleButton_Click(object sender, EventArgs e)
        {
            LOG("XGameSaveCreateUpdate - start.");
            Int32 hr = SDK.XGameSaveCreateUpdate(this.gameSaveContainerHandle, TestContainerName, out this.gameSaveUpdateHandle);
            LOG("XGameSaveCreateUpdate - complete.", hr);

            UpdateButtonState();
        }

        private void DeleteBlobFromHandleButton_Click(object sender, EventArgs e)
        {
            LOG("XGameSaveSubmitBlobDelete - start.");
            Int32 hr = SDK.XGameSaveSubmitBlobDelete(this.gameSaveUpdateHandle, TestBlobName);
            LOG("XGameSaveSubmitBlobDelete - complete.", hr);
        }

        private void SubmitUpdateHandleButton_Click(object sender, EventArgs e)
        {
            LOG("XGameSaveSubmitUpdate - start.");
            Int32 hr = SDK.XGameSaveSubmitUpdate(this.gameSaveUpdateHandle);
            LOG("XGameSaveSubmitUpdate - complete.", hr);
        }

        private void SubmitUpdateHandleAsyncButton_Click(object sender, EventArgs e)
        {
            LOG("XGameSaveSubmitUpdateAsync - start.");
            SDK.XGameSaveSubmitUpdateAsync(this.gameSaveUpdateHandle, SubmitUpdateCompletionRoutine);
        }

        private void SubmitUpdateCompletionRoutine(Int32 hresult)
        {
            LOG("XGameSaveSubmitUpdateAsync - complete.", hresult);
        }

        private void CloseUpdateHandleButton_Click(object sender, EventArgs e)
        {
            LOG("XGameSaveCloseUpdateHandle - start.");
            SDK.XGameSaveCloseUpdateHandle(this.gameSaveUpdateHandle);
            LOG("XGameSaveCloseUpdateHandle - complete.");

            this.gameSaveUpdateHandle = null;
            UpdateButtonState();
        }
        #endregion Update APIs
    }
}
