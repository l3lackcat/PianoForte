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
    public class StudentDaoImplMySql : StudentDao
    {
        //--------------------------------------------------------------------------------

        public bool insertStudent(Student student)
        {
            string sql = "INSERT INTO " +
                         Student.tableName + " (" +
                         Student.columnFirstname + ", " +
                         Student.columnLastname + ", " +
                         Student.columnNickname + ", " +
                         Student.columnPhone1 + ", " +
                         Student.columnPhone2 + ", " +
                         Student.columnPhone3 + ", " +
                         Student.columnBirthday + ", " +
                         Student.columnAddress1 + ", " +
                         Student.columnAddress2 + ", " +
                         Student.columnPostCode + ", " +
                         Student.columnEmail + ", " +
                         Student.columnRegisterDate + ", " +
                         Student.columnLastDateOfClass + ", " +
                         Student.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Student.columnFirstname + ", " +
                         "?" + Student.columnLastname + ", " +
                         "?" + Student.columnNickname + ", " +
                         "?" + Student.columnPhone1 + ", " +
                         "?" + Student.columnPhone2 + ", " +
                         "?" + Student.columnPhone3 + ", " +
                         "?" + Student.columnBirthday + ", " +
                         "?" + Student.columnAddress1 + ", " +
                         "?" + Student.columnAddress2 + ", " +
                         "?" + Student.columnPostCode + ", " +
                         "?" + Student.columnEmail + ", " +
                         "?" + Student.columnRegisterDate + ", " +
                         "?" + Student.columnLastDateOfClass + ", " +
                         "?" + Student.columnStatus + ")";

            return this.processInsertCommand(sql, student);
        }

        public bool updateStudent(Student student)
        {
            string sql = "UPDATE " +
                         Student.tableName + " SET " +
                         Student.columnFirstname + " = ?" + Student.columnFirstname + ", " +
                         Student.columnLastname + " = ?" + Student.columnLastname + ", " +
                         Student.columnNickname + " = ?" + Student.columnNickname + ", " +
                         Student.columnPhone1 + " = ?" + Student.columnPhone1 + ", " +
                         Student.columnPhone2 + " = ?" + Student.columnPhone2 + ", " +
                         Student.columnPhone3 + " = ?" + Student.columnPhone3 + ", " +
                         Student.columnBirthday + " = ?" + Student.columnBirthday + ", " +
                         Student.columnAddress1 + " = ?" + Student.columnAddress1 + ", " +
                         Student.columnAddress2 + " = ?" + Student.columnAddress2 + ", " +
                         Student.columnPostCode + " = ?" + Student.columnPostCode + ", " +
                         Student.columnEmail + " = ?" + Student.columnEmail + ", " +
                         Student.columnRegisterDate + " = ?" + Student.columnRegisterDate + ", " +
                         Student.columnLastDateOfClass + " = ?" + Student.columnLastDateOfClass + ", " +
                         Student.columnStatus + " = ?" + Student.columnStatus + " " +
                         "WHERE " + Student.columnStudentId + " = ?" + Student.columnStudentId;

            return this.processUpdateCommand(sql, student);
        }

        public bool deleteStudent(int studentId)
        {
            string sql = "DELETE " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " = " + studentId;

            return this.processDeleteCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public Student findStudent(int studentId)
        {
            Student student = null;

            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " = " + studentId + " " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            List<Student> studentList = this.processSelectCommand(sql);
            if (studentList.Count > 0)
            {
                student = studentList[0];
            }

            return student;
        }

        public Student findLastStudent()
        {
            Student student = null;

            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "ORDER BY " + Student.columnStudentId + " DESC " +
                         "LIMIT 1";

            List<Student> studentList = this.processSelectCommand(sql);
            if (studentList.Count > 0)
            {
                student = studentList[0];
            }

            return student;
        }

        //--------------------------------------------------------------------------------

        public List<Student> findAllStudent()
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudent(int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQuery(startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudent(Student.StudentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudent(Student.StudentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQuery(status, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Student> findAllStudentByFirstname(string firstname)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByFirstname(string firstname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByFirstname(firstname, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByFirstname(string firstname, Student.StudentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);            
        }

        public List<Student> findAllStudentByFirstname(string firstname, Student.StudentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByFirstname(firstname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Student> findAllStudentByLastname(string lastname)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByLastname(string lastname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByLastname(lastname, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByLastname(string lastname, Student.StudentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByLastname(string lastname, Student.StudentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByLastname(lastname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Student> findAllStudentByNickname(string nickname)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByNickname(string nickname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByNickname(nickname, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByNickname(string nickname, Student.StudentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                         "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByNickname(string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByNickname(nickname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByFirstnameAndLastname(firstname, lastname, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname, Student.StudentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname, Student.StudentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByFirstnameAndLastname(firstname, lastname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByFirstnameAndNickname(firstname, nickname, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname, Student.StudentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                         "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByFirstnameAndNickname(firstname, nickname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByLastnameAndNickname(lastname, nickname, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname, Student.StudentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                         "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByLastnameAndNickname(lastname, nickname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Student.StudentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                         "AND " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                         "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                         "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getStudentSubQueryByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, status, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        //private string getSubquery(string firstname, string lastname, string nickname, int startIndex, int offset)
        //{
        //    string subQuery = "";

        //    if ((firstname != "") && (lastname != "") && (nickname != ""))
        //    {
        //        subQuery = this.getSubQueryByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex, offset);
        //    }
        //    else if ((firstname == "") && (lastname != "") && (nickname != ""))
        //    {
        //        subQuery = this.getSubQueryByLastnameAndNickname(lastname, nickname, startIndex, offset);
        //    }
        //    else if ((firstname != "") && (lastname == "") && (nickname != ""))
        //    {
        //        subQuery = this.getSubQueryByFirstnameAndNickname(firstname, nickname, startIndex, offset);
        //    }
        //    else if ((firstname != "") && (lastname != "") && (nickname == ""))
        //    {
        //        subQuery = this.getSubQueryByFirstnameAndLastname(firstname, lastname, startIndex, offset);
        //    }
        //    else if ((firstname == "") && (lastname == "") && (nickname != ""))
        //    {
        //        subQuery = this.getSubQueryByNickname(nickname, startIndex, offset);
        //    }
        //    else if ((firstname == "") && (lastname != "") && (nickname == ""))
        //    {
        //        subQuery = this.getSubQueryByLastname(lastname, startIndex, offset);
        //    }
        //    else if ((firstname != "") && (lastname == "") && (nickname == ""))
        //    {
        //        subQuery = this.getStudentSubQueryByFirstname(firstname, startIndex, offset);
        //    }

        //    return subQuery;
        //}

        //--------------------------------------------------------------------------------

        private string getStudentSubQuery(int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getStudentSubQuery(Student.StudentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getStudentSubQueryByFirstname(string firstname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getStudentSubQueryByFirstname(string firstname, Student.StudentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getStudentSubQueryByLastname(string lastname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getStudentSubQueryByLastname(string lastname, Student.StudentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getStudentSubQueryByNickname(string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getStudentSubQueryByNickname(string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                   "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getStudentSubQueryByFirstnameAndLastname(string firstname, string lastname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getStudentSubQueryByFirstnameAndLastname(string firstname, string lastname, Student.StudentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getStudentSubQueryByFirstnameAndNickname(string firstname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getStudentSubQueryByFirstnameAndNickname(string firstname, string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                   "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getStudentSubQueryByLastnameAndNickname(string lastname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getStudentSubQueryByLastnameAndNickname(string lastname, string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                   "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private string getStudentSubQueryByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getStudentSubQueryByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '" + firstname + "%' " +
                   "AND " + Student.columnLastname + " LIKE '" + lastname + "%' " +
                   "AND " + Student.columnNickname + " LIKE '" + nickname + "%' " +
                   "AND " + Student.columnStatus + " = '" + status.ToString() + "' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        //--------------------------------------------------------------------------------

        private bool processInsertCommand(string sql, Student student)
        {
            bool returnFlag = false;
            
            if (student != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Student.columnFirstname, student.Firstname);
                        command.Parameters.AddWithValue(Student.columnLastname, student.Lastname);
                        command.Parameters.AddWithValue(Student.columnNickname, student.Nickname);
                        command.Parameters.AddWithValue(Student.columnPhone1, student.Phone1);
                        command.Parameters.AddWithValue(Student.columnPhone2, student.Phone2);
                        command.Parameters.AddWithValue(Student.columnPhone3, student.Phone3);
                        command.Parameters.AddWithValue(Student.columnBirthday, student.Birthday);
                        command.Parameters.AddWithValue(Student.columnAddress1, student.Address.Address1);
                        command.Parameters.AddWithValue(Student.columnAddress2, student.Address.Address2);
                        command.Parameters.AddWithValue(Student.columnPostCode, student.Address.PostCode);
                        command.Parameters.AddWithValue(Student.columnEmail, student.Email);
                        command.Parameters.AddWithValue(Student.columnRegisterDate, student.RegisteredDate);
                        command.Parameters.AddWithValue(Student.columnLastDateOfClass, student.LastDateOfClass);
                        command.Parameters.AddWithValue(Student.columnStatus, student.Status);

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

        private bool processUpdateCommand(string sql, Student student)
        {
            bool returnFlag = false;
            
            if (student != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Student.columnFirstname, student.Firstname);
                        command.Parameters.AddWithValue(Student.columnLastname, student.Lastname);
                        command.Parameters.AddWithValue(Student.columnNickname, student.Nickname);
                        command.Parameters.AddWithValue(Student.columnPhone1, student.Phone1);
                        command.Parameters.AddWithValue(Student.columnPhone2, student.Phone2);
                        command.Parameters.AddWithValue(Student.columnPhone3, student.Phone3);
                        command.Parameters.AddWithValue(Student.columnBirthday, student.Birthday);
                        command.Parameters.AddWithValue(Student.columnAddress1, student.Address.Address1);
                        command.Parameters.AddWithValue(Student.columnAddress2, student.Address.Address2);
                        command.Parameters.AddWithValue(Student.columnPostCode, student.Address.PostCode);
                        command.Parameters.AddWithValue(Student.columnEmail, student.Email);
                        command.Parameters.AddWithValue(Student.columnRegisterDate, student.RegisteredDate);
                        command.Parameters.AddWithValue(Student.columnLastDateOfClass, student.LastDateOfClass);
                        command.Parameters.AddWithValue(Student.columnStatus, student.Status);
                        command.Parameters.AddWithValue(Student.columnStudentId, student.Id);

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

        private List<Student> processSelectCommand(string sql)
        {
            List<Student> studentList = new List<Student>();
            
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
                    dataAdapter.Fill(data, Student.tableName);

                    for (int i = 0; i < data.Tables[Student.tableName].Rows.Count; i++)
                    {
                        studentList.Add(generateStudent(data, i));
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

            return studentList;
        }

        private Student generateStudent(DataSet data, int index)
        {
            Address address = new Address();
            address.Address1 = data.Tables[Student.tableName].Rows[index][Student.columnAddress1].ToString();
            address.Address2 = data.Tables[Student.tableName].Rows[index][Student.columnAddress2].ToString();

            string postCode = data.Tables[Student.tableName].Rows[index][Student.columnPostCode].ToString();
            if (ValidateManager.isNumber(postCode))
            {
                address.PostCode = Convert.ToInt32(postCode);
            }            

            Student student = new Student();
            student.Id = Convert.ToInt32(data.Tables[Student.tableName].Rows[index][Student.columnStudentId].ToString());
            student.Firstname = data.Tables[Student.tableName].Rows[index][Student.columnFirstname].ToString();
            student.Lastname = data.Tables[Student.tableName].Rows[index][Student.columnLastname].ToString();
            student.Nickname = data.Tables[Student.tableName].Rows[index][Student.columnNickname].ToString();            
            student.Phone1 = data.Tables[Student.tableName].Rows[index][Student.columnPhone1].ToString();
            student.Phone2 = data.Tables[Student.tableName].Rows[index][Student.columnPhone2].ToString();
            student.Phone3 = data.Tables[Student.tableName].Rows[index][Student.columnPhone3].ToString();

            string birthday = data.Tables[Student.tableName].Rows[index][Student.columnBirthday].ToString();
            if (birthday == "")
            {
                student.Birthday = DateTime.Today;
            }
            else
            {
                student.Birthday = Convert.ToDateTime(birthday);
            }

            student.Address = address;

            student.Email = data.Tables[Student.tableName].Rows[index][Student.columnEmail].ToString();

            string registerDate = data.Tables[Student.tableName].Rows[index][Student.columnRegisterDate].ToString();
            if (registerDate == "")
            {
                student.RegisteredDate = DateTime.Today;
            }  
            else
            {
                student.RegisteredDate = Convert.ToDateTime(registerDate);
            }

            string lastDateOfClass = data.Tables[Student.tableName].Rows[index][Student.columnLastDateOfClass].ToString();
            if (lastDateOfClass == "")
            {
                student.LastDateOfClass = DateTime.Today;
            }
            else
            {
                student.LastDateOfClass = Convert.ToDateTime(lastDateOfClass);
            }

            string status = data.Tables[Student.tableName].Rows[index][Student.columnStatus].ToString();
            if (status == "")
            {
                student.Status = Student.StudentStatus.INACTIVE.ToString();
            }
            else
            {
                student.Status = status;
            }

            return student;
        }

        //--------------------------------------------------------------------------------
    }
}
