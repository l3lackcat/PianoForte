using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class CdService
    {
        private CdDaoImplMySql cdDao = new CdDaoImplMySql();

        public bool addCd(Cd cd)
        {
            string sql = "INSERT INTO " +
                         Cd.tableName + " (" +
                         Cd.columnCdId + ", " +
                         Cd.columnCdBarcode + ", " +
                         Cd.columnCdName + ", " +
                         Cd.columnCdPrice + ", " +
                         Cd.columnCdAmount + ", " +
                         Cd.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Cd.columnCdId + ", " +
                         "?" + Cd.columnCdBarcode + ", " +
                         "?" + Cd.columnCdName + ", " +
                         "?" + Cd.columnCdPrice + ", " +
                         "?" + Cd.columnCdAmount + ", " +
                         "?" + Cd.columnStatus + ")";

            return this.cdDao.processInsertString(sql, cd);
        }

        public bool updateCd(Cd cd)
        {
            string sql = "UPDATE " +
                         Cd.tableName + " SET " +
                         Cd.columnCdBarcode + " = ?" + Cd.columnCdBarcode + ", " +
                         Cd.columnCdName + " = ?" + Cd.columnCdName + ", " +
                         Cd.columnCdPrice + " = ?" + Cd.columnCdPrice + ", " +
                         Cd.columnCdAmount + " = ?" + Cd.columnCdAmount + ", " +
                         Cd.columnStatus + " = ?" + Cd.columnStatus + " " +
                         "WHERE " + Cd.columnCdId + " = ?" + Cd.columnCdId;
            /*
            string sql = "UPDATE CDs SET " +
                         "barcode = ?barcode, " +
                         "cdName = ?cdName, " +
                         "cdPrice = ?cdPrice, " +
                         "amount = ?amount, " +
                         "status = ?status " +
                         "WHERE cdID = ?cdID";
            */
            return this.cdDao.processUpdateString(sql, cd);
        }

        public bool deleteCd(int cdId)
        {
            string sql = "DELETE " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " = " + cdId;
            /*
            string sql = "DELETE FROM CDs " +
                         "WHERE cdID = " + cdID;
            */
            return this.cdDao.processDeleteString(sql);
        }

        public Cd getLastCd()
        {
            Cd cd = null;

            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "ORDER BY " + Cd.columnCdId + " DESC " +
                         "LIMIT 1";

            List<Cd> cdList = this.cdDao.processQueryString(sql);
            if (cdList.Count > 0)
            {
                cd = cdList[0];
            }

            return cd;
        }

        public Cd getCd(int cdId)
        {
            Cd cd = null;

            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " = " + cdId;

            List<Cd> cdList = this.cdDao.processQueryString(sql);
            if (cdList.Count > 0)
            {
                cd = cdList[0];
            }

            return cd;
        }

        public List<Cd> getAllCd()
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCd(int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC"; 

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCd(string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnStatus + " LIKE '%" + status + "%' " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCd(string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnStatus + " LIKE '%" + status + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);

        }

        public List<Cd> getAllCdByBarcode(string cdBarcode)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdBarcode + " LIKE '%" + cdBarcode + "%' " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCdByBarcode(string cdBarcode, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdBarcode + " LIKE '%" + cdBarcode + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCdByBarcode(string cdBarcode, string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdBarcode + " LIKE '%" + cdBarcode + "%' " +
                         "AND " + Cd.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCdByBarcode(string cdBarcode, string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdBarcode + " LIKE '%" + cdBarcode + "%' " +
                         "AND " + Cd.columnStatus + " = '" + status + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);

        }

        public List<Cd> getAllCdByName(string cdName)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCdByName(string cdName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCdByName(string cdName, string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "AND " + Cd.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCdByName(string cdName, string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "AND " + Cd.columnStatus + " = '" + status + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCdByBarcodeAndName(string cdBarcode, string cdName)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdBarcode + " LIKE '%" + cdBarcode + "%' " +
                         "AND " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCdByBarcodeAndName(string cdBarcode, string cdName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdBarcode + " LIKE '%" + cdBarcode + "%' " +
                         "AND " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);

        }

        public List<Cd> getAllCdByBarcodeAndName(string cdBarcode, string cdName, string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdBarcode + " LIKE '%" + cdBarcode + "%' " +
                         "AND " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "AND " + Cd.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public List<Cd> getAllCdByBarcodeAndName(string cdBarcode, string cdName, string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdBarcode + " LIKE '%" + cdBarcode + "%' " +
                         "AND " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "AND " + Cd.columnStatus + " = '" + status + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public int getNewCdId(int oldCdId)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.matchingTableName + " " +
                         "WHERE " + Cd.columnOldCdId + " = " + oldCdId;

            return this.cdDao.processQueryStringForMatching(sql);
        }

        //Temporary
        public List<Cd> getAllCd_Old()
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + "_old " +
                         "ORDER BY " + Cd.columnCdId + " ASC";

            return this.cdDao.processQueryString(sql);
        }

        public bool matchCdId(int oldCdId, int newCdId)
        {
            string sql = "INSERT INTO " +
                         Cd.matchingTableName + " (" +
                         Cd.columnOldCdId + ", " +
                         Cd.columnNewCdId + ") " +
                         "VALUES(" +
                         "?" + Cd.columnOldCdId + ", " +
                         "?" + Cd.columnNewCdId + ")";

            return this.cdDao.processInsertStringForMathching(sql, oldCdId, newCdId);
        }        
    }
}
