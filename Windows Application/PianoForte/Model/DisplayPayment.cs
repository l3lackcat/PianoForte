using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class DisplayPayment : Payment
    {
        private string studentName;
        private string paymentType;
        private string classStartDate;
        private string receiverName;

        public DisplayPayment()
        {
            //Do Nothing
        }

        public DisplayPayment(Payment payment)
        {
            this.Id = payment.Id;
            this.PrintPaymentId = payment.PrintPaymentId;
            this.StudentId = payment.StudentId;
            this.ReceiverId = payment.ReceiverId;
            this.CreditCardNumber = payment.CreditCardNumber;
            this.TotalPrice = payment.TotalPrice;
            this.TotalPriceText = payment.TotalPriceText;
            this.PaymentDate = payment.PaymentDate;
            this.Status = payment.Status;
        }

        public string StudentName
        {
            get
            {
                return this.studentName;
            }

            set
            {
                this.studentName = value;
            }
        }

        public string PaymentType
        {
            get
            {
                return this.paymentType;
            }

            set
            {
                this.paymentType = value;
            }
        }

        public string ClassroomStartDate
        {
            get
            {
                return this.classStartDate;
            }

            set
            {
                this.classStartDate = value;
            }
        }

        public string ReceiverName
        {
            get
            {
                return this.receiverName;
            }

            set
            {
                this.receiverName = value;
            }
        }
    }
}
