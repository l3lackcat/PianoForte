using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface PaymentDetailDao
    {
        bool insertPaymentDetail(PaymentDetail paymentDetail);
        bool updatePaymentDetail(PaymentDetail paymentDetail);
        bool deletePaymentDetail(int paymentId);

        PaymentDetail findLastPaymentDetail();

        List<PaymentDetail> findAllPaymentDetail(int paymentId);
    }
}
