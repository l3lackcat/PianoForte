using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Constant;
using PianoForte.Manager;
using PianoForte.Model;
using PianoForte.Dao;

namespace PianoForte.View
{
    public partial class MainForm : Form
    {
        //Logged User
        private User user;

        //Current Form
        public static Form currentForm;

        //Login Form
        private static LoginForm loginForm;

        //Form on top menu        
        public static PaymentForm paymentForm;
        public static StudentMainForm studentMainForm;
        public static TeacherMainForm teacherMainForm;
        public static CourseMainForm courseMainForm;
        public static BookMainForm bookMainForm;
        public static CdMainForm cdMainForm;
        public static PaymentMainForm paymentMainForm;
        public static DailyPaymentReportForm dailyPaymentReportForm;
        public static CheckInMainForm checkInMainForm;
        public static PaymentForm2 paymentForm2;

        public MainForm()
        {
            //LogManager.writeLog("Start MainForm.InitializeComponent()");
            InitializeComponent();
            //LogManager.writeLog("Finish MainForm.InitializeComponent()");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //LogManager.writeLog("Start MainForm.MainForm_Load()");
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(6, 6);

            //LogManager.writeLog("Start DatabaseManager.readDatabaseConfiguration()");
            DatabaseManager.readDatabaseConfiguration();
            //LogManager.writeLog("Finish DatabaseManager.readDatabaseConfiguration()");

            //LogManager.writeLog("Start DateTimeManager.initialTimeList()");
            DateTimeManager.initialTimeList();
            //LogManager.writeLog("Finish DateTimeManager.initialTimeList()");

            Constant.Constant.STARTUP_PATH = Application.StartupPath;

            currentForm = null;

            user = new User();

            //LogManager.writeLog("Start loading LoginForm");
            loginForm = new LoginForm();
            loginForm.load(this);
            this.initialForm(loginForm);
            //LogManager.writeLog("Finish loading LoginForm");

            //LogManager.writeLog("Start loading PaymentForm");
            //paymentForm = new PaymentForm();
            //paymentForm.load(this);
            //this.initialForm(paymentForm);
            //LogManager.writeLog("Finish loading PaymentForm");

            //LogManager.writeLog("Start loading StudentMainForm");
            studentMainForm = new StudentMainForm();
            studentMainForm.load(this);
            this.initialForm(studentMainForm);
            //LogManager.writeLog("Finish loading StudentMainForm");

            //LogManager.writeLog("Start loading TeacherMainForm");
            teacherMainForm = new TeacherMainForm();
            teacherMainForm.load(this);
            this.initialForm(teacherMainForm);
            //LogManager.writeLog("Finish loading TeacherMainForm");

            //LogManager.writeLog("Start loading CourseMainForm");
            courseMainForm = new CourseMainForm();
            courseMainForm.load(this);
            this.initialForm(courseMainForm);
            //LogManager.writeLog("Finish loading CourseMainForm");

            //LogManager.writeLog("Start loading BookMainForm");
            bookMainForm = new BookMainForm();
            bookMainForm.load(this);
            this.initialForm(bookMainForm);
            //LogManager.writeLog("Finish loading BookMainForm");

            //LogManager.writeLog("Start loading CdMainForm");
            cdMainForm = new CdMainForm();
            cdMainForm.load(this);
            this.initialForm(cdMainForm);
            //LogManager.writeLog("Finish loading CdMainForm");

            //LogManager.writeLog("Start loading PaymentMainForm");
            paymentMainForm = new PaymentMainForm();
            paymentMainForm.load(this);
            this.initialForm(paymentMainForm);
            //LogManager.writeLog("Finish loading PaymentMainForm");

            //LogManager.writeLog("Start loading DailyPaymentReportForm");
            dailyPaymentReportForm = new DailyPaymentReportForm();
            dailyPaymentReportForm.load(this);
            this.initialForm(dailyPaymentReportForm);
            //LogManager.writeLog("Finish loading DailyPaymentReportForm");

            //LogManager.writeLog("Start loading CheckInMainForm");
            //checkInMainForm = new CheckInMainForm();
            //checkInMainForm.load(this);
            //this.initialForm(checkInMainForm);
            //LogManager.writeLog("Finish loading CheckInMainForm");

            paymentForm2 = new PaymentForm2();
            paymentForm2.load(this);
            this.initialForm(paymentForm2);

            this.switchForm(loginForm);

            //LogManager.writeLog("Finish MainForm.MainForm_Load()");
        }

        public void loginSuccess(User user)
        {
            this.classroomDetailtimer.Enabled = true;

            this.user = user;
            dailyPaymentReportForm.init(this.user.Role);
            this.switchForm(paymentForm2);
        }

