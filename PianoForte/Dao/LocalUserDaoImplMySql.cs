using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

using MySql.Data.MySqlClient;

using PianoForte.Enum;
using PianoForte.Models;
using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class LocalUserDaoImplMySql : LocalUserDao
    {
        private bool insert(string databaseName, LocalUser localUser, string sql)
        {
            bool returnFlag = false;

            if (localUser != null)
            {
                MySqlConnection conn = null;
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString;

                    conn = new MySqlConnection(connectionString);
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(LocalUsers.ColumnLocalUserFirstname, localUser.Firstname);
                        command.Parameters.AddWithValue(LocalUsers.ColumnLocalUserLastname, localUser.Lastname);
                        command.Parameters.AddWithValue(LocalUsers.ColumnLocalUserNickname, localUser.Nickname);
                        command.Parameters.AddWithValue(LocalUsers.ColumnLocalUserRole, (int)localUser.Role);
                        command.Parameters.AddWithValue(LocalUsers.ColumnLocalUserStatus, (int)localUser.Status);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    Console.Write(e.Message);
                }
                catch (MySqlException e)
                {
                    Console.Write(e.Message);
                }
                catch (System.SystemException e)
                {
                    Console.Write(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return returnFlag;
        }

        private bool update(string databaseName, LocalUser localUser, string sql)
        {
            bool returnFlag = false;

            if (localUser != null)
            {
                MySqlConnection conn = null;
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString;

                    conn = new MySqlConnection(connectionString);
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(LocalUsers.ColumnLocalUserFirstname, localUser.Firstname);
                        command.Parameters.AddWithValue(LocalUsers.ColumnLocalUserLastname, localUser.Lastname);
                        command.Parameters.AddWithValue(LocalUsers.ColumnLocalUserNickname, localUser.Nickname);
                        command.Parameters.AddWithValue(LocalUsers.ColumnLocalUserRole, (int)localUser.Role);
                        command.Parameters.AddWithValue(LocalUsers.ColumnLocalUserStatus, (int)localUser.Status);
                        command.Parameters.AddWithValue(LocalUsers.ColumnLocalUserId, localUser.Id);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    Console.Write(e.Message);
                }
                catch (MySqlException e)
                {
                    Console.Write(e.Message);
                }
                catch (System.SystemException e)
                {
                    Console.Write(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return returnFlag;
        }

        private List<LocalUser> select(string databaseName, string sql)
        {
            List<LocalUser> localUserList = new List<LocalUser>();

            MySqlConnection conn = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString;

                conn = new MySqlConnection(connectionString);
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                    DataSet data = new DataSet();
                    dataAdapter.Fill(data, LocalUsers.TableName);

                    for (int i = 0; i < data.Tables[LocalUsers.TableName].Rows.Count; i++)
                    {
                        LocalUser localUser = new LocalUser();
                        localUser.Id = Convert.ToInt32(data.Tables[LocalUsers.TableName].Rows[i][LocalUsers.ColumnLocalUserId].ToString());
                        localUser.Firstname = data.Tables[LocalUsers.TableName].Rows[i][LocalUsers.ColumnLocalUserFirstname].ToString();
                        localUser.Lastname = data.Tables[LocalUsers.TableName].Rows[i][LocalUsers.ColumnLocalUserLastname].ToString();
                        localUser.Nickname = data.Tables[LocalUsers.TableName].Rows[i][LocalUsers.ColumnLocalUserNickname].ToString();
                        localUser.Role = EnumConverter.ToUserRole(data.Tables[LocalUsers.TableName].Rows[i][LocalUsers.ColumnLocalUserRole].ToString());
                        localUser.Status = EnumConverter.ToStatus(data.Tables[LocalUsers.TableName].Rows[i][LocalUsers.ColumnLocalUserStatus].ToString());

                        localUserList.Add(localUser);
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                Console.Write(e.Message);
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
            }
            catch (System.SystemException e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return localUserList;
        }

        public bool insertLocalUser(string databaseName, LocalUser localUser)
        {
            string sql = "INSERT INTO " +
                         LocalUsers.TableName + " (" +
                         LocalUsers.ColumnLocalUserFirstname + ", " +
                         LocalUsers.ColumnLocalUserLastname + ", " +
                         LocalUsers.ColumnLocalUserNickname + ", " +
                         LocalUsers.ColumnLocalUserRole + ", " +
                         LocalUsers.ColumnLocalUserStatus + ") " +
                         "VALUES(" +
                         "?" + LocalUsers.ColumnLocalUserFirstname + ", " +
                         "?" + LocalUsers.ColumnLocalUserLastname + ", " +
                         "?" + LocalUsers.ColumnLocalUserNickname + ", " +
                         "?" + LocalUsers.ColumnLocalUserRole + ", " +
                         "?" + LocalUsers.ColumnLocalUserStatus + ")";

            return this.insert(databaseName, localUser, sql);
        }

        public bool updateLocalUser(string databaseName, LocalUser localUser)
        {
            string sql = "UPDATE " +
                         LocalUsers.TableName + " SET " +
                         LocalUsers.ColumnLocalUserFirstname + " = ?" + LocalUsers.ColumnLocalUserFirstname + ", " +
                         LocalUsers.ColumnLocalUserLastname + " = ?" + LocalUsers.ColumnLocalUserLastname + ", " +
                         LocalUsers.ColumnLocalUserNickname + " = ?" + LocalUsers.ColumnLocalUserNickname + ", " +
                         LocalUsers.ColumnLocalUserRole + " = ?" + LocalUsers.ColumnLocalUserRole + ", " +
                         LocalUsers.ColumnLocalUserStatus + " = ?" + LocalUsers.ColumnLocalUserStatus + ", " +
                         "WHERE " + LocalUsers.ColumnLocalUserId + " = ?" + LocalUsers.ColumnLocalUserId;

            return this.update(databaseName, localUser, sql);
        }

        public List<LocalUser> getLocalUserList(string databaseName, int localUserId)
        {
            string sql = "SELECT * " +
                         "FROM " + LocalUsers.TableName + " " +
                         "WHERE " + LocalUsers.ColumnLocalUserId + " = " + localUserId;

            return this.select(databaseName, sql);
        }
    }
}