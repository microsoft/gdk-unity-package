namespace TestGame
{
    partial class PrivacyForm
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
            this.xuids = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.permissionsList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkPermissionsButton = new System.Windows.Forms.Button();
            this.getMuteListButton = new System.Windows.Forms.Button();
            this.getAvoidListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 287);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(582, 294);
            this.textBox1.TabIndex = 16;
            // 
            // xuids
            // 
            this.xuids.Location = new System.Drawing.Point(81, 13);
            this.xuids.Multiline = true;
            this.xuids.Name = "xuids";
            this.xuids.Size = new System.Drawing.Size(186, 40);
            this.xuids.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Xuids:";
            // 
            // permissionsList
            // 
            this.permissionsList.FormattingEnabled = true;
            this.permissionsList.Location = new System.Drawing.Point(81, 59);
            this.permissionsList.Name = "permissionsList";
            this.permissionsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.permissionsList.Size = new System.Drawing.Size(186, 173);
            this.permissionsList.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Permissions:";
            // 
            // checkPermissionsButton
            // 
            this.checkPermissionsButton.Location = new System.Drawing.Point(81, 239);
            this.checkPermissionsButton.Name = "checkPermissionsButton";
            this.checkPermissionsButton.Size = new System.Drawing.Size(186, 23);
            this.checkPermissionsButton.TabIndex = 28;
            this.checkPermissionsButton.Text = "Check Permissions";
            this.checkPermissionsButton.UseVisualStyleBackColor = true;
            this.checkPermissionsButton.Click += new System.EventHandler(this.checkPermissionsButton_Click);
            // 
            // getMuteListButton
            // 
            this.getMuteListButton.Location = new System.Drawing.Point(353, 29);
            this.getMuteListButton.Name = "getMuteListButton";
            this.getMuteListButton.Size = new System.Drawing.Size(146, 23);
            this.getMuteListButton.TabIndex = 29;
            this.getMuteListButton.Text = "Get Mute List";
            this.getMuteListButton.UseVisualStyleBackColor = true;
            this.getMuteListButton.Click += new System.EventHandler(this.getMuteListButton_Click);
            // 
            // getAvoidListButton
            // 
            this.getAvoidListButton.Location = new System.Drawing.Point(353, 59);
            this.getAvoidListButton.Name = "getAvoidListButton";
            this.getAvoidListButton.Size = new System.Drawing.Size(146, 23);
            this.getAvoidListButton.TabIndex = 30;
            this.getAvoidListButton.Text = "Get Avoid List";
            this.getAvoidListButton.UseVisualStyleBackColor = true;
            this.getAvoidListButton.Click += new System.EventHandler(this.getAvoidListButton_Click);
            // 
            // PrivacyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 592);
            this.Controls.Add(this.getAvoidListButton);
            this.Controls.Add(this.getMuteListButton);
            this.Controls.Add(this.checkPermissionsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.permissionsList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xuids);
            this.Controls.Add(this.textBox1);
            this.Name = "PrivacyForm";
            this.Text = "PrivacyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox xuids;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox permissionsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button checkPermissionsButton;
        private System.Windows.Forms.Button getMuteListButton;
        private System.Windows.Forms.Button getAvoidListButton;
    }
}