using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Constant;
using PianoForte.DatasetModel;
using PianoForte.Interface;
using PianoForte.Manager;
using PianoForte.Model;
using PianoForte.Report;

namespace PianoForte.View
{
    public partial class TeacherProfileForm : Form
    {
        private Teacher teacher;        
        private List<string> courseNameList;

        public TeacherProfileForm()
        {
            InitializeComponent();
        }

        private void TeacherProfileForm_Load(object sender, EventArgs e)
        {
            //Do Nothing
        }

        public void showFormDialog(Teacher teacher, bool isEditMode)
        {
            this.teacher = new Teacher();
            this.courseNameList = new List<string>();

            this.ComboBox_Status.Items.Clear();
            this.ComboBox_Status.Items.Add(Teacher.TeacherStatus.ACTIVE.ToString());
            this.ComboBox_Status.Items.Add(Teacher.TeacherStatus.RESIGNED.ToString());

            this.ListBox_CourseName.Items.Clear();
            this.ListBox_TeachingCourse.Items.Clear();

            this.courseNameList = CourseManager.getAllActiveCourseName();
            for (int i = 0; i < this.courseNameList.Count; i++)
            {
                this.ListBox_CourseName.Items.Add(this.courseNameList[i]);
            }

            this.setup(teacher, isEditMode);

            this.ShowDialog();
        }

        public void setup(Teacher teacher, bool isEditMode)
        {
            this.teacher = teacher;
            //this.teacher.TeachingCourseIdList = TeacherManager.getCourseIdByTeacherId(this.teacher.Id);
            this.teacher.TeachingCourseIdList = TeachingCourseManager.getCourseIdByTeacherId(this.teacher.Id);

            this.TextBox_ID.Text = this.teacher.Id.ToString();
            
            if (this.teacher.Status == Teacher.TeacherStatus.ACTIVE.ToString())
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }
            else if (this.teacher.Status == Teacher.TeacherStatus.RESIGNED.ToString())
            {
                this.ComboBox_Status.SelectedIndex = 1;
            }

            this.TextBox_Firstname.Text = this.teacher.Firstname;
            this.TextBox_Lastname.Text = this.teacher.Lastname;
            this.TextBox_Nickname.Text = this.teacher.Nickname;
            this.TextBox_Email.Text = this.teacher.Email;

            List<string> tempPhoneList = new List<string>();

            TextBox_Phone1_All.Text = this.teacher.Phone1;
            tempPhoneList = ConvertManager.toInputPhoneNumber(this.teacher.Phone1);
            TextBox_Phone1_1.Text = tempPhoneList[0];
            TextBox_Phone1_2.Text = tempPhoneList[1];

            TextBox_Phone2_All.Text = this.teacher.Phone2;
            tempPhoneList = ConvertManager.toInputPhoneNumber(this.teacher.Phone2);
            TextBox_Phone2_1.Text = tempPhoneList[0];
            TextBox_Phone2_2.Text = tempPhoneList[1];

            TextBox_Phone3_All.Text = this.teacher.Phone3;
            tempPhoneList = ConvertManager.toInputPhoneNumber(this.teacher.Phone3);
            TextBox_Phone3_1.Text = tempPhoneList[0];
            TextBox_Phone3_2.Text = tempPhoneList[1];

            this.ListBox_TeachingCourse.Items.Clear();
            List<string> teachingCourseNameList = new List<string>();
            for (int i = 0; i < this.teacher.TeachingCourseIdList.Count; i++)
            {
                Course course = CourseManager.findCourse(this.teacher.TeachingCourseIdList[i]);
                if (course != null)
                {
                    if (teachingCourseNameList.Count == 0)
                    {
                        teachingCourseNameList.Add(course.Name);
                    }
                    else
                    {
                        bool isDuplicate = false;

                        for (int j = 0; j < teachingCourseNameList.Count; j++)
                        {
                            if (course.Name == teachingCourseNameList[j])
                            {
                                isDuplicate = true;
                                break;
                            }
                        }

                        if (!isDuplicate)
                        {
                            teachingCourseNameList.Add(course.Name);
                        }
                    }
                }
            }

            for (int i = 0; i < teachingCourseNameList.Count; i++)
            {
                this.addTeachingCourse(teachingCourseNameList[i]);
            }

            this.ListBox_CourseName.ClearSelected();
            this.ListBox_TeachingCourse.ClearSelected();

            if ((this.teacher.Settings & Teacher.TeacherSettings.TEACHES_45_MIN) != 0)
            {
                this.CheckBox_IsFourtyFiveMinutes.Checked = true;
            }

