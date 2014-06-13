namespace PianoForte.View
{
    partial class SearchCDPopUp
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
            this.DataGridView_CDList = new System.Windows.Forms.DataGridView();
            this.Button_SearchCD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_CDName = new System.Windows.Forms.TextBox();
            this.barcodeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CDList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView_CDList
            // 
            this.DataGridView_CDList.AllowUserToAddRows = false;
            this.DataGridView_CDList.AllowUserToDeleteRows = false;
            this.DataGridView_CDList.AllowUserToResizeColumns = false;
            this.DataGridView_CDList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.DataGridView_CDList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_CDList.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.DataGridView_CDList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_CDList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_CDList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_CDList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcodeNumber,
            this.name,
            this.price,
            this.quantity,
            this.status});
            this.DataGridView_CDList.Location = new System.Drawing.Point(0, 41);
            this.DataGridView_CDList.MultiSelect = false;
            this.DataGridView_CDList.Name = "DataGridView_CDList";
            this.DataGridView_CDList.ReadOnly = true;
            this.DataGridView_CDList.RowHeadersVisible = false;
            this.DataGridView_CDList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_CDList.Size = new System.Drawing.Size(758, 354);
            this.DataGridView_CDList.TabIndex = 4;
            this.DataGridView_CDList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_CDList_CellMouseDoubleClick);
            // 
            // Button_SearchCD
            // 
            this.Button_SearchCD.Location = new System.Drawing.Point(264, 12);
            this.Button_SearchCD.Name = "Button_SearchCD";
            this.Button_SearchCD.Size = new System.Drawing.Size(75, 23);
            this.Button_SearchCD.TabIndex = 9;
            this.Button_SearchCD.Text = "ค้นหา";
            this.Button_SearchCD.UseVisualStyleBackColor = true;
            this.Button_SearchCD.Click += new System.EventHandler(this.Button_SearchCD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "ชื่อ CD";
            // 
            // TextBox_CDName
            // 
            this.TextBox_CDName.Location = new System.Drawing.Point(58, 12);
            this.TextBox_CDName.Name = "TextBox_CDName";
            this.TextBox_CDName.Size = new System.Drawing.Size(200, 23);
            this.TextBox_CDName.TabIndex = 7;
            this.TextBox_CDName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_CDName_KeyUp);
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
            // SearchCDPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 395);
            this.Controls.Add(this.Button_SearchCD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBox_CDName);
            this.Controls.Add(this.DataGridView_CDList);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SearchCDPopUp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ค้นหา CD";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CDList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView_CDList;
        private System.Windows.Forms.Button Button_SearchCD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_CDName;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}