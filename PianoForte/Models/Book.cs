﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class Book : Product
    {
        public string InternalBarcode { get; set; }
        public string OriginalBarcode { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }

        public Book()
        {
            //Do Nothing
        }

        public Book(int id, string internalBarcode, string originalBarcode, string name, double unitPrice, int quantity, Status status)
        {
            this.Id = id;
            this.InternalBarcode = internalBarcode;
            this.OriginalBarcode = originalBarcode;
            this.Name = name;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
            this.Status = status;
        }
    }
}