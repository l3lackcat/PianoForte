using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.View
{
    public partial class ClassroomDetailForm : Form
    {
        bool isEditMode;
        private List<string> teacherNameList;
        private ClassroomDetail classroomDetail;
        private Course course;
        private List<int> teacherIdList;

        public ClassroomDetailForm()
        {
            InitializeComponent();
        }

        public void showFormDialog(ClassroomDetail classroomDetail, string courseName, string courseLevel)
        {
            this.teacherNameList = new List<string>();
            this.classroomDetail = new ClassroomDetail(classroomDetail);
            this.teacherIdList = new List<int>();

            this.course = CourseManager.findCourseByNameAndLevel(courseName, courseLevel);

            this.enableEditClassroomDetailDate(false);
            this.enableEditClassroomDetailStatus(false);
            this.initComboBox_TeacherName();
            this.setUpComponent(classroomDetail);
            //this.refreshButton_Edit_ClassroomDetail_Status();            
            this.ShowDialog(); 
        }

        private void setUpComponent(ClassroomDetail classroomDetail)
        {           
            this.TextBox_ClassroomNo.Text = this.classroomDetail.ClassroomNo.ToString();
            this.TextBox_ClassroomType.Text = this.classroomDetail.DisplayType;

            if (this.classroomDetail.Type == ClassroomDetail.ClassroomType.EXTRA.ToString())
            {
                ClassroomDetail tempClassroomDetail = ClassroomDetailManager.findClassroomDetail(this.classroomDetail.RegularClassroomDetailId);
                if (tempClassroomDetail != null)
                {
                    this.TextBox_MakeUpForClassroomNo.Text = tempClassroomDetail.ClassroomNo.ToString();
                    this.label5.Visible = true;
                    this.TextBox_MakeUpForClassroomNo.Visible = true;
                }
            }
            else
            {
                this.label5.Visible = false;
                this.TextBox_MakeUpForClassroomNo.Visible = false;
            }

            this.DateTimePicker_ClassroomDate.Value = this.classroomDetail.ClassroomDate;
            this.TextBox_CourseName.Text = this.course.Name;
            this.TextBox_CourseLevel.Text = this.course.Level;

            Teacher tempTeacher = TeacherManager.findTeacher(this.classroomDetail.TeacherId);
            if (tempTeacher != null)
            {
                this.TextBox_TeacherName.Text = "อ." + tempTeacher.Firstname + " (ครู" + tempTeacher.Nickname + ")";
            }
            
            string classroomDetailStatus = this.classroomDetail.CurrentStatus;

            if (classroomDetailStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
            {
                this.RadioButton_Waiting.Checked = true;
                this.showPostponeDateAndTime(false);
                this.ComboBox_TeacherName.Visible = false;
            }
            else if (classroomDetailStatus == ClassroomDetail.ClassroomStatus.CHECKED_IN.ToString())
            {
                this.RadioButton_CheckedIn.Checked = true;
                this.showPostponeDateAndTime(false);
                this.ComboBox_TeacherName.Visible = false;
            }
            else if (classroomDetailStatus == ClassroomDetail.ClassroomStatus.POSTPONE1.ToString())
            {
                this.RadioButton_Postpone.Checked = true;

                //ClassroomDetail tempPostponedClassroomDetail = ClassroomDetailManager.getNonNormalClassroomDetail(this.classroomDetail.ClassroomDetailId);
                ClassroomDetail tempPostponedClassroomDetail = ClassroomDetailManager.findClassroomDetailByRegularClassroomDetail(this.classroomDetail.ClassroomDetailId);
                if (tempPostponedClassroomDetail != null)
                {
                    this.DateTimePicker_PostponedTo.Value = tempPostponedClassroomDetail.ClassroomDate;
                    this.ComboBox_PostponeTo_Time.Text = tempPostponedClassroomDetail.ClassroomTime;
                    this.showPostponeDateAndTime(true);
                    this.ComboBox_TeacherName.Visible = false;
                }
            }
            else if (classroomDetailStatus == ClassroomDetail.ClassroomStatus.POSTPONE2.ToString())
            {
                this.RadioButton_Postpone.Checked = true;

                //ClassroomDetail tempPostponedClassroomDetail = ClassroomDetailManager.getNonNormalClassroomDetail(this.classroomDetail.ClassroomDetailId);
                ClassroomDetail tempPostponedClassroomDetail = ClassroomDetailManager.findClassroomDetailByRegularClassroomDetail(this.classroomDetail.ClassroomDetailId);
                if (tempPostponedClassroomDetail != null)
                {
                    this.DateTimePicker_PostponedTo.Value = tempPostponedClassroomDetail.ClassroomDate;
                    this.ComboBox_PostponeTo_Time.Text = tempPostponedClassroomDetail.ClassroomTime;
                    this.showPostponeDateAndTime(true);
                    this.ComboBox_TeacherName.Visible = false;
                }
            }
            else if (classroomDetailStatus == ClassroomDetail.ClassroomStatus.STUDENT_ABSENT.ToString())
            {
                this.RadioButton_Student_Absent.Checked = true;
                this.showPostponeDateAndTime(false);
                this.ComboBox_TeacherName.Visible = false;
            }
            else if (classroomDetailStatus == ClassroomDetail.ClassroomStatus.TEACHER_ABSENT.ToString())
            {
                this.RadioButton_Teacher_Absent.Checked = true;

                //ClassroomDetail tempExtraClassroomDetail = ClassroomDetailManager.getNonNormalClassroomDetail(this.classroomDetail.ClassroomDetailId);
                ClassroomDetail tempExtraClassroomDetail = ClassroomDetailManager.findClassroomDetailByRegularClassroomDetail(this.classroomDetail.ClassroomDetailId);
                if (tempExtraClassroomDetail != null)
                {
                    this.showPostponeDateAndTime(false);

                    if (this.classroomDetail.TeacherId == tempExtraClassroomDetail.TeacherId)
                    {
                        this.ComboBox_TeacherName.SelectedIndex = 0;
                    }
                    else
                    {
                        this.ComboBox_TeacherName.SelectedIndex = this.getTeacherIdListIndex(tempExtraClassroomDetail.TeacherId) + 1;
                    }
                    
                    this.ComboBox_TeacherName.Visible = true;
                }                                
            }
            else if (classroomDetailStatus == ClassroomDetail.ClassroomStatus.SCHOOL_CLOSE.ToString())
            {
                this.RadioButton_School_Close.Checked = true;
                this.showPostponeDateAndTime(false);
                this.ComboBox_TeacherName.Visible = false;
            }
            else if (classroomDetailStatus == ClassroomDetail.ClassroomStatus.MISSING.ToString())
            {
                this.RadioButton_Missing.Checked = true;
                this.showPostponeDateAndTime(false);
                this.ComboBox_TeacherName.Visible = false;
            }
        }

        private void refreshComboBox_ClassroomTime()
        {
            this.ComboBox_ClassroomTime.Items.Clear();

            bool isWeekEnd = DateTimeManager.isWeekEnd(DateTimePicker_ClassroomDate.Value);
            if (isWeekEnd)
            {
                List<string> tempWeekEndTimeList = DateTimeManager.weekEndTimeList;
                for (int i = 0; i < tempWeekEndTimeList.Count; i++)
                {
                    this.ComboBox_ClassroomTime.Items.Add(tempWeekEndTimeList[i]);
                }
            }
            else
            {
                List<string> tempWeekDayTimeList = DateTimeManager.weekDayTimeList;
                for (int i = 0; i < tempWeekDayTimeList.Count; i++)
                {
                    this.ComboBox_ClassroomTime.Items.Add(tempWeekDayTimeList[i]);
                }
            }

            this.ComboBox_ClassroomTime.Text = this.classroomDetail.ClassroomTime;
        }

        private void initComboBox_TeacherName()
        {
            this.ComboBox_TeacherName.Items.Clear();
            this.ComboBox_TeacherName.Items.Add("ไม่มีครูแทน");

            this.teacherIdList = TeachingCourseManager.getTeacherIdByCourseId(this.course.Id);
            for (int i = 0; i < this.teacherIdList.Count; i++)
            {
                if (this.classroomDetail.TeacherId != this.teacherIdList[i])
                {
                    Teacher tempTeacher = TeacherManager.findTeacher(this.teacherIdList[i]);
                    if (tempTeacher != null)
                    {
                        string tempTeacherName = "อ." + tempTeacher.Firstname + " (ครู" + tempTeacher.Nickname + ")";
                        this.ComboBox_TeacherName.Items.Add(tempTeacherName);
                    }
                }                
            }
        }

        private int getTeacherIdListIndex(int teacherId)
        {
            int index = -1;

            for (int i = 0; i < this.teacherIdList.Count; i++)
            {
                if (teacherId == this.teacherIdList[i])
                {
                    index = i;
                }
            }

            return index;
        }

        private void refreshButton_Edit_ClassroomDetail_Status()
        {
            string deadlineTime = DateTimeManager.addMinute(this.classroomDetail.ClassroomTime, this.classroomDetail.ClassroomDuration);
            string currentTime = DateTimeManager.getCurrentTime();
            
            bool isOverTime = false;
            if (this.classroomDetail.ClassroomDate < DateTime.Today)
            {
                isOverTime = true;
            }
            else if (this.classroomDetail.ClassroomDate == DateTime.Today)
            {
                if (deadlineTime == DateTimeManager.getMinTime(deadlineTime, currentTime))
                {
                    isOverTime = true;
                }
            }

            if ((isOverTime) ||
                (this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.POSTPONE1.ToString()) ||
                (this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.POSTPONE2.ToString()))
            {
                this.Button_Edit_ClassroomDetail.Enabled = false;
            }
        }

        private void enableEditClassroomDetailDate(bool isEditMode)
        {
            if (this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
            {
                this.DateTimePicker_ClassroomDate.Enabled = isEditMode;
                this.ComboBox_ClassroomTime.Enabled = isEditMode;
            }
            else
            {
                this.DateTimePicker_ClassroomDate.Enabled = false;
                this.ComboBox_ClassroomTime.Enabled = false;
            }
        }

        private void enableEditClassroomDetailStatus(bool isEditMode)
        {
            this.isEditMode = isEditMode;

            this.RadioButton_Waiting.Enabled = isEditMode;

            if ((this.classroomDetail.Type == ClassroomDetail.ClassroomType.NORMAL.ToString()) ||
                (this.classroomDetail.Type == ClassroomDetail.ClassroomType.EXTRA.ToString()) ||
                (this.classroomDetail.Type == ClassroomDetail.ClassroomType.POSTPONE1.ToString()) ||
                (this.classroomDetail.Type == ClassroomDetail.ClassroomType.POSTPONE2.ToString()))
            {
                if (this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.STUDENT_ABSENT.ToString())
                {
                    this.enablePostponeDateAndTime(false);
                    this.RadioButton_Postpone.Enabled = false;
                    this.RadioButton_Student_Absent.Enabled = isEditMode;
                    this.RadioButton_Teacher_Absent.Enabled = false;
                    this.RadioButton_School_Close.Enabled = false;
                }
                else if (this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.TEACHER_ABSENT.ToString())
                {
                    this.enablePostponeDateAndTime(false);
                    this.RadioButton_Postpone.Enabled = false;
                    this.RadioButton_Student_Absent.Enabled = false;
                    this.RadioButton_Teacher_Absent.Enabled = isEditMode;
                    this.ComboBox_TeacherName.Enabled = isEditMode;
                    this.RadioButton_School_Close.Enabled = false;
                }
                else if (this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.SCHOOL_CLOSE.ToString())
                {
                    this.enablePostponeDateAndTime(false);
                    this.RadioButton_Postpone.Enabled = false;
                    this.RadioButton_Student_Absent.Enabled = false;
                    this.RadioButton_Teacher_Absent.Enabled = false;
                    this.RadioButton_School_Close.Enabled = isEditMode;
                }
                else
                {
                    if (this.classroomDetail.Type == ClassroomDetail.ClassroomType.POSTPONE2.ToString())
                    {
                        this.enablePostponeDateAndTime(false);
                        this.RadioButton_Postpone.Enabled = false;
                    }
                    else
                    {
                        this.enablePostponeDateAndTime(isEditMode);
                        this.RadioButton_Postpone.Enabled = isEditMode;
                    }
                    
                    this.RadioButton_Student_Absent.Enabled = isEditMode;
                    this.RadioButton_Teacher_Absent.Enabled = isEditMode;
                    this.RadioButton_School_Close.Enabled = isEditMode;
                }
            }
            //else
            //{
            //    if (this.classroomDetail.Type == ClassroomDetail.ClassroomType.POSTPONE2.ToString())
            //    {
            //        this.enablePostponeDateAndTime(false);
            //        this.RadioButton_Postpone.Enabled = false;
            //    }
            //    else
            //    {
            //        this.enablePostponeDateAndTime(isEditMode);
            //        this.RadioButton_Postpone.Enabled = isEditMode;                    
            //    }

            //    this.RadioButton_Student_Absent.Enabled = isEditMode;
            //    this.RadioButton_Teacher_Absent.Enabled = isEditMode;
            //    this.RadioButton_School_Close.Enabled = isEditMode;
            //}
            
            if (ClassroomDetailManager.getNumberOfAbsenceByStudent(this.classroomDetail.ClassroomId) >= 2)
            {
                this.RadioButton_Student_Absent.Enabled = false;                
            }
            else
            {
                if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
                {
                    this.RadioButton_Student_Absent.Enabled = isEditMode;
                }
                else
                {
                    this.RadioButton_Student_Absent.Enabled = false; 
                }
            }           

            this.Button_Edit_ClassroomDetail.Visible = !isEditMode;
            this.Button_Confirm_Edit_ClassroomDetail_Status.Visible = isEditMode;
            this.Button_Cancel_Edit_ClassroomDetail.Visible = isEditMode;
        }

        private void showPostponeDateAndTime(bool isShow)
        {
            this.DateTimePicker_PostponedTo.Visible = isShow;
            this.label6.Visible = isShow;
            this.ComboBox_PostponeTo_Time.Visible = isShow;
        }

        private void enablePostponeDateAndTime(bool isEnable)
        {
            this.DateTimePicker_PostponedTo.Enabled = isEnable;
            this.ComboBox_PostponeTo_Time.Enabled = isEnable;
            this.refreshComboBox_PostponeTo_Time();
        }

        private void refreshComboBox_PostponeTo_Time()
        {
            this.ComboBox_PostponeTo_Time.Items.Clear();

            if (DateTimeManager.isWeekEnd(this.DateTimePicker_PostponedTo.Value))
            {
                List<string> tempWeekEndTimeList = DateTimeManager.weekEndTimeList;
                for (int i = 0; i < tempWeekEndTimeList.Count; i++)
                {
                    this.ComboBox_PostponeTo_Time.Items.Add(tempWeekEndTimeList[i]);
                }
            }
            else
            {
                List<string> tempWeekDayTimeList = DateTimeManager.weekDayTimeList;
                for (int i = 0; i < tempWeekDayTimeList.Count; i++)
                {
                    this.ComboBox_PostponeTo_Time.Items.Add(tempWeekDayTimeList[i]);
                }
            }

            this.ComboBox_PostponeTo_Time.Text = this.classroomDetail.ClassroomTime;
        }

        private bool editClassroomDetailDate(DateTime newClassroomDate, string newClassroomTime)
        {
            bool returnFlag = false;

            if (ClassroomDetailManager.checkAvailable(this.classroomDetail, this.course, newClassroomDate, newClassroomTime).Result)
            {
                if (newClassroomDate != this.classroomDetail.ClassroomDate)
                {
                    this.classroomDetail.ClassroomDate = newClassroomDate;
                }

                if (newClassroomTime != this.classroomDetail.ClassroomTime)
                {
                    this.classroomDetail.ClassroomTime = newClassroomTime;
                }

                bool isUpdateSuccess = ClassroomDetailManager.updateClassroomDetail(this.classroomDetail);

                if (isUpdateSuccess)
                {
                    //MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_SUCCESS);
                    returnFlag = true;
                }
                else
                {
                    MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_FAIL);
                }
            }
            else
            {
                MessageBox.Show("ไม่สามารถเปลี่ยนเวลาเรียนได้ เนื่องจากเวลาชนกับนักเรียนคนอื่น");
            }

            return returnFlag;
        }

        private bool editClassroomDetailStatus(string newStatus)
        {
            bool isEditSuccess = false;

            if (newStatus != "")
            {
                if (newStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
                {
                    if ((this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.STUDENT_ABSENT.ToString()) ||
                        (this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.TEACHER_ABSENT.ToString()) ||
                        (this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.SCHOOL_CLOSE.ToString()))
                    {
                        isEditSuccess = ClassroomDetailManager.deleteExtraClassroomDetail(newStatus, this.classroomDetail, this.course, this.DateTimePicker_ClassroomDate.Value, this.ComboBox_ClassroomTime.Text);
                    }
                }
                else if (newStatus == ClassroomDetail.ClassroomStatus.POSTPONE1.ToString())
                {
                    isEditSuccess = ClassroomDetailManager.createPostponedClassroomDetail(newStatus, this.classroomDetail, this.course, this.DateTimePicker_PostponedTo.Value, this.ComboBox_PostponeTo_Time.Text);
                }
                else if (newStatus == ClassroomDetail.ClassroomStatus.POSTPONE2.ToString())
                {
                    isEditSuccess = ClassroomDetailManager.createPostponedClassroomDetail(newStatus, this.classroomDetail, this.course, this.DateTimePicker_PostponedTo.Value, this.ComboBox_PostponeTo_Time.Text);
                }
                else if (newStatus == ClassroomDetail.ClassroomStatus.STUDENT_ABSENT.ToString())
                {
                    isEditSuccess = ClassroomDetailManager.createExtraClassroomDetail(newStatus, this.classroomDetail);
                }
                else if (newStatus == ClassroomDetail.ClassroomStatus.TEACHER_ABSENT.ToString())
                {
                    int selectedIndex = this.ComboBox_TeacherName.SelectedIndex;
                    if (selectedIndex == 0)
                    {
                        isEditSuccess = ClassroomDetailManager.createExtraClassroomDetail(newStatus, this.classroomDetail);                        
                    }
                    else 
                    {
                        isEditSuccess = ClassroomDetailManager.createExtraClassroomDetail(newStatus, this.classroomDetail, teacherIdList[selectedIndex - 1]);
                    }
                    
                }
                else if (newStatus == ClassroomDetail.ClassroomStatus.SCHOOL_CLOSE.ToString())
                {
                    isEditSuccess = ClassroomDetailManager.createExtraClassroomDetail(newStatus, this.classroomDetail);
                }
            }

            if (isEditSuccess)
            {
                //MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_SUCCESS);
            }
            else
            {
                MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_FAIL);
            }

            return isEditSuccess;
        }

        private void Button_Edit_ClassroomDetail_Status_Click(object sender, EventArgs e)
        {
            this.enableEditClassroomDetailDate(true);
            this.enableEditClassroomDetailStatus(true);
        }

        private void Button_Confirm_Edit_ClassroomDetail_Click(object sender, EventArgs e)
        {
            string newStatus = "";
            if (this.RadioButton_Waiting.Checked)
            {
                newStatus = ClassroomDetail.ClassroomStatus.WAITING.ToString();
            }
            else if (this.RadioButton_CheckedIn.Checked)
            {
                newStatus = ClassroomDetail.ClassroomStatus.CHECKED_IN.ToString();
            }
            else if (this.RadioButton_Postpone.Checked)
            {
                if ((this.classroomDetail.Type == ClassroomDetail.ClassroomType.NORMAL.ToString()) ||
                    (this.classroomDetail.Type == ClassroomDetail.ClassroomType.EXTRA.ToString()))
                {
                    newStatus = ClassroomDetail.ClassroomStatus.POSTPONE1.ToString();
                }
                else if (this.classroomDetail.Type == ClassroomDetail.ClassroomType.POSTPONE1.ToString())
                {
                    newStatus = ClassroomDetail.ClassroomStatus.POSTPONE2.ToString();
                }
            }
            else if (this.RadioButton_Student_Absent.Checked)
            {
                newStatus = ClassroomDetail.ClassroomStatus.STUDENT_ABSENT.ToString();
            }
            else if (this.RadioButton_Teacher_Absent.Checked)
            {
                newStatus = ClassroomDetail.ClassroomStatus.TEACHER_ABSENT.ToString();
            }
            else if (this.RadioButton_School_Close.Checked)
            {
                newStatus = ClassroomDetail.ClassroomStatus.SCHOOL_CLOSE.ToString();
            }
            else if (this.RadioButton_Missing.Checked)
            {
                newStatus = ClassroomDetail.ClassroomStatus.MISSING.ToString();
            }

            bool isEditClassroomDetailComplete = true;

            if (newStatus != this.classroomDetail.CurrentStatus)
            {
                isEditClassroomDetailComplete = this.editClassroomDetailStatus(newStatus);
            }
            else
            {
                if (this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
                {
                    isEditClassroomDetailComplete = this.editClassroomDetailDate(this.DateTimePicker_ClassroomDate.Value, this.ComboBox_ClassroomTime.Text);
                }
            }

            if (isEditClassroomDetailComplete)
            {
                this.enableEditClassroomDetailDate(false);
                this.enableEditClassroomDetailStatus(false);

                if ((this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.POSTPONE1.ToString()) ||
                    (this.classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.POSTPONE2.ToString()))
                {
                    this.Button_Edit_ClassroomDetail.Enabled = false;
                }
            }                        
        }

        private void Button_Cancel_Edit_ClassroomDetail_Status_Click(object sender, EventArgs e)
        {
            this.setUpComponent(classroomDetail);
            //this.refreshButton_Edit_ClassroomDetail_Status();
            this.enableEditClassroomDetailDate(false);
            this.enableEditClassroomDetailStatus(false);
        }

        private void RadioButton_Postpone_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_Postpone.Checked)
            {
                this.showPostponeDateAndTime(true);

                if (this.isEditMode)
                {
                    this.enablePostponeDateAndTime(true);

                    this.DateTimePicker_PostponedTo.MinDate = DateTime.Today;
                    this.DateTimePicker_PostponedTo.MaxDate = this.classroomDetail.ClassroomDate.AddDays(7);
                    this.DateTimePicker_PostponedTo.Value = this.classroomDetail.ClassroomDate;
                }
                else
                {
                    this.enablePostponeDateAndTime(false);
                }
            }
            else
            {
                this.showPostponeDateAndTime(false);
            }
        }

        private void DateTimePicker_PostponedTo_ValueChanged(object sender, EventArgs e)
        {
            this.refreshComboBox_PostponeTo_Time();            
        }

        private void RadioButton_Teacher_Absent_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_Teacher_Absent.Checked)
            {
                this.ComboBox_TeacherName.Visible = true;

                if (this.ComboBox_TeacherName.Items.Count > 0)
                {
                    this.ComboBox_TeacherName.SelectedIndex = 0;
                }                
            }
            else
            {
                this.ComboBox_TeacherName.Visible = false;
            }
        }

        private void DateTimePicker_ClassroomDate_ValueChanged(object sender, EventArgs e)
        {
            this.refreshComboBox_ClassroomTime();
        }

        private void RadioButton_Waiting_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.RadioButton_Waiting.Checked) && (this.isEditMode))
            {
                this.DateTimePicker_ClassroomDate.Enabled = true;
                this.ComboBox_ClassroomTime.Enabled = true;
            }
            else
            {
                this.DateTimePicker_ClassroomDate.Enabled = false;
                this.ComboBox_ClassroomTime.Enabled = false;
            }
        }
    }
}
