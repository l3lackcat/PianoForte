using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class Book : Product
    {
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }

        public Book()
        {
            //Do Nothing
        }

        public Book(int id, string barcode, string name, double unitPrice, int quantity, Status status)
        {
            this.Id = id;
            this.Barcode = barcode;
            this.Name = name;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
            this.Status = status;
        }
    }
}