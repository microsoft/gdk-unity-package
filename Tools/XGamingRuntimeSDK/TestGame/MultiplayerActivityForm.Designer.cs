namespace TestGame
{
    partial class MultiplayerActivityForm
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
            this.UpdateRecentPlayers = new System.Windows.Forms.Button();
            this.FlushRecentPlayers = new System.Windows.Forms.Button();
            this.PendingRecentPlayersListBox = new System.Windows.Forms.ListBox();
            this.RecentPlayerXuidTextBox = new System.Windows.Forms.TextBox();
            this.AddRecentPlayerXuid = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SetActivity = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GetActivities = new System.Windows.Forms.Button();
            this.DeleteActivity = new System.Windows.Forms.Button();
            this.SendInvite = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.XuidToInviteTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EncounterTypeListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // UpdateRecentPlayers
            // 
            this.UpdateRecentPlayers.Enabled = false;
            this.UpdateRecentPlayers.Location = new System.Drawing.Point(308, 12);
            this.UpdateRecentPlayers.Name = "UpdateRecentPlayers";
            this.UpdateRecentPlayers.Size = new System.Drawing.Size(144, 38);
            this.UpdateRecentPlayers.TabIndex = 16;
            this.UpdateRecentPlayers.Text = "Update Recent Players";
            this.UpdateRecentPlayers.UseVisualStyleBackColor = true;
            this.UpdateRecentPlayers.Click += new System.EventHandler(this.UpdateRecentPlayers_Click);
            // 
            // FlushRecentPlayers
            // 
            this.FlushRecentPlayers.Enabled = false;
            this.FlushRecentPlayers.Location = new System.Drawing.Point(308, 56);
            this.FlushRecentPlayers.Name = "FlushRecentPlayers";
            this.FlushRecentPlayers.Size = new System.Drawing.Size(144, 38);
            this.FlushRecentPlayers.TabIndex = 17;
            this.FlushRecentPlayers.Text = "Flush Recent Players";
            this.FlushRecentPlayers.UseVisualStyleBackColor = true;
            this.FlushRecentPlayers.Click += new System.EventHandler(this.FlushRecentPlayers_Click);
            // 
            // PendingRecentPlayersListBox
            // 
            this.PendingRecentPlayersListBox.FormattingEnabled = true;
            this.PendingRecentPlayersListBox.Location = new System.Drawing.Point(140, 33);
            this.PendingRecentPlayersListBox.Name = "PendingRecentPlayersListBox";
            this.PendingRecentPlayersListBox.Size = new System.Drawing.Size(162, 147);
            this.PendingRecentPlayersListBox.TabIndex = 18;
            // 
            // RecentPlayerXuidTextBox
            // 
            this.RecentPlayerXuidTextBox.Location = new System.Drawing.Point(11, 33);
            this.RecentPlayerXuidTextBox.Name = "RecentPlayerXuidTextBox";
            this.RecentPlayerXuidTextBox.Size = new System.Drawing.Size(120, 20);
            this.RecentPlayerXuidTextBox.TabIndex = 19;
            // 
            // AddRecentPlayerXuid
            // 
            this.AddRecentPlayerXuid.Enabled = false;
            this.AddRecentPlayerXuid.Location = new System.Drawing.Point(11, 128);
            this.AddRecentPlayerXuid.Name = "AddRecentPlayerXuid";
            this.AddRecentPlayerXuid.Size = new System.Drawing.Size(120, 27);
            this.AddRecentPlayerXuid.TabIndex = 20;
            this.AddRecentPlayerXuid.Text = "Add Recent Player";
            this.AddRecentPlayerXuid.UseVisualStyleBackColor = true;
            this.AddRecentPlayerXuid.Click += new System.EventHandler(this.AddRecentPlayerXuid_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Pending Recent Players";
            // 
            // SetActivity
            // 
            this.SetActivity.Enabled = false;
            this.SetActivity.Location = new System.Drawing.Point(461, 12);
            this.SetActivity.Name = "SetActivity";
            this.SetActivity.Size = new System.Drawing.Size(144, 38);
            this.SetActivity.TabIndex = 23;
            this.SetActivity.Text = "Set Activity";
            this.SetActivity.UseVisualStyleBackColor = true;
            this.SetActivity.Click += new System.EventHandler(this.SetActivity_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Recent Player Xuid";
            // 
            // GetActivities
            // 
            this.GetActivities.Enabled = false;
            this.GetActivities.Location = new System.Drawing.Point(461, 56);
            this.GetActivities.Name = "GetActivities";
            this.GetActivities.Size = new System.Drawing.Size(144, 38);
            this.GetActivities.TabIndex = 25;
            this.GetActivities.Text = "Get Activities";
            this.GetActivities.UseVisualStyleBackColor = true;
            this.GetActivities.Click += new System.EventHandler(this.GetActivities_Click);
            // 
            // DeleteActivity
            // 
            this.DeleteActivity.Enabled = false;
            this.DeleteActivity.Location = new System.Drawing.Point(461, 100);
            this.DeleteActivity.Name = "DeleteActivity";
            this.DeleteActivity.Size = new System.Drawing.Size(144, 38);
            this.DeleteActivity.TabIndex = 26;
            this.DeleteActivity.Text = "Delete Activity";
            this.DeleteActivity.UseVisualStyleBackColor = true;
            this.DeleteActivity.Click += new System.EventHandler(this.DeleteActivity_Click);
            // 
            // SendInvite
            // 
            this.SendInvite.Enabled = false;
            this.SendInvite.Location = new System.Drawing.Point(611, 59);
            this.SendInvite.Name = "SendInvite";
            this.SendInvite.Size = new System.Drawing.Size(144, 38);
            this.SendInvite.TabIndex = 27;
            this.SendInvite.Text = "Send Invite";
            this.SendInvite.UseVisualStyleBackColor = true;
            this.SendInvite.Click += new System.EventHandler(this.SendInvite_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Xuid to Invite";
            // 
            // XuidToInviteTextBox
            // 
            this.XuidToInviteTextBox.Location = new System.Drawing.Point(611, 33);
            this.XuidToInviteTextBox.Name = "XuidToInviteTextBox";
            this.XuidToInviteTextBox.Size = new System.Drawing.Size(144, 20);
            this.XuidToInviteTextBox.TabIndex = 28;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(11, 229);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(778, 210);
            this.textBox1.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "EncounterType";
            // 
            // EncounterTypeListBox
            // 
            this.EncounterTypeListBox.FormattingEnabled = true;
            this.EncounterTypeListBox.Items.AddRange(new object[] {
            "Default",
            "Teammate",
            "Opponent"});
            this.EncounterTypeListBox.Location = new System.Drawing.Point(11, 75);
            this.EncounterTypeListBox.Name = "EncounterTypeListBox";
            this.EncounterTypeListBox.Size = new System.Drawing.Size(120, 43);
            this.EncounterTypeListBox.TabIndex = 32;
            // 
            // MultiplayerActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EncounterTypeListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.XuidToInviteTextBox);
            this.Controls.Add(this.SendInvite);
            this.Controls.Add(this.DeleteActivity);
            this.Controls.Add(this.GetActivities);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SetActivity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddRecentPlayerXuid);
            this.Controls.Add(this.RecentPlayerXuidTextBox);
            this.Controls.Add(this.PendingRecentPlayersListBox);
            this.Controls.Add(this.FlushRecentPlayers);
            this.Controls.Add(this.UpdateRecentPlayers);
            this.Name = "MultiplayerActivityForm";
            this.Text = "MultiplayerActivityForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdateRecentPlayers;
        private System.Windows.Forms.Button FlushRecentPlayers;
        private System.Windows.Forms.ListBox PendingRecentPlayersListBox;
        private System.Windows.Forms.TextBox RecentPlayerXuidTextBox;
        private System.Windows.Forms.Button AddRecentPlayerXuid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SetActivity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GetActivities;
        private System.Windows.Forms.Button DeleteActivity;
        private System.Windows.Forms.Button SendInvite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox XuidToInviteTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox EncounterTypeListBox;
    }
}