using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Models
{
    public class CreditCardPayment : CashPayment
    {
        public string CreditCardNumber { get; set; }
    }
}