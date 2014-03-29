using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class CourseService
    {
        private CourseDao courseDao = new CourseDao();

        public bool addCourse(Course course)
        {
            string sql = "INSERT INTO " +
                         Course.tableName + " (" +
                         Course.columnCourseId + ", " +
                         Course.columnCourseCategoryId + ", " +
                         Course.columnCourseName + ", " +
                         Course.columnCourseLevel + ", " +
                         Course.columnNumberOfClassroom + ", " +
                         Course.columnCourseFee + ", " +
                         Course.columnClassroomDuration + ", " +
                         Course.columnStudentPerClassroom + ", " +
                         Course.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Course.columnCourseId + ", " +
                         "?" + Course.columnCourseCategoryId + ", " +
                         "?" + Course.columnCourseName + ", " +
                         "?" + Course.columnCourseLevel + ", " +
                         "?" + Course.columnNumberOfClassroom + ", " +
                         "?" + Course.columnCourseFee + ", " +
                         "?" + Course.columnClassroomDuration + ", " +
                         "?" + Course.columnStudentPerClassroom + ", " +
                         "?" + Course.columnStatus + ")";

            return this.courseDao.processInsertString(sql, course);
        }

        public bool updateCourse(Course course)
        {
            string sql = "UPDATE " +
                         Course.tableName + " SET " +
                         Course.columnCourseCategoryId + " = ?" + Course.columnCourseCategoryId + ", " +
                         Course.columnCourseName + " = ?" + Course.columnCourseName + ", " +
                         Course.columnCourseLevel + " = ?" + Course.columnCourseLevel + ", " +
                         Course.columnNumberOfClassroom + " = ?" + Course.columnNumberOfClassroom + ", " +
                         Course.columnCourseFee + " = ?" + Course.columnCourseFee + ", " +
                         Course.columnClassroomDuration + " = ?" + Course.columnClassroomDuration + ", " +
                         Course.columnStudentPerClassroom + " = ?" + Course.columnStudentPerClassroom + ", " +
                         Course.columnStatus + " = ?" + Course.columnStatus + " " +
                         "WHERE " + Course.columnCourseId + " = ?" + Course.columnCourseId;

            return this.courseDao.processUpdateString(sql, course);
        }

        public bool deleteCourse(int courseId)
        {
            string sql = "DELETE " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " = " + courseId;

            return this.courseDao.processDeleteString(sql);
        }

        public bool deleteCourse(string courseName)
        {
            string sql = "DELETE " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " = '" + courseName + "'";

            return this.courseDao.processDeleteString(sql);
        }

        public Course getLastCourse()
        {
            Course course = null;

            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "ORDER BY " + Course.columnCourseId + " DESC " +
                         "LIMIT 1";

            List<Course> courseList = this.courseDao.processQueryString(sql);
            if (courseList.Count > 0)
            {
                course = courseList[0];
            }

            return course;
        }

        public Course getCourse(int courseId)
        {
            Course course = null;
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " = " + courseId;

            List<Course> courseList = this.courseDao.processQueryString(sql);
            if (courseList.Count > 0)
            {
                course = courseList[0];
            }

            return course;
        }

        public Course getCourse(int courseId, string status)
        {
            Course course = null;
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " = " + courseId + " " +
                         "AND " + Course.columnStatus + " = '" + status + "'";

            List<Course> courseList = this.courseDao.processQueryString(sql);
            if (courseList.Count > 0)
            {
                course = courseList[0];
            }

            return course;
        }

        public Course getCourseByNameAndLevel(string courseName, string courseLevel)
        {
            Course course = null;
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " = '" + courseName + "' " +
                         "AND " + Course.columnCourseLevel + " = '" + courseLevel + "'";

            List<Course> courseList = this.courseDao.processQueryString(sql);
            if (courseList.Count > 0)
            {
                course = courseList[0];
            }

            return course;
        }

        public Course getCourseByNameAndLevel(string courseName, string courseLevel, string status)
        {
            Course course = null;
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " = '" + courseName + "' " +
                         "AND " + Course.columnCourseLevel + " = '" + courseLevel + "' " +
                         "AND " + Course.columnStatus + " = '" + status + "'";

            List<Course> courseList = this.courseDao.processQueryString(sql);
            if (courseList.Count > 0)
            {
                course = courseList[0];
            }

            return course;
        }

        public List<Course> getAllCourse()
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourse(int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";  

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourse(string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourse(string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnStatus + " = '" + status + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC"; 

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseCategoryId(int courseCategoryId)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseCategoryId(int courseCategoryId, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseCategoryId(int courseCategoryId, string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseCategoryId(int courseCategoryId, string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnStatus + " = '" + status + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseNameWithoutWildard(string courseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " LIKE '" + courseName + "' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseName(string courseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseName(string courseName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseName(string courseName, string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "AND " + Course.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseName(string courseName, string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "AND " + Course.columnStatus + " = '" + status + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "AND " + Course.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "AND " + Course.columnStatus + " = '" + status + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public bool matchCourseId(int oldCourseId, int newCourseId)
        {
            string sql = "INSERT INTO " +
                         Course.matchingTableName + " (" +
                         Course.columnOldCourseId + ", " +
                         Course.columnNewCourseId + ") " +
                         "VALUES(" +
                         "?" + Course.columnOldCourseId + ", " +
                         "?" + Course.columnNewCourseId + ")";

            return this.courseDao.processInsertStringForMathching(sql, oldCourseId, newCourseId);
        }

        public int getNewCourseId(int oldCourseId)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.matchingTableName + " " +
                         "WHERE " + Course.columnOldCourseId + " = " + oldCourseId;

            return this.courseDao.processQueryStringForMatching(sql);
        }

        //Temporary
        public List<Course> getAllCourseOld()
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + "_old " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }

        public List<Course> getAllCourseOld(int courseCategoryId)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + "_old " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.courseDao.processQueryString(sql);
        }
    }
}
