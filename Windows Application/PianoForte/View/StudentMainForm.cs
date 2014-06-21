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
    public partial class StudentMainForm : Form, FormInterface
    {
        private MainForm mainForm;
        private List<Student> studentList;

        public StudentMainForm()
        {
            InitializeComponent();
        }

        private void StudentMainForm_Load(object sender, EventArgs e)
        {
            //Do Nothing
        }

        public void load(MainForm mainForm)
        {
            this.mainForm = mainForm;           
            this.studentList = new List<Student>();

            this.DataGridView_StudentInfo.AutoGenerateColumns = false;

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
            this.studentList.Clear();

            this.RadioButton_Show_AllStudent.Checked = true;
            this.RadioButton_Search_StudentId.Checked = false;
            this.RadioButton_Search_Info.Checked = false;

            this.Textbox_StudentId.Text = "";
            this.TextBox_Firstname.Text = "";
            this.TextBox_Lastname.Text = "";
            this.TextBox_Nickname.Text = "";

            if (this.ComboBox_NumberPerPage.Items.Count > 0)
            {
                this.ComboBox_NumberPerPage.SelectedIndex = 0;
            }

            this.TextBox_PageNumber.Text = "1";

            this.refreshDataGridView_StudentInfo();
        }

        private void keyPressed(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyData == Keys.Enter)
            {
                this.TextBox_PageNumber.Text = "1";
                this.search();
            }
        }

        private void refreshDataGridView_StudentInfo()
        {
            this.DataGridView_StudentInfo.DataSource = null;

            if (this.studentList.Count > 0)
            {
                this.DataGridView_StudentInfo.DataSource = this.studentList;
            }

            this.DataGridView_StudentInfo.ClearSelection();
        }

        private void search()
        {
            if (MainForm.currentForm is StudentMainForm)
            {
                List<Student> tempStudentList = new List<Student>();

                int numberPerPage = Convert.ToInt32(this.ComboBox_NumberPerPage.Text);
                int pageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text);
                int startIndex = (pageNumber - 1) * numberPerPage;

                if (this.RadioButton_Show_AllStudent.Checked)
                {
                    this.studentList = StudentManager.findAllStudent(startIndex, numberPerPage);
                    tempStudentList = StudentManager.findAllStudent(startIndex + numberPerPage, numberPerPage);
                }
                else if (this.RadioButton_Search_StudentId.Checked)
                {
                    this.studentList.Clear();

                    string temp = this.Textbox_StudentId.Text;
                    if (temp != "")
                    {
                        int studentId = Convert.ToInt32(temp);

                        Student student = StudentManager.findStudent(studentId);
                        if (student != null)
                        {
                            this.studentList.Add(student);
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
                        this.studentList = StudentManager.findAllStudent(startIndex, numberPerPage);
                        tempStudentList = StudentManager.findAllStudent(startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname == "") && (lastname == "") && (nickname != ""))
                    {
                        this.studentList = StudentManager.findAllStudentByNickname(nickname, startIndex, numberPerPage);
                        tempStudentList = StudentManager.findAllStudentByNickname(nickname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname == "") && (lastname != "") && (nickname == ""))
                    {
                        this.studentList = StudentManager.findAllStudentByLastname(lastname, startIndex, numberPerPage);
                        tempStudentList = StudentManager.findAllStudentByLastname(lastname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname == "") && (lastname != "") && (nickname != ""))
                    {
                        this.studentList = StudentManager.findAllStudentByLastnameAndNickname(lastname, nickname, startIndex, numberPerPage);
                        tempStudentList = StudentManager.findAllStudentByLastnameAndNickname(lastname, nickname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname != "") && (lastname == "") && (nickname == ""))
                    {
                        this.studentList = StudentManager.findAllStudentByFirstname(firstname, startIndex, numberPerPage);
                        tempStudentList = StudentManager.findAllStudentByFirstname(firstname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname != "") && (lastname == "") && (nickname != ""))
                    {
                        this.studentList = StudentManager.findAllStudentByFirstnameAndNickname(firstname, nickname, startIndex, numberPerPage);
                        tempStudentList = StudentManager.findAllStudentByFirstnameAndNickname(firstname, nickname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname != "") && (lastname != "") && (nickname == ""))
                    {
                        this.studentList = StudentManager.findAllStudentByFirstnameAndLastname(firstname, lastname, startIndex, numberPerPage);
                        tempStudentList = StudentManager.findAllStudentByFirstnameAndLastname(firstname, lastname, startIndex + numberPerPage, numberPerPage);
                    }
                    else if ((firstname != "") && (lastname != "") && (nickname != ""))
                    {
                        this.studentList = StudentManager.findAllStudentByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex, numberPerPage);
                        tempStudentList = StudentManager.findAllStudentByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex + numberPerPage, numberPerPage);
                    }                    
                }

                if (this.studentList.Count == 0)
                {
                    MessageBox.Show(DatabaseConstant.DATA_NOT_FOUND);
                }
                else if (this.studentList.Count < numberPerPage)
                {
                    this.Button_NextPage.Enabled = false;
                }
                else if (this.studentList.Count == numberPerPage)
                {
                    this.refreshButton_NextPage(tempStudentList);
                }

                this.refreshDataGridView_StudentInfo(); 
            }

            this.Textbox_StudentId.Text = "";
            this.TextBox_Firstname.Text = "";
            this.TextBox_Lastname.Text = "";
            this.TextBox_Nickname.Text = "";       
        }

        private void refreshButton_NextPage(List<Student> studentList)
        {
            if (studentList.Count > 0)
            {
                this.Button_NextPage.Enabled = true;
            }
            else
            {
                this.Button_NextPage.Enabled = false;
            }
        }

        private void RadioButton_ShowAll_CheckedChanged(object sender, EventArgs e)
        {
            this.Textbox_StudentId.Enabled = false;
            this.TextBox_Firstname.Enabled = false;
            this.TextBox_Lastname.Enabled  = false;
            this.TextBox_Nickname.Enabled  = false;
        }

        private void RadioButton_Show_AllStudent_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }
        
        private void RadioButton_Search_StudentId_CheckedChanged(object sender, EventArgs e)
        {
            this.Textbox_StudentId.Enabled = true;
            this.TextBox_Firstname.Enabled = false;
            this.TextBox_Lastname.Enabled  = false;
            this.TextBox_Nickname.Enabled  = false;

            this.TextBox_Firstname.Text = "";
            this.TextBox_Lastname.Text = "";
            this.TextBox_Nickname.Text = "";
        }

        private void RadioButton_Search_StudentId_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void Textbox_StudentId_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }        

        private void RadioButton_Search_Info_CheckedChanged(object sender, EventArgs e)
        {
            this.Textbox_StudentId.Enabled = false;            
            this.TextBox_Firstname.Enabled = true;
            this.TextBox_Lastname.Enabled  = true;
            this.TextBox_Nickname.Enabled  = true;

            this.Textbox_StudentId.Text = "";
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

        private void DataGridView_StudentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 9:
                        {
                            StudentProfileForm studentProfileForm = new StudentProfileForm();
                            studentProfileForm.showFormDialog(this.studentList[e.RowIndex], this.mainForm, false);
                        }
                        break;
                    case 10:
                        {
                            StudentProfileForm studentProfileForm = new StudentProfileForm();
                            studentProfileForm.showFormDialog(this.studentList[e.RowIndex], this.mainForm, true);
                        }
                        break;
                }
            }

            this.Cursor = Cursors.Arrow;
        }

        private void DataGridView_StudentInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MainForm.paymentForm2.setStudent(studentList[e.RowIndex]);
                this.mainForm.switchForm(MainForm.paymentForm2);
            }

            this.Cursor = Cursors.Arrow;
        } 

        private void DataGridView_StudentInfo_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 9:
                        {
                            this.Cursor = Cursors.Hand;
                            this.DataGridView_StudentInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "View";
                        }
                        break;
                    case 10:
                        {
                            this.Cursor = Cursors.Hand;
                            this.DataGridView_StudentInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Edit";
                        }
                        break;
                }
            }
        }

        private void DataGridView_StudentInfo_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
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
            StudentRegisterForm studentRegisterForm = new StudentRegisterForm();
            Student student = studentRegisterForm.showFormDialog();
            if (student != null)
            {
                MainForm.paymentForm2.setStudent(student);
                this.mainForm.switchForm(MainForm.paymentForm2);
            }
        }                    
    }
}
