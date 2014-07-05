using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface TeacherDao
    {
        bool insertTeacher(string databaseName, Teacher teacher);

        bool updateTeacher(string databaseName, Teacher teacher);

        Teacher getLastTeacher(string databaseName);

        Teacher getTeacher(string databaseName, int id);

        List<Teacher> getTeacherList(string databaseName);
    }
}
