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

        public static Student getStudent(string databaseName, int id)
        {
            return studentDao.getStudent(databaseName, id);;
        }
        
        public static List<Student> getStudentList(string databaseName)
        {
            return studentDao.getStudentList(databaseName);
        }

        public static List<Student> getStudentList(string databaseName, int startIndex, int offset)
        {
            return studentDao.getStudentList(databaseName, startIndex, offset);
        }
    }
}