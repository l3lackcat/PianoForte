using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Student : Person
    {
        public static string tableName = "student";
        public static string columnStudentId = "studentId";
        public static string columnFirstname = "firstname";
        public static string columnLastname = "lastname";
        public static string columnNickname = "nickname";
        public static string columnPhone1 = "phone1";
        public static string columnPhone2 = "phone2";
        public static string columnPhone3 = "phone3";
        public static string columnBirthday = "birthday";
        public static string columnAddress1 = "address1";
        public static string columnAddress2 = "address2";
        public static string columnPostCode = "postCode";
        public static string columnEmail = "email";
        public static string columnRegisterDate = "registerDate";
        public static string columnLastDateOfClass = "lastDateOfClass";
        public static string columnStatus = "status";

        public enum StudentStatus
        {
            ALL,
            ACTIVE,
            INACTIVE,
            DROPPED                                    
        };
        
        private Address address;
        private DateTime lastDateOfClass;
        private List<Enrollment> currentCourseList;
        private List<Enrollment> previousCourseList;

        public Student()
        {
            this.currentCourseList = new List<Enrollment>();
            this.previousCourseList = new List<Enrollment>();
        }

        public Student(Student student)
        {
            this.currentCourseList = new List<Enrollment>();
            this.previousCourseList = new List<Enrollment>();

            this.Id = student.Id;
            this.Firstname = student.Firstname;
            this.Lastname = student.Lastname;
            this.Nickname = student.Nickname;
            this.Birthday = student.Birthday;
            this.Address = student.Address;
            this.Phone1 = student.Phone1;
            this.Phone2 = student.Phone2;
            this.Phone3 = student.Phone3;
            this.Email = student.Email;
            this.RegisteredDate = student.RegisteredDate;
            this.LastDateOfClass = student.LastDateOfClass;
            this.Status = student.Status;
        }        

        public Address Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
            }
        }

        public DateTime LastDateOfClass
        {
            get
            {
                return this.lastDateOfClass;
            }

            set
            {
                this.lastDateOfClass = value;
            }
        }

        public List<Enrollment> CurrentCourseList
        {
            get
            {
                return this.currentCourseList;
            }

            set
            {
                this.currentCourseList = value;
            }
        }

        public List<Enrollment> PreviousCourseList
        {
            get
            {
                return this.previousCourseList;
            }

            set
            {
                this.previousCourseList = value;
            }
        }
    }
}
