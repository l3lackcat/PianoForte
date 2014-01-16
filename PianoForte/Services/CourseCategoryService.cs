using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class CourseCategoryService
    {
        private static CourseCategoryDao courseCategoryDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getCourseCategoryDao();

        public static bool insertCourseCategory(string databaseName, CourseCategory courseCategory)
        {
            return courseCategoryDao.insertCourseCategory(databaseName, courseCategory);
        }

        public static bool updateCourseCategory(string databaseName, CourseCategory courseCategory)
        {
            return courseCategoryDao.updateCourseCategory(databaseName, courseCategory);
        }

        public static CourseCategory getCourseCategory(string databaseName, int courseCategoryId)
        {
            return courseCategoryDao.getCourseCategory(databaseName, courseCategoryId);
        }

        public static List<CourseCategory> getCourseCategoryList(string databaseName)
        {
            return courseCategoryDao.getCourseCategoryList(databaseName);
        }

        public static List<CourseCategory> getCourseCategoryList(string databaseName, Status status)
        {
            return courseCategoryDao.getCourseCategoryList(databaseName, status);
        }
    }
}