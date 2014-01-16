using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface TeacherContactDao
    {
        bool insertTeacherContact(string databaseName, TeacherContact teacherContact);

        bool updateTeacherContact(string databaseName, TeacherContact teacherContact);

        bool deleteTeacherContact(string databaseName, int contactId);

        bool deleteTeacherContactList(string databaseName, int teacherId);

        TeacherContact getTeacherContact(string databaseName, int contactId);

        TeacherContact getTeacherContact(string databaseName, int teacherId, ContactType type, string label, string content);

        List<TeacherContact> getTeacherContactList(string databaseName, int teacherId);

        List<TeacherContact> getTeacherContactList(string databaseName, int teacherId, Status status);
    }
}
