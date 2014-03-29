using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class OtherCostOrderDetailService
    {
        private OtherCostOrderDetailDao otherCostOrderDetailDao = new OtherCostOrderDetailDao();

        public bool addOtherCostOrderDetail(OtherCostOrderDetail otherCostOrderDetail)
        {
            string sql = "INSERT INTO " +
                         OtherCostOrderDetail.tableName + " (" +
                         OtherCostOrderDetail.columnPaymentId + ", " +
                         OtherCostOrderDetail.columnStudentId + ", " +
                         OtherCostOrderDetail.columnOtherCostId + ", " +
                         OtherCostOrderDetail.columnTotalPrice + ", " +
                         OtherCostOrderDetail.columnOrderDate + ", " +
                         OtherCostOrderDetail.columnStatus + ") " +
                         "VALUES(" +
                         "?" + OtherCostOrderDetail.columnPaymentId + ", " +
                         "?" + OtherCostOrderDetail.columnStudentId + ", " +
                         "?" + OtherCostOrderDetail.columnOtherCostId + ", " +
                         "?" + OtherCostOrderDetail.columnTotalPrice + ", " +
                         "?" + OtherCostOrderDetail.columnOrderDate + ", " +
                         "?" + OtherCostOrderDetail.columnStatus + ")";
            /*
            string sql = "INSERT INTO " +
                         "OtherCostOrderDetail(studentID, otherCostID, totalPrice, orderDate, status, paymentID)" +
                         "VALUES(?studentID, ?otherCostID, ?totalPrice, ?orderDate, ?status, ?paymentID)";
            */
            return this.otherCostOrderDetailDao.processInsertString(sql, otherCostOrderDetail);
        }

        public bool updateOtherCostOrderDetail(OtherCostOrderDetail otherCostOrderDetail)
        {
            string sql = "UPDATE " +
                         OtherCostOrderDetail.tableName + " SET " +
                         OtherCostOrderDetail.columnPaymentId + " = ?" + OtherCostOrderDetail.columnPaymentId + ", " +
                         OtherCostOrderDetail.columnStudentId + " = ?" + OtherCostOrderDetail.columnStudentId + ", " +
                         OtherCostOrderDetail.columnOtherCostId + " = ?" + OtherCostOrderDetail.columnOtherCostId + ", " +
                         OtherCostOrderDetail.columnTotalPrice + " = ?" + OtherCostOrderDetail.columnTotalPrice + ", " +
                         OtherCostOrderDetail.columnOrderDate + " = ?" + OtherCostOrderDetail.columnOrderDate + ", " +
                         OtherCostOrderDetail.columnStatus + " = ?" + OtherCostOrderDetail.columnStatus + " " +
                         "WHERE " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " = ?" + OtherCostOrderDetail.columnOtherCostOrderDetailId;
            /*
            string sql = "UPDATE OtherCostOrderDetail SET " +
                         "studentID = ?studentID, " +
                         "otherCostID = ?otherCostID, " +
                         "totalPrice = ?totalPrice, " +
                         "orderDate = ?orderDate, " +
                         "status = ?status, " +
                         "paymentID = ?paymentID " +
                         "WHERE otherCostOrderID = ?otherCostOrderID";
            */
            return this.otherCostOrderDetailDao.processUpdateString(sql, otherCostOrderDetail);
        }

        public bool deleteOtherCostOrderDetail(int otherCostOrderId)
        {
            string sql = "DELETE " +
                         "FROM " + OtherCostOrderDetail.tableName + " " +
                         "WHERE " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " = " + otherCostOrderId;
            /*
            string sql = "DELETE FROM OtherCostOrderDetail " +
                         "WHERE otherCostOrderID = " + otherCostOrderId;
            */
            return this.otherCostOrderDetailDao.processDeleteString(sql);
        }

        public OtherCostOrderDetail getLastOtherCostOrderDetail()
        {
            OtherCostOrderDetail otherCostOrderDetail = null;

            string sql = "SELECT * " +
                         "FROM " + OtherCostOrderDetail.tableName + " " +
                         "ORDER BY " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " DESC" +
                         "LIMIT 1,1";
            /*
            string sql = "SELECT TOP 1 * " +
                         "FROM OtherCostOrderDetail " +
                         "ORDER BY otherCostOrderID DESC";
            */
            List<OtherCostOrderDetail> otherCostOrderDetailList = this.otherCostOrderDetailDao.processQueryString(sql);
            if (otherCostOrderDetailList.Count > 0)
            {
                otherCostOrderDetail = otherCostOrderDetailList[0];
            }

            return otherCostOrderDetail;
        }

        public OtherCostOrderDetail getOtherCostOrderDetail(int otherCostOrderId)
        {
            OtherCostOrderDetail otherCostOrderDetail = null;

            string sql = "SELECT * " +
                         "FROM " + OtherCostOrderDetail.tableName + " " +
                         "WHERE " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " = " + otherCostOrderId;
            /*
            string sql = "SELECT * " +
                         "FROM OtherCostOrderDetail " +
                         "WHERE otherCostOrderID = " + otherCostOrderId;
            */
            List<OtherCostOrderDetail> otherCostOrderDetailList = this.otherCostOrderDetailDao.processQueryString(sql);
            if (otherCostOrderDetailList.Count > 0)
            {
                otherCostOrderDetail = otherCostOrderDetailList[0];
            }

            return otherCostOrderDetail;
        }

        public List<OtherCostOrderDetail> getAllOtherCostOrderDetail()
        {
            string sql = "SELECT * " +
                         "FROM " + OtherCostOrderDetail.tableName + " " +
                         "ORDER BY " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " ASC";
            /*
            string sql = "SELECT * " +
                         "FROM OtherCostOrderDetail " +
                         "ORDER BY otherCostOrderID ASC";
            */
            return this.otherCostOrderDetailDao.processQueryString(sql);
        }

        public List<OtherCostOrderDetail> getAllOtherCostOrderDetailByPaymentId(int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + OtherCostOrderDetail.tableName + " " +
                         "WHERE " + OtherCostOrderDetail.columnPaymentId + " = " + paymentId + " " +
                         "ORDER BY " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " ASC";
            /*
            string sql = "SELECT * " +
                         "FROM OtherCostOrderDetail " +
                         "WHERE paymentID = " + paymentId + " " +
                         "ORDER BY otherCostOrderID ASC";
            */
            return this.otherCostOrderDetailDao.processQueryString(sql);
        }
    }
}
