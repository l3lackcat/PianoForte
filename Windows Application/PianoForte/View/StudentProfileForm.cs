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
    public partial class StudentProfileForm : Form
    {
        private MainForm mainForm;
        private Student student;
        private List<Enrollment> currentEnrolledCourseList;
        private List<Enrollment> previousEnrolledCourseList;
        private List<ClassroomDetail> classroomDetailList;
        private string selectedEnrolledCourseName;
        private string selectedEnrolledCourseLevel;

        public StudentProfileForm()
        {
            InitializeComponent();
        }

        private void StudentProfileForm_Load(object sender, EventArgs e)
        {
            //Do Nothing
        }

        public void showFormDialog(Student student, MainForm mainForm, bool isEditMode)
        {
            this.mainForm = mainForm;

            this.student = new Student();
            this.currentEnrolledCourseList = new List<Enrollment>();
            this.previousEnrolledCourseList = new List<Enrollment>();
            this.classroomDetailList = new List<ClassroomDetail>();
            this.selectedEnrolledCourseName = "";
            this.selectedEnrolledCourseLevel = "";

            this.ComboBox_Status.Items.Clear();
            this.ComboBox_Status.Items.Add(Student.StudentStatus.ACTIVE.ToString());
            this.ComboBox_Status.Items.Add(Student.StudentStatus.INACTIVE.ToString());
            this.ComboBox_Status.Items.Add(Student.StudentStatus.DROPPED.ToString());

            this.DatagridView_CurrentCourse.AutoGenerateColumns = false;
            this.DataGridView_PreviousCourse.AutoGenerateColumns = false;
            this.DataGridView_ClassroomDetail.AutoGenerateColumns = false;

            this.setup(student, isEditMode);

            this.ShowDialog();
        }            

        public void setup(Student student, bool isEditMode)
        {
            this.student = student;

            this.TextBox_Id.Text = this.student.Id.ToString();
            this.TextBox_RegisterDate.Text = String.Format("{0:dd MMMM yyyy}", this.student.RegisteredDate);
            if (this.student.Status == Student.StudentStatus.ACTIVE.ToString())
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }
            else if (this.student.Status == Student.StudentStatus.INACTIVE.ToString())
            {
                this.ComboBox_Status.SelectedIndex = 1;
            }
            else if (this.student.Status == Student.StudentStatus.DROPPED.ToString())
            {
                this.ComboBox_Status.SelectedIndex = 2;
            }
            this.TextBox_Firstname.Text = this.student.Firstname;
            this.TextBox_Lastname.Text = this.student.Lastname;
            this.TextBox_Nickname.Text = this.student.Nickname;
            this.DateTimePicker_Birthday.Value = this.student.Birthday;
            this.TextBox_Age.Text = (DateTime.Today.Year - this.student.Birthday.Year).ToString();
            this.TextBox_Address1.Text = this.student.Address.Address1;
            this.TextBox_Address2.Text = this.student.Address.Address2;
            this.TextBox_PostCode.Text = this.student.Address.PostCode.ToString();
            this.TextBox_Email.Text = this.student.Email;

            List<string> tempPhoneList = new List<string>();

            TextBox_Phone1_All.Text = this.student.Phone1;
            tempPhoneList = ConvertManager.toInputPhoneNumber(this.student.Phone1);
            TextBox_Phone1_1.Text = tempPhoneList[0];
            TextBox_Phone1_2.Text = tempPhoneList[1];

            TextBox_Phone2_All.Text = this.student.Phone2;
            tempPhoneList = ConvertManager.toInputPhoneNumber(this.student.Phone2);
            TextBox_Phone2_1.Text = tempPhoneList[0];
            TextBox_Phone2_2.Text = tempPhoneList[1];

            TextBox_Phone3_All.Text = this.student.Phone3;
            tempPhoneList = ConvertManager.toInputPhoneNumber(this.student.Phone3);
            TextBox_Phone3_1.Text = tempPhoneList[0];
            TextBox_Phone3_2.Text = tempPhoneList[1];

            enableEditmode(isEditMode);
            initEnrolledCourse();
            initClassroomDetailList(0);
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
            this.DateTimePicker_Birthday.Enabled = isEditMode;
            this.TextBox_Email.Enabled = isEditMode;
            this.TextBox_Address1.Enabled = isEditMode;
            this.TextBox_Address2.Enabled = isEditMode;
            this.TextBox_PostCode.Enabled = isEditMode;

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
        }

        private void initEnrolledCourse()
        {
            this.currentEnrolledCourseList.Clear();
            this.previousEnrolledCourseList.Clear();

            List<Enrollment> enrollmentList = EnrollmentManager.findAllEnrollmentByStudentId(this.student.Id);
            for (int i = 0; i < enrollmentList.Count; i++)
            {
                Enrollment tempEnrollment = enrollmentList[i];
                if (tempEnrollment != null)
                {
                    if (tempEnrollment.Status != Enrollment.EnrollmentStatus.CANCELED.ToString())
                    {
                        bool isActive = false;
                        List<Classroom> classroomList = ClassroomManager.findAllClassroom(tempEnrollment.Id);
                        for (int j = 0; j < classroomList.Count; j++)
                        {
                            if (classroomList[j].Status == Classroom.ClassroomStatus.ACTIVE.ToString())
                            {
                                isActive = true;
                                break;
                            }
                        }

                        if (isActive)
                        {
                            this.currentEnrolledCourseList.Add(tempEnrollment);
                        }
                        else
                        {
                            this.previousEnrolledCourseList.Add(tempEnrollment);
                        }
                    }                    
                }                                
            }

            refreshDatagridView_EnrolledCourse();
        }

        private void refreshDatagridView_EnrolledCourse()
        {
            this.refreshDatagridView_CurrentCourse();
            this.refreshDataGridView_PreviousCourse();

            this.selectedEnrolledCourseName = "";
            this.selectedEnrolledCourseLevel = "";
        }

        private void refreshDatagridView_CurrentCourse()
        {
            this.DatagridView_CurrentCourse.Rows.Clear();

            for (int i = 0; i < this.currentEnrolledCourseList.Count; i++)
            {
                int n = this.DatagridView_CurrentCourse.Rows.Add();
                this.DatagridView_CurrentCourse.Rows[n].Cells["CurrentCourse_EnrollmentId"].Value = this.currentEnrolledCourseList[i].Id;
                this.DatagridView_CurrentCourse.Rows[n].Cells["CurrentCourse_CourseName"].Value = this.currentEnrolledCourseList[i].Course.Name;
                this.DatagridView_CurrentCourse.Rows[n].Cells["CurrentCourse_CourseLevel"].Value = this.currentEnrolledCourseList[i].Course.Level;
                this.DatagridView_CurrentCourse.Rows[n].Cells["CurrentCourse_EnrolledDate"].Value = this.currentEnrolledCourseList[i].EnrolledDate.ToShortDateString();
                this.DatagridView_CurrentCourse.Rows[n].Cells["CurrentCourse_Status"].Value = this.currentEnrolledCourseList[i].Status;

                this.DatagridView_CurrentCourse.Rows[n].Cells["CurrentCourse_TransactionButton"].Value = new Bitmap(20, 16);
                this.DatagridView_CurrentCourse.Rows[n].Cells["CurrentCourse_DeleteButton"].Value = new Bitmap(20, 16);
                //if (this.currentEnrolledCourseList[i].Status != Enrollment.EnrollmentStatus.NOT_PAID.ToString())
                //{                                        
                //    this.DatagridView_CurrentCourse.Rows[n].Cells["CurrentCourse_DeleteButton"].Value = new Bitmap(20, 16);
                //}
            }

            this.DatagridView_CurrentCourse.ClearSelection();
        }

        private void refreshDataGridView_PreviousCourse()
        {
            this.DataGridView_PreviousCourse.Rows.Clear();

            for (int i = 0; i < this.previousEnrolledCourseList.Count; i++)
            {
                int n = this.DataGridView_PreviousCourse.Rows.Add();
                this.DataGridView_PreviousCourse.Rows[n].Cells["PreviousCourse_EnrollmentId"].Value = this.previousEnrolledCourseList[i].Id;
                this.DataGridView_PreviousCourse.Rows[n].Cells["PreviousCourse_CourseName"].Value = this.previousEnrolledCourseList[i].Course.Name;
                this.DataGridView_PreviousCourse.Rows[n].Cells["PreviousCourse_CourseLevel"].Value = this.previousEnrolledCourseList[i].Course.Level;
                this.DataGridView_PreviousCourse.Rows[n].Cells["PreviousCourse_EnrolledDate"].Value = this.previousEnrolledCourseList[i].EnrolledDate.ToShortDateString();
                this.DataGridView_PreviousCourse.Rows[n].Cells["PreviousCourse_Status"].Value = this.previousEnrolledCourseList[i].Status;
            }

            this.DataGridView_PreviousCourse.ClearSelection();
        }

        private void initClassroomDetailList(int enrollmentId)
        {
            this.classroomDetailList.Clear();

            List<Classroom> tempClassroomList = ClassroomManager.findAllClassroom(enrollmentId);
            for (int i = 0; i < tempClassroomList.Count; i++)
            {
                Classroom tempClassroom = tempClassroomList[i];
                if (tempClassroom != null)
                {
                    if (tempClassroom.Status != Classroom.ClassroomStatus.CANCELED.ToString())
                    {
                        List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(tempClassroom.Id);
                        for (int j = 0; j < tempClassroomDetailList.Count; j++)
                        {
                            this.classroomDetailList.Add(tempClassroomDetailList[j]);
                        }
                    }                    
                }
            }

            if (this.classroomDetailList.Count > 1)
            {
                this.classroomDetailList = ClassroomDetailManager.sortClassroomDetailListByClassroomNo(this.classroomDetailList);
            }            

            this.refreshDataGridView_ClassroomDetail();
        }        

        private void refreshDataGridView_ClassroomDetail()
        {
            this.DataGridView_ClassroomDetail.Rows.Clear();

            for (int i = 0; i < this.classroomDetailList.Count; i++)
            {
                int n = this.DataGridView_ClassroomDetail.Rows.Add();
                this.DataGridView_ClassroomDetail.Rows[n].Cells["ClassroomNo"].Value = this.classroomDetailList[i].ClassroomNo;
                this.DataGridView_ClassroomDetail.Rows[n].Cells["ClassroomDate"].Value = this.classroomDetailList[i].ClassroomDate.ToShortDateString();
                this.DataGridView_ClassroomDetail.Rows[n].Cells["DisplayStatus"].Value = this.classroomDetailList[i].DisplayStatus;                
            }

            this.DataGridView_ClassroomDetail.ClearSelection();

        }

        private void updateGeneralInFo()
        {
            Address address = new Address();
            address.Address1 = this.TextBox_Address1.Text;
            address.Address2 = this.TextBox_Address2.Text;
            address.PostCode = Convert.ToInt32(this.TextBox_PostCode.Text);

            Student tempStudent = new Student(this.student);
            tempStudent.Firstname = this.TextBox_Firstname.Text;
            tempStudent.Lastname = this.TextBox_Lastname.Text;
            tempStudent.Nickname = this.TextBox_Nickname.Text;
            tempStudent.Birthday = Convert.ToDateTime(this.DateTimePicker_Birthday.Text);
            tempStudent.Address = address;
            tempStudent.Phone1 = this.TextBox_Phone1_1.Text + this.TextBox_Phone1_2.Text;
            tempStudent.Phone2 = this.TextBox_Phone2_1.Text + this.TextBox_Phone2_2.Text;
            if (tempStudent.Phone2 == "")
            {
                tempStudent.Phone2 = this.TextBox_Phone3_1.Text + this.TextBox_Phone3_2.Text;
                tempStudent.Phone3 = "";
            }
            else
            {
                tempStudent.Phone3 = this.TextBox_Phone3_1.Text + this.TextBox_Phone3_2.Text;
            }
            tempStudent.Email = this.TextBox_Email.Text;
            tempStudent.Status = this.ComboBox_Status.Text;

            string result = ValidateManager.validate(tempStudent);
            if (result == "")
            {
                this.student = tempStudent;
                this.student.Phone1 = ConvertManager.toDisplayPhoneNumber(this.student.Phone1);
                this.student.Phone2 = ConvertManager.toDisplayPhoneNumber(this.student.Phone2);
                this.student.Phone3 = ConvertManager.toDisplayPhoneNumber(this.student.Phone3);

                bool isSuccess = StudentManager.updateStudent(this.student);
                if (isSuccess)
                {
                    setup(this.student, false);
                    //MessageBox.Show(DatabaseConstant.UPDATE_DATA_SUCCESS);
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
                this.updateGeneralInFo();
            }            
        }               

        private void Button_Cancel_Edit_GeneralInfo_Click(object sender, EventArgs e)
        {
            setup(this.student, false);
            enableEditmode(false);
        }

        private void DatagridView_CurrentCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 5:
                        {
                            //if (this.currentEnrolledCourseList[e.RowIndex].Status == Enrollment.EnrollmentStatus.NOT_PAID.ToString())
                            //{
                            //    if (ConfirmDialogBox.show("คุณต้องการทำรายการการลงทะเบียนรหัส " + this.currentEnrolledCourseList[e.RowIndex].Id.ToString() + " ใช่หรือไม่?"))
                            //    {
                            //        MainForm.paymentForm.searchEnrollment(this.currentEnrolledCourseList[e.RowIndex].Id);
                            //        this.mainForm.switchForm(MainForm.paymentForm);
                            //        this.Close();
                            //    }
                            //}
                        }
                        break;
                    case 6:
                        {
                            //if (this.currentEnrolledCourseList[e.RowIndex].Status == Enrollment.EnrollmentStatus.NOT_PAID.ToString())
                            //{
                            //    if (ConfirmDialogBox.show("คุณต้องการยกเลิกการลงทะเบียนรหัส " + this.currentEnrolledCourseList[e.RowIndex].Id.ToString() + " ใช่หรือไม่?"))
                            //    {
                            //        if (EnrollmentManager.cancelEnrollment(EnrollmentManager.getEnrollment(this.currentEnrolledCourseList[e.RowIndex].Id)))
                            //        {
                            //            this.initEnrolledCourse();
                            //            this.initClassroomDetailList(0);
                            //        }
                            //        else
                            //        {
                            //            MessageBox.Show(PianoForte.Constant.DatabaseConstant.DELETE_DATA_FAIL);
                            //        }
                            //    } 
                            //}
                        }
                        break;
                    default:
                        {
                            this.selectedEnrolledCourseName = this.DatagridView_CurrentCourse.Rows[e.RowIndex].Cells["CurrentCourse_CourseName"].Value.ToString();
                            this.selectedEnrolledCourseLevel = this.DatagridView_CurrentCourse.Rows[e.RowIndex].Cells["CurrentCourse_CourseLevel"].Value.ToString();
                            this.initClassroomDetailList(this.currentEnrolledCourseList[e.RowIndex].Id);
                        }
                        break;
                }
            }

            this.Cursor = Cursors.Arrow;
        } 

        private void DatagridView_CurrentCourse_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    switch (e.ColumnIndex)
            //    {
            //        case 4:
            //            {
            //                if (this.currentEnrolledCourseList[e.RowIndex].Status == Enrollment.EnrollmentStatus.NOT_PAID.ToString())
            //                {
            //                    //this.Cursor = Cursors.Hand;
            //                    //this.DatagridView_CurrentCourse.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "";
            //                }
            //            }
            //            break;
            //        case 5:
            //            {
            //                if (this.currentEnrolledCourseList[e.RowIndex].Status == Enrollment.EnrollmentStatus.NOT_PAID.ToString())
            //                {
            //                    //this.Cursor = Cursors.Hand;
            //                    //this.DatagridView_CurrentCourse.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Delete";
            //                }
            //            }
            //            break;
            //    }
            //}
        }

        private void DatagridView_CurrentCourse_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void DataGridView_PreviousCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.selectedEnrolledCourseName = this.DataGridView_PreviousCourse.Rows[e.RowIndex].Cells["PreviousCourse_CourseName"].Value.ToString();
                this.selectedEnrolledCourseLevel = this.DataGridView_PreviousCourse.Rows[e.RowIndex].Cells["PreviousCourse_CourseLevel"].Value.ToString();
                this.initClassroomDetailList(this.previousEnrolledCourseList[e.RowIndex].Id);
            }
        } 

        private void Button_Add_Enrollment_Click(object sender, EventArgs e)
        {
            EnrollmentForm enrollmentForm = new EnrollmentForm();
            Enrollment enrollment = enrollmentForm.showFormDialog();
            if (enrollment != null)
            {
                enrollment.Student = this.student;
                if (EnrollmentManager.processEnrollment(enrollment))
                {
                    //MessageBox.Show(DatabaseConstant.INSERT_DATA_SUCCESS);
                    this.initEnrolledCourse();
                    this.refreshDatagridView_EnrolledCourse();
                }                
            }            
        }

        private void Button_Show_ClassroomDetail_Click(object sender, EventArgs e)
        {
            int rowNumber = this.DataGridView_ClassroomDetail.CurrentRow.Index;

            ClassroomDetail tempClassroomDetail = this.classroomDetailList[rowNumber];
            if (tempClassroomDetail != null)
            {
                ClassroomDetailForm classroomDetailForm = new ClassroomDetailForm();
                classroomDetailForm.showFormDialog(tempClassroomDetail, this.selectedEnrolledCourseName, this.selectedEnrolledCourseLevel);

                int tempEnrollmentId = Convert.ToInt32(this.DatagridView_CurrentCourse.Rows[this.DatagridView_CurrentCourse.CurrentRow.Index].Cells[0].Value);               
                this.initClassroomDetailList(tempEnrollmentId);
            }
        }

        private void DataGridView_ClassroomDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 3:
                        {
                            ClassroomDetail tempClassroomDetail = this.classroomDetailList[e.RowIndex];
                            if (tempClassroomDetail != null)
                            {
                                ClassroomDetailForm classroomDetailForm = new ClassroomDetailForm();
                                classroomDetailForm.showFormDialog(tempClassroomDetail, this.selectedEnrolledCourseName, this.selectedEnrolledCourseLevel);

                                if (this.tabControl1.SelectedIndex == 0)
                                {
                                    int rowIndex = this.DatagridView_CurrentCourse.CurrentRow.Index;
                                    int tempEnrollmentId = Convert.ToInt32(this.DatagridView_CurrentCourse.Rows[rowIndex].Cells["CurrentCourse_EnrollmentId"].Value);
                                    this.initClassroomDetailList(tempEnrollmentId);
                                }
                                else if (this.tabControl1.SelectedIndex == 1)
                                {
                                    int rowIndex = this.DataGridView_PreviousCourse.CurrentRow.Index;
                                    int tempEnrollmentId = Convert.ToInt32(this.DataGridView_PreviousCourse.Rows[rowIndex].Cells["PreviousCourse_EnrollmentId"].Value);
                                    this.initClassroomDetailList(tempEnrollmentId);
                                }
                            }
                        }
                        break;
                }
            }

            this.Cursor = Cursors.Arrow;
        } 

        private void DataGridView_ClassroomDetail_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3)
                {
                    this.Cursor = Cursors.Hand;
                }
            }
        }

        private void DataGridView_ClassroomDetail_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }                                                               
    }
}
