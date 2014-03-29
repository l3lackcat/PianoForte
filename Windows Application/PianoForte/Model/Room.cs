using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Room
    {
        public static string tableName = "room";
        public static string columnRoomId = "roomId";
        public static string columnRoomNumber = "roomNumber";
        public static string columnDate = "date";

        private int id;
        private int number;
        private DateTime date;

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

        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
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
    }
}
