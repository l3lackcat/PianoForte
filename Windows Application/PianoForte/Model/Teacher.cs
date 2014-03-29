using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Teacher : Person
    {
        public static string tableName = "teacher";
        public static string columnTeacherId = "teacherId";
        public static string columnFirstname = "firstname";
        public static string columnLastname = "lastname";
        public static string columnNickname = "nickname";
        public static string columnPhone1 = "phone1";
        public static string columnPhone2 = "phone2";
        public static string columnPhone3 = "phone3";
        public static string columnBirthday = "birthday";
        public static string columnEmail = "email";
        public static string columnRegisterDate = "registerDate";
        public static string columnResignedDate = "resignedDate";
        public static string columnSettings = "settings";
        public static string columnStatus = "status";

        public enum TeacherStatus
        {
            ALL,
            ACTIVE,
            RESIGNED            
        };

        [Flags]
        public enum TeacherSettings
        {
            NONE = 0,
            TEACHES_45_MIN = 1
        };

        private DateTime resignedDate;
        private List<int> teachingCourseList;
        private TeacherSettings settings;

        public Teacher()
        {
            this.teachingCourseList = new List<int>();
        }

        public Teacher(Teacher teacher)
        {           
            this.Id = teacher.Id;
            this.Firstname = teacher.Firstname;
            this.Lastname = teacher.Lastname;
            this.Nickname = teacher.Nickname;
            this.Email = teacher.Email;
            this.Phone1 = teacher.Phone1;
            this.Phone2 = teacher.Phone2;
            this.Phone3 = teacher.Phone3;
            this.Birthday = teacher.Birthday;
            this.RegisteredDate = teacher.RegisteredDate;
            this.ResignedDate = teacher.ResignedDate;
            this.Status = teacher.Status;
            this.teachingCourseList = new List<int>(teacher.TeachingCourseIdList);
            this.Settings = teacher.Settings;
        }

        public override string ToString()
        {
            return "อ." + this.Firstname + " (ครู" + this.Nickname + ")";
        }

        public DateTime ResignedDate
        {
            get
            {
                return this.resignedDate;
            }

            set
            {
                this.resignedDate = value;
            }
        }

        public List<int> TeachingCourseIdList
        {
            get
            {
                return this.teachingCourseList;
            }

            set
            {
                this.teachingCourseList = value;
            }
        }

        public TeacherSettings Settings
        {
            get
            {
                return this.settings;
            }

            set
            {
                this.settings = value;
            }
        }
    }
}
