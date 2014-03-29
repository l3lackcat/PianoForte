namespace PianoForte.View
{
    partial class CourseMainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseMainForm));
            this.GroupBox_SearchCriteria_Course = new System.Windows.Forms.GroupBox();
            this.TextBox_CourseName_ForSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBox_Status = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBox_CourseCategory = new System.Windows.Forms.ComboBox();
            this.RadioButton_Show_AllCourse = new System.Windows.Forms.RadioButton();
            this.Button_Search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RadioButton_Search_CourseCategory = new System.Windows.Forms.RadioButton();
            this.Button_Add = new System.Windows.Forms.Button();
            this.DataGridView_CourseInfo = new System.Windows.Forms.DataGridView();
            this.Button_PreviousPage = new System.Windows.Forms.Button();
            this.Button_NextPage = new System.Windows.Forms.Button();
            this.TextBox_PageNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboBox_NumberPerPage = new System.Windows.Forms.ComboBox();
            this.CourseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfClassroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassroomDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPerClassroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.GroupBox_SearchCriteria_Course.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CourseInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox_SearchCriteria_Course
            // 
            this.GroupBox_SearchCriteria_Course.Controls.Add(this.TextBox_CourseName_ForSearch);
            this.GroupBox_SearchCriteria_Course.Controls.Add(this.label3);
            this.GroupBox_SearchCriteria_Course.Controls.Add(this.ComboBox_Status);
            this.GroupBox_SearchCriteria_Course.Controls.Add(this.label1);
            this.GroupBox_SearchCriteria_Course.Controls.Add(this.ComboBox_CourseCategory);
            this.GroupBox_SearchCriteria_Course.Controls.Add(this.RadioButton_Show_AllCourse);
            this.GroupBox_SearchCriteria_Course.Controls.Add(this.Button_Search);
            this.GroupBox_SearchCriteria_Course.Controls.Add(this.label2);
            this.GroupBox_SearchCriteria_Course.Controls.Add(this.RadioButton_Search_CourseCategory);
            this.GroupBox_SearchCriteria_Course.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_SearchCriteria_Course.Location = new System.Drawing.Point(12, 12);
            this.GroupBox_SearchCriteria_Course.Name = "GroupBox_SearchCriteria_Course";
            this.GroupBox_SearchCriteria_Course.Size = new System.Drawing.Size(992, 126);
            this.GroupBox_SearchCriteria_Course.TabIndex = 9;
            this.GroupBox_SearchCriteria_Course.TabStop = false;
            this.GroupBox_SearchCriteria_Course.Text = "กำหนดข้อมูลการค้นหา";
            // 
            // TextBox_CourseName_ForSearch
            // 
            this.TextBox_CourseName_ForSearch.Enabled = false;
            this.TextBox_CourseName_ForSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_CourseName_ForSearch.Location = new System.Drawing.Point(389, 68);
            this.TextBox_CourseName_ForSearch.Name = "TextBox_CourseName_ForSearch";
            this.TextBox_CourseName_ForSearch.Size = new System.Drawing.Size(200, 23);
            this.TextBox_CourseName_ForSearch.TabIndex = 16;
            this.TextBox_CourseName_ForSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_CourseName_ForSearch_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(339, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "ชื่อวิชา";
            // 
            // ComboBox_Status
            // 
            this.ComboBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Status.Enabled = false;
            this.ComboBox_Status.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ComboBox_Status.FormattingEnabled = true;
            this.ComboBox_Status.Location = new System.Drawing.Point(645, 68);
            this.ComboBox_Status.Name = "ComboBox_Status";
            this.ComboBox_Status.Size = new System.Drawing.Size(100, 24);
            this.ComboBox_Status.TabIndex = 14;
            this.ComboBox_Status.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBox_Status_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(595, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "สถานะ";
            // 
            // ComboBox_CourseCategory
            // 
            this.ComboBox_CourseCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_CourseCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ComboBox_CourseCategory.FormattingEnabled = true;
            this.ComboBox_CourseCategory.Location = new System.Drawing.Point(83, 68);
            this.ComboBox_CourseCategory.Name = "ComboBox_CourseCategory";
            this.ComboBox_CourseCategory.Size = new System.Drawing.Size(250, 24);
            this.ComboBox_CourseCategory.TabIndex = 12;
            this.ComboBox_CourseCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBox_CourseCategory_KeyDown);
            // 
            // RadioButton_Show_AllCourse
            // 
            this.RadioButton_Show_AllCourse.AutoSize = true;
            this.RadioButton_Show_AllCourse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_Show_AllCourse.Location = new System.Drawing.Point(6, 22);
            this.RadioButton_Show_AllCourse.Name = "RadioButton_Show_AllCourse";
            this.RadioButton_Show_AllCourse.Size = new System.Drawing.Size(95, 20);
            this.RadioButton_Show_AllCourse.TabIndex = 11;
            this.RadioButton_Show_AllCourse.Text = "แสดงทั้งหมด";
            this.RadioButton_Show_AllCourse.UseVisualStyleBackColor = true;
            this.RadioButton_Show_AllCourse.CheckedChanged += new System.EventHandler(this.RadioButton_Show_AllCourse_CheckedChanged);
            this.RadioButton_Show_AllCourse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioButton_Show_AllCourse_KeyDown);
            // 
            // Button_Search
            // 
            this.Button_Search.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Search.Location = new System.Drawing.Point(451, 97);
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Size = new System.Drawing.Size(90, 23);
            this.Button_Search.TabIndex = 10;
            this.Button_Search.Text = "ค้นหา";
            this.Button_Search.UseVisualStyleBackColor = true;
            this.Button_Search.Click += new System.EventHandler(this.Button_Search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(23, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "หลักสูตร";
            // 
            // RadioButton_Search_CourseCategory
            // 
            this.RadioButton_Search_CourseCategory.AutoSize = true;
            this.RadioButton_Search_CourseCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_Search_CourseCategory.Location = new System.Drawing.Point(6, 48);
            this.RadioButton_Search_CourseCategory.Name = "RadioButton_Search_CourseCategory";
            this.RadioButton_Search_CourseCategory.Size = new System.Drawing.Size(124, 20);
            this.RadioButton_Search_CourseCategory.TabIndex = 1;
            this.RadioButton_Search_CourseCategory.Text = "ค้นหาด้วยหลักสูตร";
            this.RadioButton_Search_CourseCategory.UseVisualStyleBackColor = true;
            this.RadioButton_Search_CourseCategory.CheckedChanged += new System.EventHandler(this.RadioButton_Search_CourseCategory_CheckedChanged);
            this.RadioButton_Search_CourseCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioButton_Search_CourseCategory_KeyDown);
            // 
            // Button_Add
            // 
            this.Button_Add.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Add.Location = new System.Drawing.Point(904, 570);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(100, 25);
            this.Button_Add.TabIndex = 7;
            this.Button_Add.Text = "เพิ่ม";
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // DataGridView_CourseInfo
            // 
            this.DataGridView_CourseInfo.AllowUserToAddRows = false;
            this.DataGridView_CourseInfo.AllowUserToDeleteRows = false;
            this.DataGridView_CourseInfo.AllowUserToResizeColumns = false;
            this.DataGridView_CourseInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.DataGridView_CourseInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_CourseInfo.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.DataGridView_CourseInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DataGridView_CourseInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_CourseInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_CourseInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseId,
            this.CourseName,
            this.CourseLevel,
            this.NumberOfClassroom,
            this.CourseFee,
            this.ClassroomDuration,
            this.StudentPerClassroom,
            this.Status,
            this.ViewButton,
            this.EditButton,
            this.DeleteButton});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_CourseInfo.DefaultCellStyle = dataGridViewCellStyle11;
            this.DataGridView_CourseInfo.Location = new System.Drawing.Point(12, 144);
            this.DataGridView_CourseInfo.MultiSelect = false;
            this.DataGridView_CourseInfo.Name = "DataGridView_CourseInfo";
            this.DataGridView_CourseInfo.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_CourseInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.DataGridView_CourseInfo.RowHeadersVisible = false;
            this.DataGridView_CourseInfo.RowTemplate.ReadOnly = true;
            this.DataGridView_CourseInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_CourseInfo.Size = new System.Drawing.Size(992, 420);
            this.DataGridView_CourseInfo.TabIndex = 11;
            this.DataGridView_CourseInfo.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CourseInfo_CellMouseLeave);
            this.DataGridView_CourseInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CourseInfo_CellDoubleClick);
            this.DataGridView_CourseInfo.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CourseInfo_CellMouseEnter);
            this.DataGridView_CourseInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CourseInfo_CellClick);
            this.DataGridView_CourseInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CourseInfo_CellContentClick);
            // 
            // Button_PreviousPage
            // 
            this.Button_PreviousPage.Location = new System.Drawing.Point(466, 570);
            this.Button_PreviousPage.Name = "Button_PreviousPage";
            this.Button_PreviousPage.Size = new System.Drawing.Size(25, 25);
            this.Button_PreviousPage.TabIndex = 16;
            this.Button_PreviousPage.Text = "<";
            this.Button_PreviousPage.UseVisualStyleBackColor = true;
            this.Button_PreviousPage.Click += new System.EventHandler(this.Button_PreviousPage_Click);
            // 
            // Button_NextPage
            // 
            this.Button_NextPage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_NextPage.Location = new System.Drawing.Point(528, 570);
            this.Button_NextPage.Name = "Button_NextPage";
            this.Button_NextPage.Size = new System.Drawing.Size(25, 25);
            this.Button_NextPage.TabIndex = 15;
            this.Button_NextPage.Text = ">";
            this.Button_NextPage.UseVisualStyleBackColor = true;
            this.Button_NextPage.Click += new System.EventHandler(this.Button_NextPage_Click);
            // 
            // TextBox_PageNumber
            // 
            this.TextBox_PageNumber.Enabled = false;
            this.TextBox_PageNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_PageNumber.Location = new System.Drawing.Point(497, 571);
            this.TextBox_PageNumber.Name = "TextBox_PageNumber";
            this.TextBox_PageNumber.Size = new System.Drawing.Size(25, 23);
            this.TextBox_PageNumber.TabIndex = 14;
            this.TextBox_PageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox_PageNumber.TextChanged += new System.EventHandler(this.TextBox_PageNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 576);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "จำนวนต่อหน้า";
            // 
            // ComboBox_NumberPerPage
            // 
            this.ComboBox_NumberPerPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_NumberPerPage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ComboBox_NumberPerPage.FormattingEnabled = true;
            this.ComboBox_NumberPerPage.Location = new System.Drawing.Point(88, 571);
            this.ComboBox_NumberPerPage.Name = "ComboBox_NumberPerPage";
            this.ComboBox_NumberPerPage.Size = new System.Drawing.Size(50, 24);
            this.ComboBox_NumberPerPage.TabIndex = 12;
            this.ComboBox_NumberPerPage.SelectedIndexChanged += new System.EventHandler(this.ComboBox_NumberPerPage_SelectedIndexChanged);
            // 
            // CourseId
            // 
            this.CourseId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CourseId.DataPropertyName = "id";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CourseId.DefaultCellStyle = dataGridViewCellStyle3;
            this.CourseId.HeaderText = "รหัสวิชา";
            this.CourseId.Name = "CourseId";
            this.CourseId.ReadOnly = true;
            this.CourseId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CourseId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CourseName
            // 
            this.CourseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CourseName.DataPropertyName = "name";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CourseName.DefaultCellStyle = dataGridViewCellStyle4;
            this.CourseName.HeaderText = "ชื่อวิชา";
            this.CourseName.Name = "CourseName";
            this.CourseName.ReadOnly = true;
            this.CourseName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CourseName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CourseName.Width = 180;
            // 
            // CourseLevel
            // 
            this.CourseLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CourseLevel.DataPropertyName = "level";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CourseLevel.DefaultCellStyle = dataGridViewCellStyle5;
            this.CourseLevel.HeaderText = "ระดับชั้น";
            this.CourseLevel.Name = "CourseLevel";
            this.CourseLevel.ReadOnly = true;
            this.CourseLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CourseLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CourseLevel.Width = 214;
            // 
            // NumberOfClassroom
            // 
            this.NumberOfClassroom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumberOfClassroom.DataPropertyName = "numberOfClassroom";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.NumberOfClassroom.DefaultCellStyle = dataGridViewCellStyle6;
            this.NumberOfClassroom.HeaderText = "จำนวนครั้ง";
            this.NumberOfClassroom.Name = "NumberOfClassroom";
            this.NumberOfClassroom.ReadOnly = true;
            this.NumberOfClassroom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NumberOfClassroom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumberOfClassroom.Width = 80;
            // 
            // CourseFee
            // 
            this.CourseFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CourseFee.DataPropertyName = "price";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.CourseFee.DefaultCellStyle = dataGridViewCellStyle7;
            this.CourseFee.HeaderText = "ค่าเรียน";
            this.CourseFee.Name = "CourseFee";
            this.CourseFee.ReadOnly = true;
            this.CourseFee.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CourseFee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CourseFee.Width = 80;
            // 
            // ClassroomDuration
            // 
            this.ClassroomDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClassroomDuration.DataPropertyName = "classroomDuration";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ClassroomDuration.DefaultCellStyle = dataGridViewCellStyle8;
            this.ClassroomDuration.HeaderText = "จำนวนนาที";
            this.ClassroomDuration.Name = "ClassroomDuration";
            this.ClassroomDuration.ReadOnly = true;
            this.ClassroomDuration.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClassroomDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClassroomDuration.Width = 80;
            // 
            // StudentPerClassroom
            // 
            this.StudentPerClassroom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StudentPerClassroom.DataPropertyName = "studentPerClassroom";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.StudentPerClassroom.DefaultCellStyle = dataGridViewCellStyle9;
            this.StudentPerClassroom.HeaderText = "จำนวนนักเรียน";
            this.StudentPerClassroom.Name = "StudentPerClassroom";
            this.StudentPerClassroom.ReadOnly = true;
            this.StudentPerClassroom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StudentPerClassroom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status.DataPropertyName = "status";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Status.DefaultCellStyle = dataGridViewCellStyle10;
            this.Status.HeaderText = "สถานะ";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Status.Width = 80;
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
            // DeleteButton
            // 
            this.DeleteButton.HeaderText = "";
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.ReadOnly = true;
            this.DeleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DeleteButton.Width = 20;
            // 
            // CourseMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 600);
            this.Controls.Add(this.Button_PreviousPage);
            this.Controls.Add(this.Button_NextPage);
            this.Controls.Add(this.TextBox_PageNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ComboBox_NumberPerPage);
            this.Controls.Add(this.DataGridView_CourseInfo);
            this.Controls.Add(this.GroupBox_SearchCriteria_Course);
            this.Controls.Add(this.Button_Add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CourseMainForm";
            this.Text = "CourseMainForm";
            this.Load += new System.EventHandler(this.CourseMainForm_Load);
            this.GroupBox_SearchCriteria_Course.ResumeLayout(false);
            this.GroupBox_SearchCriteria_Course.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CourseInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox_SearchCriteria_Course;
        private System.Windows.Forms.RadioButton RadioButton_Show_AllCourse;
        private System.Windows.Forms.Button Button_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RadioButton_Search_CourseCategory;
        private System.Windows.Forms.Button Button_Add;
        private System.Windows.Forms.ComboBox ComboBox_CourseCategory;
        private System.Windows.Forms.ComboBox ComboBox_Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_CourseName_ForSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DataGridView_CourseInfo;
        private System.Windows.Forms.Button Button_PreviousPage;
        private System.Windows.Forms.Button Button_NextPage;
        private System.Windows.Forms.TextBox TextBox_PageNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboBox_NumberPerPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfClassroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassroomDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPerClassroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewImageColumn ViewButton;
        private System.Windows.Forms.DataGridViewImageColumn EditButton;
        private System.Windows.Forms.DataGridViewImageColumn DeleteButton;
    }
}