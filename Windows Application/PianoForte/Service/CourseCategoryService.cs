using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class CourseCategoryService
    {
        private CourseCategoryDao courseCategoryDao = new CourseCategoryDao();

        public bool addCourseCategory(CourseCategory courseCategory)
        {
            string sql = "INSERT INTO " +
                         CourseCategory.tableName + " (" +
                         CourseCategory.columnCourseCategoryName + ", " +
                         CourseCategory.columnStatus + ") " +
                         "VALUES(" +
                         "?" + CourseCategory.columnCourseCategoryName + ", " +
                         "?" + CourseCategory.columnStatus + ")";

            return this.courseCategoryDao.processInsertString(sql, courseCategory);
        }

        public bool updateCourseCategory(CourseCategory courseCategory)
        {
            string sql = "UPDATE " +
                         CourseCategory.tableName + " SET " +
                         CourseCategory.columnCourseCategoryName + " = ?" + CourseCategory.columnCourseCategoryName + ", " +
                         CourseCategory.columnStatus + " = ?" + CourseCategory.columnStatus + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryId + " = ?" + CourseCategory.columnCourseCategoryId;

            return this.courseCategoryDao.processUpdateString(sql, courseCategory);
        }

        public bool deleteCourseCategory(int courseCategoryId)
        {
            string sql = "DELETE " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryId + " = " + courseCategoryId;
            /*
            string sql = "DELETE FROM CourseCategories " +
                         "WHERE courseCategoryID = " + courseCategoryId;
            */
            return this.courseCategoryDao.processDeleteString(sql);
        }

        public bool deleteCourseCategory(string courseCategoryName)
        {
            string sql = "DELETE " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryName + " = '" + courseCategoryName + "'";
            /*
            string sql = "DELETE FROM CourseCategories " +
                         "WHERE courseCategoryName = '" + courseCategoryName + "'";
            */
            return this.courseCategoryDao.processDeleteString(sql);
        }

        public CourseCategory getLastCourseCategory()
        {
            CourseCategory courseCategory = null;

            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "ORDER BY " + CourseCategory.columnCourseCategoryId + " DESC " +
                         "LIMIT 1";

            List<CourseCategory> courseCategoryList = this.courseCategoryDao.processQueryString(sql);
            if (courseCategoryList.Count > 0)
            {
                courseCategory = courseCategoryList[0];
            }

            return courseCategory;
        }

        public CourseCategory getCourseCategory(int courseCategoryId)
        {
            CourseCategory courseCategory = null;

            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryId + " = " + courseCategoryId;
            /*
            string sql = "SELECT * " +
                         "FROM CourseCategories " +
                         "WHERE courseCategoryID = " + courseCategoryId;
            */
            List<CourseCategory> courseCategoryList = this.courseCategoryDao.processQueryString(sql);
            if (courseCategoryList.Count > 0)
            {
                courseCategory = courseCategoryList[0];
            }

            return courseCategory;
        }

        public CourseCategory getCourseCategory(string courseCategoryName)
        {
            CourseCategory courseCategory = null;

            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryName + " = '" + courseCategoryName + "'";
            /*
            string sql = "SELECT * " +
                         "FROM CourseCategories " +
                         "WHERE courseCategoryName = '" + courseCategoryName + "'";
            */
            List<CourseCategory> courseCategoryList = this.courseCategoryDao.processQueryString(sql);
            if (courseCategoryList.Count > 0)
            {
                courseCategory = courseCategoryList[0];
            }

            return courseCategory;
        }

        public List<CourseCategory> getAllCourseCategory()
        {
            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "ORDER BY " + CourseCategory.columnCourseCategoryId + " ASC";
            /*
            string sql = "SELECT * " +
                         "FROM CourseCategories " +
                         "ORDER BY courseCategoryID ASC";
            */
            return this.courseCategoryDao.processQueryString(sql);
        }

        public CourseCategory getActiveCourseCategory(int courseCategoryId)
        {
            CourseCategory courseCategory = null;

            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + CourseCategory.columnStatus + " = '" + CourseCategory.CourseCategoryStatus.ACTIVE.ToString() + "'";
            /*
            string sql = "SELECT * " +
                         "FROM CourseCategories " +
                         "WHERE courseCategoryID = " + courseCategoryId + " " +
                         "AND status = '" + CourseCategory.CourseCategoryStatus.ACTIVE.ToString() + "'";
            */
            List<CourseCategory> courseCategoryList = this.courseCategoryDao.processQueryString(sql);
            if (courseCategoryList.Count > 0)
            {
                courseCategory = courseCategoryList[0];
            }

            return courseCategory;
        }

        public CourseCategory getActiveCourseCategory(string courseCategoryName)
        {
            CourseCategory courseCategory = null;

            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryName + " = '" + courseCategoryName + "' " +
                         "AND " + CourseCategory.columnStatus + " = '" + CourseCategory.CourseCategoryStatus.ACTIVE.ToString() + "'";
            /*
            string sql = "SELECT * " +
                         "FROM CourseCategories " +
                         "WHERE courseCategoryName = '" + courseCategoryName + "' " +
                         "AND status = '" + CourseCategory.CourseCategoryStatus.ACTIVE.ToString() + "'";
            */
            List<CourseCategory> courseCategoryList = this.courseCategoryDao.processQueryString(sql);
            if (courseCategoryList.Count > 0)
            {
                courseCategory = courseCategoryList[0];
            }

            return courseCategory;
        }

        public List<CourseCategory> getAllActiveCourseCategory()
        {
            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnStatus + " = '" + CourseCategory.CourseCategoryStatus.ACTIVE.ToString() + "' " +
                         "ORDER BY " + CourseCategory.columnCourseCategoryId + " ASC";
            /*
            string sql = "SELECT * " +
                         "FROM CourseCategories " +
                         "WHERE status = '" + CourseCategory.CourseCategoryStatus.ACTIVE.ToString() + "' " +
                         "ORDER BY courseCategoryID ASC";
            */
            return this.courseCategoryDao.processQueryString(sql);
        }              
    }
}
