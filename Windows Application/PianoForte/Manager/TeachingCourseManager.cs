using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class TeachingCourseManager
    {
        private static TeachingCourseDao teachingCourseDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getTeachingCourseDao();

        public static bool insertTeachingCourse(int teacherId, int courseId)
        {
            return teachingCourseDao.insertTeachingCourse(teacherId, courseId);
        }

        public static bool updateTeachingCourse(int teacherId, int courseId)
        {
            return teachingCourseDao.updateTeachingCourse(teacherId, courseId);
        }

        public static bool deleteTeachingCourseByTeacherId(int teacherId)
        {
            return teachingCourseDao.deleteTeachingCourseByTeacherId(teacherId);
        }

        public static bool deleteTeachingCourseByCourseId(int courseId)
        {
            return teachingCourseDao.deleteTeachingCourseByCourseId(courseId);
        }

        public static bool deleteTeachingCourse(int teacherId, int courseId)
        {
            return teachingCourseDao.deleteTeachingCourse(teacherId, courseId);
        }

        public static List<int> getCourseIdByTeacherId(int teacherId)
        {
            return teachingCourseDao.findCourseIdByTeacherId(teacherId);
        }

        public static List<int> getTeacherIdByCourseId(int courseId)
        {
            return teachingCourseDao.findTeacherIdByCourseId(courseId);
        }

        //Temporary
        //public static List<string> getCourseNameByTeacherId(int teacherId)
        //{
        //    return teachingCourseService.getCourseNameByTeacherId(teacherId);
        //}
    }
}
