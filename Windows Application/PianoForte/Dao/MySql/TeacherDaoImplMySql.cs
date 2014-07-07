using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;

using PianoForte.Dao;
using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.Dao.MySql
{
    public class TeacherDaoImplMySql : TeacherDao
    {
        //--------------------------------------------------------------------------------

        public bool insertTeacher(Teacher teacher)
        {
            string sql = "INSERT INTO " +
                         Teacher.tableName + " (" +
                         Teacher.columnTeacherId + ", " +
                         Teacher.columnFirstname + ", " +
                         Teacher.columnLastname + ", " +
                         Teacher.columnNickname + ", " +
                         Teacher.columnPhone1 + ", " +
                         Teacher.columnPhone2 + ", " +
                         Teacher.columnPhone3 + ", " +
                         Teacher.columnEmail + ", " +
                         Teacher.columnSettings + ", " +
                         Teacher.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Teacher.columnTeacherId + ", " +
                         "?" + Teacher.columnFirstname + ", " +
                         "?" + Teacher.columnLastname + ", " +
                         "?" + Teacher.columnNickname + ", " +
                         "?" + Teacher.columnPhone1 + ", " +
                         "?" + Teacher.columnPhone2 + ", " +
                         "?" + Teacher.columnPhone3 + ", " +
                         "?" + Teacher.columnEmail + ", " +
                         "?" + Teacher.columnSettings + ", " +
                         "?" + Teacher.columnStatus + ")";

            return this.processInsertCommand(sql, teacher);
        }

        public bool updateTeacher(Teacher teacher)
        {
            string sql = "UPDATE " +
                         Teacher.tableName + " SET " +
                         Teacher.columnFirstname + " = ?" + Teacher.columnFirstname + ", " +
                         Teacher.columnLastname + " = ?" + Teacher.columnLastname + ", " +
                         Teacher.columnNickname + " = ?" + Teacher.columnNickname + ", " +
                         Teacher.columnPhone1 + " = ?" + Teacher.columnPhone1 + ", " +
                         Teacher.columnPhone2 + " = ?" + Teacher.columnPhone2 + ", " +
                         Teacher.columnPhone3 + " = ?" + Teacher.columnPhone3 + ", " +
                         Teacher.columnEmail + " = ?" + Teacher.columnEmail + ", " +
                         Teacher.columnSettings + " = ?" + Teacher.columnSettings + ", " +
                         Teacher.columnStatus + " = ?" + Teacher.columnStatus + " " +
                         "WHERE " + Teacher.columnTeacherId + " = ?" + Teacher.columnTeacherId;

            return this.processUpdateCommand(sql, teacher);
        }

        public bool deleteTeacher(int teacherId)
        {
            string sql = "DELETE " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " = " + teacherId;

            return this.processDeleteCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public Teacher findLastTeacher()
        {
            Teacher teacher = null;

            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "ORDER BY " + Teacher.columnTeacherId + " DESC " +
                         "LIMIT 1";

            List<Teacher> teacherList = this.processSelectCommand(sql);
            if (teacherList.Count > 0)
            {
                teacher = teacherList[0];
            }

            return teacher;
        }

        public Teacher findTeacher(int teacherId)
        {
            Teacher teacher = null;

            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " = " + teacherId + " " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            List<Teacher> teacherList = this.processSelectCommand(sql);
            if (teacherList.Count > 0)
            {
                teacher = teacherList[0];
            }

            return teacher;
        }

        //--------------------------------------------------------------------------------

        public List<Teacher> findAllTeacher()
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacher(int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Teacher.columnTeacherId + " " +
                         "FROM " + Teacher.tableName + " " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacher(Teacher.TeacherStatus status)
        {
            return null;
        }

        public List<Teacher> findAllTeacher(Teacher.TeacherStatus status, int startIndex, int offset)
        {
            return null;
        }

        //--------------------------------------------------------------------------------

        public List<Teacher> findAllTeacherByFirstname(string firstname)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstname(string firstname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByFirstname(firstname, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstname(string firstname, Teacher.TeacherStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstname(string firstname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByFirstname(firstname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Teacher> findAllTeacherByLastname(string lastname)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByLastname(string lastname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByLastname(lastname, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByLastname(string lastname, Teacher.TeacherStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByLastname(string lastname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByLastname(lastname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Teacher> findAllTeacherByNickname(string nickname)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByNickname(string nickname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByNickname(nickname, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByNickname(string nickname, Teacher.TeacherStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                         "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByNickname(string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByNickname(nickname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByFirstnameAndLastname(firstname, lastname, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname, Teacher.TeacherStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByFirstnameAndLastname(firstname, lastname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByFirstnameAndNickname(firstname, nickname, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname, Teacher.TeacherStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                         "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByFirstnameAndNickname(firstname, nickname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByLastnameAndNickname(lastname, nickname, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname, Teacher.TeacherStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                         "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByLastnameAndNickname(lastname, nickname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Teacher.TeacherStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                         "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getTeacherSubQueryByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        private string getTeacherSubquery(int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getTeacherSubquery(Teacher.TeacherStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getTeacherSubQueryByFirstname(string firstname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getTeacherSubQueryByFirstname(string firstname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getTeacherSubQueryByLastname(string lastname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getTeacherSubQueryByLastname(string lastname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getTeacherSubQueryByNickname(string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getTeacherSubQueryByNickname(string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                   "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getTeacherSubQueryByFirstnameAndLastname(string firstname, string lastname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getTeacherSubQueryByFirstnameAndLastname(string firstname, string lastname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getTeacherSubQueryByFirstnameAndNickname(string firstname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getTeacherSubQueryByFirstnameAndNickname(string firstname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                   "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getTeacherSubQueryByLastnameAndNickname(string lastname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getTeacherSubQueryByLastnameAndNickname(string lastname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                   "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getTeacherSubQueryByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getTeacherSubQueryByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Teacher.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Teacher.columnNickname + " LIKE '" + nickname + "%' " +
                   "AND " + Teacher.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private bool processInsertCommand(string sql, Teacher teacher)
        {
            bool returnFlag = false;

            if (teacher != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Teacher.columnTeacherId, teacher.Id);
                        command.Parameters.AddWithValue(Teacher.columnFirstname, teacher.Firstname);
                        command.Parameters.AddWithValue(Teacher.columnLastname, teacher.Lastname);
                        command.Parameters.AddWithValue(Teacher.columnNickname, teacher.Nickname);
                        command.Parameters.AddWithValue(Teacher.columnPhone1, teacher.Phone1);
                        command.Parameters.AddWithValue(Teacher.columnPhone2, teacher.Phone2);
                        command.Parameters.AddWithValue(Teacher.columnPhone3, teacher.Phone3);
                        command.Parameters.AddWithValue(Teacher.columnEmail, teacher.Email);
                        command.Parameters.AddWithValue(Teacher.columnSettings, Convert.ToInt32(teacher.Settings));
                        command.Parameters.AddWithValue(Teacher.columnStatus, teacher.Status);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (MySqlException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (System.SystemException e)
                {
                    LogManager.writeLog(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return returnFlag;
        }

        private bool processUpdateCommand(string sql, Teacher teacher)
        {
            bool returnFlag = false;

            if (teacher != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Teacher.columnFirstname, teacher.Firstname);
                        command.Parameters.AddWithValue(Teacher.columnLastname, teacher.Lastname);
                        command.Parameters.AddWithValue(Teacher.columnNickname, teacher.Nickname);
                        command.Parameters.AddWithValue(Teacher.columnPhone1, teacher.Phone1);
                        command.Parameters.AddWithValue(Teacher.columnPhone2, teacher.Phone2);
                        command.Parameters.AddWithValue(Teacher.columnPhone3, teacher.Phone3);
                        command.Parameters.AddWithValue(Teacher.columnEmail, teacher.Email);
                        command.Parameters.AddWithValue(Teacher.columnSettings, Convert.ToInt32(teacher.Settings));
                        command.Parameters.AddWithValue(Teacher.columnStatus, teacher.Status);
                        command.Parameters.AddWithValue(Teacher.columnTeacherId, teacher.Id);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (MySqlException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (System.SystemException e)
                {
                    LogManager.writeLog(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return returnFlag;
        }

        private bool processDeleteCommand(string sql)
        {
            bool returnFlag = false;

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);

                    int affectedRow = command.ExecuteNonQuery();
                    if (affectedRow != -1)
                    {
                        returnFlag = true;
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (MySqlException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (System.SystemException e)
            {
                LogManager.writeLog(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return returnFlag;
        }

        private List<Teacher> processSelectCommand(string sql)
        {
            List<Teacher> teacherList = new List<Teacher>();

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                    DataSet data = new DataSet();
                    dataAdapter.Fill(data, Teacher.tableName);

                    for (int i = 0; i < data.Tables[Teacher.tableName].Rows.Count; i++)
                    {
                        teacherList.Add(generateTeacher(data, i));
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (MySqlException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (System.SystemException e)
            {
                LogManager.writeLog(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return teacherList;
        }

        private Teacher generateTeacher(DataSet data, int index)
        {
            Teacher teacher = new Teacher();
            teacher.Id = Convert.ToInt32(data.Tables[Teacher.tableName].Rows[index][Teacher.columnTeacherId].ToString());
            teacher.Firstname = data.Tables[Teacher.tableName].Rows[index][Teacher.columnFirstname].ToString();
            teacher.Lastname = data.Tables[Teacher.tableName].Rows[index][Teacher.columnLastname].ToString();
            teacher.Nickname = data.Tables[Teacher.tableName].Rows[index][Teacher.columnNickname].ToString();            
            teacher.Phone1 = data.Tables[Teacher.tableName].Rows[index][Teacher.columnPhone1].ToString();
            teacher.Phone2 = data.Tables[Teacher.tableName].Rows[index][Teacher.columnPhone2].ToString();
            teacher.Phone3 = data.Tables[Teacher.tableName].Rows[index][Teacher.columnPhone3].ToString();
            teacher.Email = data.Tables[Teacher.tableName].Rows[index][Teacher.columnEmail].ToString();
            teacher.Settings = ConvertManager.toTeacherSettings(Convert.ToInt32(data.Tables[Teacher.tableName].Rows[index][Teacher.columnSettings].ToString()));
            teacher.Status = data.Tables[Teacher.tableName].Rows[index][Teacher.columnStatus].ToString();

            return teacher;
        }

        //--------------------------------------------------------------------------------
    }
}
