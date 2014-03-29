using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class TeacherContactService
    {
        private static TeacherContactDao teacherContactDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getTeacherContactDao();

        public static bool insertTeacherContact(string databaseName, TeacherContact teacherContact)
        {
            return teacherContactDao.insertTeacherContact(databaseName, teacherContact);
        }

        public static bool updateTeacherContact(string databaseName, TeacherContact teacherContact)
        {
            return teacherContactDao.updateTeacherContact(databaseName, teacherContact);
        }

        public static bool deleteTeacherContact(string databaseName, int contactId)
        {
            return teacherContactDao.deleteTeacherContact(databaseName, contactId);
        }

        public static bool deleteTeacherContactList(string databaseName, int teacherId)
        {
            return teacherContactDao.deleteTeacherContactList(databaseName, teacherId);
        }

        public static TeacherContact getTeacherContact(string databaseName, int contactId)
        {
            return teacherContactDao.getTeacherContact(databaseName, contactId);
        }

        public static TeacherContact getTeacherContact(string databaseName, int teacherId, ContactType type, string label, string content)
        {
            return teacherContactDao.getTeacherContact(databaseName, teacherId, type, label, content);
        }

        public static List<TeacherContact> getTeacherContactList(string databaseName, int teacherId)
        {
            return teacherContactDao.getTeacherContactList(databaseName, teacherId);
        }

        public static List<TeacherContact> getTeacherContactList(string databaseName, int teacherId, Status status)
        {
            return teacherContactDao.getTeacherContactList(databaseName, teacherId, status);
        }
    }
}