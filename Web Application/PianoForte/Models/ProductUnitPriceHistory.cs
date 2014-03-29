using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class ProductUnitPriceHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductType ProductType { get; set; }
        public double ProductUnitPrice { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}