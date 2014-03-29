using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface BookOrderDetailDao
    {
        //bool processInsertCommand(string sql, Book book);
        //bool processUpdateCommand(string sql, Book book);
        //bool processDeleteCommand(string sql);
        //List<BookOrderDetail> processSelectCommand(string sql);

        bool insertBookOrderDetail(BookOrderDetail bookOrderDetail);
        bool updateBookOrderDetail(BookOrderDetail bookOrderDetail);
        bool deleteBookOrderDetail(int bookOrderDetailId);

        BookOrderDetail findLastBookOrderDetail();

        BookOrderDetail findBookOrderDetail(int bookOrderDetailId);

        List<BookOrderDetail> findAllBookOrderDetail();

        List<BookOrderDetail> findAllBookOrderDetailByPaymentId(int paymentId);

        List<BookOrderDetail> findAllBookOrderDetailByStudentId(int studentId);

        List<BookOrderDetail> findAllBookOrderDetailByDate(DateTime startDate, DateTime endDate);
    }
}
