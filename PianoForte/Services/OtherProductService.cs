using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class OtherProductService
    {
        private static OtherProductDao otherProductDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getOtherProductDao();

        public static bool insertOtherProduct(string databaseName, OtherProduct otherProduct)
        {
            return otherProductDao.insertOtherProduct(databaseName, otherProduct);
        }

        public static bool updateOtherProduct(string databaseName, OtherProduct otherProduct)
        {
            return otherProductDao.updateOtherProduct(databaseName, otherProduct);
        }

        public static OtherProduct getOtherProduct(string databaseName, int otherProductId)
        {
            OtherProduct otherProduct = null;

            List<OtherProduct> tempOtherProductList = otherProductDao.getOtherProductList(databaseName, otherProductId);
            if (tempOtherProductList.Count == 1)
            {
                otherProduct = tempOtherProductList[0];
            }

            return otherProduct;
        }

        public static List<OtherProduct> getOtherProductList(string databaseName, int startIndex, int offset, string keyword)
        {
            return otherProductDao.getOtherProductList(databaseName, startIndex, offset, keyword);
        }
    }
}