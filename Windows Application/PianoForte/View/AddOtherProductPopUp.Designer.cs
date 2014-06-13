namespace PianoForte.View
{
    partial class AddOtherProductPopUp
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_OtherProductName = new System.Windows.Forms.TextBox();
            this.TextBox_OtherProductPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Button_Add = new System.Windows.Forms.Button();
            this.Button_Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อรายการ";
            // 
            // TextBox_OtherProductName
            // 
            this.TextBox_OtherProductName.Location = new System.Drawing.Point(82, 12);
            this.TextBox_OtherProductName.Name = "TextBox_OtherProductName";
            this.TextBox_OtherProductName.Size = new System.Drawing.Size(200, 23);
            this.TextBox_OtherProductName.TabIndex = 1;
            this.TextBox_OtherProductName.TextChanged += new System.EventHandler(this.TextBox_OtherProductName_TextChanged);
            // 
            // TextBox_OtherProductPrice
            // 
            this.TextBox_OtherProductPrice.Location = new System.Drawing.Point(82, 41);
            this.TextBox_OtherProductPrice.Name = "TextBox_OtherProductPrice";
            this.TextBox_OtherProductPrice.Size = new System.Drawing.Size(106, 23);
            this.TextBox_OtherProductPrice.TabIndex = 2;
            this.TextBox_OtherProductPrice.TextChanged += new System.EventHandler(this.TextBox_OtherProductPrice_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "ราคา";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "บาท";
            // 
            // Button_Add
            // 
            this.Button_Add.Enabled = false;
            this.Button_Add.Location = new System.Drawing.Point(82, 70);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(50, 23);
            this.Button_Add.TabIndex = 5;
            this.Button_Add.Text = "เพิ่ม";
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // Button_Reset
            // 
            this.Button_Reset.Location = new System.Drawing.Point(138, 70);
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Size = new System.Drawing.Size(50, 23);
            this.Button_Reset.TabIndex = 6;
            this.Button_Reset.Text = "รีเซ็ต";
            this.Button_Reset.UseVisualStyleBackColor = true;
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // AddOtherProductPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 105);
            this.Controls.Add(this.Button_Reset);
            this.Controls.Add(this.Button_Add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBox_OtherProductPrice);
            this.Controls.Add(this.TextBox_OtherProductName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddOtherProductPopUp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "เพิ่มรายการอื่นๆ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_OtherProductName;
        private System.Windows.Forms.TextBox TextBox_OtherProductPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Button_Add;
        private System.Windows.Forms.Button Button_Reset;
    }
}