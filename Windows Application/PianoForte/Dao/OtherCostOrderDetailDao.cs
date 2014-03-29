using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface OtherCostOrderDetailDao
    {
        //bool processInsertCommand(string sql, OtherCostOrderDetail otherCostOrderDetail);
        //bool processUpdateCommand(string sql, OtherCostOrderDetail otherCostOrderDetail);
        //bool processDeleteCommand(string sql);
        //List<OtherCostOrderDetail> processSelectCommand(string sql);

        bool insertOtherCostOrderDetail(OtherCostOrderDetail otherCostOrderDetail);
        bool updateOtherCostOrderDetail(OtherCostOrderDetail otherCostOrderDetail);
        bool deleteOtherCostOrderDetail(int otherCostOrderDetailId);

        OtherCostOrderDetail findLastOtherCostOrderDetail();

        OtherCostOrderDetail findOtherCostOrderDetail(int otherCostOrderDetailId);

        List<OtherCostOrderDetail> findAllOtherCost();

        List<OtherCostOrderDetail> findAllOtherCostByPaymentId(int paymentId);
    }
}
