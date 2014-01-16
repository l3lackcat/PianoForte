using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface HolidayDao
    {
        bool insertHoliday(string databaseName, Holiday holiday);

        bool updateHoliday(string databaseName, Holiday holiday);

        List<Holiday> getHolidayList(string databaseName, int holidayId);

        List<Holiday> getHolidayList(string databaseName);
    }
}
