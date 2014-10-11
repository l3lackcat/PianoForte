namespace LocationXlsToJson
{
    partial class TradewebTemplateForm
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
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.PathTextbox = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 48);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(598, 28);
            this.ProgressBar.TabIndex = 11;
            this.ProgressBar.Visible = false;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(143, 49);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(125, 28);
            this.GenerateButton.TabIndex = 10;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // PathTextbox
            // 
            this.PathTextbox.Enabled = false;
            this.PathTextbox.Location = new System.Drawing.Point(12, 13);
            this.PathTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PathTextbox.Name = "PathTextbox";
            this.PathTextbox.Size = new System.Drawing.Size(598, 22);
            this.PathTextbox.TabIndex = 9;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(12, 49);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(125, 28);
            this.BrowseButton.TabIndex = 8;
            this.BrowseButton.Text = "Browse File";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TradewebTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 335);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.PathTextbox);
            this.Controls.Add(this.BrowseButton);
            this.Name = "TradewebTemplateForm";
            this.Text = "TradewebTemplate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.TextBox PathTextbox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}