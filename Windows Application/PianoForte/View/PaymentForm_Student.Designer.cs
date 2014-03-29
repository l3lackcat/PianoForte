namespace PianoForte.View
{
    partial class PaymentForm_Student
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
            this.GroupBox_Student = new System.Windows.Forms.GroupBox();
            this.TextBox_StudentId_ForSearch = new System.Windows.Forms.TextBox();
            this.Button_Search_Student = new System.Windows.Forms.Button();
            this.GroupBox_StudentInfo = new System.Windows.Forms.GroupBox();
            this.Button_ViewStudentProfile = new System.Windows.Forms.Button();
            this.TextBox_StudentStatus = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TextBox_StudentId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBox_Firstname = new System.Windows.Forms.TextBox();
            this.TextBox_Nickname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBox_Lastname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.GroupBox_Student.SuspendLayout();
            this.GroupBox_StudentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox_Student
            // 
            this.GroupBox_Student.Controls.Add(this.TextBox_StudentId_ForSearch);
            this.GroupBox_Student.Controls.Add(this.Button_Search_Student);
            this.GroupBox_Student.Controls.Add(this.GroupBox_StudentInfo);
            this.GroupBox_Student.Controls.Add(this.label8);
            this.GroupBox_Student.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_Student.Location = new System.Drawing.Point(0, 0);
            this.GroupBox_Student.Name = "GroupBox_Student";
            this.GroupBox_Student.Size = new System.Drawing.Size(220, 270);
            this.GroupBox_Student.TabIndex = 1;
            this.GroupBox_Student.TabStop = false;
            this.GroupBox_Student.Text = "นักเรียน";
            // 
            // TextBox_StudentId_ForSearch
            // 
            this.TextBox_StudentId_ForSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_StudentId_ForSearch.Location = new System.Drawing.Point(90, 22);
            this.TextBox_StudentId_ForSearch.Name = "TextBox_StudentId_ForSearch";
            this.TextBox_StudentId_ForSearch.Size = new System.Drawing.Size(59, 23);
            this.TextBox_StudentId_ForSearch.TabIndex = 1;
            this.TextBox_StudentId_ForSearch.TextChanged += new System.EventHandler(this.TextBox_StudentId_ForSearch_TextChanged);
            this.TextBox_StudentId_ForSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_StudentId_ForSearch_KeyDown);
            // 
            // Button_Search_Student
            // 
            this.Button_Search_Student.Enabled = false;
            this.Button_Search_Student.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Search_Student.Location = new System.Drawing.Point(155, 22);
            this.Button_Search_Student.Name = "Button_Search_Student";
            this.Button_Search_Student.Size = new System.Drawing.Size(59, 23);
            this.Button_Search_Student.TabIndex = 1;
            this.Button_Search_Student.Text = "ค้นหา";
            this.Button_Search_Student.UseVisualStyleBackColor = true;
            this.Button_Search_Student.Click += new System.EventHandler(this.Button_Search_Student_Click);
            // 
            // GroupBox_StudentInfo
            // 
            this.GroupBox_StudentInfo.Controls.Add(this.Button_ViewStudentProfile);
            this.GroupBox_StudentInfo.Controls.Add(this.TextBox_StudentStatus);
            this.GroupBox_StudentInfo.Controls.Add(this.label12);
            this.GroupBox_StudentInfo.Controls.Add(this.label7);
            this.GroupBox_StudentInfo.Controls.Add(this.TextBox_StudentId);
            this.GroupBox_StudentInfo.Controls.Add(this.label6);
            this.GroupBox_StudentInfo.Controls.Add(this.TextBox_Firstname);
            this.GroupBox_StudentInfo.Controls.Add(this.TextBox_Nickname);
            this.GroupBox_StudentInfo.Controls.Add(this.label5);
            this.GroupBox_StudentInfo.Controls.Add(this.label4);
            this.GroupBox_StudentInfo.Controls.Add(this.TextBox_Lastname);
            this.GroupBox_StudentInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_StudentInfo.Location = new System.Drawing.Point(6, 47);
            this.GroupBox_StudentInfo.Name = "GroupBox_StudentInfo";
            this.GroupBox_StudentInfo.Size = new System.Drawing.Size(208, 211);
            this.GroupBox_StudentInfo.TabIndex = 31;
            this.GroupBox_StudentInfo.TabStop = false;
            // 
            // Button_ViewStudentProfile
            // 
            this.Button_ViewStudentProfile.AutoSize = true;
            this.Button_ViewStudentProfile.Enabled = false;
            this.Button_ViewStudentProfile.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_ViewStudentProfile.Location = new System.Drawing.Point(84, 169);
            this.Button_ViewStudentProfile.Name = "Button_ViewStudentProfile";
            this.Button_ViewStudentProfile.Size = new System.Drawing.Size(75, 26);
            this.Button_ViewStudentProfile.TabIndex = 4;
            this.Button_ViewStudentProfile.Text = "ดูข้อมูล";
            this.Button_ViewStudentProfile.UseVisualStyleBackColor = true;
            this.Button_ViewStudentProfile.Visible = false;
            this.Button_ViewStudentProfile.Click += new System.EventHandler(this.Button_ViewStudentProfile_Click);
            // 
            // TextBox_StudentStatus
            // 
            this.TextBox_StudentStatus.Enabled = false;
            this.TextBox_StudentStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_StudentStatus.Location = new System.Drawing.Point(84, 131);
            this.TextBox_StudentStatus.Name = "TextBox_StudentStatus";
            this.TextBox_StudentStatus.ReadOnly = true;
            this.TextBox_StudentStatus.Size = new System.Drawing.Size(90, 23);
            this.TextBox_StudentStatus.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(34, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 16);
            this.label12.TabIndex = 30;
            this.label12.Text = "สถานะ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "รหัสนักเรียน";
            // 
            // TextBox_StudentId
            // 
            this.TextBox_StudentId.Enabled = false;
            this.TextBox_StudentId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_StudentId.Location = new System.Drawing.Point(84, 14);
            this.TextBox_StudentId.Name = "TextBox_StudentId";
            this.TextBox_StudentId.ReadOnly = true;
            this.TextBox_StudentId.Size = new System.Drawing.Size(59, 23);
            this.TextBox_StudentId.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(54, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "ชื่อ";
            // 
            // TextBox_Firstname
            // 
            this.TextBox_Firstname.Enabled = false;
            this.TextBox_Firstname.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_Firstname.Location = new System.Drawing.Point(84, 43);
            this.TextBox_Firstname.Name = "TextBox_Firstname";
            this.TextBox_Firstname.ReadOnly = true;
            this.TextBox_Firstname.Size = new System.Drawing.Size(118, 23);
            this.TextBox_Firstname.TabIndex = 26;
            // 
            // TextBox_Nickname
            // 
            this.TextBox_Nickname.Enabled = false;
            this.TextBox_Nickname.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_Nickname.Location = new System.Drawing.Point(84, 102);
            this.TextBox_Nickname.Name = "TextBox_Nickname";
            this.TextBox_Nickname.ReadOnly = true;
            this.TextBox_Nickname.Size = new System.Drawing.Size(90, 23);
            this.TextBox_Nickname.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(24, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "นามสกุล";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(34, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "ชื่อเล่น";
            // 
            // TextBox_Lastname
            // 
            this.TextBox_Lastname.Enabled = false;
            this.TextBox_Lastname.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_Lastname.Location = new System.Drawing.Point(84, 73);
            this.TextBox_Lastname.Name = "TextBox_Lastname";
            this.TextBox_Lastname.ReadOnly = true;
            this.TextBox_Lastname.Size = new System.Drawing.Size(118, 23);
            this.TextBox_Lastname.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(12, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "รหัสนักเรียน";
            // 
            // PaymentForm_Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 270);
            this.Controls.Add(this.GroupBox_Student);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaymentForm_Student";
            this.GroupBox_Student.ResumeLayout(false);
            this.GroupBox_Student.PerformLayout();
            this.GroupBox_StudentInfo.ResumeLayout(false);
            this.GroupBox_StudentInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox_Student;
        private System.Windows.Forms.TextBox TextBox_StudentId_ForSearch;
        private System.Windows.Forms.Button Button_Search_Student;
        private System.Windows.Forms.GroupBox GroupBox_StudentInfo;
        private System.Windows.Forms.Button Button_ViewStudentProfile;
        private System.Windows.Forms.TextBox TextBox_StudentStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TextBox_StudentId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBox_Firstname;
        private System.Windows.Forms.TextBox TextBox_Nickname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBox_Lastname;
        private System.Windows.Forms.Label label8;
    }
}