            this.enableEditmode(isEditMode);
        }

        private void addTeachingCourse(string courseName)
        {
            this.ListBox_CourseName.Items.Remove(courseName);
            this.ListBox_TeachingCourse.Items.Add(courseName);
        }

        private void removeTeachingCourse(string courseName)
        {
            this.ListBox_CourseName.Items.Add(courseName);
            this.ListBox_TeachingCourse.Items.Remove(courseName);
        }

        private void enableEditmode(bool isEditMode)
        {
            this.Button_Edit_GeneralInfo.Visible = !isEditMode;
            this.Button_Submit_Edit_GeneralInfo.Visible = isEditMode;
            this.Button_Cancel_Edit_GeneralInfo.Visible = isEditMode;

            this.ComboBox_Status.Enabled = isEditMode;
            this.TextBox_Firstname.Enabled = isEditMode;
            this.TextBox_Lastname.Enabled = isEditMode;
            this.TextBox_Nickname.Enabled = isEditMode;
            this.TextBox_Email.Enabled = isEditMode;

            this.TextBox_Phone1_All.Visible = !isEditMode;
            this.TextBox_Phone2_All.Visible = !isEditMode;
            this.TextBox_Phone3_All.Visible = !isEditMode;

            this.TextBox_Phone1_1.Visible = isEditMode;
            this.Label_Between_Phone1.Visible = isEditMode;
            this.TextBox_Phone1_2.Visible = isEditMode;

            this.TextBox_Phone2_1.Visible = isEditMode;
            this.Label_Between_Phone2.Visible = isEditMode;
            this.TextBox_Phone2_2.Visible = isEditMode;

            this.TextBox_Phone3_1.Visible = isEditMode;
            this.Label_Between_Phone3.Visible = isEditMode;
            this.TextBox_Phone3_2.Visible = isEditMode;

            this.ListBox_CourseName.Enabled = isEditMode;
            this.enableButton_Add(isEditMode);
            this.enableButton_Remove(isEditMode);
            this.ListBox_TeachingCourse.Enabled = isEditMode;

            this.CheckBox_IsFourtyFiveMinutes.Enabled = isEditMode;
        }

        private void enableButton_Add(bool isEnable)
        {
            if (this.ListBox_CourseName.SelectedIndex >= 0)
            {
                this.Button_Add.Enabled = isEnable;
            }
            else
            {
                this.Button_Add.Enabled = false;
            }
        }

        private void enableButton_Remove(bool isEnable)
        {
            if (this.ListBox_TeachingCourse.SelectedIndex >= 0)
            {
                this.Button_Remove.Enabled = isEnable;
            }
            else
            {
                this.Button_Remove.Enabled = false;
            } 
        }

