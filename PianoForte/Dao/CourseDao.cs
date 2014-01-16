using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface CourseDao
    {
        bool insertCourse(string databaseName, Course course);

        bool updateCourse(string databaseName, Course course);

        Course getCourse(string databaseName, int courseId);

        List<Course> getCourseList(string databaseName);

        List<Course> getCourseList(string databaseName, string keyword);

        List<Course> getCourseListByName(string databaseName, string courseName);

        List<Course> getCourseListByName(string databaseName, string courseName, Status status);

        List<string> getCourseNameList(string databaseName);

        List<string> getCourseNameList(string databaseName, Status status);
    }
}
