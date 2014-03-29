namespace PianoForte.View
{
    partial class HolidayMainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HolidayMainForm));
            this.DataGridView_Holiday = new System.Windows.Forms.DataGridView();
            this.GroupBox_Search_Criteria = new System.Windows.Forms.GroupBox();
            this.Button_Search = new System.Windows.Forms.Button();
            this.ComboBox_Year = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBox_Month = new System.Windows.Forms.ComboBox();
            this.Button_Add_Holiday = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Holiday)).BeginInit();
            this.GroupBox_Search_Criteria.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView_Holiday
            // 
            this.DataGridView_Holiday.AllowUserToAddRows = false;
            this.DataGridView_Holiday.AllowUserToDeleteRows = false;
            this.DataGridView_Holiday.AllowUserToResizeColumns = false;
            this.DataGridView_Holiday.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.DataGridView_Holiday.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_Holiday.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.DataGridView_Holiday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_Holiday.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_Holiday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Holiday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Date,
            this.AdderName,
            this.DeleteButton});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_Holiday.DefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridView_Holiday.Location = new System.Drawing.Point(12, 70);
            this.DataGridView_Holiday.MultiSelect = false;
            this.DataGridView_Holiday.Name = "DataGridView_Holiday";
            this.DataGridView_Holiday.ReadOnly = true;
            this.DataGridView_Holiday.RowHeadersVisible = false;
            this.DataGridView_Holiday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Holiday.Size = new System.Drawing.Size(320, 238);
            this.DataGridView_Holiday.TabIndex = 8;
            this.DataGridView_Holiday.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Holiday_CellMouseLeave);
            this.DataGridView_Holiday.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Holiday_CellMouseEnter);
            this.DataGridView_Holiday.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Holiday_CellClick);
            // 
            // GroupBox_Search_Criteria
            // 
            this.GroupBox_Search_Criteria.Controls.Add(this.Button_Search);
            this.GroupBox_Search_Criteria.Controls.Add(this.ComboBox_Year);
            this.GroupBox_Search_Criteria.Controls.Add(this.label1);
            this.GroupBox_Search_Criteria.Controls.Add(this.label2);
            this.GroupBox_Search_Criteria.Controls.Add(this.ComboBox_Month);
            this.GroupBox_Search_Criteria.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_Search_Criteria.Location = new System.Drawing.Point(12, 12);
            this.GroupBox_Search_Criteria.Name = "GroupBox_Search_Criteria";
            this.GroupBox_Search_Criteria.Size = new System.Drawing.Size(320, 52);
            this.GroupBox_Search_Criteria.TabIndex = 9;
            this.GroupBox_Search_Criteria.TabStop = false;
            this.GroupBox_Search_Criteria.Text = "กำหนดข้อมูลการค้นหา";
            // 
            // Button_Search
            // 
            this.Button_Search.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Search.Location = new System.Drawing.Point(253, 22);
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Size = new System.Drawing.Size(61, 23);
            this.Button_Search.TabIndex = 5;
            this.Button_Search.Text = "ค้นหา";
            this.Button_Search.UseVisualStyleBackColor = true;
            this.Button_Search.Click += new System.EventHandler(this.Button_Search_Click);
            // 
            // ComboBox_Year
            // 
            this.ComboBox_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Year.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ComboBox_Year.FormattingEnabled = true;
            this.ComboBox_Year.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016"});
            this.ComboBox_Year.Location = new System.Drawing.Point(192, 22);
            this.ComboBox_Year.Name = "ComboBox_Year";
            this.ComboBox_Year.Size = new System.Drawing.Size(55, 24);
            this.ComboBox_Year.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(154, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "ค.ศ.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "เดือน";
            // 
            // ComboBox_Month
            // 
            this.ComboBox_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Month.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ComboBox_Month.FormattingEnabled = true;
            this.ComboBox_Month.Items.AddRange(new object[] {
            "ทั้งหมด",
            "มกราคม",
            "กุมภาพันธ์",
            "มีนาคม",
            "เมษายน",
            "พฤษภาคม",
            "มิถุนายน",
            "กรกฎาคม",
            "สิงหาคม",
            "กันยายน",
            "ตุลาคม",
            "พฤศจิกายน",
            "ธันวาคม"});
            this.ComboBox_Month.Location = new System.Drawing.Point(48, 22);
            this.ComboBox_Month.Name = "ComboBox_Month";
            this.ComboBox_Month.Size = new System.Drawing.Size(100, 24);
            this.ComboBox_Month.TabIndex = 0;
            // 
            // Button_Add_Holiday
            // 
            this.Button_Add_Holiday.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Add_Holiday.Location = new System.Drawing.Point(271, 314);
            this.Button_Add_Holiday.Name = "Button_Add_Holiday";
            this.Button_Add_Holiday.Size = new System.Drawing.Size(61, 23);
            this.Button_Add_Holiday.TabIndex = 10;
            this.Button_Add_Holiday.Text = "เพิ่ม";
            this.Button_Add_Holiday.UseVisualStyleBackColor = true;
            this.Button_Add_Holiday.Click += new System.EventHandler(this.Button_Add_Holiday_Click);
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
            this.No.Width = 30;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Date.DefaultCellStyle = dataGridViewCellStyle4;
            this.Date.HeaderText = "วันที่หยุด";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AdderName
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.AdderName.DefaultCellStyle = dataGridViewCellStyle5;
            this.AdderName.HeaderText = "โดย";
            this.AdderName.Name = "AdderName";
            this.AdderName.ReadOnly = true;
            this.AdderName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AdderName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AdderName.Width = 152;
            // 
            // DeleteButton
            // 
            this.DeleteButton.HeaderText = "";
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.ReadOnly = true;
            this.DeleteButton.Width = 20;
            // 
            // HolidayMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 345);
            this.Controls.Add(this.Button_Add_Holiday);
            this.Controls.Add(this.GroupBox_Search_Criteria);
            this.Controls.Add(this.DataGridView_Holiday);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HolidayMainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Holiday";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Holiday)).EndInit();
            this.GroupBox_Search_Criteria.ResumeLayout(false);
            this.GroupBox_Search_Criteria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView_Holiday;
        private System.Windows.Forms.GroupBox GroupBox_Search_Criteria;
        private System.Windows.Forms.ComboBox ComboBox_Month;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBox_Year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_Search;
        private System.Windows.Forms.Button Button_Add_Holiday;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdderName;
        private System.Windows.Forms.DataGridViewImageColumn DeleteButton;



    }
}