        public User getUser()
        {
            return this.user;
        }

        private void ToolStripButton_Home_Click(object sender, EventArgs e)
        {
            this.switchForm(paymentForm2);
        }

        private void ToolStripButton_RegisterStudent_Click(object sender, EventArgs e)
        {
            StudentRegisterForm studentRegisterForm = new StudentRegisterForm();
            Student student = studentRegisterForm.showFormDialog();
            if (student != null)
            {
                MainForm.paymentForm2.setStudent(student);
                this.switchForm(MainForm.paymentForm2);
            }
        }        

        private void ToolStripButton_Student_Click(object sender, EventArgs e)
        {
            studentMainForm.reset();
            this.switchForm(studentMainForm);
        }

        private void ToolStripButton_Teacher_Click(object sender, EventArgs e)
        {
            teacherMainForm.reset();
            this.switchForm(teacherMainForm);
        }

        private void ToolStripButton_Course_Click(object sender, EventArgs e)
        {
            courseMainForm.reset();          
            this.switchForm(courseMainForm);
        }

        private void ToolStripButton_Book_Click(object sender, EventArgs e)
        {
            bookMainForm.reset();
            this.switchForm(bookMainForm);
        }

        private void ToolStripButton_CD_Click(object sender, EventArgs e)
        {
            cdMainForm.reset();
            this.switchForm(cdMainForm);
        }

        private void ToolStripButton_Payment_Click(object sender, EventArgs e)
        {
            paymentMainForm.reset();
            this.switchForm(paymentMainForm);
        }

        private void ToolStripButton_DailyPaymentReport_Click(object sender, EventArgs e)
        {
            dailyPaymentReportForm.reset();
            this.switchForm(dailyPaymentReportForm);
        }

        private void ToolStripButton_AddUser_Click(object sender, EventArgs e)
        {
            UserRegisterForm userRegisterForm = new UserRegisterForm();
            userRegisterForm.showFormDialog();
        }

        private void toolStripButton_CheckIn_Click(object sender, EventArgs e)
        {
            //checkInMainForm.init();
            //checkInMainForm.reload();
            //this.switchForm(checkInMainForm);
            this.switchForm(paymentForm2);            
        } 

        private void ToolStripButton_Logout_Click(object sender, EventArgs e)
        {
            this.classroomDetailtimer.Enabled = false;

            this.user = null;
            loginForm.reset();
            this.switchForm(loginForm);
        }

        private void initialForm(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.Panel_Body.Controls.Add(form);
        }

        public void switchForm(Form form)
        {
            if (currentForm != null)
            {                
                currentForm.Hide();
            }

            if (form is LoginForm)
            {
                this.enableTopMenu(false);
            }
            else
            {
                this.enableTopMenu(true);
            }

            currentForm = form;            
            currentForm.Show();

            if (currentForm is PaymentForm2)
            {
                paymentForm2.updateFocusedTextBox();
            }
        }  
      
        public void switchForm(PaymentForm2 paymentForm2, Student student)
        {
            if (currentForm != null)
            {
                currentForm.Hide();
            }

            paymentForm2.setStudent(student);
            currentForm = paymentForm2;
            currentForm.Show();
        } 
       
        private void enableTopMenu(bool isLoggedIn)
        {
            this.ToolStripButton_Home.Enabled = isLoggedIn;            
            this.ToolStripButton_RegisterStudent.Enabled = isLoggedIn;
            this.ToolStripButton_Student.Enabled = isLoggedIn;
            this.ToolStripButton_Teacher.Enabled = isLoggedIn;
            this.ToolStripButton_Course.Enabled = isLoggedIn;
            this.ToolStripButton_Book.Enabled = isLoggedIn;
            this.ToolStripButton_CD.Enabled = isLoggedIn;
            this.ToolStripButton_Payment.Enabled = isLoggedIn;
            this.ToolStripButton_DailyPaymentReport.Enabled = isLoggedIn;
            //this.toolStripButton_CheckIn.Enabled = isLoggedIn;
          
            if (isLoggedIn)
            {
                if (this.user.Role == (int)User.UserRole.ADMIN)
                {
                    this.ToolStripButton_AddUser.Enabled = true;
                }
                else
                {
                    this.ToolStripButton_AddUser.Enabled = false;
                }
            }            
            else
            {
                this.ToolStripButton_AddUser.Enabled = false;
            }

            this.ToolStripButton_Logout.Enabled = isLoggedIn;
        }

        private void classroomDetailtimer_Tick(object sender, EventArgs e)
        {
            //To Do
        }
    }
}
