using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;
using PianoForte.Dao;

namespace PianoForte.Service
{
    class StudentService
    {
        private StudentDao studentDao = new StudentDao();

        public bool addStudent(Student student)
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
                         "?" + Student.columnStatus + ")";

            return this.studentDao.processInsertString(sql, student);
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
                         Student.columnStatus + " = ?" + Student.columnStatus + " " +
                         "WHERE " + Student.columnStudentId + " = ?" + Student.columnStudentId;

            return this.studentDao.processUpdateString(sql, student);
        }

        public bool deleteStudent(int studentId)
        {
            string sql = "DELETE " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " = " + studentId;

            return this.studentDao.processDeleteString(sql);
        }

        public Student getLastStudent()
        {
            Student student = null;

            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "ORDER BY " + Student.columnStudentId + " DESC " +
                         "LIMIT 1";

            List<Student> studentList = this.studentDao.processQueryString(sql);
            if (studentList.Count > 0)
            {
                student = studentList[0];
            }

            return student;
        }

        public Student getStudent(int studentId)
        {
            Student student = null;

            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " = " + studentId + " " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            List<Student> studentList = this.studentDao.processQueryString(sql);
            if (studentList.Count > 0)
            {
                student = studentList[0];
            }

            return student;
        }

        public List<Student> getAllStudent(int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Student.columnStudentId + " " +
                         "FROM " + Student.tableName + " " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Student.columnStudentId + " ASC";           

            return this.studentDao.processQueryString(sql);
        }

        public List<Student> getAllStudent(string firstname, string lastname, string nickname, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Student.tableName + " " +
                         "WHERE " + Student.columnStudentId + " IN " +
                         "(" + this.getSubquery(firstname, lastname, nickname, startIndex, offset) + ") " +
                         "ORDER BY " + Student.columnStudentId + " ASC";

            return this.studentDao.processQueryString(sql);
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
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '%" + firstname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByLastname(string lastname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnLastname + " LIKE '%" + lastname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByNickname(string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnNickname + " LIKE '%" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByFirstnameAndLastname(string firstname, string lastname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '%" + firstname + "%' " +
                   "AND " + Student.columnLastname + " LIKE '%" + lastname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByFirstnameAndNickname(string firstname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '%" + firstname + "%' " +
                   "AND " + Student.columnNickname + " LIKE '%" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByLastnameAndNickname(string lastname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnLastname + " LIKE '%" + lastname + "%' " +
                   "AND " + Student.columnNickname + " LIKE '%" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }

        private string getSubQueryByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, int startIndex, int offset)
        {
            return "SELECT * " +
                   "FROM (" +
                   "SELECT " + Student.columnStudentId + " " +
                   "FROM " + Student.tableName + " " +
                   "WHERE " + Student.columnFirstname + " LIKE '%" + firstname + "%' " +
                   "AND " + Student.columnLastname + " LIKE '%" + lastname + "%' " +
                   "AND " + Student.columnNickname + " LIKE '%" + nickname + "%' " +
                   "LIMIT " + startIndex + "," + offset + ") ALIAS";
        }
    }
}
