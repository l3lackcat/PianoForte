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
    public partial class SetupCheckInForm : Form
    {
        private ClassroomForm classroomForm;

        public SetupCheckInForm()
        {
            InitializeComponent();
        }

        public void showFormDialog(ClassroomForm classroomForm)
        {
            this.classroomForm = classroomForm;

            this.setupComponent();
            this.ShowDialog();
        }

        public void setupComponent()
        {
            Room tempRoom = this.classroomForm.getRoom();                           
            if (tempRoom != null)
            {
                string roomNumberText = "ห้องเบอร์ " + ConvertManager.toStringRoomNumber(tempRoom.Number);
                this.Text = roomNumberText;
                this.Label_RoomNumber.Text = roomNumberText;
                this.refreshDataGridView_TeacherDetail();
            }
        }

        private void refreshDataGridView_TeacherDetail()
        {
            this.DataGridView_TeacherDetail.Rows.Clear();

            List<RoomDetail> tempRoomDetailList = this.classroomForm.getRoomDetailList();
            for (int i = 0; i < tempRoomDetailList.Count; i++)
            {
                RoomDetail tempRoomDetail = tempRoomDetailList[i];
                if (tempRoomDetail != null)
                {
                    string teacherName = "";

                    Teacher tempTeacher = TeacherManager.findTeacher(tempRoomDetail.TeacherId);
                    if (tempTeacher != null)
                    {
                        teacherName = "อ." + tempTeacher.Firstname + " (ครู" + tempTeacher.Nickname + ")";
                    }

                    int n = this.DataGridView_TeacherDetail.Rows.Add();
                    this.DataGridView_TeacherDetail.Rows[n].Cells["TeacherName"].Value = teacherName;
                    this.DataGridView_TeacherDetail.Rows[n].Cells["StartTime"].Value = tempRoomDetail.StartTime;
                    this.DataGridView_TeacherDetail.Rows[n].Cells["EndTime"].Value = tempRoomDetail.EndTime;
                }
            }

            this.DataGridView_TeacherDetail.ClearSelection();
            this.DataGridView_ClassroomDetail.Rows.Clear();
        }

        private void refreshDataGridView_ClassroomDetail(RoomDetail roomDetail)
        {
            this.DataGridView_ClassroomDetail.Rows.Clear();

            List<ClassroomDetail> tempClassroomDetailList = new List<ClassroomDetail>();
            string startTime = roomDetail.StartTime;
            string endTime = roomDetail.EndTime;

            List<ClassroomDetail> originalClassroomDetailList = this.classroomForm.getClassroomDetailList(roomDetail.TeacherId);
            for (int i = 0; i < originalClassroomDetailList.Count; i++)
            {
                ClassroomDetail originalClassroomDetail = originalClassroomDetailList[i];
                if (originalClassroomDetail != null)
                {
                    if ((DateTimeManager.isBetweenTimeInterval(startTime, endTime, originalClassroomDetail.ClassroomTime)) &&
                        (DateTimeManager.isBetweenTimeInterval(startTime, endTime, DateTimeManager.addMinute(originalClassroomDetail.ClassroomTime, originalClassroomDetail.ClassroomDuration))))
                    {
                        tempClassroomDetailList.Add(originalClassroomDetail);
                    }
                }
            }
            
            for (int i = 0; i < tempClassroomDetailList.Count; i++)
            {
                ClassroomDetail tempClassroomDetail = tempClassroomDetailList[i];
                if (tempClassroomDetail != null)
                {
                    string studentName = "";

                    Classroom tempClassroom = ClassroomManager.findClassroom(tempClassroomDetail.ClassroomId);
                    if (tempClassroomDetail != null)
                    {
                        Enrollment tempEnrollment = EnrollmentManager.getEnrollment(tempClassroom.EnrollmentId);
                        if (tempEnrollment != null)
                        {
                            if (tempEnrollment.Student != null)
                            {
                                studentName = tempEnrollment.Student.Firstname + " " + tempEnrollment.Student.Lastname + "(" + tempEnrollment.Student.Nickname + ")";
                            }
                        }
                    }

                    string classroomStartTime = tempClassroomDetail.ClassroomTime;
                    string classroomEndTime = "";
                    if (tempClassroomDetail.ClassroomDuration == 55)
                    {
                        classroomEndTime = DateTimeManager.addMinute(classroomStartTime, 60);
                    }
                    else
                    {
                        classroomEndTime = DateTimeManager.addMinute(classroomStartTime, tempClassroomDetail.ClassroomDuration);
                    }

                    if ((startTime != tempClassroomDetail.ClassroomTime) &&
                        (startTime == DateTimeManager.getMinTime(startTime, tempClassroomDetail.ClassroomTime)))
                    {
                        int m = this.DataGridView_ClassroomDetail.Rows.Add();
                        this.DataGridView_ClassroomDetail.Rows[m].Cells["StudentName"].Value = "";
                        this.DataGridView_ClassroomDetail.Rows[m].Cells["ClassroomStartTime"].Value = startTime;
                        this.DataGridView_ClassroomDetail.Rows[m].Cells["ClassroomEndTime"].Value = classroomStartTime;
                        this.DataGridView_ClassroomDetail.Rows[m].Cells["ClassroomStatus"].Value = "ว่าง";
                    }

                    int n = this.DataGridView_ClassroomDetail.Rows.Add();
                    this.DataGridView_ClassroomDetail.Rows[n].Cells["StudentName"].Value = studentName;
                    this.DataGridView_ClassroomDetail.Rows[n].Cells["ClassroomStartTime"].Value = classroomStartTime;
                    this.DataGridView_ClassroomDetail.Rows[n].Cells["ClassroomEndTime"].Value = classroomEndTime;
                    this.DataGridView_ClassroomDetail.Rows[n].Cells["ClassroomStatus"].Value = tempClassroomDetail.DisplayStatus;

                    startTime = classroomEndTime;
                }
            }

            if (tempClassroomDetailList.Count > 0)
            {
                if (startTime != endTime)
                {
                    int m = this.DataGridView_ClassroomDetail.Rows.Add();
                    this.DataGridView_ClassroomDetail.Rows[m].Cells["StudentName"].Value = "";
                    this.DataGridView_ClassroomDetail.Rows[m].Cells["ClassroomStartTime"].Value = startTime;
                    this.DataGridView_ClassroomDetail.Rows[m].Cells["ClassroomEndTime"].Value = endTime;
                    this.DataGridView_ClassroomDetail.Rows[m].Cells["ClassroomStatus"].Value = "ว่าง";
                }
            }           

            this.DataGridView_ClassroomDetail.ClearSelection();
        }

        private void DataGridView_TeacherDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 3:
                        {
                            Room tempRoom = this.classroomForm.getRoom();
                            if (tempRoom != null)
                            {
                                RoomDetail tempRoomDetail = this.classroomForm.getRoomDetail(e.RowIndex);
                                if (tempRoomDetail != null)
                                {
                                    SetupTeacherForm setupTeacherForm = new SetupTeacherForm();
                                    setupTeacherForm.showFormDialog(tempRoom.Id, tempRoomDetail, false);
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            Room tempRoom = this.classroomForm.getRoom();
                            if (tempRoom != null)
                            {
                                RoomDetail tempRoomDetail = this.classroomForm.getRoomDetail(e.RowIndex);
                                if (tempRoomDetail != null)
                                {
                                    SetupTeacherForm setupTeacherForm = new SetupTeacherForm();
                                    RoomDetail roomDetail = setupTeacherForm.showFormDialog(tempRoom.Id, tempRoomDetail, true);
                                    if (roomDetail != null)
                                    {
                                        bool isUpdateComplete = RoomDetailManager.updateRoomDetail(roomDetail);
                                        if (isUpdateComplete)
                                        {
                                            this.classroomForm.refreshRoomDetailList();
                                            this.refreshDataGridView_TeacherDetail();
                                            //MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_SUCCESS);
                                        }
                                        else
                                        {
                                            MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_FAIL);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case 5:
                        {
                            string text = "คุณต้องการลบ " + this.DataGridView_TeacherDetail.Rows[e.RowIndex].Cells["TeacherName"].Value + " ใช่หรือไม่";
                            if (ConfirmDialogBox.show(text))
                            {
                                RoomDetail tempRoomDetail = this.classroomForm.getRoomDetail(e.RowIndex);
                                if (tempRoomDetail != null)
                                {
                                    bool isDeleteComplete = RoomDetailManager.deleteRoomDetail(tempRoomDetail.RoomDetailId);
                                    if (isDeleteComplete)
                                    {
                                        this.classroomForm.refreshRoomDetailList();
                                        this.refreshDataGridView_TeacherDetail();
                                        MainForm.checkInMainForm.removeTeacherAndRoomDetailDictionary(tempRoomDetail.TeacherId, tempRoomDetail.RoomDetailId);
                                        //MessageBox.Show(PianoForte.Constant.DatabaseConstant.DELETE_DATA_SUCCESS);
                                    }
                                    else
                                    {
                                        MessageBox.Show(PianoForte.Constant.DatabaseConstant.DELETE_DATA_FAIL);
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        {
                            RoomDetail tempRoomDetail = this.classroomForm.getRoomDetail(e.RowIndex);
                            if (tempRoomDetail != null)
                            {
                                this.refreshDataGridView_ClassroomDetail(tempRoomDetail);
                            }
                        }
                        break;
                }
            }

            this.Cursor = Cursors.Arrow;
        }

        private void DataGridView_TeacherDetail_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 3:
                        this.Cursor = Cursors.Hand;
                        this.DataGridView_TeacherDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "View";
                        break;
                    case 4:
                        this.Cursor = Cursors.Hand;
                        this.DataGridView_TeacherDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Edit";
                        break;
                    case 5:
                        this.Cursor = Cursors.Hand;
                        this.DataGridView_TeacherDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Delete";
                        break;
                }
            }
        }

        private void DataGridView_TeacherDetail_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }        

        private void Button_Add_TeacherDetail_Click(object sender, EventArgs e)
        {
            Room tempRoom = this.classroomForm.getRoom();
            if (tempRoom != null)
            {
                SetupTeacherForm setupTeacherForm = new SetupTeacherForm();
                RoomDetail tempRoomDetail = setupTeacherForm.showFormDialog(tempRoom.Id);
                if (tempRoomDetail != null)
                {
                    tempRoomDetail = RoomDetailManager.insertRoomDetail(tempRoomDetail);
                    if (tempRoomDetail != null)
                    {
                        this.classroomForm.refreshRoomDetailList();
                        this.refreshDataGridView_TeacherDetail();
                        MainForm.checkInMainForm.addTeacherAndRoomDetailDictionary(tempRoomDetail.TeacherId, tempRoomDetail.RoomDetailId);
                        //MessageBox.Show(PianoForte.Constant.DatabaseConstant.INSERT_DATA_SUCCESS);
                    }
                    else
                    {
                        MessageBox.Show(PianoForte.Constant.DatabaseConstant.INSERT_DATA_FAIL);
                    }
                }
            }            
        }

        private void Button_Edit_TeacherDetail_Click(object sender, EventArgs e)
        {
            Room tempRoom = this.classroomForm.getRoom();
            if (tempRoom != null)
            {
                RoomDetail tempRoomDetail = this.classroomForm.getRoomDetail(this.DataGridView_TeacherDetail.CurrentRow.Index);
                if (tempRoomDetail != null)
                {
                    SetupTeacherForm setupTeacherForm = new SetupTeacherForm();
                    RoomDetail roomDetail = setupTeacherForm.showFormDialog(tempRoom.Id, tempRoomDetail, true);
                    if (roomDetail != null)
                    {
                        bool isUpdateComplete = RoomDetailManager.updateRoomDetail(roomDetail);
                        if (isUpdateComplete)
                        {
                            this.classroomForm.refreshRoomDetailList();
                            this.refreshDataGridView_TeacherDetail();
                            //MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_SUCCESS);
                        }
                        else
                        {
                            MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_FAIL);
                        }
                    }
                }
            }              
        }

        private void Button_Delete_TeacherDetail_Click(object sender, EventArgs e)
        {
            RoomDetail tempRoomDetail = this.classroomForm.getRoomDetail(this.DataGridView_TeacherDetail.CurrentRow.Index);
            if (tempRoomDetail != null)
            {
                bool isDeleteComplete = RoomDetailManager.deleteRoomDetail(tempRoomDetail.RoomDetailId);
                if (isDeleteComplete)
                {
                    this.classroomForm.refreshRoomDetailList();
                    this.refreshDataGridView_TeacherDetail();
                    MainForm.checkInMainForm.removeTeacherAndRoomDetailDictionary(tempRoomDetail.TeacherId, tempRoomDetail.RoomDetailId);
                    //MessageBox.Show(PianoForte.Constant.DatabaseConstant.DELETE_DATA_SUCCESS);
                }
                else
                {
                    MessageBox.Show(PianoForte.Constant.DatabaseConstant.DELETE_DATA_FAIL);
                }
            }            
        }        
    }
}
