namespace TestGame
{
    partial class UserForm
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
            this.components = new System.ComponentModel.Container();
            this.addUser = new System.Windows.Forms.Button();
            this.addUserOptions = new System.Windows.Forms.ListBox();
            this.signedInUsers = new System.Windows.Forms.ListBox();
            this.gamertag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.localId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.gamerpic = new System.Windows.Forms.PictureBox();
            this.privileges = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isGuest = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ageGroup = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.resolveButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.disallowedPrivileges = new System.Windows.Forms.ListBox();
            this.log = new System.Windows.Forms.TextBox();
            this.closeUserHandle = new System.Windows.Forms.Button();
            this.resolveIssue = new System.Windows.Forms.Button();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.registerForEvent = new System.Windows.Forms.Button();
            this.deferSignOut = new System.Windows.Forms.CheckBox();
            this.unregisterForEvent = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.maxUsers = new System.Windows.Forms.TextBox();
            this.findId = new System.Windows.Forms.TextBox();
            this.findLocal = new System.Windows.Forms.Button();
            this.findXuid = new System.Windows.Forms.Button();
            this.duplicateUserHandle = new System.Windows.Forms.Button();
            this.compareHandle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.getTokenAndSignatureButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.getTokenAndSignatureBody = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.getTokenAndSignatureMethod = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.getTokenAndSignatureUrl = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gamerpic)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // addUser
            // 
            this.addUser.Location = new System.Drawing.Point(11, 11);
            this.addUser.Margin = new System.Windows.Forms.Padding(2);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(100, 44);
            this.addUser.TabIndex = 6;
            this.addUser.Text = "AddUser";
            this.addUser.UseVisualStyleBackColor = true;
            this.addUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // addUserOptions
            // 
            this.addUserOptions.FormattingEnabled = true;
            this.addUserOptions.Items.AddRange(new object[] {
            "AddDefaultUserSilently",
            "AllowGuests",
            "AddDefaultUserAllowingUI"});
            this.addUserOptions.Location = new System.Drawing.Point(116, 11);
            this.addUserOptions.Name = "addUserOptions";
            this.addUserOptions.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.addUserOptions.Size = new System.Drawing.Size(140, 43);
            this.addUserOptions.TabIndex = 8;
            // 
            // signedInUsers
            // 
            this.signedInUsers.FormattingEnabled = true;
            this.signedInUsers.Location = new System.Drawing.Point(12, 61);
            this.signedInUsers.Name = "signedInUsers";
            this.signedInUsers.Size = new System.Drawing.Size(244, 43);
            this.signedInUsers.TabIndex = 9;
            this.signedInUsers.SelectedIndexChanged += new System.EventHandler(this.signedInUsers_SelectedIndexChanged);
            // 
            // gamertag
            // 
            this.gamertag.Location = new System.Drawing.Point(72, 19);
            this.gamertag.Name = "gamertag";
            this.gamertag.ReadOnly = true;
            this.gamertag.Size = new System.Drawing.Size(100, 20);
            this.gamertag.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "gamertag:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "local id:";
            // 
            // localId
            // 
            this.localId.Location = new System.Drawing.Point(72, 45);
            this.localId.Name = "localId";
            this.localId.ReadOnly = true;
            this.localId.Size = new System.Drawing.Size(100, 20);
            this.localId.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "id:";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(72, 71);
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Size = new System.Drawing.Size(100, 20);
            this.id.TabIndex = 14;
            // 
            // gamerpic
            // 
            this.gamerpic.Location = new System.Drawing.Point(178, 19);
            this.gamerpic.Name = "gamerpic";
            this.gamerpic.Size = new System.Drawing.Size(64, 64);
            this.gamerpic.TabIndex = 16;
            this.gamerpic.TabStop = false;
            // 
            // privileges
            // 
            this.privileges.FormattingEnabled = true;
            this.privileges.Location = new System.Drawing.Point(72, 97);
            this.privileges.Name = "privileges";
            this.privileges.Size = new System.Drawing.Size(170, 43);
            this.privileges.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.isGuest);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.status);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ageGroup);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.resolveButton);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.disallowedPrivileges);
            this.groupBox1.Controls.Add(this.privileges);
            this.groupBox1.Controls.Add(this.gamerpic);
            this.groupBox1.Controls.Add(this.gamertag);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.localId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(262, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 292);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // isGuest
            // 
            this.isGuest.Location = new System.Drawing.Point(72, 247);
            this.isGuest.Name = "isGuest";
            this.isGuest.ReadOnly = true;
            this.isGuest.Size = new System.Drawing.Size(100, 20);
            this.isGuest.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "is guest:";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(72, 221);
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Size = new System.Drawing.Size(100, 20);
            this.status.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "status:";
            // 
            // ageGroup
            // 
            this.ageGroup.Location = new System.Drawing.Point(72, 195);
            this.ageGroup.Name = "ageGroup";
            this.ageGroup.ReadOnly = true;
            this.ageGroup.Size = new System.Drawing.Size(100, 20);
            this.ageGroup.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "age group:";
            // 
            // resolveButton
            // 
            this.resolveButton.Location = new System.Drawing.Point(249, 146);
            this.resolveButton.Name = "resolveButton";
            this.resolveButton.Size = new System.Drawing.Size(75, 23);
            this.resolveButton.TabIndex = 21;
            this.resolveButton.Text = "Resolve";
            this.resolveButton.UseVisualStyleBackColor = true;
            this.resolveButton.Click += new System.EventHandler(this.resolveButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "allowed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "disallowed:";
            // 
            // disallowedPrivileges
            // 
            this.disallowedPrivileges.FormattingEnabled = true;
            this.disallowedPrivileges.Location = new System.Drawing.Point(72, 146);
            this.disallowedPrivileges.Name = "disallowedPrivileges";
            this.disallowedPrivileges.Size = new System.Drawing.Size(170, 43);
            this.disallowedPrivileges.TabIndex = 18;
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(11, 309);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(784, 285);
            this.log.TabIndex = 19;
            // 
            // closeUserHandle
            // 
            this.closeUserHandle.Location = new System.Drawing.Point(12, 148);
            this.closeUserHandle.Name = "closeUserHandle";
            this.closeUserHandle.Size = new System.Drawing.Size(78, 31);
            this.closeUserHandle.TabIndex = 20;
            this.closeUserHandle.Text = "Close";
            this.closeUserHandle.UseVisualStyleBackColor = true;
            this.closeUserHandle.Click += new System.EventHandler(this.closeUserHandle_Click);
            // 
            // resolveIssue
            // 
            this.resolveIssue.Location = new System.Drawing.Point(12, 185);
            this.resolveIssue.Name = "resolveIssue";
            this.resolveIssue.Size = new System.Drawing.Size(244, 31);
            this.resolveIssue.TabIndex = 21;
            this.resolveIssue.Text = "Resolve Issue";
            this.resolveIssue.UseVisualStyleBackColor = true;
            this.resolveIssue.Click += new System.EventHandler(this.resolveIssue_Click);
            // 
            // statusTimer
            // 
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // registerForEvent
            // 
            this.registerForEvent.Location = new System.Drawing.Point(12, 221);
            this.registerForEvent.Name = "registerForEvent";
            this.registerForEvent.Size = new System.Drawing.Size(118, 31);
            this.registerForEvent.TabIndex = 22;
            this.registerForEvent.Text = "Register for Event";
            this.registerForEvent.UseVisualStyleBackColor = true;
            this.registerForEvent.Click += new System.EventHandler(this.registerForEvent_Click);
            // 
            // deferSignOut
            // 
            this.deferSignOut.AutoSize = true;
            this.deferSignOut.Location = new System.Drawing.Point(12, 258);
            this.deferSignOut.Name = "deferSignOut";
            this.deferSignOut.Size = new System.Drawing.Size(96, 17);
            this.deferSignOut.TabIndex = 24;
            this.deferSignOut.Text = "Defer Sign Out";
            this.deferSignOut.UseVisualStyleBackColor = true;
            this.deferSignOut.CheckedChanged += new System.EventHandler(this.deferSignOut_CheckedChanged);
            // 
            // unregisterForEvent
            // 
            this.unregisterForEvent.Location = new System.Drawing.Point(136, 221);
            this.unregisterForEvent.Name = "unregisterForEvent";
            this.unregisterForEvent.Size = new System.Drawing.Size(119, 31);
            this.unregisterForEvent.TabIndex = 23;
            this.unregisterForEvent.Text = "Unregister for Event";
            this.unregisterForEvent.UseVisualStyleBackColor = true;
            this.unregisterForEvent.Click += new System.EventHandler(this.unregisterForEvent_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "max users:";
            // 
            // maxUsers
            // 
            this.maxUsers.Location = new System.Drawing.Point(75, 121);
            this.maxUsers.Name = "maxUsers";
            this.maxUsers.ReadOnly = true;
            this.maxUsers.Size = new System.Drawing.Size(180, 20);
            this.maxUsers.TabIndex = 28;
            // 
            // findId
            // 
            this.findId.Location = new System.Drawing.Point(11, 282);
            this.findId.Name = "findId";
            this.findId.Size = new System.Drawing.Size(79, 20);
            this.findId.TabIndex = 29;
            // 
            // findLocal
            // 
            this.findLocal.Location = new System.Drawing.Point(96, 280);
            this.findLocal.Name = "findLocal";
            this.findLocal.Size = new System.Drawing.Size(75, 23);
            this.findLocal.TabIndex = 30;
            this.findLocal.Text = "Find Local";
            this.findLocal.UseVisualStyleBackColor = true;
            this.findLocal.Click += new System.EventHandler(this.findLocal_Click);
            // 
            // findXuid
            // 
            this.findXuid.Location = new System.Drawing.Point(177, 280);
            this.findXuid.Name = "findXuid";
            this.findXuid.Size = new System.Drawing.Size(78, 23);
            this.findXuid.TabIndex = 31;
            this.findXuid.Text = "Find XUID";
            this.findXuid.UseVisualStyleBackColor = true;
            this.findXuid.Click += new System.EventHandler(this.findXuid_Click);
            // 
            // duplicateUserHandle
            // 
            this.duplicateUserHandle.Location = new System.Drawing.Point(96, 147);
            this.duplicateUserHandle.Name = "duplicateUserHandle";
            this.duplicateUserHandle.Size = new System.Drawing.Size(75, 31);
            this.duplicateUserHandle.TabIndex = 32;
            this.duplicateUserHandle.Text = "Dupe";
            this.duplicateUserHandle.UseVisualStyleBackColor = true;
            this.duplicateUserHandle.Click += new System.EventHandler(this.duplicateUserHandle_Click);
            // 
            // compareHandle
            // 
            this.compareHandle.Location = new System.Drawing.Point(177, 147);
            this.compareHandle.Name = "compareHandle";
            this.compareHandle.Size = new System.Drawing.Size(75, 31);
            this.compareHandle.TabIndex = 33;
            this.compareHandle.Text = "Compare";
            this.compareHandle.UseVisualStyleBackColor = true;
            this.compareHandle.Click += new System.EventHandler(this.compareHandle_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.getTokenAndSignatureButton);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.getTokenAndSignatureBody);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.getTokenAndSignatureMethod);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.getTokenAndSignatureUrl);
            this.groupBox2.Location = new System.Drawing.Point(599, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 286);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GetTokenAndSignature";
            // 
            // getTokenAndSignatureButton
            // 
            this.getTokenAndSignatureButton.Location = new System.Drawing.Point(9, 245);
            this.getTokenAndSignatureButton.Name = "getTokenAndSignatureButton";
            this.getTokenAndSignatureButton.Size = new System.Drawing.Size(188, 35);
            this.getTokenAndSignatureButton.TabIndex = 6;
            this.getTokenAndSignatureButton.Text = "GetTokenAndSignature";
            this.getTokenAndSignatureButton.UseVisualStyleBackColor = true;
            this.getTokenAndSignatureButton.Click += new System.EventHandler(this.getTokenAndSignatureButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Body:";
            // 
            // getTokenAndSignatureBody
            // 
            this.getTokenAndSignatureBody.Location = new System.Drawing.Point(52, 71);
            this.getTokenAndSignatureBody.Multiline = true;
            this.getTokenAndSignatureBody.Name = "getTokenAndSignatureBody";
            this.getTokenAndSignatureBody.Size = new System.Drawing.Size(142, 165);
            this.getTokenAndSignatureBody.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Method:";
            // 
            // getTokenAndSignatureMethod
            // 
            this.getTokenAndSignatureMethod.Location = new System.Drawing.Point(52, 45);
            this.getTokenAndSignatureMethod.Name = "getTokenAndSignatureMethod";
            this.getTokenAndSignatureMethod.Size = new System.Drawing.Size(142, 20);
            this.getTokenAndSignatureMethod.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "URL:";
            // 
            // getTokenAndSignatureUrl
            // 
            this.getTokenAndSignatureUrl.Location = new System.Drawing.Point(52, 19);
            this.getTokenAndSignatureUrl.Name = "getTokenAndSignatureUrl";
            this.getTokenAndSignatureUrl.Size = new System.Drawing.Size(142, 20);
            this.getTokenAndSignatureUrl.TabIndex = 0;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 606);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.compareHandle);
            this.Controls.Add(this.duplicateUserHandle);
            this.Controls.Add(this.findXuid);
            this.Controls.Add(this.findLocal);
            this.Controls.Add(this.findId);
            this.Controls.Add(this.maxUsers);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.deferSignOut);
            this.Controls.Add(this.unregisterForEvent);
            this.Controls.Add(this.registerForEvent);
            this.Controls.Add(this.resolveIssue);
            this.Controls.Add(this.closeUserHandle);
            this.Controls.Add(this.log);
            this.Controls.Add(this.signedInUsers);
            this.Controls.Add(this.addUserOptions);
            this.Controls.Add(this.addUser);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserForm";
            this.Text = "UserForm";
            ((System.ComponentModel.ISupportInitialize)(this.gamerpic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addUser;
        private System.Windows.Forms.ListBox addUserOptions;
        private System.Windows.Forms.ListBox signedInUsers;
        private System.Windows.Forms.TextBox gamertag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox localId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.PictureBox gamerpic;
        private System.Windows.Forms.ListBox privileges;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.Button closeUserHandle;
        private System.Windows.Forms.Button resolveIssue;
        private System.Windows.Forms.Button resolveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox disallowedPrivileges;
        private System.Windows.Forms.TextBox ageGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.TextBox status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox isGuest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button registerForEvent;
        private System.Windows.Forms.CheckBox deferSignOut;
        private System.Windows.Forms.Button unregisterForEvent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox maxUsers;
        private System.Windows.Forms.TextBox findId;
        private System.Windows.Forms.Button findLocal;
        private System.Windows.Forms.Button findXuid;
        private System.Windows.Forms.Button duplicateUserHandle;
        private System.Windows.Forms.Button compareHandle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button getTokenAndSignatureButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox getTokenAndSignatureBody;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox getTokenAndSignatureMethod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox getTokenAndSignatureUrl;
    }
}