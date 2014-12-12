using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;
using System.Globalization;

namespace PianoForte.Manager
{
    public class PaymentManager
    {
        private static PaymentDao paymentDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getPaymentDao();

        //--------------------------------------------------------------------------------

        public static Payment insertPayment(Payment payment)
        {
            bool isInsertComplete = paymentDao.insertPayment(payment);
            if (isInsertComplete)
            {
                payment.Id = paymentDao.findLastPayment().Id;
            }
            else
            {
                payment = null;
            }

            return payment;
        }

        public static bool updatePayment(Payment payment)
        {
            return paymentDao.updatePayment(payment);
        }

        public static bool deletePayment(int paymentId)
        {
            return paymentDao.deletePayment(paymentId);
        }

        //--------------------------------------------------------------------------------

        public static Payment findPayment(int paymentId)
        {
            return paymentDao.findPayment(paymentId);
        }

        public static Payment findLastPayment()
        {
            return paymentDao.findLastPayment();
        }

        public static int generateNextPrintedPaymentId(DateTime date)
        {
            int nextPrintPaymentId = 0;
            int currentPrintPaymentId = PaymentManager.findLastPrintedPayment(date).PrintPaymentId;

            if (currentPrintPaymentId == 0)
            {
                if (date.Year == 2011)
                {
                    currentPrintPaymentId = 389;
                }

                CultureInfo cultureInfo = new CultureInfo("th-TH");
                String sDate = date.ToString("yy", cultureInfo);

                nextPrintPaymentId = Convert.ToInt32(sDate) * 100000;   // First 2 digits
                nextPrintPaymentId += 10000;                            // Third digit
                nextPrintPaymentId += ++currentPrintPaymentId;          // Last 4 digits
            }
            else
            {
                nextPrintPaymentId = currentPrintPaymentId + 1;
            }            

            return nextPrintPaymentId;
        }

        public static Payment findLastPrintedPayment(DateTime date)
        {
            return paymentDao.findLastPrintedPayment(date);
        }

        //--------------------------------------------------------------------------------

        public static List<Payment> findAllPayment()
        {
            return paymentDao.findAllPayment();
        }        

        public static List<Payment> findAllPayment(int startIndex, int offset)
        {
            return paymentDao.findAllPayment(startIndex, offset);
        }

        public static List<Payment> findAllPayment(Payment.PaymentStatus status)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPayment();
            }
            else
            {
                paymentList = paymentDao.findAllPayment(status);
            }

