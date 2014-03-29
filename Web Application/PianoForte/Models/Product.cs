using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class Product
    {
        public int Id { get; set; }
        public ProductType Type { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
    }
}