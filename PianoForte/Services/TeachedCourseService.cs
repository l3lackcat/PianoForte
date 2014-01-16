using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;

namespace PianoForte.Services
{
    public class TeachedCourseService
    {
        private static TeachedCourseDao teachedCourseDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getTeachedCourseDao();

        public static bool insertTeachedCourse(string databaseName, int teacherId, int courseId)
        {
            return teachedCourseDao.insertTeachedCourse(databaseName, teacherId, courseId);
        }

        public static bool deleteTeachedCourseListByCourseId(string databaseName, int courseId)
        {
            return teachedCourseDao.deleteTeachedCourseListByCourseId(databaseName, courseId);
        }

        public static bool deleteTeachedCourseListByTeacherId(string databaseName, int teacherId)
        {
            return teachedCourseDao.deleteTeachedCourseListByTeacherId(databaseName, teacherId);
        }

        public static List<int> getTeachedCourseIdList(string databaseName, int teacherId)
        {
            return teachedCourseDao.getTeachedCourseIdList(databaseName, teacherId);
        }
    }
}