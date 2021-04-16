namespace TestGame
{
    partial class XboxLiveForm
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
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.XBLVerticalLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.XBLHorizontalLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.fetchAchievementsButton = new System.Windows.Forms.Button();
            this.earnAchievementButton = new System.Windows.Forms.Button();
            this.solvePuzzleButton = new System.Windows.Forms.Button();
            this.getStatsButton = new System.Windows.Forms.Button();
            this.getLeaderboardButton = new System.Windows.Forms.Button();
            this.testSocialManagerButton = new System.Windows.Forms.Button();
            this.getSocialManagerUsersButton = new System.Windows.Forms.Button();
            this.destroySocialButton = new System.Windows.Forms.Button();
            this.lookupErrorButton = new System.Windows.Forms.Button();
            this.errorCodeTextBox = new System.Windows.Forms.TextBox();
            this.makeHttpCallButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.XBLVerticalLayout.SuspendLayout();
            this.XBLHorizontalLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // logTextBox
            // 
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.logTextBox.Location = new System.Drawing.Point(3, 269);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(800, 287);
            this.logTextBox.TabIndex = 0;
            // 
            // XBLVerticalLayout
            // 
            this.XBLVerticalLayout.Controls.Add(this.XBLHorizontalLayout);
            this.XBLVerticalLayout.Controls.Add(this.listView1);
            this.XBLVerticalLayout.Controls.Add(this.logTextBox);
            this.XBLVerticalLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XBLVerticalLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.XBLVerticalLayout.Location = new System.Drawing.Point(0, 0);
            this.XBLVerticalLayout.Name = "XBLVerticalLayout";
            this.XBLVerticalLayout.Size = new System.Drawing.Size(800, 565);
            this.XBLVerticalLayout.TabIndex = 1;
            // 
            // XBLHorizontalLayout
            // 
            this.XBLHorizontalLayout.Controls.Add(this.fetchAchievementsButton);
            this.XBLHorizontalLayout.Controls.Add(this.earnAchievementButton);
            this.XBLHorizontalLayout.Controls.Add(this.solvePuzzleButton);
            this.XBLHorizontalLayout.Controls.Add(this.getStatsButton);
            this.XBLHorizontalLayout.Controls.Add(this.getLeaderboardButton);
            this.XBLHorizontalLayout.Controls.Add(this.testSocialManagerButton);
            this.XBLHorizontalLayout.Controls.Add(this.getSocialManagerUsersButton);
            this.XBLHorizontalLayout.Controls.Add(this.destroySocialButton);
            this.XBLHorizontalLayout.Controls.Add(this.lookupErrorButton);
            this.XBLHorizontalLayout.Controls.Add(this.errorCodeTextBox);
            this.XBLHorizontalLayout.Controls.Add(this.makeHttpCallButton);
            this.XBLHorizontalLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.XBLHorizontalLayout.Location = new System.Drawing.Point(3, 3);
            this.XBLHorizontalLayout.Name = "XBLHorizontalLayout";
            this.XBLHorizontalLayout.Size = new System.Drawing.Size(800, 62);
            this.XBLHorizontalLayout.TabIndex = 2;
            // 
            // fetchAchievementsButton
            // 
            this.fetchAchievementsButton.Enabled = false;
            this.fetchAchievementsButton.Location = new System.Drawing.Point(3, 3);
            this.fetchAchievementsButton.Name = "fetchAchievementsButton";
            this.fetchAchievementsButton.Size = new System.Drawing.Size(140, 23);
            this.fetchAchievementsButton.TabIndex = 1;
            this.fetchAchievementsButton.Text = "Fetch achievements";
            this.fetchAchievementsButton.UseVisualStyleBackColor = true;
            this.fetchAchievementsButton.Click += new System.EventHandler(this.fetchAchievementsButton_Click);
            // 
            // earnAchievementButton
            // 
            this.earnAchievementButton.Enabled = false;
            this.earnAchievementButton.Location = new System.Drawing.Point(149, 3);
            this.earnAchievementButton.Name = "earnAchievementButton";
            this.earnAchievementButton.Size = new System.Drawing.Size(169, 23);
            this.earnAchievementButton.TabIndex = 2;
            this.earnAchievementButton.Text = "Earn selected achievement";
            this.earnAchievementButton.UseVisualStyleBackColor = true;
            this.earnAchievementButton.Click += new System.EventHandler(this.earnAchievementButton_Click);
            // 
            // solvePuzzleButton
            // 
            this.solvePuzzleButton.Location = new System.Drawing.Point(324, 3);
            this.solvePuzzleButton.Name = "solvePuzzleButton";
            this.solvePuzzleButton.Size = new System.Drawing.Size(102, 23);
            this.solvePuzzleButton.TabIndex = 3;
            this.solvePuzzleButton.Text = "Solve a Puzzle";
            this.solvePuzzleButton.UseVisualStyleBackColor = true;
            this.solvePuzzleButton.Click += new System.EventHandler(this.solvePuzzleButton_Click);
            // 
            // getStatsButton
            // 
            this.getStatsButton.Location = new System.Drawing.Point(432, 3);
            this.getStatsButton.Name = "getStatsButton";
            this.getStatsButton.Size = new System.Drawing.Size(77, 23);
            this.getStatsButton.TabIndex = 4;
            this.getStatsButton.Text = "Get Stats";
            this.getStatsButton.UseVisualStyleBackColor = true;
            this.getStatsButton.Click += new System.EventHandler(this.getStatsButton_Click);
            // 
            // getLeaderboardButton
            // 
            this.getLeaderboardButton.Location = new System.Drawing.Point(515, 3);
            this.getLeaderboardButton.Name = "getLeaderboardButton";
            this.getLeaderboardButton.Size = new System.Drawing.Size(99, 23);
            this.getLeaderboardButton.TabIndex = 5;
            this.getLeaderboardButton.Text = "Get Leaderboard";
            this.getLeaderboardButton.UseVisualStyleBackColor = true;
            this.getLeaderboardButton.Click += new System.EventHandler(this.getLeaderboardButton_Click);
            // 
            // testSocialManagerButton
            // 
            this.testSocialManagerButton.Location = new System.Drawing.Point(620, 3);
            this.testSocialManagerButton.Name = "testSocialManagerButton";
            this.testSocialManagerButton.Size = new System.Drawing.Size(110, 23);
            this.testSocialManagerButton.TabIndex = 6;
            this.testSocialManagerButton.Text = "Init Social Manager";
            this.testSocialManagerButton.UseVisualStyleBackColor = true;
            this.testSocialManagerButton.Click += new System.EventHandler(this.testSocialManagerButton_Click);
            // 
            // getSocialManagerUsersButton
            // 
            this.getSocialManagerUsersButton.Location = new System.Drawing.Point(3, 32);
            this.getSocialManagerUsersButton.Name = "getSocialManagerUsersButton";
            this.getSocialManagerUsersButton.Size = new System.Drawing.Size(150, 23);
            this.getSocialManagerUsersButton.TabIndex = 7;
            this.getSocialManagerUsersButton.Text = "Get Social Manager Users";
            this.getSocialManagerUsersButton.UseVisualStyleBackColor = true;
            this.getSocialManagerUsersButton.Click += new System.EventHandler(this.getSocialManagerUsersButton_Click);
            // 
            // destroySocialButton
            // 
            this.destroySocialButton.Location = new System.Drawing.Point(159, 32);
            this.destroySocialButton.Name = "destroySocialButton";
            this.destroySocialButton.Size = new System.Drawing.Size(110, 23);
            this.destroySocialButton.TabIndex = 8;
            this.destroySocialButton.Text = "Destroy Social Manager";
            this.destroySocialButton.UseVisualStyleBackColor = true;
            this.destroySocialButton.Click += new System.EventHandler(this.destroySocialButton_Click);
            // 
            // lookupErrorButton
            // 
            this.lookupErrorButton.Location = new System.Drawing.Point(275, 32);
            this.lookupErrorButton.Name = "lookupErrorButton";
            this.lookupErrorButton.Size = new System.Drawing.Size(77, 23);
            this.lookupErrorButton.TabIndex = 9;
            this.lookupErrorButton.Text = "Lookup Error";
            this.lookupErrorButton.UseVisualStyleBackColor = true;
            this.lookupErrorButton.Click += new System.EventHandler(this.lookupErrorButton_Click);
            // 
            // errorCodeTextBox
            // 
            this.errorCodeTextBox.Location = new System.Drawing.Point(358, 32);
            this.errorCodeTextBox.Name = "errorCodeTextBox";
            this.errorCodeTextBox.Size = new System.Drawing.Size(81, 20);
            this.errorCodeTextBox.TabIndex = 10;
            this.errorCodeTextBox.Text = "0x80190194";
            // 
            // makeHttpCallButton
            // 
            this.makeHttpCallButton.Location = new System.Drawing.Point(445, 32);
            this.makeHttpCallButton.Name = "makeHttpCallButton";
            this.makeHttpCallButton.Size = new System.Drawing.Size(99, 23);
            this.makeHttpCallButton.TabIndex = 11;
            this.makeHttpCallButton.Text = "Make Http Call";
            this.makeHttpCallButton.UseVisualStyleBackColor = true;
            this.makeHttpCallButton.Click += new System.EventHandler(this.makeHttpCallButton_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 71);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(797, 192);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView1_ItemSelectionChanged);
            // 
            // XboxLiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.XBLVerticalLayout);
            this.Name = "XboxLiveForm";
            this.Text = "XboxLiveForm";
            this.XBLVerticalLayout.ResumeLayout(false);
            this.XBLVerticalLayout.PerformLayout();
            this.XBLHorizontalLayout.ResumeLayout(false);
            this.XBLHorizontalLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.FlowLayoutPanel XBLVerticalLayout;
        private System.Windows.Forms.Button fetchAchievementsButton;
        private System.Windows.Forms.FlowLayoutPanel XBLHorizontalLayout;
        private System.Windows.Forms.Button earnAchievementButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button solvePuzzleButton;
        private System.Windows.Forms.Button getStatsButton;
        private System.Windows.Forms.Button getLeaderboardButton;
        private System.Windows.Forms.Button testSocialManagerButton;
        private System.Windows.Forms.Button getSocialManagerUsersButton;
        private System.Windows.Forms.Button destroySocialButton;
        private System.Windows.Forms.Button lookupErrorButton;
        private System.Windows.Forms.TextBox errorCodeTextBox;
        private System.Windows.Forms.Button makeHttpCallButton;
    }
}