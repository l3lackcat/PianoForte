using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface CourseCategoryDao
    {
        bool insertCourseCategory(CourseCategory courseCategory);
        bool updateCourseCategory(CourseCategory courseCategory);
        bool deleteCourseCategory(int courseCategoryId);

        CourseCategory findLastCourseCategory();

        CourseCategory findCourseCategory(int courseCategoryId);
        CourseCategory findCourseCategory(int courseCategoryId, CourseCategory.CourseCategoryStatus status);
        CourseCategory findCourseCategory(string courseCategoryName);
        CourseCategory findCourseCategory(string courseCategoryName, CourseCategory.CourseCategoryStatus status);

        List<CourseCategory> findAllCourseCategory();
        List<CourseCategory> findAllCourseCategory(CourseCategory.CourseCategoryStatus status);
    }
}
