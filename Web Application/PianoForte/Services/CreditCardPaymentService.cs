using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class CreditCardPaymentService
    {
        private static CreditCardPaymentDao creditCardPaymentDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getCreditCardPaymentDao();

        public static bool insertCreditCardPayment(string databaseName, CreditCardPayment creditCardPayment)
        {
            return creditCardPaymentDao.insertCreditCardPayment(databaseName, creditCardPayment);
        }

        public static List<CreditCardPayment> getCreditCardPaymentListByPaymentId(string databaseName, int paymentId)
        {
            return creditCardPaymentDao.getCreditCardPaymentListByPaymentId(databaseName, paymentId);
        }
    }
}