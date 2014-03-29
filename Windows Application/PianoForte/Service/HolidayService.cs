using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    class HolidayService
    {
        private HolidayDao holidayDao = new HolidayDao();
        
        public bool addHoliday(Holiday holiday)
        {
            string sql = "INSERT INTO " +
                         Holiday.tableName + " (" +
                         Holiday.columnHolidayDate + ", " +
                         Holiday.columnAdderName + ") " +
                         "VALUES(" +
                         "?" + Holiday.columnHolidayDate + ", " +
                         "?" + Holiday.columnAdderName + ")";

            return this.holidayDao.processInsertString(sql, holiday);
        }

        public bool updateHoliday(Holiday holiday)
        {
            //To Do
            return true;
        }

        public bool deleteHoliday(int id)
        {
            string sql = "DELETE " +
                         "FROM " + Holiday.tableName + " " +
                         "WHERE " + Holiday.columnHolidayId + " = " + id;

            return this.holidayDao.processDeleteString(sql);
        }

        public Holiday getHoliday(int id)
        {
            Holiday holiday = null;

            string sql = "SELECT * " +
                         "FROM " + Holiday.tableName + " " +
                         "WHERE " + Holiday.columnHolidayId + " = " + id;

            List<Holiday> holidayList = this.holidayDao.processQueryString(sql);
            if (holidayList.Count > 0)
            {
                holiday = holidayList[0];
            }

            return holiday;
        }

        public Holiday getHoliday(DateTime date)
        {
            Holiday holiday = null;

            string sql = "SELECT * " +
                         "FROM " + Holiday.tableName + " " +
                         "WHERE " + Holiday.columnHolidayDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "'";

            List<Holiday> holidayList = this.holidayDao.processQueryString(sql);
            if (holidayList.Count > 0)
            {
                holiday = holidayList[0];
            }

            return holiday;
        }

        public List<Holiday> getAllHoliday(int month, int year)
        {
            string sql = "SELECT * " +
                         "FROM " + Holiday.tableName + " " +
                         "WHERE MONTH(" + Holiday.columnHolidayDate + ") = '" + month + "' " +
                         "AND YEAR(" + Holiday.columnHolidayDate + ") = '" + year + "' " +
                         "ORDER BY " + Holiday.columnHolidayDate + " ASC";

            return holidayDao.processQueryString(sql);
        }

        public List<Holiday> getAllHoliday(int year)
        {
            string sql = "SELECT * " +
                         "FROM " + Holiday.tableName + " " +
                         "WHERE YEAR(" + Holiday.columnHolidayDate + ") = '" + year + "' " +
                         "ORDER BY " + Holiday.columnHolidayDate + " ASC";

            return holidayDao.processQueryString(sql);
        }
    }
}
