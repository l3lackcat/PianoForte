using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Payment
    {
        public static string tableName = "payment";
        public static string columnPaymentId = "paymentId";
        public static string columnPrintPaymentId = "printPaymentId";
        public static string columnStudentId = "studentId";
        public static string columnReceiverId = "receiverId";
        public static string columnCreditCardNumber = "creditCardNumber";
        public static string columnTotalPrice = "totalPrice";
        public static string columnTotalPriceText = "totalPriceText";
        public static string columnPaymentDate = "paymentDate";
        public static string columnStatus = "status";

        public enum PaymentStatus
        {
            ALL,
            PAID,
            CANCELED,
            NOT_PAID
        }

        protected int id;
        protected int printPaymentId;
        protected int studentId;
        protected int receiverId;
        protected string creditCardNumber;
        protected double totalPrice;
        protected string totalPriceText;
        protected DateTime paymentDate;
        protected string status;        

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public int PrintPaymentId
        {
            get
            {
                return this.printPaymentId;
            }

            set
            {
                this.printPaymentId = value;
            }
        }

        public int StudentId
        {
            get
            {
                return this.studentId;
            }

            set
            {
                this.studentId = value;
            }
        }

        public int ReceiverId
        {
            get
            {
                return this.receiverId;
            }

            set
            {
                this.receiverId = value;
            }
        }

        public string CreditCardNumber
        {
            get
            {
                return this.creditCardNumber;
            }

            set
            {
                this.creditCardNumber = value;
            }
        }

        public double TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            set
            {
                this.totalPrice = value;
            }
        }

        public string TotalPriceText
        {
            get
            {
                return this.totalPriceText;
            }

            set
            {
                this.totalPriceText = value;
            }
        }

        public DateTime PaymentDate
        {
            get
            {
                return this.paymentDate;
            }

            set
            {
                this.paymentDate = value;
            }
        }

        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }        
    }
}
