using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Model;
using PianoForte.Manager;

namespace PianoForte.View
{
    public partial class EnrollmentPopUp : Form
    {
        private Form caller;
        private Course course = null;
        private List<Teacher> teacherList = null;
        private Enrollment enrollment = null;

        public EnrollmentPopUp()
        {
            InitializeComponent();
        }

        public Enrollment showFormDialog(Form caller)
        {
            this.caller = caller;

            this.reset();

            this.ShowDialog();

            return this.enrollment;
        }

        public Enrollment showFormDialog(Form caller, Course course)
        {
            this.caller = caller;

            this.reset();
            this.updateCourseInfo(course);

            this.ShowDialog();

            return this.enrollment;
        }

        public Enrollment showFormDialog(Form caller, Enrollment enrollment)
        {
            this.caller = caller;            

            this.reset();

            this.enrollment = enrollment;

            this.updateCourseInfo(this.enrollment);            

            this.ShowDialog();

            return this.enrollment;
        }

        private void reset()
        {
            this.course = null;
            this.teacherList = null;
            this.enrollment = null;

            this.resetTextBoxCourseBarcode();
            this.resetDiscountBox();
            this.resetCourseInfoBox();
            this.resetNumberOfClassroomDetailBox();
            this.resetClassroomFrequencyBox();
            this.resetClassroom1Box();
            this.resetClassroom2Box();

            this.enableGroupBoxClassroom1(false);
        }

        private void resetTextBoxCourseBarcode()
        {
            this.TextBox_CourseBarcode.Text = "";
        }

        private void resetDiscountBox()
        {
            this.CheckBox_Discount.Checked = false;
            this.TextBox_Discount.Text = "";

            this.enableDiscountBox(false);
        }

        private void resetCourseInfoBox()
        {
            this.TextBox_CourseCategoryName.Text = "";
            this.TextBox_CourseName.Text = "";
            this.TextBox_CourseFee.Text = "";
        }

        private void resetNumberOfClassroomDetailBox()
        {
            this.ComboBox_NumberOfClassroomDetail.SelectedIndex = this.ComboBox_NumberOfClassroomDetail.Items.Count - 1;

            this.enableComboBoxNumberOfClassroomDetail(false);
        }

        private void resetClassroomFrequencyBox()
        {
            this.RadioButton_OneClassPerWeek.Checked = true;

            this.enableGroupBoxClassroomFrequency(false);
        }

        private void resetClassroom1Box()
        {
            this.DateTimePicker_Classroom1_StartDate.Value = DateTime.Today;
            this.TextBox_Classroom1_Duration.Text = "";
            this.ComboBox_Classroom1_Teacher.Items.Clear();

            this.updateComboBoxClassroom1Time(DateTimePicker_Classroom1_StartDate.Value);
        }

        private void resetClassroom2Box()
        {
            this.DateTimePicker_Classroom2_StartDate.Value = DateTime.Today;
            this.TextBox_Classroom2_Duration.Text = "";
            this.ComboBox_Classroom2_Teacher.Items.Clear();

            this.updateComboBoxClassroom2Time(DateTimePicker_Classroom2_StartDate.Value);
        }        

        //Enable and disable CheckBox_Discount.
        private void enableDiscountBox(bool isEnable)
        {
            this.CheckBox_Discount.Enabled = isEnable;
        }

        //Enable and disable TextBox_Discount.
        private void enableTextBoxDiscount(bool isEnable)
        {
            this.TextBox_Discount.Enabled = isEnable;
        }

        //Enable and disable ComboBox_NumberOfClassroomDetail.
        private void enableComboBoxNumberOfClassroomDetail(bool isEnable)
        {
            this.Label_Prefix_ComboBox_NumberOfClassroomDetail.Enabled = isEnable;
            this.ComboBox_NumberOfClassroomDetail.Enabled = isEnable;
            this.Label_Postfix_ComboBox_NumberOfClassroomDetail.Enabled = isEnable;
        }

