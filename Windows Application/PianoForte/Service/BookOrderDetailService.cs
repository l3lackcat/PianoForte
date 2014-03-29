using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class BookOrderDetailService
    {
        private BookOrderDetailDao bookOrderDetailDao = new BookOrderDetailDao();

        public bool addBookOrderDetail(BookOrderDetail bookOrderDetail)
        {
            string sql = "INSERT INTO " +
                         BookOrderDetail.tableName + " (" +
                         BookOrderDetail.columnPaymentId + ", " +
                         BookOrderDetail.columnStudentId + ", " +
                         BookOrderDetail.columnBookId + ", " +
                         BookOrderDetail.columnAmount + ", " +
                         BookOrderDetail.columnTotalPrice + ", " +
                         BookOrderDetail.columnOrderDate + ", " +
                         BookOrderDetail.columnStatus + ") " +
                         "VALUES(" +
                         "?" + BookOrderDetail.columnPaymentId + ", " +
                         "?" + BookOrderDetail.columnStudentId + ", " +
                         "?" + BookOrderDetail.columnBookId + ", " +
                         "?" + BookOrderDetail.columnAmount + ", " +
                         "?" + BookOrderDetail.columnTotalPrice + ", " +
                         "?" + BookOrderDetail.columnOrderDate + ", " +
                         "?" + BookOrderDetail.columnStatus + ")";

            return this.bookOrderDetailDao.processInsertString(sql, bookOrderDetail);
        }

        public bool updateBookOrderDetail(BookOrderDetail bookOrderDetail)
        {
            string sql = "UPDATE " +
                         BookOrderDetail.tableName + " SET " +
                         BookOrderDetail.columnPaymentId + " = ?" + BookOrderDetail.columnPaymentId + ", " +
                         BookOrderDetail.columnStudentId + " = ?" + BookOrderDetail.columnStudentId + ", " +
                         BookOrderDetail.columnBookId + " = ?" + BookOrderDetail.columnBookId + ", " +
                         BookOrderDetail.columnAmount + " = ?" + BookOrderDetail.columnAmount + ", " +
                         BookOrderDetail.columnTotalPrice + " = ?" + BookOrderDetail.columnTotalPrice + ", " +
                         BookOrderDetail.columnOrderDate + " = ?" + BookOrderDetail.columnOrderDate + ", " +
                         BookOrderDetail.columnStatus + " = ?" + BookOrderDetail.columnStatus + ", " +
                         "WHERE " + BookOrderDetail.columnBookOrderDetailId + " = ?" + BookOrderDetail.columnBookOrderDetailId;

            return this.bookOrderDetailDao.processUpdateString(sql, bookOrderDetail);
        }

        public bool deleteBookOrderDetail(int bookOrderId)
        {
            string sql = "DELETE " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "WHERE " + BookOrderDetail.columnBookOrderDetailId + " = " + bookOrderId;

            return this.bookOrderDetailDao.processDeleteString(sql);
        }

        public BookOrderDetail getLastBookOrderDetail()
        {
            BookOrderDetail bookOrderDetail = null;

            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "ORDER BY " + BookOrderDetail.columnBookOrderDetailId + " DESC " +
                         "LIMIT 1";

            List<BookOrderDetail> bookOrderDetailList = this.bookOrderDetailDao.processQueryString(sql);
            if (bookOrderDetailList.Count > 0)
            {
                bookOrderDetail = bookOrderDetailList[0];
            }

            return bookOrderDetail;
        }

        public BookOrderDetail getBookOrderDetail(int bookOrderId)
        {
            BookOrderDetail bookOrderDetail = null;

            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "WHERE " + BookOrderDetail.columnBookOrderDetailId + " = " + bookOrderId;

            List<BookOrderDetail> bookOrderDetailList = this.bookOrderDetailDao.processQueryString(sql);
            if (bookOrderDetailList.Count > 0)
            {
                bookOrderDetail = bookOrderDetailList[0];
            }

            return bookOrderDetail;
        }

        public List<BookOrderDetail> getAllBookOrderDetailByDate()
        {
            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "ORDER BY " + BookOrderDetail.columnBookOrderDetailId + " ASC";

            return this.bookOrderDetailDao.processQueryString(sql);
        }

        public List<BookOrderDetail> getAllBookOrderDetailByDate(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "WHERE " + BookOrderDetail.columnOrderDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + BookOrderDetail.columnOrderDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + BookOrderDetail.columnBookOrderDetailId + " ASC";

            return this.bookOrderDetailDao.processQueryString(sql);
        }

        public List<BookOrderDetail> getAllBookOrderDetailByStudentId(int studentId)
        {
            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "WHERE " + BookOrderDetail.columnStudentId + " = " + studentId + " " + 
                         "ORDER BY " + BookOrderDetail.columnBookOrderDetailId + " ASC";

            return this.bookOrderDetailDao.processQueryString(sql);
        }

        public List<BookOrderDetail> getAllBookOrderDetailByPaymentId(int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "WHERE " + BookOrderDetail.columnPaymentId + " = " + paymentId + " " +
                         "ORDER BY " + BookOrderDetail.columnBookOrderDetailId + " ASC";

            return this.bookOrderDetailDao.processQueryString(sql);
        }
    }
}
