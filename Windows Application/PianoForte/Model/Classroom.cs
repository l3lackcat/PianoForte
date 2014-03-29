using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Classroom
    {
        public static string tableName = "classroom";
        public static string columnClassroomId = "classroomId";
        public static string columnEnrollmentId = "enrollmentId";
        public static string columnTeacherId = "teacherId";
        public static string columnStartDate = "startDate";
        public static string columnClassDayOfWeek = "classDayOfWeek";
        public static string columnClassTime = "classTime";
        public static string columnClassDuration = "classDuration";
        public static string columnStatus = "status";

        public enum ClassroomStatus
        {
            ALL,
            ACTIVE,
            INACTIVE,            
            CANCELED
        };

        public enum ClassroomPerWeek
        {
            ONE,
            TWO,
            THREE,
            FOUR
        }

        private int id;
        private int enrollmentId;
        private int teacherId;
        private DateTime startDate;
        private string classDayOfWeek;
        private string classTime;
        private int classDuration;
        private string status;

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

        public int EnrollmentId
        {
            get
            {
                return this.enrollmentId;
            }

            set
            {
                this.enrollmentId = value;
            }
        }

        public int TeacherId
        {
            get
            {
                return this.teacherId;
            }

            set
            {
                this.teacherId = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }

            set
            {
                this.startDate = value;
            }
        }

        public string ClassDayOfWeek
        {
            get
            {
                return this.classDayOfWeek;
            }

            set
            {
                this.classDayOfWeek = value;
            }
        }

        public string ClassTime
        {
            get
            {
                return this.classTime;
            }

            set
            {
                this.classTime = value;
            }
        }

        public int ClassDuration
        {
            get
            {
                return this.classDuration;
            }

            set
            {
                this.classDuration = value;
            }
        }

        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }
    }
}
