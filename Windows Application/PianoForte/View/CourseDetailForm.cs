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
    public partial class CourseDetailForm : Form
    {
        private List<CourseCategory> courseCategoryList;
        private List<Course> originalCourseList;
        private List<Course> editableCourseList;

        public CourseDetailForm()
        {
            InitializeComponent();
        }

        public void showFormDialog(List<Course> courseList, bool isEditMode)
        {
            this.courseCategoryList = new List<CourseCategory>();
            this.originalCourseList = new List<Course>();
            this.editableCourseList = new List<Course>();

            this.DataGridView_CourseLevel.AutoGenerateColumns = false;

            this.refreshComboBox_CourseCategory();
            this.refreshOriginalCourseList(courseList);
            this.refreshEditableCourseList(courseList);
            this.setup(isEditMode);           

            this.ShowDialog();
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

        private void setup(bool isEditMode)
        {
            if (this.editableCourseList.Count > 0)
            {
                this.ComboBox_CourseCategory.SelectedIndex = this.editableCourseList[0].CourseCategoryId - 1;
            }

            this.TextBox_CourseName.Text = this.editableCourseList[0].Name;
            this.refreshDataGridView_CourseLevel();

            this.ComboBox_CourseCategory.Enabled = isEditMode;
            this.Button_Add_New_CourseCategory.Visible = isEditMode;
            this.TextBox_CourseName.Enabled = isEditMode;
            this.Button_AddNewLevel.Visible = isEditMode;
            this.DataGridView_CourseLevel.Enabled = isEditMode;
            this.Button_Edit.Visible = !isEditMode;
            this.Button_OK.Visible = isEditMode;
            this.Button_Cancel.Visible = isEditMode; 
        }

        private void refreshComboBox_CourseCategory()
        {
            this.ComboBox_CourseCategory.Items.Clear();

            //this.courseCategoryList = CourseCategoryManager.getAllActiveCourseCategory();
            this.courseCategoryList = CourseCategoryManager.findAllCourseCategory(CourseCategory.CourseCategoryStatus.ACTIVE);
            for (int i = 0; i < this.courseCategoryList.Count; i++)
            {
                this.ComboBox_CourseCategory.Items.Add(this.courseCategoryList[i].Name);
            }
        }

        private void refreshOriginalCourseList(List<Course> courseList)
        {
            this.originalCourseList.Clear();

            for (int i = 0; i < courseList.Count; i++)
            {
                this.originalCourseList.Add(new Course(courseList[i]));
            }
        }

        private void refreshEditableCourseList(List<Course> courseList)
        {
            this.editableCourseList.Clear();

            for (int i = 0; i < courseList.Count; i++)
            {
                this.editableCourseList.Add(new Course(courseList[i]));
            }
        }

        private void refreshDataGridView_CourseLevel()
        {
            this.DataGridView_CourseLevel.Rows.Clear();

            for (int i = 0; i < this.editableCourseList.Count; i++)
            {
                int n = this.DataGridView_CourseLevel.Rows.Add();
                this.DataGridView_CourseLevel.Rows[n].Cells["CourseLevel"].Value = this.editableCourseList[i].Level;
                this.DataGridView_CourseLevel.Rows[n].Cells["NumberOfClassroom"].Value = this.editableCourseList[i].NumberOfClassroom;
                this.DataGridView_CourseLevel.Rows[n].Cells["CourseFee"].Value = this.editableCourseList[i].Price;
                this.DataGridView_CourseLevel.Rows[n].Cells["ClassroomDuration"].Value = this.editableCourseList[i].ClassroomDuration;
                this.DataGridView_CourseLevel.Rows[n].Cells["StudentPerClassroom"].Value = this.editableCourseList[i].StudentPerClassroom;
                this.DataGridView_CourseLevel.Rows[n].Cells["Status"].Value = this.editableCourseList[i].Status;

                if (this.editableCourseList[i].Status == Course.CourseStatus.INACTIVE.ToString())
                {
                    ((DataGridViewImageCell)this.DataGridView_CourseLevel.Rows[n].Cells["DeleteButton"]).Value = PianoForte.Properties.Resources.Check;
                }
            } 

            this.DataGridView_CourseLevel.ClearSelection();
        }

        private void refreshButton_OK()
        {
            string tempCourseName = this.TextBox_CourseName.Text;

            if ((tempCourseName != "") && (this.editableCourseList.Count > 0))
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

            for (int i = 0; i < this.editableCourseList.Count; i++)
            {
                if ((this.editableCourseList[i].Level == courseLevel) && (i != exceptionIndex))
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
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
                this.editableCourseList.Add(newLevel);
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
                    editCourseLevelForm.setup(this.editableCourseList[e.RowIndex], e.RowIndex);
                    Course editedCourse = editCourseLevelForm.showFormDialog(this);
                    if (editedCourse != null)
                    {
                        this.editableCourseList[e.RowIndex].Level = editedCourse.Level;
                        this.editableCourseList[e.RowIndex].NumberOfClassroom = editedCourse.NumberOfClassroom;
                        this.editableCourseList[e.RowIndex].Price = editedCourse.Price;
                        this.editableCourseList[e.RowIndex].ClassroomDuration = editedCourse.ClassroomDuration;
                        this.editableCourseList[e.RowIndex].StudentPerClassroom = editedCourse.StudentPerClassroom;
                        this.editableCourseList[e.RowIndex].Status = editedCourse.Status;
                        this.refreshDataGridView_CourseLevel();
                    }
                }
                else if (e.ColumnIndex == 7)
                {
                    if (this.editableCourseList[e.RowIndex].Status == Course.CourseStatus.ACTIVE.ToString())
                    {
                        if (this.editableCourseList[e.RowIndex].Id == 0)
                        {
                            this.editableCourseList.RemoveAt(e.RowIndex);
                            this.Cursor = Cursors.Arrow;
                            this.refreshButton_OK();
                        }
                        else
                        {
                            this.editableCourseList[e.RowIndex].Status = Course.CourseStatus.INACTIVE.ToString();
                        }                        
                    }
                    else if (this.editableCourseList[e.RowIndex].Status == Course.CourseStatus.INACTIVE.ToString())
                    {
                        this.editableCourseList[e.RowIndex].Status = Course.CourseStatus.ACTIVE.ToString();
                    }

                    this.refreshDataGridView_CourseLevel();
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
                    if (this.editableCourseList[e.RowIndex].Status == Course.CourseStatus.ACTIVE.ToString())
                    {
                        this.Cursor = Cursors.Hand;

                        if (this.editableCourseList[e.RowIndex].Id == 0)
                        {
                            this.DataGridView_CourseLevel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Delete";
                        }
                        else
                        {
                            this.DataGridView_CourseLevel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Disable";
                        }                        
                    }
                    else if (this.editableCourseList[e.RowIndex].Status == Course.CourseStatus.INACTIVE.ToString())
                    {
                        this.Cursor = Cursors.Hand;
                        this.DataGridView_CourseLevel.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Enable";
                    }
                }
            }
        }

        private void DataGridView_CourseLevel_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            string text = "คุณต้องการแก้ไขข้อมูลใช่หรือไม่?";
            if (ConfirmDialogBox.show(text))
            {
                bool isDuplicateCourseName = true;

                List<Course> tempCourseList = CourseManager.findAllCourseByCourseNameWithoutWildcard(this.TextBox_CourseName.Text);
                if (tempCourseList.Count == 0)
                {
                    isDuplicateCourseName = false;
                }
                else if (tempCourseList.Count > 0)
                {
                    if (this.editableCourseList[0].Name == this.TextBox_CourseName.Text)
                    {
                        isDuplicateCourseName = false;
                    }
                    else
                    {
                        isDuplicateCourseName = true;
                    }
                }

                if (!isDuplicateCourseName)
                {
                    bool isEditComplete = false;
                    //int courseCategoryId = this.ComboBox_CourseCategory.SelectedIndex + 1;
                    int courseCategoryId = this.courseCategoryList[this.ComboBox_CourseCategory.SelectedIndex].Id;
                    string courseName = this.TextBox_CourseName.Text;

                    for (int i = 0; i < this.editableCourseList.Count; i++)
                    {
                        Course tempCourse = this.editableCourseList[i];
                        tempCourse.CourseCategoryId = courseCategoryId;
                        tempCourse.Name = courseName;
                        tempCourse.Type = Product.ProductType.COURSE.ToString();

                        if (tempCourse.Id == 0)
                        {
                            tempCourse.Id = CourseManager.getNewCourseId(courseName, i + 1);

                            if (CourseManager.insertCourse(tempCourse))
                            {
                                isEditComplete = true;
                            }
                            else
                            {
                                isEditComplete = false;
                                break;
                            }
                        }
                        else
                        {
                            double oldCourseFee = -1;

                            foreach (Course c in tempCourseList)
                            {
                                if (c.Id == tempCourse.Id)
                                {
                                    oldCourseFee = c.Price;
                                    break;
                                }                                
                            }

                            if (oldCourseFee == -1)
                            {
                                Course course = CourseManager.findCourse(tempCourse.Id);
                                if (course != null)
                                {
                                    oldCourseFee = course.Price;
                                }
                            }

                            if (CourseManager.updateCourse(tempCourse))
                            {
                                if (oldCourseFee == tempCourse.Price)
                                {
                                    isEditComplete = true;
                                }
                                else
                                {
                                    ProductPriceHistory productPriceHistory = new ProductPriceHistory();
                                    productPriceHistory.ProductId = tempCourse.Id;
                                    productPriceHistory.Price = oldCourseFee;
                                    productPriceHistory.LastUsed = DateTime.Now;

                                    if (ProductManager.addProductPriceHistory(productPriceHistory))
                                    {                                        
                                        isEditComplete = true;
                                    }
                                    else
                                    {
                                        isEditComplete = false;
                                    }
                                }                                
                            }
                            else
                            {
                                isEditComplete = false;
                                break;
                            }
                        }
                    }

                    if (isEditComplete)
                    {
                        this.refreshOriginalCourseList(this.editableCourseList);

                        //MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_SUCCESS);

                        this.setup(false);
                    }
                    else
                    {
                        MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_FAIL);
                    }
                }
                else
                {
                    MessageBox.Show("ชื่อวิชาได้ถูกใช้ไปแล้ว");
                    this.TextBox_CourseName.Text = this.originalCourseList[0].Name;
                }
            }            
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.refreshEditableCourseList(this.originalCourseList);
            this.setup(false);
        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {
            this.setup(true);
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
    }
}
