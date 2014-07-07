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
    public class UserDaoImplMySql : UserDao
    {
        public bool insertUser(User user)
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

            return this.processInsertCommand(sql, user);
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

            return this.processUpdateCommand(sql, user);
        }

        public bool deleteUser(int userId)
        {
            string sql = "DELETE " +
                         "FROM " + User.tableName + " " +
                         "WHERE " + User.columnUser_id + " = " + userId;

            return this.processDeleteCommand(sql);
        }

        public User findUser(int userId)
        {
            User user = null;

            string sql = "SELECT * " +
                         "FROM " + User.tableName + " " +
                         "WHERE " + User.columnUser_id + " = " + userId;

            List<User> userList = processSelectCommand(sql);
            if (userList.Count > 0)
            {
                user = userList[0];
            }

            return user;
        }

        public User findUser(string username)
        {
            User user = null;

            string sql = "SELECT * " +
                         "FROM " + User.tableName + " " +
                         "WHERE " + User.columnUser_username + " = '" + username + "'";

            List<User> userList = processSelectCommand(sql);
            if (userList.Count > 0)
            {
                user = userList[0];
            }

            return user;
        }

        public List<User> findAllUser()
        {
            string sql = "SELECT * " +
                         "FROM " + User.tableName;

            return this.processSelectCommand(sql);
        }

        private bool processInsertCommand(string sql, User user)
        {
            bool returnFlag = false;
            if (user != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(User.columnUser_username, user.Username);
                        command.Parameters.AddWithValue(User.columnUser_password, user.Password);
                        command.Parameters.AddWithValue(User.columnUser_role, user.Role);
                        command.Parameters.AddWithValue(User.columnUser_displayName, user.DisplayName);

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

        private bool processUpdateCommand(string sql, User user)
        {
            bool returnFlag = false;
            
            if (user != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(User.columnUser_username, user.Username);
                        command.Parameters.AddWithValue(User.columnUser_password, user.Password);
                        command.Parameters.AddWithValue(User.columnUser_role, user.Role);
                        command.Parameters.AddWithValue(User.columnUser_displayName, user.DisplayName);
                        command.Parameters.AddWithValue(User.columnUser_id, user.Id);

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

        private List<User> processSelectCommand(string sql)
        {
            List<User> userList = new List<User>();

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
                    dataAdapter.Fill(data, User.tableName);

                    for (int i = 0; i < data.Tables[User.tableName].Rows.Count; i++)
                    {
                        userList.Add(generateUser(data, i));
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
            
            return userList;
        }

        private User generateUser(DataSet data, int index)
        {
            User user = new User();
            user.Id = Convert.ToInt32(data.Tables[User.tableName].Rows[index][User.columnUser_id].ToString());
            user.Username = data.Tables[User.tableName].Rows[index][User.columnUser_username].ToString();
            user.Password = data.Tables[User.tableName].Rows[index][User.columnUser_password].ToString();
            user.Role = Convert.ToInt32(data.Tables[User.tableName].Rows[index][User.columnUser_role].ToString());
            user.DisplayName = data.Tables[User.tableName].Rows[index][User.columnUser_displayName].ToString();

            return user;
        }
    }
}
