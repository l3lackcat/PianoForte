using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface TeachingCourseDao
    {
        bool insertTeachingCourse(int teacherId, int courseId);
        bool updateTeachingCourse(int teacherId, int courseId);
        bool deleteTeachingCourse(int teacherId, int courseId);
        bool deleteTeachingCourseByTeacherId(int teacherId);
        bool deleteTeachingCourseByCourseId(int courseId);

        List<int> findCourseIdByTeacherId(int teacherId);

        List<int> findTeacherIdByCourseId(int courseId);
    }
}
