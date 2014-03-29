namespace PianoForte.View
{
    partial class EnrollmentForm
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
            this.GroupBox_Enrollment = new System.Windows.Forms.GroupBox();
            this.Button_Reset = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Button_Submit = new System.Windows.Forms.Button();
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail = new System.Windows.Forms.Label();
            this.ComboBox_NumberOfClassroomDetail = new System.Windows.Forms.ComboBox();
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail = new System.Windows.Forms.Label();
            this.GroupBox_Classroom_Frequency = new System.Windows.Forms.GroupBox();
            this.RadioButton_OneClassPerWeek = new System.Windows.Forms.RadioButton();
            this.RadioButton_TwoClassPerDay = new System.Windows.Forms.RadioButton();
            this.RadioButton_TwoClassPerWeek = new System.Windows.Forms.RadioButton();
            this.GroupBox_Classroom1 = new System.Windows.Forms.GroupBox();
            this.Label_RequireField_TextBox_Classroom1_Duration = new System.Windows.Forms.Label();
            this.TextBox_Classroom1_Duration = new System.Windows.Forms.TextBox();
            this.Label_Prefix_TextBox_Classroom1_Duration = new System.Windows.Forms.Label();
            this.Label_Postfix_TextBox_Classroom1_Duration = new System.Windows.Forms.Label();
            this.Label_Prefix_ComboBox_Classroom1_Teacher = new System.Windows.Forms.Label();
            this.ComboBox_Classroom1_Teacher = new System.Windows.Forms.ComboBox();
            this.ComboBox_Classroom1_Time = new System.Windows.Forms.ComboBox();
            this.Label_Prefix_ComboBox_Classroom1_Time = new System.Windows.Forms.Label();
            this.DateTimePicker_Classroom1_StartDate = new System.Windows.Forms.DateTimePicker();
            this.Label_Prefix_DateTimePicker_Classroom1_StartDate = new System.Windows.Forms.Label();
            this.GroupBox_Classroom2 = new System.Windows.Forms.GroupBox();
            this.Label_RequireField_TextBox_Classroom2_Duration = new System.Windows.Forms.Label();
            this.TextBox_Classroom2_Duration = new System.Windows.Forms.TextBox();
            this.Label_Prefix_TextBox_Classroom2_Duration = new System.Windows.Forms.Label();
            this.Label_Postfix_TextBox_Classroom2_Duration = new System.Windows.Forms.Label();
            this.Label_Prefix_ComboBox_Classroom2_Teacher = new System.Windows.Forms.Label();
            this.ComboBox_Classroom2_Teacher = new System.Windows.Forms.ComboBox();
            this.ComboBox_Classroom2_Time = new System.Windows.Forms.ComboBox();
            this.Label_Prefix_ComboBox_Classroom2_Time = new System.Windows.Forms.Label();
            this.DateTimePicker_Classroom2_StartDate = new System.Windows.Forms.DateTimePicker();
            this.Label_Prefix_DateTimePicker_Classroom2_StartDate = new System.Windows.Forms.Label();
            this.Button_Search_Course = new System.Windows.Forms.Button();
            this.GroupBox_CourseDetail = new System.Windows.Forms.GroupBox();
            this.TextBox_CourseLevel = new System.Windows.Forms.TextBox();
            this.TextBox_CourseName = new System.Windows.Forms.TextBox();
            this.TextBox_CourseCategoryName = new System.Windows.Forms.TextBox();
            this.TextBox_CourseFee = new System.Windows.Forms.TextBox();
            this.Label_Prefix_TextBox_CourseFee = new System.Windows.Forms.Label();
            this.Label_Prefix_TextBox_CourseLevel = new System.Windows.Forms.Label();
            this.Label_Prefix_TextBox_CourseCategoryName = new System.Windows.Forms.Label();
            this.Label_Prefix_TextBox_CourseName = new System.Windows.Forms.Label();
            this.GroupBox_Enrollment.SuspendLayout();
            this.GroupBox_Classroom_Frequency.SuspendLayout();
            this.GroupBox_Classroom1.SuspendLayout();
            this.GroupBox_Classroom2.SuspendLayout();
            this.GroupBox_CourseDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox_Enrollment
            // 
            this.GroupBox_Enrollment.Controls.Add(this.Button_Reset);
            this.GroupBox_Enrollment.Controls.Add(this.Button_Cancel);
            this.GroupBox_Enrollment.Controls.Add(this.Button_Submit);
            this.GroupBox_Enrollment.Controls.Add(this.Label_Prefix_ComboBox_NumberOfClassroomDetail);
            this.GroupBox_Enrollment.Controls.Add(this.ComboBox_NumberOfClassroomDetail);
            this.GroupBox_Enrollment.Controls.Add(this.Label_Postfix_ComboBox_NumberOfClassroomDetail);
            this.GroupBox_Enrollment.Controls.Add(this.GroupBox_Classroom_Frequency);
            this.GroupBox_Enrollment.Controls.Add(this.GroupBox_Classroom1);
            this.GroupBox_Enrollment.Controls.Add(this.GroupBox_Classroom2);
            this.GroupBox_Enrollment.Controls.Add(this.Button_Search_Course);
            this.GroupBox_Enrollment.Controls.Add(this.GroupBox_CourseDetail);
            this.GroupBox_Enrollment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_Enrollment.Location = new System.Drawing.Point(0, 0);
            this.GroupBox_Enrollment.Name = "GroupBox_Enrollment";
            this.GroupBox_Enrollment.Size = new System.Drawing.Size(754, 238);
            this.GroupBox_Enrollment.TabIndex = 3;
            this.GroupBox_Enrollment.TabStop = false;
            this.GroupBox_Enrollment.Text = " วิชาเรียน";
            // 
            // Button_Reset
            // 
            this.Button_Reset.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Reset.Location = new System.Drawing.Point(6, 209);
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Size = new System.Drawing.Size(75, 23);
            this.Button_Reset.TabIndex = 40;
            this.Button_Reset.Text = "รีเซ็ต";
            this.Button_Reset.UseVisualStyleBackColor = true;
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Cancel.Location = new System.Drawing.Point(673, 209);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 39;
            this.Button_Cancel.Text = "ยกเลิก";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Button_Submit
            // 
            this.Button_Submit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Submit.Location = new System.Drawing.Point(592, 209);
            this.Button_Submit.Name = "Button_Submit";
            this.Button_Submit.Size = new System.Drawing.Size(75, 23);
            this.Button_Submit.TabIndex = 38;
            this.Button_Submit.Text = "ตกลง";
            this.Button_Submit.UseVisualStyleBackColor = true;
            this.Button_Submit.Click += new System.EventHandler(this.Button_Submit_Click);
            // 
            // Label_Prefix_ComboBox_NumberOfClassroomDetail
            // 
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail.AutoSize = true;
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail.Location = new System.Drawing.Point(6, 98);
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail.Name = "Label_Prefix_ComboBox_NumberOfClassroomDetail";
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail.Size = new System.Drawing.Size(43, 16);
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail.TabIndex = 37;
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail.Text = "จำนวน";
            // 
            // ComboBox_NumberOfClassroomDetail
            // 
            this.ComboBox_NumberOfClassroomDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_NumberOfClassroomDetail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ComboBox_NumberOfClassroomDetail.FormattingEnabled = true;
            this.ComboBox_NumberOfClassroomDetail.Items.AddRange(new object[] {
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
            this.ComboBox_NumberOfClassroomDetail.Location = new System.Drawing.Point(55, 95);
            this.ComboBox_NumberOfClassroomDetail.Name = "ComboBox_NumberOfClassroomDetail";
            this.ComboBox_NumberOfClassroomDetail.Size = new System.Drawing.Size(41, 24);
            this.ComboBox_NumberOfClassroomDetail.TabIndex = 36;
            // 
            // Label_Postfix_ComboBox_NumberOfClassroomDetail
            // 
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail.AutoSize = true;
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail.Location = new System.Drawing.Point(102, 98);
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail.Name = "Label_Postfix_ComboBox_NumberOfClassroomDetail";
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail.Size = new System.Drawing.Size(28, 16);
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail.TabIndex = 35;
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail.Text = "ครั้ง";
            // 
            // GroupBox_Classroom_Frequency
            // 
            this.GroupBox_Classroom_Frequency.Controls.Add(this.RadioButton_OneClassPerWeek);
            this.GroupBox_Classroom_Frequency.Controls.Add(this.RadioButton_TwoClassPerDay);
            this.GroupBox_Classroom_Frequency.Controls.Add(this.RadioButton_TwoClassPerWeek);
            this.GroupBox_Classroom_Frequency.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_Classroom_Frequency.Location = new System.Drawing.Point(6, 114);
            this.GroupBox_Classroom_Frequency.Name = "GroupBox_Classroom_Frequency";
            this.GroupBox_Classroom_Frequency.Size = new System.Drawing.Size(124, 89);
            this.GroupBox_Classroom_Frequency.TabIndex = 34;
            this.GroupBox_Classroom_Frequency.TabStop = false;
            // 
            // RadioButton_OneClassPerWeek
            // 
            this.RadioButton_OneClassPerWeek.AutoSize = true;
            this.RadioButton_OneClassPerWeek.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_OneClassPerWeek.Location = new System.Drawing.Point(6, 11);
            this.RadioButton_OneClassPerWeek.Name = "RadioButton_OneClassPerWeek";
            this.RadioButton_OneClassPerWeek.Size = new System.Drawing.Size(108, 20);
            this.RadioButton_OneClassPerWeek.TabIndex = 1;
            this.RadioButton_OneClassPerWeek.Text = "1 ครั้ง / สัปดาห์";
            this.RadioButton_OneClassPerWeek.UseVisualStyleBackColor = true;
            this.RadioButton_OneClassPerWeek.CheckedChanged += new System.EventHandler(this.RadioButton_OneClassPerWeek_CheckedChanged);
            // 
            // RadioButton_TwoClassPerDay
            // 
            this.RadioButton_TwoClassPerDay.AutoSize = true;
            this.RadioButton_TwoClassPerDay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_TwoClassPerDay.Location = new System.Drawing.Point(6, 63);
            this.RadioButton_TwoClassPerDay.Name = "RadioButton_TwoClassPerDay";
            this.RadioButton_TwoClassPerDay.Size = new System.Drawing.Size(84, 20);
            this.RadioButton_TwoClassPerDay.TabIndex = 3;
            this.RadioButton_TwoClassPerDay.Text = "2 ครั้ง / วัน";
            this.RadioButton_TwoClassPerDay.UseVisualStyleBackColor = true;
            this.RadioButton_TwoClassPerDay.CheckedChanged += new System.EventHandler(this.RadioButton_TwoClassPerDay_CheckedChanged);
            // 
            // RadioButton_TwoClassPerWeek
            // 
            this.RadioButton_TwoClassPerWeek.AutoSize = true;
            this.RadioButton_TwoClassPerWeek.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.RadioButton_TwoClassPerWeek.Location = new System.Drawing.Point(6, 37);
            this.RadioButton_TwoClassPerWeek.Name = "RadioButton_TwoClassPerWeek";
            this.RadioButton_TwoClassPerWeek.Size = new System.Drawing.Size(108, 20);
            this.RadioButton_TwoClassPerWeek.TabIndex = 2;
            this.RadioButton_TwoClassPerWeek.Text = "2 ครั้ง / สัปดาห์";
            this.RadioButton_TwoClassPerWeek.UseVisualStyleBackColor = true;
            this.RadioButton_TwoClassPerWeek.CheckedChanged += new System.EventHandler(this.RadioButton_TwoClassPerWeek_CheckedChanged);
            // 
            // GroupBox_Classroom1
            // 
            this.GroupBox_Classroom1.Controls.Add(this.Label_RequireField_TextBox_Classroom1_Duration);
            this.GroupBox_Classroom1.Controls.Add(this.TextBox_Classroom1_Duration);
            this.GroupBox_Classroom1.Controls.Add(this.Label_Prefix_TextBox_Classroom1_Duration);
            this.GroupBox_Classroom1.Controls.Add(this.Label_Postfix_TextBox_Classroom1_Duration);
            this.GroupBox_Classroom1.Controls.Add(this.Label_Prefix_ComboBox_Classroom1_Teacher);
            this.GroupBox_Classroom1.Controls.Add(this.ComboBox_Classroom1_Teacher);
            this.GroupBox_Classroom1.Controls.Add(this.ComboBox_Classroom1_Time);
            this.GroupBox_Classroom1.Controls.Add(this.Label_Prefix_ComboBox_Classroom1_Time);
            this.GroupBox_Classroom1.Controls.Add(this.DateTimePicker_Classroom1_StartDate);
            this.GroupBox_Classroom1.Controls.Add(this.Label_Prefix_DateTimePicker_Classroom1_StartDate);
            this.GroupBox_Classroom1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_Classroom1.Location = new System.Drawing.Point(136, 92);
            this.GroupBox_Classroom1.Name = "GroupBox_Classroom1";
            this.GroupBox_Classroom1.Size = new System.Drawing.Size(303, 111);
            this.GroupBox_Classroom1.TabIndex = 33;
            this.GroupBox_Classroom1.TabStop = false;
            this.GroupBox_Classroom1.Text = "เวลาเรียนครั้งที่ 1";
            // 
            // Label_RequireField_TextBox_Classroom1_Duration
            // 
            this.Label_RequireField_TextBox_Classroom1_Duration.AutoSize = true;
            this.Label_RequireField_TextBox_Classroom1_Duration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_RequireField_TextBox_Classroom1_Duration.ForeColor = System.Drawing.Color.Red;
            this.Label_RequireField_TextBox_Classroom1_Duration.Location = new System.Drawing.Point(284, 55);
            this.Label_RequireField_TextBox_Classroom1_Duration.Name = "Label_RequireField_TextBox_Classroom1_Duration";
            this.Label_RequireField_TextBox_Classroom1_Duration.Size = new System.Drawing.Size(13, 16);
            this.Label_RequireField_TextBox_Classroom1_Duration.TabIndex = 41;
            this.Label_RequireField_TextBox_Classroom1_Duration.Text = "*";
            // 
            // TextBox_Classroom1_Duration
            // 
            this.TextBox_Classroom1_Duration.Location = new System.Drawing.Point(197, 52);
            this.TextBox_Classroom1_Duration.Name = "TextBox_Classroom1_Duration";
            this.TextBox_Classroom1_Duration.Size = new System.Drawing.Size(50, 23);
            this.TextBox_Classroom1_Duration.TabIndex = 6;
            this.TextBox_Classroom1_Duration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox_Classroom1_Duration.TextChanged += new System.EventHandler(this.TextBox_Classroom1_Duration_TextChanged);
            this.TextBox_Classroom1_Duration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_Classroom1_Duration_KeyDown);
            // 
            // Label_Prefix_TextBox_Classroom1_Duration
            // 
            this.Label_Prefix_TextBox_Classroom1_Duration.AutoSize = true;
            this.Label_Prefix_TextBox_Classroom1_Duration.Location = new System.Drawing.Point(148, 55);
            this.Label_Prefix_TextBox_Classroom1_Duration.Name = "Label_Prefix_TextBox_Classroom1_Duration";
            this.Label_Prefix_TextBox_Classroom1_Duration.Size = new System.Drawing.Size(43, 16);
            this.Label_Prefix_TextBox_Classroom1_Duration.TabIndex = 9;
            this.Label_Prefix_TextBox_Classroom1_Duration.Text = "จำนวน";
            // 
            // Label_Postfix_TextBox_Classroom1_Duration
            // 
            this.Label_Postfix_TextBox_Classroom1_Duration.AutoSize = true;
            this.Label_Postfix_TextBox_Classroom1_Duration.Location = new System.Drawing.Point(253, 55);
            this.Label_Postfix_TextBox_Classroom1_Duration.Name = "Label_Postfix_TextBox_Classroom1_Duration";
            this.Label_Postfix_TextBox_Classroom1_Duration.Size = new System.Drawing.Size(31, 16);
            this.Label_Postfix_TextBox_Classroom1_Duration.TabIndex = 8;
            this.Label_Postfix_TextBox_Classroom1_Duration.Text = "นาที";
            // 
            // Label_Prefix_ComboBox_Classroom1_Teacher
            // 
            this.Label_Prefix_ComboBox_Classroom1_Teacher.AutoSize = true;
            this.Label_Prefix_ComboBox_Classroom1_Teacher.Location = new System.Drawing.Point(27, 84);
            this.Label_Prefix_ComboBox_Classroom1_Teacher.Name = "Label_Prefix_ComboBox_Classroom1_Teacher";
            this.Label_Prefix_ComboBox_Classroom1_Teacher.Size = new System.Drawing.Size(54, 16);
            this.Label_Prefix_ComboBox_Classroom1_Teacher.TabIndex = 5;
            this.Label_Prefix_ComboBox_Classroom1_Teacher.Text = "สอนโดย";
            // 
            // ComboBox_Classroom1_Teacher
            // 
            this.ComboBox_Classroom1_Teacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Classroom1_Teacher.FormattingEnabled = true;
            this.ComboBox_Classroom1_Teacher.Location = new System.Drawing.Point(87, 81);
            this.ComboBox_Classroom1_Teacher.Name = "ComboBox_Classroom1_Teacher";
            this.ComboBox_Classroom1_Teacher.Size = new System.Drawing.Size(210, 24);
            this.ComboBox_Classroom1_Teacher.TabIndex = 7;
            this.ComboBox_Classroom1_Teacher.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Classroom1_Teacher_SelectedIndexChanged);
            // 
            // ComboBox_Classroom1_Time
            // 
            this.ComboBox_Classroom1_Time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Classroom1_Time.FormattingEnabled = true;
            this.ComboBox_Classroom1_Time.Location = new System.Drawing.Point(87, 51);
            this.ComboBox_Classroom1_Time.Name = "ComboBox_Classroom1_Time";
            this.ComboBox_Classroom1_Time.Size = new System.Drawing.Size(55, 24);
            this.ComboBox_Classroom1_Time.TabIndex = 5;
            // 
            // Label_Prefix_ComboBox_Classroom1_Time
            // 
            this.Label_Prefix_ComboBox_Classroom1_Time.AutoSize = true;
            this.Label_Prefix_ComboBox_Classroom1_Time.Location = new System.Drawing.Point(49, 55);
            this.Label_Prefix_ComboBox_Classroom1_Time.Name = "Label_Prefix_ComboBox_Classroom1_Time";
            this.Label_Prefix_ComboBox_Classroom1_Time.Size = new System.Drawing.Size(32, 16);
            this.Label_Prefix_ComboBox_Classroom1_Time.TabIndex = 2;
            this.Label_Prefix_ComboBox_Classroom1_Time.Text = "เวลา";
            // 
            // DateTimePicker_Classroom1_StartDate
            // 
            this.DateTimePicker_Classroom1_StartDate.Location = new System.Drawing.Point(87, 22);
            this.DateTimePicker_Classroom1_StartDate.Name = "DateTimePicker_Classroom1_StartDate";
            this.DateTimePicker_Classroom1_StartDate.Size = new System.Drawing.Size(210, 23);
            this.DateTimePicker_Classroom1_StartDate.TabIndex = 4;
            this.DateTimePicker_Classroom1_StartDate.ValueChanged += new System.EventHandler(this.DateTimePicker_Classroom1_StartDate_ValueChanged);
            // 
            // Label_Prefix_DateTimePicker_Classroom1_StartDate
            // 
            this.Label_Prefix_DateTimePicker_Classroom1_StartDate.AutoSize = true;
            this.Label_Prefix_DateTimePicker_Classroom1_StartDate.Location = new System.Drawing.Point(6, 26);
            this.Label_Prefix_DateTimePicker_Classroom1_StartDate.Name = "Label_Prefix_DateTimePicker_Classroom1_StartDate";
            this.Label_Prefix_DateTimePicker_Classroom1_StartDate.Size = new System.Drawing.Size(75, 16);
            this.Label_Prefix_DateTimePicker_Classroom1_StartDate.TabIndex = 0;
            this.Label_Prefix_DateTimePicker_Classroom1_StartDate.Text = "วันที่เริ่มเรียน";
            // 
            // GroupBox_Classroom2
            // 
            this.GroupBox_Classroom2.Controls.Add(this.Label_RequireField_TextBox_Classroom2_Duration);
            this.GroupBox_Classroom2.Controls.Add(this.TextBox_Classroom2_Duration);
            this.GroupBox_Classroom2.Controls.Add(this.Label_Prefix_TextBox_Classroom2_Duration);
            this.GroupBox_Classroom2.Controls.Add(this.Label_Postfix_TextBox_Classroom2_Duration);
            this.GroupBox_Classroom2.Controls.Add(this.Label_Prefix_ComboBox_Classroom2_Teacher);
            this.GroupBox_Classroom2.Controls.Add(this.ComboBox_Classroom2_Teacher);
            this.GroupBox_Classroom2.Controls.Add(this.ComboBox_Classroom2_Time);
            this.GroupBox_Classroom2.Controls.Add(this.Label_Prefix_ComboBox_Classroom2_Time);
            this.GroupBox_Classroom2.Controls.Add(this.DateTimePicker_Classroom2_StartDate);
            this.GroupBox_Classroom2.Controls.Add(this.Label_Prefix_DateTimePicker_Classroom2_StartDate);
            this.GroupBox_Classroom2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_Classroom2.Location = new System.Drawing.Point(445, 92);
            this.GroupBox_Classroom2.Name = "GroupBox_Classroom2";
            this.GroupBox_Classroom2.Size = new System.Drawing.Size(303, 111);
            this.GroupBox_Classroom2.TabIndex = 32;
            this.GroupBox_Classroom2.TabStop = false;
            this.GroupBox_Classroom2.Text = "เวลาเรียนครั้งที่ 2";
            // 
            // Label_RequireField_TextBox_Classroom2_Duration
            // 
            this.Label_RequireField_TextBox_Classroom2_Duration.AutoSize = true;
            this.Label_RequireField_TextBox_Classroom2_Duration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_RequireField_TextBox_Classroom2_Duration.ForeColor = System.Drawing.Color.Red;
            this.Label_RequireField_TextBox_Classroom2_Duration.Location = new System.Drawing.Point(284, 54);
            this.Label_RequireField_TextBox_Classroom2_Duration.Name = "Label_RequireField_TextBox_Classroom2_Duration";
            this.Label_RequireField_TextBox_Classroom2_Duration.Size = new System.Drawing.Size(13, 16);
            this.Label_RequireField_TextBox_Classroom2_Duration.TabIndex = 41;
            this.Label_RequireField_TextBox_Classroom2_Duration.Text = "*";
            // 
            // TextBox_Classroom2_Duration
            // 
            this.TextBox_Classroom2_Duration.Location = new System.Drawing.Point(197, 51);
            this.TextBox_Classroom2_Duration.Name = "TextBox_Classroom2_Duration";
            this.TextBox_Classroom2_Duration.Size = new System.Drawing.Size(50, 23);
            this.TextBox_Classroom2_Duration.TabIndex = 10;
            this.TextBox_Classroom2_Duration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox_Classroom2_Duration.TextChanged += new System.EventHandler(this.TextBox_Classroom2_Duration_TextChanged);
            this.TextBox_Classroom2_Duration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_Classroom2_Duration_KeyDown);
            // 
            // Label_Prefix_TextBox_Classroom2_Duration
            // 
            this.Label_Prefix_TextBox_Classroom2_Duration.AutoSize = true;
            this.Label_Prefix_TextBox_Classroom2_Duration.Location = new System.Drawing.Point(148, 55);
            this.Label_Prefix_TextBox_Classroom2_Duration.Name = "Label_Prefix_TextBox_Classroom2_Duration";
            this.Label_Prefix_TextBox_Classroom2_Duration.Size = new System.Drawing.Size(43, 16);
            this.Label_Prefix_TextBox_Classroom2_Duration.TabIndex = 10;
            this.Label_Prefix_TextBox_Classroom2_Duration.Text = "จำนวน";
            // 
            // Label_Postfix_TextBox_Classroom2_Duration
            // 
            this.Label_Postfix_TextBox_Classroom2_Duration.AutoSize = true;
            this.Label_Postfix_TextBox_Classroom2_Duration.Location = new System.Drawing.Point(253, 54);
            this.Label_Postfix_TextBox_Classroom2_Duration.Name = "Label_Postfix_TextBox_Classroom2_Duration";
            this.Label_Postfix_TextBox_Classroom2_Duration.Size = new System.Drawing.Size(31, 16);
            this.Label_Postfix_TextBox_Classroom2_Duration.TabIndex = 9;
            this.Label_Postfix_TextBox_Classroom2_Duration.Text = "นาที";
            // 
            // Label_Prefix_ComboBox_Classroom2_Teacher
            // 
            this.Label_Prefix_ComboBox_Classroom2_Teacher.AutoSize = true;
            this.Label_Prefix_ComboBox_Classroom2_Teacher.Location = new System.Drawing.Point(27, 84);
            this.Label_Prefix_ComboBox_Classroom2_Teacher.Name = "Label_Prefix_ComboBox_Classroom2_Teacher";
            this.Label_Prefix_ComboBox_Classroom2_Teacher.Size = new System.Drawing.Size(54, 16);
            this.Label_Prefix_ComboBox_Classroom2_Teacher.TabIndex = 5;
            this.Label_Prefix_ComboBox_Classroom2_Teacher.Text = "สอนโดย";
            // 
            // ComboBox_Classroom2_Teacher
            // 
            this.ComboBox_Classroom2_Teacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Classroom2_Teacher.FormattingEnabled = true;
            this.ComboBox_Classroom2_Teacher.Location = new System.Drawing.Point(87, 81);
            this.ComboBox_Classroom2_Teacher.Name = "ComboBox_Classroom2_Teacher";
            this.ComboBox_Classroom2_Teacher.Size = new System.Drawing.Size(210, 24);
            this.ComboBox_Classroom2_Teacher.TabIndex = 11;
            this.ComboBox_Classroom2_Teacher.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Classroom2_Teacher_SelectedIndexChanged);
            // 
            // ComboBox_Classroom2_Time
            // 
            this.ComboBox_Classroom2_Time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Classroom2_Time.FormattingEnabled = true;
            this.ComboBox_Classroom2_Time.Location = new System.Drawing.Point(87, 51);
            this.ComboBox_Classroom2_Time.Name = "ComboBox_Classroom2_Time";
            this.ComboBox_Classroom2_Time.Size = new System.Drawing.Size(55, 24);
            this.ComboBox_Classroom2_Time.TabIndex = 9;
            // 
            // Label_Prefix_ComboBox_Classroom2_Time
            // 
            this.Label_Prefix_ComboBox_Classroom2_Time.AutoSize = true;
            this.Label_Prefix_ComboBox_Classroom2_Time.Location = new System.Drawing.Point(49, 54);
            this.Label_Prefix_ComboBox_Classroom2_Time.Name = "Label_Prefix_ComboBox_Classroom2_Time";
            this.Label_Prefix_ComboBox_Classroom2_Time.Size = new System.Drawing.Size(32, 16);
            this.Label_Prefix_ComboBox_Classroom2_Time.TabIndex = 2;
            this.Label_Prefix_ComboBox_Classroom2_Time.Text = "เวลา";
            // 
            // DateTimePicker_Classroom2_StartDate
            // 
            this.DateTimePicker_Classroom2_StartDate.Location = new System.Drawing.Point(87, 22);
            this.DateTimePicker_Classroom2_StartDate.Name = "DateTimePicker_Classroom2_StartDate";
            this.DateTimePicker_Classroom2_StartDate.Size = new System.Drawing.Size(210, 23);
            this.DateTimePicker_Classroom2_StartDate.TabIndex = 8;
            this.DateTimePicker_Classroom2_StartDate.ValueChanged += new System.EventHandler(this.DateTimePicker_Classroom2_StartDate_ValueChanged);
            // 
            // Label_Prefix_DateTimePicker_Classroom2_StartDate
            // 
            this.Label_Prefix_DateTimePicker_Classroom2_StartDate.AutoSize = true;
            this.Label_Prefix_DateTimePicker_Classroom2_StartDate.Location = new System.Drawing.Point(6, 26);
            this.Label_Prefix_DateTimePicker_Classroom2_StartDate.Name = "Label_Prefix_DateTimePicker_Classroom2_StartDate";
            this.Label_Prefix_DateTimePicker_Classroom2_StartDate.Size = new System.Drawing.Size(75, 16);
            this.Label_Prefix_DateTimePicker_Classroom2_StartDate.TabIndex = 0;
            this.Label_Prefix_DateTimePicker_Classroom2_StartDate.Text = "วันที่เริ่มเรียน";
            // 
            // Button_Search_Course
            // 
            this.Button_Search_Course.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Search_Course.Location = new System.Drawing.Point(6, 22);
            this.Button_Search_Course.Name = "Button_Search_Course";
            this.Button_Search_Course.Size = new System.Drawing.Size(87, 23);
            this.Button_Search_Course.TabIndex = 16;
            this.Button_Search_Course.Text = "ค้นหาวิชาเรียน";
            this.Button_Search_Course.UseVisualStyleBackColor = true;
            this.Button_Search_Course.Click += new System.EventHandler(this.Button_Search_Course_Click);
            // 
            // GroupBox_CourseDetail
            // 
            this.GroupBox_CourseDetail.Controls.Add(this.TextBox_CourseLevel);
            this.GroupBox_CourseDetail.Controls.Add(this.TextBox_CourseName);
            this.GroupBox_CourseDetail.Controls.Add(this.TextBox_CourseCategoryName);
            this.GroupBox_CourseDetail.Controls.Add(this.TextBox_CourseFee);
            this.GroupBox_CourseDetail.Controls.Add(this.Label_Prefix_TextBox_CourseFee);
            this.GroupBox_CourseDetail.Controls.Add(this.Label_Prefix_TextBox_CourseLevel);
            this.GroupBox_CourseDetail.Controls.Add(this.Label_Prefix_TextBox_CourseCategoryName);
            this.GroupBox_CourseDetail.Controls.Add(this.Label_Prefix_TextBox_CourseName);
            this.GroupBox_CourseDetail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox_CourseDetail.Location = new System.Drawing.Point(6, 42);
            this.GroupBox_CourseDetail.Name = "GroupBox_CourseDetail";
            this.GroupBox_CourseDetail.Size = new System.Drawing.Size(742, 44);
            this.GroupBox_CourseDetail.TabIndex = 31;
            this.GroupBox_CourseDetail.TabStop = false;
            // 
            // TextBox_CourseLevel
            // 
            this.TextBox_CourseLevel.Enabled = false;
            this.TextBox_CourseLevel.Location = new System.Drawing.Point(464, 15);
            this.TextBox_CourseLevel.Name = "TextBox_CourseLevel";
            this.TextBox_CourseLevel.ReadOnly = true;
            this.TextBox_CourseLevel.Size = new System.Drawing.Size(155, 23);
            this.TextBox_CourseLevel.TabIndex = 19;
            this.TextBox_CourseLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBox_CourseName
            // 
            this.TextBox_CourseName.Enabled = false;
            this.TextBox_CourseName.Location = new System.Drawing.Point(261, 15);
            this.TextBox_CourseName.Name = "TextBox_CourseName";
            this.TextBox_CourseName.ReadOnly = true;
            this.TextBox_CourseName.Size = new System.Drawing.Size(155, 23);
            this.TextBox_CourseName.TabIndex = 18;
            this.TextBox_CourseName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBox_CourseCategoryName
            // 
            this.TextBox_CourseCategoryName.Enabled = false;
            this.TextBox_CourseCategoryName.Location = new System.Drawing.Point(66, 15);
            this.TextBox_CourseCategoryName.Name = "TextBox_CourseCategoryName";
            this.TextBox_CourseCategoryName.ReadOnly = true;
            this.TextBox_CourseCategoryName.Size = new System.Drawing.Size(155, 23);
            this.TextBox_CourseCategoryName.TabIndex = 17;
            this.TextBox_CourseCategoryName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBox_CourseFee
            // 
            this.TextBox_CourseFee.Enabled = false;
            this.TextBox_CourseFee.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.TextBox_CourseFee.Location = new System.Drawing.Point(665, 15);
            this.TextBox_CourseFee.Name = "TextBox_CourseFee";
            this.TextBox_CourseFee.ReadOnly = true;
            this.TextBox_CourseFee.Size = new System.Drawing.Size(71, 23);
            this.TextBox_CourseFee.TabIndex = 12;
            this.TextBox_CourseFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label_Prefix_TextBox_CourseFee
            // 
            this.Label_Prefix_TextBox_CourseFee.AutoSize = true;
            this.Label_Prefix_TextBox_CourseFee.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_Prefix_TextBox_CourseFee.Location = new System.Drawing.Point(625, 18);
            this.Label_Prefix_TextBox_CourseFee.Name = "Label_Prefix_TextBox_CourseFee";
            this.Label_Prefix_TextBox_CourseFee.Size = new System.Drawing.Size(34, 16);
            this.Label_Prefix_TextBox_CourseFee.TabIndex = 13;
            this.Label_Prefix_TextBox_CourseFee.Text = "ราคา";
            // 
            // Label_Prefix_TextBox_CourseLevel
            // 
            this.Label_Prefix_TextBox_CourseLevel.AutoSize = true;
            this.Label_Prefix_TextBox_CourseLevel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_Prefix_TextBox_CourseLevel.Location = new System.Drawing.Point(422, 18);
            this.Label_Prefix_TextBox_CourseLevel.Name = "Label_Prefix_TextBox_CourseLevel";
            this.Label_Prefix_TextBox_CourseLevel.Size = new System.Drawing.Size(36, 16);
            this.Label_Prefix_TextBox_CourseLevel.TabIndex = 7;
            this.Label_Prefix_TextBox_CourseLevel.Text = "ระดับ";
            // 
            // Label_Prefix_TextBox_CourseCategoryName
            // 
            this.Label_Prefix_TextBox_CourseCategoryName.AutoSize = true;
            this.Label_Prefix_TextBox_CourseCategoryName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_Prefix_TextBox_CourseCategoryName.Location = new System.Drawing.Point(6, 18);
            this.Label_Prefix_TextBox_CourseCategoryName.Name = "Label_Prefix_TextBox_CourseCategoryName";
            this.Label_Prefix_TextBox_CourseCategoryName.Size = new System.Drawing.Size(54, 16);
            this.Label_Prefix_TextBox_CourseCategoryName.TabIndex = 3;
            this.Label_Prefix_TextBox_CourseCategoryName.Text = "หลักสูตร";
            // 
            // Label_Prefix_TextBox_CourseName
            // 
            this.Label_Prefix_TextBox_CourseName.AutoSize = true;
            this.Label_Prefix_TextBox_CourseName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label_Prefix_TextBox_CourseName.Location = new System.Drawing.Point(227, 18);
            this.Label_Prefix_TextBox_CourseName.Name = "Label_Prefix_TextBox_CourseName";
            this.Label_Prefix_TextBox_CourseName.Size = new System.Drawing.Size(28, 16);
            this.Label_Prefix_TextBox_CourseName.TabIndex = 5;
            this.Label_Prefix_TextBox_CourseName.Text = "วิชา";
            // 
            // EnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 238);
            this.Controls.Add(this.GroupBox_Enrollment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnrollmentForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enrollment";
            this.GroupBox_Enrollment.ResumeLayout(false);
            this.GroupBox_Enrollment.PerformLayout();
            this.GroupBox_Classroom_Frequency.ResumeLayout(false);
            this.GroupBox_Classroom_Frequency.PerformLayout();
            this.GroupBox_Classroom1.ResumeLayout(false);
            this.GroupBox_Classroom1.PerformLayout();
            this.GroupBox_Classroom2.ResumeLayout(false);
            this.GroupBox_Classroom2.PerformLayout();
            this.GroupBox_CourseDetail.ResumeLayout(false);
            this.GroupBox_CourseDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox_Enrollment;
        private System.Windows.Forms.Button Button_Submit;
        private System.Windows.Forms.Label Label_Prefix_ComboBox_NumberOfClassroomDetail;
        private System.Windows.Forms.ComboBox ComboBox_NumberOfClassroomDetail;
        private System.Windows.Forms.Label Label_Postfix_ComboBox_NumberOfClassroomDetail;
        private System.Windows.Forms.GroupBox GroupBox_Classroom_Frequency;
        private System.Windows.Forms.RadioButton RadioButton_OneClassPerWeek;
        private System.Windows.Forms.RadioButton RadioButton_TwoClassPerDay;
        private System.Windows.Forms.RadioButton RadioButton_TwoClassPerWeek;
        private System.Windows.Forms.GroupBox GroupBox_Classroom1;
        private System.Windows.Forms.Label Label_RequireField_TextBox_Classroom1_Duration;
        private System.Windows.Forms.TextBox TextBox_Classroom1_Duration;
        private System.Windows.Forms.Label Label_Prefix_TextBox_Classroom1_Duration;
        private System.Windows.Forms.Label Label_Postfix_TextBox_Classroom1_Duration;
        private System.Windows.Forms.Label Label_Prefix_ComboBox_Classroom1_Teacher;
        private System.Windows.Forms.ComboBox ComboBox_Classroom1_Teacher;
        private System.Windows.Forms.ComboBox ComboBox_Classroom1_Time;
        private System.Windows.Forms.Label Label_Prefix_ComboBox_Classroom1_Time;
        private System.Windows.Forms.DateTimePicker DateTimePicker_Classroom1_StartDate;
        private System.Windows.Forms.Label Label_Prefix_DateTimePicker_Classroom1_StartDate;
        private System.Windows.Forms.GroupBox GroupBox_Classroom2;
        private System.Windows.Forms.Label Label_RequireField_TextBox_Classroom2_Duration;
        private System.Windows.Forms.TextBox TextBox_Classroom2_Duration;
        private System.Windows.Forms.Label Label_Prefix_TextBox_Classroom2_Duration;
        private System.Windows.Forms.Label Label_Postfix_TextBox_Classroom2_Duration;
        private System.Windows.Forms.Label Label_Prefix_ComboBox_Classroom2_Teacher;
        private System.Windows.Forms.ComboBox ComboBox_Classroom2_Teacher;
        private System.Windows.Forms.ComboBox ComboBox_Classroom2_Time;
        private System.Windows.Forms.Label Label_Prefix_ComboBox_Classroom2_Time;
        private System.Windows.Forms.DateTimePicker DateTimePicker_Classroom2_StartDate;
        private System.Windows.Forms.Label Label_Prefix_DateTimePicker_Classroom2_StartDate;
        private System.Windows.Forms.Button Button_Search_Course;
        private System.Windows.Forms.GroupBox GroupBox_CourseDetail;
        private System.Windows.Forms.TextBox TextBox_CourseLevel;
        private System.Windows.Forms.TextBox TextBox_CourseName;
        private System.Windows.Forms.TextBox TextBox_CourseCategoryName;
        private System.Windows.Forms.TextBox TextBox_CourseFee;
        private System.Windows.Forms.Label Label_Prefix_TextBox_CourseFee;
        private System.Windows.Forms.Label Label_Prefix_TextBox_CourseLevel;
        private System.Windows.Forms.Label Label_Prefix_TextBox_CourseCategoryName;
        private System.Windows.Forms.Label Label_Prefix_TextBox_CourseName;
        private System.Windows.Forms.Button Button_Reset;
        private System.Windows.Forms.Button Button_Cancel;

    }
}