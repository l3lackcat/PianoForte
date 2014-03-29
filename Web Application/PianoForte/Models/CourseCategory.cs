using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class CourseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}