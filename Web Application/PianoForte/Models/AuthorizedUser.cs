using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class AuthorizedUser
    {
        public int GlobalUserId { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string BranchName { get; set; }
        public UserRole Role { get; set; }
        public int LocalUserId { get; set; }
    }
}