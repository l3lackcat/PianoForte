using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class StudentService
    {
        private static StudentDao studentDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getStudentDao();

        public static bool insertStudent(string databaseName, Student student)
        {
            return studentDao.insertStudent(databaseName, student);
        }

        public static bool updateStudent(string databaseName, Student student)
        {
            return studentDao.updateStudent(databaseName, student);
        }

        public static Student getStudent(string databaseName, int studentId)
        {
            Student student = null;

            List<Student> tempStudentList = studentDao.getStudentList(databaseName, studentId);
            if (tempStudentList.Count == 1)
            {
                student = tempStudentList[0];
            }

            return student;
        }

        public static List<Student> getStudentList(string databaseName, int startIndex, int offset)
        {
            return studentDao.getStudentList(databaseName, startIndex, offset);
        }

        public static List<Student> getStudentList(string databaseName, int startIndex, int offset, string keyword)
        {
            return studentDao.getStudentList(databaseName, startIndex, offset, keyword);
        }

        public static List<ShortStudent> getShortStudentList(string databaseName)
        {
            return studentDao.getShortStudentList(databaseName);
        }

        public static List<ShortStudent> getShortStudentList(string databaseName, string keyword)
        {
            return studentDao.getShortStudentList(databaseName, keyword);
        }

        public static List<ShortStudent> getShortStudentList(string databaseName, string keyword, int startIndex, int offset)
        {
            return studentDao.getShortStudentList(databaseName, keyword, startIndex, offset);
        }
    }
}