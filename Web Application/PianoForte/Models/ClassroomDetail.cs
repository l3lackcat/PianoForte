using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class ClassroomDetail
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public int TeacherId { get; set; }
        public DateTime ClassroomStart { get; set; }
        public DateTime ClassroomEnd { get; set; }
        public ClassroomType Type { get; set; }
        public Status Status { get; set; }
        public int PreviousId { get; set; }
        public int HolidayId { get; set; }
    }
}