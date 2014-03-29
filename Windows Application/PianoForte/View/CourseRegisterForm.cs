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
    public partial class CourseRegisterForm : Form, FormInterface
    {        
        private MainForm mainForm;
        private List<CourseCategory> courseCategoryList;
        private List<Course> courseList;
        private List<Course> originalCourseList;
        bool isEditmode;

        public CourseRegisterForm()
        {
            InitializeComponent();
        }

        private void CourseRegisterForm_Load(object sender, EventArgs e)
        {
            //Do Nothing
        }

        public void load(MainForm mainForm)
        {           
            this.mainForm = mainForm;            
            this.courseCategoryList = new List<CourseCategory>();
            this.courseList = new List<Course>();
            this.originalCourseList = new List<Course>();

            this.DataGridView_CourseLevel.AutoGenerateColumns = false;
        }

        public void reload()
        {
            this.ComboBox_CourseCategory.Items.Clear();

            this.courseCategoryList = CourseCategoryManager.getAllActiveCourseCategory();    
                       
            for (int i = 0; i < this.courseCategoryList.Count; i++)
            {
                this.ComboBox_CourseCategory.Items.Add(this.courseCategoryList[i].Name);
            }            
        }

        public void reset()
        {
            this.courseList.Clear();
            this.originalCourseList.Clear();

            if (this.courseCategoryList.Count == 0)
            {
                this.reload();
            }

            if (this.ComboBox_CourseCategory.Items.Count > 0)
            {
                this.ComboBox_CourseCategory.SelectedIndex = 0;
            }            

            this.TextBox_CourseName.Text = "";
            this.Button_OK.Enabled = false;
            this.Button_Edit.Visible = false;

            this.refreshDataGridView_CourseLevel();          
        }

        public void setup(List<Course> setupCourseList, bool isEditMode)
        {
            this.reset();

            this.isEditmode = isEditMode;

            this.GroupBox_Course.Enabled = isEditmode;
            this.Button_Edit.Visible = !isEditmode;

            if (setupCourseList.Count > 0)
            {                
                for (int i = 0; i < setupCourseList.Count; i++)
                {
                    Course tempCourse = new Course(setupCourseList[i]);
                    this.courseList.Add(tempCourse);

                    Course tempOriginalCourse = new Course(setupCourseList[i]);
                    this.originalCourseList.Add(tempOriginalCourse);
                }

                for (int i = 0; i < this.courseCategoryList.Count; i++)
                {
                    if (this.courseCategoryList[i].Id == this.courseList[0].CourseCategoryId)
                    {
                        this.ComboBox_CourseCategory.SelectedIndex = i;
                        break;
                    }
                }

                this.TextBox_CourseName.Text = this.courseList[0].Name;

                this.refreshDataGridView_CourseLevel();
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
            this.Button_EditLevel.Enabled = false;
            this.Button_CancelLevel.Enabled = false;
        }

        //private bool isDuplicateCourseName(string courseName)
        //{
        //    bool returnFlag = false;

        //    List<Course> tempCourseList = CourseManager.getAllCourse(this.TextBox_CourseName.Text);
        //    for (int i = 0; i < tempCourseList.Count; i++)
        //    {
        //        returnFlag = true;

        //        for (int j = 0; j < this.originalCourseList.Count; j++)
        //        {
        //            if (tempCourseList[i].Id == this.originalCourseList[j].Id)
        //            {
        //                returnFlag = false;
        //                break;
        //            }
        //        }

        //        if (returnFlag)
        //        {
        //            break;
        //        }
        //    }

        //    return returnFlag;
        //}

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

        private void refreshTextBox_CourseName()
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

        //private bool processInsertCourse(int courseCategoryId, string courseName)
        //{
        //    bool returnFlag = true;

        //    for (int i = 0; i < this.courseList.Count; i++)
        //    {
        //        bool isExist = false;

        //        for (int j = 0; j < this.originalCourseList.Count; j++)
        //        {                    
        //            if (this.courseList[i].Id == this.originalCourseList[j].Id)
        //            {
        //                isExist = true;
        //                break;
        //            }
        //        }

        //        if (!isExist)
        //        {
        //            this.courseList[i].Id = CourseManager.getNewCourseId(courseCategoryId, courseName);
        //            this.courseList[i].CourseCategoryId = courseCategoryId;
        //            this.courseList[i].Name = courseName;
        //            this.courseList[i].Status = Course.CourseStatus.ACTIVE.ToString();

        //            returnFlag = CourseManager.addCourse(this.courseList[i]);
        //        }
        //    }

        //    return returnFlag;
        //}

        //private bool processUpdateCourse(int courseCategoryId, string courseName)
        //{
        //    bool returnFlag = true;

        //    for (int i = 0; i < this.courseList.Count; i++)
        //    {                
        //        if (courseCategoryId != this.courseList[i].CourseCategoryId)
        //        {
        //            int tempCourseId = this.courseList[i].Id;
                    
        //            CourseManager.deleteCourse(this.courseList[i].Id);
        //            this.courseList[i].Id = CourseManager.getNewCourseId(courseCategoryId, courseName, i + 1);
        //            this.courseList[i].CourseCategoryId = courseCategoryId;
        //            this.courseList[i].Name = courseName;

        //            returnFlag = true;
        //            for (int j = 0; j < this.originalCourseList.Count; j++)
        //            {
        //                if (this.courseList[i].Id == this.originalCourseList[j].Id)
        //                {
        //                    returnFlag = CourseManager.addCourse(this.courseList[i]);
        //                    break;
        //                }
        //            }

        //            if (returnFlag)
        //            {
        //                List<Enrollment> enrollmentList = EnrollmentManager.getAllEnrollmentByCourseId(tempCourseId);
        //                if (enrollmentList.Count > 0)
        //                {
        //                    for (int j = 0; j < enrollmentList.Count; j++)
        //                    {
        //                        enrollmentList[j].CourseId = this.courseList[i].Id;
        //                        EnrollmentManager.updateEnrollment(enrollmentList[j]);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //        else
        //        {
        //            this.courseList[i].CourseCategoryId = courseCategoryId;
        //            this.courseList[i].Name = courseName;

        //            returnFlag = true;
        //            for (int j = 0; j < this.originalCourseList.Count; j++)
        //            {
        //                if (this.courseList[i].Id == this.originalCourseList[j].Id)
        //                {
        //                    returnFlag = CourseManager.updateCourse(this.courseList[i]);
        //                    break;
        //                }
        //            }

        //            if (!returnFlag)
        //            {
        //                break;
        //            }
        //        }                                               
        //    }

        //    return returnFlag;
        //}

        private void Button_Add_New_CourseCategory_Click(object sender, EventArgs e)
        {            
            string courseCategoryName = InputDialogBox.show(PianoForte.Constant.Constant.NOT_FILL_COURSE_CATEGORY_NAME);

            if (courseCategoryName != "")
            {
                CourseCategory courseCategory = new CourseCategory();
                courseCategory.Name = courseCategoryName;
                courseCategory.Status = CourseCategory.CourseCategoryStatus.ACTIVE.ToString();

                if (CourseCategoryManager.addCourseCategory(courseCategory))
                {
                    MessageBox.Show(DatabaseConstant.INSERT_DATA_SUCCESS);
                    this.reload();
                    MainForm.courseMainForm.reload();
                }
                else
                {
                    MessageBox.Show(DatabaseConstant.INSERT_DATA_FAIL);
                }
            }
        }

        private void Button_AddNewLevel_Click(object sender, EventArgs e)
        {
            AddCourseLevelForm addCourseLevelForm = new AddCourseLevelForm();
            Course newCourse = addCourseLevelForm.showFormDialog(this);
            if (newCourse != null)
            {
                this.courseList.Add(newCourse);
                this.refreshDataGridView_CourseLevel();
            }

            this.refreshTextBox_CourseName();
        }

        private void Button_EditLevel_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.DataGridView_CourseLevel.CurrentRow.Index;

            EditCourseLevelForm editCourseLevelForm = new EditCourseLevelForm();
            editCourseLevelForm.setup(this.courseList[selectedIndex], selectedIndex);
            Course editedCourse = editCourseLevelForm.showFormDialog(this);
            if (editedCourse != null)
            {
                this.courseList[selectedIndex].Level = editedCourse.Level;
                this.courseList[selectedIndex].Price = editedCourse.Price;
                this.courseList[selectedIndex].ClassroomDuration = editedCourse.ClassroomDuration;
                this.courseList[selectedIndex].StudentPerClassroom = editedCourse.StudentPerClassroom;
                this.courseList[selectedIndex].Status = editedCourse.Status;
                this.refreshDataGridView_CourseLevel();
            }
        }

        private void Button_CancelLevel_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.DataGridView_CourseLevel.CurrentRow.Index;

            if (ConfirmDialogBox.show(PianoForte.Constant.Constant.CONFIRM_DELETE_COURSE_LEVEL))
            {
                this.courseList[selectedIndex].Status = Course.CourseStatus.INACTIVE.ToString();
                this.refreshDataGridView_CourseLevel();
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {


            if (this.TextBox_CourseName.Text != "")
            {
                if (CourseManager.getAllCourse(this.TextBox_CourseName.Text).Count == 0)
                {
                    if (this.courseList.Count > 0)
                    {
                        for (int i = 0; i < this.courseList.Count; i++)
                        {
                            int courseCategoryId = this.courseCategoryList[this.ComboBox_CourseCategory.SelectedIndex].Id;
                            string courseName = this.TextBox_CourseName.Text;
                            
                            this.courseList[i].Id = CourseManager.getNewCourseId(courseCategoryId, courseName, i+1);
                            this.courseList[i].CourseCategoryId = courseCategoryId;
                            this.courseList[i].Name = courseName;

                            if (!CourseManager.addCourse(this.courseList[i]))
                            {
                                LogManager.writeLog("Insert " + courseList[i].Name + " failed");
                            }
                        }
                        MessageBox.Show(DatabaseConstant.INSERT_DATA_SUCCESS);
                        this.mainForm.switchForm(MainForm.courseMainForm);
                    }
                    else
                    {
                        MessageBox.Show(Constant.Constant.NOT_FILL_COURSE_LEVEL);
                    }                    
                }
                else
                {
                    MessageBox.Show(Constant.Constant.DUPLICATE_COURSE_NAME);
                }                  
            }
            else
            {
                MessageBox.Show(Constant.Constant.NOT_FILL_COURSE_NAME);
            }            
        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {
            this.GroupBox_Course.Enabled = true;
            this.DataGridView_CourseLevel.ClearSelection();
            this.Button_Edit.Visible = false;
        } 

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.courseList.Clear();

            for (int i = 0; i < this.originalCourseList.Count; i++)
            {
                Course tempCourse = new Course(this.originalCourseList[i]);
                this.courseList.Add(tempCourse);
            }

            this.refreshDataGridView_CourseLevel();
            this.GroupBox_Course.Enabled = false;
            this.Button_Edit.Visible = true;
        }

        private void Button_Submit_CourseLevel_Click(object sender, EventArgs e)
        {
                      
        }

        private void DataGridView_CourseLevel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = this.DataGridView_CourseLevel.CurrentRow.Index;

            this.Button_EditLevel.Enabled = true;

            if (this.courseList[selectedIndex].Status != Course.CourseStatus.INACTIVE.ToString())
            {
                this.Button_CancelLevel.Enabled = true;
            }
            else
            {
                this.Button_CancelLevel.Enabled = false;
            }                       
        }

        private void TextBox_CourseName_TextChanged(object sender, EventArgs e)
        {
            this.refreshTextBox_CourseName();
        }               
    }
}
