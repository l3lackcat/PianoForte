using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PianoForte.Enum;

namespace PianoForte.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Status Status { get; set; }
    }
}