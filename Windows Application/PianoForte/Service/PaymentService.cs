using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class PaymentService
    {
        private PaymentDao paymentDao = new PaymentDao();

        public bool addPayment(Payment payment)
        {
            string sql = "INSERT INTO " +
                         Payment.tableName + " (" +
                         Payment.columnPrintPaymentId + ", " +
                         Payment.columnStudentId + ", " +
                         Payment.columnReceiverId + ", " +
                         Payment.columnCreditCardNumber + ", " +
                         Payment.columnTotalPrice + ", " +
                         Payment.columnTotalPriceText + ", " +
                         Payment.columnPaymentDate + ", " +
                         Payment.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Payment.columnPrintPaymentId + ", " +
                         "?" + Payment.columnStudentId + ", " +
                         "?" + Payment.columnReceiverId + ", " +
                         "?" + Payment.columnCreditCardNumber + ", " +
                         "?" + Payment.columnTotalPrice + ", " +
                         "?" + Payment.columnTotalPriceText + ", " +
                         "?" + Payment.columnPaymentDate + ", " +
                         "?" + Payment.columnStatus + ")";

            return this.paymentDao.processInsertString(sql, payment);
        }

        public bool updatePayment(Payment payment)
        {
            string sql = "UPDATE " +
                         Payment.tableName + " SET " +
                         Payment.columnPrintPaymentId + " = ?" + Payment.columnPrintPaymentId + ", " +
                         Payment.columnStudentId + " = ?" + Payment.columnStudentId + ", " +
                         Payment.columnReceiverId + " = ?" + Payment.columnReceiverId + ", " +
                         Payment.columnCreditCardNumber + " = ?" + Payment.columnCreditCardNumber + ", " +
                         Payment.columnTotalPrice + " = ?" + Payment.columnTotalPrice + ", " +
                         Payment.columnTotalPriceText + " = ?" + Payment.columnTotalPriceText + ", " +
                         Payment.columnPaymentDate + " = ?" + Payment.columnPaymentDate + ", " +
                         Payment.columnStatus + " = ?" + Payment.columnStatus + " " +
                         "WHERE " + Payment.columnPaymentId + " = ?" + Payment.columnPaymentId;

            return this.paymentDao.processUpdateString(sql, payment);
        }

        public bool deletePayment(int paymentId)
        {
            string sql = "DELETE " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " = " + paymentId;

            return this.paymentDao.processDeleteString(sql);
        }

        public Payment getLastPayment()
        {
            Payment payment = null;

            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "ORDER BY " + Payment.columnPaymentId + " DESC " +
                         "LIMIT 1";

            List<Payment> paymentList = this.paymentDao.processQueryString(sql);
            if (paymentList.Count > 0)
            {
                payment = paymentList[0];
            }

            return payment;
        }

        public Payment getPayment(int paymentId)
        {
            Payment payment = null;

            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " = " + paymentId;

            List<Payment> paymentList = this.paymentDao.processQueryString(sql);
            if (paymentList.Count > 0)
            {
                payment = paymentList[0];
            }

            return payment;
        }

        public List<Payment> getAllPayment()
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.paymentDao.processQueryString(sql);
        }        

        public List<Payment> getAllPayment(int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubquery(startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC"; 

            return this.paymentDao.processQueryString(sql);
        }

        public List<Payment> getAllPayment(string status, DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.paymentDao.processQueryString(sql);
        }

        public List<Payment> getAllPayment(int studentId, string creditCardNumber, string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubquery(studentId, creditCardNumber, status, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.paymentDao.processQueryString(sql);
        }        

        public List<Payment> getAllPayment(int studentId, string creditCardNumber, string status, DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubquery(studentId, creditCardNumber, status, startDate, endDate, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.paymentDao.processQueryString(sql);
        }

        private string getPaymentSubquery(int studentId, string creditCardNumber, string status, int startIndex, int offset)
        {
            string subQuery = "";

            if ((studentId != -1) && (creditCardNumber != ""))
            {
                if (status == Constant.Constant.ALL_EN)
                {
                    subQuery = this.getPaymentSubqueryByStudentIdAndCreditCardNumber(studentId, creditCardNumber, startIndex, offset);
                }
                else
                {
                    subQuery = this.getPaymentSubqueryByStudentIdAndCreditCardNumber(studentId, creditCardNumber, status, startIndex, offset);
                }
            }
            else if ((studentId != -1) && (creditCardNumber == ""))
            {
                if (status == Constant.Constant.ALL_EN)
                {
                    subQuery = this.getPaymentSubqueryByStudentId(studentId, startIndex, offset);
                }
                else
                {
                    subQuery = this.getPaymentSubqueryByStudentId(studentId, status, startIndex, offset);
                }
            }
            else if ((studentId == -1) && (creditCardNumber != ""))
            {
                if (status == Constant.Constant.ALL_EN)
                {
                    subQuery = this.getPaymentSubqueryByCreditCardNumber(creditCardNumber, startIndex, offset);
                }
                else
                {
                    subQuery = this.getPaymentSubqueryByCreditCardNumber(creditCardNumber, status, startIndex, offset);
                }
            }
            else if ((studentId == -1) && (creditCardNumber == ""))
            {
                if (status == Constant.Constant.ALL_EN)
                {
                    subQuery = this.getPaymentSubquery(startIndex, offset);
                }
                else
                {
                    subQuery = this.getPaymentSubquery(status, startIndex, offset);
                }
            }

            return subQuery;
        }

        private string getPaymentSubquery(int studentId, string creditCardNumber, string status, DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            string subQuery = "";

            if ((studentId != -1) && (creditCardNumber != ""))
            {
                if (status == Constant.Constant.ALL_EN)
                {
                    subQuery = this.getPaymentSubqueryByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate, startIndex, offset);
                }
                else
                {
                    subQuery = this.getPaymentSubqueryByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate, status, startIndex, offset);
                }
            }
            else if ((studentId != -1) && (creditCardNumber == ""))
            {
                if (status == Constant.Constant.ALL_EN)
                {
                    subQuery = this.getPaymentSubqueryByStudentIdAndDate(studentId, startDate, endDate, startIndex, offset);
                }
                else
                {
                    subQuery = this.getPaymentSubqueryByStudentIdAndDate(studentId, startDate, endDate, status, startIndex, offset);
                }
            }
            else if ((studentId == -1) && (creditCardNumber != ""))
            {
                if (status == Constant.Constant.ALL_EN)
                {
                    subQuery = this.getPaymentSubqueryByCreditCardNumberAndDate(creditCardNumber, startDate, endDate, startIndex, offset);
                }
                else
                {
                    subQuery = this.getPaymentSubqueryByCreditCardNumberAndDate(creditCardNumber, startDate, endDate, status, startIndex, offset);
                }
            }
            else if ((studentId == -1) && (creditCardNumber == ""))
            {
                if (status == Constant.Constant.ALL_EN)
                {
                    subQuery = this.getPaymentSubqueryByDate(startDate, endDate, startIndex, offset);
                }
                else
                {
                    subQuery = this.getPaymentSubqueryByDate(startDate, endDate, status, startIndex, offset);
                }
            }

            return subQuery;
        }

        private string getPaymentSubquery(int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubquery(string status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStatus + " = '" + status + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByStudentId(int studentId, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByStudentId(int studentId, string status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "AND " + Payment.columnStatus + " = '" + status + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByCreditCardNumber(string creditCardNumber, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByCreditCardNumber(string creditCardNumber, string status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "AND " + Payment.columnStatus + " = '" + status + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByDate(DateTime startDate, DateTime endDate, int startIndex, int offset)
        {            
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByDate(DateTime startDate, DateTime endDate, string status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnStatus + " = '" + status + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "AND " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, string status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "AND " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "AND " + Payment.columnStatus + " = '" + status + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, string status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnStatus + " = '" + status + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, string status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnStatus + " = '" + status + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "AND " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, string status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "AND " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnStatus + " = '" + status + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        public Payment getLastPrintedPayment()
        {
            Payment payment = null;

            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPrintPaymentId + " = " +
                         "(SELECT max(" + Payment.columnPrintPaymentId + ") " +
                         "FROM " + Payment.tableName + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            List<Payment> paymentList = this.paymentDao.processQueryString(sql);
            if (paymentList.Count > 0)
            {
                payment = paymentList[0];
            }

            return payment;
        }        
    }
}
