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
    public partial class EnrollmentForm : Form
    {
        private Enrollment enrollment;
        private Course course;        
        private List<Teacher> teacherList;

        public EnrollmentForm()
        {
            InitializeComponent();
        }

        public Enrollment showFormDialog()
        {         
            this.course = new Course();
            this.teacherList = new List<Teacher>();

            this.reset();
            this.ShowDialog();

            return this.enrollment;
        }

        public void reset()
        {
            this.enrollment = null;
            this.course = null;            
            this.teacherList.Clear();

            this.resetGroupBoxCourseDetail();                                 
            this.enableGroupBoxCourseDetail(false);

            this.resetComboBoxNumberOfClassroomDetail();
            this.enableComboBoxNumberOfClassroomDetail(false);

            this.resetGroupBoxClassroomFrequency();
            this.enableGroupBoxClassroomFrequency(false);

            this.resetGroupBoxClassroom1();
            this.enableGroupBoxClassroom1(false);

            this.resetGroupBoxClassroom2();
            this.enableGroupBoxClassroom2(false);

            this.resetGroupBoxClassroom2();
            this.enableButtonSubmit(false);
        }

        public void resetGroupBoxCourseDetail()
        {
            this.TextBox_CourseCategoryName.Text = "";
            this.TextBox_CourseName.Text = "";
            this.TextBox_CourseLevel.Text = "";
            this.TextBox_CourseFee.Text = "";
        }

        public void resetComboBoxNumberOfClassroomDetail()
        {
            this.ComboBox_NumberOfClassroomDetail.SelectedIndex = 11;
        }

        public void resetGroupBoxClassroomFrequency()
        {
            this.RadioButton_OneClassPerWeek.Checked = true;
        }

        public void resetGroupBoxClassroom1()
        {
            this.DateTimePicker_Classroom1_StartDate.Value = DateTime.Today;
            this.refreshComboBoxClassroom1Time(this.DateTimePicker_Classroom1_StartDate.Value);
            this.TextBox_Classroom1_Duration.Text = "";
            this.ComboBox_Classroom1_Teacher.Items.Clear();
        }

        public void resetGroupBoxClassroom2()
        {
            this.DateTimePicker_Classroom2_StartDate.Value = DateTime.Today;
            this.refreshComboBoxClassroom2Time(this.DateTimePicker_Classroom2_StartDate.Value);
            this.TextBox_Classroom2_Duration.Text = "";
            this.ComboBox_Classroom2_Teacher.Items.Clear();
        }

        public void setup(Course course)
        {
            if (course != null)
            {
                this.course = course;

                //CourseCategory tempCourseCategory = CourseCategoryManager.getActiveCourseCategory(course.CourseCategoryId);
                CourseCategory tempCourseCategory = CourseCategoryManager.findCourseCategory(course.CourseCategoryId, CourseCategory.CourseCategoryStatus.ACTIVE);
                if (tempCourseCategory != null)
                {
                    this.setup(tempCourseCategory.Name);
                }
            }
        }

        public void setup(string courseCategoryName)
        {
            this.initGroupBoxCourseDetail(courseCategoryName);
            this.enableComboBoxNumberOfClassroomDetail(true);

            this.ComboBox_NumberOfClassroomDetail.SelectedIndex = this.course.NumberOfClassroom - 1;
            this.enableComboBoxNumberOfClassroomDetail(true);

            this.RadioButton_OneClassPerWeek.Checked = true;
            this.enableGroupBoxClassroomFrequency(true);

            this.DateTimePicker_Classroom1_StartDate.Value = DateTime.Today;
            this.TextBox_Classroom1_Duration.Text = this.course.ClassroomDuration.ToString();
            this.enableGroupBoxClassroom1(true);

            this.DateTimePicker_Classroom2_StartDate.Value = DateTime.Today;
            this.TextBox_Classroom2_Duration.Text = this.course.ClassroomDuration.ToString();
            this.enableGroupBoxClassroom2(false);

            this.refreshComboBoxTeacher(this.course.Id);
        }

        public void initGroupBoxCourseDetail(string courseCategoryName)
        {
            this.TextBox_CourseCategoryName.Text = courseCategoryName;
            this.TextBox_CourseName.Text = this.course.Name;
            this.TextBox_CourseLevel.Text = this.course.Level;
            this.TextBox_CourseFee.Text = this.course.Price.ToString();
        }

        public void initGroupBoxClassroom1(Classroom classroom)
        {
            this.DateTimePicker_Classroom1_StartDate.Value = classroom.StartDate;
            this.ComboBox_Classroom1_Time.Text = classroom.ClassTime;
            this.TextBox_Classroom1_Duration.Text = classroom.ClassDuration.ToString();

            Teacher tempTeacher = TeacherManager.findTeacher(classroom.TeacherId);
            if (tempTeacher != null)
            {
                //string teacherName = "อ." + tempTeacher.Firstname + " (ครู" + tempTeacher.Nickname + ")";

                this.ComboBox_Classroom1_Teacher.Items.Clear();
                this.ComboBox_Classroom1_Teacher.Items.Add(tempTeacher.ToString());
                this.ComboBox_Classroom1_Teacher.SelectedIndex = 0;
            }
        }

        public void initGroupBoxClassroom2(Classroom classroom)
        {
            this.DateTimePicker_Classroom2_StartDate.Value = classroom.StartDate;
            this.ComboBox_Classroom2_Time.Text = classroom.ClassTime;
            this.TextBox_Classroom2_Duration.Text = classroom.ClassDuration.ToString();

            Teacher tempTeacher = TeacherManager.findTeacher(classroom.TeacherId);
            if (tempTeacher != null)
            {
                //string teacherName = "อ." + tempTeacher.Firstname + " (ครู" + tempTeacher.Nickname + ")";

                this.ComboBox_Classroom2_Teacher.Items.Clear();
                this.ComboBox_Classroom2_Teacher.Items.Add(tempTeacher.ToString());
                this.ComboBox_Classroom2_Teacher.SelectedIndex = 0;
            }
        }

        public void refreshComboBoxClassroom1Time(DateTime date)
        {
            this.ComboBox_Classroom1_Time.Items.Clear();

            bool isWeekEnd = DateTimeManager.isWeekEnd(date);
            if (isWeekEnd)
            {
                List<string> tempWeekEndTimeList = DateTimeManager.weekEndTimeList;
                for (int i = 0; i < tempWeekEndTimeList.Count; i++)
                {
                    this.ComboBox_Classroom1_Time.Items.Add(tempWeekEndTimeList[i]);
                }
            }
            else
            {
                List<string> tempWeekDayTimeList = DateTimeManager.weekDayTimeList;
                for (int i = 0; i < tempWeekDayTimeList.Count; i++)
                {
                    this.ComboBox_Classroom1_Time.Items.Add(tempWeekDayTimeList[i]);
                }
            }

            if (this.ComboBox_Classroom1_Time.Items.Count > 0)
            {
                this.ComboBox_Classroom1_Time.SelectedIndex = 0;
            }
        }

        public void refreshComboBoxClassroom2Time(DateTime date)
        {
            this.ComboBox_Classroom2_Time.Items.Clear();

            bool isWeekEnd = DateTimeManager.isWeekEnd(date);
            if (isWeekEnd)
            {
                List<string> tempWeekEndTimeList = DateTimeManager.weekEndTimeList;
                for (int i = 0; i < tempWeekEndTimeList.Count; i++)
                {
                    this.ComboBox_Classroom2_Time.Items.Add(tempWeekEndTimeList[i]);
                }
            }
            else
            {
                List<string> tempWeekDayTimeList = DateTimeManager.weekDayTimeList;
                for (int i = 0; i < tempWeekDayTimeList.Count; i++)
                {
                    this.ComboBox_Classroom2_Time.Items.Add(tempWeekDayTimeList[i]);
                }
            }

            if (this.ComboBox_Classroom2_Time.Items.Count > 0)
            {
                this.ComboBox_Classroom2_Time.SelectedIndex = 0;
            }
        }

        public void refreshComboBoxTeacher(int courseId)
        {
            this.teacherList.Clear();
            this.ComboBox_Classroom1_Teacher.Items.Clear();
            this.ComboBox_Classroom2_Teacher.Items.Clear();

            //List<int> teacherIdList = TeacherManager.getTeacherIdByCourseId(courseId);
            List<int> teacherIdList = TeachingCourseManager.getTeacherIdByCourseId(courseId);
            for (int i = 0; i < teacherIdList.Count; i++)
            {
                Teacher tempTeacher = TeacherManager.findTeacher(teacherIdList[i]);
                if (tempTeacher != null)
                {
                    if (tempTeacher.Status == Teacher.TeacherStatus.ACTIVE.ToString())
                    {
                        this.teacherList.Add(tempTeacher);

                        //string teacherName = "อ." + tempTeacher.Firstname + " (ครู" + tempTeacher.Nickname + ")";
                        this.ComboBox_Classroom1_Teacher.Items.Add(tempTeacher.ToString());
                        this.ComboBox_Classroom2_Teacher.Items.Add(tempTeacher.ToString());
                    }                    
                }
            }

            if (this.ComboBox_Classroom1_Teacher.Items.Count > 0)
            {
                this.ComboBox_Classroom1_Teacher.SelectedIndex = 0;
            }

            if (this.ComboBox_Classroom2_Teacher.Items.Count > 0)
            {
                this.ComboBox_Classroom2_Teacher.SelectedIndex = 0;
            }
        }

        public void refreshButtonSubmit()
        {
            bool isEnableButtonSubmit = false;

            if (this.RadioButton_OneClassPerWeek.Checked)
            {
                if (this.TextBox_Classroom1_Duration.Text != "")
                {
                    isEnableButtonSubmit = true;
                }
            }
            else
            {
                if ((this.TextBox_Classroom1_Duration.Text != "") &&
                    (this.TextBox_Classroom2_Duration.Text != ""))
                {
                    isEnableButtonSubmit = true;
                }
            }

            this.enableButtonSubmit(isEnableButtonSubmit);
        }

        //Set visible for GroupBox_CourseDetail.
        public void showGroupBoxCourseDetail(bool isVisible)
        {
            this.GroupBox_CourseDetail.Visible = isVisible;
            this.TextBox_CourseCategoryName.Visible = isVisible;
            this.TextBox_CourseName.Visible = isVisible;
            this.TextBox_CourseLevel.Visible = isVisible;
            this.TextBox_CourseFee.Visible = isVisible;
        }

        //Set visible for Label_Prefix_ComboBox_NumberOfClassroomDetail, ComboBox_NumberOfClassroomDetail, and Label_Postfix_ComboBox_NumberOfClassroomDetail.
        public void showComboBoxNumberOfClassroomDetail(bool isVisible)
        {
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail.Visible = isVisible;
            this.ComboBox_NumberOfClassroomDetail.Visible = isVisible;
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail.Visible = isVisible;
        }

        //Set visible for GroupBox_Classroom_Frequency.
        public void showGroupBoxClassroomFrequency(bool isVisible)
        {
            this.GroupBox_Classroom_Frequency.Visible = isVisible;
            this.RadioButton_OneClassPerWeek.Visible = isVisible;
            this.RadioButton_TwoClassPerWeek.Visible = isVisible;
            this.RadioButton_TwoClassPerDay.Visible = isVisible;
        }

        //Set visible for GroupBox_Classroom1.
        public void showGroupBoxClassroom1(bool isVisible)
        {
            this.GroupBox_Classroom1.Visible = isVisible;
            this.DateTimePicker_Classroom1_StartDate.Visible = isVisible;
            this.ComboBox_Classroom1_Time.Visible = isVisible;
            this.TextBox_Classroom1_Duration.Visible = isVisible;
            this.ComboBox_Classroom1_Teacher.Visible = isVisible;
        }

        //Set visible for GroupBox_Classroom2.
        public void showGroupBoxClassroom2(bool isVisible)
        {
            this.GroupBox_Classroom2.Visible = isVisible;
            this.DateTimePicker_Classroom2_StartDate.Visible = isVisible;
            this.ComboBox_Classroom2_Time.Visible = isVisible;
            this.TextBox_Classroom2_Duration.Visible = isVisible;
            this.ComboBox_Classroom2_Teacher.Visible = isVisible;
        }

        //Set visible for Button_Submit.
        public void showButtonSubmit(bool isVisible)
        {
            this.Button_Submit.Visible = isVisible;
        }

        public void enableGroupBoxCourseDetail(bool isEnable)
        {
            this.GroupBox_CourseDetail.Enabled = isEnable;
            this.TextBox_CourseCategoryName.Enabled = isEnable;
            this.TextBox_CourseName.Enabled = isEnable;
            this.TextBox_CourseLevel.Enabled = isEnable;
            this.TextBox_CourseFee.Enabled = isEnable;
        }

        //Enable and disable ComboBox_NumberOfClassroomDetail.
        public void enableComboBoxNumberOfClassroomDetail(bool isEnable)
        {
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail.Enabled = isEnable;
            this.ComboBox_NumberOfClassroomDetail.Enabled = isEnable;
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail.Enabled = isEnable;
        }

        //Enable and disable GroupBox_Classroom_Frequency.
        public void enableGroupBoxClassroomFrequency(bool isEnable)
        {
            this.GroupBox_Classroom_Frequency.Enabled = isEnable;
            this.RadioButton_OneClassPerWeek.Enabled = isEnable;
            this.RadioButton_TwoClassPerWeek.Enabled = isEnable;
            this.RadioButton_TwoClassPerDay.Enabled = isEnable;
        }

        //Enable and disable all components in GroupBox_Classroom1.
        public void enableGroupBoxClassroom1(bool isEnable)
        {
            this.GroupBox_Classroom1.Enabled = isEnable;
            this.DateTimePicker_Classroom1_StartDate.Enabled = isEnable;
            this.ComboBox_Classroom1_Time.Enabled = isEnable;
            this.TextBox_Classroom1_Duration.Enabled = isEnable;
            this.ComboBox_Classroom1_Teacher.Enabled = isEnable;
        }

        //Enable and disable component in GroupBox_Classroom1.
        public void enableGroupBoxClassroom1(bool isEnableDateTimePickerStartDate, bool isEnableComboBoxTime, bool isEnableTextBoxDuration, bool isEnableComboBoxTeacher)
        {
            if (isEnableDateTimePickerStartDate ||
                isEnableComboBoxTime ||
                isEnableTextBoxDuration ||
                isEnableComboBoxTeacher)
            {
                this.GroupBox_Classroom1.Enabled = true;
            }
            else
            {
                this.GroupBox_Classroom1.Enabled = false;
            }

            this.DateTimePicker_Classroom1_StartDate.Enabled = isEnableDateTimePickerStartDate;
            this.ComboBox_Classroom1_Time.Enabled = isEnableComboBoxTime;
            this.TextBox_Classroom1_Duration.Enabled = isEnableTextBoxDuration;
            this.ComboBox_Classroom1_Teacher.Enabled = isEnableComboBoxTeacher;
        }

        //Enable and disable all components in GroupBox_Classroom2.
        public void enableGroupBoxClassroom2(bool isEnable)
        {
            this.GroupBox_Classroom2.Enabled = isEnable;
            this.DateTimePicker_Classroom2_StartDate.Enabled = isEnable;
            this.ComboBox_Classroom2_Time.Enabled = isEnable;
            this.TextBox_Classroom2_Duration.Enabled = isEnable;
            this.ComboBox_Classroom2_Teacher.Enabled = isEnable;
        }

        //Enable and disable all component in GroupBox_Classroom2.
        public void enableGroupBoxClassroom2(bool isEnableDateTimePickerStartDate, bool isEnableComboBoxTime, bool isEnableTextBoxDuration, bool isEnableComboBoxTeacher)
        {
            if (isEnableDateTimePickerStartDate ||
                isEnableComboBoxTime ||
                isEnableTextBoxDuration ||
                isEnableComboBoxTeacher)
            {
                this.GroupBox_Classroom2.Enabled = true;
            }
            else
            {
                this.GroupBox_Classroom2.Enabled = false;
            }
            
            this.DateTimePicker_Classroom2_StartDate.Enabled = isEnableDateTimePickerStartDate;
            this.ComboBox_Classroom2_Time.Enabled = isEnableComboBoxTime;
            this.TextBox_Classroom2_Duration.Enabled = isEnableTextBoxDuration;
            this.ComboBox_Classroom2_Teacher.Enabled = isEnableComboBoxTeacher;
        }

        //Enable and disable Button_Submit.
        public void enableButtonSubmit(bool isEnable)
        {
            this.Button_Submit.Enabled = isEnable;
        }

        public Classroom createClassroom1()
        {
            Classroom classroom = new Classroom();
            classroom.Id = 1;
            classroom.TeacherId = this.teacherList[this.ComboBox_Classroom1_Teacher.SelectedIndex].Id;
            classroom.StartDate = this.DateTimePicker_Classroom1_StartDate.Value;
            classroom.ClassDayOfWeek = ConvertManager.toThaiDayOfWeek(this.DateTimePicker_Classroom1_StartDate.Value.DayOfWeek.ToString());
            classroom.ClassTime = this.ComboBox_Classroom1_Time.Text;
            classroom.Status = Classroom.ClassroomStatus.ACTIVE.ToString();

            try
            {
                classroom.ClassDuration = Convert.ToInt32(this.TextBox_Classroom1_Duration.Text);
            }
            catch (System.Exception ex)
            {
                classroom.ClassDuration = this.course.ClassroomDuration;
                LogManager.writeLog(ex.Message);
            }

            return classroom;
        }

        public Classroom createClassroom2()
        {
            Classroom classroom = null;
            if (this.RadioButton_TwoClassPerWeek.Checked || 
                this.RadioButton_TwoClassPerDay.Checked)
            {
                classroom = new Classroom();
                classroom.Id = 2;
                classroom.TeacherId = this.teacherList[this.ComboBox_Classroom2_Teacher.SelectedIndex].Id;
                classroom.StartDate = this.DateTimePicker_Classroom2_StartDate.Value;
                classroom.ClassDayOfWeek = ConvertManager.toThaiDayOfWeek(this.DateTimePicker_Classroom2_StartDate.Value.DayOfWeek.ToString());
                classroom.ClassTime = this.ComboBox_Classroom2_Time.Text;
                classroom.Status = Classroom.ClassroomStatus.ACTIVE.ToString();

                try
                {
                    classroom.ClassDuration = Convert.ToInt32(this.TextBox_Classroom2_Duration.Text);
                }
                catch (System.Exception ex)
                {
                    classroom.ClassDuration = this.course.ClassroomDuration;
                    LogManager.writeLog(ex.Message);
                }                
            }

            return classroom;
        }

        private void Button_Search_Course_Click(object sender, EventArgs e)
        {
            List<Course> tempCourseList = CourseManager.findAllCourse(Course.CourseStatus.ACTIVE);
            if (tempCourseList.Count > 0)
            {
                SearchProductResultForm searchProductResultForm = new SearchProductResultForm();
                searchProductResultForm.showFormDialog(tempCourseList, this);
            }
        }

        private void RadioButton_OneClassPerWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_OneClassPerWeek.Checked)
            {
                this.enableGroupBoxClassroom1(true);
                this.enableGroupBoxClassroom2(false);
                this.refreshButtonSubmit();
            }
        }

        private void RadioButton_TwoClassPerWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_TwoClassPerWeek.Checked)
            {
                this.enableGroupBoxClassroom1(true);
                this.enableGroupBoxClassroom2(true);
                this.refreshButtonSubmit();
            }
        }

        private void RadioButton_TwoClassPerDay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_TwoClassPerDay.Checked)
            {
                this.enableGroupBoxClassroom1(true);
                this.DateTimePicker_Classroom2_StartDate.Value = this.DateTimePicker_Classroom1_StartDate.Value;
                this.refreshComboBoxClassroom2Time(this.DateTimePicker_Classroom2_StartDate.Value);
                this.enableGroupBoxClassroom2(false, true, true, true);
                this.refreshButtonSubmit();
            }
        }

        private void DateTimePicker_Classroom1_StartDate_ValueChanged(object sender, EventArgs e)
        {
            this.refreshComboBoxClassroom1Time(this.DateTimePicker_Classroom1_StartDate.Value);

            if (this.RadioButton_TwoClassPerDay.Checked)
            {
                this.DateTimePicker_Classroom2_StartDate.Value = this.DateTimePicker_Classroom1_StartDate.Value;
                this.refreshComboBoxClassroom2Time(this.DateTimePicker_Classroom1_StartDate.Value);
            }
        }

        private void DateTimePicker_Classroom2_StartDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.GroupBox_Classroom2.Enabled)
            {
                this.refreshComboBoxClassroom2Time(this.DateTimePicker_Classroom2_StartDate.Value);
            }            
        }

        private void TextBox_Classroom1_Duration_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_Classroom1_Duration_TextChanged(object sender, EventArgs e)
        {
            this.refreshButtonSubmit();
        }

        private void TextBox_Classroom2_Duration_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_Classroom2_Duration_TextChanged(object sender, EventArgs e)
        {
            this.refreshButtonSubmit();
        }        

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            this.reset();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.enrollment = null;
            this.Close();
        }

        private void Button_Submit_Click(object sender, EventArgs e)
        {
            if (this.course != null)
            {
                this.enrollment = new Enrollment(this.course);
                this.enrollment.addClassroom(this.createClassroom1());
                this.enrollment.addClassroom(this.createClassroom2());
                this.enrollment.EnrolledDate = DateTime.Today;
                this.enrollment.Status = Enrollment.EnrollmentStatus.NOT_PAID.ToString();
                if (this.enrollment.ClassroomList.Count > 0)
                {
                    int numberOfClassroomDetail = Convert.ToInt32(this.ComboBox_NumberOfClassroomDetail.Text);

                    this.enrollment.ClassroomIdClassroomDetailListDictionary = ClassroomDetailManager.generateClassroomDetail(this.enrollment.ClassroomList, this.enrollment.Course, numberOfClassroomDetail);
                    this.Close();
                }
            }            
        }

        private void ComboBox_Classroom1_Teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            Teacher tempTeacher = this.teacherList[this.ComboBox_Classroom1_Teacher.SelectedIndex];
            if (tempTeacher != null)
            {
                if ((tempTeacher.Settings & Teacher.TeacherSettings.TEACHES_45_MIN) != 0)
                {
                    this.TextBox_Classroom1_Duration.Text = "45";
                }
                else
                {
                    this.TextBox_Classroom1_Duration.Text = this.course.ClassroomDuration.ToString();
                }
            }
        }

        private void ComboBox_Classroom2_Teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            Teacher tempTeacher = this.teacherList[this.ComboBox_Classroom2_Teacher.SelectedIndex];
            if (tempTeacher != null)
            {
                if ((tempTeacher.Settings & Teacher.TeacherSettings.TEACHES_45_MIN) != 0)
                {
                    this.TextBox_Classroom2_Duration.Text = "45";
                }
                else
                {
                    this.TextBox_Classroom2_Duration.Text = this.course.ClassroomDuration.ToString();
                }
            }
        }
    }
}
