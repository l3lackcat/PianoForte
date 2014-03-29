using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class DailyIncomeManager
    {
        private static DailyIncomeService dailyIncomeService = new DailyIncomeService();

        public static bool addDailyIncome(DailyIncome dailyReceiptSummary)
        {
            return dailyIncomeService.addDailyIncome(dailyReceiptSummary);
        }

        public static bool updateDailyIncome(DailyIncome dailyReceiptSummary)
        {
            return dailyIncomeService.updateDailyIncome(dailyReceiptSummary);
        }

        public static bool deleteDailyIncome(DateTime date)
        {
            return dailyIncomeService.deleteDailyIncome(date);
        }

        public static DailyIncome getDailyIncome(DateTime date)
        {
            return dailyIncomeService.getDailyIncome(date);
        }

        public static List<DailyIncome> getAllDailyIncome(DateTime startDate, DateTime endTime)
        {
            return dailyIncomeService.getAllDailyIncome(startDate, endTime);
        }
    }
}
