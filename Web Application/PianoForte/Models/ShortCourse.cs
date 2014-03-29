using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class ShortCourse : Product
    {
        public int CourseCategoryId { get; set; }
        public string Level { get; set; }
        public Status Status { get; set; }
    }
}