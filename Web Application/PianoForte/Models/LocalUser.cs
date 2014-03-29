using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class LocalUser : Person
    {
        public UserRole Role { get; set; }
    } 
}