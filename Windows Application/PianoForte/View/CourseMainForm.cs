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
    public partial class CourseMainForm : Form, FormInterface
    {
        private MainForm mainForm;
        private List<CourseCategory> courseCategoryList;
        private List<Course> courseList;

        public CourseMainForm()
        {
            InitializeComponent();
        }

        private void CourseMainForm_Load(object sender, EventArgs e)
        {
            //Do Nothing                       
        }

        public void load(MainForm mainForm)
        {
            this.mainForm = mainForm;            
            this.courseCategoryList = new List<CourseCategory>();
            this.courseList = new List<Course>();            

            this.ComboBox_Status.Items.Clear();
            this.ComboBox_Status.Items.Add(Course.CourseStatus.ALL.ToString());
            this.ComboBox_Status.Items.Add(Course.CourseStatus.ACTIVE.ToString());
            this.ComboBox_Status.Items.Add(Course.CourseStatus.INACTIVE.ToString());

            this.DataGridView_CourseInfo.AutoGenerateColumns = false;

            this.ComboBox_NumberPerPage.Items.Clear();
            this.ComboBox_NumberPerPage.Items.Add("20");
            this.ComboBox_NumberPerPage.Items.Add("40");
            this.ComboBox_NumberPerPage.Items.Add("60");
        }

        public void reload()
        {
            this.ComboBox_CourseCategory.Items.Clear();

            this.ComboBox_CourseCategory.Items.Add(CourseCategory.CourseCategoryStatus.ALL.ToString());

            //this.courseCategoryList = CourseCategoryManager.getAllActiveCourseCategory();
            this.courseCategoryList = CourseCategoryManager.findAllCourseCategory(CourseCategory.CourseCategoryStatus.ACTIVE);

            for (int i = 0; i < this.courseCategoryList.Count; i++)
            {
                this.ComboBox_CourseCategory.Items.Add(this.courseCategoryList[i].Name);
            }
        }

        public void reset()
        {
            this.courseList.Clear();

            this.RadioButton_Show_AllCourse.Checked = true;          
            this.RadioButton_Search_CourseCategory.Checked = false;

            if (this.courseCategoryList.Count == 0)
            {
                this.reload();
            }

            if (this.ComboBox_CourseCategory.Items.Count > 0)
            {
                this.ComboBox_CourseCategory.SelectedIndex = 0;
            }

            this.TextBox_CourseName_ForSearch.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }

            if (this.ComboBox_NumberPerPage.Items.Count > 0)
            {
                this.ComboBox_NumberPerPage.SelectedIndex = 0;
            }

            this.TextBox_PageNumber.Text = "1";

            this.refreshDataGridView_CourseInfo();
        }        

        private void keyPressed(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyData == Keys.Enter)
            {
                this.TextBox_PageNumber.Text = "1";
                this.search();
            }
        }

        private void refreshDataGridView_CourseInfo()
        {
            this.DataGridView_CourseInfo.Rows.Clear();

            for (int i = 0; i < this.courseList.Count; i++)
            {
                int n = this.DataGridView_CourseInfo.Rows.Add();
                this.DataGridView_CourseInfo.Rows[n].Cells["CourseId"].Value = this.courseList[i].Id;
                this.DataGridView_CourseInfo.Rows[n].Cells["CourseName"].Value = this.courseList[i].Name;
                this.DataGridView_CourseInfo.Rows[n].Cells["CourseLevel"].Value = this.courseList[i].Level;
                this.DataGridView_CourseInfo.Rows[n].Cells["NumberOfClassroom"].Value = this.courseList[i].NumberOfClassroom;
                this.DataGridView_CourseInfo.Rows[n].Cells["CourseFee"].Value = this.courseList[i].Price;
                this.DataGridView_CourseInfo.Rows[n].Cells["ClassroomDuration"].Value = this.courseList[i].ClassroomDuration;
                this.DataGridView_CourseInfo.Rows[n].Cells["StudentPerClassroom"].Value = this.courseList[i].StudentPerClassroom;
                this.DataGridView_CourseInfo.Rows[n].Cells["Status"].Value = this.courseList[i].Status;

                if (this.courseList[i].Status != Course.CourseStatus.ACTIVE.ToString())
                {
                    //((DataGridViewImageCell)this.DataGridView_CourseInfo.Rows[n].Cells["DeleteButton"]).Value = new Bitmap(20, 16);
                    ((DataGridViewImageCell)this.DataGridView_CourseInfo.Rows[n].Cells["DeleteButton"]).Value = PianoForte.Properties.Resources.Check;
                }
            }

            this.DataGridView_CourseInfo.ClearSelection();
        }

        private void search()
        {
            if (MainForm.currentForm is CourseMainForm)
            {                
                List<Course> tempCourseList = new List<Course>();

                int numberPerPage = Convert.ToInt32(this.ComboBox_NumberPerPage.Text);
                int pageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text);
                int startIndex = (pageNumber - 1) * numberPerPage;

                if (this.RadioButton_Show_AllCourse.Checked)
                {
                    this.courseList = CourseManager.findAllCourse(startIndex, numberPerPage);
                    tempCourseList = CourseManager.findAllCourse(startIndex + numberPerPage, numberPerPage);
                }
                else if (this.RadioButton_Search_CourseCategory.Checked)
                {
                    int selectedIndex = this.ComboBox_CourseCategory.SelectedIndex;
                    if (selectedIndex == 0)
                    {
                        string tempCourseName = this.TextBox_CourseName_ForSearch.Text;
                        //string status = this.ComboBox_Status.Text;
                        Course.CourseStatus status = (Course.CourseStatus)this.ComboBox_Status.SelectedIndex;

                        if ((tempCourseName == "") && (status == Course.CourseStatus.ALL))
                        {
                            this.courseList = CourseManager.findAllCourse(startIndex, numberPerPage);
                            tempCourseList = CourseManager.findAllCourse(startIndex + numberPerPage, numberPerPage);
                        }
                        else if ((tempCourseName != "") && (status == Course.CourseStatus.ALL))
                        {
                            this.courseList = CourseManager.findAllCourseByCourseName(tempCourseName, startIndex, numberPerPage);
                            tempCourseList = CourseManager.findAllCourseByCourseName(tempCourseName, startIndex + numberPerPage, numberPerPage);
                        }
                        else if ((tempCourseName == "") && (status != Course.CourseStatus.ALL))
                        {
                            this.courseList = CourseManager.findAllCourse(status, startIndex, numberPerPage);
                            tempCourseList = CourseManager.findAllCourse(status, startIndex + numberPerPage, numberPerPage);
                        }
                        else if ((tempCourseName != "") && (status != Course.CourseStatus.ALL))
                        {
                            this.courseList = CourseManager.findAllCourseByCourseName(tempCourseName, status, startIndex, numberPerPage);
                            tempCourseList = CourseManager.findAllCourseByCourseName(tempCourseName, status, startIndex + numberPerPage, numberPerPage);
                        }
                    }
                    else if (selectedIndex > 0)
                    {
                        int courseCategoryId = courseCategoryList[selectedIndex - 1].Id;
                        string tempCourseName = this.TextBox_CourseName_ForSearch.Text;
                        //string status = this.ComboBox_Status.Text;
                        Course.CourseStatus status = (Course.CourseStatus)this.ComboBox_Status.SelectedIndex;

                        if ((tempCourseName == "") && (status == Course.CourseStatus.ALL))
                        {
                            this.courseList = CourseManager.findAllCourseByCourseCategoryId(courseCategoryId, startIndex, numberPerPage);
                            tempCourseList = CourseManager.findAllCourseByCourseCategoryId(courseCategoryId, startIndex + numberPerPage, numberPerPage);
                        }
                        else if ((tempCourseName != "") && (status == Course.CourseStatus.ALL))
                        {
                            this.courseList = CourseManager.findAllCourseByCourseCategoryIdAndCourseName(courseCategoryId, tempCourseName, startIndex, numberPerPage);
                            tempCourseList = CourseManager.findAllCourseByCourseCategoryIdAndCourseName(courseCategoryId, tempCourseName, startIndex + numberPerPage, numberPerPage);
                        }
                        else if ((tempCourseName == "") && (status != Course.CourseStatus.ALL))
                        {
                            this.courseList = CourseManager.findAllCourseByCourseCategoryId(courseCategoryId, status, startIndex, numberPerPage);
                            tempCourseList = CourseManager.findAllCourseByCourseCategoryId(courseCategoryId, status, startIndex + numberPerPage, numberPerPage);
                        }
                        else if ((tempCourseName != "") && (status != Course.CourseStatus.ALL))
                        {
                            this.courseList = CourseManager.findAllCourseByCourseCategoryIdAndCourseName(courseCategoryId, tempCourseName, status, startIndex, numberPerPage);
                            tempCourseList = CourseManager.findAllCourseByCourseCategoryIdAndCourseName(courseCategoryId, tempCourseName, status, startIndex + numberPerPage, numberPerPage);
                        }
                    }
                }

                if (this.courseList.Count == 0)
                {
                    MessageBox.Show(DatabaseConstant.DATA_NOT_FOUND);
                }
                else if (this.courseList.Count < numberPerPage)
                {
                    this.Button_NextPage.Enabled = false;
                }
                else if (this.courseList.Count == numberPerPage)
                {
                    this.refreshButton_NextPage(tempCourseList);
                }

                this.refreshDataGridView_CourseInfo();
            }            
        }

        private void refreshButton_NextPage(List<Course> courseList)
        {
            if (courseList.Count > 0)
            {
                this.Button_NextPage.Enabled = true;
            }
            else
            {
                this.Button_NextPage.Enabled = false;
            }
        }        

        private void RadioButton_Show_AllCourse_CheckedChanged(object sender, EventArgs e)
        {
            this.ComboBox_CourseCategory.Enabled = false;
            this.TextBox_CourseName_ForSearch.Enabled = false;
            this.ComboBox_Status.Enabled = false;
        }

        private void RadioButton_Show_AllCourse_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void RadioButton_Search_CourseCategory_CheckedChanged(object sender, EventArgs e)
        {
            this.ComboBox_CourseCategory.Enabled = true;
            this.TextBox_CourseName_ForSearch.Enabled = true;
            this.ComboBox_Status.Enabled = true;
        }

        private void RadioButton_Search_CourseCategory_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void ComboBox_CourseCategory_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_CourseName_ForSearch_KeyDown(object sender, KeyEventArgs e)
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

        private void DataGridView_CourseInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Do Nothing
        }

        private void DataGridView_CourseInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 8:
                        {
                            string courseName = this.courseList[e.RowIndex].Name;

                            List<Course> tempCourseList = new List<Course>();
                            tempCourseList = CourseManager.findAllCourseByCourseName(courseName);
                            if (tempCourseList.Count > 0)
                            {
                                CourseDetailForm courseDetailForm = new CourseDetailForm();
                                courseDetailForm.showFormDialog(tempCourseList, false);
                                this.Cursor = Cursors.Arrow;
                            }
                        }
                        break;
                    case 9:
                        {
                            string courseName = this.courseList[e.RowIndex].Name;

                            List<Course> tempCourseList = new List<Course>();
                            tempCourseList = CourseManager.findAllCourseByCourseName(courseName);
                            if (tempCourseList.Count > 0)
                            {
                                CourseDetailForm courseDetailForm = new CourseDetailForm();
                                courseDetailForm.showFormDialog(tempCourseList, true);
                                this.Cursor = Cursors.Arrow;
                            }
                        }
                        break;
                    case 10:
                        {
                            string text = "";
                            string tempStatus = this.courseList[e.RowIndex].Status;

                            if (this.courseList[e.RowIndex].Status == Course.CourseStatus.ACTIVE.ToString())
                            {
                                text = "คุณต้องการยกเลิกวิชา " + CourseManager.getDisplayCourseText(this.courseList[e.RowIndex]) + " ใช่หรือไม่?";
                                this.courseList[e.RowIndex].Status = Course.CourseStatus.INACTIVE.ToString();
                            }
                            else if (this.courseList[e.RowIndex].Status == Course.CourseStatus.INACTIVE.ToString())
                            {
                                text = "คุณต้องการเริ่มวิชา " + CourseManager.getDisplayCourseText(this.courseList[e.RowIndex]) + " ใช่หรือไม่?";
                                this.courseList[e.RowIndex].Status = Course.CourseStatus.ACTIVE.ToString();
                            }

                            if (ConfirmDialogBox.show(text))
                            {
                                if (CourseManager.updateCourse(this.courseList[e.RowIndex]))
                                {
                                    //MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_SUCCESS);
                                    this.refreshDataGridView_CourseInfo();
                                }
                                else
                                {
                                    this.courseList[e.RowIndex].Status = tempStatus;
                                    MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_FAIL);
                                    this.refreshDataGridView_CourseInfo();
                                }
                            }                             
                        }
                        break;
                }
            }

            this.Cursor = Cursors.Arrow;
        }

        private void DataGridView_CourseInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //To Do
        }

        private void DataGridView_CourseInfo_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 8:
                        {
                            this.Cursor = Cursors.Hand;
                            this.DataGridView_CourseInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "View";
                        }                        
                        break;
                    case 9:
                        {
                            this.Cursor = Cursors.Hand;
                            this.DataGridView_CourseInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Edit";
                        }  
                        break;
                    case 10:
                        {
                            if (this.courseList[e.RowIndex].Status == Course.CourseStatus.ACTIVE.ToString())
                            {
                                this.Cursor = Cursors.Hand;
                                this.DataGridView_CourseInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Disable";
                            }
                            else if (this.courseList[e.RowIndex].Status == Course.CourseStatus.INACTIVE.ToString())
                            {
                                this.Cursor = Cursors.Hand;
                                this.DataGridView_CourseInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Enable";
                            }
                        }  
                        break;
                }
            }
        }

        private void DataGridView_CourseInfo_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
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
            AddCourseForm addCourseForm = new AddCourseForm();
            List<Course> newCourseList = addCourseForm.showFormDialog();
            for (int i = 0; i < newCourseList.Count; i++)
            {
                if (!CourseManager.insertCourse(newCourseList[i]))
                {
                    LogManager.writeLog("Insert " + newCourseList[i].Name + " failed");
                }
            }
        }        
    }
}
