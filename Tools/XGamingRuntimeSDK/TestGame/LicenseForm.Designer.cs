using System;

namespace TestGame
{
    partial class LicenseForm
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
            this.queryGameLicense = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.acquireLicenseForPackage = new System.Windows.Forms.Button();
            this.canAcquireLicenseForPackage = new System.Windows.Forms.Button();
            this.canAcquireLicenseForStoreId = new System.Windows.Forms.Button();
            this.closeLicenseHandle = new System.Windows.Forms.Button();
            this.isLicenseValid = new System.Windows.Forms.Button();
            this.queryAddonLicenses = new System.Windows.Forms.Button();
            this.queryLicenseToken = new System.Windows.Forms.Button();
            this.registerGameLicenseChanged = new System.Windows.Forms.Button();
            this.registerPackageLicenseLost = new System.Windows.Forms.Button();
            this.unregisterGameLicenseChanged = new System.Windows.Forms.Button();
            this.unregisterPackageLicenseLost = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // queryGameLicense
            // 
            this.queryGameLicense.Location = new System.Drawing.Point(242, 174);
            this.queryGameLicense.Margin = new System.Windows.Forms.Padding(4);
            this.queryGameLicense.Name = "queryGameLicense";
            this.queryGameLicense.Size = new System.Drawing.Size(220, 72);
            this.queryGameLicense.TabIndex = 5;
            this.queryGameLicense.Text = "Query Game License";
            this.queryGameLicense.UseVisualStyleBackColor = true;
            this.queryGameLicense.Click += new System.EventHandler(this.queryGameLicense_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 515);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1133, 351);
            this.textBox1.TabIndex = 14;
            // 
            // acquireLicenseForPackage
            // 
            this.acquireLicenseForPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acquireLicenseForPackage.Location = new System.Drawing.Point(15, 15);
            this.acquireLicenseForPackage.Margin = new System.Windows.Forms.Padding(4);
            this.acquireLicenseForPackage.Name = "acquireLicenseForPackage";
            this.acquireLicenseForPackage.Size = new System.Drawing.Size(220, 72);
            this.acquireLicenseForPackage.TabIndex = 15;
            this.acquireLicenseForPackage.Text = "Acquire License For Package";
            this.acquireLicenseForPackage.UseVisualStyleBackColor = true;
            this.acquireLicenseForPackage.Click += new System.EventHandler(this.acquireLicenseForPackage_Click);
            // 
            // canAcquireLicenseForPackage
            // 
            this.canAcquireLicenseForPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.canAcquireLicenseForPackage.Location = new System.Drawing.Point(13, 175);
            this.canAcquireLicenseForPackage.Margin = new System.Windows.Forms.Padding(4);
            this.canAcquireLicenseForPackage.Name = "canAcquireLicenseForPackage";
            this.canAcquireLicenseForPackage.Size = new System.Drawing.Size(220, 72);
            this.canAcquireLicenseForPackage.TabIndex = 16;
            this.canAcquireLicenseForPackage.Text = "Can Acquire License For Package";
            this.canAcquireLicenseForPackage.UseVisualStyleBackColor = true;
            this.canAcquireLicenseForPackage.Click += new System.EventHandler(this.canAcquireLicenseForPackage_Click);
            // 
            // canAcquireLicenseForStoreId
            // 
            this.canAcquireLicenseForStoreId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.canAcquireLicenseForStoreId.Location = new System.Drawing.Point(13, 255);
            this.canAcquireLicenseForStoreId.Margin = new System.Windows.Forms.Padding(4);
            this.canAcquireLicenseForStoreId.Name = "canAcquireLicenseForStoreId";
            this.canAcquireLicenseForStoreId.Size = new System.Drawing.Size(220, 72);
            this.canAcquireLicenseForStoreId.TabIndex = 17;
            this.canAcquireLicenseForStoreId.Text = "Can Acquire License For Store ID";
            this.canAcquireLicenseForStoreId.UseVisualStyleBackColor = true;
            this.canAcquireLicenseForStoreId.Click += new System.EventHandler(this.canAcquireLicenseForStoreId_Click);
            // 
            // closeLicenseHandle
            // 
            this.closeLicenseHandle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.closeLicenseHandle.Location = new System.Drawing.Point(13, 332);
            this.closeLicenseHandle.Margin = new System.Windows.Forms.Padding(4);
            this.closeLicenseHandle.Name = "closeLicenseHandle";
            this.closeLicenseHandle.Size = new System.Drawing.Size(220, 72);
            this.closeLicenseHandle.TabIndex = 18;
            this.closeLicenseHandle.Text = "Close License Handle";
            this.closeLicenseHandle.UseVisualStyleBackColor = true;
            this.closeLicenseHandle.Click += new System.EventHandler(this.closeLicenseHandle_Click);
            // 
            // isLicenseValid
            // 
            this.isLicenseValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.isLicenseValid.Location = new System.Drawing.Point(13, 411);
            this.isLicenseValid.Margin = new System.Windows.Forms.Padding(4);
            this.isLicenseValid.Name = "isLicenseValid";
            this.isLicenseValid.Size = new System.Drawing.Size(220, 72);
            this.isLicenseValid.TabIndex = 19;
            this.isLicenseValid.Text = "Is License Valid";
            this.isLicenseValid.UseVisualStyleBackColor = true;
            this.isLicenseValid.Click += new System.EventHandler(this.isLicenseValid_Click);
            // 
            // queryAddonLicenses
            // 
            this.queryAddonLicenses.Location = new System.Drawing.Point(243, 15);
            this.queryAddonLicenses.Margin = new System.Windows.Forms.Padding(4);
            this.queryAddonLicenses.Name = "queryAddonLicenses";
            this.queryAddonLicenses.Size = new System.Drawing.Size(220, 72);
            this.queryAddonLicenses.TabIndex = 20;
            this.queryAddonLicenses.Text = "Query Addon Licenses";
            this.queryAddonLicenses.UseVisualStyleBackColor = true;
            this.queryAddonLicenses.Click += new System.EventHandler(this.queryAddonLicenses_Click);
            // 
            // queryLicenseToken
            // 
            this.queryLicenseToken.Location = new System.Drawing.Point(242, 95);
            this.queryLicenseToken.Margin = new System.Windows.Forms.Padding(4);
            this.queryLicenseToken.Name = "queryLicenseToken";
            this.queryLicenseToken.Size = new System.Drawing.Size(220, 72);
            this.queryLicenseToken.TabIndex = 21;
            this.queryLicenseToken.Text = "Query License Token";
            this.queryLicenseToken.UseVisualStyleBackColor = true;
            this.queryLicenseToken.Click += new System.EventHandler(this.queryLicenseToken_Click);
            // 
            // registerGameLicenseChanged
            // 
            this.registerGameLicenseChanged.Location = new System.Drawing.Point(471, 15);
            this.registerGameLicenseChanged.Margin = new System.Windows.Forms.Padding(4);
            this.registerGameLicenseChanged.Name = "registerGameLicenseChanged";
            this.registerGameLicenseChanged.Size = new System.Drawing.Size(220, 72);
            this.registerGameLicenseChanged.TabIndex = 22;
            this.registerGameLicenseChanged.Text = "Register Game License Changed";
            this.registerGameLicenseChanged.UseVisualStyleBackColor = true;
            this.registerGameLicenseChanged.Click += new System.EventHandler(this.registerGameLicenseChanged_Click);
            // 
            // registerPackageLicenseLost
            // 
            this.registerPackageLicenseLost.Location = new System.Drawing.Point(471, 92);
            this.registerPackageLicenseLost.Margin = new System.Windows.Forms.Padding(4);
            this.registerPackageLicenseLost.Name = "registerPackageLicenseLost";
            this.registerPackageLicenseLost.Size = new System.Drawing.Size(220, 72);
            this.registerPackageLicenseLost.TabIndex = 23;
            this.registerPackageLicenseLost.Text = "Register Package License Lost";
            this.registerPackageLicenseLost.UseVisualStyleBackColor = true;
            this.registerPackageLicenseLost.Click += new System.EventHandler(this.registerPackageLicenseLost_Click);
            // 
            // unregisterGameLicenseChanged
            // 
            this.unregisterGameLicenseChanged.Enabled = false;
            this.unregisterGameLicenseChanged.Location = new System.Drawing.Point(471, 171);
            this.unregisterGameLicenseChanged.Margin = new System.Windows.Forms.Padding(4);
            this.unregisterGameLicenseChanged.Name = "unregisterGameLicenseChanged";
            this.unregisterGameLicenseChanged.Size = new System.Drawing.Size(220, 72);
            this.unregisterGameLicenseChanged.TabIndex = 24;
            this.unregisterGameLicenseChanged.Text = "Unregister Game License Changed";
            this.unregisterGameLicenseChanged.UseVisualStyleBackColor = true;
            this.unregisterGameLicenseChanged.Click += new System.EventHandler(this.unregisterGameLicenseChanged_Click);
            // 
            // unregisterPackageLicenseLost
            // 
            this.unregisterPackageLicenseLost.Enabled = false;
            this.unregisterPackageLicenseLost.Location = new System.Drawing.Point(471, 251);
            this.unregisterPackageLicenseLost.Margin = new System.Windows.Forms.Padding(4);
            this.unregisterPackageLicenseLost.Name = "unregisterPackageLicenseLost";
            this.unregisterPackageLicenseLost.Size = new System.Drawing.Size(220, 72);
            this.unregisterPackageLicenseLost.TabIndex = 25;
            this.unregisterPackageLicenseLost.Text = "Unregister Package License Lost";
            this.unregisterPackageLicenseLost.UseVisualStyleBackColor = true;
            this.unregisterPackageLicenseLost.Click += new System.EventHandler(this.unregisterPackageLicenseLost_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 95);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 72);
            this.button1.TabIndex = 26;
            this.button1.Text = "Acquire License For Durables";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.XStoreAcquireLicenseForDurablesAsync_Click);
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 881);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.unregisterPackageLicenseLost);
            this.Controls.Add(this.unregisterGameLicenseChanged);
            this.Controls.Add(this.registerPackageLicenseLost);
            this.Controls.Add(this.registerGameLicenseChanged);
            this.Controls.Add(this.queryLicenseToken);
            this.Controls.Add(this.queryAddonLicenses);
            this.Controls.Add(this.isLicenseValid);
            this.Controls.Add(this.closeLicenseHandle);
            this.Controls.Add(this.canAcquireLicenseForStoreId);
            this.Controls.Add(this.canAcquireLicenseForPackage);
            this.Controls.Add(this.acquireLicenseForPackage);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.queryGameLicense);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LicenseForm";
            this.Text = "License Related Features";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button queryGameLicense;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button acquireLicenseForPackage;
        private System.Windows.Forms.Button canAcquireLicenseForPackage;
        private System.Windows.Forms.Button canAcquireLicenseForStoreId;
        private System.Windows.Forms.Button closeLicenseHandle;
        private System.Windows.Forms.Button isLicenseValid;
        private System.Windows.Forms.Button queryAddonLicenses;
        private System.Windows.Forms.Button queryLicenseToken;
        private System.Windows.Forms.Button registerGameLicenseChanged;
        private System.Windows.Forms.Button registerPackageLicenseLost;
        private System.Windows.Forms.Button unregisterGameLicenseChanged;
        private System.Windows.Forms.Button unregisterPackageLicenseLost;
        private System.Windows.Forms.Button button1;
    }
}