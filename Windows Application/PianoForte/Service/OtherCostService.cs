using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class OtherCostService
    {
        private OtherCostDao otherCostDao = new OtherCostDao();

        public bool addOtherCost(OtherCost otherCost)
        {
            string sql = "INSERT INTO " +
                         OtherCost.tableName + " (" +
                         OtherCost.columnOtherCostId + ", " +
                         OtherCost.columnOtherCostName + ", " +
                         OtherCost.columnOtherCostPrice + ") " +
                         "VALUES(" +
                         "?" + OtherCost.columnOtherCostId + ", " +
                         "?" + OtherCost.columnOtherCostName + ", " +
                         "?" + OtherCost.columnOtherCostPrice + ")";

            return this.otherCostDao.processInsertString(sql, otherCost);
        }

        public bool updateOtherCost(OtherCost otherCost)
        {
            string sql = "UPDATE " +
                         OtherCost.tableName + " SET " +
                         OtherCost.columnOtherCostName + " = ?" + OtherCost.columnOtherCostName + ", " +
                         OtherCost.columnOtherCostPrice + " = ?" + OtherCost.columnOtherCostPrice + " " +
                         "WHERE " + OtherCost.columnOtherCostId + " = ?" + OtherCost.columnOtherCostId;
            /*
            string sql = "UPDATE OtherCosts SET " +
                         "otherCostName = ?otherCostName, " +
                         "otherCostPrice = ?otherCostPrice " +
                         "WHERE otherCostID = ?otherCostID";
            */
            return this.otherCostDao.processUpdateString(sql, otherCost);
        }

        public bool deleteOtherCost(int otherCostId)
        {
            string sql = "DELETE " +
                         "FROM " + OtherCost.tableName + " " +
                         "WHERE " + OtherCost.columnOtherCostId + " = " + otherCostId;

            return this.otherCostDao.processDeleteString(sql);
        }

        public OtherCost getLastOtherCost()
        {
            OtherCost otherCost = null;

            string sql = "SELECT * " +
                         "FROM " + OtherCost.tableName + " " +
                         "ORDER BY " + OtherCost.columnOtherCostId + " DESC " +
                         "LIMIT 1";

            List<OtherCost> otherCostList = this.otherCostDao.processQueryString(sql);
            if (otherCostList.Count > 0)
            {
                otherCost = otherCostList[0];
            }

            return otherCost;
        }

        public OtherCost getOtherCost(int otherCostId)
        {
            OtherCost otherCost = null;

            string sql = "SELECT * " +
                         "FROM " + OtherCost.tableName + " " +
                         "WHERE " + OtherCost.columnOtherCostId + " = " + otherCostId;

            List<OtherCost> otherCostList = this.otherCostDao.processQueryString(sql);
            if (otherCostList.Count > 0)
            {
                otherCost = otherCostList[0];
            }

            return otherCost;
        }

        public OtherCost getOtherCost(string otherCostName, double otherCostPrice)
        {
            OtherCost otherCost = null;

            string sql = "SELECT * " +
                         "FROM " + OtherCost.tableName + " " +
                         "WHERE " + OtherCost.columnOtherCostName + " = '" + otherCostName + "' " +
                         "AND " + OtherCost.columnOtherCostPrice + " = " + otherCostPrice;
            /*
            string sql = "SELECT * " +
                         "FROM OtherCosts " +
                         "WHERE otherCostName = '" + otherCostName + "' " +
                         "AND otherCostPrice = " + otherCostPrice;
            */
            List<OtherCost> otherCostList = this.otherCostDao.processQueryString(sql);
            if (otherCostList.Count > 0)
            {
                otherCost = otherCostList[0];
            }

            return otherCost;
        }

        public List<OtherCost> getAllOtherCost()
        {
            string sql = "SELECT * " +
                         "FROM " + OtherCost.tableName + " " +
                         "ORDER BY " + OtherCost.columnOtherCostId + " ASC";

            return this.otherCostDao.processQueryString(sql);
        }

        public List<OtherCost> getAllOtherCost_Old()
        {
            string sql = "SELECT * " +
                         "FROM " + OtherCost.tableName + "_old " +
                         "ORDER BY " + OtherCost.columnOtherCostId + " ASC";

            return this.otherCostDao.processQueryString(sql);
        }

        //Temporary
        public bool matchOtherCostId(int oldOtherCostId, int newOtherCostId)
        {
            string sql = "INSERT INTO " +
                         OtherCost.matchingTableName + " (" +
                         OtherCost.columnOldOtherCostId + ", " +
                         OtherCost.columnNewOtherCostId + ") " +
                         "VALUES(" +
                         "?" + OtherCost.columnOldOtherCostId + ", " +
                         "?" + OtherCost.columnNewOtherCostId + ")";

            return this.otherCostDao.processInsertStringForMathching(sql, oldOtherCostId, newOtherCostId);
        }

        public int getNewOtherCostId(int oldOtherCostId)
        {
            string sql = "SELECT * " +
                         "FROM " + OtherCost.matchingTableName + " " +
                         "WHERE " + OtherCost.columnOldOtherCostId + " = " + oldOtherCostId;

            return this.otherCostDao.processQueryStringForMatching(sql);
        }
    }
}
