using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface StudentContactDao
    {
        bool insertStudentContact(string databaseName, StudentContact studentContact);

        bool updateStudentContact(string databaseName, StudentContact studentContact);

        bool deleteStudentContact(string databaseName, int contactId);

        bool deleteStudentContactList(string databaseName, int studentId);

        StudentContact getStudentContact(string databaseName, int contactId);

        StudentContact getStudentContact(string databaseName, int teacherId, ContactType type, string label, string content);

        List<StudentContact> getStudentContactList(string databaseName, int teacherId);

        List<StudentContact> getStudentContactList(string databaseName, int teacherId, Status status);
    }
}
