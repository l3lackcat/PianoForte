using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class GlobalUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public Status Status { get; set; }
        public UserRole Role { get; set; }
        public int BranchId { get; set; }
        public int LocalUserId { get; set; }
        public Nullable<DateTime> LastLogin { get; set; }
    }
}