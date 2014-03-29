using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Models
{
    public class TeacherContact : Contact
    {
        public int TeacherId { get; set; }
    }
}