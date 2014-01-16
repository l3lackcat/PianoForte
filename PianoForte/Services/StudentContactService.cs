using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class StudentContactService
    {
        private static StudentContactDao studentContactDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getStudentContactDao();

        public static bool insertStudentContact(string databaseName, StudentContact studentContact)
        {
            return studentContactDao.insertStudentContact(databaseName, studentContact);
        }

        public static bool updateStudentContact(string databaseName, StudentContact studentContact)
        {
            return studentContactDao.updateStudentContact(databaseName, studentContact);
        }

        public static bool deleteStudentContact(string databaseName, int contactId)
        {
            return studentContactDao.deleteStudentContact(databaseName, contactId);
        }

        public static bool deleteStudentContactList(string databaseName, int studentId)
        {
            return studentContactDao.deleteStudentContactList(databaseName, studentId);
        }

        public static StudentContact getStudentContact(string databaseName, int contactId)
        {
            return studentContactDao.getStudentContact(databaseName, contactId);
        }

        public static StudentContact getStudentContact(string databaseName, int studentId, ContactType type, string label, string content)
        {
            return studentContactDao.getStudentContact(databaseName, studentId, type, label, content);
        }

        public static List<StudentContact> getStudentContactList(string databaseName, int studentId)
        {
            return studentContactDao.getStudentContactList(databaseName, studentId);
        }

        public static List<StudentContact> getStudentContactList(string databaseName, int studentId, Status status)
        {
            return studentContactDao.getStudentContactList(databaseName, studentId, status);
        }
    }
}