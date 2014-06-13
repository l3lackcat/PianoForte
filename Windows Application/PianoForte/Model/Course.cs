using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Course : Product
    {
        public static string tableName = "course";
        public static string columnCourseId = "courseId";
        public static string columnCourseId_old = "courseId_old";
        public static string columnCourseCategoryId = "courseCategoryId";
        public static string columnCourseName = "courseName";
        public static string columnCourseLevel = "courseLevel";
        public static string columnNumberOfClassroom = "numberOfClassroom";
        public static string columnCourseFee = "courseFee";
        public static string columnClassroomDuration = "classroomDuration";
        public static string columnStudentPerClassroom = "studentPerClassroom";
        public static string columnStatus = "status";

        //Temporary
        public static string matchingTableName = "course_id_matching";
        public static string columnOldCourseId = "oldCourseId";
        public static string columnNewCourseId = "newCourseId";

        public enum CourseStatus
        {
            ALL,
            ACTIVE,
            INACTIVE
        };

        public int CourseId_old { get; set; }
        public int CourseCategoryId { get; set; }
        public string Level { get; set; }
        public int NumberOfClassroom { get; set; }
        public int ClassroomDuration { get; set; }
        public int StudentPerClassroom { get; set; }
        public string Status { get; set; }

        public Course()
        {
            //Do Nothing
        }

        public Course(Course course)
        {
            this.Id = course.Id;
            this.CourseId_old = course.CourseId_old;
            this.CourseCategoryId = course.CourseCategoryId;
            this.Name = course.Name;
            this.Level = course.Level;
            this.NumberOfClassroom = course.NumberOfClassroom;
            this.Price = course.Price;
            this.ClassroomDuration = course.ClassroomDuration;
            this.StudentPerClassroom = course.StudentPerClassroom;
            this.Status = course.Status;
        }

        //public int CourseId_old
        //{
        //    get
        //    {
        //        return this.courseId_old;
        //    }

        //    set
        //    {
        //        this.courseId_old = value;
        //    }
        //}

        //public int CourseCategoryId
        //{
        //    get
        //    {
        //        return this.courseCategoryId;
        //    }

        //    set
        //    {
        //        this.courseCategoryId = value;
        //    }
        //}

        //public string Level
        //{
        //    get
        //    {
        //        return this.level;
        //    }

        //    set
        //    {
        //        this.level = value;
        //    }
        //}

        //public int NumberOfClassroom
        //{
        //    get
        //    {
        //        return this.numberOfClassroom;
        //    }

        //    set
        //    {
        //        this.numberOfClassroom = value;
        //    }
        //}

        //public int ClassroomDuration
        //{
        //    get
        //    {
        //        return this.classroomDuration;
        //    }

        //    set
        //    {
        //        this.classroomDuration = value;
        //    }
        //}

        //public int StudentPerClassroom
        //{
        //    get
        //    {
        //        return this.studentPerClassroom;
        //    }

        //    set
        //    {
        //        this.studentPerClassroom = value;
        //    }
        //}

        //public string Status
        //{
        //    get
        //    {
        //        return this.status;
        //    }

        //    set
        //    {
        //        this.status = value;
        //    }
        //}
    }
}
