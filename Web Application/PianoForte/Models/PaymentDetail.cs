using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Models
{
    public class PaymentDetail
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public PaymentDetail()
        {
            this.Product = new Product();
        }
    }
}