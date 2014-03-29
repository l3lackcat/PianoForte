using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class ProductPriceHistory
    {
        public static string tableName = "product_price_history";
        public static string columnProductId = "productId";
        public static string columnPrice = "price";
        public static string columnLastUsed = "lastUsed";

        private int productId;
        private double price;
        private DateTime lastUsed;

        public ProductPriceHistory()
        {
            //Do Nothing
        }

        public ProductPriceHistory(ProductPriceHistory productPriceHistory)
        {
            this.productId = productPriceHistory.productId;
            this.price = productPriceHistory.price;
            this.lastUsed = productPriceHistory.lastUsed;
        }

        public int ProductId
        {
            get { return this.productId; }
            set { this.productId = value; }
        }

        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public DateTime LastUsed
        {
            get { return this.lastUsed; }
            set { this.lastUsed = value; }
        }
    }
}
