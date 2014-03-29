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
    public partial class LeftClassroomForm : Form, ClassroomFormInterface
    {
        private enum RoomStatus
        {
            WAITING_FOR_SETUP,
            AVAILABLE,
            IN_USE
        }

        private const string ROOM_NUMBER_IMAGE_PATH = "\\Images\\RoomNumber\\";
        private const string TEACHER_IMAGE_PATH = "\\Images\\Teacher\\Resized\\";
        private const string NOT_SETUP_TEACHER_IMAGE = "NotSetup.png";
        private const string NO_TEACHER_IMAGE = "NoImage.png";
        private const string NO_TEACHER_AT_THIS_TIME = "NoTeacher.png";

        private MainForm mainForm;
        private Room room;
        private List<RoomDetail> roomDetailList;
        private Dictionary<int, List<ClassroomDetail>> classroomDetailDictionary;
        private RoomStatus roomStatus;
        private RoomDetail roomDetail;
        //private int teacherId;
        private string message;

        public LeftClassroomForm()
        {
            InitializeComponent();
        }

        public void load(MainForm mainForm, int roomNumber)
        {
            this.mainForm = mainForm;
            this.roomDetailList = new List<RoomDetail>();
            this.classroomDetailDictionary = new Dictionary<int, List<ClassroomDetail>>();

            try
            {
                Image roomNumberImage = Image.FromFile(PianoForte.Constant.Constant.STARTUP_PATH + "" + ROOM_NUMBER_IMAGE_PATH + "Room_" + ConvertManager.toStringRoomNumber(roomNumber) + ".png");
                if (roomNumberImage != null)
                {
                    this.PictureBox_RoomNumber.Image = roomNumberImage;
                }
            }
            catch (System.Exception ex)
            {
                LogManager.writeLog(ex.Message);
            }

            this.room = RoomManager.findRoom(roomNumber, DateTime.Today);
            if (this.room == null)
            {
                this.room = new Room();
                this.room.Number = roomNumber;
                this.room.Date = DateTime.Today;

                this.room = RoomManager.insertRoom(this.room);
                if (this.room == null)
                {
                    LogManager.writeLog("Error occur : Add room failed at ClassroomLeftForm.load");
                }
            }

            this.refreshRoomDetailList();                      
        }        

        public void update(string currentTime)
        {
            this.updateTeacherImage(currentTime);
            this.updateTextBox_Status(currentTime);
        }

        public void updateTeacherImage(string currentTime)
        {
            Image teacherImage = null;

            if (this.roomStatus == RoomStatus.WAITING_FOR_SETUP)
            {
                this.Button_CheckIn.Enabled = false;

                try
                {
                    teacherImage = Image.FromFile(PianoForte.Constant.Constant.STARTUP_PATH + "" + TEACHER_IMAGE_PATH + "" + NOT_SETUP_TEACHER_IMAGE);
                }
                catch (System.Exception ex)
                {
                    LogManager.writeLog(ex.Message);
                }
            }
            else
            {
                this.Button_CheckIn.Enabled = true;

                int index = -1;
                for (int i = 0; i < this.roomDetailList.Count; i++)
                {
                    RoomDetail tempRoomDetail = this.roomDetailList[i];
                    if (tempRoomDetail != null)
                    {
                        if (DateTimeManager.isBetweenTimeInterval(tempRoomDetail.StartTime, tempRoomDetail.EndTime, currentTime))
                        {
                            index = i;
                            //this.teacherId = tempRoomDetail.TeacherId;
                            this.roomDetail = tempRoomDetail;
                            break;
                        }
                        else
                        {
                            //this.teacherId = 0;
                            this.roomDetail = null;
                        }
                    }
                }

                if (index != -1)
                {
                    try
                    {
                        string stringTeacherId = this.roomDetailList[index].TeacherId.ToString();
                        teacherImage = Image.FromFile(PianoForte.Constant.Constant.STARTUP_PATH + "" + TEACHER_IMAGE_PATH + "T" + stringTeacherId + "_Normal.png");
                    }
                    catch (System.Exception ex)
                    {
                        teacherImage = Image.FromFile(PianoForte.Constant.Constant.STARTUP_PATH + "" + TEACHER_IMAGE_PATH + "" + NO_TEACHER_IMAGE);
                        LogManager.writeLog(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        teacherImage = Image.FromFile(PianoForte.Constant.Constant.STARTUP_PATH + "" + TEACHER_IMAGE_PATH + "" + NO_TEACHER_AT_THIS_TIME);
                    }
                    catch (System.Exception ex)
                    {
                        LogManager.writeLog(ex.Message);
                    }
                }
            }

            if (teacherImage != null)
            {
                this.PictureBox_TeacherImage.Image = teacherImage;
            }
        }

        public void updateTextBox_Status(string currentTime)
        {
            if (this.roomStatus != RoomStatus.WAITING_FOR_SETUP)
            {
                //if (this.teacherId != 0)
                if (this.roomDetail != null)
                {
                    int index = -1;

                    //List<ClassroomDetail> tempClassroomDetailList = this.classroomDetailDictionary[this.teacherId];
                    List<ClassroomDetail> tempClassroomDetailList = this.classroomDetailDictionary[this.roomDetail.TeacherId];
                    for (int i = 0; i < tempClassroomDetailList.Count; i++)
                    {
                        ClassroomDetail tempClassroomDetail = tempClassroomDetailList[i];
                        if (tempClassroomDetail != null)
                        {
                            int classroomDuration = tempClassroomDetailList[i].ClassroomDuration;
                            if (classroomDuration == 55)
                            {
                                classroomDuration = 60;
                            }

                            string startTime = tempClassroomDetail.ClassroomTime;
                            string endTime = DateTimeManager.addMinute(startTime, classroomDuration);
                            if (DateTimeManager.isBetweenTimeInterval(startTime, endTime, currentTime))
                            {
                                index = i;
                                break;
                            }
                            else if (currentTime == DateTimeManager.getMaxTime(currentTime, endTime))
                            {
                                if (tempClassroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
                                {
                                    string newStatus = ClassroomDetail.ClassroomStatus.MISSING.ToString();
                                    tempClassroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(newStatus, tempClassroomDetail);

                                    bool isUpdateComplete = false;
                                    while (!isUpdateComplete)
                                    {
                                        isUpdateComplete = ClassroomDetailManager.updateClassroomDetail(tempClassroomDetail);
                                    }
                                }
                            }
                        }
                    }

                    if (index != -1)
                    {
                        this.roomStatus = RoomStatus.IN_USE;

                        int classroomDuration = tempClassroomDetailList[index].ClassroomDuration;
                        if (classroomDuration == 55)
                        {
                            classroomDuration = 60;
                        }

                        string startTime = tempClassroomDetailList[index].ClassroomTime;
                        string endTime = DateTimeManager.addMinute(tempClassroomDetailList[index].ClassroomTime, tempClassroomDetailList[index].ClassroomDuration);
                        this.TextBox_Status.Text = startTime + " - " + endTime;

                        if (tempClassroomDetailList[index].CurrentStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
                        {
                            Classroom tempClassroom = ClassroomManager.findClassroom(tempClassroomDetailList[index].ClassroomId);
                            if (tempClassroom != null)
                            {
                                Enrollment tempEnrollment = EnrollmentManager.getEnrollment(tempClassroom.EnrollmentId);
                                if (tempEnrollment != null)
                                {
                                    if (tempEnrollment.Student != null)
                                    {
                                        string studentName = tempEnrollment.Student.Firstname + " " + tempEnrollment.Student.Lastname + "(" + tempEnrollment.Student.Nickname + ")";

                                        this.message = studentName + " ยังไม่ได้เช็คอิน";
                                    }
                                }
                            }


                            this.PictureBox_Warning.Visible = true;
                        }
                        else
                        {
                            this.message = "";
                            this.PictureBox_Warning.Visible = false;
                        }
                    }
                    else
                    {
                        this.roomStatus = RoomStatus.AVAILABLE;
                        this.TextBox_Status.Text = this.roomStatus.ToString();
                    }
                }
                else
                {
                    this.roomStatus = RoomStatus.AVAILABLE;
                    this.TextBox_Status.Text = this.roomStatus.ToString();
                }                
            }
        }

        public void refreshRoomDetailList()
        {
            this.roomDetailList.Clear();

            if (this.room != null)
            {
                this.roomDetailList = RoomDetailManager.findAllRoomDetailByRoomId(this.room.Id);
                if (this.roomDetailList.Count == 0)
                {
                    this.roomStatus = RoomStatus.WAITING_FOR_SETUP;
                    this.TextBox_Status.Text = "Not Setup";
                }
                else
                {
                    this.roomStatus = RoomStatus.AVAILABLE;
                    this.refreshClassroomDetailDictionary();
                }
            }           
        }

        public void refreshClassroomDetailDictionary()
        {
            this.classroomDetailDictionary.Clear();

            for (int i = 0; i < this.roomDetailList.Count; i++)
            {
                RoomDetail tempRoomDetail = this.roomDetailList[i];
                if (tempRoomDetail != null)
                {
                    int teacherId = tempRoomDetail.TeacherId;
                    DateTime date = DateTime.Today;
                    string status = ClassroomDetail.ClassroomStatus.WAITING.ToString();
                    //List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.getAllClassroomDetailForCheckInForm(teacherId, date);
                    List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.findAllClassroomDetailByTeacherIdAndDate(teacherId, date);

                    for (int j = 0; j < tempClassroomDetailList.Count; j++)
                    {
                        ClassroomDetail tempClassroomDetail = tempClassroomDetailList[j];
                        if (tempRoomDetail != null)
                        {
                            if ((DateTimeManager.isBetweenTimeInterval(tempRoomDetail.StartTime, tempRoomDetail.EndTime, tempClassroomDetail.ClassroomTime)) &&
                                (DateTimeManager.isBetweenTimeInterval(tempRoomDetail.StartTime, tempRoomDetail.EndTime, DateTimeManager.addMinute(tempClassroomDetail.ClassroomTime, tempClassroomDetail.ClassroomDuration))))
                            {
                                //Do Nothing
                            }
                            else
                            {
                                tempClassroomDetailList.RemoveAt(j);
                                j--;
                            }
                        }
                    }

                    this.classroomDetailDictionary.Add(teacherId, tempClassroomDetailList);
                }
            }
        }

        public Room getRoom()
        {
            return this.room;
        }

        public RoomDetail getRoomDetail(int index)
        {
            RoomDetail tempRoomDetail = null;

            if ((this.roomDetailList.Count > 0) && (index < this.roomDetailList.Count))
            {
                tempRoomDetail = this.roomDetailList[index];
            }

            return tempRoomDetail;
        }

        public List<RoomDetail> getRoomDetailList()
        {
            return this.roomDetailList;
        }

        public List<ClassroomDetail> getClassroomDetailList(int teacherId)
        {
            return this.classroomDetailDictionary[teacherId];
        }

        public bool isClassroomDetailExist(int teacherId, int classroomDetailId)
        {
            bool isExist = false;

            if (this.classroomDetailDictionary.Count > 0)
            {
                if (this.classroomDetailDictionary.ContainsKey(teacherId))
                {
                    List<ClassroomDetail> tempClassroomDetailList = this.classroomDetailDictionary[teacherId];
                    for (int i = 0; i < tempClassroomDetailList.Count; i++)
                    {
                        ClassroomDetail tempClassroomDetail = tempClassroomDetailList[i];
                        if (tempClassroomDetail != null)
                        {
                            if (tempClassroomDetail.ClassroomDetailId == classroomDetailId)
                            {
                                isExist = true;
                                break;
                            }
                        }
                    }
                }
            }                        

            return isExist;
        }

        private void Button_CheckIn_Click(object sender, EventArgs e)
        {
            //To Do
        }

        private void Button_Setup_Click(object sender, EventArgs e)
        {
            //To Do
        }
    }
}
