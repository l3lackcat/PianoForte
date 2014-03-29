using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class DailyIncome
    {
        public static string tableName = "daily_income";
        public static string columnDailyIncomeId = "dailyIncomeId";
        public static string columnDailyIncomeDate = "dailyIncomeDate";
        public static string columnTotalCoursePrice = "totalCoursePrice";
        public static string columnTotalBookPrice = "totalBookPrice";
        public static string columnTotalAssignmentBookPrice = "totalAssignmentBookPrice";
        public static string columnTotalFirstRegister = "totalFirstRegister";
        public static string columnTotalCdPrice = "totalCdPrice";
        public static string columnTotalOtherPrice = "totalOtherPrice";
        public static string columnTotalCash = "totalCash";
        public static string columnTotalCreditcard = "totalCreditcard";

        private int id;
        private DateTime date;
        private double totalCoursePrice;
        private double totalBookPrice;
        private double totalAssignmentBookPrice;
        private double totalFirstRegister;
        private double totalCdPrice;
        private double totalOtherPrice;
        private double totalCash;
        private double totalCreditcard;

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

        public double TotalCoursePrice
        {
            get
            {
                return this.totalCoursePrice;
            }

            set
            {
                this.totalCoursePrice = value;
            }
        }

        public double TotalBookPrice
        {
            get
            {
                return this.totalBookPrice;
            }

            set
            {
                this.totalBookPrice = value;
            }
        }

        public double TotalAssignmentBookPrice
        {
            get
            {
                return this.totalAssignmentBookPrice;
            }

            set
            {
                this.totalAssignmentBookPrice = value;
            }
        }

        public double TotalFirstRegister
        {
            get
            {
                return this.totalFirstRegister;
            }

            set
            {
                this.totalFirstRegister = value;
            }
        }

        public double TotalCdPrice
        {
            get
            {
                return this.totalCdPrice;
            }

            set
            {
                this.totalCdPrice = value;
            }
        }

        public double TotalOtherPrice
        {
            get
            {
                return this.totalOtherPrice;
            }

            set
            {
                this.totalOtherPrice = value;
            }
        }

        public double TotalCash
        {
            get
            {
                return this.totalCash;
            }

            set
            {
                this.totalCash = value;
            }
        }

        public double TotalCreditcard
        {
            get
            {
                return this.totalCreditcard;
            }

            set
            {
                this.totalCreditcard = value;
            }
        }
    }
}
