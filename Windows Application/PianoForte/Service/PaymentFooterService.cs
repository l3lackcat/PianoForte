using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class PaymentFooterService
    {
        private PaymentFooterDao paymentFooterDao = new PaymentFooterDao();

        public bool addPaymentFooter(ReceiptFooter paymentFooter, int paymentID)
        {
            string sql = "INSERT INTO " +
                         ReceiptFooter.tableName + " (" +
                         ReceiptFooter.columnPaymentId + ", " +
                         ReceiptFooter.columnCourseName + ", " +
                         ReceiptFooter.columnCourseLevel + ", " +
                         ReceiptFooter.columnDate01 + ", " +
                         ReceiptFooter.columnDate02 + ", " +
                         ReceiptFooter.columnDate03 + ", " +
                         ReceiptFooter.columnDate04 + ", " +
                         ReceiptFooter.columnDate05 + ", " +
                         ReceiptFooter.columnDate06 + ", " +
                         ReceiptFooter.columnDate07 + ", " +
                         ReceiptFooter.columnDate08 + ", " +
                         ReceiptFooter.columnDate09 + ", " +
                         ReceiptFooter.columnDate10 + ", " +
                         ReceiptFooter.columnDate11 + ", " +
                         ReceiptFooter.columnDate12 + ", " +
                         ReceiptFooter.columnClassDay1 + ", " +
                         ReceiptFooter.columnClassTime1 + ", " +
                         ReceiptFooter.columnTeacher1 + ", " +
                         ReceiptFooter.columnClassDay2 + ", " +
                         ReceiptFooter.columnClassTime2 + ", " +
                         ReceiptFooter.columnTeacher2 + ") " +
                         "VALUES(" +
                         "?" + ReceiptFooter.columnPaymentId + ", " +
                         "?" + ReceiptFooter.columnCourseName + ", " +
                         "?" + ReceiptFooter.columnCourseLevel + ", " +
                         "?" + ReceiptFooter.columnDate01 + ", " +
                         "?" + ReceiptFooter.columnDate02 + ", " +
                         "?" + ReceiptFooter.columnDate03 + ", " +
                         "?" + ReceiptFooter.columnDate04 + ", " +
                         "?" + ReceiptFooter.columnDate05 + ", " +
                         "?" + ReceiptFooter.columnDate06 + ", " +
                         "?" + ReceiptFooter.columnDate07 + ", " +
                         "?" + ReceiptFooter.columnDate08 + ", " +
                         "?" + ReceiptFooter.columnDate09 + ", " +
                         "?" + ReceiptFooter.columnDate10 + ", " +
                         "?" + ReceiptFooter.columnDate11 + ", " +
                         "?" + ReceiptFooter.columnDate12 + ", " +
                         "?" + ReceiptFooter.columnClassDay1 + ", " +
                         "?" + ReceiptFooter.columnClassTime1 + ", " +
                         "?" + ReceiptFooter.columnTeacher1 + ", " +
                         "?" + ReceiptFooter.columnClassDay2 + ", " +
                         "?" + ReceiptFooter.columnClassTime2 + ", " +
                         "?" + ReceiptFooter.columnTeacher2 + ")";
            /*
            string sql = "INSERT INTO " +
                         "PaymentFooter(courseName, courseLevel, date01, date02, date03, date04, date05, date06, date07, date08, date09, date10, date11, date12, classDay1, classTime1, teacher1, classDay2, classTime2, teacher2, paymentID) " +
                         "VALUES(?courseName, ?courseLevel, ?date01, ?date02, ?date03, ?date04, ?date05, ?date06, ?date07, ?date08, ?date09, ?date10, ?date11, ?date12, ?classDay1, ?classTime1, ?teacher1, ?classDay2, ?classTime2, ?teacher2, ?paymentID)";
            */
            return this.paymentFooterDao.processInsertString(sql, paymentFooter, paymentID);
        }

        public bool addEmptyPaymentFooter(int paymentId)
        {
            string sql = "INSERT INTO " +
                         ReceiptFooter.tableName + " (" +
                         ReceiptFooter.columnPaymentId + ") " +
                         "VALUES(" +
                         "?" + ReceiptFooter.columnPaymentId + ")";
            /*
            string sql = "INSERT INTO " +
                         "PaymentFooter(paymentID) " +
                         "VALUES(@paymentID)";
            */
            return this.paymentFooterDao.processInsertString(sql, paymentId);
        }

        public bool deletePaymentFooter(int paymentId)
        {
            string sql = "DELETE " +
                         "FROM " + ReceiptFooter.tableName + " " +
                         "WHERE " + ReceiptFooter.columnPaymentId + " = " + paymentId;
            /*
            string sql = "DELETE FROM PaymentFooter " +
                         "WHERE paymentID = " + paymentId;
            */
            return this.paymentFooterDao.processDeleteString(sql);
        }
    }
}
