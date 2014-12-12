using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationXlsToJson
{
    public class TradewebData
    {
        public string ContributorName { get; set; }
        public List<string> ContributorIdList { get; set; }

        public TradewebData()
        {
            this.ContributorIdList = new List<string>();
        }
    }
}
