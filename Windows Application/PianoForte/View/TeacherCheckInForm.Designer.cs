namespace PianoForte.View
{
    partial class TeacherCheckInForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView_TeacherDetail = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckedInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckInButton = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_TeacherDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView_TeacherDetail
            // 
            this.DataGridView_TeacherDetail.AllowUserToAddRows = false;
            this.DataGridView_TeacherDetail.AllowUserToDeleteRows = false;
            this.DataGridView_TeacherDetail.AllowUserToResizeColumns = false;
            this.DataGridView_TeacherDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.DataGridView_TeacherDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            this.DataGridView_TeacherDetail.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.DataGridView_TeacherDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_TeacherDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.DataGridView_TeacherDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_TeacherDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.TeacherId,
            this.TeacherName,
            this.CheckedInTime,
            this.CheckInButton});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_TeacherDetail.DefaultCellStyle = dataGridViewCellStyle21;
            this.DataGridView_TeacherDetail.Location = new System.Drawing.Point(0, 0);
            this.DataGridView_TeacherDetail.MultiSelect = false;
            this.DataGridView_TeacherDetail.Name = "DataGridView_TeacherDetail";
            this.DataGridView_TeacherDetail.ReadOnly = true;
            this.DataGridView_TeacherDetail.RowHeadersVisible = false;
            this.DataGridView_TeacherDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_TeacherDetail.Size = new System.Drawing.Size(400, 300);
            this.DataGridView_TeacherDetail.TabIndex = 7;
            this.DataGridView_TeacherDetail.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_TeacherDetail_CellMouseLeave);
            this.DataGridView_TeacherDetail.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_TeacherDetail_CellMouseEnter);
            this.DataGridView_TeacherDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_TeacherDetail_CellClick);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.No.DefaultCellStyle = dataGridViewCellStyle17;
            this.No.HeaderText = "#";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 30;
            // 
            // TeacherId
            // 
            this.TeacherId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeacherId.DefaultCellStyle = dataGridViewCellStyle18;
            this.TeacherId.HeaderText = "ID";
            this.TeacherId.Name = "TeacherId";
            this.TeacherId.ReadOnly = true;
            this.TeacherId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TeacherId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TeacherId.Width = 60;
            // 
            // TeacherName
            // 
            this.TeacherName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TeacherName.DefaultCellStyle = dataGridViewCellStyle19;
            this.TeacherName.HeaderText = "ชื่อ-สกุล";
            this.TeacherName.Name = "TeacherName";
            this.TeacherName.ReadOnly = true;
            this.TeacherName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TeacherName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TeacherName.Width = 172;
            // 
            // CheckedInTime
            // 
            this.CheckedInTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CheckedInTime.DefaultCellStyle = dataGridViewCellStyle20;
            this.CheckedInTime.HeaderText = "เวลาเช็คอิน";
            this.CheckedInTime.Name = "CheckedInTime";
            this.CheckedInTime.ReadOnly = true;
            this.CheckedInTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CheckedInTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CheckInButton
            // 
            this.CheckInButton.HeaderText = "";
            this.CheckInButton.Name = "CheckInButton";
            this.CheckInButton.ReadOnly = true;
            this.CheckInButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CheckInButton.Width = 20;
            // 
            // TeacherCheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.DataGridView_TeacherDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeacherCheckInForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Teacher Check-In";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_TeacherDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView_TeacherDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckedInTime;
        private System.Windows.Forms.DataGridViewImageColumn CheckInButton;
    }
}