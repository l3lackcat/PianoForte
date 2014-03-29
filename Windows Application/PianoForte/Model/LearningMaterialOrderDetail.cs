using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class LearningMaterialOrderDetail
    {
        protected int id;
        protected int customerId;
        protected int learningMaterialId;        
        protected int amount;
        protected double totalPrice;
        protected DateTime orderDate;
        protected string status;
        protected int paymentId;

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

        public int LearningMaterialId
        {
            get
            {
                return this.learningMaterialId;
            }

            set
            {
                this.learningMaterialId = value;
            }
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                this.amount = value;
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
