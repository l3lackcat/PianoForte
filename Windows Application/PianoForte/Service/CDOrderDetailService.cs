using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class CdOrderDetailService
    {
        private CdOrderDetailDaoImplMySql cdOrderDetailDao = new CdOrderDetailDaoImplMySql();

        public bool addCdOrderDetail(CdOrderDetail cdOrderDetail)
        {
            string sql = "INSERT INTO " +
                         CdOrderDetail.tableName + " (" +
                         CdOrderDetail.columnPaymentId + ", " +
                         CdOrderDetail.columnStudentId + ", " +
                         CdOrderDetail.columnCdId + ", " +
                         CdOrderDetail.columnAmount + ", " +
                         CdOrderDetail.columnTotalPrice + ", " +
                         CdOrderDetail.columnOrderDate + ", " +
                         CdOrderDetail.columnStatus + ") " +
                         "VALUES(" +
                         "?" + CdOrderDetail.columnPaymentId + ", " +
                         "?" + CdOrderDetail.columnStudentId + ", " +
                         "?" + CdOrderDetail.columnCdId + ", " +
                         "?" + CdOrderDetail.columnAmount + ", " +
                         "?" + CdOrderDetail.columnTotalPrice + ", " +
                         "?" + CdOrderDetail.columnOrderDate + ", " +
                         "?" + CdOrderDetail.columnStatus + ")";
            /*
            string sql = "INSERT INTO " +
                         "CDOrderDetail(studentID, cdID, amount, totalPrice, orderDate, status, paymentID)" +
                         "VALUES(?studentID, ?cdID, ?amount, ?totalPrice, ?orderDate, ?status, ?paymentID)";
            */
            return this.cdOrderDetailDao.processInsertString(sql, cdOrderDetail);
        }

        public bool updateCdOrderDetail(CdOrderDetail cdOrderDetail)
        {
            string sql = "UPDATE " +
                         CdOrderDetail.tableName + " SET " +
                         CdOrderDetail.columnPaymentId + " = ?" + CdOrderDetail.columnPaymentId + ", " +
                         CdOrderDetail.columnStudentId + " = ?" + CdOrderDetail.columnStudentId + ", " +
                         CdOrderDetail.columnCdId + " = ?" + CdOrderDetail.columnCdId + ", " +
                         CdOrderDetail.columnAmount + " = ?" + CdOrderDetail.columnAmount + ", " +
                         CdOrderDetail.columnTotalPrice + " = ?" + CdOrderDetail.columnTotalPrice + ", " +
                         CdOrderDetail.columnOrderDate + " = ?" + CdOrderDetail.columnOrderDate + ", " +
                         CdOrderDetail.columnStatus + " = ?" + CdOrderDetail.columnStatus + " " +
                         "WHERE " + CdOrderDetail.columnCdOrderDetailId + " = ?" + CdOrderDetail.columnCdOrderDetailId;
            /*
            string sql = "UPDATE CDOrderDetail SET " +
                         "studentID = ?studentID, " +
                         "cdID = ?cdID, " +
                         "amount = ?amount, " +
                         "totalPrice = ?totalPrice, " +
                         "orderDate = ?orderDate, " +
                         "status = ?status, " +
                         "paymentID = ?paymentID " +
                         "WHERE cdOrderID = ?cdOrderID";
            */
            return this.cdOrderDetailDao.processUpdateString(sql, cdOrderDetail);
        }

        public bool deleteCdOrderDetail(int cdOrderId)
        {
            string sql = "DELETE " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "WHERE " + CdOrderDetail.columnCdOrderDetailId + " = " + cdOrderId;
            /*
            string sql = "DELETE FROM CDOrderDetail " +
                         "WHERE cdOrderID = " + cdOrderID;
            */
            return this.cdOrderDetailDao.processDeleteString(sql);
        }

        public CdOrderDetail getLastCdOrderDetail()
        {
            CdOrderDetail cdOrderDetail = null;

            string sql = "SELECT " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "ORDER BY " + CdOrderDetail.columnCdOrderDetailId + " DESC" +
                         "LIMIT 1,1";
            /*
            string sql = "SELECT TOP 1 * " +
                         "FROM CDOrderDetail " +
                         "ORDER BY cdOrderID DESC";
            */
            List<CdOrderDetail> cdOrderDetailList = this.cdOrderDetailDao.processQueryString(sql);
            if (cdOrderDetailList.Count > 0)
            {
                cdOrderDetail = cdOrderDetailList[0];
            }

            return cdOrderDetail;
        }

        public CdOrderDetail getCdOrderDetail(int cdOrderId)
        {
            CdOrderDetail cdOrderDetail = null;

            string sql = "SELECT * " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "WHERE " + CdOrderDetail.columnCdOrderDetailId + " = " + cdOrderId;
            /*
            string sql = "SELECT * " +
                         "FROM CDOrderDetail " +
                         "WHERE cdOrderID = " + cdOrderID;
            */
            List<CdOrderDetail> cdOrderDetailList = this.cdOrderDetailDao.processQueryString(sql);
            if (cdOrderDetailList.Count > 0)
            {
                cdOrderDetail = cdOrderDetailList[0];
            }

            return cdOrderDetail;
        }

        public List<CdOrderDetail> getAllCdOrderDetail()
        {
            string sql = "SELECT * " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "ORDER BY " + CdOrderDetail.columnCdOrderDetailId + " ASC";
            /*
            string sql = "SELECT * " +
                         "FROM CDOrderDetail " +
                         "ORDER BY cdOrderID ASC";
            */
            return this.cdOrderDetailDao.processQueryString(sql);
        }

        public List<CdOrderDetail> getAllCdOrderDetail(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "WHERE " + CdOrderDetail.columnOrderDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + CdOrderDetail.columnOrderDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + CdOrderDetail.columnCdOrderDetailId + " ASC";
            /*
            string sql = "SELECT * " +
                         "FROM CDOrderDetail " +
                         "WHERE orderDate BETWEEN '" + startDate + "' AND '" + endDate + "' " +
                         "ORDER BY cdOrderID ASC";
            */
            return this.cdOrderDetailDao.processQueryString(sql);
        }

        public List<CdOrderDetail> getAllCdOrderDetailByStudentId(int studentId)
        {
            string sql = "SELECT * " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "WHERE " + CdOrderDetail.columnStudentId + " = " + studentId + " " +
                         "ORDER BY " + CdOrderDetail.columnCdOrderDetailId + " ASC";
            /*
            string sql = "SELECT * " +
                         "FROM CDOrderDetail " +
                         "WHERE studentID = " + studentID + " " +
                         "ORDER BY cdOrderID ASC";
            */
            return this.cdOrderDetailDao.processQueryString(sql);
        }

        public List<CdOrderDetail> getAllCdOrderDetailByPaymentId(int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "WHERE " + CdOrderDetail.columnPaymentId + " = " + paymentId + " " +
                         "ORDER BY " + CdOrderDetail.columnCdOrderDetailId + " ASC";
            /*
            string sql = "SELECT * " +
                         "FROM CDOrderDetail " +
                         "WHERE paymentID = " + paymentId + " " +
                         "ORDER BY cdOrderID ASC";
            */
            return this.cdOrderDetailDao.processQueryString(sql);
        }
    }
}
