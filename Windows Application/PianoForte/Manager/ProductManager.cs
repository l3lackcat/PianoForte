using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class ProductManager
    {
        private static ProductDao productDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getProductDao();

        public static bool addProductPriceHistory(ProductPriceHistory productPriceHistory)
        {
            return productDao.addProductPriceHistory(productPriceHistory);
        }
    }
}
