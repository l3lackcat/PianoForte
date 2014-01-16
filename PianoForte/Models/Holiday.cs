using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}