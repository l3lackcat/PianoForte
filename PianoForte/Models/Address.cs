using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public string StreetAddress { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
    }
}