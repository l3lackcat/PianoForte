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
    public partial class UserRegisterForm : Form
    {
        public UserRegisterForm()
        {
            InitializeComponent();
        }

        private void UserRegisterForm_Load(object sender, EventArgs e)
        {
            //Do Nothing
        }

        public void showFormDialog()
        {
            this.ComboBox_Role.Items.Clear();
            this.ComboBox_Role.Items.Add("Normal");
            this.ComboBox_Role.Items.Add("Admin");

            this.TextBox_Username.Text = "";
            this.TextBox_Password.Text = "";
            this.TextBox_RePassword.Text = "";
            this.TextBox_DisplayName.Text = "";

            if (this.ComboBox_Role.Items.Count > 0)
            {
                this.ComboBox_Role.SelectedIndex = 0;
            }

            this.ShowDialog();
        }

        public void refreshButton_Submit_Register()
        {
            if ((this.TextBox_Username.Text != "") &&
                (this.TextBox_Password.Text != "") &&
                (this.TextBox_RePassword.Text != "") &&
                (this.TextBox_DisplayName.Text != ""))
            {
                this.Button_Submit.Enabled = true;
            }
            else
            {
                this.Button_Submit.Enabled = false;
            }
        }

        public void registerUser()
        {
            if (this.TextBox_Password.Text == this.TextBox_RePassword.Text)
            {
                User user = UserManager.findUser(this.TextBox_Username.Text);
                if (user == null)
                {
                    user = new User();
                    user.Username = this.TextBox_Username.Text;
                    user.Password = this.TextBox_Password.Text;
                    user.Role = this.ComboBox_Role.SelectedIndex;
                    user.DisplayName = this.TextBox_DisplayName.Text;

                    bool isRegisterSuccess = UserManager.insertUser(user);
                    if (isRegisterSuccess)
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
                    MessageBox.Show("Username ได้ถูกใช้ไปแล้ว");
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกพาสเวิร์ดให้ถูกต้อง");
            }
        }

        private void TextBox_Username_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit_Register();
        }

        private void TextBox_Password_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit_Register();
        }

        private void TextBox_RePassword_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit_Register();
        }

        private void TextBox_DisplayName_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit_Register();
        }

        private void Button_Submit_Register_Click(object sender, EventArgs e)
        {
            this.registerUser();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
