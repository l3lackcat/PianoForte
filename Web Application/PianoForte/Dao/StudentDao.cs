using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface StudentDao
    {
        bool insertStudent(string databaseName, Student student);

        bool updateStudent(string databaseName, Student student);

        List<Student> getStudentList(string databaseName, int studentId);

        List<Student> getStudentList(string databaseName, int startIndex, int offset);

        List<Student> getStudentList(string databaseName, int startIndex, int offset, string keyword);

        List<ShortStudent> getShortStudentList(string databaseName);

        List<ShortStudent> getShortStudentList(string databaseName, string keyword);

        List<ShortStudent> getShortStudentList(string databaseName, string keyword, int startIndex, int offset);
    }
}
