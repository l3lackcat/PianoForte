using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class HolidayService
    {
        private static HolidayDao holidayDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getHolidayDao();

        public static bool insertHoliday(string databaseName, Holiday holiday)
        {
            return holidayDao.insertHoliday(databaseName, holiday);
        }

        public static bool updateHoliday(string databaseName, Holiday holiday)
        {
            return holidayDao.updateHoliday(databaseName, holiday);
        }

        public static Holiday getHolidayt(string databaseName, int holidayId)
        {
            Holiday holiday = null;

            List<Holiday> tempHolidayList = holidayDao.getHolidayList(databaseName, holidayId);
            if (tempHolidayList.Count == 1)
            {
                holiday = tempHolidayList[0];
            }

            return holiday;
        }

        public static List<Holiday> getHolidayList(string databaseName)
        {
            return holidayDao.getHolidayList(databaseName);
        }
    }
}