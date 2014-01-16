using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class CashPaymentService
    {
        private static CashPaymentDao cashPaymentDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getCashPaymentDao();

        public static bool insertCashPayment(string databaseName, CashPayment cashPayment)
        {
            return cashPaymentDao.insertCashPayment(databaseName, cashPayment);
        }

        public static List<CashPayment> getCashPaymentListByPaymentId(string databaseName, int paymentId)
        {
            return cashPaymentDao.getCashPaymentListByPaymentId(databaseName, paymentId);
        }
    }
}