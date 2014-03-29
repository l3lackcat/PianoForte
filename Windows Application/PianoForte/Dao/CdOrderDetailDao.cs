using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface CdOrderDetailDao
    {
        //bool processInsertCommand(string sql, CdOrderDetail cdOrderDetail);
        //bool processUpdateCommand(string sql, CdOrderDetail cdOrderDetail);
        //bool processDeleteCommand(string sql);
        //List<CdOrderDetail> processSelectCommand(string sql);

        bool insertCdOrderDetail(CdOrderDetail cdOrderDetail);
        bool updateCdOrderDetail(CdOrderDetail cdOrderDetail);
        bool deleteCdOrderDetail(int cdOrderDetailId);

        CdOrderDetail findLastCdOrderDetail();

        CdOrderDetail findCdOrderDetail(int cdOrderDetailId);

        List<CdOrderDetail> findAllCdOrderDetail();

        List<CdOrderDetail> findAllCdOrderDetailByPaymentId(int paymentId);

        List<CdOrderDetail> findAllCdOrderDetailByStudentId(int studentId);

        List<CdOrderDetail> findAllCdOrderDetailByDate(DateTime startDate, DateTime endDate);
    }
}
