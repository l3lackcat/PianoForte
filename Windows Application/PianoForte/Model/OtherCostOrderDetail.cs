using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class OtherCostOrderDetail
    {
        public static string tableName = "other_cost_order_detail";
        public static string columnOtherCostOrderDetailId = "otherCostOrderDetailId";
        public static string columnPaymentId = "paymentId";
        public static string columnStudentId = "studentId";
        public static string columnOtherCostId = "otherCostId";
        public static string columnTotalPrice = "totalPrice";
        public static string columnOrderDate = "orderDate";
        public static string columnStatus = "status";

        public enum OtherCostOrderDetailStatus
        {
            ALL,
            PAID,
            NOT_PAID,
            CANCELED
        };

        private int id;
        private int customerId;
        private int otherCostId;
        private double totalPrice;
        private DateTime orderDate;
        private string status;
        private int paymentId;

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

        public int CustomerId
        {
            get
            {
                return this.customerId;
            }

            set
            {
                this.customerId = value;
            }
        }

        public int OtherCostId
        {
            get
            {
                return this.otherCostId;
            }

            set
            {
                this.otherCostId = value;
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

        public DateTime OrderDate
        {
            get
            {
                return this.orderDate;
            }

            set
            {
                this.orderDate = value;
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

        public int PaymentId
        {
            get
            {
                return this.paymentId;
            }

            set
            {
                this.paymentId = value;
            }
        }
    }
}
