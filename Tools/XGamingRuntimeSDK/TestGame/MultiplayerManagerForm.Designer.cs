namespace TestGame
{
    partial class MultiplayerManagerForm
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
            this.initButton = new System.Windows.Forms.Button();
            this.addUserButton = new System.Windows.Forms.Button();
            this.lobbyUserList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inviteFriendsButton = new System.Windows.Forms.Button();
            this.registerForInvitesButton = new System.Windows.Forms.Button();
            this.unregisterForInvitesButton = new System.Windows.Forms.Button();
            this.joinLobbyButton = new System.Windows.Forms.Button();
            this.lobbyHandleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.setSessionPropsButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.listLobbyMembersButton = new System.Windows.Forms.Button();
            this.searchForSessionButton = new System.Windows.Forms.Button();
            this.deleteSearchHandleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(15, 369);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1036, 258);
            this.textBox1.TabIndex = 14;
            // 
            // initButton
            // 
            this.initButton.Enabled = false;
            this.initButton.Location = new System.Drawing.Point(17, 16);
            this.initButton.Margin = new System.Windows.Forms.Padding(4);
            this.initButton.Name = "initButton";
            this.initButton.Size = new System.Drawing.Size(192, 47);
            this.initButton.TabIndex = 15;
            this.initButton.Text = "Initialize";
            this.initButton.UseVisualStyleBackColor = true;
            this.initButton.Click += new System.EventHandler(this.initButton_Click);
            // 
            // addUserButton
            // 
            this.addUserButton.Enabled = false;
            this.addUserButton.Location = new System.Drawing.Point(16, 70);
            this.addUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(192, 49);
            this.addUserButton.TabIndex = 16;
            this.addUserButton.Text = "Add User";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // lobbyUserList
            // 
            this.lobbyUserList.FormattingEnabled = true;
            this.lobbyUserList.Location = new System.Drawing.Point(639, 38);
            this.lobbyUserList.Margin = new System.Windows.Forms.Padding(4);
            this.lobbyUserList.Name = "lobbyUserList";
            this.lobbyUserList.Size = new System.Drawing.Size(184, 259);
            this.lobbyUserList.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(639, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Lobby Users";
            // 
            // inviteFriendsButton
            // 
            this.inviteFriendsButton.Enabled = false;
            this.inviteFriendsButton.Location = new System.Drawing.Point(16, 127);
            this.inviteFriendsButton.Margin = new System.Windows.Forms.Padding(4);
            this.inviteFriendsButton.Name = "inviteFriendsButton";
            this.inviteFriendsButton.Size = new System.Drawing.Size(192, 49);
            this.inviteFriendsButton.TabIndex = 19;
            this.inviteFriendsButton.Text = "Invite Friends";
            this.inviteFriendsButton.UseVisualStyleBackColor = true;
            this.inviteFriendsButton.Click += new System.EventHandler(this.inviteFriendsButton_Click);
            // 
            // registerForInvitesButton
            // 
            this.registerForInvitesButton.Enabled = false;
            this.registerForInvitesButton.Location = new System.Drawing.Point(16, 183);
            this.registerForInvitesButton.Margin = new System.Windows.Forms.Padding(4);
            this.registerForInvitesButton.Name = "registerForInvitesButton";
            this.registerForInvitesButton.Size = new System.Drawing.Size(192, 49);
            this.registerForInvitesButton.TabIndex = 20;
            this.registerForInvitesButton.Text = "Register for Invites";
            this.registerForInvitesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.registerForInvitesButton.UseVisualStyleBackColor = true;
            this.registerForInvitesButton.Click += new System.EventHandler(this.registerForInvitesButton_Click);
            // 
            // unregisterForInvitesButton
            // 
            this.unregisterForInvitesButton.Enabled = false;
            this.unregisterForInvitesButton.Location = new System.Drawing.Point(216, 183);
            this.unregisterForInvitesButton.Margin = new System.Windows.Forms.Padding(4);
            this.unregisterForInvitesButton.Name = "unregisterForInvitesButton";
            this.unregisterForInvitesButton.Size = new System.Drawing.Size(192, 49);
            this.unregisterForInvitesButton.TabIndex = 21;
            this.unregisterForInvitesButton.Text = "Unregister";
            this.unregisterForInvitesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.unregisterForInvitesButton.UseVisualStyleBackColor = true;
            this.unregisterForInvitesButton.Click += new System.EventHandler(this.unregisterForInvitesButton_Click);
            // 
            // joinLobbyButton
            // 
            this.joinLobbyButton.Enabled = false;
            this.joinLobbyButton.Location = new System.Drawing.Point(17, 240);
            this.joinLobbyButton.Margin = new System.Windows.Forms.Padding(4);
            this.joinLobbyButton.Name = "joinLobbyButton";
            this.joinLobbyButton.Size = new System.Drawing.Size(192, 49);
            this.joinLobbyButton.TabIndex = 22;
            this.joinLobbyButton.Text = "Join lobby";
            this.joinLobbyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.joinLobbyButton.UseVisualStyleBackColor = true;
            this.joinLobbyButton.Click += new System.EventHandler(this.joinLobbyButton_Click);
            // 
            // lobbyHandleTextBox
            // 
            this.lobbyHandleTextBox.Location = new System.Drawing.Point(219, 263);
            this.lobbyHandleTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.lobbyHandleTextBox.Name = "lobbyHandleTextBox";
            this.lobbyHandleTextBox.Size = new System.Drawing.Size(307, 22);
            this.lobbyHandleTextBox.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 245);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Lobby Handle:";
            // 
            // setSessionPropsButton
            // 
            this.setSessionPropsButton.Enabled = false;
            this.setSessionPropsButton.Location = new System.Drawing.Point(832, 38);
            this.setSessionPropsButton.Margin = new System.Windows.Forms.Padding(4);
            this.setSessionPropsButton.Name = "setSessionPropsButton";
            this.setSessionPropsButton.Size = new System.Drawing.Size(192, 49);
            this.setSessionPropsButton.TabIndex = 25;
            this.setSessionPropsButton.Text = "Set session props";
            this.setSessionPropsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.setSessionPropsButton.UseVisualStyleBackColor = true;
            this.setSessionPropsButton.Click += new System.EventHandler(this.setSessionPropsButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(17, 297);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(192, 49);
            this.searchButton.TabIndex = 26;
            this.searchButton.Text = "Create Search Handle";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // listLobbyMembersButton
            // 
            this.listLobbyMembersButton.Enabled = false;
            this.listLobbyMembersButton.Location = new System.Drawing.Point(831, 95);
            this.listLobbyMembersButton.Margin = new System.Windows.Forms.Padding(4);
            this.listLobbyMembersButton.Name = "listLobbyMembersButton";
            this.listLobbyMembersButton.Size = new System.Drawing.Size(192, 49);
            this.listLobbyMembersButton.TabIndex = 27;
            this.listLobbyMembersButton.Text = "List Lobby Members";
            this.listLobbyMembersButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.listLobbyMembersButton.UseVisualStyleBackColor = true;
            this.listLobbyMembersButton.Click += new System.EventHandler(this.listLobbyMembersButton_Click);
            // 
            // searchForSessionButton
            // 
            this.searchForSessionButton.Enabled = false;
            this.searchForSessionButton.Location = new System.Drawing.Point(216, 297);
            this.searchForSessionButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchForSessionButton.Name = "searchForSessionButton";
            this.searchForSessionButton.Size = new System.Drawing.Size(192, 49);
            this.searchForSessionButton.TabIndex = 28;
            this.searchForSessionButton.Text = "Search For Session";
            this.searchForSessionButton.UseVisualStyleBackColor = true;
            this.searchForSessionButton.Click += new System.EventHandler(this.searchForSessionButton_Click);
            // 
            // deleteSearchHandleButton
            // 
            this.deleteSearchHandleButton.Enabled = false;
            this.deleteSearchHandleButton.Location = new System.Drawing.Point(416, 297);
            this.deleteSearchHandleButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteSearchHandleButton.Name = "deleteSearchHandleButton";
            this.deleteSearchHandleButton.Size = new System.Drawing.Size(192, 49);
            this.deleteSearchHandleButton.TabIndex = 29;
            this.deleteSearchHandleButton.Text = "Delete Search Handle";
            this.deleteSearchHandleButton.UseVisualStyleBackColor = true;
            this.deleteSearchHandleButton.Click += new System.EventHandler(this.deleteSearchHandleButton_Click);
            // 
            // MultiplayerManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 642);
            this.Controls.Add(this.deleteSearchHandleButton);
            this.Controls.Add(this.searchForSessionButton);
            this.Controls.Add(this.listLobbyMembersButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.setSessionPropsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lobbyHandleTextBox);
            this.Controls.Add(this.joinLobbyButton);
            this.Controls.Add(this.unregisterForInvitesButton);
            this.Controls.Add(this.registerForInvitesButton);
            this.Controls.Add(this.inviteFriendsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lobbyUserList);
            this.Controls.Add(this.addUserButton);
            this.Controls.Add(this.initButton);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MultiplayerManagerForm";
            this.Text = "MultiplayerManagerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button initButton;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.CheckedListBox lobbyUserList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button inviteFriendsButton;
        private System.Windows.Forms.Button registerForInvitesButton;
        private System.Windows.Forms.Button unregisterForInvitesButton;
        private System.Windows.Forms.Button joinLobbyButton;
        private System.Windows.Forms.TextBox lobbyHandleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button setSessionPropsButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button listLobbyMembersButton;
        private System.Windows.Forms.Button searchForSessionButton;
        private System.Windows.Forms.Button deleteSearchHandleButton;
    }
}