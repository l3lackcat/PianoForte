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
    public partial class TeacherCheckInForm : Form
    {
        private Dictionary<int, List<int>> teacherAndRoomDetailDictionary;

        public TeacherCheckInForm()
        {
            InitializeComponent();
        }

        public void showFormDialog(Dictionary<int, List<int>> teacherAndRoomDetailDictionary)
        {
            this.teacherAndRoomDetailDictionary = new Dictionary<int, List<int>>(teacherAndRoomDetailDictionary);

            refreshDataGridView_TeacherDetail();
            ShowDialog();
        }

        private void refreshDataGridView_TeacherDetail()
        {
            this.DataGridView_TeacherDetail.Rows.Clear();

            foreach (var pair in this.teacherAndRoomDetailDictionary)
            {
                Teacher tempTeacher = TeacherManager.findTeacher(pair.Key);
                if (tempTeacher != null)
                {
                    string teacherName = tempTeacher.Firstname + " " + tempTeacher.Lastname + "(" + tempTeacher.Nickname + ")";
                    string checkedInTime = "";

                    for (int i = 0; i < pair.Value.Count; i++)
                    {
                        int roomDetailId = pair.Value[i];
                        RoomDetail tempRoomDetail = RoomDetailManager.findRoomDetail(roomDetailId);
                        if (tempRoomDetail != null)
                        {
                            if (tempRoomDetail.CheckInTime != "")
                            {
                                if (checkedInTime == "")
                                {
                                    if (tempRoomDetail.CheckInTime != "")
                                    {
                                        checkedInTime = tempRoomDetail.CheckInTime;
                                    }                                    
                                }
                                else
                                {
                                    if (checkedInTime != tempRoomDetail.CheckInTime)
                                    {
                                        checkedInTime = "Error";
                                        //break;
                                    }
                                }                                
                            }
                        }
                    }

                    int n = this.DataGridView_TeacherDetail.Rows.Add();
                    this.DataGridView_TeacherDetail.Rows[n].Cells["No"].Value = n+1;
                    this.DataGridView_TeacherDetail.Rows[n].Cells["TeacherId"].Value = tempTeacher.Id;
                    this.DataGridView_TeacherDetail.Rows[n].Cells["TeacherName"].Value = teacherName;
                    this.DataGridView_TeacherDetail.Rows[n].Cells["CheckedInTime"].Value = checkedInTime;
                    
                    if (checkedInTime == "")
                    {
                        ((DataGridViewImageCell)this.DataGridView_TeacherDetail.Rows[n].Cells["CheckInButton"]).Value = Image.FromFile("..\\..\\Images\\Check-In.png");
                    }
                    else
                    {
                        ((DataGridViewImageCell)this.DataGridView_TeacherDetail.Rows[n].Cells["CheckInButton"]).Value = Image.FromFile("..\\..\\Images\\Delete.png");
                    }
                }
            }

            this.DataGridView_TeacherDetail.ClearSelection();
        }

        private bool checkInTeacher(int teacherId, string currentTime)
        {
            bool isCheckInSuccess = false;

            List<int> tempRoomDetailIdList = this.teacherAndRoomDetailDictionary[teacherId];
            for (int i = 0; i < tempRoomDetailIdList.Count; i++)
            {
                RoomDetail tempRoomDetail = RoomDetailManager.findRoomDetail(tempRoomDetailIdList[i]);
                if (tempRoomDetail != null)
                {
                    tempRoomDetail.CheckInTime = currentTime;

                    isCheckInSuccess = RoomDetailManager.updateRoomDetail(tempRoomDetail);
                    if (!isCheckInSuccess)
                    {
                        break;
                    }
                }
            }

            return isCheckInSuccess;
        }

        private void DataGridView_TeacherDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {    
            if (e.RowIndex >= 0)
            {
                string stringValue = this.DataGridView_TeacherDetail.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (stringValue == "")
                {
                    string text = "คุณต้องการเช็คอิน " + this.DataGridView_TeacherDetail.Rows[e.RowIndex].Cells[2].Value + " ใช่หรือไม่?";
                    if (ConfirmDialogBox.show(text))
                    {
                        int teacherId = Convert.ToInt32(this.DataGridView_TeacherDetail.Rows[e.RowIndex].Cells[1].Value);
                        this.checkInTeacher(teacherId, DateTimeManager.getCurrentTime());
                        this.refreshDataGridView_TeacherDetail();
                    }
                }
                else
                {
                    if (stringValue != "Error")
                    {
                        string text = "คุณต้องการยกเลิกเช็คอิน " + this.DataGridView_TeacherDetail.Rows[e.RowIndex].Cells[2].Value + " ใช่หรือไม่?";
                        if (ConfirmDialogBox.show(text))
                        {
                            int teacherId = Convert.ToInt32(this.DataGridView_TeacherDetail.Rows[e.RowIndex].Cells[1].Value);
                            this.checkInTeacher(teacherId, "");
                            this.refreshDataGridView_TeacherDetail();
                        }
                    }
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
                    case 4:
                        {
                            this.Cursor = Cursors.Hand;
                        }
                        break;
                }                
            }
        }

        private void DataGridView_TeacherDetail_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }      
    }
}
