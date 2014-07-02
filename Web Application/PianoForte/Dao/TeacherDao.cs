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

        Teacher getTeacher(string databaseName, int id);

        List<Teacher> getTeacherList(string databaseName);

        List<Teacher> getTeacherList(string databaseName, string keyword);

        List<ShortTeacher> getShortTeacherList(string databaseName);

        List<ShortTeacher> getShortTeacherList(string databaseName, string keyword);

        List<ShortTeacher> getShortTeacherList(string databaseName, string keyword, int startIndex, int offset);
    }
}
