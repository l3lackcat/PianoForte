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
    public partial class AddCourseForm : Form
    {
        private List<CourseCategory> courseCategoryList;
        private List<Course> courseList;

        public AddCourseForm()
        {
            InitializeComponent();
        }

        public List<Course> showFormDialog()
        {
            this.courseCategoryList = new List<CourseCategory>();
            this.courseList = new List<Course>();

            this.reload();

            if (this.ComboBox_CourseCategory.Items.Count > 0)
            {
                this.ComboBox_CourseCategory.SelectedIndex = 0;
            }

            this.DataGridView_CourseLevel.AutoGenerateColumns = false;
            this.Button_OK.Enabled = false;

            this.ShowDialog(); 

            return this.courseList;
        }

        public void reload()
        {
            this.ComboBox_CourseCategory.Items.Clear();

            //this.courseCategoryList = CourseCategoryManager.getAllActiveCourseCategory();
            this.courseCategoryList = CourseCategoryManager.findAllCourseCategory(CourseCategory.CourseCategoryStatus.ACTIVE);

            for (int i = 0; i < this.courseCategoryList.Count; i++)
            {
                this.ComboBox_CourseCategory.Items.Add(this.courseCategoryList[i].Name);
            }
        }

        private void refreshDataGridView_CourseLevel()
        {
            this.DataGridView_CourseLevel.DataSource = null;

            if (this.courseList.Count > 0)
            {
                this.DataGridView_CourseLevel.DataSource = this.courseList;
            }

            this.DataGridView_CourseLevel.ClearSelection();
        }

        private void refreshButton_OK()
        {
            string tempCourseName = this.TextBox_CourseName.Text;

            if ((tempCourseName != "") && (this.courseList.Count > 0))
            {
                this.Button_OK.Enabled = true;
            }
            else
            {
                this.Button_OK.Enabled = false;
            }
        }

        public bool isDuplicateCourseLevel(string courseLevel, int exceptionIndex)
        {
            bool returnFlag = false;

            for (int i = 0; i < this.courseList.Count; i++)
            {
                if ((this.courseList[i].Level == courseLevel) && (i != exceptionIndex))
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }

        private void Button_Add_New_CourseCategory_Click(object sender, EventArgs e)
        {
            string courseCategoryName = InputDialogBox.show(PianoForte.Constant.Constant.NOT_FILL_COURSE_CATEGORY_NAME);

            if (courseCategoryName != "")
            {
                CourseCategory tempCourseCategory = CourseCategoryManager.findCourseCategory(courseCategoryName);
                if (tempCourseCategory == null)
                {
                    CourseCategory courseCategory = new CourseCategory();
                    courseCategory.Name = courseCategoryName;
                    courseCategory.Status = CourseCategory.CourseCategoryStatus.ACTIVE.ToString();

                    if (CourseCategoryManager.insertCourseCategory(courseCategory))
                    {
                        //MessageBox.Show(DatabaseConstant.INSERT_DATA_SUCCESS);
                        this.reload();
                        MainForm.courseMainForm.reload();
                    }
                    else
                    {
                        MessageBox.Show(DatabaseConstant.INSERT_DATA_FAIL);
                    }
                }
                else
                {
                    MessageBox.Show("ชื่อได้ถูกใช้ไปแล้ว");
                }
            }
        }

        private void TextBox_CourseName_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_OK();
        }

        private void Button_AddNewLevel_Click(object sender, EventArgs e)
        {
            AddCourseLevelForm addCourseLevelForm = new AddCourseLevelForm();
            Course newLevel = addCourseLevelForm.showFormDialog(this);
            if (newLevel != null)
            {
                this.courseList.Add(newLevel);
                this.refreshDataGridView_CourseLevel();
            }

            this.refreshButton_OK();
        }

        private void DataGridView_CourseLevel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    EditCourseLevelForm editCourseLevelForm = new EditCourseLevelForm();
                    editCourseLevelForm.setup(this.courseList[e.RowIndex], e.RowIndex);
                    Course editedCourse = editCourseLevelForm.showFormDialog(this);
                    if (editedCourse != null)
                    {
                        this.courseList[e.RowIndex].Level = editedCourse.Level;
                        this.courseList[e.RowIndex].NumberOfClassroom = editedCourse.NumberOfClassroom;
                        this.courseList[e.RowIndex].Price = editedCourse.Price;
                        this.courseList[e.RowIndex].ClassroomDuration = editedCourse.ClassroomDuration;
                        this.courseList[e.RowIndex].StudentPerClassroom = editedCourse.StudentPerClassroom;
                        this.courseList[e.RowIndex].Status = editedCourse.Status;
                        this.refreshDataGridView_CourseLevel();
                    }
                }
                else if (e.ColumnIndex == 7)
                {
                    this.courseList.RemoveAt(e.RowIndex);
                    this.Cursor = Cursors.Arrow;
                    this.refreshDataGridView_CourseLevel();
                    this.refreshButton_OK();
                }
            }

            this.Cursor = Cursors.Arrow;
        }

        private void DataGridView_CourseLevel_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    this.Cursor = Cursors.Hand;
                    this.DataGridView_CourseLevel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Edit";
                }
                else if (e.ColumnIndex == 7)
                {
                    this.Cursor = Cursors.Hand;
                    this.DataGridView_CourseLevel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Delete";
                }
            }
        }

        private void DataGridView_CourseLevel_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }        

        private void Button_OK_Click(object sender, EventArgs e)
        {
            List<Course> tempCourseList = CourseManager.findAllCourseByCourseNameWithoutWildcard(this.TextBox_CourseName.Text);
            if (tempCourseList.Count == 0)
            {
                for (int i = 0; i < this.courseList.Count; i++)
                {
                    int courseCategoryId = this.courseCategoryList[this.ComboBox_CourseCategory.SelectedIndex].Id;
                    string courseName = this.TextBox_CourseName.Text;

                    this.courseList[i].Id = CourseManager.getNewCourseId(courseName, i + 1);
                    this.courseList[i].CourseCategoryId = courseCategoryId;
                    this.courseList[i].Name = courseName;
                    this.courseList[i].Type = Product.ProductType.COURSE.ToString();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("ชื่อวิชาได้ถูกใช้ไปแล้ว");
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
