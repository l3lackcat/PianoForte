using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationXlsToJson
{
    public class TradewebTemplate
    {
        public string QuantityTemplate { get; set; }
        public int MaxNoOfDealers { get; set; }
        public Dictionary<string, int> DisplayedTemplateDictioanry { get; set; }

        public TradewebTemplate()
        {
            this.DisplayedTemplateDictioanry = new Dictionary<string, int>();
        }
    }
}
