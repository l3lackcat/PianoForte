using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class Course : Product
    {
        public int CourseCategoryId { get; set; }
        public string Level { get; set; }
        public int NumberOfTimes { get; set; }
        public int ClassroomDuration { get; set; }
        public int StudentPerClassroom { get; set; }
        public Status Status { get; set; }
    }
}