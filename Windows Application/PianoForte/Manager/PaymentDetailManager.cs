using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class PaymentDetailManager
    {
        private static PaymentDetailDao paymentDetailDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getPaymentDetailDao();

        public static bool insertPaymentDetail(PaymentDetail paymentDetail)
        {
            return paymentDetailDao.insertPaymentDetail(paymentDetail);
        }

        public static bool updatePaymentDetail(PaymentDetail paymentDetail)
        {
            return paymentDetailDao.updatePaymentDetail(paymentDetail);
        }

        public static bool deletePaymentDetail(int paymentId)
        {
            return paymentDetailDao.deletePaymentDetail(paymentId);
        }

        public static List<PaymentDetail> findAllPaymentDetail(int paymentId)
        {
            return paymentDetailDao.findAllPaymentDetail(paymentId);
        }
    }
}
