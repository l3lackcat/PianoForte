using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationXlsToJson
{
    public class LocationData
    {
        public Dictionary<string, List<string>> PostCodeToProvinceDictionary { get; set; }
        public Dictionary<string, List<string>> ProvinceToDistrictDictionary { get; set; }
        public Dictionary<string, List<string>> DistrictToSubDistrictDictionary { get; set; }

        public LocationData()
        {
            PostCodeToProvinceDictionary = new Dictionary<string, List<string>>();
            ProvinceToDistrictDictionary = new Dictionary<string, List<string>>();
            DistrictToSubDistrictDictionary = new Dictionary<string, List<string>>();
        }
    }
}
