namespace PianoForte.View
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Panel_Body = new System.Windows.Forms.Panel();
            this.Panel_Menu = new System.Windows.Forms.Panel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton_Home = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_RegisterStudent = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Student = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Teacher = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Course = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Book = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_CD = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Payment = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_DailyPaymentReport = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_AddUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_CheckIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripButton_Logout = new System.Windows.Forms.ToolStripButton();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.classroomDetailtimer = new System.Windows.Forms.Timer(this.components);
            this.Panel_Menu.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Body
            // 
            this.Panel_Body.Location = new System.Drawing.Point(2, 65);
            this.Panel_Body.Name = "Panel_Body";
            this.Panel_Body.Size = new System.Drawing.Size(1016, 600);
            this.Panel_Body.TabIndex = 5;
            // 
            // Panel_Menu
            // 
            this.Panel_Menu.Controls.Add(this.ToolStrip);
            this.Panel_Menu.Location = new System.Drawing.Point(2, 2);
            this.Panel_Menu.Name = "Panel_Menu";
            this.Panel_Menu.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.Panel_Menu.Size = new System.Drawing.Size(1126, 65);
            this.Panel_Menu.TabIndex = 7;
            // 
            // ToolStrip
            // 
            this.ToolStrip.CanOverflow = false;
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_Home,
            this.ToolStripButton_RegisterStudent,
            this.ToolStripButton_Student,
            this.ToolStripButton_Teacher,
            this.ToolStripButton_Course,
            this.ToolStripButton_Book,
            this.ToolStripButton_CD,
            this.ToolStripButton_Payment,
            this.ToolStripButton_DailyPaymentReport,
            this.ToolStripButton_AddUser,
            this.toolStripButton_CheckIn,
            this.toolStripLabel1,
            this.ToolStripButton_Logout});
            this.ToolStrip.Location = new System.Drawing.Point(1, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Size = new System.Drawing.Size(1125, 63);
            this.ToolStrip.TabIndex = 4;
            // 
            // ToolStripButton_Home
            // 
            this.ToolStripButton_Home.AutoSize = false;
            this.ToolStripButton_Home.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripButton_Home.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Home.Image")));
            this.ToolStripButton_Home.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_Home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Home.Name = "ToolStripButton_Home";
            this.ToolStripButton_Home.Size = new System.Drawing.Size(75, 60);
            this.ToolStripButton_Home.Text = "หน้าหลัก";
            this.ToolStripButton_Home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_Home.Click += new System.EventHandler(this.ToolStripButton_Home_Click);
            // 
            // ToolStripButton_RegisterStudent
            // 
            this.ToolStripButton_RegisterStudent.AutoSize = false;
            this.ToolStripButton_RegisterStudent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripButton_RegisterStudent.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_RegisterStudent.Image")));
            this.ToolStripButton_RegisterStudent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_RegisterStudent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_RegisterStudent.Name = "ToolStripButton_RegisterStudent";
            this.ToolStripButton_RegisterStudent.Size = new System.Drawing.Size(75, 60);
            this.ToolStripButton_RegisterStudent.Text = "ลงทะเบียน";
            this.ToolStripButton_RegisterStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_RegisterStudent.Click += new System.EventHandler(this.ToolStripButton_RegisterStudent_Click);
            // 
            // ToolStripButton_Student
            // 
            this.ToolStripButton_Student.AutoSize = false;
            this.ToolStripButton_Student.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripButton_Student.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Student.Image")));
            this.ToolStripButton_Student.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_Student.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Student.Name = "ToolStripButton_Student";
            this.ToolStripButton_Student.Size = new System.Drawing.Size(75, 60);
            this.ToolStripButton_Student.Text = "นักเรียน";
            this.ToolStripButton_Student.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_Student.Click += new System.EventHandler(this.ToolStripButton_Student_Click);
            // 
            // ToolStripButton_Teacher
            // 
            this.ToolStripButton_Teacher.AutoSize = false;
            this.ToolStripButton_Teacher.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripButton_Teacher.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Teacher.Image")));
            this.ToolStripButton_Teacher.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_Teacher.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Teacher.Name = "ToolStripButton_Teacher";
            this.ToolStripButton_Teacher.Size = new System.Drawing.Size(75, 60);
            this.ToolStripButton_Teacher.Text = "อาจารย์";
            this.ToolStripButton_Teacher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_Teacher.Click += new System.EventHandler(this.ToolStripButton_Teacher_Click);
            // 
            // ToolStripButton_Course
            // 
            this.ToolStripButton_Course.AutoSize = false;
            this.ToolStripButton_Course.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripButton_Course.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Course.Image")));
            this.ToolStripButton_Course.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_Course.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Course.Name = "ToolStripButton_Course";
            this.ToolStripButton_Course.Size = new System.Drawing.Size(75, 60);
            this.ToolStripButton_Course.Text = "วิชาเรียน";
            this.ToolStripButton_Course.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_Course.Click += new System.EventHandler(this.ToolStripButton_Course_Click);
            // 
            // ToolStripButton_Book
            // 
            this.ToolStripButton_Book.AutoSize = false;
            this.ToolStripButton_Book.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripButton_Book.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Book.Image")));
            this.ToolStripButton_Book.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_Book.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Book.Name = "ToolStripButton_Book";
            this.ToolStripButton_Book.Size = new System.Drawing.Size(75, 60);
            this.ToolStripButton_Book.Text = "หนังสือ";
            this.ToolStripButton_Book.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_Book.Click += new System.EventHandler(this.ToolStripButton_Book_Click);
            // 
            // ToolStripButton_CD
            // 
            this.ToolStripButton_CD.AutoSize = false;
            this.ToolStripButton_CD.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripButton_CD.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_CD.Image")));
            this.ToolStripButton_CD.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_CD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_CD.Name = "ToolStripButton_CD";
            this.ToolStripButton_CD.Size = new System.Drawing.Size(75, 60);
            this.ToolStripButton_CD.Text = "ซีดี";
            this.ToolStripButton_CD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_CD.Click += new System.EventHandler(this.ToolStripButton_CD_Click);
            // 
            // ToolStripButton_Payment
            // 
            this.ToolStripButton_Payment.AutoSize = false;
            this.ToolStripButton_Payment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripButton_Payment.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Payment.Image")));
            this.ToolStripButton_Payment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_Payment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Payment.Name = "ToolStripButton_Payment";
            this.ToolStripButton_Payment.Size = new System.Drawing.Size(75, 60);
            this.ToolStripButton_Payment.Text = "ใบเสร็จ";
            this.ToolStripButton_Payment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_Payment.Click += new System.EventHandler(this.ToolStripButton_Payment_Click);
            // 
            // ToolStripButton_DailyPaymentReport
            // 
            this.ToolStripButton_DailyPaymentReport.AutoSize = false;
            this.ToolStripButton_DailyPaymentReport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripButton_DailyPaymentReport.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_DailyPaymentReport.Image")));
            this.ToolStripButton_DailyPaymentReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_DailyPaymentReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_DailyPaymentReport.Name = "ToolStripButton_DailyPaymentReport";
            this.ToolStripButton_DailyPaymentReport.Size = new System.Drawing.Size(85, 60);
            this.ToolStripButton_DailyPaymentReport.Text = "สรุปรายรับ";
            this.ToolStripButton_DailyPaymentReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_DailyPaymentReport.Click += new System.EventHandler(this.ToolStripButton_DailyPaymentReport_Click);
            // 
            // ToolStripButton_AddUser
            // 
            this.ToolStripButton_AddUser.AutoSize = false;
            this.ToolStripButton_AddUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripButton_AddUser.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_AddUser.Image")));
            this.ToolStripButton_AddUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_AddUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_AddUser.Name = "ToolStripButton_AddUser";
            this.ToolStripButton_AddUser.Size = new System.Drawing.Size(75, 60);
            this.ToolStripButton_AddUser.Text = "เพิ่มผู้ใช้";
            this.ToolStripButton_AddUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_AddUser.Click += new System.EventHandler(this.ToolStripButton_AddUser_Click);
            // 
            // toolStripButton_CheckIn
            // 
            this.toolStripButton_CheckIn.AutoSize = false;
            this.toolStripButton_CheckIn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton_CheckIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_CheckIn.Image")));
            this.toolStripButton_CheckIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_CheckIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_CheckIn.Name = "toolStripButton_CheckIn";
            this.toolStripButton_CheckIn.Size = new System.Drawing.Size(75, 60);
            this.toolStripButton_CheckIn.Text = "เช็คอิน";
            this.toolStripButton_CheckIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_CheckIn.Click += new System.EventHandler(this.toolStripButton_CheckIn_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(88, 60);
            this.toolStripLabel1.Text = "                           ";
            // 
            // ToolStripButton_Logout
            // 
            this.ToolStripButton_Logout.AutoSize = false;
            this.ToolStripButton_Logout.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripButton_Logout.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Logout.Image")));
            this.ToolStripButton_Logout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripButton_Logout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Logout.Name = "ToolStripButton_Logout";
            this.ToolStripButton_Logout.Size = new System.Drawing.Size(90, 60);
            this.ToolStripButton_Logout.Text = "ออกจากระบบ";
            this.ToolStripButton_Logout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton_Logout.Click += new System.EventHandler(this.ToolStripButton_Logout_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Location = new System.Drawing.Point(0, 668);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusStrip.Size = new System.Drawing.Size(1018, 22);
            this.StatusStrip.TabIndex = 9;
            // 
            // classroomDetailtimer
            // 
            this.classroomDetailtimer.Interval = 5000;
            this.classroomDetailtimer.Tick += new System.EventHandler(this.classroomDetailtimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 690);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.Panel_Menu);
            this.Controls.Add(this.Panel_Body);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PianoForte Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Panel_Menu.ResumeLayout(false);
            this.Panel_Menu.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Body;
        private System.Windows.Forms.Panel Panel_Menu;
        private System.Windows.Forms.ToolStripButton ToolStripButton_Logout;
        private System.Windows.Forms.ToolStripButton ToolStripButton_AddUser;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton ToolStripButton_RegisterStudent;
        private System.Windows.Forms.ToolStripButton ToolStripButton_Student;
        private System.Windows.Forms.ToolStripButton ToolStripButton_Teacher;
        private System.Windows.Forms.ToolStripButton ToolStripButton_Course;
        private System.Windows.Forms.ToolStripButton ToolStripButton_Book;
        private System.Windows.Forms.ToolStripButton ToolStripButton_CD;
        private System.Windows.Forms.ToolStripButton ToolStripButton_Payment;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton ToolStripButton_Home;
        private System.Windows.Forms.ToolStripButton ToolStripButton_DailyPaymentReport;
        private System.Windows.Forms.ToolStripButton toolStripButton_CheckIn;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.Timer classroomDetailtimer;

    }
}