            return paymentList;
        }

        public static List<Payment> findAllPayment(Payment.PaymentStatus status, int startIndex, int offset)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPayment(startIndex, offset);
            }
            else
            {
                paymentList = paymentDao.findAllPayment(status, startIndex, offset);
            }

            return paymentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Payment> findAllPaymentByStudentId(int studentId)
        {
            return paymentDao.findAllPaymentByStudentId(studentId);
        }

        public static List<Payment> findAllPaymentByStudentId(int studentId, int startIndex, int offset)
        {
            return paymentDao.findAllPaymentByStudentId(studentId, startIndex, offset);
        }

        public static List<Payment> findAllPaymentByStudentId(int studentId, Payment.PaymentStatus status)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByStudentId(studentId);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByStudentId(studentId, status);
            }

            return paymentList;
        }

        public static List<Payment> findAllPaymentByStudentId(int studentId, Payment.PaymentStatus status, int startIndex, int offset)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByStudentId(studentId, startIndex, offset);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByStudentId(studentId, status, startIndex, offset);
            }

            return paymentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber)
        {
            return paymentDao.findAllPaymentByCreditCardNumber(creditCardNumber);
        }

        public static List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber, int startIndex, int offset)
        {
            return paymentDao.findAllPaymentByCreditCardNumber(creditCardNumber, startIndex, offset);
        }

        public static List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber, Payment.PaymentStatus status)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByCreditCardNumber(creditCardNumber);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByCreditCardNumber(creditCardNumber, status);
            }

            return paymentList;
        }

        public static List<Payment> findAllPaymentByCreditCardNumber(string creditCardNumber, Payment.PaymentStatus status, int startIndex, int offset)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByCreditCardNumber(creditCardNumber, startIndex, offset);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByCreditCardNumber(creditCardNumber, status, startIndex, offset);
            }

            return paymentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate)
        {
            return paymentDao.findAllPaymentByDate(startDate, endDate);
        }

        public static List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            return paymentDao.findAllPaymentByDate(startDate, endDate, startIndex, offset);
        }

        public static List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate, Payment.PaymentStatus status)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByDate(startDate, endDate);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByDate(startDate, endDate, status);
            }

            return paymentList;
        }

        public static List<Payment> findAllPaymentByDate(DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByDate(startDate, endDate, startIndex, offset);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByDate(startDate, endDate, status, startIndex, offset);
            }

            return paymentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber)
        {
            return paymentDao.findAllPaymentByStudentIdAndCreditCardNumber(studentId, creditCardNumber);
        }

        public static List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, int startIndex, int offset)
        {
            return paymentDao.findAllPaymentByStudentIdAndCreditCardNumber(studentId, creditCardNumber, startIndex, offset);
        }

        public static List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, Payment.PaymentStatus status)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndCreditCardNumber(studentId, creditCardNumber);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndCreditCardNumber(studentId, creditCardNumber, status);
            }

            return paymentList;
        }

        public static List<Payment> findAllPaymentByStudentIdAndCreditCardNumber(int studentId, string creditCardNumber, Payment.PaymentStatus status, int startIndex, int offset)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndCreditCardNumber(studentId, creditCardNumber, startIndex, offset);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndCreditCardNumber(studentId, creditCardNumber, status, startIndex, offset);
            }

            return paymentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate)
        {
            return paymentDao.findAllPaymentByStudentIdAndDate(studentId, startDate, endDate);
        }

        public static List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            return paymentDao.findAllPaymentByStudentIdAndDate(studentId, startDate, endDate, startIndex, offset);
        }

        public static List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, Payment.PaymentStatus status)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndDate(studentId, startDate, endDate);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndDate(studentId, startDate, endDate, status);
            }

            return paymentList;
        }

        public static List<Payment> findAllPaymentByStudentIdAndDate(int studentId, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndDate(studentId, startDate, endDate, startIndex, offset);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndDate(studentId, startDate, endDate, status, startIndex, offset);
            }

            return paymentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate)
        {
            return paymentDao.findAllPaymentByCreditCardNumberAndDate(creditCardNumber, startDate, endDate);
        }

        public static List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            return paymentDao.findAllPaymentByCreditCardNumberAndDate(creditCardNumber, startDate, endDate, startIndex, offset);
        }

        public static List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByCreditCardNumberAndDate(creditCardNumber, startDate, endDate);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByCreditCardNumberAndDate(creditCardNumber, startDate, endDate, status);
            }

            return paymentList;
        }

        public static List<Payment> findAllPaymentByCreditCardNumberAndDate(string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByCreditCardNumberAndDate(creditCardNumber, startDate, endDate, startIndex, offset);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByCreditCardNumberAndDate(creditCardNumber, startDate, endDate, status, startIndex, offset);
            }

            return paymentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate)
        {
            return paymentDao.findAllPaymentByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate);
        }

        public static List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, int startIndex, int offset)
        {
            return paymentDao.findAllPaymentByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate, startIndex, offset);
        }

        public static List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate, status);
            }

            return paymentList;
        }

        public static List<Payment> findAllPaymentByStudentIdAndCreditCardNumberAndDate(int studentId, string creditCardNumber, DateTime startDate, DateTime endDate, Payment.PaymentStatus status, int startIndex, int offset)
        {
            List<Payment> paymentList;

            if (status == Payment.PaymentStatus.ALL)
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate, startIndex, offset);
            }
            else
            {
                paymentList = paymentDao.findAllPaymentByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate, status, startIndex, offset);
            }

            return paymentList;
        }

        //--------------------------------------------------------------------------------

        //public static List<Payment> findAllPayment(Payment.PaymentStatus status, DateTime startDate, DateTime endDate)
        //{
        //    return paymentDao.findAllPayment(-1, "", status, startDate, endDate);
        //}

        //public static List<Payment> findAllPayment(int studentId, string creditCardNumber, Payment.PaymentStatus status)
        //{
        //    return paymentDao.findAllPayment(studentId, creditCardNumber, status);
        //}

        //public static List<Payment> findAllPayment(int studentId, string creditCardNumber, Payment.PaymentStatus status, int startIndex, int offset)
        //{
        //    return paymentDao.findAllPayment(studentId, creditCardNumber, status, startIndex, offset);
        //}

        //public static List<Payment> findAllPayment(int studentId, string creditCardNumber, Payment.PaymentStatus status, DateTime startDate, DateTime endDate)
        //{
        //    return paymentDao.findAllPayment(studentId, creditCardNumber, status, startDate, endDate);
        //}

        //public static List<Payment> findAllPayment(int studentId, string creditCardNumber, Payment.PaymentStatus status, DateTime startDate, DateTime endDate, int startIndex, int offset)
        //{
        //    return paymentDao.findAllPayment(studentId, creditCardNumber, status, startDate, endDate, startIndex, offset);
        //}
        
        public static Payment processPayment(int studentId, int receiverId, string creditCardNumber, double totalPrice, Payment.PaymentStatus paymentStatus)
        {
            Payment payment = new Payment();
            payment.StudentId = studentId;
            payment.ReceiverId = receiverId;
            payment.CreditCardNumber = ConvertManager.toDisplayCreditCardNumber(creditCardNumber);
            payment.TotalPrice = totalPrice;
            payment.TotalPriceText = ConvertManager.toBahtText(totalPrice);
            payment.PaymentDate = DateTime.Today;
            payment.Status = paymentStatus.ToString();

            return PaymentManager.insertPayment(payment);
        }

        public static Dictionary<DateTime, DailyIncome> generateDailyIncome(List<Payment> paymentList)
        {
            Dictionary<DateTime, DailyIncome> dailyIncomeDictionary = new Dictionary<DateTime, DailyIncome>();

            for (int i = 0; i < paymentList.Count; i++)
            {
                Payment payment = paymentList[i];
                if (payment != null)
                {
                    if (!dailyIncomeDictionary.ContainsKey(payment.PaymentDate))
                    {
                        dailyIncomeDictionary.Add(payment.PaymentDate, new DailyIncome());
                    }

                    if (payment.CreditCardNumber == "")
                    {
                        dailyIncomeDictionary[payment.PaymentDate].TotalCash += payment.TotalPrice;
                    }
                    else
                    {
                        dailyIncomeDictionary[payment.PaymentDate].TotalCreditcard += payment.TotalPrice;
                    }

                    List<PaymentDetail> paymentDetailList = PaymentDetailManager.findAllPaymentDetail(payment.Id);
                    for (int j = 0; j < paymentDetailList.Count; j++)
                    {
                        PaymentDetail paymentDetail = paymentDetailList[j];
                        if (paymentDetail != null)
                        {
                            double productPrice = (paymentDetail.Product.Price * paymentDetail.Quantity) - paymentDetail.Discount;
                            if (paymentDetail.Product.Type == Product.ProductType.COURSE.ToString())
                            {
                                dailyIncomeDictionary[payment.PaymentDate].TotalCoursePrice += productPrice;
                            }
                            else if (paymentDetail.Product.Type == Product.ProductType.BOOK.ToString())
                            {
                                if (paymentDetail.Product.Id == 2000001)
                                {
                                    dailyIncomeDictionary[payment.PaymentDate].TotalAssignmentBookPrice += productPrice;
                                }
                                else
                                {
                                    dailyIncomeDictionary[payment.PaymentDate].TotalBookPrice += productPrice;
                                }
                            }
                            else if (paymentDetail.Product.Type == Product.ProductType.CD.ToString())
                            {
                                dailyIncomeDictionary[payment.PaymentDate].TotalCdPrice += productPrice;
                            }
                            else if (paymentDetail.Product.Type == Product.ProductType.OTHER.ToString())
                            {
                                if (paymentDetail.Product.Id == 4000001)
                                {
                                    dailyIncomeDictionary[payment.PaymentDate].TotalFirstRegister += productPrice;
                                }
                                else
                                {
                                    dailyIncomeDictionary[payment.PaymentDate].TotalOtherPrice += productPrice;
                                }
                            }
                        }
                    }
                }
            }

            return dailyIncomeDictionary;
        }

        //public static OtherCostOrderDetail addOtherCostOrderDetail(OtherCostOrderDetail otherCostOrderDetail)
        //{
        //    bool isAddSuccess = otherCostOrderDetailService.addOtherCostOrderDetail(otherCostOrderDetail);
        //    if (isAddSuccess)
        //    {
        //        otherCostOrderDetail.Id = otherCostOrderDetailService.getLastOtherCostOrderDetail().Id;
        //    }
        //    else
        //    {
        //        otherCostOrderDetail = null;
        //    }

        //    return otherCostOrderDetail;
        //}
        
        //public static bool updateOtherCostOrderDetail(OtherCostOrderDetail otherCostOrderDetail)
        //{
        //    return otherCostOrderDetailService.updateOtherCostOrderDetail(otherCostOrderDetail);
        //}

        //public static bool deleteOtherCostOrderDetail(int otherCostOrderDetailId)
        //{
        //    return otherCostOrderDetailService.deleteOtherCostOrderDetail(otherCostOrderDetailId);
        //}

        //public static OtherCostOrderDetail getOtherCostOrderDetail(int otherCostOrderDetailId)
        //{
        //    return otherCostOrderDetailService.getOtherCostOrderDetail(otherCostOrderDetailId);
        //}

        //public static List<OtherCostOrderDetail> getAllOtherCostOrderDetail()
        //{
        //    return otherCostOrderDetailService.getAllOtherCostOrderDetail();
        //}

        //public static List<OtherCostOrderDetail> getAllOtherCostOrderDetailByPaymentId(int paymentId)
        //{
        //    return otherCostOrderDetailService.getAllOtherCostOrderDetailByPaymentId(paymentId);
        //}        
    }
}
