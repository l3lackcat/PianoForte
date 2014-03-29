using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class OtherCostManager
    {
        public static OtherCostDao otherCostDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getOtherCostDao();
        
        public static bool insertOtherCost(OtherCost otherCost)
        {
            return otherCostDao.insertOtherCost(otherCost);
        }

        public static bool updateOtherCost(OtherCost otherCost)
        {
            return otherCostDao.updateOtherCost(otherCost);
        }

        public static bool deleteOtherCost(int otherCostId)
        {
            return otherCostDao.deleteOtherCost(otherCostId);
        }

        public static OtherCost findOtherCost(int otherCostId)
        {
            return otherCostDao.findOtherCost(otherCostId);
        }

        public static OtherCost findOtherCost(string otherCostName, double otherCostPrice)
        {
            return otherCostDao.findOtherCost(otherCostName, otherCostPrice);
        }

        public static List<OtherCost> findAllOtherCost()
        {
            return otherCostDao.findAllOtherCost();
        }

        public static int getNewOtherCostId()
        {
            int newOtherCostId = 0;

            OtherCost otherCost = otherCostDao.findLastOtherCost();
            if (otherCost != null)
            {
                newOtherCostId = otherCost.Id + 1;
            }
            else
            {
                newOtherCostId = ((int)Product.ProductType.OTHER * 1000000) + 1;
            }

            return newOtherCostId;
        }

        //public static List<OtherCost> getAllOtherCost_Old()
        //{
        //    return otherCostService.getAllOtherCost_Old();
        //}

        //Temporary
        //public static bool matchOtherCostId(int oldOtherCostId, int newOtherCostId)
        //{
        //    return otherCostService.matchOtherCostId(oldOtherCostId, newOtherCostId);
        //}

        //public static int getNewOtherCostId(int oldBookId)
        //{
        //    return otherCostService.getNewOtherCostId(oldBookId);
        //}
    }
}
