namespace TestGame
{
    partial class XblProfileForm
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
            this.GetUserProfiles = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PlayerXuidTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.XuidsListBox = new System.Windows.Forms.ListBox();
            this.AddPlayerXuid = new System.Windows.Forms.Button();
            this.GetUserProfile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SocialGroupListBox = new System.Windows.Forms.ListBox();
            this.GetSocialUserProfiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetUserProfiles
            // 
            this.GetUserProfiles.Enabled = false;
            this.GetUserProfiles.Location = new System.Drawing.Point(151, 155);
            this.GetUserProfiles.Name = "GetUserProfiles";
            this.GetUserProfiles.Size = new System.Drawing.Size(144, 38);
            this.GetUserProfiles.TabIndex = 16;
            this.GetUserProfiles.Text = "Get All User Profiles";
            this.GetUserProfiles.UseVisualStyleBackColor = true;
            this.GetUserProfiles.Click += new System.EventHandler(this.GetUserProfiles_Click);
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
            // PlayerXuidTextBox
            // 
            this.PlayerXuidTextBox.Location = new System.Drawing.Point(11, 33);
            this.PlayerXuidTextBox.Name = "PlayerXuidTextBox";
            this.PlayerXuidTextBox.Size = new System.Drawing.Size(120, 20);
            this.PlayerXuidTextBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Players";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Player Xuid";
            // 
            // XuidsListBox
            // 
            this.XuidsListBox.FormattingEnabled = true;
            this.XuidsListBox.Location = new System.Drawing.Point(14, 111);
            this.XuidsListBox.Name = "XuidsListBox";
            this.XuidsListBox.Size = new System.Drawing.Size(122, 108);
            this.XuidsListBox.TabIndex = 18;
            // 
            // AddPlayerXuid
            // 
            this.AddPlayerXuid.Enabled = false;
            this.AddPlayerXuid.Location = new System.Drawing.Point(11, 56);
            this.AddPlayerXuid.Name = "AddPlayerXuid";
            this.AddPlayerXuid.Size = new System.Drawing.Size(120, 27);
            this.AddPlayerXuid.TabIndex = 20;
            this.AddPlayerXuid.Text = "Add Player";
            this.AddPlayerXuid.UseVisualStyleBackColor = true;
            this.AddPlayerXuid.Click += new System.EventHandler(this.AddPlayerXuid_Click);
            // 
            // GetUserProfile
            // 
            this.GetUserProfile.Enabled = false;
            this.GetUserProfile.Location = new System.Drawing.Point(151, 111);
            this.GetUserProfile.Name = "GetUserProfile";
            this.GetUserProfile.Size = new System.Drawing.Size(144, 38);
            this.GetUserProfile.TabIndex = 31;
            this.GetUserProfile.Text = "Get Selected User Profile";
            this.GetUserProfile.UseVisualStyleBackColor = true;
            this.GetUserProfile.Click += new System.EventHandler(this.GetUserProfile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Social Group";
            // 
            // SocialGroupListBox
            // 
            this.SocialGroupListBox.FormattingEnabled = true;
            this.SocialGroupListBox.Items.AddRange(new object[] {
            "Favorites",
            "People"});
            this.SocialGroupListBox.Location = new System.Drawing.Point(558, 41);
            this.SocialGroupListBox.Name = "SocialGroupListBox";
            this.SocialGroupListBox.Size = new System.Drawing.Size(122, 43);
            this.SocialGroupListBox.TabIndex = 34;
            // 
            // GetSocialUserProfiles
            // 
            this.GetSocialUserProfiles.Enabled = false;
            this.GetSocialUserProfiles.Location = new System.Drawing.Point(558, 95);
            this.GetSocialUserProfiles.Name = "GetSocialUserProfiles";
            this.GetSocialUserProfiles.Size = new System.Drawing.Size(144, 38);
            this.GetSocialUserProfiles.TabIndex = 35;
            this.GetSocialUserProfiles.Text = "Get User Profiles for Social Group";
            this.GetSocialUserProfiles.UseVisualStyleBackColor = true;
            this.GetSocialUserProfiles.Click += new System.EventHandler(this.GetSocialUserProfiles_Click);
            // 
            // XblProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GetSocialUserProfiles);
            this.Controls.Add(this.SocialGroupListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GetUserProfile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddPlayerXuid);
            this.Controls.Add(this.PlayerXuidTextBox);
            this.Controls.Add(this.XuidsListBox);
            this.Controls.Add(this.GetUserProfiles);
            this.Name = "XblProfileForm";
            this.Text = "XblProfileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetUserProfiles;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox PlayerXuidTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox XuidsListBox;
        private System.Windows.Forms.Button AddPlayerXuid;
        private System.Windows.Forms.Button GetUserProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox SocialGroupListBox;
        private System.Windows.Forms.Button GetSocialUserProfiles;
    }
}