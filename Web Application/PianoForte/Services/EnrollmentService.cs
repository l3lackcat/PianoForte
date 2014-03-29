using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class EnrollmentService
    {
        private static EnrollmentDao enrollmentDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getEnrollmentDao();

        public static bool insertEnrollment(string databaseName, Enrollment enrollment)
        {
            return enrollmentDao.insertEnrollment(databaseName, enrollment);
        }

        public static bool updateEnrollment(string databaseName, Enrollment enrollment)
        {
            return enrollmentDao.updateEnrollment(databaseName, enrollment);
        }
    }
}