using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Constant;
using PianoForte.Interface;
using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.View
{
    public partial class StudentRegisterForm : Form
    {
        //private MainForm mainForm;
        private Student student;

        public StudentRegisterForm()
        {
            InitializeComponent();
        }

        private void StudentRegisterForm_Load(object sender, EventArgs e)
        {
            //Do Nothing
        }

        public Student showFormDialog()
        {
            this.TextBox_Firstname.Text = "";
            this.TextBox_Lastname.Text = "";
            this.TextBox_Nickname.Text = "";
            this.DateTimePicker_Birthday.Value = DateTime.Today;
            this.TextBox_Address1.Text = "";
            this.TextBox_Address2.Text = "";
            this.TextBox_PostCode.Text = "";
            this.TextBox_Phone1_1.Text = "";
            this.TextBox_Phone1_2.Text = "";
            this.TextBox_Phone2_1.Text = "";
            this.TextBox_Phone2_2.Text = "";
            this.TextBox_Phone3_1.Text = "";
            this.TextBox_Phone3_2.Text = "";
            this.TextBox_Email.Text = "";

            this.ShowDialog();

            return this.student;
        }      

        private void refreshButton_OK()
        {
            if ((this.TextBox_Firstname.Text != "") &&
                (this.TextBox_Lastname.Text != "") &&
                (this.TextBox_Nickname.Text != "") &&
                (this.TextBox_Address1.Text != "") &&
                (this.TextBox_PostCode.Text != "") &&
                (this.TextBox_Phone1_1.Text != "") &&
                (this.TextBox_Phone1_2.Text != ""))
            {
                this.Button_OK.Enabled = true;
            }
            else
            {
                this.Button_OK.Enabled = false;
            }
        }

        private void TextBox_Firstname_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_OK();
        }

        private void TextBox_Lastname_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_OK();
        }

        private void TextBox_Nickname_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_OK();
        }

        private void TextBox_Address1_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_OK();
        }

        private void TextBox_PostCode_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_OK();
        }

        private void TextBox_PostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }        

        private void TextBox_Phone1_1_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_OK();
        }

        private void TextBox_Phone1_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }
        
        private void TextBox_Phone1_2_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_OK();
        }

        private void TextBox_Phone1_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                Address address = new Address();
                address.Address1 = this.TextBox_Address1.Text;
                address.Address2 = this.TextBox_Address2.Text;
                if (ValidateManager.isNumber(this.TextBox_PostCode.Text))
                {
                    address.PostCode = Convert.ToInt32(this.TextBox_PostCode.Text);
                }

                this.student = new Student();
                this.student.Firstname = this.TextBox_Firstname.Text;
                this.student.Lastname = this.TextBox_Lastname.Text;
                this.student.Nickname = this.TextBox_Nickname.Text;

                this.student.Birthday = Convert.ToDateTime(this.DateTimePicker_Birthday.Text);
                this.student.Address = address;
                this.student.Phone1 = this.TextBox_Phone1_1.Text + this.TextBox_Phone1_2.Text;
                this.student.Phone2 = this.TextBox_Phone2_1.Text + this.TextBox_Phone2_2.Text;
                if (this.student.Phone2 == "")
                {
                    this.student.Phone2 = this.TextBox_Phone3_1.Text + this.TextBox_Phone3_2.Text;
                    this.student.Phone3 = "";
                }
                else
                {
                    this.student.Phone3 = this.TextBox_Phone3_1.Text + this.TextBox_Phone3_2.Text;
                }
                this.student.Email = this.TextBox_Email.Text;
                this.student.Status = Student.StudentStatus.INACTIVE.ToString();
                this.student.RegisteredDate = DateTime.Today;

                string result = ValidateManager.validate(student);
                if (result == ValidateManager.NO_ERROR_TEXT)
                {
                    this.student.Phone1 = ConvertManager.toDisplayPhoneNumber(this.student.Phone1);
                    this.student.Phone2 = ConvertManager.toDisplayPhoneNumber(this.student.Phone2);
                    this.student.Phone3 = ConvertManager.toDisplayPhoneNumber(this.student.Phone3);

                    this.student = StudentManager.insertStudent(this.student);
                    if (this.student != null)
                    {
                        //MessageBox.Show(DatabaseConstant.INSERT_DATA_SUCCESS);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(DatabaseConstant.INSERT_DATA_FAIL);
                    }
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
            catch (System.Exception exception)
            {
                Console.Write(exception.Message);
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
