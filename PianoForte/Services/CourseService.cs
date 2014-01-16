using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class CourseService
    {
        private static CourseDao courseDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getCourseDao();

        public static bool insertCourse(string databaseName, Course course)
        {
            return courseDao.insertCourse(databaseName, course);
        }

        public static bool updateCourse(string databaseName, Course course)
        {
            return courseDao.updateCourse(databaseName, course);
        }

        public static Course getCourse(string databaseName, int courseId)
        {
            return courseDao.getCourse(databaseName, courseId);
        }

        public static List<Course> getCourseList(string databaseName)
        {
            return courseDao.getCourseList(databaseName);
        }

        public static List<Course> getCourseList(string databaseName, string keyword)
        {
            return courseDao.getCourseList(databaseName, keyword);
        }

        public static List<Course> getCourseListByName(string databaseName, string courseName)
        {
            return courseDao.getCourseListByName(databaseName, courseName);
        }

        public static List<Course> getCourseListByName(string databaseName, string courseName, Status status)
        {
            return courseDao.getCourseListByName(databaseName, courseName, status);
        }

        public static List<string> getCourseNameList(string databaseName)
        {
            return courseDao.getCourseNameList(databaseName);
        }

        public static List<string> getCourseNameList(string databaseName, Status status)
        {
            return courseDao.getCourseNameList(databaseName, status);
        }
    }
}