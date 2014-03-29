using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface HolidayDao
    {
        bool insertHoliday(Holiday holiday);
        bool updateHoliday(Holiday holiday);
        bool deleteHoliday(int holidayId);

        Holiday findHoliday(int holidayId);

        Holiday findHoliday(DateTime date);

        List<Holiday> findAllHoliday();
        List<Holiday> findAllHoliday(int year);
        List<Holiday> findAllHoliday(int year, int month);
    }
}
