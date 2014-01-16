using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface CourseCategoryDao
    {
        bool insertCourseCategory(string databaseName, CourseCategory courseCategory);

        bool updateCourseCategory(string databaseName, CourseCategory courseCategory);

        CourseCategory getCourseCategory(string databaseName, int courseCategoryId);

        List<CourseCategory> getCourseCategoryList(string databaseName);

        List<CourseCategory> getCourseCategoryList(string databaseName, Status status);
    }
}
