namespace TestGame
{
    partial class XblMultiplayerForm
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
            this.GetActivitiesForUsers = new System.Windows.Forms.Button();
            this.GetActivitiesForSocialGroup = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OwnerXuidTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PlayerXuidTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.XuidsListBox = new System.Windows.Forms.ListBox();
            this.AddPlayerXuid = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SocialGroupListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // GetActivitiesForUsers
            // 
            this.GetActivitiesForUsers.Enabled = false;
            this.GetActivitiesForUsers.Location = new System.Drawing.Point(275, 61);
            this.GetActivitiesForUsers.Margin = new System.Windows.Forms.Padding(6);
            this.GetActivitiesForUsers.Name = "GetActivitiesForUsers";
            this.GetActivitiesForUsers.Size = new System.Drawing.Size(264, 70);
            this.GetActivitiesForUsers.TabIndex = 16;
            this.GetActivitiesForUsers.Text = "Get Activities For Players";
            this.GetActivitiesForUsers.UseVisualStyleBackColor = true;
            this.GetActivitiesForUsers.Click += new System.EventHandler(this.GetActivitiesForUser_Click);
            // 
            // GetActivitiesForSocialGroup
            // 
            this.GetActivitiesForSocialGroup.Enabled = false;
            this.GetActivitiesForSocialGroup.Location = new System.Drawing.Point(714, 221);
            this.GetActivitiesForSocialGroup.Margin = new System.Windows.Forms.Padding(6);
            this.GetActivitiesForSocialGroup.Name = "GetActivitiesForSocialGroup";
            this.GetActivitiesForSocialGroup.Size = new System.Drawing.Size(264, 70);
            this.GetActivitiesForSocialGroup.TabIndex = 17;
            this.GetActivitiesForSocialGroup.Text = "Get Activities For Social Group";
            this.GetActivitiesForSocialGroup.UseVisualStyleBackColor = true;
            this.GetActivitiesForSocialGroup.Click += new System.EventHandler(this.GetActivitiesForSocialGroup_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(20, 423);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1423, 384);
            this.textBox1.TabIndex = 30;
            // 
            // OwnerXuidTextBox
            // 
            this.OwnerXuidTextBox.Location = new System.Drawing.Point(709, 61);
            this.OwnerXuidTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.OwnerXuidTextBox.Name = "OwnerXuidTextBox";
            this.OwnerXuidTextBox.Size = new System.Drawing.Size(261, 29);
            this.OwnerXuidTextBox.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(709, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 29;
            this.label3.Text = "Xuid";
            // 
            // PlayerXuidTextBox
            // 
            this.PlayerXuidTextBox.Location = new System.Drawing.Point(20, 61);
            this.PlayerXuidTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.PlayerXuidTextBox.Name = "PlayerXuidTextBox";
            this.PlayerXuidTextBox.Size = new System.Drawing.Size(217, 29);
            this.PlayerXuidTextBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 175);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Players";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Player Xuid";
            // 
            // XuidsListBox
            // 
            this.XuidsListBox.FormattingEnabled = true;
            this.XuidsListBox.ItemHeight = 24;
            this.XuidsListBox.Location = new System.Drawing.Point(25, 205);
            this.XuidsListBox.Margin = new System.Windows.Forms.Padding(6);
            this.XuidsListBox.Name = "XuidsListBox";
            this.XuidsListBox.Size = new System.Drawing.Size(220, 196);
            this.XuidsListBox.TabIndex = 18;
            // 
            // AddPlayerXuid
            // 
            this.AddPlayerXuid.Enabled = false;
            this.AddPlayerXuid.Location = new System.Drawing.Point(20, 103);
            this.AddPlayerXuid.Margin = new System.Windows.Forms.Padding(6);
            this.AddPlayerXuid.Name = "AddPlayerXuid";
            this.AddPlayerXuid.Size = new System.Drawing.Size(220, 50);
            this.AddPlayerXuid.TabIndex = 20;
            this.AddPlayerXuid.Text = "Add Player";
            this.AddPlayerXuid.UseVisualStyleBackColor = true;
            this.AddPlayerXuid.Click += new System.EventHandler(this.AddPlayerXuid_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(714, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "Social Group";
            // 
            // SocialGroupListBox
            // 
            this.SocialGroupListBox.FormattingEnabled = true;
            this.SocialGroupListBox.ItemHeight = 24;
            this.SocialGroupListBox.Items.AddRange(new object[] {
            "people",
            "favorites"});
            this.SocialGroupListBox.Location = new System.Drawing.Point(714, 134);
            this.SocialGroupListBox.Margin = new System.Windows.Forms.Padding(6);
            this.SocialGroupListBox.Name = "SocialGroupListBox";
            this.SocialGroupListBox.Size = new System.Drawing.Size(217, 76);
            this.SocialGroupListBox.TabIndex = 32;
            // 
            // XblMultiplayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 831);
            this.Controls.Add(this.SocialGroupListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OwnerXuidTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddPlayerXuid);
            this.Controls.Add(this.PlayerXuidTextBox);
            this.Controls.Add(this.XuidsListBox);
            this.Controls.Add(this.GetActivitiesForSocialGroup);
            this.Controls.Add(this.GetActivitiesForUsers);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "XblMultiplayerForm";
            this.Text = "MultiplayerActivityForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetActivitiesForUsers;
        private System.Windows.Forms.Button GetActivitiesForSocialGroup;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox OwnerXuidTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PlayerXuidTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox XuidsListBox;
        private System.Windows.Forms.Button AddPlayerXuid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox SocialGroupListBox;
    }
}