using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    class HolidayManager
    {
        private static HolidayDao holidayDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getHolidayDao();

        public static bool insertHoliday(Holiday holiday)
        {
            return holidayDao.insertHoliday(holiday);
        }

        public static bool updateHoliday(Holiday schoolClosingDate)
        {
            //To Do
            return true;
        }

        public static bool deleteHoliday(int id)
        {
            return holidayDao.deleteHoliday(id);
        }

        public static Holiday findHoliday(int holidayId)
        {
            return holidayDao.findHoliday(holidayId);
        }

        public static Holiday findHoliday(DateTime date)
        {
            return holidayDao.findHoliday(date);
        }

        public static List<Holiday> findAllHoliday(int year)
        {
            return holidayDao.findAllHoliday(year);
        }

        public static List<Holiday> findAllHoliday(int year, int month)
        {
            return holidayDao.findAllHoliday(year, month);
        }

        public static bool isHoliday(DateTime date)
        {
            bool returnFlag = false;

            List<Holiday> holidayList = HolidayManager.findAllHoliday(date.Year);
            foreach (Holiday holiday in holidayList)
            {
                if (holiday.Date == date)
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }
    }
}
