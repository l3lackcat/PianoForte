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

namespace PianoForte.View
{
    public partial class PaymentForm_Student : Form
    {
        private PaymentForm paymentForm;
        private Student student;

        public PaymentForm_Student()
        {
            InitializeComponent();
        }

        public void load(PaymentForm paymentForm)
        {
            this.paymentForm = paymentForm;
            this.student = new Student();
        }

        public void reset()
        {
            this.student = null;

            this.enableGroupBoxStudent(true);

            this.TextBox_StudentId_ForSearch.Text = "";
            this.Button_Search_Student.Enabled = false;

            this.TextBox_StudentId.Text = "";
            this.TextBox_Firstname.Text = "";
            this.TextBox_Lastname.Text = "";
            this.TextBox_Nickname.Text = "";
            this.TextBox_StudentStatus.Text = "";

            this.Button_ViewStudentProfile.Enabled = false;
        }        

        public void enableGroupBoxStudent(bool isEnable)
        {
            this.GroupBox_Student.Enabled = isEnable;
        }

        private void searchStudent()
        {
            string stringStudentId = this.TextBox_StudentId_ForSearch.Text;
            if (stringStudentId != "")
            {
                if (ValidateManager.isNumber(stringStudentId))
                {
                    this.searchStudent(Convert.ToInt32(stringStudentId));
                }
            }            
        }

        public void searchStudent(int studentId)
        {
            Student tempStudent = StudentManager.findStudent(studentId);
            if (tempStudent != null)
            {
                this.initGroupBox_Student(tempStudent);
                //this.paymentForm.initComboBox_Not_Paid_Enrollment(EnrollmentManager.findAllEnrollment(studentId, Enrollment.EnrollmentStatus.NOT_PAID.ToString()));
                this.paymentForm.initComboBox_Not_Paid_Enrollment(EnrollmentManager.findAllEnrollmentByStudentId(studentId, Enrollment.EnrollmentStatus.NOT_PAID), -1);
            }
            else
            {
                MessageBox.Show(DatabaseConstant.DATA_NOT_FOUND);
                this.reset();                
            }

            this.TextBox_StudentId_ForSearch.Text = "";
        }

        public void initGroupBox_Student(Student student)
        {
            if (student != null)
            {
                this.student = student;

                this.TextBox_StudentId.Text = this.student.Id.ToString();
                this.TextBox_Firstname.Text = this.student.Firstname;
                this.TextBox_Lastname.Text = this.student.Lastname;
                this.TextBox_Nickname.Text = this.student.Nickname;
                this.TextBox_StudentStatus.Text = this.student.Status;

                this.Button_ViewStudentProfile.Enabled = true;

                this.paymentForm.setStudent(this.student);
            }
            else
            {
                this.reset();
            }
        }

        private void TextBox_StudentId_ForSearch_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox_StudentId_ForSearch.Text != "")
            {
                this.Button_Search_Student.Enabled = true;
            }
            else
            {
                this.Button_Search_Student.Enabled = false;
            }
        }

        private void TextBox_StudentId_ForSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.searchStudent();
            }
        }

        private void Button_Search_Student_Click(object sender, EventArgs e)
        {
            this.searchStudent();
        }

        private void Button_ViewStudentProfile_Click(object sender, EventArgs e)
        {
            //To Do
        }
    }
}
