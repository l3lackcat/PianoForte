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
    public partial class StudentCheckInForm : Form
    {
        private RoomDetail roomDetail;
        private List<ClassroomDetail> classroomDetailList;
        private List<RoomDetail> roomDetailList;

        //DataTable dataTable;

        public StudentCheckInForm()
        {
            InitializeComponent();
        }

        public void showFormDialog(RoomDetail roomDetail, Dictionary<int, List<ClassroomDetail>> classroomDetailDictionary)
        {
            this.roomDetail = roomDetail;
            this.classroomDetailList = new List<ClassroomDetail>();

            //PianoForteDataGridViewButtonColumn dataGridViewButtonColumn = new PianoForteDataGridViewButtonColumn();
            //dataGridViewButtonColumn.Name = "CheckIn_Buttons";
            //dataGridViewButtonColumn.HeaderText = "";
            //dataGridViewButtonColumn.Width = 60;
            //this.DataGridView_Student_CheckInTime_List.Columns.Add(dataGridViewButtonColumn);

            foreach (var pair in classroomDetailDictionary)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    this.classroomDetailList.Add(pair.Value[i]);
                }
            }

            this.classroomDetailList = ClassroomDetailManager.sortClassroomDetailListByClassroomTime(this.classroomDetailList);
            this.refreshDataGridView_Student_CheckInTime_List();
            this.ShowDialog();
        }

        public void showFormDialog(List<RoomDetail> roomDetailList, Dictionary<int, List<ClassroomDetail>> classroomDetailDictionary)
        {
            this.roomDetailList = roomDetailList;
            this.classroomDetailList = new List<ClassroomDetail>();

            //PianoForteDataGridViewButtonColumn dataGridViewButtonColumn = new PianoForteDataGridViewButtonColumn();
            //dataGridViewButtonColumn.Name = "CheckIn_Buttons";
            //dataGridViewButtonColumn.HeaderText = "";
            //dataGridViewButtonColumn.Width = 60;
            //this.DataGridView_Student_CheckInTime_List.Columns.Add(dataGridViewButtonColumn);

            //dataTable = new DataTable("Test");
            //dataTable.Columns.Add(new DataColumn("No"));
            //dataTable.Columns.Add(new DataColumn("StudentId"));
            //dataTable.Columns.Add(new DataColumn("StudentName"));
            //dataTable.Columns.Add(new DataColumn("StartTime"));
            //dataTable.Columns.Add(new DataColumn("EndTime"));
            //dataTable.Columns.Add(new DataColumn("Status"));
            //DataColumn dateColumn = new DataColumn("Date", typeof(DateTime));
            //dateColumn.DefaultValue = DateTime.Today;
            //dataTable.Columns.Add(dateColumn);

            //DataSet dataSet = new DataSet();
            //dataSet.Tables.Add(dataTable);
            //this.DataGridView_Student_CheckInTime_List.DataSource = dataSet;

            foreach (var pair in classroomDetailDictionary)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    this.classroomDetailList.Add(pair.Value[i]);
                }
            }

            this.classroomDetailList = ClassroomDetailManager.sortClassroomDetailListByClassroomTime(this.classroomDetailList);
            this.refreshDataGridView_Student_CheckInTime_List();
            this.ShowDialog();
        }

        private void refreshDataGridView_Student_CheckInTime_List()
        {            
            for (int i = 0; i < this.classroomDetailList.Count; i++)
            {
                ClassroomDetail tempClassroomDetail = this.classroomDetailList[i];
                if (tempClassroomDetail != null)
                {
                    int studentId = 0;
                    string studentName = "";

                    Classroom tempClassroom = ClassroomManager.findClassroom(tempClassroomDetail.ClassroomId);
                    if (tempClassroom != null)
                    {
                        Enrollment tempEnrollment = EnrollmentManager.getEnrollment(tempClassroom.EnrollmentId);
                        if (tempEnrollment != null)
                        {
                            if (tempEnrollment.Student != null)
                            {
                                studentId = tempEnrollment.Student.Id;
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

                    int n = this.DataGridView_Student_CheckInTime_List.Rows.Add();
                    this.DataGridView_Student_CheckInTime_List.Rows[n].Cells[0].Value = n + 1;
                    this.DataGridView_Student_CheckInTime_List.Rows[n].Cells[1].Value = studentId;
                    this.DataGridView_Student_CheckInTime_List.Rows[n].Cells[2].Value = studentName;
                    this.DataGridView_Student_CheckInTime_List.Rows[n].Cells[3].Value = classroomStartTime;
                    this.DataGridView_Student_CheckInTime_List.Rows[n].Cells[4].Value = classroomEndTime;
                    this.DataGridView_Student_CheckInTime_List.Rows[n].Cells[5].Value = tempClassroomDetail.DisplayStatus;

                    if (tempClassroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
                    {
                        this.DataGridView_Student_CheckInTime_List.Rows[n].Cells["CheckIn_Buttons"].Value = "เช็คอิน";
                        //((PianoForteDataGridViewButtonCell)this.DataGridView_Student_CheckInTime_List.Rows[n].Cells["CheckIn_Buttons"]).Enabled = true;
                    }
                    else
                    {
                        //((PianoForteDataGridViewButtonCell)this.DataGridView_Student_CheckInTime_List.Rows[n].Cells["CheckIn_Buttons"]).Enabled = false;
                    }

                    if (tempClassroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
                    {
                        this.DataGridView_Student_CheckInTime_List.Rows[n].DefaultCellStyle.BackColor = Color.MediumTurquoise;
                    }
                    else if (tempClassroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.CHECKED_IN.ToString())
                    {
                        this.DataGridView_Student_CheckInTime_List.Rows[n].DefaultCellStyle.BackColor = Color.SpringGreen;
                    }
                    else if (tempClassroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.MISSING.ToString())
                    {
                        this.DataGridView_Student_CheckInTime_List.Rows[n].DefaultCellStyle.BackColor = Color.Salmon;
                    }

                    //DataRow dataRow = dataTable.NewRow();
                    //dataRow["No"] = i + 1;
                    //dataRow["StudentId"] = studentId;
                    //dataRow["StudentName"] = studentName;
                    //dataRow["StartTime"] = classroomStartTime;
                    //dataRow["EndTime"] = classroomEndTime;
                    //dataRow["Status"] = tempClassroomDetail.DisplayStatus;
                    //dataRow["Date"] = tempClassroomDetail.ClassroomDate;
                    //dataTable.Rows.Add(dataRow);
                    //dataTable.AcceptChanges();
                }
            }

            this.DataGridView_Student_CheckInTime_List.ClearSelection();
        }

        private void DataGridView_Student_CheckInTime_List_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = this.DataGridView_Student_CheckInTime_List.CurrentRow.Index;
            if (this.classroomDetailList[selectedIndex].CurrentStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
            {
                string studentName = this.DataGridView_Student_CheckInTime_List[0, this.DataGridView_Student_CheckInTime_List.CurrentRow.Index].Value.ToString();
                string text = "คุณต้องการเช็คอิน " + studentName + " ใช่หรือไม่?";
                if (ConfirmDialogBox.show(text))
                {
                    RoomDetail tempRoomDetail = null;

                    for (int i = 0; i < this.roomDetailList.Count; i++)
                    {
                        tempRoomDetail = roomDetailList[i];
                        if (tempRoomDetail != null)
                        {
                            if (tempRoomDetail.TeacherId == this.classroomDetailList[selectedIndex].TeacherId)
                            {
                                break;
                            }
                            else
                            {
                                tempRoomDetail = null;
                            }
                        }
                    }

                    if (tempRoomDetail != null)
                    {
                        string newStatus = ClassroomDetail.ClassroomStatus.CHECKED_IN.ToString();
                        ClassroomDetail tempClassroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(newStatus, this.classroomDetailList[selectedIndex]);
                        tempClassroomDetail.RoomDetailId = tempRoomDetail.RoomDetailId;

                        bool isCheckInComplete = ClassroomDetailManager.updateClassroomDetail(tempClassroomDetail);
                        if (isCheckInComplete)
                        {
                            MainForm.checkInMainForm.updateClassroomDictionary(tempClassroomDetail.TeacherId, tempClassroomDetail.ClassroomDetailId);
                            MessageBox.Show("Check-In เรียบร้อยแล้ว");
                            this.Close();
                        }
                    }

                    //if (this.roomDetail != null)
                    //{
                    //    string newStatus = ClassroomDetail.ClassroomStatus.CHECKED_IN.ToString();
                    //    ClassroomDetail tempClassroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(newStatus, this.classroomDetailList[selectedIndex]);
                    //    tempClassroomDetail.RoomDetailId = this.roomDetail.RoomDetailId;

                    //    bool isCheckInComplete = ClassroomDetailManager.updateClassroomDetail(tempClassroomDetail);
                    //    if (isCheckInComplete)
                    //    {
                    //        MainForm.checkInMainForm.updateClassroomDictionary(tempClassroomDetail.TeacherId, tempClassroomDetail.ClassroomDetailId);
                    //        MessageBox.Show("Check-In เรียบร้อยแล้ว");
                    //        this.Close();
                    //    }
                    //}                    
                }
            }
            else if (this.classroomDetailList[selectedIndex].CurrentStatus == ClassroomDetail.ClassroomStatus.CHECKED_IN.ToString())
            {
                MessageBox.Show("ไม่สามารถ Check-In ได้เนื่องจาก Check-In ไปแล้ว");
            }
            else if (this.classroomDetailList[selectedIndex].CurrentStatus == ClassroomDetail.ClassroomStatus.MISSING.ToString())
            {
                MessageBox.Show("ไม่สามารถ Check-In ได้เนื่องจากเลยเวลาแล้ว");
            }
        }
    }
}
