using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface ProductUnitPriceHistoryDao
    {
        bool insertProductUnitPriceHistory(string databaseName, ProductUnitPriceHistory productUnitPriceHistory);

        List<ProductUnitPriceHistory> getProductUnitPriceHistoryList(string databaseName, int productId);
    }
}
