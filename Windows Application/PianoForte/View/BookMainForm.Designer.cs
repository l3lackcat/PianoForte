namespace PianoForte.View
{
    partial class BookMainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookMainForm));
            this.TabControl_Book = new System.Windows.Forms.TabControl();
            this.TabPage_Book_Main = new System.Windows.Forms.TabPage();
            this.Button_PreviousPage = new System.Windows.Forms.Button();
            this.Button_NextPage = new System.Windows.Forms.Button();
            this.TextBox_PageNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboBox_NumberPerPage = new System.Windows.Forms.ComboBox();
            this.DataGridView_BookInfo = new System.Windows.Forms.DataGridView();
            this.Button_Add_Book = new System.Windows.Forms.Button();
            this.GroupBox_SearchCriteria_Book = new System.Windows.Forms.GroupBox();
            this.RadioButton_Search_BookBarcode = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.TextBox_BookBarcode_ForSearch = new System.Windows.Forms.TextBox();
            this.ComboBox_Status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBox_BookName_ForSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RadioButton_Search_Info = new System.Windows.Forms.RadioButton();
            this.Button_Search = new System.Windows.Forms.Button();
            this.TextBox_BookId_ForSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RadioButton_Search_BookId = new System.Windows.Forms.RadioButton();
            this.RadioButton_Show_AllBook = new System.Windows.Forms.RadioButton();
            this.BookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.TabControl_Book.SuspendLayout();
            this.TabPage_Book_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_BookInfo)).BeginInit();
            this.GroupBox_SearchCriteria_Book.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl_Book
            // 
            this.TabControl_Book.Controls.Add(this.TabPage_Book_Main);
            this.TabControl_Book.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TabControl_Book.Location = new System.Drawing.Point(12, 12);
            this.TabControl_Book.Name = "TabControl_Book";
            this.TabControl_Book.SelectedIndex = 0;
            this.TabControl_Book.Size = new System.Drawing.Size(992, 576);
            this.TabControl_Book.TabIndex = 0;
            // 
            // TabPage_Book_Main
            // 
            this.TabPage_Book_Main.Controls.Add(this.Button_PreviousPage);
            this.TabPage_Book_Main.Controls.Add(this.Button_NextPage);
            this.TabPage_Book_Main.Controls.Add(this.TextBox_PageNumber);
            this.TabPage_Book_Main.Controls.Add(this.label6);
            this.TabPage_Book_Main.Controls.Add(this.ComboBox_NumberPerPage);
            this.TabPage_Book_Main.Controls.Add(this.DataGridView_BookInfo);
            this.TabPage_Book_Main.Controls.Add(this.Button_Add_Book);
            this.TabPage_Book_Main.Controls.Add(this.GroupBox_SearchCriteria_Book);
            this.TabPage_Book_Main.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Book_Main.Name = "TabPage_Book_Main";
            this.TabPage_Book_Main.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Book_Main.Size = new System.Drawing.Size(984, 547);
            this.TabPage_Book_Main.TabIndex = 0;
            this.TabPage_Book_Main.Text = "หนังสือ";
            this.TabPage_Book_Main.UseVisualStyleBackColor = true;
            // 
            // Button_PreviousPage
            // 
            this.Button_PreviousPage.Location = new System.Drawing.Point(449, 503);
            this.Button_PreviousPage.Name = "Button_PreviousPage";
            this.Button_PreviousPage.Size = new System.Drawing.Size(25, 25);
            this.Button_PreviousPage.TabIndex = 15;
            this.Button_PreviousPage.Text = "<";
            this.Button_PreviousPage.UseVisualStyleBackColor = true;
            this.Button_PreviousPage.Click += new System.EventHandler(this.Button_PreviousPage_Click);
            // 
            // Button_NextPage
            // 
            this.Button_NextPage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_NextPage.Location = new System.Drawing.Point(511, 503);
            this.Button_NextPage.Name = "Button_NextPage";
            this.Button_NextPage.Size = new System.Drawing.Size(25, 25);
            this.Button_NextPage.TabIndex = 14;
            this.Button_NextPage.Text = ">";
            this.Button_NextPage.UseVisualStyleBackColor = true;
            this.Button_NextPage.Click += new System.EventHandler(this.Button_NextPage_Click);
            // 
            // TextBox_PageNumber
            // 
            this.TextBox_PageNumber.Enabled = false;
            this.TextBox_PageNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_PageNumber.Location = new System.Drawing.Point(480, 504);
            this.TextBox_PageNumber.Name = "TextBox_PageNumber";
            this.TextBox_PageNumber.Size = new System.Drawing.Size(25, 23);
            this.TextBox_PageNumber.TabIndex = 13;
            this.TextBox_PageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox_PageNumber.TextChanged += new System.EventHandler(this.TextBox_PageNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 509);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "จำนวนต่อหน้า";
            // 
            // ComboBox_NumberPerPage
            // 
            this.ComboBox_NumberPerPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_NumberPerPage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ComboBox_NumberPerPage.FormattingEnabled = true;
            this.ComboBox_NumberPerPage.Location = new System.Drawing.Point(93, 504);
            this.ComboBox_NumberPerPage.Name = "ComboBox_NumberPerPage";
            this.ComboBox_NumberPerPage.Size = new System.Drawing.Size(50, 24);
            this.ComboBox_NumberPerPage.TabIndex = 11;
            this.ComboBox_NumberPerPage.SelectedIndexChanged += new System.EventHandler(this.ComboBox_NumberPerPage_SelectedIndexChanged);
            // 
            // DataGridView_BookInfo
            // 
            this.DataGridView_BookInfo.AllowUserToAddRows = false;
            this.DataGridView_BookInfo.AllowUserToDeleteRows = false;
            this.DataGridView_BookInfo.AllowUserToResizeColumns = false;
            this.DataGridView_BookInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.DataGridView_BookInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_BookInfo.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.DataGridView_BookInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_BookInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_BookInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_BookInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookId,
            this.BarcodeNumber,
            this.BookName,
            this.BookPrice,
            this.Quantity,
            this.Status,
            this.ViewButton,
            this.EditButton});
            this.DataGridView_BookInfo.Location = new System.Drawing.Point(6, 146);
            this.DataGridView_BookInfo.MultiSelect = false;
            this.DataGridView_BookInfo.Name = "DataGridView_BookInfo";
            this.DataGridView_BookInfo.ReadOnly = true;
            this.DataGridView_BookInfo.RowHeadersVisible = false;
            this.DataGridView_BookInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_BookInfo.Size = new System.Drawing.Size(972, 354);
            this.DataGridView_BookInfo.TabIndex = 5;
            this.DataGridView_BookInfo.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_BookInfo_CellMouseLeave);
            this.DataGridView_BookInfo.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_BookInfo_CellMouseEnter);
            this.DataGridView_BookInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_BookInfo_CellClick);
            // 
            // Button_Add_Book
            // 
            this.Button_Add_Book.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Add_Book.Location = new System.Drawing.Point(878, 506);
            this.Button_Add_Book.Name = "Button_Add_Book";
            this.Button_Add_Book.Size = new System.Drawing.Size(100, 23);
            this.Button_Add_Book.TabIndex = 2;
            this.Button_Add_Book.Text = "เพิ่ม";
            this.Button_Add_Book.UseVisualStyleBackColor = true;
            this.Button_Add_Book.Click += new System.EventHandler(this.Button_Add_Book_Click);
            // 
            // GroupBox_SearchCriteria_Book
            // 
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.RadioButton_Search_BookBarcode);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.label16);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.TextBox_BookBarcode_ForSearch);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.ComboBox_Status);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.label4);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.TextBox_BookName_ForSearch);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.label2);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.RadioButton_Search_Info);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.Button_Search);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.TextBox_BookId_ForSearch);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.label1);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.RadioButton_Search_BookId);
            this.GroupBox_SearchCriteria_Book.Controls.Add(this.RadioButton_Show_AllBook);
            this.GroupBox_SearchCriteria_Book.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_SearchCriteria_Book.Location = new System.Drawing.Point(6, 6);
            this.GroupBox_SearchCriteria_Book.Name = "GroupBox_SearchCriteria_Book";
            this.GroupBox_SearchCriteria_Book.Size = new System.Drawing.Size(972, 134);
            this.GroupBox_SearchCriteria_Book.TabIndex = 0;
            this.GroupBox_SearchCriteria_Book.TabStop = false;
            this.GroupBox_SearchCriteria_Book.Text = "กำหนดข้อมูลการค้นหา";
            // 
            // RadioButton_Search_BookBarcode
            // 
            this.RadioButton_Search_BookBarcode.AutoSize = true;
            this.RadioButton_Search_BookBarcode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_Search_BookBarcode.Location = new System.Drawing.Point(209, 39);
            this.RadioButton_Search_BookBarcode.Name = "RadioButton_Search_BookBarcode";
            this.RadioButton_Search_BookBarcode.Size = new System.Drawing.Size(120, 20);
            this.RadioButton_Search_BookBarcode.TabIndex = 14;
            this.RadioButton_Search_BookBarcode.TabStop = true;
            this.RadioButton_Search_BookBarcode.Text = "ค้นหาด้วยบาร์โค้ด";
            this.RadioButton_Search_BookBarcode.UseVisualStyleBackColor = true;
            this.RadioButton_Search_BookBarcode.CheckedChanged += new System.EventHandler(this.RadioButton_Search_BookBarcode_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label16.Location = new System.Drawing.Point(491, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 16);
            this.label16.TabIndex = 13;
            this.label16.Text = "ชื่อหนังสือ";
            // 
            // TextBox_BookBarcode_ForSearch
            // 
            this.TextBox_BookBarcode_ForSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_BookBarcode_ForSearch.Location = new System.Drawing.Point(282, 65);
            this.TextBox_BookBarcode_ForSearch.MaxLength = 15;
            this.TextBox_BookBarcode_ForSearch.Name = "TextBox_BookBarcode_ForSearch";
            this.TextBox_BookBarcode_ForSearch.Size = new System.Drawing.Size(100, 23);
            this.TextBox_BookBarcode_ForSearch.TabIndex = 12;
            this.TextBox_BookBarcode_ForSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_Barcode_ForSearch_KeyDown);
            // 
            // ComboBox_Status
            // 
            this.ComboBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Status.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ComboBox_Status.FormattingEnabled = true;
            this.ComboBox_Status.Location = new System.Drawing.Point(765, 65);
            this.ComboBox_Status.Name = "ComboBox_Status";
            this.ComboBox_Status.Size = new System.Drawing.Size(90, 24);
            this.ComboBox_Status.TabIndex = 11;
            this.ComboBox_Status.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBox_Status_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(715, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "สถานะ";
            // 
            // TextBox_BookName_ForSearch
            // 
            this.TextBox_BookName_ForSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_BookName_ForSearch.Location = new System.Drawing.Point(559, 65);
            this.TextBox_BookName_ForSearch.Name = "TextBox_BookName_ForSearch";
            this.TextBox_BookName_ForSearch.Size = new System.Drawing.Size(150, 23);
            this.TextBox_BookName_ForSearch.TabIndex = 7;
            this.TextBox_BookName_ForSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_BookName_ForSearch_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(226, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "บาร์โค้ด";
            // 
            // RadioButton_Search_Info
            // 
            this.RadioButton_Search_Info.AutoSize = true;
            this.RadioButton_Search_Info.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_Search_Info.Location = new System.Drawing.Point(474, 39);
            this.RadioButton_Search_Info.Name = "RadioButton_Search_Info";
            this.RadioButton_Search_Info.Size = new System.Drawing.Size(140, 20);
            this.RadioButton_Search_Info.TabIndex = 5;
            this.RadioButton_Search_Info.Text = "ค้นหาด้วยข้อมูลทั่วไป";
            this.RadioButton_Search_Info.UseVisualStyleBackColor = true;
            this.RadioButton_Search_Info.CheckedChanged += new System.EventHandler(this.RadioButton_Search_Info_CheckedChanged);
            this.RadioButton_Search_Info.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioButton_Search_Info_KeyDown);
            // 
            // Button_Search
            // 
            this.Button_Search.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Search.Location = new System.Drawing.Point(441, 105);
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Size = new System.Drawing.Size(90, 23);
            this.Button_Search.TabIndex = 4;
            this.Button_Search.Text = "ค้นหา";
            this.Button_Search.UseVisualStyleBackColor = true;
            this.Button_Search.Click += new System.EventHandler(this.Button_Search_Click);
            // 
            // TextBox_BookId_ForSearch
            // 
            this.TextBox_BookId_ForSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_BookId_ForSearch.Location = new System.Drawing.Point(97, 65);
            this.TextBox_BookId_ForSearch.Name = "TextBox_BookId_ForSearch";
            this.TextBox_BookId_ForSearch.Size = new System.Drawing.Size(60, 23);
            this.TextBox_BookId_ForSearch.TabIndex = 3;
            this.TextBox_BookId_ForSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_BookId_ForSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(23, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "รหัสหนังสือ";
            // 
            // RadioButton_Search_BookId
            // 
            this.RadioButton_Search_BookId.AutoSize = true;
            this.RadioButton_Search_BookId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_Search_BookId.Location = new System.Drawing.Point(6, 39);
            this.RadioButton_Search_BookId.Name = "RadioButton_Search_BookId";
            this.RadioButton_Search_BookId.Size = new System.Drawing.Size(138, 20);
            this.RadioButton_Search_BookId.TabIndex = 1;
            this.RadioButton_Search_BookId.Text = "ค้นหาด้วยรหัสหนังสือ";
            this.RadioButton_Search_BookId.UseVisualStyleBackColor = true;
            this.RadioButton_Search_BookId.CheckedChanged += new System.EventHandler(this.RadioButton_Search_BookId_CheckedChanged);
            this.RadioButton_Search_BookId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioButton_Search_BookId_KeyDown);
            // 
            // RadioButton_Show_AllBook
            // 
            this.RadioButton_Show_AllBook.AutoSize = true;
            this.RadioButton_Show_AllBook.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_Show_AllBook.Location = new System.Drawing.Point(6, 22);
            this.RadioButton_Show_AllBook.Name = "RadioButton_Show_AllBook";
            this.RadioButton_Show_AllBook.Size = new System.Drawing.Size(95, 20);
            this.RadioButton_Show_AllBook.TabIndex = 0;
            this.RadioButton_Show_AllBook.Text = "แสดงทั้งหมด";
            this.RadioButton_Show_AllBook.UseVisualStyleBackColor = true;
            this.RadioButton_Show_AllBook.CheckedChanged += new System.EventHandler(this.RadioButton_Show_AllBook_CheckedChanged);
            this.RadioButton_Show_AllBook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioButton_Show_AllBook_KeyDown);
            // 
            // BookId
            // 
            this.BookId.DataPropertyName = "id";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BookId.DefaultCellStyle = dataGridViewCellStyle3;
            this.BookId.HeaderText = "รหัสหนังสือ";
            this.BookId.Name = "BookId";
            this.BookId.ReadOnly = true;
            this.BookId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BookId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BarcodeNumber
            // 
            this.BarcodeNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BarcodeNumber.DataPropertyName = "barcode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BarcodeNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.BarcodeNumber.HeaderText = "หมายเลขบาร์โค้ด";
            this.BarcodeNumber.Name = "BarcodeNumber";
            this.BarcodeNumber.ReadOnly = true;
            this.BarcodeNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BarcodeNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BarcodeNumber.Width = 120;
            // 
            // BookName
            // 
            this.BookName.DataPropertyName = "name";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BookName.DefaultCellStyle = dataGridViewCellStyle5;
            this.BookName.HeaderText = "ชื่อหนังสือ";
            this.BookName.Name = "BookName";
            this.BookName.ReadOnly = true;
            this.BookName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BookName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BookName.Width = 374;
            // 
            // BookPrice
            // 
            this.BookPrice.DataPropertyName = "price";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.BookPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.BookPrice.HeaderText = "ราคา";
            this.BookPrice.Name = "BookPrice";
            this.BookPrice.ReadOnly = true;
            this.BookPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BookPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "quantity";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle7;
            this.Quantity.HeaderText = "คงเหลือ";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "status";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Status.DefaultCellStyle = dataGridViewCellStyle8;
            this.Status.HeaderText = "สถานะ";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Status.Width = 120;
            // 
            // ViewButton
            // 
            this.ViewButton.HeaderText = "";
            this.ViewButton.Image = ((System.Drawing.Image)(resources.GetObject("ViewButton.Image")));
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.ReadOnly = true;
            this.ViewButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ViewButton.Width = 20;
            // 
            // EditButton
            // 
            this.EditButton.HeaderText = "";
            this.EditButton.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Image")));
            this.EditButton.Name = "EditButton";
            this.EditButton.ReadOnly = true;
            this.EditButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EditButton.Width = 20;
            // 
            // BookMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 600);
            this.Controls.Add(this.TabControl_Book);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookMainForm";
            this.Text = "BookMainForm";
            this.Load += new System.EventHandler(this.BookMainForm_Load);
            this.TabControl_Book.ResumeLayout(false);
            this.TabPage_Book_Main.ResumeLayout(false);
            this.TabPage_Book_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_BookInfo)).EndInit();
            this.GroupBox_SearchCriteria_Book.ResumeLayout(false);
            this.GroupBox_SearchCriteria_Book.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl_Book;
        private System.Windows.Forms.TabPage TabPage_Book_Main;
        private System.Windows.Forms.GroupBox GroupBox_SearchCriteria_Book;
        private System.Windows.Forms.RadioButton RadioButton_Show_AllBook;
        private System.Windows.Forms.RadioButton RadioButton_Search_BookId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_BookId_ForSearch;
        private System.Windows.Forms.Button Button_Add_Book;
        private System.Windows.Forms.Button Button_Search;
        private System.Windows.Forms.ComboBox ComboBox_Status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBox_BookName_ForSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RadioButton_Search_Info;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TextBox_BookBarcode_ForSearch;
        private System.Windows.Forms.DataGridView DataGridView_BookInfo;
        private System.Windows.Forms.Button Button_PreviousPage;
        private System.Windows.Forms.Button Button_NextPage;
        private System.Windows.Forms.TextBox TextBox_PageNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboBox_NumberPerPage;
        private System.Windows.Forms.RadioButton RadioButton_Search_BookBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewImageColumn ViewButton;
        private System.Windows.Forms.DataGridViewImageColumn EditButton;
    }
}