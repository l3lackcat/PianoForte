using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Models
{
    public class StudentAddress : Address
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
    }
}