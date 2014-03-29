using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class CourseCategoryManager
    {
        private static CourseCategoryDao courseCategoryDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getCourseCategoryDao();

        //--------------------------------------------------------------------------------

        public static bool insertCourseCategory(CourseCategory courseCategory)
        {
            return courseCategoryDao.insertCourseCategory(courseCategory);
        }

        public static bool updateCourseCategory(CourseCategory courseCategory)
        {
            return courseCategoryDao.updateCourseCategory(courseCategory);
        }

        public static bool deleteCourseCategory(int courseCategoryId)
        {
            return courseCategoryDao.deleteCourseCategory(courseCategoryId);
        }

        //--------------------------------------------------------------------------------

        public static CourseCategory findCourseCategory(int courseCategoryId)
        {
            return courseCategoryDao.findCourseCategory(courseCategoryId);
        }

        public static CourseCategory findCourseCategory(int courseCategoryId, CourseCategory.CourseCategoryStatus status)
        {
            CourseCategory courseCategory;

            if (status == CourseCategory.CourseCategoryStatus.ALL)
            {
                courseCategory = courseCategoryDao.findCourseCategory(courseCategoryId);
            }
            else
            {
                courseCategory = courseCategoryDao.findCourseCategory(courseCategoryId, status);
            }

            return courseCategory;
        }

        public static CourseCategory findCourseCategory(string courseCategoryName)
        {
            return courseCategoryDao.findCourseCategory(courseCategoryName);
        }

        public static CourseCategory findCourseCategory(string courseCategoryName, CourseCategory.CourseCategoryStatus status)
        {
            CourseCategory courseCategory;

            if (status == CourseCategory.CourseCategoryStatus.ALL)
            {
                courseCategory = courseCategoryDao.findCourseCategory(courseCategoryName);
            }
            else
            {
                courseCategory = courseCategoryDao.findCourseCategory(courseCategoryName, status);
            }

            return courseCategory;
        }

        //--------------------------------------------------------------------------------

        public static List<CourseCategory> findAllCourseCategory()
        {
            return courseCategoryDao.findAllCourseCategory();
        }

        public static List<CourseCategory> findAllCourseCategory(CourseCategory.CourseCategoryStatus status)
        {
            return courseCategoryDao.findAllCourseCategory(status);
        }

        //--------------------------------------------------------------------------------
    }
}
