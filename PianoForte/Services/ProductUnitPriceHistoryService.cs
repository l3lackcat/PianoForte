using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class ProductUnitPriceHistoryService
    {
        private static ProductUnitPriceHistoryDao productUnitPriceHistoryDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getProductUnitPriceHistoryDao();

        public static bool insertProductUnitPriceHistory(string databaseName, ProductUnitPriceHistory productUnitPriceHistory)
        {
            return productUnitPriceHistoryDao.insertProductUnitPriceHistory(databaseName, productUnitPriceHistory);
        }

        public static List<ProductUnitPriceHistory> getProductUnitPriceHistoryList(string databaseName, int productId)
        {
            return productUnitPriceHistoryDao.getProductUnitPriceHistoryList(databaseName, productId);
        }
    }
}