using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
    }
}