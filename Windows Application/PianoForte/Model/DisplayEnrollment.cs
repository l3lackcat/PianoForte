using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class DisplayEnrollment
    {
        private int enrollmentId;
        private string courseName;
        private DateTime enrolledDate;
        private string status;

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

        public DateTime EnrolledDate
        {
            get
            {
                return this.enrolledDate;
            }

            set
            {
                this.enrolledDate = value;
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
