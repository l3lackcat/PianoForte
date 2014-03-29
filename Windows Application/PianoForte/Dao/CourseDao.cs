using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface CourseDao
    {
        bool insertCourse(Course course);
        bool updateCourse(Course course);
        bool updateCourseId(int oldCourseId, int newCourseId);
        bool deleteCourse(int courseId);
        bool deleteCourse(string courseName);

        Course findCourse(int courseId);
        Course findCourse(int courseId, Course.CourseStatus status);
        Course findLastCourse();

        Course findCourseByNameAndLevel(string courseName, string courseLevel);
        Course findCourseByNameAndLevel(string courseName, string courseLevel, Course.CourseStatus status);

        List<Course> findAllCourse();
        List<Course> findAllCourse(int startIndex, int offset);
        List<Course> findAllCourse(Course.CourseStatus status);
        List<Course> findAllCourse(Course.CourseStatus status, int startIndex, int offset);

        List<Course> findAllCourseByCourseCategoryId(int courseCategoryId);
        List<Course> findAllCourseByCourseCategoryId(int courseCategoryId, int startIndex, int offset);
        List<Course> findAllCourseByCourseCategoryId(int courseCategoryId, Course.CourseStatus status);
        List<Course> findAllCourseByCourseCategoryId(int courseCategoryId, Course.CourseStatus status, int startIndex, int offset);

        List<Course> findAllCourseByCourseName(string courseName);
        List<Course> findAllCourseByCourseName(string courseName, int startIndex, int offset);
        List<Course> findAllCourseByCourseName(string courseName, Course.CourseStatus status);
        List<Course> findAllCourseByCourseName(string courseName, Course.CourseStatus status, int startIndex, int offset);

        List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName);
        List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, int startIndex, int offset);
        List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, Course.CourseStatus status);
        List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, Course.CourseStatus status, int startIndex, int offset);

        List<Course> findAllCourseByCourseNameWithoutWildcard(string courseName);
    }
}
