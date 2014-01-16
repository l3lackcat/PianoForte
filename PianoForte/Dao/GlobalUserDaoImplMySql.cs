using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using MySql.Data.MySqlClient;

using PianoForte.Enum;
using PianoForte.Models;
using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class GlobalUserDaoImplMySql : GlobalUserDao
    {
        private string databaseName = "pianoforte";

        private bool insert(GlobalUser globalUser, string sql)
        {
            bool returnFlag = false;

            if (globalUser != null)
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
                        command.Parameters.AddWithValue(GlobalUsers.ColumnGlobalUserUsername, globalUser.Username);
                        command.Parameters.AddWithValue(GlobalUsers.ColumnGlobalUserPassword, globalUser.Password);
                        command.Parameters.AddWithValue(GlobalUsers.ColumnGlobalUserDisplayName, globalUser.DisplayName);
                        command.Parameters.AddWithValue(GlobalUsers.ColumnGlobalUserStatus, (int)globalUser.Status);
                        command.Parameters.AddWithValue(GlobalUsers.ColumnGlobalUserRole, (int)globalUser.Role);

                        if (globalUser.Role == UserRole.ADMIN)
                        {                            
                            command.Parameters[GlobalUsers.ColumnBranchId].IsNullable = true;
                            command.Parameters[GlobalUsers.ColumnBranchId].SourceColumnNullMapping = true;
                            command.Parameters.AddWithValue(GlobalUsers.ColumnBranchId, DBNull.Value);

                            command.Parameters[GlobalUsers.ColumnUserId].IsNullable = true;
                            command.Parameters[GlobalUsers.ColumnUserId].SourceColumnNullMapping = true;
                            command.Parameters.AddWithValue(GlobalUsers.ColumnUserId, DBNull.Value);                                                        
                        }
                        else
                        {
                            command.Parameters.AddWithValue(GlobalUsers.ColumnBranchId, globalUser.BranchId);
                            command.Parameters.AddWithValue(GlobalUsers.ColumnUserId, globalUser.LocalUserId);
                        }

                        if (globalUser.LastLogin == null)
                        {
                            command.Parameters[GlobalUsers.ColumnLastLogin].IsNullable = true;
                            command.Parameters[GlobalUsers.ColumnLastLogin].SourceColumnNullMapping = true;
                            command.Parameters.AddWithValue(GlobalUsers.ColumnLastLogin, DBNull.Value); 
                        }
                        else
                        {
                            command.Parameters.AddWithValue(GlobalUsers.ColumnLastLogin, globalUser.LastLogin.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        }

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

        private bool update(GlobalUser globalUser, string sql)
        {
            bool returnFlag = false;

            if (globalUser != null)
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
                        command.Parameters.AddWithValue(GlobalUsers.ColumnGlobalUserUsername, globalUser.Username);
                        command.Parameters.AddWithValue(GlobalUsers.ColumnGlobalUserPassword, globalUser.Password);
                        command.Parameters.AddWithValue(GlobalUsers.ColumnGlobalUserDisplayName, globalUser.DisplayName);
                        command.Parameters.AddWithValue(GlobalUsers.ColumnGlobalUserStatus, (int)globalUser.Status);
                        command.Parameters.AddWithValue(GlobalUsers.ColumnGlobalUserRole, (int)globalUser.Role);

                        if (globalUser.Role == UserRole.ADMIN)
                        {
                            command.Parameters.AddWithValue(GlobalUsers.ColumnBranchId, DBNull.Value);
                            command.Parameters[GlobalUsers.ColumnBranchId].IsNullable = true;
                            command.Parameters[GlobalUsers.ColumnBranchId].SourceColumnNullMapping = true;

                            command.Parameters.AddWithValue(GlobalUsers.ColumnUserId, DBNull.Value);
                            command.Parameters[GlobalUsers.ColumnUserId].IsNullable = true;
                            command.Parameters[GlobalUsers.ColumnUserId].SourceColumnNullMapping = true;                            
                        }
                        else
                        {
                            command.Parameters.AddWithValue(GlobalUsers.ColumnBranchId, globalUser.BranchId);
                            command.Parameters.AddWithValue(GlobalUsers.ColumnUserId, globalUser.LocalUserId);
                        }

                        if (globalUser.LastLogin == null)
                        {
                            command.Parameters.AddWithValue(GlobalUsers.ColumnLastLogin, DBNull.Value);
                            command.Parameters[GlobalUsers.ColumnLastLogin].IsNullable = true;
                            command.Parameters[GlobalUsers.ColumnLastLogin].SourceColumnNullMapping = true;                            
                        }
                        else
                        {
                            command.Parameters.AddWithValue(GlobalUsers.ColumnLastLogin, globalUser.LastLogin.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        }

                        command.Parameters.AddWithValue(GlobalUsers.ColumnGlobalUserId, globalUser.Id);

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

        private List<GlobalUser> select(string sql)
        {
            List<GlobalUser> globalUserList = new List<GlobalUser>();

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
                    dataAdapter.Fill(data, GlobalUsers.TableName);

                    for (int i = 0; i < data.Tables[GlobalUsers.TableName].Rows.Count; i++)
                    {
                        GlobalUser globalUser = new GlobalUser();
                        globalUser.Id = Convert.ToInt32(data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnGlobalUserId].ToString());
                        globalUser.Username = data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnGlobalUserUsername].ToString();
                        globalUser.Password = data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnGlobalUserPassword].ToString();
                        globalUser.DisplayName = data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnGlobalUserDisplayName].ToString();
                        globalUser.Status = EnumConverter.ToStatus(data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnGlobalUserStatus].ToString());
                        globalUser.Role = EnumConverter.ToUserRole(data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnGlobalUserRole].ToString());

                        if (data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnBranchId] != DBNull.Value)
                        {
                            globalUser.BranchId = Convert.ToInt32(data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnBranchId].ToString());
                        }
                        else
                        {
                            globalUser.BranchId = 0;
                        }

                        if (data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnUserId] != DBNull.Value)
                        {
                            globalUser.LocalUserId = Convert.ToInt32(data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnUserId].ToString());
                        }
                        else
                        {
                            globalUser.LocalUserId = 0;
                        }

                        if (data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnLastLogin] != DBNull.Value)
                        {
                            globalUser.LastLogin = Convert.ToDateTime(data.Tables[GlobalUsers.TableName].Rows[i][GlobalUsers.ColumnLastLogin].ToString());
                        }
                        else
                        {
                            globalUser.LastLogin = null;
                        } 

                        globalUserList.Add(globalUser);
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

            return globalUserList;
        }

        public bool insertGlobalUser(GlobalUser globalUser)
        {
            string sql = "INSERT INTO " +
                         GlobalUsers.TableName + " (" +
                         GlobalUsers.ColumnGlobalUserUsername + ", " +
                         GlobalUsers.ColumnGlobalUserPassword + ", " +
                         GlobalUsers.ColumnGlobalUserDisplayName + ", " +
                         GlobalUsers.ColumnGlobalUserStatus + ", " +
                         GlobalUsers.ColumnGlobalUserRole + ", " +
                         GlobalUsers.ColumnBranchId + ", " +
                         GlobalUsers.ColumnGlobalUserId + ", " +
                         GlobalUsers.ColumnLastLogin + ") " +
                         "VALUES(" +
                         "?" + GlobalUsers.ColumnGlobalUserUsername + ", " +
                         "?" + GlobalUsers.ColumnGlobalUserPassword + ", " +
                         "?" + GlobalUsers.ColumnGlobalUserDisplayName + ", " +
                         "?" + GlobalUsers.ColumnGlobalUserStatus + ", " +
                         "?" + GlobalUsers.ColumnGlobalUserRole + ", " +
                         "?" + GlobalUsers.ColumnBranchId + ", " +
                         "?" + GlobalUsers.ColumnGlobalUserId + ", " +
                         "?" + GlobalUsers.ColumnLastLogin + ")";

            return this.insert(globalUser, sql);
        }

        public bool updateGlobalUser(GlobalUser globalUser)
        {
            string sql = "UPDATE " +
                         GlobalUsers.TableName + " SET " +
                         GlobalUsers.ColumnGlobalUserUsername + " = ?" + GlobalUsers.ColumnGlobalUserUsername + ", " +
                         GlobalUsers.ColumnGlobalUserPassword + " = ?" + GlobalUsers.ColumnGlobalUserPassword + ", " +
                         GlobalUsers.ColumnGlobalUserDisplayName + " = ?" + GlobalUsers.ColumnGlobalUserDisplayName + ", " +
                         GlobalUsers.ColumnGlobalUserStatus + " = ?" + GlobalUsers.ColumnGlobalUserStatus + ", " +
                         GlobalUsers.ColumnGlobalUserRole + " = ?" + GlobalUsers.ColumnGlobalUserRole + ", " +
                         GlobalUsers.ColumnBranchId + " = ?" + GlobalUsers.ColumnBranchId + ", " +
                         GlobalUsers.ColumnGlobalUserId + " = ?" + GlobalUsers.ColumnGlobalUserId + ", " +
                         GlobalUsers.ColumnLastLogin + " = ?" + GlobalUsers.ColumnLastLogin + " " +
                         "WHERE " + GlobalUsers.ColumnGlobalUserId + " = ?" + GlobalUsers.ColumnGlobalUserId;

            return this.update(globalUser, sql);
        }

        public List<GlobalUser> getGlobalUserList()
        {
            string sql = "SELECT * " +
                         "FROM " + GlobalUsers.TableName + " " +
                         "ORDER BY " + GlobalUsers.ColumnGlobalUserId + " ASC";

            return this.select(sql);
        }

        public List<GlobalUser> getGlobalUserList(string username)
        {
            string sql = "SELECT * " +
                         "FROM " + GlobalUsers.TableName + " " +
                         "WHERE " + GlobalUsers.ColumnGlobalUserUsername + " = '" + username + "'";

            return this.select(sql);
        }
    }
}