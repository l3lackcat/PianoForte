using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface CreditCardPaymentDao
    {
        bool insertCreditCardPayment(string databaseName, CreditCardPayment creditCardPayment);

        List<CreditCardPayment> getCreditCardPaymentListByPaymentId(string databaseName, int paymentId);
    }
}
