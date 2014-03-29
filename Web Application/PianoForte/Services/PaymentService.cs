using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class PaymentService
    {
        private static PaymentDao paymentDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getPaymentDao();

        public static bool insertPayment(string databaseName, Payment payment)
        {
            return paymentDao.insertPayment(databaseName, payment);
        }

        public static bool updatePayment(string databaseName, Payment payment)
        {
            return paymentDao.updatePayment(databaseName, payment);
        }

        public static Payment getPayment(string databaseName, int paymentId)
        {
            Payment payment = null;

            List<Payment> tempPaymentList = paymentDao.getPaymentList(databaseName, paymentId);
            if (tempPaymentList.Count == 1)
            {
                payment = tempPaymentList[0];
            }

            return payment;
        }

        public static List<Payment> getPaymentList(string databaseName, int startIndex, int offset)
        {
            return paymentDao.getPaymentList(databaseName, startIndex, offset);
        }

        public static List<Payment> getPaymentList(string databaseName, int startIndex, int offset, Status status)
        {
            return paymentDao.getPaymentList(databaseName, startIndex, offset, status);
        }

        public static List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId)
        {
            return paymentDao.getPaymentList(databaseName, startIndex, offset, studentId);
        }

        public static List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId, Status status)
        {
            return paymentDao.getPaymentList(databaseName, startIndex, offset, studentId, status);
        }

        public static List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId, DateTime startDate, DateTime endDate)
        {
            return paymentDao.getPaymentList(databaseName, startIndex, offset, studentId, startDate, endDate);
        }

        public static List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId, DateTime startDate, DateTime endDate, Status status)
        {
            return paymentDao.getPaymentList(databaseName, startIndex, offset, studentId, startDate, endDate, status);
        }

        public static List<Payment> getPaymentList(string databaseName, int startIndex, int offset, DateTime startDate, DateTime endDate)
        {
            return paymentDao.getPaymentList(databaseName, startIndex, offset, startDate, endDate);
        }

        public static List<Payment> getPaymentList(string databaseName, int startIndex, int offset, DateTime startDate, DateTime endDate, Status status)
        {
            return paymentDao.getPaymentList(databaseName, startIndex, offset, startDate, endDate, status);
        }
    }
}