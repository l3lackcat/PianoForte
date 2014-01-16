using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface PaymentDetailDao
    {
        bool insertPaymentDetail(string databaseName, PaymentDetail paymentDetail);

        List<PaymentDetail> getPaymentDetailListByPaymentId(string databaseName, int paymentId);
    }
}
