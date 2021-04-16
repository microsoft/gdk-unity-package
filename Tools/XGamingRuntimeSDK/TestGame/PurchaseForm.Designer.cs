namespace TestGame
{
    partial class PurchaseForm
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
            this.getPurchaseId = new System.Windows.Forms.Button();
            this.getCollectionsId = new System.Windows.Forms.Button();
            this.consumeConsumable = new System.Windows.Forms.Button();
            this.queryConsumable = new System.Windows.Forms.Button();
            this.purchase = new System.Windows.Forms.Button();
            this.rateAndReview = new System.Windows.Forms.Button();
            this.redeemToken = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.purchaseIdTextBox = new System.Windows.Forms.TextBox();
            this.consumeQuantityTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // getPurchaseId
            // 
            this.getPurchaseId.Location = new System.Drawing.Point(11, 249);
            this.getPurchaseId.Margin = new System.Windows.Forms.Padding(2);
            this.getPurchaseId.Name = "getPurchaseId";
            this.getPurchaseId.Size = new System.Drawing.Size(120, 31);
            this.getPurchaseId.TabIndex = 22;
            this.getPurchaseId.Text = "Get Purchase Id";
            this.getPurchaseId.UseVisualStyleBackColor = true;
            this.getPurchaseId.Click += new System.EventHandler(this.userPurchaseId_Click);
            // 
            // getCollectionsId
            // 
            this.getCollectionsId.Location = new System.Drawing.Point(11, 213);
            this.getCollectionsId.Margin = new System.Windows.Forms.Padding(2);
            this.getCollectionsId.Name = "getCollectionsId";
            this.getCollectionsId.Size = new System.Drawing.Size(120, 31);
            this.getCollectionsId.TabIndex = 21;
            this.getCollectionsId.Text = "Get Collections Id";
            this.getCollectionsId.UseVisualStyleBackColor = true;
            this.getCollectionsId.Click += new System.EventHandler(this.userCollectionsId_Click);
            // 
            // consumeConsumable
            // 
            this.consumeConsumable.Location = new System.Drawing.Point(11, 167);
            this.consumeConsumable.Margin = new System.Windows.Forms.Padding(2);
            this.consumeConsumable.Name = "consumeConsumable";
            this.consumeConsumable.Size = new System.Drawing.Size(120, 31);
            this.consumeConsumable.TabIndex = 20;
            this.consumeConsumable.Text = "Consume Consumable";
            this.consumeConsumable.UseVisualStyleBackColor = true;
            this.consumeConsumable.Click += new System.EventHandler(this.consumeConsumable_Click);
            // 
            // queryConsumable
            // 
            this.queryConsumable.Location = new System.Drawing.Point(11, 129);
            this.queryConsumable.Margin = new System.Windows.Forms.Padding(2);
            this.queryConsumable.Name = "queryConsumable";
            this.queryConsumable.Size = new System.Drawing.Size(120, 31);
            this.queryConsumable.TabIndex = 19;
            this.queryConsumable.Text = "Query Consumable";
            this.queryConsumable.UseVisualStyleBackColor = true;
            this.queryConsumable.Click += new System.EventHandler(this.queryConsumable_Click);
            // 
            // purchase
            // 
            this.purchase.Location = new System.Drawing.Point(11, 83);
            this.purchase.Margin = new System.Windows.Forms.Padding(2);
            this.purchase.Name = "purchase";
            this.purchase.Size = new System.Drawing.Size(120, 31);
            this.purchase.TabIndex = 18;
            this.purchase.Text = "Do Purchase";
            this.purchase.UseVisualStyleBackColor = true;
            this.purchase.Click += new System.EventHandler(this.purchase_Click);
            // 
            // rateAndReview
            // 
            this.rateAndReview.Location = new System.Drawing.Point(11, 48);
            this.rateAndReview.Margin = new System.Windows.Forms.Padding(2);
            this.rateAndReview.Name = "rateAndReview";
            this.rateAndReview.Size = new System.Drawing.Size(120, 31);
            this.rateAndReview.TabIndex = 17;
            this.rateAndReview.Text = "Do Rate And Review";
            this.rateAndReview.UseVisualStyleBackColor = true;
            this.rateAndReview.Click += new System.EventHandler(this.rateAndReview_Click);
            // 
            // redeemToken
            // 
            this.redeemToken.Location = new System.Drawing.Point(11, 13);
            this.redeemToken.Margin = new System.Windows.Forms.Padding(2);
            this.redeemToken.Name = "redeemToken";
            this.redeemToken.Size = new System.Drawing.Size(120, 31);
            this.redeemToken.TabIndex = 16;
            this.redeemToken.Text = "Do Token Redeem";
            this.redeemToken.UseVisualStyleBackColor = true;
            this.redeemToken.Click += new System.EventHandler(this.redeemToken_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 291);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(611, 163);
            this.textBox1.TabIndex = 13;
            // 
            // purchaseIdTextBox
            // 
            this.purchaseIdTextBox.Location = new System.Drawing.Point(136, 87);
            this.purchaseIdTextBox.Name = "purchaseIdTextBox";
            this.purchaseIdTextBox.Size = new System.Drawing.Size(119, 20);
            this.purchaseIdTextBox.TabIndex = 23;
            this.purchaseIdTextBox.Text = "111";
            // 
            // consumeQuantityTextBox
            // 
            this.consumeQuantityTextBox.Location = new System.Drawing.Point(136, 173);
            this.consumeQuantityTextBox.Name = "consumeQuantityTextBox";
            this.consumeQuantityTextBox.Size = new System.Drawing.Size(119, 20);
            this.consumeQuantityTextBox.TabIndex = 24;
            this.consumeQuantityTextBox.Text = "25";
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 477);
            this.Controls.Add(this.consumeQuantityTextBox);
            this.Controls.Add(this.purchaseIdTextBox);
            this.Controls.Add(this.getPurchaseId);
            this.Controls.Add(this.getCollectionsId);
            this.Controls.Add(this.consumeConsumable);
            this.Controls.Add(this.queryConsumable);
            this.Controls.Add(this.purchase);
            this.Controls.Add(this.rateAndReview);
            this.Controls.Add(this.redeemToken);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Purchase Related Features";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getPurchaseId;
        private System.Windows.Forms.Button getCollectionsId;
        private System.Windows.Forms.Button consumeConsumable;
        private System.Windows.Forms.Button queryConsumable;
        private System.Windows.Forms.Button purchase;
        private System.Windows.Forms.Button rateAndReview;
        private System.Windows.Forms.Button redeemToken;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox purchaseIdTextBox;
        private System.Windows.Forms.TextBox consumeQuantityTextBox;
    }
}