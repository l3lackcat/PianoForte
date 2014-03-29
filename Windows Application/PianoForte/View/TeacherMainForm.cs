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
    public partial class TeacherMainForm : Form, FormInterface
    {
        private MainForm mainForm;
        private List<Teacher> teacherList;

        public TeacherMainForm()
        {
            InitializeComponent();
        }

        private void TeacherMainForm_Load(object sender, EventArgs e)
        {
            //Do Nothing
        }

        public void load(MainForm mainForm)
        {
            this.mainForm = mainForm;            
            this.teacherList = new List<Teacher>();

            this.DataGridView_TeacherInfo.AutoGenerateColumns = false;

            this.ComboBox_NumberPerPage.Items.Clear();
            this.ComboBox_NumberPerPage.Items.Add("20");
            this.ComboBox_NumberPerPage.Items.Add("40");
            this.ComboBox_NumberPerPage.Items.Add("60");            
        }

        public void reload()
        {
            //Do Nothing            
        }

        public void reset()
        {
            this.teacherList.Clear();

            this.RadioButton_Show_AllTeacher.Checked = true;
            this.RadioButton_Search_TeacherID.Checked = false;
            this.RadioButton_Search_Info.Checked = false;

            this.Textbox_TeacherID.Text = "";
            this.TextBox_Firstname.Text = "";
            this.TextBox_Lastname.Text = "";
            this.TextBox_Nickname.Text = "";

            if (this.ComboBox_NumberPerPage.Items.Count > 0)
            {
                this.ComboBox_NumberPerPage.SelectedIndex = 0;
            }

            this.TextBox_PageNumber.Text = "1";

            this.refreshDataGridView_TeacherInfo();
        }

        private void keyPressed(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyData == Keys.Enter)
            {
                this.TextBox_PageNumber.Text = "1";
                this.search();
            }
        }

        private void refreshDataGridView_TeacherInfo()
        {
            this.DataGridView_TeacherInfo.DataSource = null;

            if (this.teacherList.Count > 0)
            {
                this.DataGridView_TeacherInfo.DataSource = this.teacherList;                
            }

            this.DataGridView_TeacherInfo.ClearSelection();
        }

        private void search()
        {
            if (MainForm.currentForm is TeacherMainForm)
            {
                List<Teacher> tempTeacherList = new List<Teacher>();

                int numberPerPage = Convert.ToInt32(this.ComboBox_NumberPerPage.Text);
                int pageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text);
                int startIndex = (pageNumber - 1) * numberPerPage;

                if (this.RadioButton_Show_AllTeacher.Checked)
                {
                    this.teacherList = TeacherManager.findAllTeacher(startIndex, numberPerPage);
                    tempTeacherList = TeacherManager.findAllTeacher(startIndex + numberPerPage, numberPerPage);
                }
                else if (this.RadioButton_Search_TeacherID.Checked)
                {
                    this.teacherList.Clear();

                    string temp = this.Textbox_TeacherID.Text;
                    if (temp != "")
                    {
                        int teacherID = Convert.ToInt32(temp);

                        Teacher teacher = TeacherManager.findTeacher(teacherID);
                        if (teacher != null)
                        {
                            this.teacherList.Add(teacher);
                        }
                    }
                }
                else if (this.RadioButton_Search_Info.Checked)
                {
                    string firstname = this.TextBox_Firstname.Text;
                    string lastname = this.TextBox_Lastname.Text;
                    string nickname = this.TextBox_Nickname.Text;

                    if ((firstname == "") && (lastname == "") && (nickname == ""))
                    {
                        this.teacherList = TeacherManager.findAllTeacher(startIndex, numberPerPage);
                        tempTeacherList = TeacherManager.findAllTeacher(startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname == "") && (lastname == "") && (nickname != ""))
                    {
                        this.teacherList = TeacherManager.findAllTeacherByNickname(nickname, startIndex, numberPerPage);
                        tempTeacherList = TeacherManager.findAllTeacherByNickname(nickname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname == "") && (lastname != "") && (nickname == ""))
                    {
                        this.teacherList = TeacherManager.findAllTeacherByLastname(lastname, startIndex, numberPerPage);
                        tempTeacherList = TeacherManager.findAllTeacherByLastname(lastname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname == "") && (lastname != "") && (nickname != ""))
                    {
                        this.teacherList = TeacherManager.findAllTeacherByLastnameAndNickname(lastname, nickname, startIndex, numberPerPage);
                        tempTeacherList = TeacherManager.findAllTeacherByLastnameAndNickname(lastname, nickname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname != "") && (lastname == "") && (nickname == ""))
                    {
                        this.teacherList = TeacherManager.findAllTeacherByFirstname(firstname, startIndex, numberPerPage);
                        tempTeacherList = TeacherManager.findAllTeacherByFirstname(firstname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname != "") && (lastname == "") && (nickname != ""))
                    {
                        this.teacherList = TeacherManager.findAllTeacherByFirstnameAndNickname(firstname, nickname, startIndex, numberPerPage);
                        tempTeacherList = TeacherManager.findAllTeacherByFirstnameAndNickname(firstname, nickname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname != "") && (lastname != "") && (nickname == ""))
                    {
                        this.teacherList = TeacherManager.findAllTeacherByFirstnameAndLastname(firstname, lastname, startIndex, numberPerPage);
                        tempTeacherList = TeacherManager.findAllTeacherByFirstnameAndLastname(firstname, lastname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname != "") && (lastname != "") && (nickname != ""))
                    {
                        this.teacherList = TeacherManager.findAllTeacherByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex, numberPerPage);
                        tempTeacherList = TeacherManager.findAllTeacherByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex + numberPerPage, numberPerPage);
                    }                    
                }

                if (this.teacherList.Count == 0)
                {
                    MessageBox.Show(DatabaseConstant.DATA_NOT_FOUND);
                }
                else if (this.teacherList.Count < numberPerPage)
                {
                    this.Button_NextPage.Enabled = false;
                }
                else if (this.teacherList.Count == numberPerPage)
                {
                    this.refreshButton_NextPage(tempTeacherList);
                }

                this.refreshDataGridView_TeacherInfo();
            }

            this.Textbox_TeacherID.Text = "";
            this.TextBox_Firstname.Text = "";
            this.TextBox_Lastname.Text = "";
            this.TextBox_Nickname.Text = "";
        }

        private void refreshButton_NextPage(List<Teacher> teacherList)
        {
            if (teacherList.Count > 0)
            {
                this.Button_NextPage.Enabled = true;
            }
            else
            {
                this.Button_NextPage.Enabled = false;
            }
        }

        private void RadioButton_Show_AllTeacher_CheckedChanged(object sender, EventArgs e)
        {
            this.Textbox_TeacherID.Enabled = false;
            this.TextBox_Firstname.Enabled = false;
            this.TextBox_Lastname.Enabled  = false;
            this.TextBox_Nickname.Enabled  = false;
        }

        private void RadioButton_Show_AllTeacher_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void RadioButton_Search_TeacherID_CheckedChanged(object sender, EventArgs e)
        {
            this.Textbox_TeacherID.Enabled = true;
            this.TextBox_Firstname.Enabled = false;
            this.TextBox_Lastname.Enabled  = false;
            this.TextBox_Nickname.Enabled  = false;

            this.TextBox_Firstname.Text = "";
            this.TextBox_Lastname.Text = "";
            this.TextBox_Nickname.Text = "";
        }

        private void RadioButton_Search_TeacherID_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void Textbox_TeacherID_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void RadioButton_Search_Info_CheckedChanged(object sender, EventArgs e)
        {
            this.Textbox_TeacherID.Enabled = false;
            this.TextBox_Firstname.Enabled = true;
            this.TextBox_Lastname.Enabled  = true;
            this.TextBox_Nickname.Enabled  = true;

            this.Textbox_TeacherID.Text = "";
        }

        private void RadioButton_Search_Info_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_Firstname_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_Lastname_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_Nickname_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void ComboBox_Status_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        } 

        private void Button_Search_Click(object sender, EventArgs e)
        {
            this.TextBox_PageNumber.Text = "1";
            this.search();
        }

        private void DataGridView_TeacherInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 9:
                        {
                            TeacherProfileForm teacherProfileForm = new TeacherProfileForm();
                            teacherProfileForm.showFormDialog(this.teacherList[e.RowIndex], false);
                        }
                        break;
                    case 10:
                        {
                            TeacherProfileForm teacherProfileForm = new TeacherProfileForm();
                            teacherProfileForm.showFormDialog(this.teacherList[e.RowIndex], true);
                        }
                        break;
                }
            }

            this.Cursor = Cursors.Arrow;
        }

        private void DataGridView_TeacherInfo_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 9:
                        {
                            this.Cursor = Cursors.Hand;
                            this.DataGridView_TeacherInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "View";
                        }
                        break;
                    case 10:
                        {
                            this.Cursor = Cursors.Hand;
                            this.DataGridView_TeacherInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Edit";
                        }
                        break;
                }
            }
        }

        private void DataGridView_TeacherInfo_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }                                     

        private void ComboBox_NumberPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TextBox_PageNumber.Text = "1";
            this.search();
        }

        private void Button_PreviousPage_Click(object sender, EventArgs e)
        {
            int currentPageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text) - 1;
            this.TextBox_PageNumber.Text = currentPageNumber.ToString();
            this.search();
        }

        private void TextBox_PageNumber_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox_PageNumber.Text == "1")
            {
                this.Button_PreviousPage.Enabled = false;
            }
            else
            {
                this.Button_PreviousPage.Enabled = true;
            }
        }

        private void Button_NextPage_Click(object sender, EventArgs e)
        {
            int currentPageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text) + 1;
            this.TextBox_PageNumber.Text = currentPageNumber.ToString();
            this.search();
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            TeacherRegisterForm teacherRegisterForm = new TeacherRegisterForm();
            teacherRegisterForm.ShowDialog();
        }
    }
}
