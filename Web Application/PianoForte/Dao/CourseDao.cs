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

        Course getCourse(string databaseName, int id);

        List<Course> getCourseList(string databaseName);

        List<Course> getCourseList(string databaseName, Status status);

        List<Course> getCourseListByName(string databaseName, string name);

        List<Course> getCourseListByName(string databaseName, string name, Status status);

        List<string> getCourseNameList(string databaseName);

        List<string> getCourseNameList(string databaseName, Status status);
    }
}
