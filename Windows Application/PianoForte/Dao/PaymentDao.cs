using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface PaymentDao
    {
        bool insertPayment(Payment payment);
        bool updatePayment(Payment payment);
        bool deletePayment(int paymentId);

        Payment findPayment(int paymentId);
        Payment findLastPayment();        
        Payment findLastPrintedPayment(DateTime date);

        List<Payment> findAllPayment();
        List<Payment> findAllPayment(int startIndex, int offset);
        List<Payment> findAllPayment(Payment.PaymentStatus status);
        List<Payment> findAllPayment(Payment.PaymentStatus status, int startIndex, int offset);

        List<Payment> findAllPaymentByStudentId(int studentId);
        List<Payment> findAllPaymentByStudentId(int studentId, int startIndex, int offset);
        List<Payment> findAllPaymentByStudentId(int studentId, Payment.PaymentStatus status);
        List<Payment> findAllPaymentByStudentId(int studentId, Payment.PaymentStatus status, int startIndex, int offset);

        List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber);
        List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber, int startIndex, int offset);
        List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber, Payment.PaymentStatus status);
        List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber, Payment.PaymentStatus status, int startIndex, int offset);

        List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate);
        List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate, int startIndex, int offset);
        List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate, Payment.PaymentStatus status);
        List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset);

        List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber);
        List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, int startIndex, int offset);
        List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, Payment.PaymentStatus status);
        List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, Payment.PaymentStatus status, int startIndex, int offset);

        List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate);
        List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, int startIndex, int offset);
        List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, Payment.PaymentStatus status);
        List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset);

        List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate);
        List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, int startIndex, int offset);
        List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status);
        List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset);

        List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate);
        List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, int startIndex, int offset);
        List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status);
        List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset);        
    }
}
