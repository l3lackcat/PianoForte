using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Enum;

namespace PianoForte.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public CashPayment CashPayment { get; set; }
        public CreditCardPayment CreditCardPayment { get; set; }
    }
}