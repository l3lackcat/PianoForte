using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface CashPaymentDao
    {
        bool insertCashPayment(string databaseName, CashPayment cashPayment);

        List<CashPayment> getCashPaymentListByPaymentId(string databaseName, int paymentId);
    }
}
