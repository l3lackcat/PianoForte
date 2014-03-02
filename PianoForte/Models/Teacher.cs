using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class Teacher : Person
    {
        public DateTime ResignedDate { get; set; }

        public List<TeacherContact> ContactList { get; set; }
        public TeacherAddress Address { get; set; }
        public List<string> TeachedCourseList { get; set; }
        public TeacherProperty Property { get; set; }

        public Teacher()
        {
            this.ContactList = new List<TeacherContact>();
            this.Address = new TeacherAddress();
            this.TeachedCourseList = new List<string>();
        }

        public Teacher(int id, string firstname, string lastname, string nickname, Status status)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Nickname = nickname;
            this.Status = status;

            this.ContactList = new List<TeacherContact>();
            this.TeachedCourseList = new List<string>();
        }
    }
}