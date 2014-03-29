using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class StudentAddressService
    {
        private static StudentAddressDao studentAddressDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getStudentAddressDao();

        public static bool insertStudentAddress(string databaseName, StudentAddress studentAddress)
        {
            return studentAddressDao.insertStudentAddress(databaseName, studentAddress);
        }

        public static bool updateStudentAddress(string databaseName, StudentAddress studentAddress)
        {
            return studentAddressDao.updateStudentAddress(databaseName, studentAddress);
        }

        public static bool deleteStudentAddress(string databaseName, int studentId)
        {
            return studentAddressDao.deleteStudentAddress(databaseName, studentId);
        }

        public static StudentAddress getStudentAddress(string databaseName, int studentId)
        {
            StudentAddress studentAddress = null;

            List<StudentAddress> studentAddressList = studentAddressDao.getStudentAddressList(databaseName, studentId);
            if (studentAddressList.Count == 1)
            {
                studentAddress = studentAddressList[0];
            }

            return studentAddress;
        }
    }
}