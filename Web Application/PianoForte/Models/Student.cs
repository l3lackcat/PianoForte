using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class Student : Person
    {
        public DateTime LastEnrollmentDate { get; set; }

        public List<StudentContact> ContactList { get; set; }
        public StudentAddress Address { get; set; }

        public Student()
        {
            this.ContactList = new List<StudentContact>();
            this.Address = new StudentAddress();
        }
    }
}