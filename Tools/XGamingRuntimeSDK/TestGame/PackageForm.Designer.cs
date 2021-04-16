using System;

namespace TestGame
{
    partial class PackageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.downloadUpdates = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.installUpdates = new System.Windows.Forms.Button();
            this.downloadStoreId = new System.Windows.Forms.Button();
            this.queryUpdates = new System.Windows.Forms.Button();
            this.queryPackageIdentiifer = new System.Windows.Forms.Button();
            this.getProcessPkgidBtn = new System.Windows.Forms.Button();
            this.getLocaleBtn = new System.Windows.Forms.Button();
            this.getIsPackagedBtn = new System.Windows.Forms.Button();
            this.packageEnumList = new System.Windows.Forms.ListBox();
            this.enumPackagesBtn = new System.Windows.Forms.Button();
            this.packageKindCombo = new System.Windows.Forms.ComboBox();
            this.copyToClipboardBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mountedPackagesList = new System.Windows.Forms.ListBox();
            this.unmountBtn = new System.Windows.Forms.Button();
            this.getPathBtn = new System.Windows.Forms.Button();
            this.mountBtn = new System.Windows.Forms.Button();
            this.installRegBtn = new System.Windows.Forms.Button();
            this.installUnregBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.packageIdTextBox = new System.Windows.Forms.TextBox();
            this.estimateDownloadSizeButton = new System.Windows.Forms.Button();
            this.createInstallMonitorButton = new System.Windows.Forms.Button();
            this.updateInstallMonitorButton = new System.Windows.Forms.Button();
            this.closeInstallMonitorButton = new System.Windows.Forms.Button();
            this.registerForInstallProgressButton = new System.Windows.Forms.Button();
            this.unregisterForInstallProgressButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.storeIdTextBox = new System.Windows.Forms.TextBox();
            this.updatesListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // downloadUpdates
            // 
            this.downloadUpdates.Location = new System.Drawing.Point(1100, 796);
            this.downloadUpdates.Margin = new System.Windows.Forms.Padding(4);
            this.downloadUpdates.Name = "downloadUpdates";
            this.downloadUpdates.Size = new System.Drawing.Size(220, 44);
            this.downloadUpdates.TabIndex = 17;
            this.downloadUpdates.Text = "Download selected";
            this.downloadUpdates.UseVisualStyleBackColor = true;
            this.downloadUpdates.Click += new System.EventHandler(this.downloadUpdates_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 916);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1779, 425);
            this.textBox1.TabIndex = 13;
            // 
            // installUpdates
            // 
            this.installUpdates.Location = new System.Drawing.Point(1100, 847);
            this.installUpdates.Margin = new System.Windows.Forms.Padding(4);
            this.installUpdates.Name = "installUpdates";
            this.installUpdates.Size = new System.Drawing.Size(220, 44);
            this.installUpdates.TabIndex = 18;
            this.installUpdates.Text = "Install selected";
            this.installUpdates.UseVisualStyleBackColor = true;
            this.installUpdates.Click += new System.EventHandler(this.installUpdates_Click);
            // 
            // downloadStoreId
            // 
            this.downloadStoreId.Location = new System.Drawing.Point(288, 336);
            this.downloadStoreId.Margin = new System.Windows.Forms.Padding(4);
            this.downloadStoreId.Name = "downloadStoreId";
            this.downloadStoreId.Size = new System.Drawing.Size(220, 57);
            this.downloadStoreId.TabIndex = 16;
            this.downloadStoreId.Text = "Download StoreId";
            this.downloadStoreId.UseVisualStyleBackColor = true;
            this.downloadStoreId.Click += new System.EventHandler(this.downloadStoreId_Click);
            // 
            // queryUpdates
            // 
            this.queryUpdates.Location = new System.Drawing.Point(792, 587);
            this.queryUpdates.Margin = new System.Windows.Forms.Padding(4);
            this.queryUpdates.Name = "queryUpdates";
            this.queryUpdates.Size = new System.Drawing.Size(220, 57);
            this.queryUpdates.TabIndex = 19;
            this.queryUpdates.Text = "Query Updates";
            this.queryUpdates.UseVisualStyleBackColor = true;
            this.queryUpdates.Click += new System.EventHandler(this.queryUpdates_Click);
            // 
            // queryPackageIdentiifer
            // 
            this.queryPackageIdentiifer.Location = new System.Drawing.Point(61, 336);
            this.queryPackageIdentiifer.Margin = new System.Windows.Forms.Padding(4);
            this.queryPackageIdentiifer.Name = "queryPackageIdentiifer";
            this.queryPackageIdentiifer.Size = new System.Drawing.Size(220, 57);
            this.queryPackageIdentiifer.TabIndex = 20;
            this.queryPackageIdentiifer.Text = "Query Package Id";
            this.queryPackageIdentiifer.UseVisualStyleBackColor = true;
            this.queryPackageIdentiifer.Click += new System.EventHandler(this.queryPackageIdentifier_Click);
            // 
            // getProcessPkgidBtn
            // 
            this.getProcessPkgidBtn.Location = new System.Drawing.Point(26, 22);
            this.getProcessPkgidBtn.Margin = new System.Windows.Forms.Padding(6);
            this.getProcessPkgidBtn.Name = "getProcessPkgidBtn";
            this.getProcessPkgidBtn.Size = new System.Drawing.Size(207, 57);
            this.getProcessPkgidBtn.TabIndex = 21;
            this.getProcessPkgidBtn.Text = "Get process pkgid";
            this.getProcessPkgidBtn.UseVisualStyleBackColor = true;
            this.getProcessPkgidBtn.Click += new System.EventHandler(this.getProcessPkgId_click);
            // 
            // getLocaleBtn
            // 
            this.getLocaleBtn.Location = new System.Drawing.Point(26, 89);
            this.getLocaleBtn.Margin = new System.Windows.Forms.Padding(6);
            this.getLocaleBtn.Name = "getLocaleBtn";
            this.getLocaleBtn.Size = new System.Drawing.Size(207, 54);
            this.getLocaleBtn.TabIndex = 22;
            this.getLocaleBtn.Text = "Get user locale";
            this.getLocaleBtn.UseVisualStyleBackColor = true;
            this.getLocaleBtn.Click += new System.EventHandler(this.getLocaleBtn_Click);
            // 
            // getIsPackagedBtn
            // 
            this.getIsPackagedBtn.Location = new System.Drawing.Point(26, 153);
            this.getIsPackagedBtn.Margin = new System.Windows.Forms.Padding(6);
            this.getIsPackagedBtn.Name = "getIsPackagedBtn";
            this.getIsPackagedBtn.Size = new System.Drawing.Size(207, 57);
            this.getIsPackagedBtn.TabIndex = 23;
            this.getIsPackagedBtn.Text = "Get is packaged";
            this.getIsPackagedBtn.UseVisualStyleBackColor = true;
            this.getIsPackagedBtn.Click += new System.EventHandler(this.getIsPackagedBtn_Click);
            // 
            // packageEnumList
            // 
            this.packageEnumList.FormattingEnabled = true;
            this.packageEnumList.ItemHeight = 24;
            this.packageEnumList.Location = new System.Drawing.Point(1030, 52);
            this.packageEnumList.Margin = new System.Windows.Forms.Padding(6);
            this.packageEnumList.Name = "packageEnumList";
            this.packageEnumList.Size = new System.Drawing.Size(354, 388);
            this.packageEnumList.TabIndex = 24;
            this.packageEnumList.SelectedIndexChanged += new System.EventHandler(this.packageEnumList_SelectedIndexChanged);
            // 
            // enumPackagesBtn
            // 
            this.enumPackagesBtn.Location = new System.Drawing.Point(790, 52);
            this.enumPackagesBtn.Margin = new System.Windows.Forms.Padding(6);
            this.enumPackagesBtn.Name = "enumPackagesBtn";
            this.enumPackagesBtn.Size = new System.Drawing.Size(207, 57);
            this.enumPackagesBtn.TabIndex = 25;
            this.enumPackagesBtn.Text = "Enum packages";
            this.enumPackagesBtn.UseVisualStyleBackColor = true;
            this.enumPackagesBtn.Click += new System.EventHandler(this.enumPackagesBtn_Click);
            // 
            // packageKindCombo
            // 
            this.packageKindCombo.FormattingEnabled = true;
            this.packageKindCombo.Location = new System.Drawing.Point(790, 120);
            this.packageKindCombo.Margin = new System.Windows.Forms.Padding(6);
            this.packageKindCombo.Name = "packageKindCombo";
            this.packageKindCombo.Size = new System.Drawing.Size(219, 32);
            this.packageKindCombo.TabIndex = 26;
            // 
            // copyToClipboardBtn
            // 
            this.copyToClipboardBtn.Location = new System.Drawing.Point(1069, 504);
            this.copyToClipboardBtn.Margin = new System.Windows.Forms.Padding(6);
            this.copyToClipboardBtn.Name = "copyToClipboardBtn";
            this.copyToClipboardBtn.Size = new System.Drawing.Size(288, 42);
            this.copyToClipboardBtn.TabIndex = 27;
            this.copyToClipboardBtn.Text = "Copy selected to clipboard";
            this.copyToClipboardBtn.UseVisualStyleBackColor = true;
            this.copyToClipboardBtn.Click += new System.EventHandler(this.copyToClipboardBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1025, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "Enumerated packages:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1412, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 25);
            this.label2.TabIndex = 29;
            this.label2.Text = "Mounted packages:";
            // 
            // mountedPackagesList
            // 
            this.mountedPackagesList.FormattingEnabled = true;
            this.mountedPackagesList.ItemHeight = 24;
            this.mountedPackagesList.Location = new System.Drawing.Point(1419, 52);
            this.mountedPackagesList.Margin = new System.Windows.Forms.Padding(6);
            this.mountedPackagesList.Name = "mountedPackagesList";
            this.mountedPackagesList.Size = new System.Drawing.Size(380, 388);
            this.mountedPackagesList.TabIndex = 30;
            this.mountedPackagesList.SelectedIndexChanged += new System.EventHandler(this.mountedPackagesList_SelectedIndexChanged);
            // 
            // unmountBtn
            // 
            this.unmountBtn.Location = new System.Drawing.Point(1478, 504);
            this.unmountBtn.Margin = new System.Windows.Forms.Padding(6);
            this.unmountBtn.Name = "unmountBtn";
            this.unmountBtn.Size = new System.Drawing.Size(255, 42);
            this.unmountBtn.TabIndex = 31;
            this.unmountBtn.Text = "Unmount selected";
            this.unmountBtn.UseVisualStyleBackColor = true;
            this.unmountBtn.Click += new System.EventHandler(this.unmountBtn_Click);
            // 
            // getPathBtn
            // 
            this.getPathBtn.Location = new System.Drawing.Point(1478, 450);
            this.getPathBtn.Margin = new System.Windows.Forms.Padding(6);
            this.getPathBtn.Name = "getPathBtn";
            this.getPathBtn.Size = new System.Drawing.Size(255, 42);
            this.getPathBtn.TabIndex = 32;
            this.getPathBtn.Text = "Get path for selected";
            this.getPathBtn.UseVisualStyleBackColor = true;
            this.getPathBtn.Click += new System.EventHandler(this.getPathBtn_Click);
            // 
            // mountBtn
            // 
            this.mountBtn.Location = new System.Drawing.Point(1069, 450);
            this.mountBtn.Margin = new System.Windows.Forms.Padding(6);
            this.mountBtn.Name = "mountBtn";
            this.mountBtn.Size = new System.Drawing.Size(288, 42);
            this.mountBtn.TabIndex = 33;
            this.mountBtn.Text = "Mount selected";
            this.mountBtn.UseVisualStyleBackColor = true;
            this.mountBtn.Click += new System.EventHandler(this.mountBtn_Click);
            // 
            // installRegBtn
            // 
            this.installRegBtn.Location = new System.Drawing.Point(26, 222);
            this.installRegBtn.Margin = new System.Windows.Forms.Padding(6);
            this.installRegBtn.Name = "installRegBtn";
            this.installRegBtn.Size = new System.Drawing.Size(262, 52);
            this.installRegBtn.TabIndex = 34;
            this.installRegBtn.Text = "Register for install event";
            this.installRegBtn.UseVisualStyleBackColor = true;
            this.installRegBtn.Click += new System.EventHandler(this.installRegBtn_Click);
            // 
            // installUnregBtn
            // 
            this.installUnregBtn.Location = new System.Drawing.Point(299, 222);
            this.installUnregBtn.Margin = new System.Windows.Forms.Padding(6);
            this.installUnregBtn.Name = "installUnregBtn";
            this.installUnregBtn.Size = new System.Drawing.Size(81, 52);
            this.installUnregBtn.TabIndex = 35;
            this.installUnregBtn.Text = "Unreg";
            this.installUnregBtn.UseVisualStyleBackColor = true;
            this.installUnregBtn.Click += new System.EventHandler(this.installUnregBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "Package identifier:";
            // 
            // packageIdTextBox
            // 
            this.packageIdTextBox.Location = new System.Drawing.Point(196, 24);
            this.packageIdTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.packageIdTextBox.Name = "packageIdTextBox";
            this.packageIdTextBox.Size = new System.Drawing.Size(492, 29);
            this.packageIdTextBox.TabIndex = 37;
            // 
            // estimateDownloadSizeButton
            // 
            this.estimateDownloadSizeButton.Location = new System.Drawing.Point(22, 83);
            this.estimateDownloadSizeButton.Margin = new System.Windows.Forms.Padding(6);
            this.estimateDownloadSizeButton.Name = "estimateDownloadSizeButton";
            this.estimateDownloadSizeButton.Size = new System.Drawing.Size(257, 42);
            this.estimateDownloadSizeButton.TabIndex = 38;
            this.estimateDownloadSizeButton.Text = "Estimate download size";
            this.estimateDownloadSizeButton.UseVisualStyleBackColor = true;
            this.estimateDownloadSizeButton.Click += new System.EventHandler(this.estimateDownloadSizeButton_Click);
            // 
            // createInstallMonitorButton
            // 
            this.createInstallMonitorButton.Location = new System.Drawing.Point(22, 138);
            this.createInstallMonitorButton.Margin = new System.Windows.Forms.Padding(6);
            this.createInstallMonitorButton.Name = "createInstallMonitorButton";
            this.createInstallMonitorButton.Size = new System.Drawing.Size(257, 42);
            this.createInstallMonitorButton.TabIndex = 39;
            this.createInstallMonitorButton.Text = "Create install monitor";
            this.createInstallMonitorButton.UseVisualStyleBackColor = true;
            this.createInstallMonitorButton.Click += new System.EventHandler(this.createInstallMonitorButton_Click);
            // 
            // updateInstallMonitorButton
            // 
            this.updateInstallMonitorButton.Location = new System.Drawing.Point(290, 138);
            this.updateInstallMonitorButton.Margin = new System.Windows.Forms.Padding(6);
            this.updateInstallMonitorButton.Name = "updateInstallMonitorButton";
            this.updateInstallMonitorButton.Size = new System.Drawing.Size(123, 42);
            this.updateInstallMonitorButton.TabIndex = 40;
            this.updateInstallMonitorButton.Text = "Update";
            this.updateInstallMonitorButton.UseVisualStyleBackColor = true;
            this.updateInstallMonitorButton.Click += new System.EventHandler(this.updateInstallMonitorButton_Click);
            // 
            // closeInstallMonitorButton
            // 
            this.closeInstallMonitorButton.Location = new System.Drawing.Point(425, 138);
            this.closeInstallMonitorButton.Margin = new System.Windows.Forms.Padding(6);
            this.closeInstallMonitorButton.Name = "closeInstallMonitorButton";
            this.closeInstallMonitorButton.Size = new System.Drawing.Size(125, 42);
            this.closeInstallMonitorButton.TabIndex = 41;
            this.closeInstallMonitorButton.Text = "Close";
            this.closeInstallMonitorButton.UseVisualStyleBackColor = true;
            this.closeInstallMonitorButton.Click += new System.EventHandler(this.closeInstallMonitorButton_Click);
            // 
            // registerForInstallProgressButton
            // 
            this.registerForInstallProgressButton.Location = new System.Drawing.Point(127, 192);
            this.registerForInstallProgressButton.Margin = new System.Windows.Forms.Padding(6);
            this.registerForInstallProgressButton.Name = "registerForInstallProgressButton";
            this.registerForInstallProgressButton.Size = new System.Drawing.Size(286, 42);
            this.registerForInstallProgressButton.TabIndex = 42;
            this.registerForInstallProgressButton.Text = "Register for install progress";
            this.registerForInstallProgressButton.UseVisualStyleBackColor = true;
            this.registerForInstallProgressButton.Click += new System.EventHandler(this.registerForInstallProgressButton_Click);
            // 
            // unregisterForInstallProgressButton
            // 
            this.unregisterForInstallProgressButton.Location = new System.Drawing.Point(425, 192);
            this.unregisterForInstallProgressButton.Margin = new System.Windows.Forms.Padding(6);
            this.unregisterForInstallProgressButton.Name = "unregisterForInstallProgressButton";
            this.unregisterForInstallProgressButton.Size = new System.Drawing.Size(125, 42);
            this.unregisterForInstallProgressButton.TabIndex = 43;
            this.unregisterForInstallProgressButton.Text = "Unreg";
            this.unregisterForInstallProgressButton.UseVisualStyleBackColor = true;
            this.unregisterForInstallProgressButton.Click += new System.EventHandler(this.unregisterForInstallProgressButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.unregisterForInstallProgressButton);
            this.groupBox1.Controls.Add(this.registerForInstallProgressButton);
            this.groupBox1.Controls.Add(this.packageIdTextBox);
            this.groupBox1.Controls.Add(this.closeInstallMonitorButton);
            this.groupBox1.Controls.Add(this.estimateDownloadSizeButton);
            this.groupBox1.Controls.Add(this.updateInstallMonitorButton);
            this.groupBox1.Controls.Add(this.createInstallMonitorButton);
            this.groupBox1.Location = new System.Drawing.Point(26, 425);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(702, 260);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Installation Monitor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 295);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 25);
            this.label4.TabIndex = 45;
            this.label4.Text = "Store ID:";
            // 
            // storeIdTextBox
            // 
            this.storeIdTextBox.Location = new System.Drawing.Point(134, 290);
            this.storeIdTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.storeIdTextBox.Name = "storeIdTextBox";
            this.storeIdTextBox.Size = new System.Drawing.Size(367, 29);
            this.storeIdTextBox.TabIndex = 46;
            // 
            // updatesListBox
            // 
            this.updatesListBox.FormattingEnabled = true;
            this.updatesListBox.ItemHeight = 24;
            this.updatesListBox.Location = new System.Drawing.Point(1030, 587);
            this.updatesListBox.Margin = new System.Windows.Forms.Padding(6);
            this.updatesListBox.Name = "updatesListBox";
            this.updatesListBox.Size = new System.Drawing.Size(354, 196);
            this.updatesListBox.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 89);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 57);
            this.button1.TabIndex = 48;
            this.button1.Text = "Get write stats";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.XPackageGetWriteStats_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 156);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 54);
            this.button2.TabIndex = 49;
            this.button2.Text = "Uninstall UWP Instance";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.XPackageUninstallUWPInstance_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(245, 22);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(226, 57);
            this.button3.TabIndex = 50;
            this.button3.Text = "Enumerate Features";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.XPackageEnumerateFeatures_Click);
            // 
            // PackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1819, 1362);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.updatesListBox);
            this.Controls.Add(this.storeIdTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.installUnregBtn);
            this.Controls.Add(this.installRegBtn);
            this.Controls.Add(this.mountBtn);
            this.Controls.Add(this.getPathBtn);
            this.Controls.Add(this.unmountBtn);
            this.Controls.Add(this.mountedPackagesList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.copyToClipboardBtn);
            this.Controls.Add(this.packageKindCombo);
            this.Controls.Add(this.enumPackagesBtn);
            this.Controls.Add(this.packageEnumList);
            this.Controls.Add(this.getIsPackagedBtn);
            this.Controls.Add(this.getLocaleBtn);
            this.Controls.Add(this.getProcessPkgidBtn);
            this.Controls.Add(this.queryPackageIdentiifer);
            this.Controls.Add(this.queryUpdates);
            this.Controls.Add(this.installUpdates);
            this.Controls.Add(this.downloadUpdates);
            this.Controls.Add(this.downloadStoreId);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PackageForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Package Related Features";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button downloadUpdates;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button installUpdates;
        private System.Windows.Forms.Button downloadStoreId;
        private System.Windows.Forms.Button queryUpdates;
        private System.Windows.Forms.Button queryPackageIdentiifer;
        private System.Windows.Forms.Button getProcessPkgidBtn;
        private System.Windows.Forms.Button getLocaleBtn;
        private System.Windows.Forms.Button getIsPackagedBtn;
        private System.Windows.Forms.ListBox packageEnumList;
        private System.Windows.Forms.Button enumPackagesBtn;
        private System.Windows.Forms.ComboBox packageKindCombo;
        private System.Windows.Forms.Button copyToClipboardBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox mountedPackagesList;
        private System.Windows.Forms.Button unmountBtn;
        private System.Windows.Forms.Button getPathBtn;
        private System.Windows.Forms.Button mountBtn;
        private System.Windows.Forms.Button installRegBtn;
        private System.Windows.Forms.Button installUnregBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox packageIdTextBox;
        private System.Windows.Forms.Button estimateDownloadSizeButton;
        private System.Windows.Forms.Button createInstallMonitorButton;
        private System.Windows.Forms.Button updateInstallMonitorButton;
        private System.Windows.Forms.Button closeInstallMonitorButton;
        private System.Windows.Forms.Button registerForInstallProgressButton;
        private System.Windows.Forms.Button unregisterForInstallProgressButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox storeIdTextBox;
        private System.Windows.Forms.ListBox updatesListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}