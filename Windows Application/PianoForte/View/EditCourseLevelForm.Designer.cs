namespace PianoForte.View
{
    partial class EditCourseLevelForm
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
            this.label10 = new System.Windows.Forms.Label();
            this.TextBox_ClassroomDuration = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBox_NumberOfClassroom = new System.Windows.Forms.ComboBox();
            this.ComboBox_CourseStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TextBox_CourseFee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Label_RedStar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RadioButton_Group = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.RadioButton_Individual = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.Button_Cancel_CourseLevel = new System.Windows.Forms.Button();
            this.Button_Submit_CourseLevel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBox_CourseLevelName = new System.Windows.Forms.TextBox();
            this.TextBox_NumberOfStudent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(171, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 16);
            this.label10.TabIndex = 47;
            this.label10.Text = "*";
            // 
            // TextBox_ClassroomDuration
            // 
            this.TextBox_ClassroomDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_ClassroomDuration.Location = new System.Drawing.Point(92, 71);
            this.TextBox_ClassroomDuration.Name = "TextBox_ClassroomDuration";
            this.TextBox_ClassroomDuration.Size = new System.Drawing.Size(50, 22);
            this.TextBox_ClassroomDuration.TabIndex = 46;
            this.TextBox_ClassroomDuration.TextChanged += new System.EventHandler(this.TextBox_ClassroomDuration_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(148, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "ครั้ง";
            // 
            // ComboBox_NumberOfClassroom
            // 
            this.ComboBox_NumberOfClassroom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_NumberOfClassroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ComboBox_NumberOfClassroom.FormattingEnabled = true;
            this.ComboBox_NumberOfClassroom.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.ComboBox_NumberOfClassroom.Location = new System.Drawing.Point(92, 41);
            this.ComboBox_NumberOfClassroom.Name = "ComboBox_NumberOfClassroom";
            this.ComboBox_NumberOfClassroom.Size = new System.Drawing.Size(50, 24);
            this.ComboBox_NumberOfClassroom.TabIndex = 44;
            // 
            // ComboBox_CourseStatus
            // 
            this.ComboBox_CourseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_CourseStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ComboBox_CourseStatus.FormattingEnabled = true;
            this.ComboBox_CourseStatus.Location = new System.Drawing.Point(92, 125);
            this.ComboBox_CourseStatus.Name = "ComboBox_CourseStatus";
            this.ComboBox_CourseStatus.Size = new System.Drawing.Size(121, 24);
            this.ComboBox_CourseStatus.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(42, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "สถานะ";
            // 
            // TextBox_CourseFee
            // 
            this.TextBox_CourseFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_CourseFee.Location = new System.Drawing.Point(181, 41);
            this.TextBox_CourseFee.Name = "TextBox_CourseFee";
            this.TextBox_CourseFee.Size = new System.Drawing.Size(75, 22);
            this.TextBox_CourseFee.TabIndex = 30;
            this.TextBox_CourseFee.TextChanged += new System.EventHandler(this.TextBox_CourseFee_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(262, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "บาท";
            // 
            // Label_RedStar
            // 
            this.Label_RedStar.AutoSize = true;
            this.Label_RedStar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_RedStar.ForeColor = System.Drawing.Color.Red;
            this.Label_RedStar.Location = new System.Drawing.Point(285, 44);
            this.Label_RedStar.Name = "Label_RedStar";
            this.Label_RedStar.Size = new System.Drawing.Size(13, 16);
            this.Label_RedStar.TabIndex = 40;
            this.Label_RedStar.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(44, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "ค่าเรียน";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(12, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = "จำนวนนักเรียน";
            // 
            // RadioButton_Group
            // 
            this.RadioButton_Group.AutoSize = true;
            this.RadioButton_Group.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_Group.Location = new System.Drawing.Point(168, 99);
            this.RadioButton_Group.Name = "RadioButton_Group";
            this.RadioButton_Group.Size = new System.Drawing.Size(67, 20);
            this.RadioButton_Group.TabIndex = 38;
            this.RadioButton_Group.Text = "เรียนกลุ่ม";
            this.RadioButton_Group.UseVisualStyleBackColor = true;
            this.RadioButton_Group.CheckedChanged += new System.EventHandler(this.RadioButton_Group_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(12, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "ระยะเวลาเรียน";
            // 
            // RadioButton_Individual
            // 
            this.RadioButton_Individual.AutoSize = true;
            this.RadioButton_Individual.Checked = true;
            this.RadioButton_Individual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_Individual.Location = new System.Drawing.Point(92, 99);
            this.RadioButton_Individual.Name = "RadioButton_Individual";
            this.RadioButton_Individual.Size = new System.Drawing.Size(70, 20);
            this.RadioButton_Individual.TabIndex = 34;
            this.RadioButton_Individual.TabStop = true;
            this.RadioButton_Individual.Text = "เรียนเดี่ยว";
            this.RadioButton_Individual.UseVisualStyleBackColor = true;
            this.RadioButton_Individual.CheckedChanged += new System.EventHandler(this.RadioButton_Individual_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(148, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "นาที";
            // 
            // Button_Cancel_CourseLevel
            // 
            this.Button_Cancel_CourseLevel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Cancel_CourseLevel.Location = new System.Drawing.Point(158, 155);
            this.Button_Cancel_CourseLevel.Name = "Button_Cancel_CourseLevel";
            this.Button_Cancel_CourseLevel.Size = new System.Drawing.Size(60, 23);
            this.Button_Cancel_CourseLevel.TabIndex = 12;
            this.Button_Cancel_CourseLevel.Text = "ยกเลิก";
            this.Button_Cancel_CourseLevel.UseVisualStyleBackColor = true;
            this.Button_Cancel_CourseLevel.Click += new System.EventHandler(this.Button_Cancel_CourseLevel_Click);
            // 
            // Button_Submit_CourseLevel
            // 
            this.Button_Submit_CourseLevel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Submit_CourseLevel.Location = new System.Drawing.Point(92, 155);
            this.Button_Submit_CourseLevel.Name = "Button_Submit_CourseLevel";
            this.Button_Submit_CourseLevel.Size = new System.Drawing.Size(60, 23);
            this.Button_Submit_CourseLevel.TabIndex = 11;
            this.Button_Submit_CourseLevel.Text = "ตกลง";
            this.Button_Submit_CourseLevel.UseVisualStyleBackColor = true;
            this.Button_Submit_CourseLevel.Click += new System.EventHandler(this.Button_Submit_CourseLevel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(18, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "ชื่อระดับชั้น";
            // 
            // TextBox_CourseLevelName
            // 
            this.TextBox_CourseLevelName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_CourseLevelName.Location = new System.Drawing.Point(92, 12);
            this.TextBox_CourseLevelName.Name = "TextBox_CourseLevelName";
            this.TextBox_CourseLevelName.Size = new System.Drawing.Size(262, 23);
            this.TextBox_CourseLevelName.TabIndex = 1;
            // 
            // TextBox_NumberOfStudent
            // 
            this.TextBox_NumberOfStudent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_NumberOfStudent.Location = new System.Drawing.Point(241, 98);
            this.TextBox_NumberOfStudent.MaxLength = 2;
            this.TextBox_NumberOfStudent.Name = "TextBox_NumberOfStudent";
            this.TextBox_NumberOfStudent.Size = new System.Drawing.Size(25, 23);
            this.TextBox_NumberOfStudent.TabIndex = 48;
            this.TextBox_NumberOfStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox_NumberOfStudent.TextChanged += new System.EventHandler(this.TextBox_NumberOfStudent_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(272, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "คน";
            // 
            // EditCourseLevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 190);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBox_NumberOfStudent);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Button_Cancel_CourseLevel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Button_Submit_CourseLevel);
            this.Controls.Add(this.ComboBox_CourseStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextBox_ClassroomDuration);
            this.Controls.Add(this.TextBox_CourseLevelName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RadioButton_Group);
            this.Controls.Add(this.ComboBox_NumberOfClassroom);
            this.Controls.Add(this.TextBox_CourseFee);
            this.Controls.Add(this.RadioButton_Individual);
            this.Controls.Add(this.Label_RedStar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCourseLevelForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Course Level";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBox_CourseStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TextBox_CourseFee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Label_RedStar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton RadioButton_Group;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton RadioButton_Individual;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Button_Cancel_CourseLevel;
        private System.Windows.Forms.Button Button_Submit_CourseLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBox_CourseLevelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBox_NumberOfClassroom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TextBox_ClassroomDuration;
        private System.Windows.Forms.TextBox TextBox_NumberOfStudent;
        private System.Windows.Forms.Label label1;
    }
}