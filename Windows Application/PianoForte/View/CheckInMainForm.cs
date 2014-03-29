using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Interface;
using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.View
{
    public partial class CheckInMainForm : Form, FormInterface
    {
        private MainForm mainForm;
        private Dictionary<int, List<int>> teacherAndRoomDetailDictionary;
        private List<ClassroomForm> classroomFormList;

        public CheckInMainForm()
        {
            InitializeComponent();
        }

        public void load(MainForm mainForm)
        {
            this.mainForm = mainForm;
            this.teacherAndRoomDetailDictionary = new Dictionary<int, List<int>>();
            this.classroomFormList = new List<ClassroomForm>();
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.RIGHT));
            this.classroomFormList.Add(new ClassroomForm(ClassroomForm.ClassroomType.LEFT));

            this.init();

            //this.timer.Enabled = true;
        }

        public void reload()
        {
            //Do Nothing
        }

        public void reset()
        {
            //Do Nothing
        }

        public void init()
        {
            for (int i = 0; i < this.classroomFormList.Count; i++)
            {
                if (this.classroomFormList[i] != null)
                {
                    this.classroomFormList[i].load(this.mainForm, i + 1);
                    this.initialForm(i + 1, this.classroomFormList[i]);
                }
            }
        }

        private void initialForm(int roomNo, ClassroomForm classroomForm)
        {
            classroomForm.TopLevel = false;
            classroomForm.Dock = DockStyle.Fill;
            classroomForm.Show();
            
            switch (roomNo)
            {
                case 1:
                    this.Panel_Room01.Controls.Add(classroomForm);
                    break;
                case 2:
                    this.Panel_Room02.Controls.Add(classroomForm);
                    break;
                case 3:
                    this.Panel_Room03.Controls.Add(classroomForm);
                    break;
                case 4:
                    this.Panel_Room04.Controls.Add(classroomForm);
                    break;
                case 5:
                    this.Panel_Room05.Controls.Add(classroomForm);
                    break;
                case 6:
                    this.Panel_Room06.Controls.Add(classroomForm);
                    break;
                case 7:
                    this.Panel_Room07.Controls.Add(classroomForm);
                    break;
                case 8:
                    this.Panel_Room08.Controls.Add(classroomForm);
                    break;
                case 9:
                    this.Panel_Room09.Controls.Add(classroomForm);
                    break;
                case 10:
                    this.Panel_Room10.Controls.Add(classroomForm);
                    break;
                case 11:
                    this.Panel_Room11.Controls.Add(classroomForm);
                    break;
                case 12:
                    this.Panel_Room12.Controls.Add(classroomForm);
                    break;
                case 13:
                    this.Panel_Room13.Controls.Add(classroomForm);
                    break;
                case 14:
                    this.Panel_Room14.Controls.Add(classroomForm);
                    break;
                case 15:
                    this.Panel_Room15.Controls.Add(classroomForm);
                    break;
                case 16:
                    this.Panel_Room16.Controls.Add(classroomForm);
                    break;
                case 17:
                    this.Panel_Room17.Controls.Add(classroomForm);
                    break;
                case 18:
                    this.Panel_Room18.Controls.Add(classroomForm);
                    break;
                case 19:
                    this.Panel_Room19.Controls.Add(classroomForm);
            	    break;
                case 20:
                    this.Panel_Room20.Controls.Add(classroomForm);
                    break;
                case 21:
                    this.Panel_Room21.Controls.Add(classroomForm);
                    break;
                case 22:
                    this.Panel_Room22.Controls.Add(classroomForm);
                    break;
                case 23:
                    this.Panel_Room23.Controls.Add(classroomForm);
                    break;
                case 24:
                    this.Panel_Room24.Controls.Add(classroomForm);
                    break;
            }
        }

        public void updateClassroomDictionary(int teacherId, int classroomDetailId)
        {
            for (int i = 0; i < this.classroomFormList.Count; i++)
            {
                if (this.classroomFormList[i] != null)
                {
                    if (this.classroomFormList[i].isClassroomDetailExist(teacherId, classroomDetailId))
                    {
                        this.classroomFormList[i].refreshClassroomDetailDictionary();
                    }
                }
            }
        }

        public void addTeacherAndRoomDetailDictionary(int teacherId, int roomDetailId)
        {
            if (this.teacherAndRoomDetailDictionary.Count == 0)
            {
                List<int> roomDetailIdList = new List<int>();
                roomDetailIdList.Add(roomDetailId);

                this.teacherAndRoomDetailDictionary.Add(teacherId, roomDetailIdList);
            }
            else
            {
                if (this.teacherAndRoomDetailDictionary.ContainsKey(teacherId))
                {
                    if (!this.teacherAndRoomDetailDictionary[teacherId].Contains(roomDetailId))
                    {
                        this.teacherAndRoomDetailDictionary[teacherId].Add(roomDetailId);
                    }                    
                }
                else
                {
                    List<int> roomDetailIdList = new List<int>();
                    roomDetailIdList.Add(roomDetailId);

                    this.teacherAndRoomDetailDictionary.Add(teacherId, roomDetailIdList);
                }
            }
        }

        public void removeTeacherAndRoomDetailDictionary(int teacherId, int roomDetailId)
        {
            if (this.teacherAndRoomDetailDictionary.Count > 0)
            {
                if (this.teacherAndRoomDetailDictionary.ContainsKey(teacherId))
                {
                    if (this.teacherAndRoomDetailDictionary[teacherId].Contains(roomDetailId))
                    {
                        this.teacherAndRoomDetailDictionary[teacherId].Remove(roomDetailId);
                        if (this.teacherAndRoomDetailDictionary[teacherId].Count == 0)
                        {
                            this.teacherAndRoomDetailDictionary.Remove(teacherId);
                        }
                    }
                }
            }
        }

        private void Button_School_Absence_Click(object sender, EventArgs e)
        {
            HolidayMainForm holidayMainForm = new HolidayMainForm();
            holidayMainForm.showFormDialog(this.mainForm);
        }

        private void Button_CheckIn_Teacher_Click(object sender, EventArgs e)
        {
            TeacherCheckInForm teacherCheckInForm = new TeacherCheckInForm();
            teacherCheckInForm.showFormDialog(this.teacherAndRoomDetailDictionary);
        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            string currentTime = DateTimeManager.getCurrentTime();

            for (int i = 0; i < this.classroomFormList.Count; i++)
            {
                if (this.classroomFormList[i] != null)
                {
                    this.classroomFormList[i].update(currentTime);
                }
            }
        }        
    }
}
