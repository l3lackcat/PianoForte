using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Dao
{
    public interface TeachedCourseDao
    {
        bool insertTeachedCourse(string databaseName, int teacherId, int courseId);

        bool deleteTeachedCourseListByCourseId(string databaseName, int courseId);

        bool deleteTeachedCourseListByTeacherId(string databaseName, int teacherId);

        List<int> getTeachedCourseIdList(string databaseName, int teacherId);
    }
}
