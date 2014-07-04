using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationXlsToJson
{
    public class LocationData
    {
        public List<string> Provinces { get; set; }
        public List<string> Districts { get; set; }
        public List<string> SubDistricts { get; set; }

        public LocationData()
        {
            this.Provinces = new List<string>();
            this.Districts = new List<string>();
            this.SubDistricts = new List<string>();
        }
    }
}
