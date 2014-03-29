namespace PianoForte.View
{
    partial class AddCourseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCourseForm));
            this.DataGridView_CourseLevel = new System.Windows.Forms.DataGridView();
            this.CourseLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfClassroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassroomDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPerClassroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.Button_AddNewLevel = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Button_OK = new System.Windows.Forms.Button();
            this.TextBox_CourseName = new System.Windows.Forms.TextBox();
            this.Button_Add_New_CourseCategory = new System.Windows.Forms.Button();
            this.ComboBox_CourseCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CourseLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView_CourseLevel
            // 
            this.DataGridView_CourseLevel.AllowUserToAddRows = false;
            this.DataGridView_CourseLevel.AllowUserToDeleteRows = false;
            this.DataGridView_CourseLevel.AllowUserToResizeColumns = false;
            this.DataGridView_CourseLevel.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridView_CourseLevel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_CourseLevel.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.DataGridView_CourseLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_CourseLevel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_CourseLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_CourseLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseLevel,
            this.NumberOfClassroom,
            this.CourseFee,
            this.ClassroomDuration,
            this.StudentPerClassroom,
            this.Status,
            this.EditButton,
            this.DeleteButton});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_CourseLevel.DefaultCellStyle = dataGridViewCellStyle9;
            this.DataGridView_CourseLevel.Location = new System.Drawing.Point(72, 71);
            this.DataGridView_CourseLevel.MultiSelect = false;
            this.DataGridView_CourseLevel.Name = "DataGridView_CourseLevel";
            this.DataGridView_CourseLevel.ReadOnly = true;
            this.DataGridView_CourseLevel.RowHeadersVisible = false;
            this.DataGridView_CourseLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_CourseLevel.Size = new System.Drawing.Size(660, 200);
            this.DataGridView_CourseLevel.TabIndex = 10;
            this.DataGridView_CourseLevel.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CourseLevel_CellMouseLeave);
            this.DataGridView_CourseLevel.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CourseLevel_CellMouseEnter);
            this.DataGridView_CourseLevel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CourseLevel_CellClick);
            // 
            // CourseLevel
            // 
            this.CourseLevel.DataPropertyName = "level";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CourseLevel.DefaultCellStyle = dataGridViewCellStyle3;
            this.CourseLevel.HeaderText = "ระดับชั้น";
            this.CourseLevel.Name = "CourseLevel";
            this.CourseLevel.ReadOnly = true;
            this.CourseLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CourseLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CourseLevel.Width = 172;
            // 
            // NumberOfClassroom
            // 
            this.NumberOfClassroom.DataPropertyName = "numberOfClassroom";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.NumberOfClassroom.DefaultCellStyle = dataGridViewCellStyle4;
            this.NumberOfClassroom.HeaderText = "จำนวนครั้ง";
            this.NumberOfClassroom.Name = "NumberOfClassroom";
            this.NumberOfClassroom.ReadOnly = true;
            this.NumberOfClassroom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NumberOfClassroom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumberOfClassroom.Width = 80;
            // 
            // CourseFee
            // 
            this.CourseFee.DataPropertyName = "price";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.CourseFee.DefaultCellStyle = dataGridViewCellStyle5;
            this.CourseFee.HeaderText = "ค่าเรียน";
            this.CourseFee.Name = "CourseFee";
            this.CourseFee.ReadOnly = true;
            this.CourseFee.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CourseFee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CourseFee.Width = 80;
            // 
            // ClassroomDuration
            // 
            this.ClassroomDuration.DataPropertyName = "classroomDuration";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ClassroomDuration.DefaultCellStyle = dataGridViewCellStyle6;
            this.ClassroomDuration.HeaderText = "ระยะเวลา(นาที)";
            this.ClassroomDuration.Name = "ClassroomDuration";
            this.ClassroomDuration.ReadOnly = true;
            this.ClassroomDuration.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClassroomDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StudentPerClassroom
            // 
            this.StudentPerClassroom.DataPropertyName = "studentPerClassroom";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.StudentPerClassroom.DefaultCellStyle = dataGridViewCellStyle7;
            this.StudentPerClassroom.HeaderText = "นักเรียนต่อห้อง";
            this.StudentPerClassroom.Name = "StudentPerClassroom";
            this.StudentPerClassroom.ReadOnly = true;
            this.StudentPerClassroom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StudentPerClassroom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.Status.Width = 70;
            // 
            // EditButton
            // 
            this.EditButton.HeaderText = "";
            this.EditButton.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Image")));
            this.EditButton.Name = "EditButton";
            this.EditButton.ReadOnly = true;
            this.EditButton.Width = 20;
            // 
            // DeleteButton
            // 
            this.DeleteButton.HeaderText = "";
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.ReadOnly = true;
            this.DeleteButton.Width = 20;
            // 
            // Button_AddNewLevel
            // 
            this.Button_AddNewLevel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_AddNewLevel.Location = new System.Drawing.Point(632, 42);
            this.Button_AddNewLevel.Name = "Button_AddNewLevel";
            this.Button_AddNewLevel.Size = new System.Drawing.Size(100, 23);
            this.Button_AddNewLevel.TabIndex = 3;
            this.Button_AddNewLevel.Text = "เพิ่มระดับชั้นใหม่";
            this.Button_AddNewLevel.UseVisualStyleBackColor = true;
            this.Button_AddNewLevel.Click += new System.EventHandler(this.Button_AddNewLevel_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Cancel.Location = new System.Drawing.Point(672, 277);
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
            this.Button_OK.Location = new System.Drawing.Point(606, 277);
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
            this.TextBox_CourseName.Location = new System.Drawing.Point(72, 42);
            this.TextBox_CourseName.Name = "TextBox_CourseName";
            this.TextBox_CourseName.Size = new System.Drawing.Size(296, 23);
            this.TextBox_CourseName.TabIndex = 2;
            this.TextBox_CourseName.TextChanged += new System.EventHandler(this.TextBox_CourseName_TextChanged);
            // 
            // Button_Add_New_CourseCategory
            // 
            this.Button_Add_New_CourseCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Add_New_CourseCategory.Location = new System.Drawing.Point(374, 12);
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
            this.ComboBox_CourseCategory.Location = new System.Drawing.Point(72, 12);
            this.ComboBox_CourseCategory.Name = "ComboBox_CourseCategory";
            this.ComboBox_CourseCategory.Size = new System.Drawing.Size(296, 24);
            this.ComboBox_CourseCategory.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ชื่อวิชา";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "หลักสูตร";
            // 
            // AddCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 312);
            this.Controls.Add(this.DataGridView_CourseLevel);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_AddNewLevel);
            this.Controls.Add(this.ComboBox_CourseCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Add_New_CourseCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBox_CourseName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCourseForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Course";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CourseLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_AddNewLevel;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.TextBox TextBox_CourseName;
        private System.Windows.Forms.Button Button_Add_New_CourseCategory;
        private System.Windows.Forms.ComboBox ComboBox_CourseCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridView_CourseLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfClassroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassroomDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPerClassroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewImageColumn EditButton;
        private System.Windows.Forms.DataGridViewImageColumn DeleteButton;
    }
}