        //Enable and disable GroupBox_Classroom_Frequency.
        private void enableGroupBoxClassroomFrequency(bool isEnable)
        {
            this.GroupBox_Classroom_Frequency.Enabled = isEnable;
            this.RadioButton_OneClassPerWeek.Enabled = isEnable;
            this.RadioButton_TwoClassPerWeek.Enabled = isEnable;
            this.RadioButton_TwoClassPerDay.Enabled = isEnable;
        }

        //Enable and disable all components in GroupBox_Classroom1.
        private void enableGroupBoxClassroom1(bool isEnable)
        {
            this.GroupBox_Classroom1.Enabled = isEnable;
            this.DateTimePicker_Classroom1_StartDate.Enabled = isEnable;
            this.ComboBox_Classroom1_Time.Enabled = isEnable;
            this.TextBox_Classroom1_Duration.Enabled = isEnable;
            this.ComboBox_Classroom1_Teacher.Enabled = isEnable;
        }

        //Enable and disable component in GroupBox_Classroom1.
        private void enableGroupBoxClassroom1(bool isEnableDateTimePickerStartDate, bool isEnableComboBoxTime, bool isEnableTextBoxDuration, bool isEnableComboBoxTeacher)
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
        private void enableGroupBoxClassroom2(bool isEnable)
        {
            bool isTwoClassPerDayChecked = this.RadioButton_TwoClassPerDay.Checked;                        
            bool isTwoClassPerWeekChecked = this.RadioButton_TwoClassPerWeek.Checked;

            if (isTwoClassPerDayChecked == true)
            {
                this.enableGroupBoxClassroom2(false, true, true, true);
            }
            else if (isTwoClassPerWeekChecked == true)
            {
                this.enableGroupBoxClassroom2(true, true, true, true);
            }
            else
            {
                this.enableGroupBoxClassroom2(false, false, false, false);
            }            
        }

        //Enable and disable all component in GroupBox_Classroom2.
        private void enableGroupBoxClassroom2(bool isEnableDateTimePickerStartDate, bool isEnableComboBoxTime, bool isEnableTextBoxDuration, bool isEnableComboBoxTeacher)
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

        private void updateDiscountBox(double discount)
        {            
            if (discount > 0)
            {
                this.CheckBox_Discount.Checked = true;
                this.TextBox_Discount.Text = discount.ToString();
            }
        }

        private void updateCourseInfo(Course course)
        {
            if (course != null)
            {
                this.course = course;

                if (this.teacherList == null)
                {
                    this.teacherList = new List<Teacher>();
                }
                else 
                {
                    this.teacherList.Clear();
                }

                CourseCategory courseCategory = CourseCategoryManager.findCourseCategory(this.course.CourseCategoryId);
                if (courseCategory != null)
                {
                    this.TextBox_CourseCategoryName.Text = courseCategory.Name;
                    this.TextBox_CourseName.Text = this.course.Name + " - " + this.course.Level;
                    this.TextBox_CourseFee.Text = this.course.Price.ToString("N", new CultureInfo("en-US"));

                    this.updateComboBoxNumberOfClassroomDetailIndex(this.course.NumberOfClassroom);
                    this.updateComboBoxTeacher(this.course.Id);

                    this.enableDiscountBox(true);                    
                    this.enableComboBoxNumberOfClassroomDetail(true);
                    this.enableGroupBoxClassroomFrequency(true);

                    this.enableGroupBoxClassroom1(true);
                    this.updateGroupBoxClassroom1(this.course.ClassroomDuration);

                    this.enableGroupBoxClassroom2(true);
                    this.updateGroupBoxClassroom2(this.course.ClassroomDuration);
                }
            }
        }

