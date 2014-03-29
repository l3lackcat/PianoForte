namespace PianoForte.View
{
    partial class SearchCourseResultForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView_CourseInfo = new System.Windows.Forms.DataGridView();
            this.courseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfClassroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentPerClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CourseInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView_CourseInfo
            // 
            this.DataGridView_CourseInfo.AllowUserToAddRows = false;
            this.DataGridView_CourseInfo.AllowUserToDeleteRows = false;
            this.DataGridView_CourseInfo.AllowUserToResizeColumns = false;
            this.DataGridView_CourseInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            this.DataGridView_CourseInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridView_CourseInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.courseID,
            this.courseName,
            this.courseLevel,
            this.numberOfClassroom,
            this.courseFee,
            this.courseDuration,
            this.studentPerClass,
            this.status});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_CourseInfo.DefaultCellStyle = dataGridViewCellStyle11;
            this.DataGridView_CourseInfo.Location = new System.Drawing.Point(0, 0);
            this.DataGridView_CourseInfo.MultiSelect = false;
            this.DataGridView_CourseInfo.Name = "DataGridView_CourseInfo";
            this.DataGridView_CourseInfo.ReadOnly = true;
            this.DataGridView_CourseInfo.RowHeadersVisible = false;
            this.DataGridView_CourseInfo.RowTemplate.ReadOnly = true;
            this.DataGridView_CourseInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_CourseInfo.Size = new System.Drawing.Size(992, 399);
            this.DataGridView_CourseInfo.TabIndex = 7;
            this.DataGridView_CourseInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CourseInfo_CellDoubleClick);
            this.DataGridView_CourseInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CourseInfo_CellClick);
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
            this.courseID.Width = 65;
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
            this.courseName.Width = 174;
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
            this.courseLevel.Width = 175;
            // 
            // numberOfClassroom
            // 
            this.numberOfClassroom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.numberOfClassroom.DataPropertyName = "numberOfClassroom";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.numberOfClassroom.DefaultCellStyle = dataGridViewCellStyle6;
            this.numberOfClassroom.HeaderText = "จำนวนครั้ง";
            this.numberOfClassroom.Name = "numberOfClassroom";
            this.numberOfClassroom.ReadOnly = true;
            this.numberOfClassroom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.numberOfClassroom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // courseFee
            // 
            this.courseFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.courseFee.DataPropertyName = "price";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.courseFee.DefaultCellStyle = dataGridViewCellStyle7;
            this.courseFee.HeaderText = "ค่าเรียน";
            this.courseFee.Name = "courseFee";
            this.courseFee.ReadOnly = true;
            this.courseFee.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.courseFee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.courseFee.Width = 110;
            // 
            // courseDuration
            // 
            this.courseDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.courseDuration.DataPropertyName = "classroomDuration";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.courseDuration.DefaultCellStyle = dataGridViewCellStyle8;
            this.courseDuration.HeaderText = "จำนวนนาที";
            this.courseDuration.Name = "courseDuration";
            this.courseDuration.ReadOnly = true;
            this.courseDuration.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.courseDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.courseDuration.Width = 170;
            // 
            // studentPerClass
            // 
            this.studentPerClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.studentPerClass.DataPropertyName = "studentPerClassroom";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.studentPerClass.DefaultCellStyle = dataGridViewCellStyle9;
            this.studentPerClass.HeaderText = "จำนวนนักเรียน";
            this.studentPerClass.Name = "studentPerClass";
            this.studentPerClass.ReadOnly = true;
            this.studentPerClass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.studentPerClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.status.DataPropertyName = "status";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.status.DefaultCellStyle = dataGridViewCellStyle10;
            this.status.HeaderText = "สถานะ";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.status.Width = 80;
            // 
            // SearchCourseResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 399);
            this.Controls.Add(this.DataGridView_CourseInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchCourseResultForm";
            this.Text = "ผลการค้นหา";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_CourseInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView_CourseInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfClassroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentPerClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}