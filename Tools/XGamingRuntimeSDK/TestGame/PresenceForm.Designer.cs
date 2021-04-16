namespace TestGame
{
    partial class PresenceForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.getPresence = new System.Windows.Forms.Button();
            this.getXuid = new System.Windows.Forms.Button();
            this.getUserState = new System.Windows.Forms.Button();
            this.getDeviceRecords = new System.Windows.Forms.Button();
            this.duplicateHandle = new System.Windows.Forms.Button();
            this.closeHandle = new System.Windows.Forms.Button();
            this.getPresenceForMultipleUsers = new System.Windows.Forms.Button();
            this.getPresenceForSocialGroup = new System.Windows.Forms.Button();
            this.setPresence = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.titleIds = new System.Windows.Forms.TextBox();
            this.xuids = new System.Windows.Forms.TextBox();
            this.titleIdLabel = new System.Windows.Forms.Label();
            this.xuidLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 344);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(928, 378);
            this.textBox1.TabIndex = 15;
            // 
            // getPresence
            // 
            this.getPresence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getPresence.Location = new System.Drawing.Point(12, 78);
            this.getPresence.Name = "getPresence";
            this.getPresence.Size = new System.Drawing.Size(180, 60);
            this.getPresence.TabIndex = 16;
            this.getPresence.Text = "Get Presence";
            this.getPresence.UseVisualStyleBackColor = true;
            this.getPresence.Click += new System.EventHandler(this.getPresence_Click);
            // 
            // getXuid
            // 
            this.getXuid.Enabled = false;
            this.getXuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getXuid.Location = new System.Drawing.Point(198, 78);
            this.getXuid.Name = "getXuid";
            this.getXuid.Size = new System.Drawing.Size(180, 60);
            this.getXuid.TabIndex = 17;
            this.getXuid.Text = "Get XUID";
            this.getXuid.UseVisualStyleBackColor = true;
            this.getXuid.Click += new System.EventHandler(this.getXuid_Click);
            // 
            // getUserState
            // 
            this.getUserState.Enabled = false;
            this.getUserState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getUserState.Location = new System.Drawing.Point(198, 144);
            this.getUserState.Name = "getUserState";
            this.getUserState.Size = new System.Drawing.Size(180, 60);
            this.getUserState.TabIndex = 18;
            this.getUserState.Text = "Get User State";
            this.getUserState.UseVisualStyleBackColor = true;
            this.getUserState.Click += new System.EventHandler(this.getUserState_Click);
            // 
            // getDeviceRecords
            // 
            this.getDeviceRecords.Enabled = false;
            this.getDeviceRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getDeviceRecords.Location = new System.Drawing.Point(198, 212);
            this.getDeviceRecords.Name = "getDeviceRecords";
            this.getDeviceRecords.Size = new System.Drawing.Size(180, 60);
            this.getDeviceRecords.TabIndex = 19;
            this.getDeviceRecords.Text = "GetDeviceRecords";
            this.getDeviceRecords.UseVisualStyleBackColor = true;
            this.getDeviceRecords.Click += new System.EventHandler(this.getDeviceRecords_Click);
            // 
            // duplicateHandle
            // 
            this.duplicateHandle.Enabled = false;
            this.duplicateHandle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duplicateHandle.Location = new System.Drawing.Point(12, 278);
            this.duplicateHandle.Name = "duplicateHandle";
            this.duplicateHandle.Size = new System.Drawing.Size(180, 60);
            this.duplicateHandle.TabIndex = 20;
            this.duplicateHandle.Text = "Duplicate Handle";
            this.duplicateHandle.UseVisualStyleBackColor = true;
            this.duplicateHandle.Click += new System.EventHandler(this.duplicateHandle_Click);
            // 
            // closeHandle
            // 
            this.closeHandle.Enabled = false;
            this.closeHandle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeHandle.Location = new System.Drawing.Point(198, 278);
            this.closeHandle.Name = "closeHandle";
            this.closeHandle.Size = new System.Drawing.Size(180, 60);
            this.closeHandle.TabIndex = 21;
            this.closeHandle.Text = "Close Handle";
            this.closeHandle.UseVisualStyleBackColor = true;
            this.closeHandle.Click += new System.EventHandler(this.closeHandle_Click);
            // 
            // getPresenceForMultipleUsers
            // 
            this.getPresenceForMultipleUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getPresenceForMultipleUsers.Location = new System.Drawing.Point(12, 144);
            this.getPresenceForMultipleUsers.Name = "getPresenceForMultipleUsers";
            this.getPresenceForMultipleUsers.Size = new System.Drawing.Size(180, 60);
            this.getPresenceForMultipleUsers.TabIndex = 22;
            this.getPresenceForMultipleUsers.Text = "Get Presence For Multiple Users";
            this.getPresenceForMultipleUsers.UseVisualStyleBackColor = true;
            this.getPresenceForMultipleUsers.Click += new System.EventHandler(this.getPresenceForMultipleUsers_Click);
            // 
            // getPresenceForSocialGroup
            // 
            this.getPresenceForSocialGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getPresenceForSocialGroup.Location = new System.Drawing.Point(12, 212);
            this.getPresenceForSocialGroup.Name = "getPresenceForSocialGroup";
            this.getPresenceForSocialGroup.Size = new System.Drawing.Size(180, 60);
            this.getPresenceForSocialGroup.TabIndex = 23;
            this.getPresenceForSocialGroup.Text = "Get Presence For Social Group";
            this.getPresenceForSocialGroup.UseVisualStyleBackColor = true;
            this.getPresenceForSocialGroup.Click += new System.EventHandler(this.getPresenceForSocialGroup_Click);
            // 
            // setPresence
            // 
            this.setPresence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setPresence.Location = new System.Drawing.Point(12, 12);
            this.setPresence.Name = "setPresence";
            this.setPresence.Size = new System.Drawing.Size(366, 60);
            this.setPresence.TabIndex = 24;
            this.setPresence.Text = "SetPresence";
            this.setPresence.UseVisualStyleBackColor = true;
            this.setPresence.Click += new System.EventHandler(this.setPresence_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.titleIds);
            this.groupBox1.Controls.Add(this.xuids);
            this.groupBox1.Controls.Add(this.titleIdLabel);
            this.groupBox1.Controls.Add(this.xuidLabel);
            this.groupBox1.Location = new System.Drawing.Point(385, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(554, 322);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // titleIds
            // 
            this.titleIds.Location = new System.Drawing.Point(104, 96);
            this.titleIds.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.titleIds.Multiline = true;
            this.titleIds.Name = "titleIds";
            this.titleIds.Size = new System.Drawing.Size(442, 60);
            this.titleIds.TabIndex = 24;
            // 
            // xuids
            // 
            this.xuids.Location = new System.Drawing.Point(104, 26);
            this.xuids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xuids.Multiline = true;
            this.xuids.Name = "xuids";
            this.xuids.Size = new System.Drawing.Size(442, 60);
            this.xuids.TabIndex = 23;
            // 
            // titleIdLabel
            // 
            this.titleIdLabel.AutoSize = true;
            this.titleIdLabel.Location = new System.Drawing.Point(8, 104);
            this.titleIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleIdLabel.Name = "titleIdLabel";
            this.titleIdLabel.Size = new System.Drawing.Size(88, 20);
            this.titleIdLabel.TabIndex = 21;
            this.titleIdLabel.Text = "Title ID List";
            // 
            // xuidLabel
            // 
            this.xuidLabel.AutoSize = true;
            this.xuidLabel.Location = new System.Drawing.Point(18, 29);
            this.xuidLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xuidLabel.Name = "xuidLabel";
            this.xuidLabel.Size = new System.Drawing.Size(78, 20);
            this.xuidLabel.TabIndex = 20;
            this.xuidLabel.Text = "XUID List";
            // 
            // PresenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 734);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.setPresence);
            this.Controls.Add(this.getPresenceForSocialGroup);
            this.Controls.Add(this.getPresenceForMultipleUsers);
            this.Controls.Add(this.closeHandle);
            this.Controls.Add(this.duplicateHandle);
            this.Controls.Add(this.getDeviceRecords);
            this.Controls.Add(this.getUserState);
            this.Controls.Add(this.getXuid);
            this.Controls.Add(this.getPresence);
            this.Controls.Add(this.textBox1);
            this.Name = "PresenceForm";
            this.Text = "PresenceForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button getPresence;
        private System.Windows.Forms.Button getXuid;
        private System.Windows.Forms.Button getUserState;
        private System.Windows.Forms.Button getDeviceRecords;
        private System.Windows.Forms.Button duplicateHandle;
        private System.Windows.Forms.Button closeHandle;
        private System.Windows.Forms.Button getPresenceForMultipleUsers;
        private System.Windows.Forms.Button getPresenceForSocialGroup;
        private System.Windows.Forms.Button setPresence;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label titleIdLabel;
        private System.Windows.Forms.Label xuidLabel;
        private System.Windows.Forms.TextBox titleIds;
        private System.Windows.Forms.TextBox xuids;
    }
}