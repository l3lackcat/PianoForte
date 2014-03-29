using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class CourseCategory
    {
        public static string tableName = "course_category";
        public static string columnCourseCategoryId = "courseCategoryId";
        public static string columnCourseCategoryName = "courseCategoryName";
        public static string columnStatus = "status";

        public enum CourseCategoryStatus
        {
            ALL,
            ACTIVE,
            INACTIVE            
        };

        private int id;
        private string name;
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

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
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
