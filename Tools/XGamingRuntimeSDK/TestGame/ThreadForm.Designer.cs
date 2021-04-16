namespace TestGame
{
    partial class ThreadForm
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
            this.setTimeSensitive = new System.Windows.Forms.Button();
            this.setNotTimeSensitive = new System.Windows.Forms.Button();
            this.getIsTimeSensitive = new System.Windows.Forms.Button();
            this.assertNotTimeSensitive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 224);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(672, 192);
            this.textBox1.TabIndex = 2;
            // 
            // setTimeSensitive
            // 
            this.setTimeSensitive.Location = new System.Drawing.Point(13, 13);
            this.setTimeSensitive.Name = "setTimeSensitive";
            this.setTimeSensitive.Size = new System.Drawing.Size(116, 34);
            this.setTimeSensitive.TabIndex = 3;
            this.setTimeSensitive.Text = "Set time sensitive";
            this.setTimeSensitive.UseVisualStyleBackColor = true;
            this.setTimeSensitive.Click += new System.EventHandler(this.setTimeSensitive_Click);
            // 
            // setNotTimeSensitive
            // 
            this.setNotTimeSensitive.Location = new System.Drawing.Point(135, 13);
            this.setNotTimeSensitive.Name = "setNotTimeSensitive";
            this.setNotTimeSensitive.Size = new System.Drawing.Size(116, 34);
            this.setNotTimeSensitive.TabIndex = 4;
            this.setNotTimeSensitive.Text = "Set not time sensitive";
            this.setNotTimeSensitive.UseVisualStyleBackColor = true;
            this.setNotTimeSensitive.Click += new System.EventHandler(this.setNotTimeSensitive_Click);
            // 
            // getIsTimeSensitive
            // 
            this.getIsTimeSensitive.Location = new System.Drawing.Point(13, 53);
            this.getIsTimeSensitive.Name = "getIsTimeSensitive";
            this.getIsTimeSensitive.Size = new System.Drawing.Size(116, 34);
            this.getIsTimeSensitive.TabIndex = 5;
            this.getIsTimeSensitive.Text = "Get is time sensitive";
            this.getIsTimeSensitive.UseVisualStyleBackColor = true;
            this.getIsTimeSensitive.Click += new System.EventHandler(this.getIsTimeSensitive_Click);
            // 
            // assertNotTimeSensitive
            // 
            this.assertNotTimeSensitive.Location = new System.Drawing.Point(135, 53);
            this.assertNotTimeSensitive.Name = "assertNotTimeSensitive";
            this.assertNotTimeSensitive.Size = new System.Drawing.Size(116, 34);
            this.assertNotTimeSensitive.TabIndex = 6;
            this.assertNotTimeSensitive.Text = "Assert not time sensitive";
            this.assertNotTimeSensitive.UseVisualStyleBackColor = true;
            this.assertNotTimeSensitive.Click += new System.EventHandler(this.assertNotTimeSensitive_Click);
            // 
            // ThreadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 427);
            this.Controls.Add(this.assertNotTimeSensitive);
            this.Controls.Add(this.getIsTimeSensitive);
            this.Controls.Add(this.setNotTimeSensitive);
            this.Controls.Add(this.setTimeSensitive);
            this.Controls.Add(this.textBox1);
            this.Name = "ThreadForm";
            this.Text = "ThreadForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button setTimeSensitive;
        private System.Windows.Forms.Button setNotTimeSensitive;
        private System.Windows.Forms.Button getIsTimeSensitive;
        private System.Windows.Forms.Button assertNotTimeSensitive;
    }
}