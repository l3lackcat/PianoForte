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
    public partial class TeacherRegisterForm : Form
    {
        private Teacher teacher;

        public TeacherRegisterForm()
        {
            InitializeComponent();
        }

        private void TeacherRegisterForm_Load(object sender, EventArgs e)
        {
            //Do Nothing
        }

        public void showFormDialog()
        {
            this.TextBox_Firstname.Text = "";
            this.TextBox_Lastname.Text = "";
            this.TextBox_Nickname.Text = "";
            this.TextBox_Phone1_1.Text = "";
            this.TextBox_Phone1_2.Text = "";
            this.TextBox_Phone2_1.Text = "";
            this.TextBox_Phone2_2.Text = "";
            this.TextBox_Phone3_1.Text = "";
            this.TextBox_Phone3_2.Text = "";
            this.TextBox_Email.Text = "";

            this.ShowDialog();
        }        

        private void refreshButton_OK()
        {
            if ((this.TextBox_Firstname.Text != "") &&
                (this.TextBox_Lastname.Text != "") &&
                (this.TextBox_Nickname.Text != "") &&
                (this.TextBox_Phone1_1.Text != "") &&
                (this.TextBox_Phone1_2.Text != "") &&
                (this.TextBox_Email.Text != ""))
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

        private void TextBox_Email_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_OK();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                this.teacher = new Teacher();
                this.teacher.Id = TeacherManager.generateNextTeacherId();
                this.teacher.Firstname = this.TextBox_Firstname.Text;
                this.teacher.Lastname = this.TextBox_Lastname.Text;
                this.teacher.Nickname = this.TextBox_Nickname.Text;
                this.teacher.Phone1 = this.TextBox_Phone1_1.Text + this.TextBox_Phone1_2.Text;
                this.teacher.Phone2 = this.TextBox_Phone2_1.Text + this.TextBox_Phone2_2.Text;
                this.teacher.Phone3 = this.TextBox_Phone3_1.Text + this.TextBox_Phone3_2.Text;
                this.teacher.Email = this.TextBox_Email.Text;
                this.teacher.Status = Teacher.TeacherStatus.ACTIVE.ToString();

                string result = ValidateManager.validate(this.teacher);
                if (result == "")
                {
                    this.teacher.Phone1 = ConvertManager.toDisplayPhoneNumber(this.teacher.Phone1);
                    this.teacher.Phone2 = ConvertManager.toDisplayPhoneNumber(this.teacher.Phone2);
                    this.teacher.Phone3 = ConvertManager.toDisplayPhoneNumber(this.teacher.Phone3);

                    this.teacher = TeacherManager.insertTeacher(this.teacher);
                    if (this.teacher != null)
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
