using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string Label { get; set; }
        public string Content { get; set; }
        public Status Status { get; set; }
    }
}