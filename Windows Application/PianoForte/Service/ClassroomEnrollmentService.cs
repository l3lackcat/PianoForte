using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class ClassroomEnrollmentService
    {
        private ClassroomEnrollmentDao classroomEnrollmentDao = new ClassroomEnrollmentDao();

        public bool addClassroomEnrollment(int classroomId, int enrollmentId)
        {
            string sql = "INSERT INTO " +
                         ClassroomEnrollment.tableName + " (" +
                         ClassroomEnrollment.columnClassroomId + ", " +
                         ClassroomEnrollment.columnEnrollmentId + ") " +
                         "VALUES(" +
                         "?" + ClassroomEnrollment.columnClassroomId + ", " +
                         "?" + ClassroomEnrollment.columnEnrollmentId + ")";
            /*
            string sql = "INSERT INTO " +
                         "ClassroomEnrollment(classroomID, enrollmentID)" +
                         "VALUES(?classroomID, ?enrollmentID)";
            */
            return this.classroomEnrollmentDao.processInsertString(sql, classroomId, enrollmentId);
        }

        public bool updateClassroomEnrollment(int classroomId, int enrollmentId)
        {
            string sql = "UPDATE " +
                         ClassroomEnrollment.tableName + " SET " +
                         ClassroomEnrollment.columnEnrollmentId + " = ?" + ClassroomEnrollment.columnEnrollmentId + " " +
                         "WHERE " + ClassroomEnrollment.columnClassroomId + " = ?" + ClassroomEnrollment.columnClassroomId;
            /*
            string sql = "UPDATE ClassroomEnrollment SET " +
                         "enrollmentID = ?enrollmentID " +
                         "WHERE classroomID = ?classroomID";
            */
            return this.classroomEnrollmentDao.processUpdateString(sql, classroomId, enrollmentId);
        }

        public bool deleteClassroomEnrollmentByClassroomId(int classroomId)
        {
            string sql = "DELETE " +
                         "FROM " + ClassroomEnrollment.tableName + " " +
                         "WHERE " + ClassroomEnrollment.columnClassroomId + " = " + classroomId;
            /*
            string sql = "DELETE FROM ClassroomEnrollment " +
                         "WHERE classroomID = " + classroomID;
            */
            return this.classroomEnrollmentDao.processDeleteString(sql);
        }

        public bool deleteClassroomEnrollmentByEnrollmentId(int enrollmentId)
        {
            string sql = "DELETE FROM " +
                         ClassroomEnrollment.tableName + " " +
                         "WHERE " + ClassroomEnrollment.columnEnrollmentId + " = " + enrollmentId;
            /*
            string sql = "DELETE FROM ClassroomEnrollment " +
                         "WHERE enrollmentID = " + enrollmentId;
            */
            return this.classroomEnrollmentDao.processDeleteString(sql);
        }

        public List<int> getClassroomIdByEnrollmentId(int enrollmentId)
        {
            string sql = "SELECT " + ClassroomEnrollment.columnClassroomId + " " +
                         "FROM " + ClassroomEnrollment.tableName + " " +
                         "WHERE " + ClassroomEnrollment.columnEnrollmentId + " = " + enrollmentId;

            return this.classroomEnrollmentDao.processQueryStringForClassroomId(sql);
        }
    }
}
