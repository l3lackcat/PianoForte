using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;
using PianoForte.Dao;

namespace PianoForte.Service
{
    public class TeacherService
    {
        private TeacherDao teacherDao = new TeacherDao();

        public bool addTeacher(Teacher teacher)
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
                         "?" + Teacher.columnStatus + ")";
            /*
            string sql = "INSERT INTO " +
                         "teachers(teacherID, firstname, lastname, nickname, email, phone1, phone2, phone3, status)" +
                         "VALUES(?teacherID, ?firstname, ?lastname, ?nickname, ?email, ?phone1, ?phone2, ?phone3, ?status)";
            */
            return this.teacherDao.processInsertString(sql, teacher);
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
                         Teacher.columnStatus + " = ?" + Teacher.columnStatus + " " +
                         "WHERE " + Teacher.columnTeacherId + " = ?" + Teacher.columnTeacherId;
            /*
            string sql = "UPDATE teachers SET " +
                         "firstname = ?firstname, " +
                         "lastname = ?lastname, " +
                         "nickname = ?nickname, " +
                         "email = ?email, " +
                         "phone1 = ?phone1, " +
                         "phone2 = ?phone2, " +
                         "phone3 = ?phone3, " +
                         "status = ?status " +
                         "WHERE teacherID = ?teacherID";
            */
            return this.teacherDao.processUpdateString(sql, teacher);
        }

        public bool deleteTeacher(int teacherId)
        {
            string sql = "DELETE " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " = " + teacherId;
            /*
            string sql = "DELETE FROM teachers " +
                         "WHERE teacherID = " + teacherId;
            */
            return this.teacherDao.processDeleteString(sql);
        }

        public Teacher getLastTeacher()
        {
            Teacher teacher = null;

            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "ORDER BY " + Teacher.columnTeacherId + " DESC " +
                         "LIMIT 1";
            /*
            string sql = "SELECT TOP 1 * " +
                         "FROM teachers " +
                         "ORDER BY teacherID DESC";
            */
            List<Teacher> teacherList = this.teacherDao.processQueryString(sql);
            if (teacherList.Count > 0)
            {
                teacher = teacherList[0];
            }

            return teacher;
        }

        public Teacher getTeacher(int teacherId)
        {
            Teacher teacher = null;

            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " = " + teacherId + " " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            List<Teacher> teacherList = this.teacherDao.processQueryString(sql);
            if (teacherList.Count > 0)
            {
                teacher = teacherList[0];
            }

            return teacher;
        }

        public List<Teacher> getAllTeacher()
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.teacherDao.processQueryString(sql);

        }
        public List<Teacher> getAllTeacher(int startIndex, int offset)
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

            return this.teacherDao.processQueryString(sql);
        }

        public List<Teacher> getAllTeacher(string firstname, string lastname, string nickname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Teacher.tableName + " " +
                         "WHERE " + Teacher.columnTeacherId + " IN " +
                         "(" + this.getSubquery(firstname, lastname, nickname, startIndex, offset) + ") " +
                         "ORDER BY " + Teacher.columnTeacherId + " ASC";

            return this.teacherDao.processQueryString(sql);
        }

        private string getSubquery(string firstname, string lastname, string nickname, int startIndex, int offset)
        {
            string subQuery = "";

            if ((firstname != "") && (lastname != "") && (nickname != ""))
            {
                subQuery = this.getSubQueryByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex, offset);
            }
            else if ((firstname == "") && (lastname != "") && (nickname != ""))
            {
                subQuery = this.getSubQueryByLastnameAndNickname(lastname, nickname, startIndex, offset);
            }
            else if ((firstname != "") && (lastname == "") && (nickname != ""))
            {
                subQuery = this.getSubQueryByFirstnameAndNickname(firstname, nickname, startIndex, offset);
            }
            else if ((firstname != "") && (lastname != "") && (nickname == ""))
            {
                subQuery = this.getSubQueryByFirstnameAndLastname(firstname, lastname, startIndex, offset);
            }
            else if ((firstname == "") && (lastname == "") && (nickname != ""))
            {
                subQuery = this.getSubQueryByNickname(nickname, startIndex, offset);
            }
            else if ((firstname == "") && (lastname != "") && (nickname == ""))
            {
                subQuery = this.getSubQueryByLastname(lastname, startIndex, offset);
            }
            else if ((firstname != "") && (lastname == "") && (nickname == ""))
            {
                subQuery = this.getSubQueryByFirstname(firstname, startIndex, offset);
            }

            return subQuery;
        }

        private string getSubQueryByFirstname(string firstname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '%" + firstname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByLastname(string lastname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnLastname + " LIKE '%" + lastname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByNickname(string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnNickname + " LIKE '%" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByFirstnameAndLastname(string firstname, string lastname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '%" + firstname + "%' " +
                   "AND " + Teacher.columnLastname + " LIKE '%" + lastname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByFirstnameAndNickname(string firstname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '%" + firstname + "%' " +
                   "AND " + Teacher.columnNickname + " LIKE '%" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByLastnameAndNickname(string lastname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnLastname + " LIKE '%" + lastname + "%' " +
                   "AND " + Teacher.columnNickname + " LIKE '%" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Teacher.columnTeacherId + " " +
                   "FROM " + Teacher.tableName + " " +
                   "WHERE " + Teacher.columnFirstname + " LIKE '%" + firstname + "%' " +
                   "AND " + Teacher.columnLastname + " LIKE '%" + lastname + "%' " +
                   "AND " + Teacher.columnNickname + " LIKE '%" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }
    }
}
