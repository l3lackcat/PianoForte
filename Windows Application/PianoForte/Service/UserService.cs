using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class UserService
    {
        private UserDao userDao = new UserDao();

        public bool addUser(User user)
        {
            string sql = "INSERT INTO " +
                         User.tableName + " (" +
                         User.columnUser_username + ", " +
                         User.columnUser_password + ", " +
                         User.columnUser_role + ", " +
                         User.columnUser_displayName + ") " +
                         "VALUES(" +
                         "?" + User.columnUser_username + ", " +
                         "?" + User.columnUser_password + ", " +
                         "?" + User.columnUser_role + ", " +
                         "?" + User.columnUser_displayName + ")";

            return this.userDao.processInsertString(sql, user);
        }

        public bool updateUser(User user)
        {
            string sql = "UPDATE " +
                         User.tableName + " SET " +
                         User.columnUser_username + " = ?" + User.columnUser_username + ", " +
                         User.columnUser_password + " = ?" + User.columnUser_password + ", " +
                         User.columnUser_role + " = ?" + User.columnUser_role + ", " +
                         User.columnUser_displayName + " = ?" + User.columnUser_displayName + " " +
                         "WHERE " + User.columnUser_id + " = ?" + User.columnUser_id;

            return this.userDao.processUpdateString(sql, user);
        }

        public bool deleteUser(int userId)
        {
            string sql = "DELETE " +
                         "FROM " + User.tableName + " " +
                         "WHERE " + User.columnUser_id + " = " + userId;

            return this.userDao.processDeleteString(sql);
        }

        public User getUser(int userId)
        {
            string sql = "SELECT * " +
                         "FROM " + User.tableName + " " +
                         "WHERE " + User.columnUser_id + " = " + userId;

            return this.userDao.processQueryString(sql);
        }

        public User getUser(string username)
        {
            string sql = "SELECT * " +
                         "FROM " + User.tableName + " " +
                         "WHERE " + User.columnUser_username + " = '" + username + "'";

            return this.userDao.processQueryString(sql);
        }
    }
}
