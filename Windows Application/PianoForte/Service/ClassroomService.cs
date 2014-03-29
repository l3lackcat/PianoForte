using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class ClassroomService
    {
        private ClassroomDao classroomDao = new ClassroomDao();

        public bool addClassroom(Classroom classroom)
        {
            string sql = "INSERT INTO " +
                         Classroom.tableName + " (" +
                         Classroom.columnEnrollmentId + ", " +
                         Classroom.columnTeacherId + ", " +
                         Classroom.columnStartDate + ", " +
                         Classroom.columnClassDayOfWeek + ", " +
                         Classroom.columnClassTime + ", " +
                         Classroom.columnClassDuration + ", " +
                         Classroom.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Classroom.columnEnrollmentId + ", " +
                         "?" + Classroom.columnTeacherId + ", " +
                         "?" + Classroom.columnStartDate + ", " +
                         "?" + Classroom.columnClassDayOfWeek + ", " +
                         "?" + Classroom.columnClassTime + ", " +
                         "?" + Classroom.columnClassDuration + ", " +
                         "?" + Classroom.columnStatus + ")";

            return this.classroomDao.processInsertString(sql, classroom);
        }

        public bool updateClassroom(Classroom classroom)
        {
            string sql = "UPDATE " +
                         Classroom.tableName + " SET " +
                         Classroom.columnEnrollmentId + " = ?" + Classroom.columnEnrollmentId + ", " +
                         Classroom.columnTeacherId + " = ?" + Classroom.columnTeacherId + ", " +
                         Classroom.columnStartDate + " = ?" + Classroom.columnStartDate + ", " +
                         Classroom.columnClassDayOfWeek + " = ?" + Classroom.columnClassDayOfWeek + ", " +
                         Classroom.columnClassTime + " = ?" + Classroom.columnClassTime + ", " +
                         Classroom.columnClassDuration + " = ?" + Classroom.columnClassDuration + ", " +
                         Classroom.columnStatus + " = ?" + Classroom.columnStatus + " " +
                         "WHERE " + Classroom.columnClassroomId + " = ?" + Classroom.columnClassroomId;

            return this.classroomDao.processUpdateString(sql, classroom);
        }

        public bool deleteClassroom(int classroomId)
        {
            string sql = "DELETE " +
                         "FROM " + Classroom.tableName + " " +
                         "WHERE " + Classroom.columnClassroomId + " = " + classroomId;

            return this.classroomDao.processDeleteString(sql);
        }

        public Classroom getLastClassroom()
        {
            Classroom classroom = null;

            string sql = "SELECT * " +
                         "FROM " + Classroom.tableName + " " +
                         "ORDER BY " + Classroom.columnClassroomId + " DESC " +
                         "LIMIT 1";

            List<Classroom> classroomList = this.classroomDao.processQueryString(sql);
            if (classroomList.Count > 0)
            {
                classroom = classroomList[0];
            }

            return classroom;
        }

        public Classroom getClassroom(int classroomId)
        {
            Classroom classroom = null;

            string sql = "SELECT * " +
                         "FROM " + Classroom.tableName + " " +
                         "WHERE " + Classroom.columnClassroomId + " = " + classroomId;

            List<Classroom> classroomList = this.classroomDao.processQueryString(sql);
            if (classroomList.Count > 0)
            {
                classroom = classroomList[0];
            }

            return classroom;
        }
        

        public List<Classroom> getAllClassroom()
        {
            string sql = "SELECT * " +
                         "FROM " + Classroom.tableName + " " +
                         "ORDER BY " + Classroom.columnClassroomId + " ASC";

            return this.classroomDao.processQueryString(sql);
        }

        public List<Classroom> getAllClassroom(int enrollmentId)
        {
            string sql = "SELECT * " +
                         "FROM " + Classroom.tableName + " " +
                         "WHERE " + Classroom.columnEnrollmentId + " = " + enrollmentId + " " +
                         "ORDER BY " + Classroom.columnClassroomId + " ASC";

            return this.classroomDao.processQueryString(sql);
        }

        public Classroom getClassroom_old(int classroomId)
        {
            Classroom classroom = null;

            string sql = "SELECT * " +
                         "FROM " + Classroom.tableName + "_old " +
                         "WHERE " + Classroom.columnClassroomId + " = " + classroomId;

            List<Classroom> classroomList = this.classroomDao.processQueryString_old(sql);
            if (classroomList.Count > 0)
            {
                classroom = classroomList[0];
            }

            return classroom;
        }

        public List<Classroom> getAllClassroom_old()
        {
            string sql = "SELECT * " +
                         "FROM " + Classroom.tableName + "_old " +
                         "ORDER BY " + Classroom.columnClassroomId + " ASC";

            return this.classroomDao.processQueryString_old(sql);
        } 
    }
}
