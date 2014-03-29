using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class PaymentDetailService
    {
        private PaymentDetailDao paymentDetailDao = new PaymentDetailDao();

        public bool addPaymentDetail(PaymentDetail paymentDetail)
        {
            string sql = "INSERT INTO " +
                         PaymentDetail.tableName + " (" +
                         PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnProductId + ", " +
                         PaymentDetail.columnProductType + ", " +
                         PaymentDetail.columnProductName + ", " +
                         PaymentDetail.columnAmount + ", " +
                         PaymentDetail.columnDiscount + ", " +
                         PaymentDetail.columnProductPrice + ") " +
                         "VALUES(" +
                         "?" + PaymentDetail.columnPaymentId + ", " +
                         "?" + PaymentDetail.columnProductId + ", " +
                         "?" + PaymentDetail.columnProductType + ", " +
                         "?" + PaymentDetail.columnProductName + ", " +
                         "?" + PaymentDetail.columnAmount + ", " +
                         "?" + PaymentDetail.columnDiscount + ", " +
                         "?" + PaymentDetail.columnProductPrice + ")";

            return this.paymentDetailDao.processInsertString(sql, paymentDetail);
        }

        public bool updatePaymentDetail(PaymentDetail paymentDetail)
        {
            string sql = "UPDATE " +
                         PaymentDetail.tableName + " SET " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + " " +
                         "WHERE " + PaymentDetail.columnPaymentDetailId + " = ?" + PaymentDetail.columnPaymentDetailId;

            return this.paymentDetailDao.processUpdateString(sql, paymentDetail);
        }

        public bool deletePaymentDetail(int paymentId)
        {
            string sql = "DELETE " +
                         "FROM " + PaymentDetail.tableName + " " +
                         "WHERE " + PaymentDetail.columnPaymentId + " = " + paymentId;

            return this.paymentDetailDao.processDeleteString(sql);
        }

        public List<PaymentDetail> getPaymentDetail(int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + PaymentDetail.tableName + " " +
                         "WHERE " + PaymentDetail.columnPaymentId + " = " + paymentId;

            return this.paymentDetailDao.processQueryString(sql);
        }
    }
}
