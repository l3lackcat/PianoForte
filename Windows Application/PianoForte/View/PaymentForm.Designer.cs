namespace PianoForte.View
{
    partial class PaymentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            this.Panel_StudentForm = new System.Windows.Forms.Panel();
            this.Panel_CourseForm = new System.Windows.Forms.Panel();
            this.CheckBox_AddFirstRegisterCost = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.TextBox_GrandTotal = new System.Windows.Forms.TextBox();
            this.Button_Reset = new System.Windows.Forms.Button();
            this.Button_Pay = new System.Windows.Forms.Button();
            this.TextBox_CreditCardNumber = new System.Windows.Forms.TextBox();
            this.RadioButton_CreditCard = new System.Windows.Forms.RadioButton();
            this.RadioButton_Cash = new System.Windows.Forms.RadioButton();
            this.DataGridView_PaymentDetail_Summary = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.Panel_OtherProductForm = new System.Windows.Forms.Panel();
            this.Button_Search_Book = new System.Windows.Forms.Button();
            this.Button_Search_Cd = new System.Windows.Forms.Button();
            this.TextBox_ProductBarcode = new System.Windows.Forms.TextBox();
            this.Button_Search_Product = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_PaymentDetail_Summary)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_StudentForm
            // 
            this.Panel_StudentForm.Location = new System.Drawing.Point(12, 12);
            this.Panel_StudentForm.Name = "Panel_StudentForm";
            this.Panel_StudentForm.Size = new System.Drawing.Size(220, 270);
            this.Panel_StudentForm.TabIndex = 0;
            // 
            // Panel_CourseForm
            // 
            this.Panel_CourseForm.Location = new System.Drawing.Point(238, 12);
            this.Panel_CourseForm.Name = "Panel_CourseForm";
            this.Panel_CourseForm.Size = new System.Drawing.Size(766, 280);
            this.Panel_CourseForm.TabIndex = 1;
            // 
            // CheckBox_AddFirstRegisterCost
            // 
            this.CheckBox_AddFirstRegisterCost.AutoSize = true;
            this.CheckBox_AddFirstRegisterCost.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CheckBox_AddFirstRegisterCost.Location = new System.Drawing.Point(238, 298);
            this.CheckBox_AddFirstRegisterCost.Name = "CheckBox_AddFirstRegisterCost";
            this.CheckBox_AddFirstRegisterCost.Size = new System.Drawing.Size(190, 20);
            this.CheckBox_AddFirstRegisterCost.TabIndex = 15;
            this.CheckBox_AddFirstRegisterCost.Text = "ค่าลงทะเบียนแรกเข้า 300 บาท";
            this.CheckBox_AddFirstRegisterCost.UseVisualStyleBackColor = true;
            this.CheckBox_AddFirstRegisterCost.CheckedChanged += new System.EventHandler(this.CheckBox_AddFirstRegisterCost_CheckedChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(840, 535);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 13);
            this.label27.TabIndex = 21;
            this.label27.Text = "รวมทั้งสิ้น";
            // 
            // TextBox_GrandTotal
            // 
            this.TextBox_GrandTotal.Enabled = false;
            this.TextBox_GrandTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_GrandTotal.Location = new System.Drawing.Point(898, 530);
            this.TextBox_GrandTotal.Name = "TextBox_GrandTotal";
            this.TextBox_GrandTotal.ReadOnly = true;
            this.TextBox_GrandTotal.Size = new System.Drawing.Size(106, 23);
            this.TextBox_GrandTotal.TabIndex = 20;
            this.TextBox_GrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Button_Reset
            // 
            this.Button_Reset.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Reset.Location = new System.Drawing.Point(929, 559);
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Size = new System.Drawing.Size(75, 23);
            this.Button_Reset.TabIndex = 23;
            this.Button_Reset.Text = "รีเซ็ต";
            this.Button_Reset.UseVisualStyleBackColor = true;
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // Button_Pay
            // 
            this.Button_Pay.Enabled = false;
            this.Button_Pay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Pay.Location = new System.Drawing.Point(848, 559);
            this.Button_Pay.Name = "Button_Pay";
            this.Button_Pay.Size = new System.Drawing.Size(75, 23);
            this.Button_Pay.TabIndex = 22;
            this.Button_Pay.Text = "ชำระเงิน";
            this.Button_Pay.UseVisualStyleBackColor = true;
            this.Button_Pay.Click += new System.EventHandler(this.Button_Pay_Click);
            // 
            // TextBox_CreditCardNumber
            // 
            this.TextBox_CreditCardNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_CreditCardNumber.Location = new System.Drawing.Point(722, 559);
            this.TextBox_CreditCardNumber.MaxLength = 16;
            this.TextBox_CreditCardNumber.Name = "TextBox_CreditCardNumber";
            this.TextBox_CreditCardNumber.Size = new System.Drawing.Size(120, 23);
            this.TextBox_CreditCardNumber.TabIndex = 19;
            this.TextBox_CreditCardNumber.TextChanged += new System.EventHandler(this.TextBox_CreditCardNumber_TextChanged);
            this.TextBox_CreditCardNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_CreditCardNumber_KeyDown);
            // 
            // RadioButton_CreditCard
            // 
            this.RadioButton_CreditCard.AutoSize = true;
            this.RadioButton_CreditCard.Checked = true;
            this.RadioButton_CreditCard.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_CreditCard.Location = new System.Drawing.Point(634, 560);
            this.RadioButton_CreditCard.Name = "RadioButton_CreditCard";
            this.RadioButton_CreditCard.Size = new System.Drawing.Size(82, 20);
            this.RadioButton_CreditCard.TabIndex = 17;
            this.RadioButton_CreditCard.TabStop = true;
            this.RadioButton_CreditCard.Text = "บัตรเครดิต";
            this.RadioButton_CreditCard.UseVisualStyleBackColor = true;
            this.RadioButton_CreditCard.CheckedChanged += new System.EventHandler(this.RadioButton_CreditCard_CheckedChanged);
            // 
            // RadioButton_Cash
            // 
            this.RadioButton_Cash.AutoSize = true;
            this.RadioButton_Cash.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_Cash.Location = new System.Drawing.Point(568, 560);
            this.RadioButton_Cash.Name = "RadioButton_Cash";
            this.RadioButton_Cash.Size = new System.Drawing.Size(60, 20);
            this.RadioButton_Cash.TabIndex = 16;
            this.RadioButton_Cash.Text = "เงินสด";
            this.RadioButton_Cash.UseVisualStyleBackColor = true;
            this.RadioButton_Cash.CheckedChanged += new System.EventHandler(this.RadioButton_Cash_CheckedChanged);
            // 
            // DataGridView_PaymentDetail_Summary
            // 
            this.DataGridView_PaymentDetail_Summary.AllowUserToAddRows = false;
            this.DataGridView_PaymentDetail_Summary.AllowUserToDeleteRows = false;
            this.DataGridView_PaymentDetail_Summary.AllowUserToResizeColumns = false;
            this.DataGridView_PaymentDetail_Summary.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridView_PaymentDetail_Summary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_PaymentDetail_Summary.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.DataGridView_PaymentDetail_Summary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_PaymentDetail_Summary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_PaymentDetail_Summary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_PaymentDetail_Summary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ItemName,
            this.Quantity,
            this.Discount,
            this.Price,
            this.TotalPrice,
            this.DeleteButton});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_PaymentDetail_Summary.DefaultCellStyle = dataGridViewCellStyle9;
            this.DataGridView_PaymentDetail_Summary.Location = new System.Drawing.Point(238, 324);
            this.DataGridView_PaymentDetail_Summary.MultiSelect = false;
            this.DataGridView_PaymentDetail_Summary.Name = "DataGridView_PaymentDetail_Summary";
            this.DataGridView_PaymentDetail_Summary.ReadOnly = true;
            this.DataGridView_PaymentDetail_Summary.RowHeadersVisible = false;
            this.DataGridView_PaymentDetail_Summary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_PaymentDetail_Summary.Size = new System.Drawing.Size(766, 200);
            this.DataGridView_PaymentDetail_Summary.TabIndex = 14;
            this.DataGridView_PaymentDetail_Summary.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_PaymentDetail_Summary_CellMouseLeave);
            this.DataGridView_PaymentDetail_Summary.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_PaymentDetail_Summary_CellMouseEnter);
            this.DataGridView_PaymentDetail_Summary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_PaymentDetail_Summary_CellClick);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.No.DefaultCellStyle = dataGridViewCellStyle3;
            this.No.HeaderText = "#";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 25;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ItemName.DefaultCellStyle = dataGridViewCellStyle4;
            this.ItemName.HeaderText = "รายการ";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemName.Width = 343;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.Quantity.HeaderText = "จำนวน";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Quantity.Width = 60;
            // 
            // Discount
            // 
            this.Discount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Discount.DefaultCellStyle = dataGridViewCellStyle6;
            this.Discount.HeaderText = "ส่วนลด";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            this.Discount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Discount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Price.DefaultCellStyle = dataGridViewCellStyle7;
            this.Price.HeaderText = "ราคา";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TotalPrice
            // 
            this.TotalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.TotalPrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.TotalPrice.HeaderText = "รวม";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TotalPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DeleteButton
            // 
            this.DeleteButton.HeaderText = "";
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.ReadOnly = true;
            this.DeleteButton.Width = 20;
            // 
            // Panel_OtherProductForm
            // 
            this.Panel_OtherProductForm.Location = new System.Drawing.Point(12, 288);
            this.Panel_OtherProductForm.Name = "Panel_OtherProductForm";
            this.Panel_OtherProductForm.Size = new System.Drawing.Size(220, 141);
            this.Panel_OtherProductForm.TabIndex = 24;
            // 
            // Button_Search_Book
            // 
            this.Button_Search_Book.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Search_Book.Location = new System.Drawing.Point(798, 296);
            this.Button_Search_Book.Name = "Button_Search_Book";
            this.Button_Search_Book.Size = new System.Drawing.Size(100, 23);
            this.Button_Search_Book.TabIndex = 25;
            this.Button_Search_Book.Text = "ค้นหาหนังสือ";
            this.Button_Search_Book.UseVisualStyleBackColor = true;
            this.Button_Search_Book.Click += new System.EventHandler(this.Button_Search_Book_Click);
            // 
            // Button_Search_Cd
            // 
            this.Button_Search_Cd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Search_Cd.Location = new System.Drawing.Point(904, 296);
            this.Button_Search_Cd.Name = "Button_Search_Cd";
            this.Button_Search_Cd.Size = new System.Drawing.Size(100, 23);
            this.Button_Search_Cd.TabIndex = 26;
            this.Button_Search_Cd.Text = "ค้นหาแผ่นซีดี";
            this.Button_Search_Cd.UseVisualStyleBackColor = true;
            this.Button_Search_Cd.Click += new System.EventHandler(this.Button_Search_Cd_Click);
            // 
            // TextBox_ProductBarcode
            // 
            this.TextBox_ProductBarcode.Location = new System.Drawing.Point(434, 298);
            this.TextBox_ProductBarcode.Name = "TextBox_ProductBarcode";
            this.TextBox_ProductBarcode.Size = new System.Drawing.Size(194, 20);
            this.TextBox_ProductBarcode.TabIndex = 27;
            // 
            // Button_Search_Product
            // 
            this.Button_Search_Product.Location = new System.Drawing.Point(634, 298);
            this.Button_Search_Product.Name = "Button_Search_Product";
            this.Button_Search_Product.Size = new System.Drawing.Size(75, 23);
            this.Button_Search_Product.TabIndex = 28;
            this.Button_Search_Product.Text = "Search";
            this.Button_Search_Product.UseVisualStyleBackColor = true;
            this.Button_Search_Product.Click += new System.EventHandler(this.Button_Search_Product_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 600);
            this.Controls.Add(this.Button_Search_Product);
            this.Controls.Add(this.TextBox_ProductBarcode);
            this.Controls.Add(this.Button_Search_Cd);
            this.Controls.Add(this.Button_Search_Book);
            this.Controls.Add(this.Panel_OtherProductForm);
            this.Controls.Add(this.CheckBox_AddFirstRegisterCost);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.TextBox_GrandTotal);
            this.Controls.Add(this.Button_Reset);
            this.Controls.Add(this.Button_Pay);
            this.Controls.Add(this.TextBox_CreditCardNumber);
            this.Controls.Add(this.RadioButton_CreditCard);
            this.Controls.Add(this.RadioButton_Cash);
            this.Controls.Add(this.DataGridView_PaymentDetail_Summary);
            this.Controls.Add(this.Panel_CourseForm);
            this.Controls.Add(this.Panel_StudentForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaymentForm";
            this.Text = "PaymentForm";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_PaymentDetail_Summary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_StudentForm;
        private System.Windows.Forms.Panel Panel_CourseForm;
        private System.Windows.Forms.CheckBox CheckBox_AddFirstRegisterCost;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox TextBox_GrandTotal;
        private System.Windows.Forms.Button Button_Reset;
        private System.Windows.Forms.Button Button_Pay;
        private System.Windows.Forms.TextBox TextBox_CreditCardNumber;
        private System.Windows.Forms.RadioButton RadioButton_CreditCard;
        private System.Windows.Forms.RadioButton RadioButton_Cash;
        private System.Windows.Forms.DataGridView DataGridView_PaymentDetail_Summary;
        private System.Windows.Forms.Panel Panel_OtherProductForm;
        private System.Windows.Forms.Button Button_Search_Book;
        private System.Windows.Forms.Button Button_Search_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewImageColumn DeleteButton;
        private System.Windows.Forms.TextBox TextBox_ProductBarcode;
        private System.Windows.Forms.Button Button_Search_Product;
    }
}