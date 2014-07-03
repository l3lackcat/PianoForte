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

        Student getStudent(string databaseName, int id);

        List<Student> getStudentList(string databaseName);
    }
}
