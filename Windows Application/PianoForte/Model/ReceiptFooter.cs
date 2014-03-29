using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class ReceiptFooter
    {
        public static string tableName = "receipt_footer";
        public static string columnPaymentId = "paymentId";
        public static string columnCourseName = "courseName";
        public static string columnCourseLevel = "courseLevel";
        public static string columnClassDay1 = "classDayOfWeek1";
        public static string columnClassTime1 = "classTime1";
        public static string columnTeacher1 = "teacherName1";
        public static string columnClassDay2 = "classDayOfWeek2";
        public static string columnClassTime2 = "classTime2";
        public static string columnTeacher2 = "teacherName2";
        public static string columnDate01 = "date01";
        public static string columnDate02 = "date02";
        public static string columnDate03 = "date03";
        public static string columnDate04 = "date04";
        public static string columnDate05 = "date05";
        public static string columnDate06 = "date06";
        public static string columnDate07 = "date07";
        public static string columnDate08 = "date08";
        public static string columnDate09 = "date09";
        public static string columnDate10 = "date10";
        public static string columnDate11 = "date11";
        public static string columnDate12 = "date12";

        private int paymentId;
        private string classDayOfWeek1;
        private string classTime1;
        private string teacherName1;
        private string classDayOfWeek2;
        private string classTime2;
        private string teacherName2;     
        private string courseName;
        private string courseLevel;
        private List<DateTime> classroomDateList;
        private DateTime date01;
        private DateTime date02;
        private DateTime date03;
        private DateTime date04;
        private DateTime date05;
        private DateTime date06;
        private DateTime date07;
        private DateTime date08;
        private DateTime date09;
        private DateTime date10;
        private DateTime date11;
        private DateTime date12;

        public ReceiptFooter()
        {
            this.classroomDateList = new List<DateTime>();
        }

        public int PaymentId
        {
            get
            {
                return this.paymentId;
            }

            set
            {
                this.paymentId = value;
            }
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            set
            {
                this.courseName = value;
            }
        }

        public string CourseLevel
        {
            get
            {
                return this.courseLevel;
            }
            
            set
            {
                this.courseLevel = value;
            }
        }

        public string ClassDayOfWeek1
        {
            get
            {
                return this.classDayOfWeek1;
            }

            set
            {
                this.classDayOfWeek1 = value;
            }
        }

        public string ClassTime1
        {
            get
            {
                return this.classTime1;
            }

            set
            {
                this.classTime1 = value;
            }
        }

        public string TeacherName1
        {
            get
            {
                return this.teacherName1;
            }

            set
            {
                this.teacherName1 = value;
            }
        }

        public string ClassDayOfWeek2
        {
            get
            {
                return this.classDayOfWeek2;
            }

            set
            {
                this.classDayOfWeek2 = value;
            }
        }

        public string ClassTime2
        {
            get
            {
                return this.classTime2;
            }

            set
            {
                this.classTime2 = value;
            }
        }

        public string TeacherName2
        {
            get
            {
                return this.teacherName2;
            }

            set
            {
                this.teacherName2 = value;
            }

        }
        public DateTime Date01
        {
            get
            {
                return this.date01;
            }

            set
            {
                this.date01 = value;
            }
        }

        public DateTime Date02
        {
            get
            {
                return this.date02;
            }

            set
            {
                this.date02 = value;
            }
        }

        public DateTime Date03
        {
            get
            {
                return this.date03;
            }

            set
            {
                this.date03 = value;
            }
        }

        public DateTime Date04
        {
            get
            {
                return this.date04;
            }

            set
            {
                this.date04 = value;
            }
        }

        public DateTime Date05
        {
            get
            {
                return this.date05;
            }

            set
            {
                this.date05 = value;
            }
        }

        public DateTime Date06
        {
            get
            {
                return this.date06;
            }

            set
            {
                this.date06 = value;
            }
        }

        public DateTime Date07
        {
            get
            {
                return this.date07;
            }

            set
            {
                this.date07 = value;
            }
        }

        public DateTime Date08
        {
            get
            {
                return this.date08;
            }

            set
            {
                this.date08 = value;
            }
        }

        public DateTime Date09
        {
            get
            {
                return this.date09;
            }

            set
            {
                this.date09 = value;
            }
        }

        public DateTime Date10
        {
            get
            {
                return this.date10;
            }

            set
            {
                this.date10 = value;
            }
        }

        public DateTime Date11
        {
            get
            {
                return this.date11;
            }

            set
            {
                this.date11 = value;
            }
        }

        public DateTime Date12
        {
            get
            {
                return this.date12;
            }

            set
            {
                this.date12 = value;
            }
        }

        public List<DateTime> ClassroomDateList
        {
            get
            {
                return this.classroomDateList;
            }

            set
            {
                this.classroomDateList = value;
            }
        }
    }
}
