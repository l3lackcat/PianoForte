namespace PianoForte.View
{
    partial class SearchBookPopUp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView_BookList = new System.Windows.Forms.DataGridView();
            this.TextBox_BookName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_SearchBook = new System.Windows.Forms.Button();
            this.barcodeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_BookList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView_BookList
            // 
            this.DataGridView_BookList.AllowUserToAddRows = false;
            this.DataGridView_BookList.AllowUserToDeleteRows = false;
            this.DataGridView_BookList.AllowUserToResizeColumns = false;
            this.DataGridView_BookList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.DataGridView_BookList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_BookList.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.DataGridView_BookList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_BookList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_BookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_BookList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcodeNumber,
            this.name,
            this.price,
            this.quantity,
            this.status});
            this.DataGridView_BookList.Location = new System.Drawing.Point(0, 41);
            this.DataGridView_BookList.MultiSelect = false;
            this.DataGridView_BookList.Name = "DataGridView_BookList";
            this.DataGridView_BookList.ReadOnly = true;
            this.DataGridView_BookList.RowHeadersVisible = false;
            this.DataGridView_BookList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_BookList.Size = new System.Drawing.Size(758, 354);
            this.DataGridView_BookList.TabIndex = 3;
            this.DataGridView_BookList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_BookList_CellMouseDoubleClick);
            // 
            // TextBox_BookName
            // 
            this.TextBox_BookName.Location = new System.Drawing.Point(80, 12);
            this.TextBox_BookName.Name = "TextBox_BookName";
            this.TextBox_BookName.Size = new System.Drawing.Size(200, 23);
            this.TextBox_BookName.TabIndex = 4;
            this.TextBox_BookName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_BookName_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "ชื่อหนังสือ";
            // 
            // Button_SearchBook
            // 
            this.Button_SearchBook.Location = new System.Drawing.Point(286, 12);
            this.Button_SearchBook.Name = "Button_SearchBook";
            this.Button_SearchBook.Size = new System.Drawing.Size(75, 23);
            this.Button_SearchBook.TabIndex = 6;
            this.Button_SearchBook.Text = "ค้นหา";
            this.Button_SearchBook.UseVisualStyleBackColor = true;
            this.Button_SearchBook.Click += new System.EventHandler(this.Button_SearchBook_Click);
            // 
            // barcodeNumber
            // 
            this.barcodeNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.barcodeNumber.DataPropertyName = "barcode";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.barcodeNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.barcodeNumber.HeaderText = "หมายเลขบาร์โค้ด";
            this.barcodeNumber.Name = "barcodeNumber";
            this.barcodeNumber.ReadOnly = true;
            this.barcodeNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.barcodeNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.barcodeNumber.Width = 125;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.name.DefaultCellStyle = dataGridViewCellStyle4;
            this.name.HeaderText = "ชื่อหนังสือ";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name.Width = 350;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.price.DefaultCellStyle = dataGridViewCellStyle5;
            this.price.HeaderText = "ราคา";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price.Width = 80;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.quantity.DefaultCellStyle = dataGridViewCellStyle6;
            this.quantity.HeaderText = "คงเหลือ";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantity.Width = 80;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status.DefaultCellStyle = dataGridViewCellStyle7;
            this.status.HeaderText = "สถานะ";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.status.Width = 105;
            // 
            // SearchBookPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 395);
            this.Controls.Add(this.Button_SearchBook);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBox_BookName);
            this.Controls.Add(this.DataGridView_BookList);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SearchBookPopUp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ค้นหาหนังสือ";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_BookList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView_BookList;
        private System.Windows.Forms.TextBox TextBox_BookName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_SearchBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}