        private void updateGeneralInfo()
        {
            Teacher tempTeacher = new Teacher(this.teacher);
            tempTeacher.Firstname = this.TextBox_Firstname.Text;
            tempTeacher.Lastname = this.TextBox_Lastname.Text;
            tempTeacher.Nickname = this.TextBox_Nickname.Text;
            tempTeacher.Email = this.TextBox_Email.Text;
            tempTeacher.Phone1 = this.TextBox_Phone1_1.Text + this.TextBox_Phone1_2.Text;
            tempTeacher.Phone2 = this.TextBox_Phone2_1.Text + this.TextBox_Phone2_2.Text;
            if (tempTeacher.Phone2 == "")
            {
                tempTeacher.Phone2 = this.TextBox_Phone3_1.Text + this.TextBox_Phone3_2.Text;
                tempTeacher.Phone3 = "";
            }
            else
            {
                tempTeacher.Phone3 = this.TextBox_Phone3_1.Text + this.TextBox_Phone3_2.Text;
            }

            tempTeacher.Settings = Teacher.TeacherSettings.NONE;
            if (this.CheckBox_IsFourtyFiveMinutes.Checked)
            {
                tempTeacher.Settings = tempTeacher.Settings | Teacher.TeacherSettings.TEACHES_45_MIN;
            }

            tempTeacher.Status = this.ComboBox_Status.Text;

            tempTeacher.TeachingCourseIdList.Clear();
            for (int i = 0; i < this.ListBox_TeachingCourse.Items.Count; i++)
            {
                string tempCourseName = this.ListBox_TeachingCourse.Items[i].ToString();

                List<Course> tempCourseList = CourseManager.findAllCourseByCourseNameWithoutWildcard(tempCourseName);
                for (int j = 0; j < tempCourseList.Count; j++)
                {
                    tempTeacher.TeachingCourseIdList.Add(tempCourseList[j].Id);
                }
            }

            string result = ValidateManager.validate(tempTeacher);
            if (result == "")
            {
                tempTeacher.Phone1 = ConvertManager.toDisplayPhoneNumber(tempTeacher.Phone1);
                tempTeacher.Phone2 = ConvertManager.toDisplayPhoneNumber(tempTeacher.Phone2);
                tempTeacher.Phone3 = ConvertManager.toDisplayPhoneNumber(tempTeacher.Phone3);

                bool isUpdateComplete = TeacherManager.updateTeacher(tempTeacher);
                if (isUpdateComplete)
                {
                    if (TeachingCourseManager.deleteTeachingCourseByTeacherId(tempTeacher.Id))
                    {
                        bool isAddTeachingCourseComplete = false;

                        for (int i = 0; i < tempTeacher.TeachingCourseIdList.Count; i++)
                        {
                            if (TeachingCourseManager.insertTeachingCourse(tempTeacher.Id, tempTeacher.TeachingCourseIdList[i]))
                            {
                                isAddTeachingCourseComplete = true;
                            }
                            else
                            {
                                isAddTeachingCourseComplete = false;
                                break;
                            }
                        }

                        if (isAddTeachingCourseComplete)
                        {
                            setup(tempTeacher, false);
                            //MessageBox.Show(DatabaseConstant.UPDATE_DATA_SUCCESS);
                        }
                        else
                        {
                            MessageBox.Show(DatabaseConstant.UPDATE_DATA_FAIL);
                        }
                    }
                    else
                    {
                        MessageBox.Show(DatabaseConstant.UPDATE_DATA_FAIL);
                    }                    
                }
                else
                {
                    MessageBox.Show(DatabaseConstant.UPDATE_DATA_FAIL);
                }
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void Button_Edit_GeneralInfo_Click(object sender, EventArgs e)
        {
            this.enableEditmode(true);
        }

        private void Button_Submit_Edit_GeneralInfo_Click(object sender, EventArgs e)
        {
            string text = "คุณต้องการแก้ไขข้อมูลใช่หรือไม่?";
            if (ConfirmDialogBox.show(text))
            {
                this.updateGeneralInfo();
            }            
        }

        private void Button_Cancel_Edit_GeneralInfo_Click(object sender, EventArgs e)
        {
            this.setup(this.teacher, false);
        }

        private DataTable initDataTableDailySalaryHeader()
        {
            DataTable dataTableDailySalaryHeader = new DataTable("daily_salary_header");
            dataTableDailySalaryHeader.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date"));
            dataTableDailySalaryHeader.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, "teacherId"));
            dataTableDailySalaryHeader.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "teacherFirstname"));
            dataTableDailySalaryHeader.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "teacherLastname"));
            dataTableDailySalaryHeader.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DOUBLE, "lateArrival"));

            return dataTableDailySalaryHeader;
        }

        private void ListBox_CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableButton_Add(true);
        }

        private void ListBox_TeachingCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableButton_Remove(true);
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            this.addTeachingCourse(this.ListBox_CourseName.SelectedItem.ToString());
            this.ListBox_CourseName.ClearSelected();
        }

        private void Button_Remove_Click(object sender, EventArgs e)
        {
            this.removeTeachingCourse(this.ListBox_TeachingCourse.SelectedItem.ToString());
            this.ListBox_TeachingCourse.ClearSelected();
        }
        /*
        private DataTable initDataTableDailySalaryDetail()
        {
            DataTable dataTableDailySalaryDetail = new DataTable("daily_salary_detail");
            dataTableDailySalaryDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, "teacherId"));
            dataTableDailySalaryDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, "roomNumber"));
            dataTableDailySalaryDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "startTime"));
            dataTableDailySalaryDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "endTime"));
            dataTableDailySalaryDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "studentName"));
            dataTableDailySalaryDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DOUBLE, "commission"));

            return dataTableDailySalaryDetail;
        }

        private void Button_SearchSalary_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();

            DataTable dataTableDailySalaryHeader = initDataTableDailySalaryHeader();
            DataTable dataTableDailySalaryDetail = initDataTableDailySalaryDetail();

            List<Room> tempRoomList = new List<Room>();
            List<RoomDetail> tempRoomDetailList = RoomDetailManager.findAllRoomDetailByTeacherId(this.teacher.Id);
            double lateArrival = 0;
            
            RoomDetail earliestRoomDetail = RoomDetailManager.getEarliestRoomDetail(tempRoomDetailList, DateTimePicker_Search_Salary.Value.Date);
            if (earliestRoomDetail != null)
            {
                if (earliestRoomDetail.StartTime != earliestRoomDetail.CheckInTime)
                {
                    string minTime = DateTimeManager.getMinTime(earliestRoomDetail.StartTime, earliestRoomDetail.CheckInTime);
                    if (minTime == earliestRoomDetail.StartTime)
                    {
                        lateArrival = 100;
                    }
                }              
            }

            for (int i = 0; i < tempRoomDetailList.Count; i++)
            {
                RoomDetail tempRoomDetail = tempRoomDetailList[i];
                if (tempRoomDetail != null)
                {
                    Room tempRoom = RoomManager.findRoom(tempRoomDetailList[i].RoomId);
                    if (tempRoom != null)
                    {
                        if (tempRoom.Date.Date == DateTimePicker_Search_Salary.Value.Date)
                        {
                            bool isRoomExist = false;

                            for (int j = 0; j < tempRoomList.Count; j++)
                            {
                                if (tempRoom.Id == tempRoomList[j].Id)
                                {
                                    isRoomExist = true;
                                    break;
                                }
                            }
                                          
                            if (!isRoomExist)
                            {
                                tempRoomList.Add(tempRoom);
                            }
                        }
                        else
                        {
                            tempRoomDetailList.Remove(tempRoomDetail);
                            i--;
                        }
                    }
                }                                
            }

            if (tempRoomList.Count > 0)
            {
                dataTableDailySalaryHeader.Rows.Add(DateTimePicker_Search_Salary.Value,
                                                    teacher.Id,
                                                    teacher.Firstname,
                                                    teacher.Lastname,
                                                    lateArrival);
            }

            for (int i = 0; i < tempRoomList.Count; i++)
            {
                Room tempRoom = tempRoomList[i];
                if (tempRoom != null)
                {
                    //List<RoomDetail> tempRoomDetailList = RoomDetailManager.getAllRoomDetail(tempRoom.Id);
                    for (int j = 0; j < tempRoomDetailList.Count; j++)
                    {
                        RoomDetail tempRoomDetail = tempRoomDetailList[j];
                        if (tempRoomDetail != null)
                        {
                            if (tempRoom.Id == tempRoomDetail.RoomId)
                            {
                                //List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.getAllClassroomDetailByRoomDetailId(tempRoomDetailList[j].RoomDetailId);
                                List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.findAllClassroomDetailByRoomDetailId(tempRoomDetailList[j].RoomDetailId);
                                for (int k = 0; k < tempClassroomDetailList.Count; k++)
                                {
                                    Classroom tempClassroom = ClassroomManager.findClassroom(tempClassroomDetailList[k].ClassroomId);
                                    if (tempClassroom != null)
                                    {
                                        Enrollment tempEnrollment = EnrollmentManager.getEnrollment(tempClassroom.EnrollmentId);
                                        if (tempEnrollment != null)
                                        {
                                            if ((tempEnrollment.Student != null) && (tempEnrollment.Course != null))
                                            {
                                                string studentName = tempEnrollment.Student.Firstname + " " + tempEnrollment.Student.Lastname + "(" + tempEnrollment.Student.Nickname + ")";
                                                double commmission = ((tempEnrollment.Course.Price / tempEnrollment.Course.NumberOfClassroom) * tempClassroomDetailList[k].Commission) / 100;

                                                dataTableDailySalaryDetail.Rows.Add(teacher.Id,
                                                                                    tempRoom.Number,
                                                                                    tempClassroomDetailList[k].ClassroomTime,
                                                                                    DateTimeManager.addMinute(tempClassroomDetailList[k].ClassroomTime, tempEnrollment.Course.ClassroomDuration),
                                                                                    studentName,
                                                                                    commmission);
                                            }
                                        }
                                    }
                                }
                            }
                        }                                                
                    }

                    DailySalaryReport dailySalaryReport = new DailySalaryReport();
                    dailySalaryReport.Database.Tables["daily_salary_header"].SetDataSource(dataTableDailySalaryHeader);
                    if (dataTableDailySalaryHeader.Rows.Count > 0)
                    {
                        dailySalaryReport.Database.Tables["daily_salary_detail"].SetDataSource(dataTableDailySalaryDetail);
                    }

                    this.CrystalReportViewer_Salary.ReportSource = dailySalaryReport;
                }
            }            
        }

        private void Button_Print_Click(object sender, EventArgs e)
        {
            //To Do
        }  
        */
    }
}