        private void updateCourseInfo(Enrollment enrollment)
        {
            if (enrollment != null)
            {
                this.course = enrollment.Course;
                this.enrollment = enrollment;

                if (this.teacherList == null)
                {
                    this.teacherList = new List<Teacher>();
                }
                else
                {
                    this.teacherList.Clear();
                }

                CourseCategory courseCategory = CourseCategoryManager.findCourseCategory(course.CourseCategoryId);
                if (courseCategory != null)
                {
                    this.TextBox_CourseCategoryName.Text = courseCategory.Name;
                    this.TextBox_CourseName.Text = this.course.Name + " - " + this.course.Level;
                    this.TextBox_CourseFee.Text = this.course.Price.ToString("N", new CultureInfo("en-US"));

                    this.updateComboBoxNumberOfClassroomDetailIndex(this.course.NumberOfClassroom);
                    this.updateComboBoxTeacher(this.course.Id);

                    this.enableDiscountBox(true);
                    this.updateDiscountBox(this.enrollment.Discount);
                    
                    this.enableComboBoxNumberOfClassroomDetail(true);
                    this.updateComboBoxNumberOfClassroomDetailIndex(this.getNumberOfClassroomDetail(this.enrollment));

                    this.enableGroupBoxClassroomFrequency(true);
                    this.updateGroupBoxClassroomFrequency(this.enrollment);

                    this.enableGroupBoxClassroom1(true);
                    this.updateGroupBoxClassroom1(enrollment);

                    this.enableGroupBoxClassroom2(true);
                    this.updateGroupBoxClassroom2(enrollment);

                    this.updateButtonSubmit();
                }
            }
        }

        private void updateComboBoxNumberOfClassroomDetailIndex(int numberOfClassroom)
        {
            if ((numberOfClassroom > 0) && (numberOfClassroom <= 12))
            {
                this.ComboBox_NumberOfClassroomDetail.SelectedIndex = numberOfClassroom - 1;
            }
        }

        private void updateGroupBoxClassroomFrequency(Enrollment enrollment)
        {
            if (enrollment != null)
            {
                int numberOfClassroom = enrollment.ClassroomList.Count;

                if (numberOfClassroom == 1)
                {
                    this.RadioButton_OneClassPerWeek.Checked = true;
                }
                else
                {
                    List<string> dayOfWeekList = new List<string>();

                    for (int i = 0; i < numberOfClassroom; i++)
                    {
                        string dayOfWeek = enrollment.ClassroomList[i].StartDate.DayOfWeek.ToString();

                        if (dayOfWeekList.Contains(dayOfWeek) == false)
                        {
                            dayOfWeekList.Add(dayOfWeek);
                        }                        
                    }

                    if (dayOfWeekList.Count == 1)
                    {
                        this.RadioButton_TwoClassPerDay.Checked = true;
                    }
                    else
                    {
                        this.RadioButton_TwoClassPerWeek.Checked = true;
                    }
                }
            }
        }

        private void updateGroupBoxClassroom1(int duration)
        {
            this.TextBox_Classroom1_Duration.Text = duration.ToString();
        }

        private void updateGroupBoxClassroom1(Enrollment enrollment)
        {
            if (enrollment != null)
            {
                int numberOfClassroom = enrollment.ClassroomList.Count;

                if (numberOfClassroom > 0)
                {
                    Classroom classroom = enrollment.ClassroomList[0];
                    Teacher teacher = TeacherManager.findTeacher(classroom.TeacherId);

                    this.DateTimePicker_Classroom1_StartDate.Value = classroom.StartDate;
                    this.updateComboBoxClassroom1Time(DateTimePicker_Classroom1_StartDate.Value);
                    this.ComboBox_Classroom1_Time.Text = classroom.ClassTime;
                    this.TextBox_Classroom1_Duration.Text = classroom.ClassDuration.ToString();

                    if (teacher != null)
                    {
                        this.ComboBox_Classroom1_Teacher.Text = teacher.ToString();
                    }
                }
            }
        }

        private void updateComboBoxClassroom1Time(DateTime date)
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

        private void updateGroupBoxClassroom2(int duration)
        {
            this.TextBox_Classroom2_Duration.Text = duration.ToString();
        }

        private void updateGroupBoxClassroom2(Enrollment enrollment)
        {
            if (enrollment != null)
            {
                int numberOfClassroom = enrollment.ClassroomList.Count;

                if (numberOfClassroom > 1)
                {
                    Classroom classroom = enrollment.ClassroomList[1];
                    Teacher teacher = TeacherManager.findTeacher(classroom.TeacherId);

                    this.DateTimePicker_Classroom2_StartDate.Value = classroom.StartDate;
                    this.updateComboBoxClassroom2Time(DateTimePicker_Classroom2_StartDate.Value);
                    this.ComboBox_Classroom2_Time.Text = classroom.ClassTime;
                    this.TextBox_Classroom2_Duration.Text = classroom.ClassDuration.ToString();

                    if (teacher != null)
                    {
                        this.ComboBox_Classroom2_Teacher.Text = teacher.ToString();
                    }
                }
            }
        }

