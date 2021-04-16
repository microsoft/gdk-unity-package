namespace TestGame
{
    partial class GameSaveForm
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
            this.InitProviderButton = new System.Windows.Forms.Button();
            this.InitProviderAsyncButton = new System.Windows.Forms.Button();
            this.CloseProviderButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GetUserHandleButton = new System.Windows.Forms.Button();
            this.CloseUserHandleButton = new System.Windows.Forms.Button();
            this.GetRemainingQuotaButton = new System.Windows.Forms.Button();
            this.GetRemainingAsyncButton = new System.Windows.Forms.Button();
            this.CreateContainerButton = new System.Windows.Forms.Button();
            this.DeleteContainerButton = new System.Windows.Forms.Button();
            this.DeleteContainerAsyncButton = new System.Windows.Forms.Button();
            this.CloseContainerButton = new System.Windows.Forms.Button();
            this.GetContainerInfoButton = new System.Windows.Forms.Button();
            this.EnumContainerInfoButton = new System.Windows.Forms.Button();
            this.EnumByNameButton = new System.Windows.Forms.Button();
            this.EnumBlobInfoButton = new System.Windows.Forms.Button();
            this.EnumBlobByNameButton = new System.Windows.Forms.Button();
            this.CreateUpdateHandleButton = new System.Windows.Forms.Button();
            this.WriteBlobToHandleButton = new System.Windows.Forms.Button();
            this.DeleteBlobFromHandleButton = new System.Windows.Forms.Button();
            this.SubmitUpdateHandleButton = new System.Windows.Forms.Button();
            this.SubmitUpdateHandleAsyncButton = new System.Windows.Forms.Button();
            this.CloseUpdateHandleButton = new System.Windows.Forms.Button();
            this.ReadBlobDataButton = new System.Windows.Forms.Button();
            this.ReadBlobDataAsyncButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InitProviderButton
            // 
            this.InitProviderButton.Enabled = false;
            this.InitProviderButton.Location = new System.Drawing.Point(150, 24);
            this.InitProviderButton.Name = "InitProviderButton";
            this.InitProviderButton.Size = new System.Drawing.Size(115, 49);
            this.InitProviderButton.TabIndex = 0;
            this.InitProviderButton.Text = "InitProvider";
            this.InitProviderButton.UseVisualStyleBackColor = true;
            this.InitProviderButton.Click += new System.EventHandler(this.InitProviderButton_Click);
            // 
            // InitProviderAsyncButton
            // 
            this.InitProviderAsyncButton.Enabled = false;
            this.InitProviderAsyncButton.Location = new System.Drawing.Point(150, 79);
            this.InitProviderAsyncButton.Name = "InitProviderAsyncButton";
            this.InitProviderAsyncButton.Size = new System.Drawing.Size(115, 49);
            this.InitProviderAsyncButton.TabIndex = 1;
            this.InitProviderAsyncButton.Text = "InitProvider - Async";
            this.InitProviderAsyncButton.UseVisualStyleBackColor = true;
            this.InitProviderAsyncButton.Click += new System.EventHandler(this.InitProviderAsyncButton_Click);
            // 
            // CloseProviderButton
            // 
            this.CloseProviderButton.Enabled = false;
            this.CloseProviderButton.Location = new System.Drawing.Point(150, 134);
            this.CloseProviderButton.Name = "CloseProviderButton";
            this.CloseProviderButton.Size = new System.Drawing.Size(115, 49);
            this.CloseProviderButton.TabIndex = 2;
            this.CloseProviderButton.Text = "Close Provider";
            this.CloseProviderButton.UseVisualStyleBackColor = true;
            this.CloseProviderButton.Click += new System.EventHandler(this.CloseProviderButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 366);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(934, 256);
            this.textBox1.TabIndex = 3;
            // 
            // GetUserHandleButton
            // 
            this.GetUserHandleButton.Location = new System.Drawing.Point(29, 24);
            this.GetUserHandleButton.Name = "GetUserHandleButton";
            this.GetUserHandleButton.Size = new System.Drawing.Size(115, 49);
            this.GetUserHandleButton.TabIndex = 4;
            this.GetUserHandleButton.Text = "Get XUser";
            this.GetUserHandleButton.UseVisualStyleBackColor = true;
            this.GetUserHandleButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // CloseUserHandleButton
            // 
            this.CloseUserHandleButton.Enabled = false;
            this.CloseUserHandleButton.Location = new System.Drawing.Point(29, 79);
            this.CloseUserHandleButton.Name = "CloseUserHandleButton";
            this.CloseUserHandleButton.Size = new System.Drawing.Size(115, 49);
            this.CloseUserHandleButton.TabIndex = 5;
            this.CloseUserHandleButton.Text = "Close XUser";
            this.CloseUserHandleButton.UseVisualStyleBackColor = true;
            this.CloseUserHandleButton.Click += new System.EventHandler(this.closeUserHandleButton_Click);
            // 
            // GetRemainingQuotaButton
            // 
            this.GetRemainingQuotaButton.Enabled = false;
            this.GetRemainingQuotaButton.Location = new System.Drawing.Point(271, 24);
            this.GetRemainingQuotaButton.Name = "GetRemainingQuotaButton";
            this.GetRemainingQuotaButton.Size = new System.Drawing.Size(115, 49);
            this.GetRemainingQuotaButton.TabIndex = 6;
            this.GetRemainingQuotaButton.Text = "GetRemaining";
            this.GetRemainingQuotaButton.UseVisualStyleBackColor = true;
            this.GetRemainingQuotaButton.Click += new System.EventHandler(this.GetRemainingQuotaButton_Click);
            // 
            // GetRemainingAsyncButton
            // 
            this.GetRemainingAsyncButton.Enabled = false;
            this.GetRemainingAsyncButton.Location = new System.Drawing.Point(271, 79);
            this.GetRemainingAsyncButton.Name = "GetRemainingAsyncButton";
            this.GetRemainingAsyncButton.Size = new System.Drawing.Size(115, 49);
            this.GetRemainingAsyncButton.TabIndex = 7;
            this.GetRemainingAsyncButton.Text = "GetRemainingAsync";
            this.GetRemainingAsyncButton.UseVisualStyleBackColor = true;
            this.GetRemainingAsyncButton.Click += new System.EventHandler(this.GetRemainingAsyncButton_Click);
            // 
            // CreateContainerButton
            // 
            this.CreateContainerButton.Enabled = false;
            this.CreateContainerButton.Location = new System.Drawing.Point(392, 24);
            this.CreateContainerButton.Name = "CreateContainerButton";
            this.CreateContainerButton.Size = new System.Drawing.Size(128, 49);
            this.CreateContainerButton.TabIndex = 8;
            this.CreateContainerButton.Text = "CreateContainer";
            this.CreateContainerButton.UseVisualStyleBackColor = true;
            this.CreateContainerButton.Click += new System.EventHandler(this.createContainerButton_Click);
            // 
            // DeleteContainerButton
            // 
            this.DeleteContainerButton.Enabled = false;
            this.DeleteContainerButton.Location = new System.Drawing.Point(392, 79);
            this.DeleteContainerButton.Name = "DeleteContainerButton";
            this.DeleteContainerButton.Size = new System.Drawing.Size(128, 49);
            this.DeleteContainerButton.TabIndex = 9;
            this.DeleteContainerButton.Text = "DeleteContainer";
            this.DeleteContainerButton.UseVisualStyleBackColor = true;
            this.DeleteContainerButton.Click += new System.EventHandler(this.deleteContainerButton_Click);
            // 
            // DeleteContainerAsyncButton
            // 
            this.DeleteContainerAsyncButton.Enabled = false;
            this.DeleteContainerAsyncButton.Location = new System.Drawing.Point(392, 134);
            this.DeleteContainerAsyncButton.Name = "DeleteContainerAsyncButton";
            this.DeleteContainerAsyncButton.Size = new System.Drawing.Size(128, 49);
            this.DeleteContainerAsyncButton.TabIndex = 10;
            this.DeleteContainerAsyncButton.Text = "DeleteContainerAsync";
            this.DeleteContainerAsyncButton.UseVisualStyleBackColor = true;
            this.DeleteContainerAsyncButton.Click += new System.EventHandler(this.deleteContainerAsyncButton_Click);
            // 
            // CloseContainerButton
            // 
            this.CloseContainerButton.Enabled = false;
            this.CloseContainerButton.Location = new System.Drawing.Point(392, 189);
            this.CloseContainerButton.Name = "CloseContainerButton";
            this.CloseContainerButton.Size = new System.Drawing.Size(128, 49);
            this.CloseContainerButton.TabIndex = 11;
            this.CloseContainerButton.Text = "CloseContainer";
            this.CloseContainerButton.UseVisualStyleBackColor = true;
            this.CloseContainerButton.Click += new System.EventHandler(this.closeContainer_Click);
            // 
            // GetContainerInfoButton
            // 
            this.GetContainerInfoButton.Enabled = false;
            this.GetContainerInfoButton.Location = new System.Drawing.Point(526, 24);
            this.GetContainerInfoButton.Name = "GetContainerInfoButton";
            this.GetContainerInfoButton.Size = new System.Drawing.Size(128, 49);
            this.GetContainerInfoButton.TabIndex = 12;
            this.GetContainerInfoButton.Text = "GetContainerInfo";
            this.GetContainerInfoButton.UseVisualStyleBackColor = true;
            this.GetContainerInfoButton.Click += new System.EventHandler(this.GetContainerInfoButton_Click);
            // 
            // EnumContainerInfoButton
            // 
            this.EnumContainerInfoButton.Enabled = false;
            this.EnumContainerInfoButton.Location = new System.Drawing.Point(526, 79);
            this.EnumContainerInfoButton.Name = "EnumContainerInfoButton";
            this.EnumContainerInfoButton.Size = new System.Drawing.Size(128, 49);
            this.EnumContainerInfoButton.TabIndex = 13;
            this.EnumContainerInfoButton.Text = "Enum Containers";
            this.EnumContainerInfoButton.UseVisualStyleBackColor = true;
            this.EnumContainerInfoButton.Click += new System.EventHandler(this.EnumContainerInfoButton_Click);
            // 
            // EnumByNameButton
            // 
            this.EnumByNameButton.Enabled = false;
            this.EnumByNameButton.Location = new System.Drawing.Point(526, 134);
            this.EnumByNameButton.Name = "EnumByNameButton";
            this.EnumByNameButton.Size = new System.Drawing.Size(128, 49);
            this.EnumByNameButton.TabIndex = 14;
            this.EnumByNameButton.Text = "Enum Container By Name";
            this.EnumByNameButton.UseVisualStyleBackColor = true;
            this.EnumByNameButton.Click += new System.EventHandler(this.EnumByNameButton_Click);
            // 
            // EnumBlobInfoButton
            // 
            this.EnumBlobInfoButton.Enabled = false;
            this.EnumBlobInfoButton.Location = new System.Drawing.Point(660, 24);
            this.EnumBlobInfoButton.Name = "EnumBlobInfoButton";
            this.EnumBlobInfoButton.Size = new System.Drawing.Size(128, 49);
            this.EnumBlobInfoButton.TabIndex = 15;
            this.EnumBlobInfoButton.Text = "Enum Blob Info";
            this.EnumBlobInfoButton.UseVisualStyleBackColor = true;
            this.EnumBlobInfoButton.Click += new System.EventHandler(this.EnumBlobInfoButton_Click);
            // 
            // EnumBlobByNameButton
            // 
            this.EnumBlobByNameButton.Enabled = false;
            this.EnumBlobByNameButton.Location = new System.Drawing.Point(660, 79);
            this.EnumBlobByNameButton.Name = "EnumBlobByNameButton";
            this.EnumBlobByNameButton.Size = new System.Drawing.Size(128, 49);
            this.EnumBlobByNameButton.TabIndex = 16;
            this.EnumBlobByNameButton.Text = "Enum Blob By Name";
            this.EnumBlobByNameButton.UseVisualStyleBackColor = true;
            this.EnumBlobByNameButton.Click += new System.EventHandler(this.EnumBlobByNameButton_Click);
            // 
            // CreateUpdateHandleButton
            // 
            this.CreateUpdateHandleButton.Enabled = false;
            this.CreateUpdateHandleButton.Location = new System.Drawing.Point(794, 24);
            this.CreateUpdateHandleButton.Name = "CreateUpdateHandleButton";
            this.CreateUpdateHandleButton.Size = new System.Drawing.Size(128, 49);
            this.CreateUpdateHandleButton.TabIndex = 17;
            this.CreateUpdateHandleButton.Text = "Create UpdateHandle";
            this.CreateUpdateHandleButton.UseVisualStyleBackColor = true;
            this.CreateUpdateHandleButton.Click += new System.EventHandler(this.CreateUpdateHandleButton_Click);
            // 
            // WriteBlobToHandleButton
            // 
            this.WriteBlobToHandleButton.Enabled = false;
            this.WriteBlobToHandleButton.Location = new System.Drawing.Point(794, 79);
            this.WriteBlobToHandleButton.Name = "WriteBlobToHandleButton";
            this.WriteBlobToHandleButton.Size = new System.Drawing.Size(128, 49);
            this.WriteBlobToHandleButton.TabIndex = 18;
            this.WriteBlobToHandleButton.Text = "Write Blob To Handle";
            this.WriteBlobToHandleButton.UseVisualStyleBackColor = true;
            this.WriteBlobToHandleButton.Click += new System.EventHandler(this.WriteBlobToHandleButton_Click);
            // 
            // DeleteBlobFromHandleButton
            // 
            this.DeleteBlobFromHandleButton.Enabled = false;
            this.DeleteBlobFromHandleButton.Location = new System.Drawing.Point(794, 134);
            this.DeleteBlobFromHandleButton.Name = "DeleteBlobFromHandleButton";
            this.DeleteBlobFromHandleButton.Size = new System.Drawing.Size(128, 49);
            this.DeleteBlobFromHandleButton.TabIndex = 19;
            this.DeleteBlobFromHandleButton.Text = "Delete Blob From Handle";
            this.DeleteBlobFromHandleButton.UseVisualStyleBackColor = true;
            this.DeleteBlobFromHandleButton.Click += new System.EventHandler(this.DeleteBlobFromHandleButton_Click);
            // 
            // SubmitUpdateHandleButton
            // 
            this.SubmitUpdateHandleButton.Enabled = false;
            this.SubmitUpdateHandleButton.Location = new System.Drawing.Point(794, 189);
            this.SubmitUpdateHandleButton.Name = "SubmitUpdateHandleButton";
            this.SubmitUpdateHandleButton.Size = new System.Drawing.Size(128, 49);
            this.SubmitUpdateHandleButton.TabIndex = 20;
            this.SubmitUpdateHandleButton.Text = "Submit Update To Handle";
            this.SubmitUpdateHandleButton.UseVisualStyleBackColor = true;
            this.SubmitUpdateHandleButton.Click += new System.EventHandler(this.SubmitUpdateHandleButton_Click);
            // 
            // SubmitUpdateHandleAsyncButton
            // 
            this.SubmitUpdateHandleAsyncButton.Enabled = false;
            this.SubmitUpdateHandleAsyncButton.Location = new System.Drawing.Point(794, 244);
            this.SubmitUpdateHandleAsyncButton.Name = "SubmitUpdateHandleAsyncButton";
            this.SubmitUpdateHandleAsyncButton.Size = new System.Drawing.Size(128, 49);
            this.SubmitUpdateHandleAsyncButton.TabIndex = 21;
            this.SubmitUpdateHandleAsyncButton.Text = "Submit Update To Handle Async";
            this.SubmitUpdateHandleAsyncButton.UseVisualStyleBackColor = true;
            this.SubmitUpdateHandleAsyncButton.Click += new System.EventHandler(this.SubmitUpdateHandleAsyncButton_Click);
            // 
            // CloseUpdateHandleButton
            // 
            this.CloseUpdateHandleButton.Enabled = false;
            this.CloseUpdateHandleButton.Location = new System.Drawing.Point(794, 299);
            this.CloseUpdateHandleButton.Name = "CloseUpdateHandleButton";
            this.CloseUpdateHandleButton.Size = new System.Drawing.Size(128, 49);
            this.CloseUpdateHandleButton.TabIndex = 22;
            this.CloseUpdateHandleButton.Text = "Close UpdateHandle";
            this.CloseUpdateHandleButton.UseVisualStyleBackColor = true;
            this.CloseUpdateHandleButton.Click += new System.EventHandler(this.CloseUpdateHandleButton_Click);
            // 
            // ReadBlobDataButton
            // 
            this.ReadBlobDataButton.Enabled = false;
            this.ReadBlobDataButton.Location = new System.Drawing.Point(660, 134);
            this.ReadBlobDataButton.Name = "ReadBlobDataButton";
            this.ReadBlobDataButton.Size = new System.Drawing.Size(128, 49);
            this.ReadBlobDataButton.TabIndex = 23;
            this.ReadBlobDataButton.Text = "Read Blob Data";
            this.ReadBlobDataButton.UseVisualStyleBackColor = true;
            this.ReadBlobDataButton.Click += new System.EventHandler(this.ReadBlobDataButton_Click);
            // 
            // ReadBlobDataAsyncButton
            // 
            this.ReadBlobDataAsyncButton.Enabled = false;
            this.ReadBlobDataAsyncButton.Location = new System.Drawing.Point(660, 189);
            this.ReadBlobDataAsyncButton.Name = "ReadBlobDataAsyncButton";
            this.ReadBlobDataAsyncButton.Size = new System.Drawing.Size(128, 49);
            this.ReadBlobDataAsyncButton.TabIndex = 24;
            this.ReadBlobDataAsyncButton.Text = "Read Blob Data Async";
            this.ReadBlobDataAsyncButton.UseVisualStyleBackColor = true;
            this.ReadBlobDataAsyncButton.Click += new System.EventHandler(this.ReadBlobDataAsyncButton_Click);
            // 
            // GameSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 633);
            this.Controls.Add(this.ReadBlobDataAsyncButton);
            this.Controls.Add(this.ReadBlobDataButton);
            this.Controls.Add(this.CloseUpdateHandleButton);
            this.Controls.Add(this.SubmitUpdateHandleAsyncButton);
            this.Controls.Add(this.SubmitUpdateHandleButton);
            this.Controls.Add(this.DeleteBlobFromHandleButton);
            this.Controls.Add(this.WriteBlobToHandleButton);
            this.Controls.Add(this.CreateUpdateHandleButton);
            this.Controls.Add(this.EnumBlobByNameButton);
            this.Controls.Add(this.EnumBlobInfoButton);
            this.Controls.Add(this.EnumByNameButton);
            this.Controls.Add(this.EnumContainerInfoButton);
            this.Controls.Add(this.GetContainerInfoButton);
            this.Controls.Add(this.CloseContainerButton);
            this.Controls.Add(this.DeleteContainerAsyncButton);
            this.Controls.Add(this.DeleteContainerButton);
            this.Controls.Add(this.CreateContainerButton);
            this.Controls.Add(this.GetRemainingAsyncButton);
            this.Controls.Add(this.GetRemainingQuotaButton);
            this.Controls.Add(this.CloseUserHandleButton);
            this.Controls.Add(this.GetUserHandleButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CloseProviderButton);
            this.Controls.Add(this.InitProviderAsyncButton);
            this.Controls.Add(this.InitProviderButton);
            this.Name = "GameSaveForm";
            this.Text = "GameSaveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InitProviderButton;
        private System.Windows.Forms.Button InitProviderAsyncButton;
        private System.Windows.Forms.Button CloseProviderButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button GetUserHandleButton;
        private System.Windows.Forms.Button CloseUserHandleButton;
        private System.Windows.Forms.Button GetRemainingQuotaButton;
        private System.Windows.Forms.Button GetRemainingAsyncButton;
        private System.Windows.Forms.Button CreateContainerButton;
        private System.Windows.Forms.Button DeleteContainerButton;
        private System.Windows.Forms.Button DeleteContainerAsyncButton;
        private System.Windows.Forms.Button CloseContainerButton;
        private System.Windows.Forms.Button GetContainerInfoButton;
        private System.Windows.Forms.Button EnumContainerInfoButton;
        private System.Windows.Forms.Button EnumByNameButton;
        private System.Windows.Forms.Button EnumBlobInfoButton;
        private System.Windows.Forms.Button EnumBlobByNameButton;
        private System.Windows.Forms.Button CreateUpdateHandleButton;
        private System.Windows.Forms.Button WriteBlobToHandleButton;
        private System.Windows.Forms.Button DeleteBlobFromHandleButton;
        private System.Windows.Forms.Button SubmitUpdateHandleButton;
        private System.Windows.Forms.Button SubmitUpdateHandleAsyncButton;
        private System.Windows.Forms.Button CloseUpdateHandleButton;
        private System.Windows.Forms.Button ReadBlobDataButton;
        private System.Windows.Forms.Button ReadBlobDataAsyncButton;
    }
}