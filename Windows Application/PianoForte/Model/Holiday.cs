using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Holiday
    {
        public static string tableName = "holidays";
        public static string columnHolidayId = "holiday_id";
        public static string columnHolidayDate = "holiday_date";
        public static string columnComment = "holiday_comment";

        private int id;
        private DateTime date;
        private string comment;

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }

            set
            {
                this.comment = value;
            }
        }
    }
}
