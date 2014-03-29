namespace PianoForte.View
{
    partial class CourseRegisterForm
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
            this.GroupBox_Course = new System.Windows.Forms.GroupBox();
            this.GroupBox_CourseLevelList = new System.Windows.Forms.GroupBox();
            this.Button_EditLevel = new System.Windows.Forms.Button();
            this.Button_CancelLevel = new System.Windows.Forms.Button();
            this.Button_AddNewLevel = new System.Windows.Forms.Button();
            this.DataGridView_CourseLevel = new System.Windows.Forms.DataGridView();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoursePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Button_OK = new System.Windows.Forms.Button();
            this.TextBox_CourseName = new System.Windows.Forms.TextBox();
            this.Button_Add_New_CourseCategory = new System.Windows.Forms.Button();
            this.ComboBox_CourseCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_Edit = new System.Windows.Forms.Button();
            this.GroupBox_Course.SuspendLayout();
            this.GroupBox_CourseLevelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CourseLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox_Course
            // 
            this.GroupBox_Course.Controls.Add(this.GroupBox_CourseLevelList);
            this.GroupBox_Course.Controls.Add(this.Button_Cancel);
            this.GroupBox_Course.Controls.Add(this.Button_OK);
            this.GroupBox_Course.Controls.Add(this.TextBox_CourseName);
            this.GroupBox_Course.Controls.Add(this.Button_Add_New_CourseCategory);
            this.GroupBox_Course.Controls.Add(this.ComboBox_CourseCategory);
            this.GroupBox_Course.Controls.Add(this.label2);
            this.GroupBox_Course.Controls.Add(this.label1);
            this.GroupBox_Course.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_Course.Location = new System.Drawing.Point(159, 60);
            this.GroupBox_Course.Name = "GroupBox_Course";
            this.GroupBox_Course.Size = new System.Drawing.Size(700, 384);
            this.GroupBox_Course.TabIndex = 0;
            this.GroupBox_Course.TabStop = false;
            this.GroupBox_Course.Text = "ข้อมูลวิชาเรียน";
            // 
            // GroupBox_CourseLevelList
            // 
            this.GroupBox_CourseLevelList.Controls.Add(this.Button_EditLevel);
            this.GroupBox_CourseLevelList.Controls.Add(this.Button_CancelLevel);
            this.GroupBox_CourseLevelList.Controls.Add(this.Button_AddNewLevel);
            this.GroupBox_CourseLevelList.Controls.Add(this.DataGridView_CourseLevel);
            this.GroupBox_CourseLevelList.Location = new System.Drawing.Point(6, 88);
            this.GroupBox_CourseLevelList.Name = "GroupBox_CourseLevelList";
            this.GroupBox_CourseLevelList.Size = new System.Drawing.Size(688, 261);
            this.GroupBox_CourseLevelList.TabIndex = 8;
            this.GroupBox_CourseLevelList.TabStop = false;
            this.GroupBox_CourseLevelList.Text = "รายการระดับชั้น";
            // 
            // Button_EditLevel
            // 
            this.Button_EditLevel.Enabled = false;
            this.Button_EditLevel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_EditLevel.Location = new System.Drawing.Point(476, 21);
            this.Button_EditLevel.Name = "Button_EditLevel";
            this.Button_EditLevel.Size = new System.Drawing.Size(100, 23);
            this.Button_EditLevel.TabIndex = 8;
            this.Button_EditLevel.Text = "แก้ไขระดับชั้น";
            this.Button_EditLevel.UseVisualStyleBackColor = true;
            this.Button_EditLevel.Click += new System.EventHandler(this.Button_EditLevel_Click);
            // 
            // Button_CancelLevel
            // 
            this.Button_CancelLevel.Enabled = false;
            this.Button_CancelLevel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_CancelLevel.Location = new System.Drawing.Point(582, 21);
            this.Button_CancelLevel.Name = "Button_CancelLevel";
            this.Button_CancelLevel.Size = new System.Drawing.Size(100, 23);
            this.Button_CancelLevel.TabIndex = 7;
            this.Button_CancelLevel.Text = "ยกเลิกระดับชั้น";
            this.Button_CancelLevel.UseVisualStyleBackColor = true;
            this.Button_CancelLevel.Click += new System.EventHandler(this.Button_CancelLevel_Click);
            // 
            // Button_AddNewLevel
            // 
            this.Button_AddNewLevel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_AddNewLevel.Location = new System.Drawing.Point(370, 21);
            this.Button_AddNewLevel.Name = "Button_AddNewLevel";
            this.Button_AddNewLevel.Size = new System.Drawing.Size(100, 23);
            this.Button_AddNewLevel.TabIndex = 3;
            this.Button_AddNewLevel.Text = "เพิ่มระดับชั้นใหม่";
            this.Button_AddNewLevel.UseVisualStyleBackColor = true;
            this.Button_AddNewLevel.Click += new System.EventHandler(this.Button_AddNewLevel_Click);
            // 
            // DataGridView_CourseLevel
            // 
            this.DataGridView_CourseLevel.AllowUserToAddRows = false;
            this.DataGridView_CourseLevel.AllowUserToDeleteRows = false;
            this.DataGridView_CourseLevel.AllowUserToOrderColumns = true;
            this.DataGridView_CourseLevel.AllowUserToResizeColumns = false;
            this.DataGridView_CourseLevel.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridView_CourseLevel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_CourseLevel.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_CourseLevel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_CourseLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_CourseLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Level,
            this.CoursePrice,
            this.CourseDuration,
            this.NumberOfStudent,
            this.status});
            this.DataGridView_CourseLevel.Location = new System.Drawing.Point(6, 50);
            this.DataGridView_CourseLevel.Name = "DataGridView_CourseLevel";
            this.DataGridView_CourseLevel.ReadOnly = true;
            this.DataGridView_CourseLevel.RowHeadersVisible = false;
            this.DataGridView_CourseLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_CourseLevel.Size = new System.Drawing.Size(676, 205);
            this.DataGridView_CourseLevel.TabIndex = 5;
            this.DataGridView_CourseLevel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CourseLevel_CellContentClick);
            // 
            // Level
            // 
            this.Level.DataPropertyName = "level";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Level.DefaultCellStyle = dataGridViewCellStyle3;
            this.Level.HeaderText = "ระดับชั้น";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            this.Level.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Level.Width = 200;
            // 
            // CoursePrice
            // 
            this.CoursePrice.DataPropertyName = "price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.CoursePrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.CoursePrice.HeaderText = "ค่าเรียน(12 ครั้ง)";
            this.CoursePrice.Name = "CoursePrice";
            this.CoursePrice.ReadOnly = true;
            this.CoursePrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CoursePrice.Width = 125;
            // 
            // CourseDuration
            // 
            this.CourseDuration.DataPropertyName = "classDuration";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CourseDuration.DefaultCellStyle = dataGridViewCellStyle5;
            this.CourseDuration.HeaderText = "ระยะเวลาเรียน(นาที)";
            this.CourseDuration.Name = "CourseDuration";
            this.CourseDuration.ReadOnly = true;
            this.CourseDuration.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CourseDuration.Width = 150;
            // 
            // NumberOfStudent
            // 
            this.NumberOfStudent.DataPropertyName = "studentPerClass";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.NumberOfStudent.DefaultCellStyle = dataGridViewCellStyle6;
            this.NumberOfStudent.HeaderText = "จำนวณนักเรียน";
            this.NumberOfStudent.Name = "NumberOfStudent";
            this.NumberOfStudent.ReadOnly = true;
            this.NumberOfStudent.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NumberOfStudent.Width = 120;
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
            this.status.Width = 78;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Cancel.Location = new System.Drawing.Point(354, 355);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(60, 23);
            this.Button_Cancel.TabIndex = 7;
            this.Button_Cancel.Text = "ยกเลิก";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Button_OK
            // 
            this.Button_OK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_OK.Location = new System.Drawing.Point(288, 355);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(60, 23);
            this.Button_OK.TabIndex = 6;
            this.Button_OK.Text = "ตกลง";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // TextBox_CourseName
            // 
            this.TextBox_CourseName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_CourseName.Location = new System.Drawing.Point(74, 60);
            this.TextBox_CourseName.Name = "TextBox_CourseName";
            this.TextBox_CourseName.Size = new System.Drawing.Size(296, 23);
            this.TextBox_CourseName.TabIndex = 2;
            this.TextBox_CourseName.TextChanged += new System.EventHandler(this.TextBox_CourseName_TextChanged);
            // 
            // Button_Add_New_CourseCategory
            // 
            this.Button_Add_New_CourseCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Add_New_CourseCategory.Location = new System.Drawing.Point(376, 29);
            this.Button_Add_New_CourseCategory.Name = "Button_Add_New_CourseCategory";
            this.Button_Add_New_CourseCategory.Size = new System.Drawing.Size(110, 24);
            this.Button_Add_New_CourseCategory.TabIndex = 3;
            this.Button_Add_New_CourseCategory.Text = "เพิ่มหลักสูตรใหม่";
            this.Button_Add_New_CourseCategory.UseVisualStyleBackColor = true;
            this.Button_Add_New_CourseCategory.Click += new System.EventHandler(this.Button_Add_New_CourseCategory_Click);
            // 
            // ComboBox_CourseCategory
            // 
            this.ComboBox_CourseCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_CourseCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ComboBox_CourseCategory.FormattingEnabled = true;
            this.ComboBox_CourseCategory.Location = new System.Drawing.Point(74, 30);
            this.ComboBox_CourseCategory.Name = "ComboBox_CourseCategory";
            this.ComboBox_CourseCategory.Size = new System.Drawing.Size(296, 24);
            this.ComboBox_CourseCategory.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(29, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ชื่อวิชา";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "หลักสูตร";
            // 
            // Button_Edit
            // 
            this.Button_Edit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Edit.Location = new System.Drawing.Point(479, 450);
            this.Button_Edit.Name = "Button_Edit";
            this.Button_Edit.Size = new System.Drawing.Size(60, 23);
            this.Button_Edit.TabIndex = 2;
            this.Button_Edit.Text = "แก้ไข";
            this.Button_Edit.UseVisualStyleBackColor = true;
            this.Button_Edit.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // CourseRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 600);
            this.Controls.Add(this.Button_Edit);
            this.Controls.Add(this.GroupBox_Course);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CourseRegisterForm";
            this.Text = "เพิ่มวิชาเรียน";
            this.Load += new System.EventHandler(this.CourseRegisterForm_Load);
            this.GroupBox_Course.ResumeLayout(false);
            this.GroupBox_Course.PerformLayout();
            this.GroupBox_CourseLevelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CourseLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox_Course;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBox_CourseCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_Add_New_CourseCategory;
        private System.Windows.Forms.TextBox TextBox_CourseName;
        private System.Windows.Forms.DataGridView DataGridView_CourseLevel;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.GroupBox GroupBox_CourseLevelList;
        private System.Windows.Forms.Button Button_AddNewLevel;
        private System.Windows.Forms.Button Button_CancelLevel;
        private System.Windows.Forms.Button Button_EditLevel;
        private System.Windows.Forms.Button Button_Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoursePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}