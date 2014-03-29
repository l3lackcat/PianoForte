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
    public class BranchDaoImplMySql : BranchDao
    {
        private string databaseName = "pianoforte";

        private bool insert(Branch branch, string sql)
        {
            bool returnFlag = false;

            if (branch != null)
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
                        command.Parameters.AddWithValue(Branches.ColumnBranchName, branch.Name);
                        command.Parameters.AddWithValue(Branches.ColumnBranchDatabase, branch.DatabaseName);
                        command.Parameters.AddWithValue(Branches.ColumnBranchStatus, (int)branch.Status);

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

        private bool update(Branch branch, string sql)
        {
            bool returnFlag = false;

            if (branch != null)
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
                        command.Parameters.AddWithValue(Branches.ColumnBranchName, branch.Name);
                        command.Parameters.AddWithValue(Branches.ColumnBranchDatabase, branch.DatabaseName);
                        command.Parameters.AddWithValue(Branches.ColumnBranchStatus, (int)branch.Status);
                        command.Parameters.AddWithValue(Branches.ColumnBranchId, branch.Id);

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

        private List<Branch> select(string sql)
        {
            List<Branch> bookList = new List<Branch>();

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
                    dataAdapter.Fill(data, Branches.TableName);

                    for (int i = 0; i < data.Tables[Branches.TableName].Rows.Count; i++)
                    {
                        Branch branch = new Branch();
                        branch.Id = Convert.ToInt32(data.Tables[Branches.TableName].Rows[i][Branches.ColumnBranchId].ToString());
                        branch.Name = data.Tables[Branches.TableName].Rows[i][Branches.ColumnBranchName].ToString();
                        branch.DatabaseName = data.Tables[Branches.TableName].Rows[i][Branches.ColumnBranchDatabase].ToString();
                        branch.Status = EnumConverter.ToStatus(data.Tables[Branches.TableName].Rows[i][Branches.ColumnBranchStatus].ToString());

                        bookList.Add(branch);
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

            return bookList;
        }

        public bool insertBranch(Branch branch)
        {
            string sql = "INSERT INTO " +
                         Branches.TableName + " (" +
                         Branches.ColumnBranchName + ", " +
                         Branches.ColumnBranchDatabase + ", " +
                         Branches.ColumnBranchStatus + ") " +
                         "VALUES(" +
                         "?" + Branches.ColumnBranchName + ", " +
                         "?" + Branches.ColumnBranchDatabase + ", " +
                         "?" + Branches.ColumnBranchStatus + ")";

            return this.insert(branch, sql);
        }

        public bool updateBranch(Branch branch)
        {
            string sql = "UPDATE " +
                         Branches.TableName + " SET " +
                         Branches.ColumnBranchName + " = ?" + Branches.ColumnBranchName + ", " +
                         Branches.ColumnBranchDatabase + " = ?" + Branches.ColumnBranchDatabase + ", " +
                         Branches.ColumnBranchStatus + " = ?" + Branches.ColumnBranchStatus + " " +
                         "WHERE " + Branches.ColumnBranchId + " = ?" + Branches.ColumnBranchId;

            return this.update(branch, sql);
        }

        public List<Branch> getBranchList(int branchId)
        {
            string sql = "SELECT * " +
                         "FROM " + Branches.TableName + " " +
                         "WHERE " + Branches.ColumnBranchId + " = " + branchId;

            return this.select(sql);
        }

        public List<Branch> getBranchList()
        {
            string sql = "SELECT * " +
                         "FROM " + Branches.TableName + " " +
                         "ORDER BY " + Branches.ColumnBranchId + " ASC";

            return this.select(sql);
        }
    }
}