using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class DailyReceiptSummaryService
    {
        private DailyReceiptSummaryDao dailyReceiptSummaryDao = new DailyReceiptSummaryDao();

        public bool addDailyReceiptSummary(DailyReceiptSummary dailyReceiptSummary)
        {
            string sql = "INSERT INTO " +
                         "DailyReceiptSummary(receiptDate, totalCoursePrice, totalBookPrice, totalAssignmentBookPrice, totalFirstRegister, totalCDPrice, totalOtherPrice, totalCash, totalCreditcard)" +
                         "VALUES(?receiptDate, ?totalCoursePrice, ?totalBookPrice, ?totalAssignmentBookPrice, ?totalFirstRegister, ?totalCDPrice, ?totalOtherPrice, ?totalCash, ?totalCreditcard)";

            return this.dailyReceiptSummaryDao.processInsertString(sql, dailyReceiptSummary);
        }

        public bool updateDailyReceiptSummary(DailyReceiptSummary dailyReceiptSummary)
        {
            string sql = "UPDATE DailyReceiptSummary SET " +
                         "totalCoursePrice = ?totalCoursePrice, " +
                         "totalBookPrice = ?totalBookPrice, " +
                         "totalAssignmentBookPrice = ?totalAssignmentBookPrice, " +
                         "totalFirstRegister = ?totalFirstRegister, " +
                         "totalCDPrice = ?totalCDPrice, " +
                         "totalOtherPrice = ?totalOtherPrice, " +
                         "totalCash = ?totalCash, " +
                         "totalCreditcard = ?totalCreditcard " +
                         "WHERE receiptDate = ?receiptDate";

            return this.dailyReceiptSummaryDao.processUpdateString(sql, dailyReceiptSummary);
        }

        public bool deleteDailyReceiptSummary(int id)
        {
            string sql = "DELETE FROM DailyReceiptSummary " +
                         "WHERE id = " + id;

            return this.dailyReceiptSummaryDao.processDeleteString(sql);
        }

        public bool deleteDailyReceiptSummary(DateTime date)
        {
            string sql = "DELETE FROM DailyReceiptSummary " +
                         "WHERE receiptDate = DateValue('" + date + "')";

            return this.dailyReceiptSummaryDao.processDeleteString(sql);
        }

        public DailyReceiptSummary getDailyReceiptSummary(DateTime date)
        {
            DailyReceiptSummary dailyReceiptSummary = null;

            string sql = "SELECT * " +
                         "FROM DailyReceiptSummary " +
                         "WHERE receiptDate = DateValue('" + date + "')";

            List<DailyReceiptSummary> dailyReceiptSummaryList = this.dailyReceiptSummaryDao.processQueryString(sql);
            if (dailyReceiptSummaryList.Count > 0)
            {
                dailyReceiptSummary = dailyReceiptSummaryList[0];
            }

            return dailyReceiptSummary;
        }

        public List<DailyReceiptSummary> getAllDailyReceiptSummary(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM DailyReceiptSummary " +
                         "WHERE receiptDate BETWEEN DateValue('" + startDate + "') AND DateValue('" + endDate + "') " +
                         "ORDER BY id ASC";

            return this.dailyReceiptSummaryDao.processQueryString(sql);
        }
    }
}
