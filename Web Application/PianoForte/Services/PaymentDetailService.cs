using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class PaymentDetailService
    {
        private static PaymentDetailDao paymentDetailDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getPaymentDetailDao();

        public static bool insertPaymentDetail(string databaseName, PaymentDetail paymentDetail)
        {
            return paymentDetailDao.insertPaymentDetail(databaseName, paymentDetail);
        }

        public static List<PaymentDetail> getPaymentDetailListByPaymentId(string databaseName, int paymentId)
        {
            return paymentDetailDao.getPaymentDetailListByPaymentId(databaseName, paymentId);
        }
    }
}