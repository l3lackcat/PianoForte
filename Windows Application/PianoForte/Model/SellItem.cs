using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class SellItem
    {
        public enum SellItemType
        { 
            COURSE,
            BOOK,
            CD,
            OTHER_COST
        };

        private SellItemType itemType;
        private int itemID;
        private int itemNo;
        private string name;
        private int amount;
        private double discountRate;
        private double price;
        private double totalPrice;

        public SellItemType ItemType
        {
            get
            {
                return this.itemType;
            }

            set
            {
                this.itemType = value;
            }
        }

        public int ItemID
        {
            get
            {
                return this.itemID;
            }

            set
            {
                this.itemID = value;
            }
        }

        public int ItemNo
        {
            get
            {
                return this.itemNo;
            }

            set
            {
                this.itemNo = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            
            set
            {
                this.name = value;
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

        public double DiscountRate
        {
            get
            {
                return this.discountRate;
            }

            set
            {
                this.discountRate = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
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
    }
}
