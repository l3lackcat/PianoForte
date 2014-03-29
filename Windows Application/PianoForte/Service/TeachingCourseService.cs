using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class TeachingCourseService
    {
        private TeachingCourseDao teachingCourseDao = new TeachingCourseDao();

        public bool addTeachingCourse(int teacherId, int courseId)
        {
            string sql = "INSERT INTO " +
                         TeachingCourse.tableName + " (" +
                         TeachingCourse.columnTeacherId + ", " +
                         TeachingCourse.columnCourseId + ") " +
                         "VALUES(" +
                         "?" + TeachingCourse.columnTeacherId + ", " +
                         "?" + TeachingCourse.columnCourseId + ")";

            return this.teachingCourseDao.processInsertString(sql, teacherId, courseId);
        }

        public bool updateTeachingCourse(int teacherId, int courseId)
        {
            string sql = "UPDATE " +
                         TeachingCourse.tableName + " SET " +
                         TeachingCourse.columnCourseId + " = ?" + TeachingCourse.columnCourseId + " " +
                         "WHERE " + TeachingCourse.columnTeacherId + " = ?" + TeachingCourse.columnTeacherId;

            return this.teachingCourseDao.processUpdateString(sql, teacherId, courseId);
        }

        public bool deleteTeachingCourseByTeacherId(int teacherId)
        {
            string sql = "DELETE " +
                         "FROM " + TeachingCourse.tableName + " " +
                         "WHERE " + TeachingCourse.columnTeacherId + " = " + teacherId;

            return this.teachingCourseDao.processDeleteString(sql);
        }

        public bool deleteTeachingCourseByCourseId(int courseId)
        {
            string sql = "DELETE " +
                         "FROM " + TeachingCourse.tableName + " " +
                         "WHERE " + TeachingCourse.columnCourseId + " = '" + courseId + "'";

            return this.teachingCourseDao.processDeleteString(sql);
        }

        public bool deleteTeachingCourse(int teacherId, int courseId)
        {
            string sql = "DELETE " +
                         "FROM " + TeachingCourse.tableName + " " +
                         "WHERE " + TeachingCourse.columnTeacherId + " = " + teacherId + " " +
                         "AND " + TeachingCourse.columnCourseId + " = '" + courseId + "'";

            return this.teachingCourseDao.processDeleteString(sql);
        }

        public List<int> getCourseIdByTeacherId(int teacherId)
        {
            string sql = "SELECT * " +
                         "FROM " + TeachingCourse.tableName + " " +
                         "WHERE " + TeachingCourse.columnTeacherId + " = " + teacherId;

            return this.teachingCourseDao.processQueryStringForCourseId(sql);
        }

        public List<int> getTeacherIdByCourseId(int courseId)
        {
            string sql = "SELECT * " +
                         "FROM " + TeachingCourse.tableName + " " +
                         "WHERE " + TeachingCourse.columnCourseId + " = '" + courseId + "'";

            return this.teachingCourseDao.processQueryStringForTeacherId(sql);
        }

        //Temporary
        public List<string> getCourseNameByTeacherId(int teacherId)
        {
            string sql = "SELECT * " +
                         "FROM teaching_course_old " +
                         "WHERE " + TeachingCourse.columnTeacherId + " = " + teacherId;

            return this.teachingCourseDao.processQueryStringForCourseName(sql);
        }
    }
}
