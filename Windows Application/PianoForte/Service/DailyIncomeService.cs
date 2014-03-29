using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class DailyIncomeService
    {
        private DailyIncomeDao dailyIncomeDao = new DailyIncomeDao();

        public bool addDailyIncome(DailyIncome dailyIncome)
        {
            string sql = "INSERT INTO " +
                         DailyIncome.tableName + " (" +
                         DailyIncome.columnDailyIncomeDate + ", " +
                         DailyIncome.columnTotalCoursePrice + ", " +
                         DailyIncome.columnTotalBookPrice + ", " +
                         DailyIncome.columnTotalAssignmentBookPrice + ", " +
                         DailyIncome.columnTotalFirstRegister + ", " +
                         DailyIncome.columnTotalCdPrice + ", " +
                         DailyIncome.columnTotalOtherPrice + ", " +
                         DailyIncome.columnTotalCash + ", " +
                         DailyIncome.columnTotalCreditcard + ") " +
                         "VALUES(" +
                         "?" + DailyIncome.columnDailyIncomeDate + ", " +
                         "?" + DailyIncome.columnTotalCoursePrice + ", " +
                         "?" + DailyIncome.columnTotalBookPrice + ", " +
                         "?" + DailyIncome.columnTotalAssignmentBookPrice + ", " +
                         "?" + DailyIncome.columnTotalFirstRegister + ", " +
                         "?" + DailyIncome.columnTotalCdPrice + ", " +
                         "?" + DailyIncome.columnTotalOtherPrice + ", " +
                         "?" + DailyIncome.columnTotalCash + ", " +
                         "?" + DailyIncome.columnTotalCreditcard + ")";
            /*
            string sql = "INSERT INTO " +
                         "DailyReceiptSummary(receiptDate, totalCoursePrice, totalBookPrice, totalAssignmentBookPrice, totalFirstRegister, totalCDPrice, totalOtherPrice, totalCash, totalCreditcard)" +
                         "VALUES(?receiptDate, ?totalCoursePrice, ?totalBookPrice, ?totalAssignmentBookPrice, ?totalFirstRegister, ?totalCDPrice, ?totalOtherPrice, ?totalCash, ?totalCreditcard)";
            */
            return this.dailyIncomeDao.processInsertString(sql, dailyIncome);
        }

        public bool updateDailyIncome(DailyIncome dailyIncome)
        {
            string sql = "UPDATE " +
                         DailyIncome.tableName + " SET " +
                         DailyIncome.columnTotalCoursePrice + " = ?" + DailyIncome.columnTotalCoursePrice + ", " +
                         DailyIncome.columnTotalBookPrice + " = ?" + DailyIncome.columnTotalBookPrice + ", " +
                         DailyIncome.columnTotalAssignmentBookPrice + " = ?" + DailyIncome.columnTotalAssignmentBookPrice + ", " +
                         DailyIncome.columnTotalFirstRegister + " = ?" + DailyIncome.columnTotalFirstRegister + ", " +
                         DailyIncome.columnTotalCdPrice + " = ?" + DailyIncome.columnTotalCdPrice + ", " +
                         DailyIncome.columnTotalOtherPrice + " = ?" + DailyIncome.columnTotalOtherPrice + ", " +
                         DailyIncome.columnTotalCash + " = ?" + DailyIncome.columnTotalCash + ", " +
                         DailyIncome.columnTotalCreditcard + " = ?" + DailyIncome.columnTotalCreditcard + " " +
                         "WHERE " + DailyIncome.columnDailyIncomeDate + " = ?" + DailyIncome.columnDailyIncomeDate;
            /*
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
            */
            return this.dailyIncomeDao.processUpdateString(sql, dailyIncome);
        }

        public bool deleteDailyIncome(int id)
        {
            string sql = "DELETE " +
                         "FROM " + DailyIncome.tableName + " " +
                         "WHERE " + DailyIncome.columnDailyIncomeId + " = " + id;
            /*
            string sql = "DELETE FROM DailyReceiptSummary " +
                         "WHERE id = " + id;
            */
            return this.dailyIncomeDao.processDeleteString(sql);
        }

        public bool deleteDailyIncome(DateTime date)
        {
            string sql = "DELETE " +
                         "FROM " + DailyIncome.tableName + " " +
                         "WHERE " + DailyIncome.columnDailyIncomeDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "'";
            /*
            string sql = "DELETE FROM DailyReceiptSummary " +
                         "WHERE receiptDate = DateValue('" + date + "')";
            */
            return this.dailyIncomeDao.processDeleteString(sql);
        }

        public DailyIncome getDailyIncome(DateTime date)
        {
            DailyIncome dailyIncome = null;

            string sql = "SELECT * " +
                         "FROM " + DailyIncome.tableName + " " +
                         "WHERE " + DailyIncome.columnDailyIncomeDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "'";
            /*
            string sql = "SELECT * " +
                         "FROM DailyReceiptSummary " +
                         "WHERE receiptDate = DateValue('" + date + "')";
            */
            List<DailyIncome> dailyIncomeList = this.dailyIncomeDao.processQueryString(sql);
            if (dailyIncomeList.Count > 0)
            {
                dailyIncome = dailyIncomeList[0];
            }

            return dailyIncome;
        }

        public List<DailyIncome> getAllDailyIncome(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + DailyIncome.tableName + " " +
                         "WHERE " + DailyIncome.columnDailyIncomeDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + DailyIncome.columnDailyIncomeDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + DailyIncome.columnDailyIncomeDate + " ASC";
            /*
            string sql = "SELECT * " +
                         "FROM DailyReceiptSummary " +
                         "WHERE receiptDate BETWEEN DateValue('" + startDate + "') AND DateValue('" + endDate + "') " +
                         "ORDER BY id ASC";
            */
            return this.dailyIncomeDao.processQueryString(sql);
        }
    }
}
