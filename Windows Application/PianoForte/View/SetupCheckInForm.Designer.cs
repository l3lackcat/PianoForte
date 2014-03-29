namespace PianoForte.View
{
    partial class SetupCheckInForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupCheckInForm));
            this.Label_RoomNumber = new System.Windows.Forms.Label();
            this.DataGridView_ClassroomDetail = new System.Windows.Forms.DataGridView();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassroomStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassroomEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassroomStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox_ClassroomDetail = new System.Windows.Forms.GroupBox();
            this.GroupBox_TeacherDetail = new System.Windows.Forms.GroupBox();
            this.Button_Add_TeacherDetail = new System.Windows.Forms.Button();
            this.DataGridView_TeacherDetail = new System.Windows.Forms.DataGridView();
            this.TeacherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_ClassroomDetail)).BeginInit();
            this.GroupBox_ClassroomDetail.SuspendLayout();
            this.GroupBox_TeacherDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_TeacherDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_RoomNumber
            // 
            this.Label_RoomNumber.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_RoomNumber.Location = new System.Drawing.Point(12, 9);
            this.Label_RoomNumber.Name = "Label_RoomNumber";
            this.Label_RoomNumber.Size = new System.Drawing.Size(740, 30);
            this.Label_RoomNumber.TabIndex = 1;
            this.Label_RoomNumber.Text = "Room Number";
            this.Label_RoomNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataGridView_ClassroomDetail
            // 
            this.DataGridView_ClassroomDetail.AllowUserToAddRows = false;
            this.DataGridView_ClassroomDetail.AllowUserToDeleteRows = false;
            this.DataGridView_ClassroomDetail.AllowUserToResizeColumns = false;
            this.DataGridView_ClassroomDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.DataGridView_ClassroomDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_ClassroomDetail.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.DataGridView_ClassroomDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_ClassroomDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_ClassroomDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_ClassroomDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentName,
            this.ClassroomStartTime,
            this.ClassroomEndTime,
            this.ClassroomStatus});
            this.DataGridView_ClassroomDetail.Location = new System.Drawing.Point(6, 22);
            this.DataGridView_ClassroomDetail.MultiSelect = false;
            this.DataGridView_ClassroomDetail.Name = "DataGridView_ClassroomDetail";
            this.DataGridView_ClassroomDetail.ReadOnly = true;
            this.DataGridView_ClassroomDetail.RowHeadersVisible = false;
            this.DataGridView_ClassroomDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_ClassroomDetail.Size = new System.Drawing.Size(400, 266);
            this.DataGridView_ClassroomDetail.TabIndex = 3;
            // 
            // StudentName
            // 
            this.StudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.StudentName.DefaultCellStyle = dataGridViewCellStyle3;
            this.StudentName.HeaderText = "นักเรียน";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            this.StudentName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StudentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StudentName.Width = 180;
            // 
            // ClassroomStartTime
            // 
            this.ClassroomStartTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ClassroomStartTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.ClassroomStartTime.HeaderText = "เริ่ม";
            this.ClassroomStartTime.Name = "ClassroomStartTime";
            this.ClassroomStartTime.ReadOnly = true;
            this.ClassroomStartTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClassroomStartTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClassroomStartTime.Width = 61;
            // 
            // ClassroomEndTime
            // 
            this.ClassroomEndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ClassroomEndTime.DefaultCellStyle = dataGridViewCellStyle5;
            this.ClassroomEndTime.HeaderText = "ถึง";
            this.ClassroomEndTime.Name = "ClassroomEndTime";
            this.ClassroomEndTime.ReadOnly = true;
            this.ClassroomEndTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClassroomEndTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClassroomEndTime.Width = 61;
            // 
            // ClassroomStatus
            // 
            this.ClassroomStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ClassroomStatus.DefaultCellStyle = dataGridViewCellStyle6;
            this.ClassroomStatus.HeaderText = "สถานะ";
            this.ClassroomStatus.Name = "ClassroomStatus";
            this.ClassroomStatus.ReadOnly = true;
            this.ClassroomStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClassroomStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClassroomStatus.Width = 80;
            // 
            // GroupBox_ClassroomDetail
            // 
            this.GroupBox_ClassroomDetail.Controls.Add(this.DataGridView_ClassroomDetail);
            this.GroupBox_ClassroomDetail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_ClassroomDetail.Location = new System.Drawing.Point(340, 42);
            this.GroupBox_ClassroomDetail.Name = "GroupBox_ClassroomDetail";
            this.GroupBox_ClassroomDetail.Size = new System.Drawing.Size(412, 301);
            this.GroupBox_ClassroomDetail.TabIndex = 4;
            this.GroupBox_ClassroomDetail.TabStop = false;
            this.GroupBox_ClassroomDetail.Text = "ตารางเรียน";
            // 
            // GroupBox_TeacherDetail
            // 
            this.GroupBox_TeacherDetail.Controls.Add(this.Button_Add_TeacherDetail);
            this.GroupBox_TeacherDetail.Controls.Add(this.DataGridView_TeacherDetail);
            this.GroupBox_TeacherDetail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_TeacherDetail.Location = new System.Drawing.Point(12, 42);
            this.GroupBox_TeacherDetail.Name = "GroupBox_TeacherDetail";
            this.GroupBox_TeacherDetail.Size = new System.Drawing.Size(322, 301);
            this.GroupBox_TeacherDetail.TabIndex = 6;
            this.GroupBox_TeacherDetail.TabStop = false;
            this.GroupBox_TeacherDetail.Text = "ตารางครู";
            // 
            // Button_Add_TeacherDetail
            // 
            this.Button_Add_TeacherDetail.Location = new System.Drawing.Point(6, 272);
            this.Button_Add_TeacherDetail.Name = "Button_Add_TeacherDetail";
            this.Button_Add_TeacherDetail.Size = new System.Drawing.Size(75, 23);
            this.Button_Add_TeacherDetail.TabIndex = 8;
            this.Button_Add_TeacherDetail.Text = "เพิ่ม";
            this.Button_Add_TeacherDetail.UseVisualStyleBackColor = true;
            this.Button_Add_TeacherDetail.Click += new System.EventHandler(this.Button_Add_TeacherDetail_Click);
            // 
            // DataGridView_TeacherDetail
            // 
            this.DataGridView_TeacherDetail.AllowUserToAddRows = false;
            this.DataGridView_TeacherDetail.AllowUserToDeleteRows = false;
            this.DataGridView_TeacherDetail.AllowUserToResizeColumns = false;
            this.DataGridView_TeacherDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.DataGridView_TeacherDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridView_TeacherDetail.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.DataGridView_TeacherDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_TeacherDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DataGridView_TeacherDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_TeacherDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeacherName,
            this.StartTime,
            this.EndTime,
            this.ViewButton,
            this.EditButton,
            this.DeleteButton});
            this.DataGridView_TeacherDetail.Location = new System.Drawing.Point(6, 22);
            this.DataGridView_TeacherDetail.MultiSelect = false;
            this.DataGridView_TeacherDetail.Name = "DataGridView_TeacherDetail";
            this.DataGridView_TeacherDetail.ReadOnly = true;
            this.DataGridView_TeacherDetail.RowHeadersVisible = false;
            this.DataGridView_TeacherDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_TeacherDetail.Size = new System.Drawing.Size(310, 244);
            this.DataGridView_TeacherDetail.TabIndex = 6;
            this.DataGridView_TeacherDetail.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_TeacherDetail_CellMouseLeave);
            this.DataGridView_TeacherDetail.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_TeacherDetail_CellMouseEnter);
            this.DataGridView_TeacherDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_TeacherDetail_CellClick);
            // 
            // TeacherName
            // 
            this.TeacherName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TeacherName.DefaultCellStyle = dataGridViewCellStyle9;
            this.TeacherName.HeaderText = "คุณครู";
            this.TeacherName.Name = "TeacherName";
            this.TeacherName.ReadOnly = true;
            this.TeacherName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TeacherName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TeacherName.Width = 132;
            // 
            // StartTime
            // 
            this.StartTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.StartTime.DefaultCellStyle = dataGridViewCellStyle10;
            this.StartTime.HeaderText = "เริ่ม";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StartTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartTime.Width = 50;
            // 
            // EndTime
            // 
            this.EndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.EndTime.DefaultCellStyle = dataGridViewCellStyle11;
            this.EndTime.HeaderText = "ถึง";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EndTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EndTime.Width = 50;
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
            // SetupCheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 355);
            this.Controls.Add(this.GroupBox_TeacherDetail);
            this.Controls.Add(this.GroupBox_ClassroomDetail);
            this.Controls.Add(this.Label_RoomNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupCheckInForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room Setup";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_ClassroomDetail)).EndInit();
            this.GroupBox_ClassroomDetail.ResumeLayout(false);
            this.GroupBox_TeacherDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_TeacherDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label_RoomNumber;
        private System.Windows.Forms.DataGridView DataGridView_ClassroomDetail;
        private System.Windows.Forms.GroupBox GroupBox_ClassroomDetail;
        private System.Windows.Forms.GroupBox GroupBox_TeacherDetail;
        private System.Windows.Forms.Button Button_Add_TeacherDetail;
        private System.Windows.Forms.DataGridView DataGridView_TeacherDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassroomStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassroomEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassroomStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewImageColumn ViewButton;
        private System.Windows.Forms.DataGridViewImageColumn EditButton;
        private System.Windows.Forms.DataGridViewImageColumn DeleteButton;
    }
}