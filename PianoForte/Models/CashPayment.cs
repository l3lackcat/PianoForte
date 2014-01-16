using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Models
{
    public class CashPayment
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public double Amount { get; set; }
    }
}