        private void updateComboBoxClassroom2Time(DateTime date)
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

        private void updateComboBoxTeacher(int courseId)
        {
            this.teacherList.Clear();
            this.ComboBox_Classroom1_Teacher.Items.Clear();
            this.ComboBox_Classroom2_Teacher.Items.Clear();

            List<int> teacherIdList = TeachingCourseManager.getTeacherIdByCourseId(courseId);
            for (int i = 0; i < teacherIdList.Count; i++)
            {
                Teacher tempTeacher = TeacherManager.findTeacher(teacherIdList[i]);
                if (tempTeacher != null)
                {
                    if (tempTeacher.Status == Teacher.TeacherStatus.ACTIVE.ToString())
                    {
                        this.teacherList.Add(tempTeacher);

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

        private void updateButtonSubmit()
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

            if (this.CheckBox_Discount.Checked == true)
            {
                if (this.TextBox_Discount.Text == "")
                {
                    isEnableButtonSubmit = false;
                }
            }

            this.enableButtonSubmit(isEnableButtonSubmit);
        }

        private Classroom createClassroom1()
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

        private Classroom createClassroom2()
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

        private int getNumberOfClassroomDetail(Enrollment enrollment)
        {
            int numberOfClassroomDetail = -1;

            if (enrollment != null)
            {
                for (int i = 0; i < enrollment.ClassroomList.Count; i++)
                {
                    int classroomId = enrollment.ClassroomList[i].Id;

                    if (numberOfClassroomDetail == -1)
                    {
                        numberOfClassroomDetail = enrollment.ClassroomIdClassroomDetailListDictionary[classroomId].Count;
                    }
                    else
                    {
                        numberOfClassroomDetail += enrollment.ClassroomIdClassroomDetailListDictionary[classroomId].Count;
                    }                    
                }
            }

            return numberOfClassroomDetail;
        }

        private void TextBox_CourseBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string barcodeText = this.TextBox_CourseBarcode.Text;

                if ((barcodeText != "") && (ValidateManager.isNumber(barcodeText) == true))
                {
                    int courseId = Convert.ToInt32(barcodeText);
                    Course course = CourseManager.findCourse(courseId);

                    if (course != null)
                    {
                        this.updateCourseInfo(course);
                    }
                }

                this.TextBox_CourseBarcode.Text = "";
            }            
        }

        private void Button_SearchCourse_Click(object sender, EventArgs e)
        {
            SearchCoursePopUp searchCoursePopUp = new SearchCoursePopUp();
            Course course = searchCoursePopUp.showFormDialog(this);

            if (course != null)
            {
                this.updateCourseInfo(course);
            }
        }

        private void CheckBox_Discount_CheckedChanged(object sender, EventArgs e)
        {
            bool isEnable = this.CheckBox_Discount.Checked;

            this.enableTextBoxDiscount(isEnable);

            this.updateButtonSubmit();
        }

        private void TextBox_Discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_Discount_TextChanged(object sender, EventArgs e)
        {
            this.updateButtonSubmit();
        }

        private void RadioButton_OneClassPerWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_OneClassPerWeek.Checked)
            {
                this.enableGroupBoxClassroom1(true);
                this.enableGroupBoxClassroom2(false);
                this.updateButtonSubmit();
            }
        }

