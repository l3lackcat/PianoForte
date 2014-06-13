namespace PianoForte.View
{
    partial class SearchCoursePopUp
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
            this.Button_SearchCourse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_CourseName = new System.Windows.Forms.TextBox();
            this.DataGridView_CourseList = new System.Windows.Forms.DataGridView();
            this.courseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CourseList)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_SearchCourse
            // 
            this.Button_SearchCourse.Location = new System.Drawing.Point(294, 12);
            this.Button_SearchCourse.Name = "Button_SearchCourse";
            this.Button_SearchCourse.Size = new System.Drawing.Size(75, 23);
            this.Button_SearchCourse.TabIndex = 9;
            this.Button_SearchCourse.Text = "ค้นหา";
            this.Button_SearchCourse.UseVisualStyleBackColor = true;
            this.Button_SearchCourse.Click += new System.EventHandler(this.Button_SearchCourse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "ชื่อวิชาเรียน";
            // 
            // TextBox_CourseName
            // 
            this.TextBox_CourseName.Location = new System.Drawing.Point(88, 12);
            this.TextBox_CourseName.Name = "TextBox_CourseName";
            this.TextBox_CourseName.Size = new System.Drawing.Size(200, 23);
            this.TextBox_CourseName.TabIndex = 7;
            this.TextBox_CourseName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_CourseName_KeyUp);
            // 
            // DataGridView_CourseList
            // 
            this.DataGridView_CourseList.AllowUserToAddRows = false;
            this.DataGridView_CourseList.AllowUserToDeleteRows = false;
            this.DataGridView_CourseList.AllowUserToResizeColumns = false;
            this.DataGridView_CourseList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataGridView_CourseList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_CourseList.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.DataGridView_CourseList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DataGridView_CourseList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_CourseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridView_CourseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.courseID,
            this.courseName,
            this.courseLevel,
            this.courseFee,
            this.status});
            this.DataGridView_CourseList.Location = new System.Drawing.Point(0, 41);
            this.DataGridView_CourseList.MultiSelect = false;
            this.DataGridView_CourseList.Name = "DataGridView_CourseList";
            this.DataGridView_CourseList.ReadOnly = true;
            this.DataGridView_CourseList.RowHeadersVisible = false;
            this.DataGridView_CourseList.RowTemplate.ReadOnly = true;
            this.DataGridView_CourseList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_CourseList.Size = new System.Drawing.Size(928, 354);
            this.DataGridView_CourseList.TabIndex = 10;
            this.DataGridView_CourseList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_CourseList_CellMouseDoubleClick);
            // 
            // courseID
            // 
            this.courseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.courseID.DataPropertyName = "id";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.courseID.DefaultCellStyle = dataGridViewCellStyle3;
            this.courseID.HeaderText = "รหัสวิชา";
            this.courseID.Name = "courseID";
            this.courseID.ReadOnly = true;
            this.courseID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.courseID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.courseID.Width = 125;
            // 
            // courseName
            // 
            this.courseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.courseName.DataPropertyName = "name";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.courseName.DefaultCellStyle = dataGridViewCellStyle4;
            this.courseName.HeaderText = "ชื่อวิชา";
            this.courseName.Name = "courseName";
            this.courseName.ReadOnly = true;
            this.courseName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.courseName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.courseName.Width = 300;
            // 
            // courseLevel
            // 
            this.courseLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.courseLevel.DataPropertyName = "level";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.courseLevel.DefaultCellStyle = dataGridViewCellStyle5;
            this.courseLevel.HeaderText = "ระดับชั้น";
            this.courseLevel.Name = "courseLevel";
            this.courseLevel.ReadOnly = true;
            this.courseLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.courseLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.courseLevel.Width = 300;
            // 
            // courseFee
            // 
            this.courseFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.courseFee.DataPropertyName = "price";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.courseFee.DefaultCellStyle = dataGridViewCellStyle6;
            this.courseFee.HeaderText = "ค่าเรียน";
            this.courseFee.Name = "courseFee";
            this.courseFee.ReadOnly = true;
            this.courseFee.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.courseFee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.courseFee.Width = 80;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.status.DataPropertyName = "status";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status.DefaultCellStyle = dataGridViewCellStyle7;
            this.status.HeaderText = "สถานะ";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.status.Width = 105;
            // 
            // SearchCoursePopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 395);
            this.Controls.Add(this.DataGridView_CourseList);
            this.Controls.Add(this.Button_SearchCourse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBox_CourseName);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SearchCoursePopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ค้นหาวิชาเรียน";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CourseList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_SearchCourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_CourseName;
        private System.Windows.Forms.DataGridView DataGridView_CourseList;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}