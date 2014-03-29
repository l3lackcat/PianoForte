using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.View.Control
{
    public partial class EnrollmentControl : UserControl
    {
        private Form caller;
        private Course course;
        private List<Teacher> teacherList;
        private Classroom classroom1;
        private Classroom classroom2;

        public EnrollmentControl()
        {
            InitializeComponent();
        }

        public Course getCourse()
        {
            return this.course;
        }

        public Classroom getClassroom1()
        {
            return this.classroom1;
        }

        public Classroom getClassroom2()
        {
            return this.classroom2;
        }

        public int getNumberOfClassroomDetail()
        {
            return this.ComboBox_NumberOfClassroomDetail.SelectedIndex + 1;
        }

        //Initial parameters and set this control to default.
        public void init(Form caller)
        {
            this.caller = caller;
            this.course = new Course();
            this.teacherList = new List<Teacher>();
            this.classroom1 = new Classroom();
            this.classroom2 = new Classroom();

            this.reset();
        }

        public void reset()
        {
            this.course = null;
            this.teacherList.Clear();
            this.classroom1 = null;
            this.classroom2 = null;

            this.showComboBoxNumberOfClassroomDetail(false);
            this.showGroupBoxClassroomFrequency(false);
            this.showGroupBoxClassroom1(false);
            this.showGroupBoxClassroom2(false);
        }

        public void setup(Course course)
        {
            if (course != null)
            {
                this.course = course;

                CourseCategory tempCourseCategory = CourseCategoryManager.getActiveCourseCategory(course.CourseCategoryId);
                if (tempCourseCategory != null)
                {
                    this.course = course;
                    this.setup(tempCourseCategory.Name);
                }
            }
        }

        public void setup(Enrollment enrollment)
        {
            if (enrollment != null)
            {
                if (enrollment.Course != null)
                {
                    CourseCategory tempCourseCategory = CourseCategoryManager.getActiveCourseCategory(enrollment.Course.CourseCategoryId);
                    if (tempCourseCategory != null)
                    {
                        this.setup(enrollment.Course);

                        List<Classroom> tempClassroomList = ClassroomManager.getAllClassroom(enrollment.Id);

                        int numberOfClassroomDetail = enrollment.Course.NumberOfClassroom;
                        for (int i = 0; i < tempClassroomList.Count; i++)
                        {
                            List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.getAllClassroomDetail(tempClassroomList[i].Id);
                            numberOfClassroomDetail += tempClassroomList.Count;
                        }

                        this.ComboBox_NumberOfClassroomDetail.SelectedIndex = numberOfClassroomDetail - 1;
                        this.enableComboBoxNumberOfClassroomDetail(false);

                        if (tempClassroomList.Count == 1)
                        {
                            Classroom tempClassroom1 = tempClassroomList[0];
                            if (tempClassroom1 != null)
                            {
                                this.RadioButton_OneClassPerWeek.Checked = true;
                                this.enableGroupBoxClassroomFrequency(false);
                                this.showGroupBoxClassroomFrequency(true);

                                this.initGroupBoxClassroom1(tempClassroom1);
                                this.enableGroupBoxClassroom1(false);
                                this.showGroupBoxClassroom1(true);
                            }
                        }
                        else if (tempClassroomList.Count == 2)
                        {
                            Classroom tempClassroom1 = tempClassroomList[0];
                            Classroom tempClassroom2 = tempClassroomList[1];

                            if ((tempClassroom1 != null) && (tempClassroom2 != null))
                            {
                                if (tempClassroom1.ClassDayOfWeek == tempClassroom2.ClassDayOfWeek)
                                {
                                    this.RadioButton_TwoClassPerDay.Checked = true;
                                }
                                else
                                {
                                    this.RadioButton_OneClassPerWeek.Checked = true;                                    
                                }

                                this.enableGroupBoxClassroomFrequency(false);

                                this.initGroupBoxClassroom1(tempClassroom1);
                                this.enableGroupBoxClassroom1(false);
                                this.showGroupBoxClassroom1(true);

                                this.initGroupBoxClassroom2(tempClassroom2);
                                this.enableGroupBoxClassroom2(false);
                                this.showGroupBoxClassroom2(true);
                            }
                        }
                    }
                }
            }
        }

        public void setup(string courseCategoryName)
        {
            this.initGroupBoxCourseDetail(courseCategoryName);

            this.showComboBoxNumberOfClassroomDetail(true);
            this.ComboBox_NumberOfClassroomDetail.SelectedIndex = this.course.NumberOfClassroom - 1;

            this.RadioButton_OneClassPerWeek.Checked = true;
            this.enableGroupBoxClassroomFrequency(true);
            this.showGroupBoxClassroomFrequency(true);

            this.DateTimePicker_Classroom1_StartDate.Value = DateTime.Today;
            this.TextBox_Classroom1_Duration.Text = this.course.ClassroomDuration.ToString();
            this.enableGroupBoxClassroom1(true);
            this.showGroupBoxClassroom1(true);

            this.DateTimePicker_Classroom2_StartDate.Value = DateTime.Today;
            this.TextBox_Classroom2_Duration.Text = this.course.ClassroomDuration.ToString();
            this.enableGroupBoxClassroom2(true);
            this.showGroupBoxClassroom2(true);

            this.refreshComboBoxTeacher(this.course.Name);
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

            Teacher tempTeacher = TeacherManager.getTeacher(classroom.TeacherId);
            if (tempTeacher != null)
            {
                string teacherName = "อ." + tempTeacher.Firstname + " (ครู" + tempTeacher.Nickname + ")";

                this.ComboBox_Classroom1_Teacher.Items.Clear();
                this.ComboBox_Classroom1_Teacher.Items.Add(teacherName);
                this.ComboBox_Classroom1_Teacher.SelectedIndex = 0;
            }
        }

        public void initGroupBoxClassroom2(Classroom classroom)
        {
            this.DateTimePicker_Classroom2_StartDate.Value = classroom.StartDate;
            this.ComboBox_Classroom2_Time.Text = classroom.ClassTime;
            this.TextBox_Classroom2_Duration.Text = classroom.ClassDuration.ToString();

            Teacher tempTeacher = TeacherManager.getTeacher(classroom.TeacherId);
            if (tempTeacher != null)
            {
                string teacherName = "อ." + tempTeacher.Firstname + " (ครู" + tempTeacher.Nickname + ")";

                this.ComboBox_Classroom2_Teacher.Items.Clear();
                this.ComboBox_Classroom2_Teacher.Items.Add(teacherName);
                this.ComboBox_Classroom2_Teacher.SelectedIndex = 0;
            }
        }

        public void setButtonSubmitText(string text)
        {
            this.Button_Submit.Text = text;
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

        public void refreshComboBoxTeacher(string courseName)
        {
            this.teacherList.Clear();
            this.ComboBox_Classroom1_Teacher.Items.Clear();
            this.ComboBox_Classroom2_Teacher.Items.Clear();

            List<int> teacherIdList = TeacherManager.getTeacherIdByCourseId(courseName);
            for (int i = 0; i < teacherIdList.Count; i++)
            {
                Teacher tempTeacher = TeacherManager.getTeacher(teacherIdList[i]);
                if (tempTeacher != null)
                {
                    this.teacherList.Add(tempTeacher);

                    string teacherName = "อ." + tempTeacher.Firstname + " (ครู" + tempTeacher.Nickname + ")";
                    this.ComboBox_Classroom1_Teacher.Items.Add(teacherName);
                    this.ComboBox_Classroom2_Teacher.Items.Add(teacherName);
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

        //Set visible for combobox number of classroom detail and its label.
        public void showComboBoxNumberOfClassroomDetail(bool isVisible)
        {
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail.Visible = isVisible;
            this.ComboBox_NumberOfClassroomDetail.Visible = isVisible;
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail.Visible = isVisible;
        }

        //Set visible for groupbox classroom frequency.
        public void showGroupBoxClassroomFrequency(bool isVisible)
        {
            this.GroupBox_Classroom_Frequency.Visible = isVisible;
        }

        //Set visible for groupbox classroom1.
        public void showGroupBoxClassroom1(bool isVisible)
        {
            this.GroupBox_Classroom1.Visible = isVisible;
        }

        //Set visible for groupbox classroom2.
        public void showGroupBoxClassroom2(bool isVisible)
        {
            this.GroupBox_Classroom2.Visible = isVisible;
        }

        //Set visible for button submit.
        public void showButtonSubmit(bool isVisible)
        {
            this.Button_Submit.Visible = isVisible;
        }

        //Enable and disable combobox number of classroom detail and its label.
        public void enableComboBoxNumberOfClassroomDetail(bool isEnable)
        {
            this.ComboBox_NumberOfClassroomDetail.Enabled = isEnable;
        }

        //Enable and disable groupbox classroom frequency.
        public void enableGroupBoxClassroomFrequency(bool isEnable)
        {
            this.GroupBox_Classroom_Frequency.Enabled = isEnable;
        }

        //Enable and disable all components in groupbox classroom1.
        public void enableGroupBoxClassroom1(bool isEnable)
        {
            this.GroupBox_Classroom1.Enabled = isEnable;
        }

        //Enable and disable all components in groupbox classroom1.
        public void enableGroupBoxClassroom1(bool isEnableDateTimePickerStartDate, bool isEnableComboBoxTime, bool isEnableTextBoxDuration, bool isEnableComboBoxTeacher)
        {
            this.DateTimePicker_Classroom1_StartDate.Enabled = isEnableDateTimePickerStartDate;
            this.ComboBox_Classroom1_Time.Enabled = isEnableComboBoxTime;
            this.TextBox_Classroom1_Duration.Enabled = isEnableTextBoxDuration;
            this.ComboBox_Classroom1_Teacher.Enabled = isEnableComboBoxTeacher;
        }

        //Enable and disable all components in groupbox classroom2.
        public void enableGroupBoxClassroom2(bool isEnable)
        {
            this.GroupBox_Classroom2.Enabled = isEnable;
        }

        //Enable and disable all components in groupbox classroom2.
        public void enableGroupBoxClassroom2(bool isEnableDateTimePickerStartDate, bool isEnableComboBoxTime, bool isEnableTextBoxDuration, bool isEnableComboBoxTeacher)
        {
            this.DateTimePicker_Classroom2_StartDate.Enabled = isEnableDateTimePickerStartDate;
            this.ComboBox_Classroom2_Time.Enabled = isEnableComboBoxTime;
            this.TextBox_Classroom2_Duration.Enabled = isEnableTextBoxDuration;
            this.ComboBox_Classroom2_Teacher.Enabled = isEnableComboBoxTeacher;
        }        

        //Enable and disable button submit.
        public void enableButtonSubmit(bool isEnable)
        {
            this.Button_Submit.Enabled = isEnable;
        }                       

        private void RadioButton_OneClassPerWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_OneClassPerWeek.Checked)
            {
                this.DateTimePicker_Classroom1_StartDate.Value = DateTime.Today;
                this.refreshComboBoxClassroom1Time(DateTime.Today);
                this.enableGroupBoxClassroom1(true);
                this.showGroupBoxClassroom1(true);

                this.showGroupBoxClassroom2(false);
            }
        }

        private void RadioButton_TwoClassPerWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_TwoClassPerWeek.Checked)
            {
                this.DateTimePicker_Classroom1_StartDate.Value = DateTime.Today;
                this.refreshComboBoxClassroom1Time(DateTime.Today);
                this.enableGroupBoxClassroom1(true);
                this.showGroupBoxClassroom1(true);

                this.DateTimePicker_Classroom2_StartDate.Value = DateTime.Today;
                this.refreshComboBoxClassroom2Time(DateTime.Today);
                this.enableGroupBoxClassroom2(true);
                this.showGroupBoxClassroom2(true);
            }
        }

        private void RadioButton_TwoClassPerDay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_TwoClassPerDay.Checked)
            {
                this.DateTimePicker_Classroom1_StartDate.Value = DateTime.Today;
                this.refreshComboBoxClassroom1Time(DateTime.Today);
                this.enableGroupBoxClassroom1(true);
                this.showGroupBoxClassroom1(true);

                this.DateTimePicker_Classroom2_StartDate.Value = DateTime.Today;
                this.refreshComboBoxClassroom2Time(DateTime.Today);
                this.enableGroupBoxClassroom2(false, true, true, true);
                this.showGroupBoxClassroom2(true);
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
            this.refreshComboBoxClassroom2Time(this.DateTimePicker_Classroom2_StartDate.Value);
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

        private void Button_Submit_Click(object sender, EventArgs e)
        {
            //To Do
        }                
    }
}