        private void RadioButton_TwoClassPerWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_TwoClassPerWeek.Checked)
            {
                this.enableGroupBoxClassroom1(true);
                this.enableGroupBoxClassroom2(true);
                this.updateButtonSubmit();
            }
        }

        private void RadioButton_TwoClassPerDay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_TwoClassPerDay.Checked)
            {
                this.DateTimePicker_Classroom2_StartDate.Value = this.DateTimePicker_Classroom1_StartDate.Value;
                this.updateComboBoxClassroom2Time(this.DateTimePicker_Classroom2_StartDate.Value);
                this.updateButtonSubmit();

                this.enableGroupBoxClassroom1(true);                
                this.enableGroupBoxClassroom2(false, true, true, true);                
            }
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            this.reset();
        }

        private void Button_Submit_Click(object sender, EventArgs e)
        {
            if (this.course != null)
            {
                this.enrollment = new Enrollment(this.course);
                this.enrollment.Course = this.course;
                this.enrollment.EnrolledDate = DateTime.Today;
                this.enrollment.Status = Enrollment.EnrollmentStatus.NOT_PAID.ToString();
                this.enrollment.addClassroom(this.createClassroom1());
                this.enrollment.addClassroom(this.createClassroom2());                                                

                if (this.enrollment.ClassroomList.Count > 0)
                {
                    int numberOfClassroomDetail = Convert.ToInt32(this.ComboBox_NumberOfClassroomDetail.Text);

                    this.enrollment.ClassroomIdClassroomDetailListDictionary = ClassroomDetailManager.generateClassroomDetail(this.enrollment.ClassroomList, this.enrollment.Course, numberOfClassroomDetail);
                    this.Close();
                }                

                int actualNumberOfClassroom = Convert.ToInt32(this.ComboBox_NumberOfClassroomDetail.Text);
                if (actualNumberOfClassroom == this.enrollment.Course.NumberOfClassroom)
                {
                    this.enrollment.TotalPrice = this.enrollment.Course.Price;
                }
                else
                {
                    if ((this.enrollment.Course.Price % this.enrollment.Course.NumberOfClassroom) == 0)
                    {
                        this.enrollment.TotalPrice = (this.enrollment.Course.Price / this.enrollment.Course.NumberOfClassroom) * actualNumberOfClassroom;
                    }
                    else
                    {
                        this.enrollment.TotalPrice = Math.Ceiling((this.enrollment.Course.Price / this.enrollment.Course.NumberOfClassroom) * actualNumberOfClassroom);
                    }
                }

                if (this.CheckBox_Discount.Checked == true)
                {
                    this.enrollment.Discount = Convert.ToDouble(this.TextBox_Discount.Text); ;
                }
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.enrollment = null;
            this.Close();
        }

        private void DateTimePicker_Classroom1_StartDate_ValueChanged(object sender, EventArgs e)
        {
            this.updateComboBoxClassroom1Time(this.DateTimePicker_Classroom1_StartDate.Value);

            if (this.RadioButton_TwoClassPerDay.Checked)
            {
                this.DateTimePicker_Classroom2_StartDate.Value = this.DateTimePicker_Classroom1_StartDate.Value;
                this.updateComboBoxClassroom2Time(this.DateTimePicker_Classroom1_StartDate.Value);
            }
        }

        private void DateTimePicker_Classroom2_StartDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.GroupBox_Classroom2.Enabled)
            {
                this.updateComboBoxClassroom2Time(this.DateTimePicker_Classroom2_StartDate.Value);
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
            this.updateButtonSubmit();
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
            this.updateButtonSubmit();
        }

        private void ComboBox_Classroom1_Teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            Teacher teacher = this.teacherList[this.ComboBox_Classroom1_Teacher.SelectedIndex];

            if (teacher != null)
            {
                if ((teacher.Settings & Teacher.TeacherSettings.TEACHES_45_MIN) != 0)
                {
                    this.updateGroupBoxClassroom1(45);
                }
                else
                {
                    this.updateGroupBoxClassroom1(this.course.ClassroomDuration);
                }
            }
        }

        private void ComboBox_Classroom2_Teacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            Teacher teacher = this.teacherList[this.ComboBox_Classroom2_Teacher.SelectedIndex];

            if (teacher != null)
            {
                if ((teacher.Settings & Teacher.TeacherSettings.TEACHES_45_MIN) != 0)
                {
                    this.updateGroupBoxClassroom2(45);
                }
                else
                {
                    this.updateGroupBoxClassroom2(this.course.ClassroomDuration);
                }
            }
        }                                        
    }
}
