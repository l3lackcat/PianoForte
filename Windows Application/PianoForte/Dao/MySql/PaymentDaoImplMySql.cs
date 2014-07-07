using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;

using PianoForte.Dao;
using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.Dao.MySql
{
    public class PaymentDaoImplMySql : PaymentDao
    {
        //--------------------------------------------------------------------------------

        public bool insertPayment(Payment payment)
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

            return this.processInsertCommand(sql, payment);
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

            return this.processUpdateCommand(sql, payment);
        }

        public bool deletePayment(int paymentId)
        {
            string sql = "DELETE " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " = " + paymentId;

            return this.processDeleteCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public Payment findPayment(int paymentId)
        {
            Payment payment = null;

            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " = " + paymentId;

            List<Payment> paymentList = this.processSelectCommand(sql);
            if (paymentList.Count > 0)
            {
                payment = paymentList[0];
            }

            return payment;
        }

        public Payment findLastPayment()
        {
            Payment payment = null;

            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "ORDER BY " + Payment.columnPaymentId + " DESC " +
                         "LIMIT 1";

            List<Payment> paymentList = this.processSelectCommand(sql);
            if (paymentList.Count > 0)
            {
                payment = paymentList[0];
            }

            return payment;
        }        

        public Payment findLastPrintedPayment()
        {
            Payment payment = null;

            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPrintPaymentId + " = " +
                         "(SELECT max(" + Payment.columnPrintPaymentId + ") " +
                         "FROM " + Payment.tableName + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            List<Payment> paymentList = this.processSelectCommand(sql);
            if (paymentList.Count > 0)
            {
                payment = paymentList[0];
            }

            return payment;
        }

        //--------------------------------------------------------------------------------

        public List<Payment> findAllPayment()
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }        

        public List<Payment> findAllPayment(int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubquery(startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPayment(Payment.PaymentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPayment(Payment.PaymentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubquery(status, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Payment> findAllPaymentByStudentId(int studentId)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentId(int studentId, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByStudentId(studentId, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentId(int studentId, Payment.PaymentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                         "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentId(int studentId, Payment.PaymentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByStudentId(studentId, status, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByCreditCardNumber(creditCardNumber, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber, Payment.PaymentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                         "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber, Payment.PaymentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByCreditCardNumber(creditCardNumber, status, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " + 
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByDate(startDate, endDate, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate, Payment.PaymentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByDate(startDate, endDate, status, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                         "AND " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByStudentIdAndCreditCardNumber(studentId, creditCardNumber, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, Payment.PaymentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                         "AND " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                         "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, Payment.PaymentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByStudentIdAndCreditCardNumber(studentId, creditCardNumber, status, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                         "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByStudentIdAndDate(studentId, startDate, endDate, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, Payment.PaymentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnStudentId + " = " + studentId + " " +                         
                         "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByStudentIdAndDate(studentId, startDate, endDate, status, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                         "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByCreditCardNumberAndDate(creditCardNumber, startDate, endDate, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                         "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByCreditCardNumberAndDate(creditCardNumber, startDate, endDate, status, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                         "AND " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                         "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnStudentId + " = " + studentId + " " +                         
                         "AND " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                         "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payment.tableName + " " +
                         "WHERE " + Payment.columnPaymentId + " IN " +
                         "(" + this.getPaymentSubqueryByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate, status, startIndex, offset) + ") " +
                         "ORDER BY " + Payment.columnPaymentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        private string getPaymentSubquery(int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubquery(Payment.PaymentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getPaymentSubqueryByStudentId(int studentId, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByStudentId(int studentId, Payment.PaymentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getPaymentSubqueryByCreditCardNumber(string creditCardNumber, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getPaymentSubqueryByCreditCardNumber(string creditCardNumber, Payment.PaymentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

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

        private string getPaymentSubqueryByDate(DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
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

        //--------------------------------------------------------------------------------

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

        private string getPaymentSubqueryByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, Payment.PaymentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "AND " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

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

        private string getPaymentSubqueryByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }
        
        //--------------------------------------------------------------------------------

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

        private string getPaymentSubqueryByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

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

        private string getPaymentSubqueryByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Payment.columnPaymentId + " " +
                   "FROM " + Payment.tableName + " " +
                   "WHERE " + Payment.columnStudentId + " = " + studentId + " " +
                   "AND " + Payment.columnCreditCardNumber + " = '" + creditCardNumber + "' " +
                   "AND " + Payment.columnPaymentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnPaymentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                   "AND " + Payment.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private bool processInsertCommand(string sql, Payment payment)
        {
            bool returnFlag = false;
            
            if (payment != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Payment.columnPrintPaymentId, payment.PrintPaymentId);
                        command.Parameters.AddWithValue(Payment.columnStudentId, payment.StudentId);
                        command.Parameters.AddWithValue(Payment.columnTotalPrice, payment.TotalPrice);
                        command.Parameters.AddWithValue(Payment.columnTotalPriceText, payment.TotalPriceText);
                        command.Parameters.AddWithValue(Payment.columnCreditCardNumber, payment.CreditCardNumber);
                        command.Parameters.AddWithValue(Payment.columnPaymentDate, payment.PaymentDate);
                        command.Parameters.AddWithValue(Payment.columnStatus, payment.Status);
                        command.Parameters.AddWithValue(Payment.columnReceiverId, payment.ReceiverId);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (MySqlException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (System.SystemException e)
                {
                    LogManager.writeLog(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            
            return returnFlag;
        }

        private bool processUpdateCommand(string sql, Payment payment)
        {
            bool returnFlag = false;
            
            if (payment != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Payment.columnPrintPaymentId, payment.PrintPaymentId);
                        command.Parameters.AddWithValue(Payment.columnStudentId, payment.StudentId);
                        command.Parameters.AddWithValue(Payment.columnTotalPrice, payment.TotalPrice);
                        command.Parameters.AddWithValue(Payment.columnTotalPriceText, payment.TotalPriceText);
                        command.Parameters.AddWithValue(Payment.columnCreditCardNumber, payment.CreditCardNumber);
                        command.Parameters.AddWithValue(Payment.columnPaymentDate, payment.PaymentDate);
                        command.Parameters.AddWithValue(Payment.columnStatus, payment.Status);
                        command.Parameters.AddWithValue(Payment.columnReceiverId, payment.ReceiverId);
                        command.Parameters.AddWithValue(Payment.columnPaymentId, payment.Id);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (MySqlException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (System.SystemException e)
                {
                    LogManager.writeLog(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            
            return returnFlag;
        }

        private bool processDeleteCommand(string sql)
        {
            bool returnFlag = false;
            
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);

                    int affectedRow = command.ExecuteNonQuery();
                    if (affectedRow != -1)
                    {
                        returnFlag = true;
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (MySqlException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (System.SystemException e)
            {
                LogManager.writeLog(e.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return returnFlag;
        }

        private List<Payment> processSelectCommand(string sql)
        {
            List<Payment> paymentList = new List<Payment>();
            
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                    DataSet data = new DataSet();
                    dataAdapter.Fill(data, Payment.tableName);

                    for (int i = 0; i < data.Tables[Payment.tableName].Rows.Count; i++)
                    {
                        paymentList.Add(generatePayment(data, i));
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (MySqlException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (System.SystemException e)
            {
                LogManager.writeLog(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return paymentList;
        }

        private Payment generatePayment(DataSet data, int index)
        {
            Payment payment = new Payment();
            payment.Id = Convert.ToInt32(data.Tables[Payment.tableName].Rows[index][Payment.columnPaymentId].ToString());
            payment.PrintPaymentId = Convert.ToInt32(data.Tables[Payment.tableName].Rows[index][Payment.columnPrintPaymentId].ToString());
            payment.StudentId = Convert.ToInt32(data.Tables[Payment.tableName].Rows[index][Payment.columnStudentId].ToString());
            payment.ReceiverId = Convert.ToInt32(data.Tables[Payment.tableName].Rows[index][Payment.columnReceiverId].ToString());
            payment.TotalPrice = Convert.ToDouble(data.Tables[Payment.tableName].Rows[index][Payment.columnTotalPrice].ToString());
            payment.TotalPriceText = data.Tables[Payment.tableName].Rows[index][Payment.columnTotalPriceText].ToString();
            payment.CreditCardNumber = data.Tables[Payment.tableName].Rows[index][Payment.columnCreditCardNumber].ToString();
            payment.PaymentDate = (DateTime)data.Tables[Payment.tableName].Rows[index][Payment.columnPaymentDate];
            payment.Status = data.Tables[Payment.tableName].Rows[index][Payment.columnStatus].ToString();            
            
            return payment;
        }

        //--------------------------------------------------------------------------------
    }
}
