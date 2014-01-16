using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface PaymentDao
    {
        bool insertPayment(string databaseName, Payment payment);

        bool updatePayment(string databaseName, Payment payment);

        List<Payment> getPaymentList(string databaseName, int paymentId);

        List<Payment> getPaymentList(string databaseName, int startIndex, int offset);

        List<Payment> getPaymentList(string databaseName, int startIndex, int offset, Status status);

        List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId);

        List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId, Status status);

        List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId, DateTime startDate, DateTime endDate);

        List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId, DateTime startDate, DateTime endDate, Status status);

        List<Payment> getPaymentList(string databaseName, int startIndex, int offset, DateTime startDate, DateTime endDate);

        List<Payment> getPaymentList(string databaseName, int startIndex, int offset, DateTime startDate, DateTime endDate, Status status);
    }
}
