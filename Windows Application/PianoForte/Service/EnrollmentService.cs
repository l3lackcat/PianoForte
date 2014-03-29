using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class EnrollmentService
    {
        private EnrollmentDaoImplMySql enrollmentDao = new EnrollmentDaoImplMySql();

        public bool addEnrollment(Enrollment enrollment)
        {
            string sql = "INSERT INTO " +
                         Enrollment.tableName + " (" +
                         Enrollment.columnPaymentId + ", " +
                         Enrollment.columnStudentId + ", " +
                         Enrollment.columnCourseId + ", " +
                         Enrollment.columnEnrollmentDate + ", " +
                         Enrollment.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Enrollment.columnPaymentId + ", " +
                         "?" + Enrollment.columnStudentId + ", " +
                         "?" + Enrollment.columnCourseId + ", " +
                         "?" + Enrollment.columnEnrollmentDate + ", " +
                         "?" + Enrollment.columnStatus + ")";

            return this.enrollmentDao.processInsertString(sql, enrollment);
        }

        public bool updateEnrollment(Enrollment enrollment)
        {
            string sql = "UPDATE " +
                         Enrollment.tableName + " SET " +
                         Enrollment.columnPaymentId + " = ?" + Enrollment.columnPaymentId + ", " +
                         Enrollment.columnStudentId + " = ?" + Enrollment.columnStudentId + ", " +
                         Enrollment.columnCourseId + " = ?" + Enrollment.columnCourseId + ", " +
                         Enrollment.columnEnrollmentDate + " = ?" + Enrollment.columnEnrollmentDate + ", " +
                         Enrollment.columnStatus + " = ?" + Enrollment.columnStatus + " " +
                         "WHERE " + Enrollment.columnEnrollmentId + " = ?" + Enrollment.columnEnrollmentId;

            return this.enrollmentDao.processUpdateString(sql, enrollment);
        }

        public bool deleteEnrollment(int enrollmentId)
        {
            string sql = "DELETE " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnEnrollmentId + " = " + enrollmentId;

            return this.enrollmentDao.processDeleteString(sql);
        }

        public Enrollment getLastEnrollment()
        {
            Enrollment enrollment = null;

            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " DESC " +
                         "LIMIT 1";

            List<Enrollment> enrollmentList = this.enrollmentDao.processQueryString(sql);
            if (enrollmentList.Count > 0)
            {
                enrollment = enrollmentList[0];
            }

            return enrollment;
        }

        public Enrollment getEnrollment(int enrollmentId)
        {
            Enrollment enrollment = null;

            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnEnrollmentId + " = " + enrollmentId;

            List<Enrollment> enrollmentList = this.enrollmentDao.processQueryString(sql);
            if (enrollmentList.Count > 0)
            {
                enrollment = enrollmentList[0];
            }

            return enrollment;
        }

        public Enrollment getEnrollmentByPaymentId(int paymentId)
        {
            Enrollment enrollment = null;

            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnPaymentId + " = " + paymentId;

            List<Enrollment> enrollmentList = this.enrollmentDao.processQueryString(sql);
            if (enrollmentList.Count > 0)
            {
                enrollment = enrollmentList[0];
            }

            return enrollment;
        }

        public List<Enrollment> getAllEnrollment()
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.enrollmentDao.processQueryString(sql);
        }

        public List<Enrollment> getAllEnrollment(int studentId)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnStudentId + " = " + studentId + " " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.enrollmentDao.processQueryString(sql);
        }

        public List<Enrollment> getAllEnrollment(int studentId, string enrollmentStatus)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnStudentId + " = " + studentId + " " +
                         "AND " + Enrollment.columnStatus + " = '" + enrollmentStatus + "' " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.enrollmentDao.processQueryString(sql);
        }

        public Enrollment getEnrollmentByPaymentId_old(int paymentId)
        {
            Enrollment enrollment = null;

            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + "_old " +
                         "WHERE " + Enrollment.columnPaymentId + " = " + paymentId;

            List<Enrollment> enrollmentList = this.enrollmentDao.processQueryString_old(sql);
            if (enrollmentList.Count > 0)
            {
                enrollment = enrollmentList[0];
            }
            return enrollment;
        } 

        public List<Enrollment> getAllEnrollment_old()
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + "_old " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.enrollmentDao.processQueryString(sql);
        }

        public List<Enrollment> getAllEnrollment(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnEnrollmentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Enrollment.columnEnrollmentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.enrollmentDao.processQueryString(sql);
        }

        public List<Enrollment> getAllPaidEnrollment(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +                         
                         "WHERE " + Enrollment.columnEnrollmentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Enrollment.columnEnrollmentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Enrollment.columnStatus + " = '" + Enrollment.EnrollmentStatus.PAID.ToString() + "' " + 
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.enrollmentDao.processQueryString(sql);
        }

        public List<Enrollment> getAllEnrollmentByStudentId(int studentId)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnStudentId + " = " + studentId + " " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.enrollmentDao.processQueryString(sql);
        }

        public List<Enrollment> getAllEnrollmentByCourseId(int courseId)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnCourseId + " = " + courseId + " " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.enrollmentDao.processQueryString(sql);
        }

        public List<Enrollment> getAllEnrollmentByPaymentId(int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnPaymentId + " = " + paymentId + " " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.enrollmentDao.processQueryString(sql);
        }
    }
}
