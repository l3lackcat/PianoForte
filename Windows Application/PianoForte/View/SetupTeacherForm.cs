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
    public partial class SetupTeacherForm : Form
    {
        private const string TEACHER_IMAGE_PATH = "\\Images\\Teacher\\Original\\";
        private const string NO_TEACHER_IMAGE = "NoImage.png";

        private int roomId;
        private Teacher teacher;
        private RoomDetail roomDetail;        

        public SetupTeacherForm()
        {
            InitializeComponent();
        }

        public RoomDetail showFormDialog(int roomId)
        {
            this.reset();
            
            this.roomId = roomId;
            this.teacher = new Teacher();
            this.roomDetail = null;

            this.TextBox_TeacherId_ForSearch.Enabled = true;
            this.Button_SearchTeacher.Enabled = true;
            this.ComboBox_StartTime.Enabled = true;
            this.ComboBox_EndTime.Enabled = true;

            this.ShowDialog();

            return this.roomDetail;
        }

        public RoomDetail showFormDialog(int roomId, RoomDetail roomDetail, bool isEditMode)
        {            
            this.roomId = roomId;
            this.teacher = new Teacher();
            this.roomDetail = new RoomDetail(roomDetail);

            if (this.roomDetail == null)
            {
                this.reset();
            }
            else
            {
                this.setup();
            }

            this.TextBox_TeacherId_ForSearch.Enabled = false;
            this.Button_SearchTeacher.Enabled = false;
            this.ComboBox_StartTime.Enabled = isEditMode;
            this.ComboBox_EndTime.Enabled = isEditMode;

            this.ShowDialog();

            return this.roomDetail;
        }

        private void reset()
        {
            this.roomId = 0;
            this.roomDetail = null;

            this.PictureBox_TeacherImage.Image = null;

            this.TextBox_TeacherId_ForSearch.Text = "";
            this.TextBox_Teacher_Firstname.Text = "";
            this.TextBox_Teacher_Lastname.Text = "";
            this.TextBox_Teacher_Nickname.Text = "";

            this.Button_OK.Enabled = false;
        }

        private void setup()
        {
            Teacher teacher = TeacherManager.findTeacher(this.roomDetail.TeacherId);
            if (teacher != null)
            {
                initGroupBox_Teacher(teacher);                
            }
        }

        private void searchTeacher()
        {
            string stringTeacherId = this.TextBox_TeacherId_ForSearch.Text;
            if (stringTeacherId != "")
            {
                if (ValidateManager.isNumber(stringTeacherId))
                {
                    int teacherId = Convert.ToInt32(stringTeacherId);
                    Teacher tempTeacher = TeacherManager.findTeacher(teacherId);
                    if (tempTeacher != null)
                    {
                        initGroupBox_Teacher(tempTeacher);
                    }
                }
            }

            this.TextBox_TeacherId_ForSearch.Text = "";
        }

        private void initGroupBox_Teacher(Teacher teacher)
        {
            if (teacher != null)
            {
                this.teacher = teacher;

                this.TextBox_TeacherId.Text = teacher.Id.ToString();
                this.TextBox_Teacher_Firstname.Text = teacher.Firstname;
                this.TextBox_Teacher_Lastname.Text = teacher.Lastname;
                this.TextBox_Teacher_Nickname.Text = teacher.Nickname;

                try
                {
                    string imageName = "T" + teacher.Id.ToString() + "_Normal.png";
                    Image image = Image.FromFile(PianoForte.Constant.Constant.STARTUP_PATH + "" + TEACHER_IMAGE_PATH + "" + imageName);
                    if (image != null)
                    {
                        this.PictureBox_TeacherImage.Image = image;
                    }
                    else
                    {
                        image = Image.FromFile(PianoForte.Constant.Constant.STARTUP_PATH + "" + TEACHER_IMAGE_PATH + "" + NO_TEACHER_IMAGE);
                        if (image != null)
                        {
                            this.PictureBox_TeacherImage.Image = image;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Image image = Image.FromFile(PianoForte.Constant.Constant.STARTUP_PATH + "" + TEACHER_IMAGE_PATH + "" + NO_TEACHER_IMAGE);
                    if (image != null)
                    {
                        this.PictureBox_TeacherImage.Image = image;
                    }

                    LogManager.writeLog(ex.Message);
                }

                this.initComboBox_Time();
                this.ComboBox_StartTime.Enabled = true;
                this.ComboBox_EndTime.Enabled = true;
                this.Button_OK.Enabled = true;
            }
        }

        private void initComboBox_Time()
        {
            List<string> tempTimeList;
            if (DateTimeManager.isWeekEnd(DateTime.Today))
            {
                tempTimeList = DateTimeManager.weekEndTimeList;
            }
            else
            {
                tempTimeList = DateTimeManager.weekDayTimeList;
            }

            for (int i = 0; i < tempTimeList.Count; i++)
            {
                this.ComboBox_StartTime.Items.Add(tempTimeList[i]);
                this.ComboBox_EndTime.Items.Add(tempTimeList[i]);
            }

            if (this.ComboBox_StartTime.Items.Count > 0)
            {
                if (this.roomDetail == null)
                {
                    this.ComboBox_StartTime.SelectedIndex = 0;
                }                
                else
                {
                    this.ComboBox_StartTime.Text = this.roomDetail.StartTime;
                }
            }

            if (this.ComboBox_EndTime.Items.Count > 0)
            {
                if (this.roomDetail == null)
                {
                    this.ComboBox_EndTime.SelectedIndex = 0;
                }
                else
                {
                    this.ComboBox_EndTime.Text = this.roomDetail.EndTime;
                }                
            }
        } 

        private void TextBox_TeacherId_ForSearch_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox_TeacherId_ForSearch.Text == "")
            {
                this.Button_SearchTeacher.Enabled = false;
            }
            else
            {
                this.Button_SearchTeacher.Enabled = true;
            }
        }

        private void TextBox_TeacherId_ForSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.searchTeacher();
            }
        }

        private void Button_SearchTeacher_Click(object sender, EventArgs e)
        {
            this.searchTeacher();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (this.roomDetail == null)
            {
                RoomDetail newRoomDetail = new RoomDetail();
                newRoomDetail.RoomId = this.roomId;
                newRoomDetail.TeacherId = this.teacher.Id;
                newRoomDetail.StartTime = this.ComboBox_StartTime.Text;
                newRoomDetail.EndTime = this.ComboBox_EndTime.Text;
                newRoomDetail.CheckInTime = "";

                this.roomDetail = newRoomDetail;
            }
            else
            {
                this.roomDetail.StartTime = this.ComboBox_StartTime.Text;
                this.roomDetail.EndTime = this.ComboBox_EndTime.Text;
            }
            
            this.Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.roomDetail = null;
            this.Close();
        }              
    }
}
